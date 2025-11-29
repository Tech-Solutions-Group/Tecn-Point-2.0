package com.example.techsolutions.model;

import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.AllArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class Jornada {
    private Long idJornada;
    private String jornada;

    @Override
    public String toString() {
        return jornada;
    }
}
