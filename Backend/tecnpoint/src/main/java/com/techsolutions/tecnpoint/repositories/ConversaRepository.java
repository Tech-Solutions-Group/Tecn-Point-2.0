package com.techsolutions.tecnpoint.repositories;

import com.techsolutions.tecnpoint.entities.Conversa;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface ConversaRepository extends JpaRepository<Conversa, Long> {

    public List<Conversa> findByChamadoIdChamadoAndIdConversaGreaterThanOrderByDataHoraEnvioAsc(Long idChamado, Long idUltimaConversa);
}