package com.techsolutions.tecnpoint.entities;

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
    private List<Chamados> chamados;
}
