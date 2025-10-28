package com.techsolutions.tecnpoint.DTO;

import com.techsolutions.tecnpoint.entities.Jornada;
import com.techsolutions.tecnpoint.entities.Modulo;
import com.techsolutions.tecnpoint.enums.PrioridadeChamado;
import com.techsolutions.tecnpoint.enums.StatusChamado;
import lombok.Builder;
import lombok.Getter;

@Getter
@Builder
public class ChamadoDTO {

    Long id_chamado;
    String descricao;
    String titulo;
    PrioridadeChamado prioridade;
    StatusChamado status;
    UsuarioDTO cliente;
    UsuarioDTO funcionario;
    Jornada jornada;
    Modulo modulo;
}
