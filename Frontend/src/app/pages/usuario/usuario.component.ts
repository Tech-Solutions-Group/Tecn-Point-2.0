import { Component, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { Usuario, UsuarioService } from '../../service/usuario.service';
import { CommonModule } from '@angular/common';
import { CadUsuarioComponent } from '../../shared/modal/cad-usuario/cad-usuario.component';
import { AttUsuarioComponent } from '../../shared/modal/att-usuario/att-usuario.component';

@Component({
  selector: 'app-usuario',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    CadUsuarioComponent,
    AttUsuarioComponent,
  ],
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css'],
})
export class UsuarioComponent implements OnInit {
  usuarios: Usuario[] = [];

  constructor(
    private fb: FormBuilder,
    private usuarioService: UsuarioService
  ) {}

  ngOnInit(): void {
    this.loadUsuarios();
  }

  loadUsuarios(): void {
    this.usuarioService.getUsuario().subscribe((data) => {
      this.usuarios = data;
    });
  }
}
