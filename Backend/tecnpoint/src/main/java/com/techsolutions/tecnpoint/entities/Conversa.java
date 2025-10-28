package com.techsolutions.tecnpoint.entities;

import jakarta.persistence.*;
import lombok.*;

import java.time.LocalDateTime;
import java.time.temporal.ChronoUnit;

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

    @Column(name = "Data_Hora", columnDefinition="TIMESTAMP(0) DEFAULT CURRENT_TIMESTAMP")
    private LocalDateTime dataHoraEnvio;

    @PrePersist
    protected void OnCreate(){
        dataHoraEnvio = LocalDateTime.now().truncatedTo(ChronoUnit.NANOS);
    }
}
