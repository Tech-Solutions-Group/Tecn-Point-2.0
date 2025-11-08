package com.techsolutions.tecnpoint.entities.DTO;

import com.techsolutions.tecnpoint.entities.enums.PrioridadeChamado;
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
