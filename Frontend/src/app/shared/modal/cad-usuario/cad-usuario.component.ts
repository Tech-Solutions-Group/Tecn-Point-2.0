import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Usuario, UsuarioService } from '../../../service/usuario.service';
import { FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function senhaMatchValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const senha = control.get('senha');
    const confirmSenha = control.get('confirmSenha');

    if (!senha || !confirmSenha) return null;
    return senha.value === confirmSenha.value ? null : { confirmSenha: true };
  };
}

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
  successModalOpen = false;

  @Input() refresh!: () => void;
  @Output() usuarioCadastrado = new EventEmitter<Usuario>();

  constructor(
    private usuarioService: UsuarioService,
    private fb: FormBuilder
  ) {}

  cadUsuarioForm = this.fb.group(
    {
      nome: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      senha: ['', Validators.required],
      confirmSenha: ['', Validators.required],
      tipoUsuario: ['', Validators.required],
    },
    { validators: senhaMatchValidator() }
  );

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
        this.usuarioCadastrado.emit(res);
        this.cadUsuarioForm.reset();
        this.close();
        this.successModalOpen = true;
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

  closeSuccess() {
    this.successModalOpen = false;
  }
}
