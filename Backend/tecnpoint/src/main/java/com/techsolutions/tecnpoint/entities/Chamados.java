package com.techsolutions.tecnpoint.entities;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.techsolutions.tecnpoint.entities.enums.PrioridadeChamado;
import com.techsolutions.tecnpoint.entities.enums.StatusChamado;
import jakarta.persistence.*;
import lombok.*;

import java.util.List;

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
    @Column(name = "id_chamado")
    private Long idChamado;

    @Column(name = "descricao", nullable = false, columnDefinition = "TEXT")
    private String descricao;

    @Column(name = "titulo", nullable = false, length = 100)
    private String titulo;

    @Column(name = "prioridade", nullable = false, length = 5)
    @Enumerated(EnumType.STRING)
    private PrioridadeChamado prioridade;

    @Column(name = "status", nullable = false, length = 15)
    @Enumerated(EnumType.STRING)
    private StatusChamado status;

    // Usuário que abriu o chamado
    @ManyToOne
    @JoinColumn(name = "fk_id_cliente", nullable = false)
    private Usuarios cliente;

    // Usuário que vai atender o chamado
    @ManyToOne
    @JoinColumn(name = "fk_id_funcionario", nullable = false)
    private Usuarios funcionario;

    @ManyToOne
    @JoinColumn(name = "fk_id_jornada", nullable = false)
    private Jornada jornada;

    @ManyToOne
    @JoinColumn(name = "fk_id_modulo", nullable = false)
    private Modulo modulo;

    @OneToMany(mappedBy = "chamado")
    @JsonIgnore
    private List<Conversa> conversas;
}
