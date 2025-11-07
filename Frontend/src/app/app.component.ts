import { Component, OnInit } from '@angular/core';
import { RouterOutlet, Router, NavigationEnd } from '@angular/router';
import { Usuario, UsuarioService } from '../app/service/usuario.service';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { filter } from 'rxjs/operators';

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
  showNavbar: boolean = true;

  constructor(
    readonly usuarioService: UsuarioService,
    readonly router: Router
  ) {
    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe((event: any) => {
        this.showNavbar = !event.url.includes('/login');
      });
  }

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
    this.router.navigate(['/open-chamado']);
  }

  listChamado() {
    this.router.navigate(['/list-chamado']);
  }

  listUsuarios() {
    this.router.navigate(['/list-usuario']);
  }
}
