package com.example.techsolutions.api;

import com.example.techsolutions.model.UsuarioLogadoDTO;
import com.example.techsolutions.model.UsuarioLoginDTO;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

public interface UsuarioApi {
    @POST("usuarios/login")
    Call<UsuarioLogadoDTO> usuarioLogin(@Body UsuarioLoginDTO usuarioLogin);
}
