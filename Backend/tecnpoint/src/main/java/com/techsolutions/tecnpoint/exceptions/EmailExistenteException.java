package com.techsolutions.tecnpoint.exceptions;

public class EmailExistenteException extends RuntimeException {
    public EmailExistenteException(String message) {
        super(message);
    }
}
