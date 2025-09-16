package com.techsolutions.tecnpoint.controllers;

import com.techsolutions.tecnpoint.entities.Usuarios;
import com.techsolutions.tecnpoint.services.UsuarioService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Repository;
import org.springframework.web.bind.annotation.*;

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
    public ResponseEntity<Usuarios> criaUsuario(@RequestBody Usuarios usuarios){
        return ResponseEntity.status(201).body(usuarioService.postUsuarios(usuarios));
    }

    @DeleteMapping("/{id_usuario}")
    public ResponseEntity<Void> deletaUsuario(@PathVariable Long id_usuario){
        usuarioService.delUsuarios(id_usuario);
        return ResponseEntity.status(200).build();
    }

}
