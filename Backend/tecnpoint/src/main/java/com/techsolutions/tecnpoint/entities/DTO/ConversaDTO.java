package com.techsolutions.tecnpoint.entities.DTO;

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
    Long idConversa;
    UsuarioDTO remetente;
    String mensagem;
    LocalDateTime dataHoraEnvio;
}
