package com.techsolutions.tecnpoint.entities;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import lombok.Getter;

import java.util.List;

@Getter
@Entity
@Table(name = "modulos")
public class Modulo {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id_modulo;

    private String modulo;

    @OneToMany(mappedBy = "modulo")
    @JsonIgnore
    private List<Chamados> chamados;
}
