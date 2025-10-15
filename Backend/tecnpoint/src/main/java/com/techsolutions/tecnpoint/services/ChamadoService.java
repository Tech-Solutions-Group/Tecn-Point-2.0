package com.techsolutions.tecnpoint.services;

import com.techsolutions.tecnpoint.DTO.AberturaChamadoDTO;
import com.techsolutions.tecnpoint.DTO.AtualizaChamadoDTO;
import com.techsolutions.tecnpoint.DTO.VisualizacaoUsuarioDTO;
import com.techsolutions.tecnpoint.DTO.VisualizacaoChamadoDTO;
import com.techsolutions.tecnpoint.entities.Chamados;
import com.techsolutions.tecnpoint.entities.Jornada;
import com.techsolutions.tecnpoint.entities.Modulo;
import com.techsolutions.tecnpoint.entities.Usuarios;
import com.techsolutions.tecnpoint.enums.StatusChamado;
import com.techsolutions.tecnpoint.enums.TipoUsuario;
import com.techsolutions.tecnpoint.repositories.ChamadoRepository;
import com.techsolutions.tecnpoint.repositories.JornadaRepository;
import com.techsolutions.tecnpoint.repositories.ModuloRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import java.util.ArrayList;
import java.util.List;

@Service
public class ChamadoService {

    @Autowired
    private ChamadoRepository chamadoRepository;

    @Autowired
    private JornadaRepository jornadaRepository;

    @Autowired
    private ModuloRepository moduloRepository;

    @Autowired
    private UsuarioService usuarioService;

    public VisualizacaoChamadoDTO postChamado(AberturaChamadoDTO aberturaChamadoDTO){

        Jornada jornada = jornadaRepository.findById(aberturaChamadoDTO.getIdJornada())
                .orElseThrow(() -> new RuntimeException("Jornada informada não encontrada"));

        Modulo modulo = moduloRepository.findById(aberturaChamadoDTO.getIdModulo())
                .orElseThrow(() -> new RuntimeException("O módulo informado não foi encontrado"));;

        Usuarios cliente = usuarioService.getUsuarioById(aberturaChamadoDTO.getIdCliente())
                .orElseThrow(() -> new RuntimeException("O cliente informado não foi encontrado"));

        if(isFuncionario(cliente)) {throw new RuntimeException("O cliente informado deve ser do tipo cliente");}

        Usuarios funcionario = usuarioService.getUsuarioById(1L)
                .orElseThrow(() -> new RuntimeException("O funcionário Tech Solutions não foi encontrado"));

        Chamados chamado = Chamados.builder()
                .descricao(aberturaChamadoDTO.getDescricao())
                .titulo(aberturaChamadoDTO.getTitulo())
                .prioridade(aberturaChamadoDTO.getPrioridade())
                .status(StatusChamado.ABERTO)
                .jornada(jornada)
                .modulo(modulo)
                .cliente(cliente)
                .funcionario(funcionario)
                .build();

        chamadoRepository.save(chamado);
        return buildVisualizacaoChamadoDTO(chamado);
    }

    public List<VisualizacaoChamadoDTO> getAllChamados(){
        List<VisualizacaoChamadoDTO> listaChamadosVisualizacao = new ArrayList<>();
        for(Chamados chamado : chamadoRepository.findAll()){
            listaChamadosVisualizacao.add(buildVisualizacaoChamadoDTO(chamado));
        }
        return listaChamadosVisualizacao;
    }

    public VisualizacaoChamadoDTO getChamadoPorId(Long id_chamado){
        Chamados chamado = chamadoRepository.findById(id_chamado)
                .orElseThrow(() -> new RuntimeException("O chamado não foi encontrado."));
        return buildVisualizacaoChamadoDTO(chamado);
    }

