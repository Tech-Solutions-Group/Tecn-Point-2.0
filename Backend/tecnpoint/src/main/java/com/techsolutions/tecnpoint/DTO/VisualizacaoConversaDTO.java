package com.techsolutions.tecnpoint.DTO;

import com.techsolutions.tecnpoint.entities.Usuarios;
import lombok.Builder;
import lombok.Getter;

import java.time.LocalDateTime;

@Getter
@Builder
public class VisualizacaoConversaDTO {
    VisualizacaoUsuarioDTO remetente;
    String mensagem;
    LocalDateTime dataHoraEnvio;
}
