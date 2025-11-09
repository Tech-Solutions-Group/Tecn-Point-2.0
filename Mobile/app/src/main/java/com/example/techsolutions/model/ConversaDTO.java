package com.example.techsolutions.model;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;

@Getter
@AllArgsConstructor
@NoArgsConstructor
@Builder
public class ConversaDTO {
    private Long idConversa;
    private UsuarioLogadoDTO remetente;
    private String mensagem;
    private String dataHoraEnvio;
}
