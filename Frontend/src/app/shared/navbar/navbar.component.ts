import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsuarioLogado, UsuarioService } from '../../service/usuario.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
})
export class NavbarComponent implements OnInit {
  usuarios?: UsuarioLogado | null;

  constructor(
    readonly usuarioService: UsuarioService,
    readonly router: Router
  ) {}

  ngOnInit(): void {
    this.usuarioService.usuario$.subscribe((usuario) => {
      this.usuarios = usuario;
    });
  }

  logoutUsuario() {
    this.usuarioService.logoutUsuarioLogado();
    this.router.navigate(['/auth/login']);
  }

  cadChamado() {
    this.router.navigate(['/app/open-chamado']);
  }

  listChamado() {
    this.router.navigate(['/app/list-chamado']);
  }

  listUsuarios() {
    this.router.navigate(['/app/list-usuario']);
  }
}
