import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Usuario, UsuarioService } from '../../service/usuario.service';
import { Router } from '@angular/router';
import { FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-cad-usuario',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './cad-usuario.component.html',
  styleUrl: './cad-usuario.component.css',
})
export class CadUsuarioComponent implements OnInit {
  usuario: Usuario[] = [];
  formInvalid = false;
  isOpen = false;

  constructor(
    private usuarioService: UsuarioService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  cadUsuarioForm = this.fb.group({
    nome: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    senha: ['', Validators.required],
    tipoUsuario: ['', Validators.required],
  });

  ngOnInit(): void {
    this.loadUsuarios();
  }

  private loadUsuarios(): void {
    this.usuarioService.getUsuario().subscribe((dados) => {
      this.usuario = dados;
    });
  }

  onSubmit(): void {
    if (this.cadUsuarioForm.invalid) {
      this.formInvalid = true;
      this.cadUsuarioForm.markAllAsTouched();
      return;
    }

    this.formInvalid = false;

    const dados: any = this.cadUsuarioForm.value;

    Object.keys(dados).forEach((key) => {
      if (dados[key] === null) dados[key] = '';
    });

    this.usuarioService
      .postUsuario(this.cadUsuarioForm.value as Usuario)
      .subscribe({
        next: (res) => {
          console.log('Usuário cadastrado com sucesso:', res);
          this.loadUsuarios();
          this.cadUsuarioForm.reset();
        },
        error: (erro) => console.error('Erro ao cadastrar usuario', erro),
      });
  }

  open() {
    this.isOpen = true;
  }

  close() {
    this.isOpen = false;
  }
}
