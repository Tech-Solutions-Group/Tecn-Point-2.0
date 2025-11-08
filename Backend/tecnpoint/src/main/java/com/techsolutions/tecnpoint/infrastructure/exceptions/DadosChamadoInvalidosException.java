package com.techsolutions.tecnpoint.infrastructure.exceptions;

public class DadosChamadoInvalidosException extends RuntimeException{
    public DadosChamadoInvalidosException(String mensagem){
        super(mensagem);
    }
}
