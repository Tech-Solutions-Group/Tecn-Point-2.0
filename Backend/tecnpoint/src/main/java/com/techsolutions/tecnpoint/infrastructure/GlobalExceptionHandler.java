package com.techsolutions.tecnpoint.infrastructure;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import com.techsolutions.tecnpoint.exceptions.*;
import org.springframework.web.servlet.mvc.method.annotation.ResponseEntityExceptionHandler;

@ControllerAdvice
public class GlobalExceptionHandler extends ResponseEntityExceptionHandler {

    @ExceptionHandler(UsuarioNaoEncontradoException.class)
    private ResponseEntity<MensagemErro> UsuarioNaoEncontradoHandler(UsuarioNaoEncontradoException ex){
        MensagemErro mensagemErro = new MensagemErro(ex.getMessage(), HttpStatus.NOT_FOUND);
        return ResponseEntity.status(HttpStatus.NOT_FOUND).body(mensagemErro);
    }

    private ResponseEntity<MensagemErro> EmailExistenteHandler(EmailExistenteException ex){
        MensagemErro mensagemErro = new MensagemErro(ex.getMessage(), HttpStatus.CONFLICT);
        return ResponseEntity.status(HttpStatus.CONFLICT).body(mensagemErro);
    }
}
