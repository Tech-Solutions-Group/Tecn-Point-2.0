import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Usuario, UsuarioService } from '../../../service/usuario.service';
import { FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-cad-usuario',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './cad-usuario.component.html',
  styleUrls: ['./cad-usuario.component.css'],
})
export class CadUsuarioComponent {
  formInvalid = false;
  isOpen = false;

  @Input() refresh!: () => void;
  @Output() usuarioCadastrado = new EventEmitter<Usuario>();

  constructor(
    private usuarioService: UsuarioService,
    private fb: FormBuilder
  ) {}

  cadUsuarioForm = this.fb.group({
    nome: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    senha: ['', Validators.required],
    tipoUsuario: ['', Validators.required],
  });

  onSubmit(): void {
    if (this.cadUsuarioForm.invalid) {
      this.formInvalid = true;
      this.cadUsuarioForm.markAllAsTouched();
      return;
    }

    this.formInvalid = false;

    const dados = this.cadUsuarioForm.value as Usuario;

    this.usuarioService.postUsuario(dados).subscribe({
      next: (res) => {
        console.log('Usuário cadastrado com sucesso:', res);
        this.usuarioCadastrado.emit(res);
        this.cadUsuarioForm.reset();
        this.close();
      },
      error: (erro) => {
        console.error('Erro ao cadastrar usuário:', erro);
      },
    });
  }

  open() {
    this.isOpen = true;
  }

  close() {
    this.isOpen = false;
  }
}
