import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { Chamado, ChamadoService } from '../../service/chamado.service';

@Component({
  selector: 'app-chamado',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './listar-chamado.component.html',
  styleUrl: './listar-chamado.component.css',
})
export class ListarChamadoComponent implements OnInit {
  chamados: Chamado[] = [];

  constructor(
    readonly chamadoService: ChamadoService,
    readonly router: Router
  ) {}

  ngOnInit(): void {
    this.loadChamados();
  }

  loadChamados(): void {
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

  goToHome() {
    this.router.navigate(['/chamado']);
  }
}
