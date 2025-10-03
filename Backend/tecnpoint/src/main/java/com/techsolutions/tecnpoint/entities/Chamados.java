package com.techsolutions.tecnpoint.entities;

import com.techsolutions.tecnpoint.enums.PrioridadeChamado;
import com.techsolutions.tecnpoint.enums.StatusChamado;
import jakarta.persistence.*;
import lombok.*;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@Builder
@Entity
@Table(name = "chamados")
public class Chamados {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id_chamado;

    @Column(nullable = false, columnDefinition = "TEXT")
    private String descricao;

    @Column(nullable = false, length = 100)
    private String titulo;

    @Column(nullable = false)
    @Enumerated(EnumType.STRING)
    private PrioridadeChamado prioridade;

    @Column(nullable = false)
    @Enumerated(EnumType.STRING)
    private StatusChamado status;

    // Usuário que abriu o chamado
    @ManyToOne
    @JoinColumn(name = "fk_idCliente", nullable = false)
    private Usuarios cliente;

    // Usuário que vai atender o chamado
    @ManyToOne
    @JoinColumn(name = "fk_idFuncionario", nullable = false)
    private Usuarios funcionario;

    @ManyToOne
    @JoinColumn(name = "fk_idJornada", nullable = false)
    private Jornada jornada;

    @ManyToOne
    @JoinColumn(name = "fk_idModulo", nullable = false)
    private Modulo modulo;

}
