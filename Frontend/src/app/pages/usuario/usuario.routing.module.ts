import { RouterModule, Routes } from '@angular/router';
import { UsuarioComponent } from './usuario.component';
import { CadUsuarioComponent } from './cad-usuario/cad-usuario.component';
import { NgModule } from '@angular/core';

const usuarioRoutes: Routes = [
  { path: '', component: UsuarioComponent },
  { path: 'adicionar', component: CadUsuarioComponent },
];

@NgModule({
  imports: [RouterModule.forChild(usuarioRoutes)],
  exports: [RouterModule],
})
export class UsuarioRoutingModule {}
