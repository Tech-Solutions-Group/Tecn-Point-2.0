import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Conversa {
  idConversa: number;
  remetente: {
    idUsuario: number;
    nome: string;
    tipoUsuario: string;
  };
  mensagem: string;
  dataHoraEnvio: string;
}

export interface NovaMensagem {
  idChamado: number;
  idUltimaConversa: number;
}

export interface Mensagem {
  idChamado: number;
  idRemetente: number;
  mensagem: string;
}

@Injectable({
  providedIn: 'root',
})
export class ConversaService {
  private apiUrl = 'http://localhost:8080/conversas';

  constructor(private http: HttpClient) {}

  postMensagem(data: Mensagem): Observable<Conversa> {
    return this.http.post<Conversa>(`${this.apiUrl}/enviar-mensagem`, data);
  }

  postNovaMensagem(data: NovaMensagem): Observable<Conversa[]> {
    return this.http.post<Conversa[]>(`${this.apiUrl}/buscar-mensagens`, data);
  }
}
