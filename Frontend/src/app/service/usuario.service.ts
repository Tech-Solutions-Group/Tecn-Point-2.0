import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Usuario {
  id: number;
  nome: string;
  email: string;
  senha: string;
  tipoUsuario: string;
}

export interface UsuarioFiltro {
  busca?: string;
  page?: number;
  limit?: number;
}

export interface UsuarioPaginado {
  data: Usuario[];
  total: number;
  page: number;
  limit: number;
}

@Injectable({
  providedIn: 'root',
})
export class UsuarioService {
  private apiUrl = 'http://localhost:8080/usuarios';

  constructor(private http: HttpClient) {}

  getUsuario(filtro?: UsuarioFiltro): Observable<Usuario[]> {
    let params = new HttpParams();

    if (filtro) {
      if (filtro.busca) params = params.set('busca', filtro.busca);
      if (filtro.limit) params = params.set('limit', filtro.limit);
      if (filtro.page) params = params.set('page', filtro.page);
    }

    return this.http.get<Usuario[]>(this.apiUrl, { params });
  }

  getUsuarioById(id: string): Observable<Usuario> {
    return this.http.get<Usuario>(`${this.apiUrl}/${id}`);
  }

  postUsuario(data: Partial<Usuario>): Observable<Usuario> {
    return this.http.post<Usuario>(`${this.apiUrl}/adicionar`, data);
  }

  delUsuario(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
