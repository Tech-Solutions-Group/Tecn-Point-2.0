import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Usuario {
  id_usuario: number;
  nome: string;
  email: string;
  senha: string;
  tipoUsuario: string;
}

@Injectable({
  providedIn: 'root',
})
export class UsuarioService {
  private apiUrl = 'http://localhost:8080/usuarios';

  constructor(private http: HttpClient) {}

  getAllUsuario(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.apiUrl);
  }

  getUsuarioById(id: number): Observable<Usuario> {
    return this.http.get<Usuario>(`${this.apiUrl}/${id}`);
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
