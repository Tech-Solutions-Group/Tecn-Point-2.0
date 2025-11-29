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
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.transaction.annotation.Transactional;

@Configuration
public class DataInitializer implements CommandLineRunner {

    private final JornadaRepository jornadaRepository;
    private final ModuloRepository moduloRepository;
    private final UsuarioRepository usuarioRepository;
    private final PasswordEncoder passwordEncoder;


    public DataInitializer(JornadaRepository jornadaRepository, ModuloRepository moduloRepository, UsuarioRepository usuarioRepository, PasswordEncoder passwordEncoder) {
        this.jornadaRepository = jornadaRepository;
        this.moduloRepository = moduloRepository;
        this.usuarioRepository = usuarioRepository;
        this.passwordEncoder = passwordEncoder;
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
            String senhaCriptografada = passwordEncoder.encode("tecn2025pim");
            usuarioRepository.save(
                    new Usuarios(null, "TecnPoint", "bot@tecnpoint.com", senhaCriptografada, TipoUsuario.FUNCIONARIO)
            );
            System.out.println("Usuário padrão cadastrado com sucesso.");
        }
    }
}
