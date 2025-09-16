import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: 'usuarios', pathMatch: 'full' },
  {
    path: 'usuarios',
    loadChildren: () =>
      import('./pages/usuario/usuario.routing.module').then(
        (m) => m.UsuarioRoutingModule
      ),
  },
];
