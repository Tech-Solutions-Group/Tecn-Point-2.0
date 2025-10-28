import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Chamado {
  id_chamado: number;
  descricao: string;
  prioridade: string;
  status: string;
  titulo: string;
  fk_id_cliente: number;
  fk_id_funcionario: number;
  fk_id_jornada: number;
  fk_id_modulo: number;
}

@Injectable({
  providedIn: 'root',
})
export class ChamadoService {
  private apiUrl = 'http://localhost:8080/chamados';

  constructor(private http: HttpClient) {}

  getAllChamados(): Observable<Chamado[]> {
    return this.http.get<Chamado[]>(`${this.apiUrl}/exibir-todos-chamados`);
  }

  getChamadoById(id: number): Observable<Chamado> {
    return this.http.get<Chamado>(`${this.apiUrl}/${id}`);
  }

  postChamado(data: Chamado): Observable<Chamado> {
    return this.http.post<Chamado>(`${this.apiUrl}/abrir-chamado`, data);
  }

  patchChamado(id: number, data: Chamado): Observable<Chamado> {
    return this.http.patch<Chamado>(`${this.apiUrl}/${id}`, data);
  }

  delChamado(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
