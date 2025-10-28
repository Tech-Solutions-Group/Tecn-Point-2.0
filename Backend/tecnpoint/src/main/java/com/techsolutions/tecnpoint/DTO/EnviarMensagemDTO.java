package com.techsolutions.tecnpoint.DTO;

import lombok.Getter;

@Getter
public class EnviarMensagemDTO {
    Long idChamado;
    Long idRemetente;
    String mensagem;
}
