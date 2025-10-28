package com.techsolutions.tecnpoint.infrastructure;

import org.springframework.data.repository.config.RepositoryNameSpaceHandler;
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

}
