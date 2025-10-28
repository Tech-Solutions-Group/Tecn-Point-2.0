package com.techsolutions.tecnpoint.services;

import com.techsolutions.tecnpoint.DTO.FuncionarioDTO;
import com.techsolutions.tecnpoint.DTO.LoginUsuarioDTO;
import com.techsolutions.tecnpoint.entities.Usuarios;
import com.techsolutions.tecnpoint.enums.TipoUsuario;
import com.techsolutions.tecnpoint.exceptions.EmailExistenteException;
import com.techsolutions.tecnpoint.exceptions.UsuarioNaoEncontradoException;
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

    public Usuarios efetuarLogin(LoginUsuarioDTO loginUsuarioDTO){
        if(loginUsuarioDTO.getEmail().trim().isEmpty()){
            throw new RuntimeException("O e-mail deve ser informado");
        }

        if(loginUsuarioDTO.getSenha().trim().isEmpty()){
            throw new RuntimeException("A senha deve ser informada");
        }

        Usuarios usuarioEncontrado = usuarioRepository.findByEmailAndSenha(loginUsuarioDTO.getEmail(), loginUsuarioDTO.getSenha())
                .orElseThrow(() -> new RuntimeException("Login inválido"));
        return usuarioEncontrado;
    }

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

        Usuarios usuarioEncontrado = getUsuarioById(id).orElseThrow(() -> new UsuarioNaoEncontradoException("O usuário não foi encontrado."));

        if(atualizaUsuarioDTO.getNome() != null && !atualizaUsuarioDTO.getNome().trim().isEmpty()){
            usuarioEncontrado.setNome(atualizaUsuarioDTO.getNome());
        }

        if(atualizaUsuarioDTO.getSenha() != null && !atualizaUsuarioDTO.getSenha().trim().isEmpty()){
            usuarioEncontrado.setSenha(atualizaUsuarioDTO.getSenha());
        }

        if(atualizaUsuarioDTO.getEmail() != null && !atualizaUsuarioDTO.getEmail().trim().isEmpty()){

            if(!usuarioEncontrado.getEmail().equals(atualizaUsuarioDTO.getEmail())){

                if(usuarioRepository.existsByEmail(atualizaUsuarioDTO.getEmail())){
                    throw new EmailExistenteException("O e-mail informado já existe!");
                }
            }
            usuarioEncontrado.setEmail(atualizaUsuarioDTO.getEmail());
        }

        return usuarioRepository.save(usuarioEncontrado);
    }

    public List<FuncionarioDTO> listarFuncionarios(){
        return buildFuncionarioListagemDTO(usuarioRepository.findByTipoUsuario(TipoUsuario.FUNCIONARIO));
    }

    private List<FuncionarioDTO> buildFuncionarioListagemDTO(List<Usuarios> listaFuncionarios){
        List<FuncionarioDTO> listaFuncionariosDTO = new ArrayList<>();
        for(Usuarios funcionario : listaFuncionarios){
            listaFuncionariosDTO.add(FuncionarioDTO.builder()
                                    .id(funcionario.getId_usuario())
                                    .nome(funcionario.getNome())
                                    .build());
        }
        return listaFuncionariosDTO;
    }
}
