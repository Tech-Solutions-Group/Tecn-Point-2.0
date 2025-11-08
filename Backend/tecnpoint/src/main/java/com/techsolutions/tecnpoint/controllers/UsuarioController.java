package com.techsolutions.tecnpoint.controllers;

import com.techsolutions.tecnpoint.entities.DTO.FuncionarioDTO;
import com.techsolutions.tecnpoint.entities.DTO.LoginUsuarioDTO;
import com.techsolutions.tecnpoint.entities.DTO.UsuarioLogadoDTO;
import com.techsolutions.tecnpoint.entities.Usuarios;
import com.techsolutions.tecnpoint.services.UsuarioService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import com.techsolutions.tecnpoint.entities.DTO.AtualizaUsuarioDTO;
import java.util.List;

@RestController
@RequestMapping("/usuarios")
@CrossOrigin(origins = "http://localhost:4200")
public class UsuarioController {

    @Autowired
    private UsuarioService usuarioService;

    @PostMapping("/login")
    public ResponseEntity<UsuarioLogadoDTO> loginUsuario(@RequestBody LoginUsuarioDTO loginUsuarioDTO) {
        return ResponseEntity.status(200).body(usuarioService.efetuarLogin(loginUsuarioDTO));
    }

    @GetMapping
    public ResponseEntity<List<Usuarios>> getAllUsuarios() {
        return ResponseEntity.status(200).body(usuarioService.getUsuarios());
    }

    @GetMapping("/{idUsuario}")
    public ResponseEntity<Usuarios> getUsuarioById(@PathVariable Long idUsuario) {
        return usuarioService.getUsuarioById(idUsuario)
                .map(usuarios -> ResponseEntity.status(200).body(usuarios))
                .orElse(ResponseEntity.status(404).build());
    }

    @PostMapping("/adicionar")
    public ResponseEntity<Usuarios> postUsuario(@RequestBody Usuarios usuarios) {
        return ResponseEntity.status(201).body(usuarioService.postUsuarios(usuarios));
    }

    @DeleteMapping("/{idUsuario}")
    public ResponseEntity<Void> delUsuario(@PathVariable Long idUsuario) {
        usuarioService.delUsuarios(idUsuario);
        return ResponseEntity.status(200).build();
    }

    @PutMapping("/{idUsuario}")
    public ResponseEntity<Usuarios> atualizarUsuario(@PathVariable Long idUsuario,
            @RequestBody AtualizaUsuarioDTO atualizaUsuarioDTO) {
        // Tirar o retorno do usuário futuramente
        return ResponseEntity.status(201).body(usuarioService.editarUsuario(idUsuario, atualizaUsuarioDTO));
    }

    @GetMapping("/listar-funcionarios")
    public ResponseEntity<List<FuncionarioDTO>> listarFuncionarios() {
        return ResponseEntity.status(200).body(usuarioService.listarFuncionarios());
    }
}
