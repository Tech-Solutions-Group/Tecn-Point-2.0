import { Component, OnInit } from '@angular/core';
import { Usuario, UsuarioService } from '../../service/usuario.service';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { CadUsuarioComponent } from '../../shared/modal/cad-usuario/cad-usuario.component';
import { EdtUsuarioComponent } from '../../shared/modal/edt-usuario/edt-usuario.component';

@Component({
  selector: 'app-usuario',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CadUsuarioComponent,
    EdtUsuarioComponent,
  ],
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css'],
})
export class UsuarioComponent implements OnInit {
  usuarios: Usuario[] = [];

  constructor(private usuarioService: UsuarioService) {}

  ngOnInit(): void {
    this.loadUsuarios();
  }

  loadUsuarios(): void {
    this.usuarioService.getAllUsuario().subscribe({
      next: (data) => (this.usuarios = data),
      error: (err) => console.error('Erro ao carregar usuários:', err),
    });
  }

  refreshUsuarios(): void {
    this.loadUsuarios();
  }

  atualizarLista(usuario: Usuario) {
    const index = this.usuarios.findIndex(
      (u) => u.id_usuario === usuario.id_usuario
    );
    if (index !== -1) {
      this.usuarios[index] = usuario;
    } else {
      this.usuarios.push(usuario);
    }
  }

  deleteUsuario(id: number): void {
    if (confirm('Tem certeza que deseja excluir este usuário?')) {
      this.usuarioService.delUsuario(id).subscribe({
        next: () => this.loadUsuarios(),
        error: (err) => console.error('Erro ao excluir usuário:', err),
      });
    }
  }
}
