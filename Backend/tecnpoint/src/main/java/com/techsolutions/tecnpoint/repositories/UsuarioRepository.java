package com.techsolutions.tecnpoint.repositories;

import com.techsolutions.tecnpoint.entities.Usuarios;
import com.techsolutions.tecnpoint.enums.TipoUsuario;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import java.util.List;

@Repository
public interface UsuarioRepository extends JpaRepository<Usuarios, Long>{
    public boolean existsByEmail(String email);
    public List<Usuarios> findByTipoUsuario(TipoUsuario tipoUsuario);
}
