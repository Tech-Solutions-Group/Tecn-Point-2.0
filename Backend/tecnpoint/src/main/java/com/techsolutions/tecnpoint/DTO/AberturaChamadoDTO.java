package com.techsolutions.tecnpoint.DTO;

import com.techsolutions.tecnpoint.enums.PrioridadeChamado;
import com.techsolutions.tecnpoint.enums.StatusChamado;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class AberturaChamadoDTO {

    String descricao;
    String titulo;
    PrioridadeChamado prioridade;
    Long idCliente;
    Long idJornada;
    Long idModulo;
}
