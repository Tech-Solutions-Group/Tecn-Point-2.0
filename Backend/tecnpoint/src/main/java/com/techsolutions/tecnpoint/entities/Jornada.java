package com.techsolutions.tecnpoint.entities;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Entity
@Table(name = "jornada")
public class Jornada {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_jornada")
    private Long idJornada;

    private String jornada;

    @OneToMany(mappedBy = "jornada")
    @JsonIgnore
    private List<Chamados> chamados;

    public Jornada(Long idJornada, String jornada) {
        this.idJornada = idJornada;
        this.jornada = jornada;
    }
}
