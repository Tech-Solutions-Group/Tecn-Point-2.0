import { Component } from '@angular/core';
import {
  FormBuilder,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { UsuarioService } from '../../service/usuario.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  formInvalid = false;

  constructor(
    readonly usuarioService: UsuarioService,
    readonly fb: FormBuilder,
    readonly router: Router
  ) {}

  login = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    senha: ['', Validators.required],
  });

  onSubmit(): void {
    if (this.login.invalid) {
      this.formInvalid = true;
      this.login.markAllAsTouched();
      return;
    }

    this.formInvalid = false;

    const dados: 
  }
}
