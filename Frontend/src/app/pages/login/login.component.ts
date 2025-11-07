import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { UsuarioLogin, UsuarioService } from '../../service/usuario.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent implements OnInit {
  formInvalid = false;
  usuarioLogado = false;

  constructor(
    readonly usuarioService: UsuarioService,
    readonly fb: FormBuilder,
    readonly router: Router
  ) {}

  usuarioLoginForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    senha: ['', Validators.required],
  });

  ngOnInit() {
    this.usuarioLogado = this.usuarioService.usuarioLogado();
  }
  onSubmit(): void {
    if (this.usuarioLoginForm.invalid) {
      this.formInvalid = true;
      this.usuarioLoginForm.markAllAsTouched();
      return;
    }

    this.formInvalid = false;

    const dados: UsuarioLogin = {
      email: this.usuarioLoginForm.value.email!,
      senha: this.usuarioLoginForm.value.senha!,
    };

    this.usuarioService.postUsarioLogin(dados).subscribe({
      next: () => {
        this.router.navigate(['/app/home']);
      },
      error: (err) => {
        console.error('Erro ao logar', err);
      },
    });
  }
}
