package com.techsolutions.tecnpoint.DTO;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
@AllArgsConstructor
@Builder
public class FuncionarioListagemDTO {
    Long id;
    String nome;
}
