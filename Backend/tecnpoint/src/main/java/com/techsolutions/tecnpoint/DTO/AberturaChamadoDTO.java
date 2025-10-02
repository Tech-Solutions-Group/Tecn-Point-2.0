package com.techsolutions.tecnpoint.DTO;

import com.techsolutions.tecnpoint.enums.PrioridadeChamado;
import com.techsolutions.tecnpoint.enums.StatusChamado;
import lombok.Getter;

@Getter
public class AberturaChamadoDTO {

    String descricao;
    String titulo;
    PrioridadeChamado prioridade;
    StatusChamado status;
    Long idCliente;
    Long idFuncionario;
    Long idJornada;
    Long idModulo;
}
