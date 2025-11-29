package com.example.techsolutions.model;

import lombok.Data;

@Data
public class MensagemDTO {
    private Long idChamado;
    private Long idRemetente;
    private String mensagem;
}