package com.techsolutions.tecnpoint.entities.DTO;

import com.techsolutions.tecnpoint.entities.enums.TipoUsuario;
import lombok.Builder;
import lombok.Getter;

@Getter
@Builder
public class UsuarioDTO {

    Long idUsuario;
    String nome;
    TipoUsuario tipoUsuario;
}
