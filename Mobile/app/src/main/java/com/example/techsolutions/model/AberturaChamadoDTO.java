package com.example.techsolutions.model;

import lombok.Data;

@Data
public class AberturaChamadoDTO {
    private String titulo;
    private String descricao;
    private String prioridade;
    private Long idCliente;
    private Long idJornada;
    private Long idModulo;
}
