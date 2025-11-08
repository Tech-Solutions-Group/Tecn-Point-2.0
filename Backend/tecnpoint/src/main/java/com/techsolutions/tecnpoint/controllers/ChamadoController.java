package com.techsolutions.tecnpoint.controllers;

import com.techsolutions.tecnpoint.entities.DTO.AberturaChamadoDTO;
import com.techsolutions.tecnpoint.entities.DTO.AtualizaChamadoDTO;
import com.techsolutions.tecnpoint.entities.DTO.ChamadoDTO;
import com.techsolutions.tecnpoint.services.ChamadoService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import java.util.List;

@RestController
@RequestMapping("/chamados")
@CrossOrigin(origins = "http://localhost:4200")
public class ChamadoController {

    @Autowired
    private ChamadoService chamadoService;

    @PostMapping("/abrir-chamado")
    public ResponseEntity<ChamadoDTO> postChamado(@RequestBody AberturaChamadoDTO aberturaChamadoDTO){
        return ResponseEntity.status(201).body(chamadoService.postChamado(aberturaChamadoDTO));
    }

    @GetMapping("/exibir-todos-chamados")
    public ResponseEntity<List<ChamadoDTO>> getAllChamados(){
        return ResponseEntity.status(200).body(chamadoService.getAllChamados());
    }

    @GetMapping("/{idChamado}")
    public ResponseEntity<ChamadoDTO> getChamadoPorId(@PathVariable Long idChamado){
        return ResponseEntity.status(200).body(chamadoService.getChamadoPorId(idChamado));
    }

    @GetMapping("/chamados-cliente/{idCliente}")
    public ResponseEntity<List<ChamadoDTO>> getChamadosCliente(@PathVariable Long idCliente){
        return ResponseEntity.status(200).body(chamadoService.getChamadosCliente(idCliente));
    }

    @GetMapping("/chamados-funcionario/{idFuncionario}")
    public ResponseEntity<List<ChamadoDTO>> getChamadosFuncionario(@PathVariable Long idFuncionario){
        return ResponseEntity.status(200).body(chamadoService.getChamadosFuncionario(idFuncionario));
    }

    @PatchMapping("/{idChamado}")
    public ResponseEntity<ChamadoDTO> updateChamado(
            @PathVariable Long idChamado,
            @RequestBody AtualizaChamadoDTO atualizaChamadoDTO) {
        return ResponseEntity.ok(chamadoService.updateChamado(idChamado, atualizaChamadoDTO));
    }
}
