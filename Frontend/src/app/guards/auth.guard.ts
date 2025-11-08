import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { UsuarioService } from '../service/usuario.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private usuarioService: UsuarioService, private router: Router) {}

  canActivate(): boolean {
    if (typeof window === 'undefined') {
      return false;
    }

    const usuario = this.usuarioService.obterUsuarioLogado();
    if (usuario) {
      return true;
    }

    this.router.navigate(['/not-found']);
    return false;
  }
}
