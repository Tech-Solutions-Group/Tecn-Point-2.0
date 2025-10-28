package com.techsolutions.tecnpoint.infrastructure;

import com.techsolutions.tecnpoint.entities.Modulo;
import org.springframework.boot.autoconfigure.graphql.GraphQlProperties;
import org.springframework.data.repository.config.RepositoryNameSpaceHandler;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import com.techsolutions.tecnpoint.exceptions.*;
import org.springframework.web.servlet.mvc.method.annotation.ResponseEntityExceptionHandler;

import javax.swing.*;

@ControllerAdvice
public class GlobalExceptionHandler extends ResponseEntityExceptionHandler {

    @ExceptionHandler(UsuarioNaoEncontradoException.class)
    private ResponseEntity<MensagemErro> UsuarioNaoEncontradoHandler(UsuarioNaoEncontradoException ex){
        MensagemErro mensagemErro = new MensagemErro(ex.getMessage(), HttpStatus.NOT_FOUND);
        return ResponseEntity.status(HttpStatus.NOT_FOUND).body(mensagemErro);
    }

    @ExceptionHandler(EmailExistenteException.class)
    private ResponseEntity<MensagemErro> EmailExistenteHandler(EmailExistenteException ex){
        MensagemErro mensagemErro = new MensagemErro(ex.getMessage(), HttpStatus.CONFLICT);
        return ResponseEntity.status(HttpStatus.CONFLICT).body(mensagemErro);
    }

    @ExceptionHandler(ChamadoNaoEncontradoException.class)
    private ResponseEntity<MensagemErro> ChamadoNaoEncontradoHandler(ChamadoNaoEncontradoException ex){
        MensagemErro mensagemErro = new MensagemErro(ex.getMessage(), HttpStatus.NOT_FOUND);
        return ResponseEntity.status(HttpStatus.NOT_FOUND).body(mensagemErro);
    }

    @ExceptionHandler(TipoUsuarioInvalidoException.class)
    private ResponseEntity<MensagemErro> TipoUsuarioInvalidoHandler(TipoUsuarioInvalidoException ex){
        MensagemErro mensagemErro = new MensagemErro(ex.getMessage(), HttpStatus.FORBIDDEN);
        return ResponseEntity.status(HttpStatus.FORBIDDEN).body(mensagemErro);
    }

    @ExceptionHandler(DadosChamadoInvalidosException.class)
    private ResponseEntity<MensagemErro> DadosChamadoInvalidosHandler(DadosChamadoInvalidosException ex){
        MensagemErro mensagemErro = new MensagemErro(ex.getMessage(), HttpStatus.BAD_REQUEST);
        return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(mensagemErro);
    }

    @ExceptionHandler(JornadaNaoEncontradaException.class)
    private ResponseEntity<MensagemErro> JornadaNaoEncontradaHandler(JornadaNaoEncontradaException ex){
        MensagemErro mensagemErro = new MensagemErro(ex.getMessage(), HttpStatus.NOT_FOUND);
        return ResponseEntity.status(HttpStatus.NOT_FOUND).body(mensagemErro);
    }

    @ExceptionHandler(ModuloNaoEncontradoException.class)
    private ResponseEntity<MensagemErro> ModuloNaoEncontradoHandler(ModuloNaoEncontradoException ex){
        MensagemErro mensagemErro = new MensagemErro(ex.getMessage(), HttpStatus.NOT_FOUND);
        return ResponseEntity.status(HttpStatus.NOT_FOUND).body(mensagemErro);
    }

    @ExceptionHandler(DadosConversaInvalidosException.class)
    private ResponseEntity<MensagemErro> DadosConversaInvalidosHandler(DadosConversaInvalidosException ex){
        MensagemErro mensagemErro = new MensagemErro(ex.getMessage(), HttpStatus.BAD_REQUEST);
        return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(mensagemErro);
    }

    @ExceptionHandler(DadosLoginInvalidosException.class)
    private ResponseEntity<MensagemErro> DadosLoginInvalidosHandler(DadosLoginInvalidosException ex){
        MensagemErro mensagemErro = new MensagemErro(ex.getMessage(), HttpStatus.BAD_REQUEST);
        return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(mensagemErro);
    }

    @ExceptionHandler(LoginInvalidoException.class)
    private ResponseEntity<MensagemErro> LoginInvalidoHandler(LoginInvalidoException ex) {
        MensagemErro mensagemErro = new MensagemErro(ex.getMessage(), HttpStatus.UNAUTHORIZED);
        return ResponseEntity.status(HttpStatus.UNAUTHORIZED).body(mensagemErro);
    }
}
