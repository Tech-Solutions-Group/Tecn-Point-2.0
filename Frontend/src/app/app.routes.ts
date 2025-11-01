import { Routes } from '@angular/router';
import { UsuarioComponent } from '../app/pages/usuario/usuario.component';
import { ListarChamadoComponent } from './pages/listar-chamado/listar-chamado.component';
import { HomeComponent } from '../app/pages/home/home.component';
import { AbrirChamadoComponent } from '../app/pages/abrir-chamado/abrir-chamado.component';

export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'usuario', component: UsuarioComponent },
  { path: 'chamado', component: ListarChamadoComponent },
  { path: 'abrir-chamado', component: AbrirChamadoComponent },
];
