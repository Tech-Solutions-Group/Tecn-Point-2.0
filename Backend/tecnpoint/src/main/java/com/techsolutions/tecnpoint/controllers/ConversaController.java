package com.techsolutions.tecnpoint.controllers;

import com.techsolutions.tecnpoint.DTO.EnviarMensagemDTO;
import com.techsolutions.tecnpoint.DTO.VisualizacaoConversaDTO;
import com.techsolutions.tecnpoint.entities.Conversa;
import com.techsolutions.tecnpoint.services.ConversaService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/conversas")
public class ConversaController {

    @Autowired
    private ConversaService conversaService;

    @PostMapping("/enviar-mensagem")
    public ResponseEntity<VisualizacaoConversaDTO> enviarMensagem(@RequestBody EnviarMensagemDTO mensagemDTO){
        return ResponseEntity.status(201).body(conversaService.enviarMensagem(mensagemDTO));
    }
}
