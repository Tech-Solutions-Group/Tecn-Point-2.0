import { Routes } from '@angular/router';
import { UsuarioComponent } from './pages/usuario/usuario.component';

export const routes: Routes = [
  { path: '', redirectTo: 'usuarios', pathMatch: 'full' },
  { path: 'usuarios', component: UsuarioComponent },
];
