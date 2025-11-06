package com.techsolutions.tecnpoint.services;

import com.techsolutions.tecnpoint.DTO.FuncionarioDTO;
import com.techsolutions.tecnpoint.DTO.LoginUsuarioDTO;
import com.techsolutions.tecnpoint.entities.Usuarios;
import com.techsolutions.tecnpoint.enums.TipoUsuario;
import com.techsolutions.tecnpoint.exceptions.DadosLoginInvalidosException;
import com.techsolutions.tecnpoint.exceptions.EmailExistenteException;
import com.techsolutions.tecnpoint.exceptions.LoginInvalidoException;
import com.techsolutions.tecnpoint.exceptions.UsuarioNaoEncontradoException;
import com.techsolutions.tecnpoint.repositories.UsuarioRepository;
import com.techsolutions.tecnpoint.DTO.AtualizaUsuarioDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.dao.DataIntegrityViolationException;
import org.springframework.stereotype.Service;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import org.springframework.data.domain.Sort;

@Service
public class UsuarioService {

    @Autowired
    private UsuarioRepository usuarioRepository;

    public Usuarios efetuarLogin(LoginUsuarioDTO loginUsuarioDTO){
        if(loginUsuarioDTO.getEmail() == null || loginUsuarioDTO.getEmail().trim().isEmpty()){
            throw new DadosLoginInvalidosException("O e-mail deve ser informado");
        }

        if(loginUsuarioDTO.getSenha() == null || loginUsuarioDTO.getSenha().trim().isEmpty()){
            throw new DadosLoginInvalidosException("A senha deve ser informada");
        }

        Usuarios usuarioEncontrado = usuarioRepository.findByEmailAndSenha(loginUsuarioDTO.getEmail(), loginUsuarioDTO.getSenha())
                .orElseThrow(() -> new LoginInvalidoException("Login inválido"));
        return usuarioEncontrado;
    }

    public List<Usuarios> getUsuarios(){
        return usuarioRepository.findAll(Sort.by(Sort.Direction.ASC, "idUsuario"));
    }

    public Optional<Usuarios> getUsuarioById(Long id){
        return usuarioRepository.findById(id);
    }

    public Usuarios postUsuarios(Usuarios usuarios){
        try{
            Usuarios usuarioSalvo = usuarioRepository.save(usuarios);
            return usuarioSalvo;
        }catch(DataIntegrityViolationException ex){
            throw new EmailExistenteException("O e-mail informado para cadastro já existe");
        }
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
                                    .idUsuario(funcionario.getIdUsuario())
                                    .nome(funcionario.getNome())
                                    .build());
        }
        return listaFuncionariosDTO;
    }
}
