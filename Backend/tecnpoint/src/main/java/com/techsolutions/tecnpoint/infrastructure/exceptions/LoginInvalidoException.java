package com.techsolutions.tecnpoint.infrastructure.exceptions;

public class LoginInvalidoException extends RuntimeException {
    public LoginInvalidoException(String message) {
        super(message);
    }
}
