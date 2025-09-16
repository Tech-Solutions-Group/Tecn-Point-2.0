package com.techsolutions.tecnpoint.repositories;


import com.techsolutions.tecnpoint.entities.Usuarios;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface UsuarioRepository extends JpaRepository<Usuarios, Long>{
}
