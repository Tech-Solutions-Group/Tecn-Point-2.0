import { Component, OnInit } from '@angular/core';
import { Usuario, UsuarioService } from '../../service/usuario.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-usuario',
  standalone: true,
  imports: [],
  templateUrl: './usuario.component.html',
  styleUrl: './usuario.component.css',
})
export class UsuarioComponent implements OnInit {
  usuario: Usuario[] = [];

  constructor(private usuarioService: UsuarioService, private router: Router) {}

  ngOnInit(): void {
    this.loadUsuarios;
  }

  private loadUsuarios(): void {
    this.usuarioService.getUsuario().subscribe((dados) => {
      this.usuario = dados;
    });
  }

  cadastro(): void {
    this.router.navigate(['usuarios/adicionar']);
  }
}
