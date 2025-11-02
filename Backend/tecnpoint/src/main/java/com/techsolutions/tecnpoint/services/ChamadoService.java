package com.techsolutions.tecnpoint.services;

import com.techsolutions.tecnpoint.DTO.*;
import com.techsolutions.tecnpoint.entities.*;
import com.techsolutions.tecnpoint.enums.*;
import com.techsolutions.tecnpoint.exceptions.*;
import com.techsolutions.tecnpoint.repositories.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Sort;
import org.springframework.stereotype.Service;
import java.util.*;

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

    /* ========== CRIAÇÃO ========== */
    public ChamadoDTO postChamado(AberturaChamadoDTO aberturaChamadoDTO) {
        Chamados chamado = buildChamado(aberturaChamadoDTO);
        return buildChamadoDTO(chamadoRepository.save(chamado));
    }

    /* ========== LEITURAS ========== */
    public List<ChamadoDTO> getAllChamados() {
        return chamadoRepository.findAll(Sort.by(Sort.Direction.ASC, "idChamado"))                .stream()
                .map(this::buildChamadoDTO)
                .toList();
    }

    public ChamadoDTO getChamadoPorId(Long idChamado) {
        Chamados chamado = chamadoRepository.findById(idChamado)
                .orElseThrow(() -> new ChamadoNaoEncontradoException("O chamado não foi encontrado."));
        return buildChamadoDTO(chamado);
    }

    public List<ChamadoDTO> getChamadosCliente(Long id_cliente) {
        Usuarios cliente = usuarioService.getUsuarioById(id_cliente)
                .orElseThrow(() -> new UsuarioNaoEncontradoException("O cliente não foi encontrado."));

        if (isFuncionario(cliente))
            throw new TipoUsuarioInvalidoException("O usuário informado deve ser um cliente");

        return cliente.getChamadosCliente().stream()
                .map(this::buildChamadoDTO)
                .toList();
    }

    public List<ChamadoDTO> getChamadosFuncionario(Long id_funcionario) {
        Usuarios funcionario = usuarioService.getUsuarioById(id_funcionario)
                .orElseThrow(() -> new UsuarioNaoEncontradoException("O funcionário não foi encontrado."));

        if (!isFuncionario(funcionario))
            throw new TipoUsuarioInvalidoException("O usuário informado deve ser um funcionário");

        return funcionario.getChamadosFuncionario().stream()
                .map(this::buildChamadoDTO)
                .toList();
    }

    /* ========== ATUALIZAÇÃO ========== */
    public ChamadoDTO updateChamado(Long idChamado, AtualizaChamadoDTO dto) {
        Chamados chamado = chamadoRepository.findById(idChamado)
                .orElseThrow(() -> new ChamadoNaoEncontradoException("O chamado não foi encontrado."));

        // Atualiza prioridade
        if (dto.getPrioridade() != null && !dto.getPrioridade().equals(chamado.getPrioridade())) {
            chamado.setPrioridade(dto.getPrioridade());
        }

        // Atualiza status
        if (dto.getStatus() != null && !dto.getStatus().equals(chamado.getStatus())) {
            chamado.setStatus(dto.getStatus());
        }

        // Atualiza funcionário responsável
        if (dto.getIdUsuario() != null &&
                (chamado.getFuncionario() == null ||
                        !chamado.getFuncionario().getIdUsuario().equals(dto.getIdUsuario()))) {

            Usuarios novoFuncionario = usuarioService.getUsuarioById(dto.getIdUsuario())
                    .orElseThrow(() -> new UsuarioNaoEncontradoException("O funcionário não foi encontrado."));

            if (!isFuncionario(novoFuncionario))
                throw new TipoUsuarioInvalidoException("O usuário informado deve ser um funcionário");

            chamado.setFuncionario(novoFuncionario);
        }

        // Atualiza jornada
        if (dto.getIdJornada() != null &&
                (chamado.getJornada() == null || !chamado.getJornada().getId_jornada().equals(dto.getIdJornada()))) {

            Jornada novaJornada = jornadaRepository.findById(dto.getIdJornada())
                    .orElseThrow(() -> new JornadaNaoEncontradaException("A jornada informada não foi encontrada"));
            chamado.setJornada(novaJornada);
        }

        // Atualiza módulo
        if (dto.getIdModulo() != null &&
                (chamado.getModulo() == null || !chamado.getModulo().getId_modulo().equals(dto.getIdModulo()))) {

            Modulo novoModulo = moduloRepository.findById(dto.getIdModulo())
                    .orElseThrow(() -> new ModuloNaoEncontradoException("O módulo informado não foi encontrado"));
            chamado.setModulo(novoModulo);
        }

        Chamados atualizado = chamadoRepository.save(chamado);
        return buildChamadoDTO(atualizado);
    }

    /* ========== VALIDAÇÕES E HELPERS ========== */
    private void validaAberturaChamado(AberturaChamadoDTO dto) {
        if (dto.getTitulo() == null || dto.getTitulo().trim().isEmpty())
            throw new DadosChamadoInvalidosException("O título do chamado deve ser informado");

        if (dto.getDescricao() == null || dto.getDescricao().trim().isEmpty())
            throw new DadosChamadoInvalidosException("A descrição do chamado deve ser informada");

        if (dto.getPrioridade() == null)
            throw new DadosChamadoInvalidosException("A prioridade deve ser informada");

        if (dto.getIdCliente() == null || dto.getIdCliente() == 0)
            throw new DadosChamadoInvalidosException("O cliente deve ser informado");

        if (dto.getIdJornada() == null || dto.getIdJornada() == 0)
            throw new DadosChamadoInvalidosException("A jornada deve ser informada");

        if (dto.getIdModulo() == null || dto.getIdModulo() == 0)
            throw new DadosChamadoInvalidosException("O módulo deve ser informado");
    }

    private Chamados buildChamado(AberturaChamadoDTO dto) {
        validaAberturaChamado(dto);

        Jornada jornada = jornadaRepository.findById(dto.getIdJornada())
                .orElseThrow(() -> new JornadaNaoEncontradaException("Jornada informada não encontrada"));

        Modulo modulo = moduloRepository.findById(dto.getIdModulo())
                .orElseThrow(() -> new ModuloNaoEncontradoException("O módulo informado não foi encontrado"));

        Usuarios cliente = usuarioService.getUsuarioById(dto.getIdCliente())
                .orElseThrow(() -> new UsuarioNaoEncontradoException("O cliente não foi encontrado."));

        if (isFuncionario(cliente))
            throw new TipoUsuarioInvalidoException("O cliente informado deve ser do tipo CLIENTE");

        Usuarios funcionarioPadrao = usuarioService.getUsuarioById(1L)
                .orElseThrow(
                        () -> new UsuarioNaoEncontradoException("O funcionário Tech Solutions não foi encontrado"));

        return Chamados.builder()
                .titulo(dto.getTitulo())
                .descricao(dto.getDescricao())
                .prioridade(dto.getPrioridade())
                .status(StatusChamado.ABERTO)
                .jornada(jornada)
                .modulo(modulo)
                .cliente(cliente)
                .funcionario(funcionarioPadrao)
                .build();
    }

    private ChamadoDTO buildChamadoDTO(Chamados chamado) {
        UsuarioDTO cliente = UsuarioDTO.builder()
                .idUsuario(chamado.getCliente().getIdUsuario())
                .nome(chamado.getCliente().getNome())
                .tipoUsuario(chamado.getCliente().getTipoUsuario())
                .build();

        UsuarioDTO funcionario = UsuarioDTO.builder()
                .idUsuario(chamado.getFuncionario().getIdUsuario())
                .nome(chamado.getFuncionario().getNome())
                .tipoUsuario(chamado.getFuncionario().getTipoUsuario())
                .build();

        return ChamadoDTO.builder()
                .idChamado(chamado.getIdChamado())
                .titulo(chamado.getTitulo())
                .descricao(chamado.getDescricao())
                .prioridade(chamado.getPrioridade())
                .status(chamado.getStatus())
                .cliente(cliente)
                .funcionario(funcionario)
                .jornada(chamado.getJornada())
                .modulo(chamado.getModulo())
                .build();
    }

    private boolean isFuncionario(Usuarios usuario) {
        return usuario.getTipoUsuario() == TipoUsuario.FUNCIONARIO;
    }
}
