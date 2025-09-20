import { Component, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { CadUsuarioComponent } from '../../shared/cad-usuario/cad-usuario.component';
import {
  Usuario,
  UsuarioFiltro,
  UsuarioService,
} from '../../service/usuario.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-usuario',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    CadUsuarioComponent,
  ],
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css'],
})
export class UsuarioComponent implements OnInit {
  usuarios: Usuario[] = [];
  total = 0;
  page = 1;
  limit = 10;

  filtroForm = this.fb.group({
    busca: [''],
  });

  constructor(
    private fb: FormBuilder,
    private usuarioService: UsuarioService
  ) {}

  ngOnInit(): void {
    this.loadUsuarios();
  }

  loadUsuarios() {
    const filtros: UsuarioFiltro = {
      page: this.page,
      limit: this.limit,
      busca: this.filtroForm.value.busca || undefined,
    };

    this.usuarioService.getUsuario(filtros).subscribe((res) => {
      this.usuarios = res;
    });
  }

  aplicarFiltro() {
    this.page = 1;
    this.loadUsuarios();
  }

  mudarPagina(novaPagina: number) {
    this.page = novaPagina;
    this.loadUsuarios();
  }
}
