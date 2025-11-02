import { Component, OnInit } from '@angular/core';
import { Usuario, UsuarioService } from '../../service/usuario.service';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { CadUsuarioComponent } from '../../shared/modal/cad-usuario/cad-usuario.component';
import { EdtUsuarioComponent } from '../../shared/modal/edt-usuario/edt-usuario.component';
import { stat } from 'fs';

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
  successModalOpen = false;
  usuarios: Usuario[] = [];

  confirmDeleteModalOpen = false;
  usuarioSelecionado: Usuario | null = null;

  constructor(private usuarioService: UsuarioService) {}

  getFuncionario(status: string): string {
    switch (status) {
      case 'CLIENTE':
        return 'Cliente';
      case 'FUNCIONARIO':
        return 'Funcionário';
      default:
        return status;
    }
  }

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
      (u) => u.idUsuario === usuario.idUsuario
    );
    if (index !== -1) {
      this.usuarios[index] = usuario;
      this.usuarios = [...this.usuarios];
    } else {
      this.usuarios = [...this.usuarios, usuario];
    }
  }

  // 🆕 Abre o modal de confirmação
  openConfirmDelete(usuario: Usuario): void {
    this.usuarioSelecionado = usuario;
    this.confirmDeleteModalOpen = true;
  }

  // 🆕 Fecha o modal de confirmação
  closeConfirmDelete(): void {
    this.usuarioSelecionado = null;
    this.confirmDeleteModalOpen = false;
  }

  // 🆕 Confirma a exclusão e chama o service
  confirmDelete(): void {
    if (!this.usuarioSelecionado) return;

    this.usuarioService
      .delUsuario(this.usuarioSelecionado.idUsuario)
      .subscribe({
        next: () => {
          this.loadUsuarios(); // atualiza tabela
          this.closeConfirmDelete();
          this.successModalOpen = true; // mostra modal de sucesso
        },
        error: (err) => console.error('Erro ao excluir usuário:', err),
      });
  }

  // Mantém seu modal de sucesso funcionando
  closeSuccess(): void {
    this.successModalOpen = false;
  }
}
