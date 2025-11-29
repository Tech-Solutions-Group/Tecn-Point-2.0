package com.example.techsolutions.model;

import lombok.Data;

@Data
public class ChamadoDTO {
    private Long idChamado;
    private String descricao;
    private String titulo;
    private String prioridade;
    private String status;
    private UsuarioLogadoDTO cliente;
    private UsuarioLogadoDTO funcionario;
    private Jornada jornada;
    private Modulo modulo;
}
