package com.techsolutions.tecnpoint.services;

import com.techsolutions.tecnpoint.entities.Usuarios;
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
            usuarioEncontrado.setTipoUsuario(atualizaUsuarioDTO.getTipoUsuario());
        }

        // Verifica se o e-mail informado é nulo e se NÃO é vazio
        if(atualizaUsuarioDTO.getEmail() != null && !atualizaUsuarioDTO.getEmail().trim().isEmpty()){
            // Verifica se o e-mail do usuário encontrado é diferente do e-mail informado
            if(!usuarioEncontrado.getEmail().equals(atualizaUsuarioDTO.getEmail())){ // Entra no if se o e-mail informado não for o mesmo do usuário encontrado
                // Verifica se o e-mail já existe no banco
                if(getListaEmailsUsuarios().contains(atualizaUsuarioDTO.getEmail())){
                    throw new RuntimeException("O e-mail informado já existe!");
                }
            }
            usuarioEncontrado.setEmail(atualizaUsuarioDTO.getEmail());
        }
        return usuarioRepository.save(usuarioEncontrado); // Salvando o usuário com os dados enviados no body e o retornando
    }

    private List<String> getListaEmailsUsuarios(){
        if(getUsuarios() != null){
            List<String> listaEmailsUsuarios = new ArrayList<>();
            for(Usuarios usuario : getUsuarios()){ // Foreach que percorre os usuários no banco
                listaEmailsUsuarios.add(usuario.getEmail()); // Pegando o email de todos os usuários
            }
            return listaEmailsUsuarios;
        }else{
            throw new RuntimeException("Não há nenhum usuário cadastrado para editar");
        }
    }
}
