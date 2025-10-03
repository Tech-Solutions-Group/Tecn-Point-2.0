package com.techsolutions.tecnpoint.controllers;

import com.techsolutions.tecnpoint.DTO.AberturaChamadoDTO;
import com.techsolutions.tecnpoint.DTO.VisualizacaoChamadoDTO;
import com.techsolutions.tecnpoint.entities.Chamados;
import com.techsolutions.tecnpoint.services.ChamadoService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/chamados")
public class ChamadoController {

    @Autowired
    private ChamadoService chamadoService;

    @PostMapping("/abrir-chamado")
    public ResponseEntity<VisualizacaoChamadoDTO> postChamado(@RequestBody AberturaChamadoDTO aberturaChamadoDTO){
        return ResponseEntity.status(201).body(chamadoService.postChamado(aberturaChamadoDTO));
    }

    @GetMapping("/exibir-todos-chamados")
    public ResponseEntity<List<Chamados>> getAllChamados(){
        return ResponseEntity.status(200).body(chamadoService.getAllChamados());
    }

    @GetMapping("/chamados-cliente/{id_cliente}")
    public ResponseEntity<List<VisualizacaoChamadoDTO>> getChamadosCliente(@PathVariable Long id_cliente){
        return ResponseEntity.status(200).body(chamadoService.getChamadosCliente(id_cliente));
    }

    @GetMapping("/chamados-funcionario/{id_funcionario}")
    public ResponseEntity<List<VisualizacaoChamadoDTO>> getChamadosFuncionario(@PathVariable Long id_funcionario){
        return ResponseEntity.status(200).body(chamadoService.getChamadosFuncionario(id_funcionario));
    }
}
