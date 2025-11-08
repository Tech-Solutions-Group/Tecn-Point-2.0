import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, Router } from '@angular/router';
import { UsuarioService } from '../service/usuario.service';

@Injectable({
  providedIn: 'root',
})
export class RoleGuard implements CanActivate {
  constructor(private usuarioService: UsuarioService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot): boolean {
    if (typeof window === 'undefined') return false;

    const usuario = this.usuarioService.obterUsuarioLogado();
    if (!usuario) {
      this.router.navigate(['/auth/login']);
      return false;
    }

    const rolesPermitidos = route.data['roles'] as string[];

    if (rolesPermitidos && !rolesPermitidos.includes(usuario.tipoUsuario)) {
      this.router.navigate(['/app/home']);
      return false;
    }

    return true;
  }
}
