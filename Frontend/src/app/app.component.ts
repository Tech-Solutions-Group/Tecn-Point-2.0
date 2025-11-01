import { Component, OnInit } from '@angular/core';
import { RouterOutlet, Router } from '@angular/router';
import { Usuario, UsuarioService } from '../app/service/usuario.service';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, ReactiveFormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  usuarios?: Usuario;
  title = 'Frontend';

  constructor(
    readonly usuarioService: UsuarioService,
    readonly router: Router
  ) {}

  ngOnInit(): void {
    this.loadUsuario();
  }

  loadUsuario(id: number = 3): void {
    this.usuarioService.getUsuarioById(id).subscribe({
      next: (data) => {
        this.usuarios = data;
        this.usuarioService.usuarioLogado = data;
      },
      error: (err) => console.error('Erros ao carregar usuario', err),
    });
  }

  cadChamado() {
    this.router.navigate(['/abrir-chamado']);
  }

  listChamado() {
    this.router.navigate(['/chamado']);
  }

  listUsuarios() {
    this.router.navigate(['/usuario']);
  }
}
