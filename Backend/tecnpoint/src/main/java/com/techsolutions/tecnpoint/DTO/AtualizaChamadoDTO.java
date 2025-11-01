package com.techsolutions.tecnpoint.DTO;

import com.techsolutions.tecnpoint.entities.Usuarios;
import com.techsolutions.tecnpoint.enums.PrioridadeChamado;
import com.techsolutions.tecnpoint.enums.StatusChamado;
import lombok.Getter;

@Getter
public class AtualizaChamadoDTO {
    Long idChamado;
    PrioridadeChamado prioridade;
    StatusChamado status;
    Long idUsuario;
    Long idModulo;
    Long idJornada;
}
