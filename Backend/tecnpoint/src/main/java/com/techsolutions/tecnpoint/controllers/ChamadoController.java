package com.techsolutions.tecnpoint.controllers;

import com.techsolutions.tecnpoint.DTO.AberturaChamadoDTO;
import com.techsolutions.tecnpoint.DTO.AtualizaChamadoDTO;
import com.techsolutions.tecnpoint.DTO.ChamadoDTO;
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

    @GetMapping("/{id_chamado}")
    public ResponseEntity<ChamadoDTO> getChamadoPorId(@PathVariable Long id_chamado){
        return ResponseEntity.status(200).body(chamadoService.getChamadoPorId(id_chamado));
    }

    @GetMapping("/chamados-cliente/{id_cliente}")
    public ResponseEntity<List<ChamadoDTO>> getChamadosCliente(@PathVariable Long id_cliente){
        return ResponseEntity.status(200).body(chamadoService.getChamadosCliente(id_cliente));
    }

    @GetMapping("/chamados-funcionario/{id_funcionario}")
    public ResponseEntity<List<ChamadoDTO>> getChamadosFuncionario(@PathVariable Long id_funcionario){
        return ResponseEntity.status(200).body(chamadoService.getChamadosFuncionario(id_funcionario));
    }

    @PatchMapping("/{id_chamado}")
    public ResponseEntity<ChamadoDTO> updateChamado(
            @PathVariable Long id_chamado,
            @RequestBody AtualizaChamadoDTO atualizaChamadoDTO) {
        return ResponseEntity.ok(chamadoService.updateChamado(id_chamado, atualizaChamadoDTO));
    }
}
