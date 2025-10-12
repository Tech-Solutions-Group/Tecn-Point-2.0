package com.techsolutions.tecnpoint.repositories;

import com.techsolutions.tecnpoint.entities.Chamados;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ChamadoRepository extends JpaRepository<Chamados, Long> {
}
