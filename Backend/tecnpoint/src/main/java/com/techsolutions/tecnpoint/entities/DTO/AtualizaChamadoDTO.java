package com.techsolutions.tecnpoint.entities.DTO;

import com.techsolutions.tecnpoint.entities.enums.PrioridadeChamado;
import com.techsolutions.tecnpoint.entities.enums.StatusChamado;
import lombok.Data;

@Data
public class AtualizaChamadoDTO {
    PrioridadeChamado prioridade;
    StatusChamado status;
    Long idUsuario;
    Long idModulo;
    Long idJornada;
}
