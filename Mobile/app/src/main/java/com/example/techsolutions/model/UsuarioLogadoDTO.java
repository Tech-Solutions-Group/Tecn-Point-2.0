package com.example.techsolutions.model;

import java.io.Serializable;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class UsuarioLogadoDTO implements Serializable {
    private Long idUsuario;
    private String nome;
    private String email;
    private String tipoUsuario;
}
