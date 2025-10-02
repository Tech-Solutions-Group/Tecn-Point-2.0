package com.techsolutions.tecnpoint.entities;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import lombok.Getter;
import java.util.List;

@Getter
@Entity
@Table(name = "jornada")
public class Jornada {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id_jornada;

    private String jornada;

    @OneToMany(mappedBy = "jornada")
    @JsonIgnore
    private List<Chamados> chamados;
}
