package com.techsolutions.tecnpoint.infrastructure.exceptions;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;
import org.springframework.http.HttpStatus;

@Getter
@Setter
@AllArgsConstructor
public class MensagemErro {
    private String mensagem;
    private HttpStatus status;
}
