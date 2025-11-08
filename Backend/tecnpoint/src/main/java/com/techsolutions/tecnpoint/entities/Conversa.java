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
    @Column(name = "id_conversa")
    private Long idConversa;

    @Column(name = "mensagem", columnDefinition = "TEXT")
    private String mensagem;

    @ManyToOne
    @JoinColumn(name = "fk_id_chamado", nullable = false)
    private Chamados chamado;

    @ManyToOne
    @JoinColumn(name = "fk_id_remetente", nullable = false)
    private Usuarios remetente;

    @Column(name = "data_hora", insertable = false, updatable = false,
            columnDefinition = "TIMESTAMP DEFAULT CURRENT_TIMESTAMP")
    private LocalDateTime dataHoraEnvio;

    @PrePersist
    protected void onCreate(){
        // Fallback caso o banco não aplique o DEFAULT
        if (dataHoraEnvio == null) {
            dataHoraEnvio = LocalDateTime.now();
        }
    }
}
