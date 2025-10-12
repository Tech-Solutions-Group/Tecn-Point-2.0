package com.techsolutions.tecnpoint.entities;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.techsolutions.tecnpoint.enums.TipoUsuario;
import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;
import java.util.List;

@Getter
@Setter
@Entity
@Table(name = "usuarios")
public class Usuarios {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id_usuario;

    @Column(nullable = false, length = 255)
    private String nome;

    @Column(unique = true, nullable = false, length = 255)
    private String email;

    @Column(nullable = false)
    private String senha;

    @Column(name = "tipo_usuario", nullable = false)
    @Enumerated(EnumType.STRING)
    private TipoUsuario tipoUsuario;

    // Chamados abertos pelo usuário
    @OneToMany(mappedBy = "cliente")
    @JsonIgnore
    private List<Chamados> chamadosCliente;

    // Chamados atendidos pelo usuário
    @OneToMany(mappedBy = "funcionario")
    @JsonIgnore
    private List<Chamados> chamadosFuncionario;
}
