package com.techsolutions.tecnpoint.exceptions;

public class UsuarioNaoEncontradoException extends RuntimeException{

    public UsuarioNaoEncontradoException(String mensagem){
        super(mensagem);
    }
}
