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
import com.techsolutions.tecnpoint.repositories.UsuarioRepository;
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
    private UsuarioRepository usuarioRepository;

    // Adicionar verificação dos tipos dos usuários
    public VisualizacaoChamadoDTO postChamado(AberturaChamadoDTO aberturaChamadoDTO){

        Jornada jornada = jornadaRepository.findById(aberturaChamadoDTO.getIdJornada())
                .orElseThrow(() -> new RuntimeException("Jornada informada não encontrada"));

        Modulo modulo = moduloRepository.findById(aberturaChamadoDTO.getIdModulo())
                .orElseThrow(() -> new RuntimeException("Módulo informado não encontrado"));

        Usuarios cliente = usuarioRepository.findById(aberturaChamadoDTO.getIdCliente())
                .orElseThrow(() -> new RuntimeException("O cliente não foi encontrado"));

        if(isFuncionario(cliente)) {throw new RuntimeException("O cliente informado deve ser do tipo cliente");}

        Usuarios funcionario = usuarioRepository.findById(1L)
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

        // Salvando o chamado no banco
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

        Usuarios cliente = usuarioRepository.findById(id_cliente)
                .orElseThrow(() -> new RuntimeException("O cliente não foi encontrado."));

        List<VisualizacaoChamadoDTO> chamadosVisualizacao = new ArrayList<>();
        for(Chamados c : cliente.getChamadosCliente()){
            chamadosVisualizacao.add(buildVisualizacaoChamadoDTO(c));
        }

        return chamadosVisualizacao;
    }

    public List<VisualizacaoChamadoDTO> getChamadosFuncionario(Long id_funcionario){
        Usuarios funcionario = usuarioRepository.findById(id_funcionario)
                .orElseThrow(() -> new RuntimeException("O funcionário não foi encontrado."));

        List<VisualizacaoChamadoDTO> chamadosVisualizacao = new ArrayList<>();
        for(Chamados c : funcionario.getChamadosFuncionario()){
            chamadosVisualizacao.add(buildVisualizacaoChamadoDTO(c));
        }

        return chamadosVisualizacao;
    }

    public VisualizacaoChamadoDTO updateChamado(AtualizaChamadoDTO chamadoDTO){
        Chamados chamadoAtualizado = chamadoRepository.save(atualizaChamado(chamadoDTO));
        return buildVisualizacaoChamadoDTO(chamadoAtualizado);
    }

    private Chamados atualizaChamado(AtualizaChamadoDTO chamadoDTO){
        Chamados chamado = chamadoRepository.findById(chamadoDTO.getId_chamado())
                .orElseThrow(() -> new RuntimeException("O chamado não foi encontrado."));

        if(!(chamado.getPrioridade() == chamadoDTO.getPrioridade())){
            chamado.setPrioridade(chamadoDTO.getPrioridade());
        }

        if(!(chamado.getStatus() == chamadoDTO.getStatus())){
            chamado.setStatus(chamadoDTO.getStatus());
        }

        if(!(chamado.getFuncionario().getId_usuario() == chamadoDTO.getId_usuario())){
            // Verificar situação do retorno do optional do método getById, usar o findById ou o getById da classe repository do usuário
            Usuarios funcionarioAtribuido = usuarioRepository.findById(chamadoDTO.getId_usuario())
                    .orElseThrow(() -> new RuntimeException("O funcionário informado não existe"));

            if(funcionarioAtribuido.getTipoUsuario() == TipoUsuario.FUNCIONARIO){
                chamado.setFuncionario(funcionarioAtribuido);
            }else{
                throw new RuntimeException("O usuário informado deve ser um funcionário.");
            }
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
                .build();
    }

    private boolean isFuncionario(Usuarios usuario){
        return usuario.getTipoUsuario() == TipoUsuario.FUNCIONARIO;
    }
}
