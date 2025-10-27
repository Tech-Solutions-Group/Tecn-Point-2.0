package com.techsolutions.tecnpoint.services;

import com.techsolutions.tecnpoint.DTO.BuscarMensagensDTO;
import com.techsolutions.tecnpoint.DTO.EnviarMensagemDTO;
import com.techsolutions.tecnpoint.DTO.VisualizacaoConversaDTO;
import com.techsolutions.tecnpoint.DTO.VisualizacaoUsuarioDTO;
import com.techsolutions.tecnpoint.entities.Chamados;
import com.techsolutions.tecnpoint.entities.Conversa;
import com.techsolutions.tecnpoint.entities.Usuarios;
import com.techsolutions.tecnpoint.repositories.ChamadoRepository;
import com.techsolutions.tecnpoint.repositories.ConversaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

@Service
public class ConversaService {

    @Autowired
    private ConversaRepository conversaRepository;

    @Autowired
    private ChamadoRepository chamadoRepository;

    @Autowired
    private UsuarioService usuarioService;

    public VisualizacaoConversaDTO enviarMensagem(EnviarMensagemDTO mensagemDTO){
        Conversa conversa = buildConversa(mensagemDTO);
        return buildVisualizacaoConversaDTO(conversaRepository.save(conversa));
    }

    public List<VisualizacaoConversaDTO> buscarMensagens(BuscarMensagensDTO buscarMensagensDTO){
        return buildListaVisualizacaoConversaDTO(conversaRepository.findByChamadoIdChamadoAndIdConversaGreaterThanOrderByDataHoraEnvioAsc(buscarMensagensDTO.getIdChamado(), buscarMensagensDTO.getIdUltimaConversa()));
    }

    private Conversa buildConversa(EnviarMensagemDTO mensagemDTO){
        validaMensagemDTO(mensagemDTO);

        Chamados chamadoConversa = buscaChamado(mensagemDTO.getIdChamado());
        Usuarios remetente = buscaRemetente(mensagemDTO.getIdRemetente());

        validaPermissaoEnvio(chamadoConversa, remetente);

        return Conversa.builder()
                .mensagem(mensagemDTO.getMensagem())
                .chamado(chamadoConversa)
                .remetente(remetente)
                .build();
    }

    private Chamados buscaChamado(Long idChamado){
        Chamados chamado = chamadoRepository.findById(idChamado)
                .orElseThrow(() -> new RuntimeException("O chamado da conversa não foi encontrado"));
        return chamado;
    }

    private Usuarios buscaRemetente(Long idRemetente){
        Usuarios usuario = usuarioService.getUsuarioById(idRemetente)
                .orElseThrow(() -> new RuntimeException("O rementente informado não foi encontrado"));
        return usuario;
    }

    private void validaMensagemDTO(EnviarMensagemDTO mensagemDTO){
        if(mensagemDTO.getIdChamado() == null || mensagemDTO.getIdChamado() == 0){
            throw new RuntimeException("O id do chamado foi informado incorretamente");
        }

        if(mensagemDTO.getIdRemetente() == null || mensagemDTO.getIdRemetente() == 0){
            throw new RuntimeException("O id do remetente foi informado incorretamente");
        }

        if(mensagemDTO.getMensagem() == null || mensagemDTO.getMensagem().trim().isEmpty()){
            throw new RuntimeException("Uma mensagem deve existir");
        }
    }

    private void validaPermissaoEnvio(Chamados chamado, Usuarios remetente){
        boolean clientePertenceAoChamado = remetente.getId_usuario().equals(chamado.getCliente().getId_usuario());
        boolean funcionarioPertenceAoChamado = remetente.getId_usuario().equals(chamado.getFuncionario().getId_usuario());

        if(!clientePertenceAoChamado && !funcionarioPertenceAoChamado ){
            throw new RuntimeException("O usuário não tem permissão para enviar mensagens nesse chamado");
        }
    }

    private VisualizacaoConversaDTO buildVisualizacaoConversaDTO(Conversa conversa){
        return VisualizacaoConversaDTO.builder()
                .idConversa(conversa.getIdConversa())
                .remetente(VisualizacaoUsuarioDTO.builder()
                        .id_usuario(conversa.getRemetente().getId_usuario())
                        .nome(conversa.getRemetente().getNome())
                        .tipoUsuario(conversa.getRemetente().getTipoUsuario())
                        .build())
                .mensagem(conversa.getMensagem())
                .dataHoraEnvio(conversa.getDataHoraEnvio())
                .build();
    }

    private List<VisualizacaoConversaDTO> buildListaVisualizacaoConversaDTO(List<Conversa> conversas){
        List<VisualizacaoConversaDTO> listaConversas = new ArrayList<>();
        for(Conversa conversa : conversas){
            listaConversas.add(buildVisualizacaoConversaDTO(conversa));
        }
        return listaConversas;
    }
}
