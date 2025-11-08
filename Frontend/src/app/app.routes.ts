import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { UsuarioComponent } from './pages/usuario/usuario.component';
import { ListarChamadoComponent } from './pages/listar-chamado/listar-chamado.component';
import { AbrirChamadoComponent } from './pages/abrir-chamado/abrir-chamado.component';
import { ChamadoComponent } from './pages/chamado/chamado.component';

import { AuthGuard } from './guards/auth.guard';
import { LoginGuard } from './guards/login.guard';
import { RoleGuard } from './guards/role.guard';
import { NotFoundComponent } from './pages/not-found/not-found.component';

export const routes: Routes = [
  { path: '', redirectTo: '/auth/login', pathMatch: 'full' },

  {
    path: 'auth',
    children: [
      {
        path: 'login',
        component: LoginComponent,
        canActivate: [LoginGuard],
      },
      { path: '**', component: NotFoundComponent },
    ],
  },

  {
    path: 'app',
    canActivate: [AuthGuard],
    children: [
      { path: 'home', component: HomeComponent },
      {
        path: 'list-usuario',
        component: UsuarioComponent,
        canActivate: [RoleGuard],
        data: { roles: ['FUNCIONARIO'] },
      },
      { path: 'list-chamado', component: ListarChamadoComponent },
      {
        path: 'open-chamado',
        component: AbrirChamadoComponent,
        canActivate: [RoleGuard],
        data: { roles: ['CLIENTE'] },
      },
      { path: 'chamados/:id', component: ChamadoComponent },
      { path: '**', redirectTo: '/app/home' },
    ],
  },
  { path: '**', component: NotFoundComponent },
];
