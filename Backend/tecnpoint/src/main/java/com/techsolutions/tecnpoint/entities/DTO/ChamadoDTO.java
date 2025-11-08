package com.techsolutions.tecnpoint.entities.DTO;

import com.techsolutions.tecnpoint.entities.Jornada;
import com.techsolutions.tecnpoint.entities.Modulo;
import com.techsolutions.tecnpoint.entities.enums.PrioridadeChamado;
import com.techsolutions.tecnpoint.entities.enums.StatusChamado;
import lombok.Builder;
import lombok.Getter;

@Getter
@Builder
public class ChamadoDTO {

    Long idChamado;
    String descricao;
    String titulo;
    PrioridadeChamado prioridade;
    StatusChamado status;
    UsuarioDTO cliente;
    UsuarioDTO funcionario;
    Jornada jornada;
    Modulo modulo;
}
