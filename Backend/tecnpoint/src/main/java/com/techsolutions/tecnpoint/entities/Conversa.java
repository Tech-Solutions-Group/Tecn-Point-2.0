package com.techsolutions.tecnpoint.entities;

import jakarta.persistence.*;
import lombok.*;

import java.time.LocalDateTime;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@Entity
@Builder
@Table(name = "conversa")
public class Conversa {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long idConversa;

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
