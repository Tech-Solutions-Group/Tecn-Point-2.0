package com.techsolutions.tecnpoint.entities.DTO;

import com.techsolutions.tecnpoint.entities.enums.TipoUsuario;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;

@Data
@Builder
@AllArgsConstructor
public class UsuarioLogadoDTO {
    private Long idUsuario;
    private String nome;
    private String email;
    private TipoUsuario tipoUsuario;
}
