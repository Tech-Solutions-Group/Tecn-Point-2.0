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

    public Usuarios postUsuarios(Usuarios usuarios){
        Usuarios usuarioSalvo = usuarioRepository.save(usuarios);
        return usuarioSalvo;
    }

    public void delUsuarios(Long id){
        usuarioRepository.deleteById(id);
    }

    public Usuarios editarUsuario(Long id, AtualizaUsuarioDTO atualizaUsuarioDTO){

        Usuarios usuarioEncontrado = getUsuarioById(id).orElseThrow(() -> new RuntimeException("O usuário não foi encontrado."));

        if(atualizaUsuarioDTO.getNome() != null && !atualizaUsuarioDTO.getNome().trim().isEmpty()){
            usuarioEncontrado.setNome(atualizaUsuarioDTO.getNome());
        }

        if(atualizaUsuarioDTO.getSenha() != null && !atualizaUsuarioDTO.getSenha().trim().isEmpty()){
            usuarioEncontrado.setSenha(atualizaUsuarioDTO.getSenha());
        }

        if(atualizaUsuarioDTO.getTipoUsuario() != null && !(atualizaUsuarioDTO.getTipoUsuario() == usuarioEncontrado.getTipoUsuario())){
            if(usuarioEncontrado.getTipoUsuario() == TipoUsuario.FUNCIONARIO && atualizaUsuarioDTO.getTipoUsuario() == TipoUsuario.CLIENTE){
                atribuiChamadosFuncionario(usuarioEncontrado);
            }

            if(usuarioEncontrado.getTipoUsuario() == TipoUsuario.CLIENTE && atualizaUsuarioDTO.getTipoUsuario() == TipoUsuario.FUNCIONARIO){
                if(!usuarioEncontrado.getChamadosCliente().isEmpty()){ // Verificando se o cliente possui chamados abertos
                    throw new RuntimeException("Não é possível alterar o tipo de usuário - O usuário possui chamados em aberto!");
                }
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

        return usuarioRepository.save(usuarioEncontrado);
    }

    /*
        Mét. utilizado para reatribuir os chamados de um funcionário
        que teve seu tipo de usuário alterado para cliente
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
