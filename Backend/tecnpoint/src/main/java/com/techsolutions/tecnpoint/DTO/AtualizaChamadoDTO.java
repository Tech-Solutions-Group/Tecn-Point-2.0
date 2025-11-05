package com.techsolutions.tecnpoint.DTO;

import com.techsolutions.tecnpoint.entities.Usuarios;
import com.techsolutions.tecnpoint.enums.PrioridadeChamado;
import com.techsolutions.tecnpoint.enums.StatusChamado;
import lombok.Data;

@Data
public class AtualizaChamadoDTO {
    PrioridadeChamado prioridade;
    StatusChamado status;
    Long idUsuario;
    Long idModulo;
    Long idJornada;
}
