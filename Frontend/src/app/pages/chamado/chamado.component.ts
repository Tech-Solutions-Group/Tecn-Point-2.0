import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { Chamado, ChamadoService } from '../../service/chamado.service';

@Component({
  selector: 'app-chamado',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './chamado.component.html',
  styleUrl: './chamado.component.css',
})
export class ChamadoComponent implements OnInit {
  chamados: Chamado[] = [];

  constructor(readonly chamadoService: ChamadoService) {}

  ngOnInit(): void {
    this.loadChamados();
  }

  loadChamados(): void {
    this.chamadoService.getAllChamados().subscribe({
      next: (data) => (this.chamados = data),
      error: (err) => console.error('Erro ao carregar chamados', err),
    });
  }
}
