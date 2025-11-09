package com.example.techsolutions.model;

import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.AllArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class Modulo {
    private Long idModulo;
    private String modulo;

    @Override
    public String toString() {
        return modulo;
    }
}
