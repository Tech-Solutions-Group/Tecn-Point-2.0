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
@Table(name = "modulo")
public class Modulo {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_modulo")
    private Long idModulo;

    private String modulo;

    @OneToMany(mappedBy = "modulo")
    @JsonIgnore
    private List<Chamados> chamados;

    public Modulo(Long idModulo, String modulo) {
        this.idModulo = idModulo;
        this.modulo = modulo;
    }
}
