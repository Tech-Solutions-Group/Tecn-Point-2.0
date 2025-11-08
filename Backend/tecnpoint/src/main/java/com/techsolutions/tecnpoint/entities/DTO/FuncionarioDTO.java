package com.techsolutions.tecnpoint.entities.DTO;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
@AllArgsConstructor
@Builder
public class FuncionarioDTO {
    Long idUsuario;
    String nome;
}
