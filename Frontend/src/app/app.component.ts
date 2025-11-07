import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { UsuarioService, UsuarioLogado } from './service/usuario.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, ReactiveFormsModule, NavbarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  showNavbar = false;
  usuario?: UsuarioLogado | null;

  constructor(private usuarioService: UsuarioService, private router: Router) {}

  ngOnInit() {
    if (typeof window !== 'undefined') {
      (this.usuarioService as any).loadFromStorage?.();
      if (!(this.usuarioService as any).loadFromStorage) {
        const saved = this.usuarioService.obterUsuarioLogado();
        (this.usuarioService as any).setUsuarioLogado?.(saved ?? null);
      }
    }

    this.usuarioService.usuario$.subscribe((u) => {
      this.usuario = u;
    });

    this.router.events
      .pipe(filter((e): e is NavigationEnd => e instanceof NavigationEnd))
      .subscribe((event) => {
        const cleanUrl = event.urlAfterRedirects.split('?')[0].split(';')[0];
        this.showNavbar = cleanUrl.startsWith('/app');
      });
  }
}
