import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { Conversa, ConversaService } from '../../service/conversa.service';
import { Chamado, ChamadoService } from '../../service/chamado.service';

@Component({
  selector: 'app-chamado',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './chamado.component.html',
  styleUrl: './chamado.component.css',
})
export class ChamadoComponent implements OnInit {
  chamados?: Chamado;
  conversas: Conversa[] = [];

  constructor(
    readonly chamadoService: ChamadoService,
    readonly conversaService: ConversaService
  ) {}

  ngOnInit(): void {}

  loadChamados(): void {
    this.chamadoService.getChamadoById(this.idChamado).subscribe({
      next: (data) => (this.chamados = data),
      error: (err) => console.error('Erro ao carregar chamados', err),
    });
  }

  loadConversas(): void {
    this.conversaService
      .postNovaMensagem({
        idChamado: this.chamados[0]?.idChamado,
        idNovaMensagem: 0,
      })
      .subscribe({
        next: (data) => (this.conversas = data),
        error: (err) => console.error('Erro ao carregar conversas', err),
      });
  }
}
