package com.techsolutions.tecnpoint.entities;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import lombok.Getter;

import java.util.List;

@Getter
@Entity
@Table(name = "modulo")
public class Modulo {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long idModulo;

    private String modulo;

    @OneToMany(mappedBy = "modulo")
    @JsonIgnore
    private List<Chamados> chamados;
}
