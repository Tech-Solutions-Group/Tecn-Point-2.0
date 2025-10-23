package com.techsolutions.tecnpoint.entities;

import jakarta.persistence.*;
import lombok.Builder;
import lombok.Getter;
import lombok.Setter;

import java.time.LocalDateTime;

@Getter
@Setter
@Entity
@Builder
@Table(name = "conversa")
public class Conversa {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id_conversa;

    @Column(columnDefinition = "TEXT")
    private String mensagem;

    @ManyToOne
    @JoinColumn(name = "fk_idChamado", nullable = false)
    private Chamados chamado;

    @ManyToOne
    @JoinColumn(name = "fk_idRemetente", nullable = false)
    private Usuarios remetente;

    @Column(name = "Data_Hora")
    private LocalDateTime dataHoraEnvio;
}
