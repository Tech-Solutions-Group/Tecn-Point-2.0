package com.techsolutions.tecnpoint.config;

import com.techsolutions.tecnpoint.entities.Jornada;
import com.techsolutions.tecnpoint.entities.Modulo;
import com.techsolutions.tecnpoint.entities.Usuarios;
import com.techsolutions.tecnpoint.entities.enums.TipoUsuario;
import com.techsolutions.tecnpoint.repositories.JornadaRepository;
import com.techsolutions.tecnpoint.repositories.ModuloRepository;
import com.techsolutions.tecnpoint.repositories.UsuarioRepository;
import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Configuration;
import org.springframework.transaction.annotation.Transactional;

@Configuration
public class DataInitializer implements CommandLineRunner {

    private final JornadaRepository jornadaRepository;
    private final ModuloRepository moduloRepository;
    private final UsuarioRepository usuarioRepository;

    public DataInitializer(JornadaRepository jornadaRepository, ModuloRepository moduloRepository, UsuarioRepository usuarioRepository) {
        this.jornadaRepository = jornadaRepository;
        this.moduloRepository = moduloRepository;
        this.usuarioRepository = usuarioRepository;
    }

    @Override
    @Transactional
    public void run(String... args) {

        if (jornadaRepository.count() == 0) {
            jornadaRepository.save(new Jornada(null, "Financeiro" ));
            jornadaRepository.save(new Jornada(null, "Marketing" ));
            jornadaRepository.save(new Jornada(null, "Recursos Humanos"));
            System.out.println("Jornadas iniciais inseridas.");
        }

        if (moduloRepository.count() == 0) {
            moduloRepository.save(new Modulo(null, "Hardware"));
            moduloRepository.save(new Modulo(null, "Software"));
            moduloRepository.save(new Modulo(null, "Rede"));
            System.out.println("Módulos iniciais inseridos.");
        }

        if (usuarioRepository.count() == 0) {
            usuarioRepository.save(new Usuarios(null,"bot@tecnpoint.com", "TecnPoint","tecn2025pim", TipoUsuario.FUNCIONARIO));
            System.out.println("Usuariao padrão cadastrado com sucesso.");
        }
    }
}
