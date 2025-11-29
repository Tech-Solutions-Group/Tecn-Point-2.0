package com.techsolutions.tecnpoint.infrastructure.exceptions;

public class EmailExistenteException extends RuntimeException {
    public EmailExistenteException(String message) {
        super(message);
    }
}
