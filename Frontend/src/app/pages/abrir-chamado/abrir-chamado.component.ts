import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { AberturaChamado, ChamadoService } from '../../service/chamado.service';
import { UsuarioService } from '../../service/usuario.service';

@Component({
  selector: 'app-abrir-chamado',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './abrir-chamado.component.html',
  styleUrl: './abrir-chamado.component.css',
})
export class AbrirChamadoComponent {
  formInvalid = false;
  successModalOpen = false;

  constructor(
    private chamadoService: ChamadoService,
    private usuarioService: UsuarioService,
    private fb: FormBuilder,
    private router: Router
  ) {}

  abrirChamadoForm = this.fb.group({
    titulo: ['', Validators.required],
    descricao: ['', Validators.required],
    prioridade: ['', Validators.required],
    id_jornada: ['', Validators.required],
    id_modulo: ['', Validators.required],
  });

  onSubmit(): void {
    const usuarioLogado = this.usuarioService.usuarioLogado;

    if (!usuarioLogado) {
      console.error('Usuário logado não definido');
      return;
    }

    if (this.abrirChamadoForm.invalid) {
      this.formInvalid = true;
      this.abrirChamadoForm.markAllAsTouched();
      return;
    }

    this.formInvalid = false;

    const dados: AberturaChamado = {
      titulo: this.abrirChamadoForm.value.titulo!,
      descricao: this.abrirChamadoForm.value.descricao!,
      prioridade: this.abrirChamadoForm.value.prioridade!,
      idCliente: usuarioLogado.idUsuario,
      idJornada: Number(this.abrirChamadoForm.value.id_jornada),
      idModulo: Number(this.abrirChamadoForm.value.id_modulo),
    };

    this.chamadoService.postChamado(dados).subscribe({
      next: () => {
        this.abrirChamadoForm.reset();
        this.successModalOpen = true;
      },
      error: (erro) => {
        console.error('Erro ao abrir chamado:', erro);
      },
    });
  }

  closeForm(): void {
    this.router.navigate(['/home']);
  }

  closeSuccess() {
    this.successModalOpen = false;
    this.router.navigate(['/list-chamado']);
  }
}
