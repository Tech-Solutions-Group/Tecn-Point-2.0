import { Routes } from '@angular/router';
import { UsuarioComponent } from '../app/pages/usuario/usuario.component';
import { ListarChamadoComponent } from './pages/listar-chamado/listar-chamado.component';
import { HomeComponent } from '../app/pages/home/home.component';
import { AbrirChamadoComponent } from '../app/pages/abrir-chamado/abrir-chamado.component';
import { ChamadoComponent } from './pages/chamado/chamado.component';
import { LoginComponent } from './pages/login/login.component';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'list-usuario', component: UsuarioComponent },
  { path: 'list-chamado', component: ListarChamadoComponent },
  { path: 'open-chamado', component: AbrirChamadoComponent },
  { path: 'chamados/:id', component: ChamadoComponent },
];
