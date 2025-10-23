package com.techsolutions.tecnpoint.controllers;

import com.techsolutions.tecnpoint.DTO.EnviarMensagemDTO;
import com.techsolutions.tecnpoint.DTO.VisualizacaoConversaDTO;
import com.techsolutions.tecnpoint.entities.Conversa;
import com.techsolutions.tecnpoint.services.ConversaService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/conversas")
public class ConversaController {

    @Autowired
    private ConversaService conversaService;

    @PostMapping("/enviar-mensagem")
    public ResponseEntity<VisualizacaoConversaDTO> enviarMensagem(@RequestBody EnviarMensagemDTO mensagemDTO){
        return ResponseEntity.status(201).body(conversaService.enviarMensagem(mensagemDTO));
    }

    @GetMapping("buscar-mensagens/{idChamado}")
    public ResponseEntity<List<VisualizacaoConversaDTO>> buscarMensagensPorChamado(@PathVariable Long idChamado){
        return ResponseEntity.status(200).body(conversaService.buscarMensagens(idChamado));
    }
}
