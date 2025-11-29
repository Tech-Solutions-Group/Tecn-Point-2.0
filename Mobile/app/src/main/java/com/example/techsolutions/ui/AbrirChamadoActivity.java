package com.example.techsolutions.ui;

import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.example.techsolutions.R;
import com.example.techsolutions.api.ChamadoApi;
import com.example.techsolutions.api.RetrofitClient;
import com.example.techsolutions.model.AberturaChamadoDTO;
import com.example.techsolutions.model.Jornada;
import com.example.techsolutions.model.Modulo;
import com.example.techsolutions.model.UsuarioLogadoDTO;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class AbrirChamadoActivity extends AppCompatActivity {

    private EditText inputTitulo, inputDescricao;
    private Spinner spinnerPrioridade, spinnerModulo, spinnerJornada;
    private Button btnAbrirChamado, btnVoltar;

    private UsuarioLogadoDTO usuarioLogado;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_abrir_chamado);

        inputTitulo = findViewById(R.id.inputTitulo);
        inputDescricao = findViewById(R.id.inputDescricao);
        spinnerPrioridade = findViewById(R.id.spinnerPrioridade);
        spinnerModulo = findViewById(R.id.spinnerModulo);
        spinnerJornada = findViewById(R.id.spinnerJornada);
        btnAbrirChamado = findViewById(R.id.btnAbrirChamado);
        btnVoltar = findViewById(R.id.btnVoltar);

        usuarioLogado = (UsuarioLogadoDTO) getIntent().getSerializableExtra("usuarioLogado");

        configurarSpinners();
        configurarBotao();

        btnVoltar.setOnClickListener(v -> finish());
    }

    private void configurarSpinners() {
        String[] prioridades = {"Baixa", "Média", "Alta"};
        spinnerPrioridade.setAdapter(new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, prioridades));

        Modulo[] modulos = {
                new Modulo(1L, "Hardware"),
                new Modulo(2L, "Software"),
                new Modulo(3L, "Rede")
        };
        spinnerModulo.setAdapter(new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, modulos));

        Jornada[] jornadas = {
                new Jornada(1L, "Financeiro"),
                new Jornada(2L, "Marketing"),
                new Jornada(3L, "Recursos Humanos")
        };
        spinnerJornada.setAdapter(new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, jornadas));
    }

    private void configurarBotao() {
        btnAbrirChamado.setOnClickListener(v -> abrirChamado());
    }

    private void abrirChamado() {
        String titulo = inputTitulo.getText().toString().trim();
        String descricao = inputDescricao.getText().toString().trim();
        String prioridadeSelecionada = spinnerPrioridade.getSelectedItem().toString();

        if (titulo.isEmpty() || descricao.isEmpty()) {
            Toast.makeText(this, "Preencha todos os campos obrigatórios", Toast.LENGTH_SHORT).show();
            return;
        }

        String prioridade;
        switch (prioridadeSelecionada) {
            case "Média":
                prioridade = "MEDIA";
                break;
            case "Alta":
                prioridade = "ALTA";
                break;
            default:
                prioridade = "BAIXA";
                break;
        }

        Modulo moduloSelecionado = (Modulo) spinnerModulo.getSelectedItem();
        Jornada jornadaSelecionada = (Jornada) spinnerJornada.getSelectedItem();

        AberturaChamadoDTO chamado = new AberturaChamadoDTO();
        chamado.setTitulo(titulo);
        chamado.setDescricao(descricao);
        chamado.setPrioridade(prioridade);
        chamado.setIdCliente(usuarioLogado.getIdUsuario());
        chamado.setIdModulo(moduloSelecionado.getIdModulo());
        chamado.setIdJornada(jornadaSelecionada.getIdJornada());

        ChamadoApi api = RetrofitClient.getRetrofitInstance().create(ChamadoApi.class);
        Call<AberturaChamadoDTO> call = api.abrirChamado(chamado);

        btnAbrirChamado.setEnabled(false);

        call.enqueue(new Callback<AberturaChamadoDTO>() {
            @Override
            public void onResponse(Call<AberturaChamadoDTO> call, Response<AberturaChamadoDTO> response) {
                btnAbrirChamado.setEnabled(true);
                if (response.isSuccessful()) {
                    Toast.makeText(AbrirChamadoActivity.this, "Chamado aberto com sucesso!", Toast.LENGTH_SHORT).show();
                    setResult(RESULT_OK);
                    finish();
                } else {
                    Toast.makeText(AbrirChamadoActivity.this, "Erro ao abrir chamado", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<AberturaChamadoDTO> call, Throwable t) {
                btnAbrirChamado.setEnabled(true);
                Toast.makeText(AbrirChamadoActivity.this, "Falha na conexão: " + t.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }
}
