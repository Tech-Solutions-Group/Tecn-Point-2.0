import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Usuario, UsuarioService } from '../../../service/usuario.service';
import { FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-edt-usuario',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './edt-usuario.component.html',
  styleUrls: ['./edt-usuario.component.css'],
})
export class EdtUsuarioComponent {
  formInvalid = false;
  isOpen = false;
  successModalOpen = false;
  usuarioId!: number;

  @Input() refresh!: () => void;
  @Output() usuarioAtualizado = new EventEmitter<Usuario>();

  constructor(
    private usuarioService: UsuarioService,
    private fb: FormBuilder
  ) {}

  attUsuarioForm = this.fb.group({
    nome: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    senha: ['', Validators.required],
  });

  onSubmit(): void {
    if (this.attUsuarioForm.invalid) {
      this.formInvalid = true;
      this.attUsuarioForm.markAllAsTouched();
      return;
    }

    this.formInvalid = false;

    this.usuarioService
      .putUsuario(this.usuarioId, this.attUsuarioForm.value as Usuario)
      .subscribe({
        next: (res) => {
          console.log('Usuário atualizado com sucesso:', res);
          this.usuarioAtualizado.emit(res);
          this.close();
          this.successModalOpen = true;
        },
        error: (err) => {
          console.error('Erro ao atualizar usuário:', err);
        },
      });
  }

  open(usuario: Usuario) {
    this.usuarioId = usuario.idUsuario;

    this.usuarioService.getUsuarioById(usuario.idUsuario).subscribe({
      next: (user) => {
        this.attUsuarioForm.patchValue({
          nome: user.nome,
          email: user.email,
          senha: user.senha,
        });
        this.isOpen = true;
      },
      error: (err) => {
        console.error('Erro ao carregar usuário:', err);
      },
    });
  }

  close() {
    this.isOpen = false;
  }

  closeSuccess() {
    this.successModalOpen = false;
  }
}
