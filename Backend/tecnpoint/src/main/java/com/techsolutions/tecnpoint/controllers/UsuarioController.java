package com.techsolutions.tecnpoint.controllers;

import com.techsolutions.tecnpoint.DTO.FuncionarioListagemDTO;
import com.techsolutions.tecnpoint.entities.Usuarios;
import com.techsolutions.tecnpoint.services.UsuarioService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import com.techsolutions.tecnpoint.DTO.AtualizaUsuarioDTO;
import java.util.List;

@RestController
@RequestMapping("/usuarios")
@CrossOrigin(origins = "http://localhost:4200")
public class UsuarioController {

    @Autowired
    private UsuarioService usuarioService;

    @GetMapping
    public ResponseEntity<List<Usuarios>> getUsuarios(){
        return ResponseEntity.status(200).body(usuarioService.getUsuarios());
    }

    @GetMapping("/{id_usuario}")
    public ResponseEntity<Usuarios> getUsuarioById(@PathVariable Long id_usuario){
        return usuarioService.getUsuarioById(id_usuario)
                .map(usuarios -> ResponseEntity.status(200).body(usuarios))
                .orElse(ResponseEntity.status(404).build());
    }

    @PostMapping("/adicionar")
    public ResponseEntity<Usuarios> postUsario(@RequestBody Usuarios usuarios){
        return ResponseEntity.status(201).body(usuarioService.postUsuarios(usuarios));
    }

    @DeleteMapping("/{id_usuario}")
    public ResponseEntity<Void> delUsuario(@PathVariable Long id_usuario){
        usuarioService.delUsuarios(id_usuario);
        return ResponseEntity.status(200).build();
    }

    @PutMapping("/{id_usuario}")
    public ResponseEntity<Usuarios> atualizarUsuario(@PathVariable Long id_usuario, @RequestBody AtualizaUsuarioDTO atualizaUsuarioDTO){
        // Tirar o retorno do usuário futuramente
        return ResponseEntity.status(201).body(usuarioService.editarUsuario(id_usuario, atualizaUsuarioDTO));
    }

    @GetMapping("/listar-funcionarios")
    public ResponseEntity<List<FuncionarioListagemDTO>> listarFuncionarios(){
        return ResponseEntity.status(200).body(usuarioService.listarFuncionarios());
    }
}
