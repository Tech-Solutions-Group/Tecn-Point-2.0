package com.techsolutions.tecnpoint.DTO;

import com.techsolutions.tecnpoint.entities.Usuarios;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;

@Getter
@AllArgsConstructor
@NoArgsConstructor
@Builder
public class VisualizacaoConversaDTO {
    Long idConversa;
    VisualizacaoUsuarioDTO remetente;
    String mensagem;
    LocalDateTime dataHoraEnvio;
}
