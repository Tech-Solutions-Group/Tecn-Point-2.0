import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

export interface Usuario {
  idUsuario: number;
  nome: string;
  email: string;
  senha: string;
  tipoUsuario: string;
}

export interface UsuarioLogin {
  email: string;
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
  private readonly KEY = 'usuario';
  private isBrowser(): boolean {
    return typeof window !== 'undefined' && typeof localStorage !== 'undefined';
  }

  usuarioSubject = new BehaviorSubject<UsuarioLogado | null>(null);

  constructor(readonly http: HttpClient) {
    const savedUser = this.obterUsuarioLogado();
    this.usuarioSubject.next(savedUser);
  }

  readonly usuario$ = this.usuarioSubject.asObservable();
  readonly apiUrl = 'http://localhost:8080/usuarios';

  postUsarioLogin(data: any): Observable<UsuarioLogado> {
    return new Observable((observer) => {
      this.http.post<UsuarioLogado>(`${this.apiUrl}/login`, data).subscribe({
        next: (user) => {
          localStorage.setItem(this.KEY, JSON.stringify(user));
          this.usuarioSubject.next(user);
          observer.next(user);
          observer.complete();
        },
        error: (err) => observer.error(err),
      });
    });
  }

  obterUsuarioLogado(): UsuarioLogado | null {
    if (!this.isBrowser()) return null;
    try {
      const data = localStorage.getItem(this.KEY);
      return data ? JSON.parse(data) : null;
    } catch {
      return null;
    }
  }

  usuarioLogado(): boolean {
    if (!this.isBrowser()) return false;
    return this.obterUsuarioLogado() !== null;
  }

  logoutUsuarioLogado(): void {
    if (!this.isBrowser()) return;
    this.usuarioSubject.next(null);
    localStorage.removeItem(this.KEY);
  }

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
