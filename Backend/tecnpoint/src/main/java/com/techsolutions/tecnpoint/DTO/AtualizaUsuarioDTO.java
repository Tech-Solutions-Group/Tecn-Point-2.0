package com.techsolutions.tecnpoint.DTO;

import com.techsolutions.tecnpoint.enums.TipoUsuario;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class AtualizaUsuarioDTO {

    String nome;

    String email;

    String senha;

    TipoUsuario tipoUsuario;
}
