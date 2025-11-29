package com.techsolutions.tecnpoint.entities;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.techsolutions.tecnpoint.entities.enums.TipoUsuario;
import jakarta.persistence.*;
import lombok.*;

import java.util.List;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Entity
@Table(name = "usuarios")
public class Usuarios {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_usuario")
    private Long idUsuario;

    @Column(name = "nome", nullable = false, length = 100)
    private String nome;

    @Column(name = "email",unique = true, nullable = false, length = 100)
    private String email;

    @Column(name = "senha",nullable = false, length = 100)
    private String senha;

    @Column(name = "tipo_usuario", nullable = false, length = 15)
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

    @OneToMany(mappedBy = "remetente")
    @JsonIgnore
    private List<Conversa> conversas;

    public Usuarios(Long idUsuario, String email, String nome, String senha, TipoUsuario tipoUsuario) {
        this.idUsuario = idUsuario;
        this.email = email;
        this.nome = nome;
        this.senha = senha;
        this.tipoUsuario = tipoUsuario;
    }
}