    public List<VisualizacaoChamadoDTO> getChamadosCliente(Long id_cliente){

        Usuarios cliente = usuarioService.getUsuarioById(id_cliente)
                .orElseThrow(() -> new RuntimeException("O cliente não foi encontrado."));

        if(!isFuncionario(cliente)){
            List<VisualizacaoChamadoDTO> chamadosVisualizacao = new ArrayList<>();
            for(Chamados c : cliente.getChamadosCliente()){
                chamadosVisualizacao.add(buildVisualizacaoChamadoDTO(c));
            }
            return chamadosVisualizacao;
        }else{
            throw new RuntimeException("O usuário informado deve ser um cliente");
        }
    }

    public List<VisualizacaoChamadoDTO> getChamadosFuncionario(Long id_funcionario){
        Usuarios funcionario = usuarioService.getUsuarioById(id_funcionario)
                .orElseThrow(() -> new RuntimeException("O funcionário não foi encontrado."));

        if(isFuncionario(funcionario)){
            List<VisualizacaoChamadoDTO> chamadosVisualizacao = new ArrayList<>();
            for(Chamados c : funcionario.getChamadosFuncionario()){
                chamadosVisualizacao.add(buildVisualizacaoChamadoDTO(c));
            }
            return chamadosVisualizacao;
        }else{
            throw new RuntimeException("O usuário informado deve ser um funcionário");
        }

    }

    public VisualizacaoChamadoDTO updateChamado(AtualizaChamadoDTO chamadoDTO){
        Chamados chamadoAtualizado = chamadoRepository.save(atualizaChamado(chamadoDTO));
        return buildVisualizacaoChamadoDTO(chamadoAtualizado);
    }

    private Chamados atualizaChamado(AtualizaChamadoDTO chamadoDTO){
        Chamados chamado = chamadoRepository.findById(chamadoDTO.getId_chamado())
                .orElseThrow(() -> new RuntimeException("O chamado não foi encontrado."));

        if(!(chamadoDTO.getPrioridade() == null)){
            if(chamadoDTO.getPrioridade() != chamado.getPrioridade()){ chamado.setPrioridade(chamadoDTO.getPrioridade()); }
        }

        if(!(chamadoDTO.getStatus() == null)){
            if(chamado.getStatus() != chamadoDTO.getStatus()) { chamado.setStatus(chamadoDTO.getStatus()); }
        }

        if(!(chamadoDTO.getId_usuario() == null) &&
          !(chamado.getFuncionario().getId_usuario().equals(chamadoDTO.getId_usuario()))){
            Usuarios funcionarioAtribuido = usuarioService.getUsuarioById(chamadoDTO.getId_usuario())
                    .orElseThrow(() -> new RuntimeException("O funcionário informado não foi encontrado"));;

            if(!isFuncionario(funcionarioAtribuido)){
                throw new RuntimeException("O usuário informado deve ser um funcionário");
            }

            chamado.setFuncionario(funcionarioAtribuido);
        }
        return chamado;
    }

    private VisualizacaoChamadoDTO buildVisualizacaoChamadoDTO(Chamados chamado){

        VisualizacaoUsuarioDTO visualizacaoCliente = VisualizacaoUsuarioDTO.builder()
                .id_usuario(chamado.getCliente().getId_usuario())
                .nome(chamado.getCliente().getNome())
                .tipoUsuario(chamado.getCliente().getTipoUsuario())
                .build();

        VisualizacaoUsuarioDTO visualizacaoFuncionario = VisualizacaoUsuarioDTO.builder()
                .id_usuario(chamado.getFuncionario().getId_usuario())
                .nome(chamado.getFuncionario().getNome())
                .tipoUsuario(chamado.getFuncionario().getTipoUsuario())
                .build();

        return VisualizacaoChamadoDTO.builder()
                .id_chamado(chamado.getId_chamado())
                .descricao(chamado.getDescricao())
                .titulo(chamado.getTitulo())
                .prioridade(chamado.getPrioridade())
                .status(chamado.getStatus())
                .cliente(visualizacaoCliente)
                .funcionario(visualizacaoFuncionario)
                .jornada(chamado.getJornada())
                .modulo(chamado.getModulo())
                .build();
    }

    private boolean isFuncionario(Usuarios usuario){
        return usuario.getTipoUsuario() == TipoUsuario.FUNCIONARIO;
    }
}
