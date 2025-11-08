package com.techsolutions.tecnpoint.repositories;

import com.techsolutions.tecnpoint.entities.Usuarios;
import com.techsolutions.tecnpoint.entities.enums.TipoUsuario;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import java.util.List;
import java.util.Optional;

@Repository
public interface UsuarioRepository extends JpaRepository<Usuarios, Long>{
    public boolean existsByEmail(String email);
    public List<Usuarios> findByTipoUsuario(TipoUsuario tipoUsuario);
    public Optional<Usuarios> findByEmailAndSenha(String email, String senha);
}
