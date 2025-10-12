package com.techsolutions.tecnpoint.services;

import com.techsolutions.tecnpoint.entities.Chamados;
import com.techsolutions.tecnpoint.entities.Usuarios;
import com.techsolutions.tecnpoint.enums.TipoUsuario;
import com.techsolutions.tecnpoint.repositories.UsuarioRepository;
import com.techsolutions.tecnpoint.DTO.AtualizaUsuarioDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
public class UsuarioService {

    @Autowired
    private UsuarioRepository usuarioRepository;

    public List<Usuarios> getUsuarios(){
        return usuarioRepository.findAll();
    }

    public Optional<Usuarios> getUsuarioById(Long id){
        return usuarioRepository.findById(id);
    }

    // Adicionar verificação de existência do usuário
    public Usuarios postUsuarios(Usuarios usuarios){
        Usuarios usuarioSalvo = usuarioRepository.save(usuarios);
        return usuarioSalvo;
    }

    public void delUsuarios(Long id){
        usuarioRepository.deleteById(id);
    }

    public Usuarios editarUsuario(Long id, AtualizaUsuarioDTO atualizaUsuarioDTO){
        /*
        Utilizando expressão lambda por causa do Optional, caso o usuário não exista no banco
         lança uma exceção
         */
        Usuarios usuarioEncontrado = getUsuarioById(id).orElseThrow(() -> new RuntimeException("O usuário não foi encontrado."));

        if(atualizaUsuarioDTO.getNome() != null && !atualizaUsuarioDTO.getNome().trim().isEmpty()){
            usuarioEncontrado.setNome(atualizaUsuarioDTO.getNome());
        }

        if(atualizaUsuarioDTO.getSenha() != null && !atualizaUsuarioDTO.getSenha().trim().isEmpty()){
            usuarioEncontrado.setSenha(atualizaUsuarioDTO.getSenha());
        }

        if(atualizaUsuarioDTO.getTipoUsuario() != null){
            if(usuarioEncontrado.getTipoUsuario() == TipoUsuario.FUNCIONARIO && atualizaUsuarioDTO.getTipoUsuario() == TipoUsuario.CLIENTE){
                atribuiChamadosFuncionario(usuarioEncontrado);
            }
            usuarioEncontrado.setTipoUsuario(atualizaUsuarioDTO.getTipoUsuario());
        }

        // Verifica se o e-mail informado é nulo e se NÃO é vazio
        if(atualizaUsuarioDTO.getEmail() != null && !atualizaUsuarioDTO.getEmail().trim().isEmpty()){
            // Verifica se o e-mail do usuário encontrado é diferente do e-mail informado
            if(!usuarioEncontrado.getEmail().equals(atualizaUsuarioDTO.getEmail())){ // Entra no if se o e-mail informado não for o mesmo do usuário encontrado
                // Verifica se o e-mail já existe no banco
                if(usuarioRepository.existsByEmail(atualizaUsuarioDTO.getEmail())){
                    throw new RuntimeException("O e-mail informado já existe!");
                }
            }
            usuarioEncontrado.setEmail(atualizaUsuarioDTO.getEmail());
        }

        return usuarioRepository.save(usuarioEncontrado); // Salvando o usuário com os dados enviados no body e o retornando
    }

    /*
        função utilizada para quando o usuário era um funcionário e agora passou a ser uma cliente
        então tiramos todos os chamados que para ele havia sido atribuido
     */
    private void atribuiChamadosFuncionario(Usuarios funcionario){

        // Recuperando todos os chamados atribuidos para o usuário que passará a ser CLIENTE
        List<Chamados> chamadosAtribuidos = funcionario.getChamadosFuncionario();

        if(!chamadosAtribuidos.isEmpty()){

            // Recuperando o usuário padrão TechSolution
            Usuarios funcionarioPadrao = getUsuarioById(1L).orElseThrow(() -> new RuntimeException("O usuário Tech Solutions não foi encontrado"));

            // Atribuindo os chamados do ex-funcionário para o TechSolution
            for(Chamados chamado : chamadosAtribuidos){
                chamado.setFuncionario(funcionarioPadrao);
            }

        }
    }
}
