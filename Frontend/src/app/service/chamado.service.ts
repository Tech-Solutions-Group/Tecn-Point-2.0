import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface AberturaChamado {
  titulo: string;
  descricao: string;
  prioridade: string;
  idCliente: number;
  idJornada: number;
  idModulo: number;
}

export interface Chamado {
  idChamado: number;
  titulo: string;
  descricao: string;
  prioridade: string;
  status: string;
  cliente: { idUsuario: number; nome: string; tipoUsuario: string };
  funcionario: { idUsuario: number; nome: string; tipoUsuario: string };
  jornada: { idJornada: number; jornada: string };
  modulo: { idModulo: number; modulo: string };
}

@Injectable({
  providedIn: 'root',
})
export class ChamadoService {
  readonly apiUrl = 'http://localhost:8080/chamados';

  constructor(readonly http: HttpClient) {}

  getAllChamados(): Observable<Chamado[]> {
    return this.http.get<Chamado[]>(`${this.apiUrl}/exibir-todos-chamados`);
  }

  getChamadoById(id: number): Observable<Chamado> {
    return this.http.get<Chamado>(`${this.apiUrl}/${id}`);
  }

  postChamado(data: AberturaChamado): Observable<Chamado> {
    return this.http.post<Chamado>(`${this.apiUrl}/abrir-chamado`, data);
  }

  patchChamado(id: number, data: Partial<Chamado>): Observable<Chamado> {
    return this.http.patch<Chamado>(`${this.apiUrl}/${id}`, data);
  }
}
