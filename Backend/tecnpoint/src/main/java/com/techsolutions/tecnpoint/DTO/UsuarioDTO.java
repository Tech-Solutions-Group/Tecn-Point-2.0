package com.techsolutions.tecnpoint.DTO;

import com.techsolutions.tecnpoint.enums.TipoUsuario;
import lombok.Builder;
import lombok.Getter;

@Getter
@Builder
public class UsuarioDTO {

    Long id_usuario;
    String nome;
    TipoUsuario tipoUsuario;
}
