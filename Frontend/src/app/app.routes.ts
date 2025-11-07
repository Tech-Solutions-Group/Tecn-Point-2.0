import { Routes } from '@angular/router';

import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { UsuarioComponent } from './pages/usuario/usuario.component';
import { ListarChamadoComponent } from './pages/listar-chamado/listar-chamado.component';
import { AbrirChamadoComponent } from './pages/abrir-chamado/abrir-chamado.component';
import { ChamadoComponent } from './pages/chamado/chamado.component';

import { AuthGuard } from './guards/auth.guard';
import { LoginGuard } from './guards/login.guard';

export const routes: Routes = [
  { path: '', redirectTo: '/auth/login', pathMatch: 'full' },
  {
    path: 'auth',
    children: [
      { path: 'login', component: LoginComponent, canActivate: [LoginGuard] },
    ],
  },

  {
    path: 'app',
    canActivate: [AuthGuard],
    children: [
      { path: 'home', component: HomeComponent },
      { path: 'list-usuario', component: UsuarioComponent },
      { path: 'list-chamado', component: ListarChamadoComponent },
      { path: 'open-chamado', component: AbrirChamadoComponent },
      { path: 'chamados/:id', component: ChamadoComponent },
    ],
  },
  { path: '**', redirectTo: '/app/home' },
];
