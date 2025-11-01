import { Routes } from '@angular/router';
import { UsuarioComponent } from '../app/pages/usuario/usuario.component';
import { ChamadoComponent } from '../app/pages/chamado/chamado.component';
import { HomeComponent } from '../app/pages/home/home.component';
import { AbrirChamadoComponent } from '../app/pages/abrir-chamado/abrir-chamado.component';

export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'usuario', component: UsuarioComponent },
  { path: 'chamado', component: ChamadoComponent },
  { path: 'abrir-chamado', component: AbrirChamadoComponent },
];
