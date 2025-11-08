import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { Chamado, ChamadoService } from '../../service/chamado.service';
import { UsuarioLogado, UsuarioService } from '../../service/usuario.service';
@Component({
  selector: 'app-listar-chamado',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './listar-chamado.component.html',
  styleUrl: './listar-chamado.component.css',
})
export class ListarChamadoComponent implements OnInit {
  chamado!: Chamado;
  chamados: Chamado[] = [];

  idUsuario: number = this.usuarioService.obterUsuarioLogado()!.idUsuario;
  tipoUsuario: string = this.usuarioService.obterUsuarioLogado()!.tipoUsuario;

  constructor(
    readonly chamadoService: ChamadoService,
    readonly usuarioService: UsuarioService,
    readonly router: Router
  ) {}

  ngOnInit(): void {
    return this.tipoUsuario === 'CLIENTE'
      ? this.chamadosCliente()
      : this.chamadosFuncionario();
  }

  chamadosCliente() {
    this.chamadoService.getChamadosByCliente(this.idUsuario).subscribe({
      next: (data) => (this.chamados = data),
      error: (err) => console.error('Erro ao carregar chamados', err),
    });
  }

  chamadosFuncionario() {
    this.chamadoService.getAllChamados().subscribe({
      next: (data) => (this.chamados = data),
      error: (err) => console.error('Erro ao carregar chamados', err),
    });
  }

  getPrioridadeLabel(prioridade: string): string {
    switch (prioridade) {
      case 'BAIXA':
        return 'Baixa';
      case 'MEDIA':
        return 'Média';
      case 'ALTA':
        return 'Alta';
      default:
        return prioridade;
    }
  }

  getStatusLabel(status: string): string {
    switch (status) {
      case 'ABERTO':
        return 'Aberto';
      case 'PENDENTE':
        return 'Pendente';
      case 'RESOLVIDO':
        return 'Resolvido';
      case 'EM_ANDAMENTO':
        return 'Em Andamento';
      default:
        return status;
    }
  }

  goToHome(id: number) {
    this.router.navigate(['app/chamados/', id]);
  }
}
