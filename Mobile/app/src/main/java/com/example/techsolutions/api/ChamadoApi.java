package com.example.techsolutions.api;

import com.example.techsolutions.model.AberturaChamadoDTO;
import com.example.techsolutions.model.ChamadoDTO;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Path;

public interface ChamadoApi {

    @POST("chamados/abrir-chamado")
    Call<AberturaChamadoDTO> abrirChamado(@Body AberturaChamadoDTO abrirChamado);

    @GET("chamados/{idChamado}")
    Call<ChamadoDTO> getChamadoPorId(@Path("idChamado") Long idChamado);

    @GET("chamados/chamados-cliente/{idCliente}")
    Call<List<ChamadoDTO>> getChamadosPorCliente(@Path("idCliente") Long idCliente);

}
