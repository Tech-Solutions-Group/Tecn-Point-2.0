package com.techsolutions.tecnpoint.DTO;

import com.techsolutions.tecnpoint.enums.TipoUsuario;
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
