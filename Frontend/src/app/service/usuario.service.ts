import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Usuario {
  idUsuario: number;
  nome: string;
  email: string;
  senha: string;
  tipoUsuario: string;
}

export interface UsuarioLogin {
  nome: string;
  senha: string;
}

export interface UsuarioLogado {
  idUsuario: number;
  nome: string;
  email: string;
  tipoUsuario: string;
}

@Injectable({
  providedIn: 'root',
})
export class UsuarioService {
  usuarioLogado?: Usuario;

  readonly apiUrl = 'http://localhost:8080/usuarios';

  constructor(readonly http: HttpClient) {}

  getAllUsuario(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.apiUrl);
  }

  getUsuarioById(id: number): Observable<Usuario> {
    return this.http.get<Usuario>(`${this.apiUrl}/${id}`);
  }

  getFuncionarios(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(`${this.apiUrl}/listar-funcionarios`);
  }

  postUsuario(data: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(`${this.apiUrl}/adicionar`, data);
  }

  putUsuario(id: number, data: Usuario): Observable<Usuario> {
    return this.http.put<Usuario>(`${this.apiUrl}/${id}`, data);
  }

  delUsuario(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
