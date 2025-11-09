package com.example.techsolutions.ui;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.example.techsolutions.R;
import com.example.techsolutions.api.RetrofitClient;
import com.example.techsolutions.api.UsuarioApi;
import com.example.techsolutions.model.UsuarioLoginDTO;
import com.example.techsolutions.model.UsuarioLogadoDTO;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class LoginActivity extends AppCompatActivity {

    private EditText emailInput, senhaInput;
    private Button btnLogin;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        emailInput = findViewById(R.id.inputEmail);
        senhaInput = findViewById(R.id.inputSenha);
        btnLogin = findViewById(R.id.btnLogin);

        btnLogin.setOnClickListener(v -> fazerLogin());
    }

    private void fazerLogin() {
        String email = emailInput.getText().toString().trim();
        String senha = senhaInput.getText().toString().trim();

        if (email.isEmpty() || senha.isEmpty()) {
            Toast.makeText(this, "Preencha todos os campos", Toast.LENGTH_SHORT).show();
            return;
        }

        UsuarioLoginDTO loginDTO = new UsuarioLoginDTO();
        loginDTO.setEmail(email);
        loginDTO.setSenha(senha);

        UsuarioApi api = RetrofitClient.getRetrofitInstance().create(UsuarioApi.class);
        Call<UsuarioLogadoDTO> call = api.usuarioLogin(loginDTO);

        call.enqueue(new Callback<UsuarioLogadoDTO>() {
            @Override
            public void onResponse(Call<UsuarioLogadoDTO> call, Response<UsuarioLogadoDTO> response) {
                if (response.isSuccessful() && response.body() != null) {
                    UsuarioLogadoDTO usuario = response.body();

                    if (!"CLIENTE".equalsIgnoreCase(usuario.getTipoUsuario())) {
                        Toast.makeText(LoginActivity.this, "Acesso permitido apenas para clientes.", Toast.LENGTH_SHORT).show();
                        return;
                    }

                    Toast.makeText(LoginActivity.this, "Bem-vindo, " + usuario.getNome(), Toast.LENGTH_SHORT).show();

                    Intent intent = new Intent(LoginActivity.this, HomeActivity.class);
                    intent.putExtra("usuarioLogado", usuario);
                    startActivity(intent);
                    finish();
                } else {
                    Toast.makeText(LoginActivity.this, "Login inválido!", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<UsuarioLogadoDTO> call, Throwable t) {
                Toast.makeText(LoginActivity.this, "Erro: " + t.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }
}
