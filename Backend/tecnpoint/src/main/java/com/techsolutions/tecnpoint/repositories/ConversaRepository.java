package com.techsolutions.tecnpoint.repositories;

import com.techsolutions.tecnpoint.entities.Conversa;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ConversaRepository extends JpaRepository<Conversa, Long> {
}