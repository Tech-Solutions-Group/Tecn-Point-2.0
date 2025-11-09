package com.example.techsolutions.api;

import com.example.techsolutions.model.ConversaDTO;
import com.example.techsolutions.model.MensagemDTO;
import com.example.techsolutions.model.NovaMensagemDTO;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

public interface ConversaApi {

    @POST("conversas/enviar-mensagem")
    Call<ConversaDTO> enviarMensagem(@Body MensagemDTO mensagem);

    @POST("conversas/buscar-mensagens")
    Call<List<ConversaDTO>> novaMensagem(@Body NovaMensagemDTO novaMensagem);
}
