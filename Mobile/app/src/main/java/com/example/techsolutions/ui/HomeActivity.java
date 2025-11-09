package com.example.techsolutions.ui;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import androidx.activity.result.ActivityResultLauncher;
import androidx.activity.result.contract.ActivityResultContracts;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.techsolutions.R;
import com.example.techsolutions.adapter.ChamadoAdapter;
import com.example.techsolutions.api.ChamadoApi;
import com.example.techsolutions.api.RetrofitClient;
import com.example.techsolutions.model.ChamadoDTO;
import com.example.techsolutions.model.UsuarioLogadoDTO;

import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class HomeActivity extends AppCompatActivity {

    private TextView txtNome, txtEmail;
    private RecyclerView recyclerChamados;
    private Button btnSair, btnAbrirChamado;
    private UsuarioLogadoDTO usuario;

    private final ActivityResultLauncher<Intent> abrirChamadoLauncher =
            registerForActivityResult(new ActivityResultContracts.StartActivityForResult(), result -> {
                if (result.getResultCode() == RESULT_OK && usuario != null) {
                    carregarChamados(usuario.getIdUsuario());
                    Toast.makeText(this, "Chamado criado com sucesso!", Toast.LENGTH_SHORT).show();
                }
            });

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);

        txtNome = findViewById(R.id.txtNome);
        txtEmail = findViewById(R.id.txtEmail);
        recyclerChamados = findViewById(R.id.recyclerChamados);
        btnSair = findViewById(R.id.btnSair);
        btnAbrirChamado = findViewById(R.id.btnAbrirChamado);

        recyclerChamados.setLayoutManager(new LinearLayoutManager(this));

        usuario = (UsuarioLogadoDTO) getIntent().getSerializableExtra("usuarioLogado");

        if (usuario != null) {
            txtNome.setText(usuario.getNome());
            txtEmail.setText(usuario.getEmail());
            carregarChamados(usuario.getIdUsuario());
        }

        btnAbrirChamado.setOnClickListener(v -> {
            Intent intent = new Intent(HomeActivity.this, AbrirChamadoActivity.class);
            intent.putExtra("usuarioLogado", usuario);
            abrirChamadoLauncher.launch(intent);
        });

        btnSair.setOnClickListener(v -> {
            Intent intent = new Intent(HomeActivity.this, LoginActivity.class);
            startActivity(intent);
            finish();
        });
    }

    private void carregarChamados(Long idCliente) {
        ChamadoApi chamadoApi = RetrofitClient.getRetrofitInstance().create(ChamadoApi.class);
        Call<List<ChamadoDTO>> call = chamadoApi.getChamadosPorCliente(idCliente);

        call.enqueue(new Callback<List<ChamadoDTO>>() {
            @Override
            public void onResponse(Call<List<ChamadoDTO>> call, Response<List<ChamadoDTO>> response) {
                if (response.isSuccessful() && response.body() != null && !response.body().isEmpty()) {
                    List<ChamadoDTO> lista = response.body();


                    for (ChamadoDTO c : lista) {
                        c.setStatus(formatarStatus(c.getStatus()));
                    }

                    recyclerChamados.setAdapter(new ChamadoAdapter(lista, HomeActivity.this, usuario));
                } else {
                    Toast.makeText(HomeActivity.this, "Nenhum chamado encontrado", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<List<ChamadoDTO>> call, Throwable t) {
                Log.e("API", "Erro ao carregar chamados", t);
                Toast.makeText(HomeActivity.this, "Erro ao conectar ao servidor", Toast.LENGTH_SHORT).show();
            }
        });
    }


    private String formatarStatus(String status) {
        switch (status) {
            case "EM_ANDAMENTO":
                return "Em Andamento";
            case "PENDENTE":
                return "Pendente";
            case "ABERTO":
                return "Aberto";
            case "RESOLVIDO":
                return "Resolvido";
            default:
                return status;
        }
    }

}
