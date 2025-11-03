import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { Conversa, ConversaService } from '../../service/conversa.service';
import { Chamado, ChamadoService } from '../../service/chamado.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-chamado',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './chamado.component.html',
  styleUrl: './chamado.component.css',
})
export class ChamadoComponent implements OnInit {
  chamados!: Chamado;
  conversas: Conversa[] = [];

  constructor(
    readonly route: ActivatedRoute,
    readonly chamadoService: ChamadoService,
    readonly conversaService: ConversaService
  ) {}

  ngOnInit(): void {
    this.loadChamados();
    this.loadConversas();
  }

  loadChamados(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.chamadoService.getChamadoById(id).subscribe({
      next: (data) => (this.chamados = data),
      error: (err) => console.error('Erro ao carregar chamados', err),
    });
  }

  loadConversas(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.conversaService
      .postNovaMensagem({
        idChamado: id,
        idUltimaConversa: 0,
      })
      .subscribe({
        next: (data) => (this.conversas = data),
        error: (err) => console.error('Erro ao carregar conversas', err),
      });
  }
}
