package com.techsolutions.tecnpoint.services;

import com.techsolutions.tecnpoint.DTO.EnviarMensagemDTO;
import com.techsolutions.tecnpoint.entities.Chamados;
import com.techsolutions.tecnpoint.entities.Conversa;
import com.techsolutions.tecnpoint.entities.Usuarios;
import com.techsolutions.tecnpoint.repositories.ChamadoRepository;
import com.techsolutions.tecnpoint.repositories.ConversaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;

@Service
public class ConversaService {

    @Autowired
    private ConversaRepository conversaRepository;

    @Autowired
    private ChamadoRepository chamadoRepository;

    @Autowired
    private UsuarioService usuarioService;

    public Conversa enviarMensagem(EnviarMensagemDTO mensagemDTO){
        return conversaRepository.save(buildConversa(mensagemDTO));
    }

    private Conversa buildConversa(EnviarMensagemDTO mensagemDTO){
        if(!validaMensagemDTO(mensagemDTO)) { throw new RuntimeException("Os dados da mensagem estão incorretos"); }

        Chamados chamadoConversa = chamadoRepository.findById(mensagemDTO.getIdChamado())
                .orElseThrow(() -> new RuntimeException("O chamado da conversa não foi encontrado"));

        Usuarios remetente = usuarioService.getUsuarioById(mensagemDTO.getIdRemetente())
                .orElseThrow(() -> new RuntimeException("O rementente informado não foi encontrado"));

        boolean podeEnviar = remetente.getId_usuario() == chamadoConversa.getCliente().getId_usuario() ||
                                remetente.getId_usuario() == chamadoConversa.getFuncionario().getId_usuario();

        if(podeEnviar){
            return Conversa.builder()
                    .mensagem(mensagemDTO.getMensagem())
                    .chamado(chamadoConversa)
                    .remetente(remetente)
                    .dataHoraEnvio(LocalDateTime.now())
                    .build();
        }else{
            throw new RuntimeException("Não foi possível enviar a mensagem");
        }
    }

    private boolean validaMensagemDTO(EnviarMensagemDTO mensagemDTO){
        if(mensagemDTO.getIdChamado() == null || mensagemDTO.getIdChamado() == 0){
            return false;
        }

        if(mensagemDTO.getIdRemetente() == null || mensagemDTO.getIdRemetente() == 0){
            return false;
        }

        if(mensagemDTO.getMensagem() == null || mensagemDTO.getMensagem().trim().isEmpty()){
            return false;
        }

        return true;
    }
}
