package com.techsolutions.tecnpoint.controllers;

import com.techsolutions.tecnpoint.DTO.AberturaChamadoDTO;
import com.techsolutions.tecnpoint.entities.Chamados;
import com.techsolutions.tecnpoint.services.ChamadoService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/chamados")
public class ChamadoController {

    @Autowired
    private ChamadoService chamadoService;

    @PostMapping("/abrir-chamado")
    public ResponseEntity<Chamados> postChamado(@RequestBody AberturaChamadoDTO aberturaChamadoDTO){
        return ResponseEntity.status(201).body(chamadoService.postChamado(aberturaChamadoDTO));
    }
}
