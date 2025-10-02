package com.techsolutions.tecnpoint.services;

import com.techsolutions.tecnpoint.DTO.AberturaChamadoDTO;
import com.techsolutions.tecnpoint.entities.Chamados;
import com.techsolutions.tecnpoint.entities.Jornada;
import com.techsolutions.tecnpoint.entities.Modulo;
import com.techsolutions.tecnpoint.entities.Usuarios;
import com.techsolutions.tecnpoint.repositories.ChamadoRepository;
import com.techsolutions.tecnpoint.repositories.JornadaRepository;
import com.techsolutions.tecnpoint.repositories.ModuloRepository;
import com.techsolutions.tecnpoint.repositories.UsuarioRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

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

    public Chamados postChamado(AberturaChamadoDTO aberturaChamadoDTO){

        Jornada jornada = jornadaRepository.findById(aberturaChamadoDTO.getIdJornada())
                .orElseThrow(() -> new RuntimeException("Jornada informada não encontrada"));

        Modulo modulo = moduloRepository.findById(aberturaChamadoDTO.getIdModulo())
                .orElseThrow(() -> new RuntimeException("Módulo informado não encontrado"));

        Usuarios cliente = usuarioRepository.findById(aberturaChamadoDTO.getIdCliente())
                .orElseThrow(() -> new RuntimeException("O cliente não foi encontrado"));

        Usuarios funcionario = usuarioRepository.findById(aberturaChamadoDTO.getIdFuncionario())
                .orElseThrow(() -> new RuntimeException("O funcionário não foi encontrado"));

        Chamados chamado = Chamados.builder()
                .descricao(aberturaChamadoDTO.getDescricao())
                .titulo(aberturaChamadoDTO.getTitulo())
                .prioridade(aberturaChamadoDTO.getPrioridade())
                .status(aberturaChamadoDTO.getStatus())
                .jornada(jornada)
                .modulo(modulo)
                .cliente(cliente)
                .funcionario(funcionario)
                .build();

        return chamadoRepository.save(chamado);
    }

}
