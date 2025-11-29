package com.techsolutions.tecnpoint.infrastructure.exceptions;

public class ChamadoNaoEncontradoException extends RuntimeException {
    public ChamadoNaoEncontradoException(String message) {
        super(message);
    }
}
