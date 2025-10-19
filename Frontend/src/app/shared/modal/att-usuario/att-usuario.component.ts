import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Usuario, UsuarioService } from '../../../service/usuario.service';
import { FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-att-usuario',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './att-usuario.component.html',
  styleUrl: './att-usuario.component.css',
})
export class AttUsuarioComponent implements OnInit {
  id!: string;
  formInvalid = false;
  isOpen = false;

  constructor(
    private usuarioService: UsuarioService,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {}

  attUsuarioForm = this.fb.group({
    nome: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    senha: ['', Validators.required],
  });

  ngOnInit(): void {
    this.loadUsuario();
  }

  private loadUsuario(): void {
    this.id = this.route.snapshot.paramMap.get('id')!;

    this.usuarioService.getUsuarioById(this.id).subscribe((user: any) => {
      user.
    })
  }

  onSubmit(): void {
    if (this.attUsuarioForm.invalid) {
      this.formInvalid = true;
      this.attUsuarioForm.markAllAsTouched();
      return;
    }

    this.formInvalid = false;

    this.usuarioService
      .putUsuario(this.id, this.attUsuarioForm.value as Usuario)
      .subscribe({
        next: (res) => {
          console.log('Usuário atualizado com sucesso:', res);
        },
        error: (err) => {
          console.error('Erro ao atualizar usuário:', err);
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
