package com.techsolutions.tecnpoint.DTO;

import com.techsolutions.tecnpoint.enums.TipoUsuario;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;

@Getter
@Builder
public class VisualizacaoUsuarioDTO {

    Long id_usuario;
    String nome;
    TipoUsuario tipoUsuario;
}
