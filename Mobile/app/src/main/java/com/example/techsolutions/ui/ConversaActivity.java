package com.example.techsolutions.ui;

import android.os.Bundle;
import android.os.Handler;
import android.util.Log;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.techsolutions.R;
import com.example.techsolutions.adapter.ConversaAdapter;
import com.example.techsolutions.api.ConversaApi;
import com.example.techsolutions.api.RetrofitClient;
import com.example.techsolutions.model.ConversaDTO;
import com.example.techsolutions.model.MensagemDTO;
import com.example.techsolutions.model.NovaMensagemDTO;
import com.example.techsolutions.model.UsuarioLogadoDTO;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ConversaActivity extends AppCompatActivity {

    private RecyclerView recyclerMensagens;
    private EditText edtMensagem;
    private Button btnEnviar;
    private Button btnVoltar;

    private ConversaAdapter adapter;
    private final List<ConversaDTO> mensagens = new ArrayList<>();

    private Long idChamado;
    private UsuarioLogadoDTO usuarioLogado;
    private Long idUltimaConversa = 0L;

    private ConversaApi conversaApi;
    private final Handler handler = new Handler();
    private Runnable atualizador;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_conversa);

        recyclerMensagens = findViewById(R.id.recyclerMensagens);
        edtMensagem = findViewById(R.id.edtMensagem);
        btnEnviar = findViewById(R.id.btnEnviar);
        btnVoltar = findViewById(R.id.btnVoltar);

        idChamado = getIntent().getLongExtra("idChamado", 0L);
        usuarioLogado = (UsuarioLogadoDTO) getIntent().getSerializableExtra("usuarioLogado");

        conversaApi = RetrofitClient.getRetrofitInstance().create(ConversaApi.class);
        adapter = new ConversaAdapter(mensagens, this);
        adapter.setUsuarioLogado(usuarioLogado);
        recyclerMensagens.setLayoutManager(new LinearLayoutManager(this));
        recyclerMensagens.setAdapter(adapter);

        btnVoltar.setOnClickListener(v -> finish());

        btnEnviar.setOnClickListener(v -> enviarMensagem());

        atualizador = new Runnable() {
            @Override
            public void run() {
                buscarNovasMensagens();
                handler.postDelayed(this, 3000);
            }
        };

        carregarMensagensIniciais();
    }

    private void carregarMensagensIniciais() {
        NovaMensagemDTO request = new NovaMensagemDTO();
        request.setIdChamado(idChamado);
        request.setIdUltimaConversa(0L);

        conversaApi.novaMensagem(request).enqueue(new Callback<List<ConversaDTO>>() {
            @Override
            public void onResponse(Call<List<ConversaDTO>> call, Response<List<ConversaDTO>> response) {
                if (response.isSuccessful() && response.body() != null) {
                    mensagens.clear();
                    mensagens.addAll(response.body());

                    if (!mensagens.isEmpty()) {
                        idUltimaConversa = mensagens.get(mensagens.size() - 1).getIdConversa();
                    }

                    adapter.notifyDataSetChanged();
                    recyclerMensagens.scrollToPosition(mensagens.size() - 1);

                    handler.postDelayed(atualizador, 3000);
                } else {
                    Toast.makeText(ConversaActivity.this, "Erro ao carregar mensagens", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<List<ConversaDTO>> call, Throwable t) {
                Log.e("Conversa", "Erro ao buscar mensagens: " + t.getMessage());
            }
        });
    }

    private void buscarNovasMensagens() {
        NovaMensagemDTO request = new NovaMensagemDTO();
        request.setIdChamado(idChamado);
        request.setIdUltimaConversa(idUltimaConversa);

        conversaApi.novaMensagem(request).enqueue(new Callback<List<ConversaDTO>>() {
            @Override
            public void onResponse(Call<List<ConversaDTO>> call, Response<List<ConversaDTO>> response) {
                if (response.isSuccessful() && response.body() != null && !response.body().isEmpty()) {
                    List<ConversaDTO> novas = response.body();

                    for (ConversaDTO nova : novas) {
                        boolean jaExiste = false;
                        for (ConversaDTO antiga : mensagens) {
                            if (antiga.getIdConversa().equals(nova.getIdConversa())) {
                                jaExiste = true;
                                break;
                            }
                        }
                        if (!jaExiste) {
                            mensagens.add(nova);
                        }
                    }

                    adapter.notifyItemRangeInserted(mensagens.size() - novas.size(), novas.size());
                    recyclerMensagens.scrollToPosition(mensagens.size() - 1);

                    idUltimaConversa = mensagens.get(mensagens.size() - 1).getIdConversa();
                }
            }

            @Override
            public void onFailure(Call<List<ConversaDTO>> call, Throwable t) {
                Log.e("Conversa", "Erro ao buscar novas mensagens: " + t.getMessage());
            }
        });
    }

    private void enviarMensagem() {
        String texto = edtMensagem.getText().toString().trim();
        if (texto.isEmpty()) return;

        MensagemDTO mensagem = new MensagemDTO();
        mensagem.setIdChamado(idChamado);
        mensagem.setIdRemetente(usuarioLogado.getIdUsuario());
        mensagem.setMensagem(texto);

        conversaApi.enviarMensagem(mensagem).enqueue(new Callback<ConversaDTO>() {
            @Override
            public void onResponse(Call<ConversaDTO> call, Response<ConversaDTO> response) {
                if (response.isSuccessful() && response.body() != null) {
                    ConversaDTO nova = response.body();
                    mensagens.add(nova);
                    adapter.notifyItemInserted(mensagens.size() - 1);
                    recyclerMensagens.scrollToPosition(mensagens.size() - 1);
                    edtMensagem.setText("");
                    idUltimaConversa = nova.getIdConversa();
                } else {
                    Toast.makeText(ConversaActivity.this, "Erro ao enviar mensagem", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<ConversaDTO> call, Throwable t) {
                Log.e("Conversa", "Erro ao enviar mensagem: " + t.getMessage());
            }
        });
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        handler.removeCallbacks(atualizador);
    }
}
