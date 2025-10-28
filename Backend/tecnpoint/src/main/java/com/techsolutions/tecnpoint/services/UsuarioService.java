package com.techsolutions.tecnpoint.services;

import com.techsolutions.tecnpoint.DTO.FuncionarioListagemDTO;
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

        // Verifica se o e-mail informado é nulo e se NÃO é vazio
        if(atualizaUsuarioDTO.getEmail() != null && !atualizaUsuarioDTO.getEmail().trim().isEmpty()){
            // Verifica se o e-mail do usuário encontrado é diferente do e-mail informado
            if(!usuarioEncontrado.getEmail().equals(atualizaUsuarioDTO.getEmail())){ // Entra no if se o e-mail informado não for o mesmo do usuário encontrado
                // Verifica se o e-mail já existe no banco
                if(usuarioRepository.existsByEmail(atualizaUsuarioDTO.getEmail())){
                    throw new EmailExistenteException("O e-mail informado já existe!");
                }
            }
            usuarioEncontrado.setEmail(atualizaUsuarioDTO.getEmail());
        }

        return usuarioRepository.save(usuarioEncontrado);
    }

    public List<FuncionarioListagemDTO> listarFuncionarios(){
        return buildFuncionarioListagemDTO(usuarioRepository.findByTipoUsuario(TipoUsuario.FUNCIONARIO));
    }

    private List<FuncionarioListagemDTO> buildFuncionarioListagemDTO(List<Usuarios> listaFuncionarios){
        List<FuncionarioListagemDTO> listaFuncionariosDTO = new ArrayList<>();
        for(Usuarios funcionario : listaFuncionarios){
            listaFuncionariosDTO.add(FuncionarioListagemDTO.builder()
                                    .id(funcionario.getId_usuario())
                                    .nome(funcionario.getNome())
                                    .build());
        }
        return listaFuncionariosDTO;
    }
}
