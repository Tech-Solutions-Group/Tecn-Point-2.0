import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { interval, Subscription, switchMap, catchError, of } from 'rxjs';
import {
  Conversa,
  Mensagem,
  ConversaService,
} from '../../service/conversa.service';
import { Chamado, ChamadoService } from '../../service/chamado.service';
import { UsuarioService } from '../../service/usuario.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-chamado',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './chamado.component.html',
  styleUrls: ['./chamado.component.css'],
})
export class ChamadoComponent implements OnInit, OnDestroy {
  chamados!: Chamado;
  conversas: Conversa[] = [];
  private pollingSubscription?: Subscription;
  private lastConversaId = 0;
  private pollingIntervalMs = 3000;

  constructor(
    readonly route: ActivatedRoute,
    readonly chamadoService: ChamadoService,
    readonly conversaService: ConversaService,
    readonly usuarioService: UsuarioService,
    readonly fb: FormBuilder
  ) {}

  enviarMensagemForm = this.fb.group({
    mensagem: ['', Validators.required],
  });

  ngOnInit(): void {
    this.loadChamados();
    this.loadConversas().then(() => this.startPolling());
  }

  ngOnDestroy(): void {
    this.stopPolling();
  }

  loadChamados(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.chamadoService.getChamadoById(id).subscribe({
      next: (data) => (this.chamados = data),
      error: (err) => console.error('Erro ao carregar chamados', err),
    });
  }

  // retorna Promise para garantir sequência ao iniciar o polling
  loadConversas(): Promise<void> {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    return new Promise((resolve) => {
      this.conversaService
        .postNovaMensagem({
          idChamado: id,
          idUltimaConversa: 0,
        })
        .subscribe({
          next: (res) => {
            this.conversas = res ?? [];
            // calcula último id conhecido (campo idConversa pode variar; usa 0 se não existir)
            this.lastConversaId = Math.max(
              0,
              ...this.conversas.map((c: any) => c.idConversa ?? 0)
            );
            console.log('Conversas carregadas, lastId=', this.lastConversaId);
            resolve();
          },
          error: (err) => {
            console.error('Erro ao carregar conversas', err);
            resolve();
          },
        });
    });
  }

  startPolling(): void {
    this.stopPolling();
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.pollingSubscription = interval(this.pollingIntervalMs)
      .pipe(
        switchMap(() =>
          this.conversaService
            .postNovaMensagem({
              idChamado: id,
              idUltimaConversa: this.lastConversaId,
            })
            .pipe(
              catchError((err) => {
                console.error('Erro no polling de conversas', err);
                return of([] as Conversa[]);
              })
            )
        )
      )
      .subscribe((res: Conversa[]) => {
        if (!res || res.length === 0) return;
        // adiciona apenas as novas mensagens e atualiza lastConversaId
        this.conversas = [...this.conversas, ...res];
        const maxId = Math.max(0, ...res.map((c: any) => c.idConversa ?? 0));
        if (maxId > this.lastConversaId) this.lastConversaId = maxId;
      });
  }

  stopPolling(): void {
    if (this.pollingSubscription) {
      this.pollingSubscription.unsubscribe();
      this.pollingSubscription = undefined;
    }
  }

  // busca uma vez por novas mensagens (usado após envio)
  fetchNewMessagesOnce(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.conversaService
      .postNovaMensagem({
        idChamado: id,
        idUltimaConversa: this.lastConversaId,
      })
      .subscribe({
        next: (res) => {
          if (res && res.length > 0) {
            this.conversas = [...this.conversas, ...res];
            const maxId = Math.max(
              0,
              ...res.map((c: any) => c.idConversa ?? 0)
            );
            if (maxId > this.lastConversaId) this.lastConversaId = maxId;
          }
        },
        error: (err) => console.error('Erro ao buscar novas mensagens', err),
      });
  }

  onSubmit(): void {
    if (this.enviarMensagemForm.invalid) return;

    const usuarioLogado: any = this.usuarioService.usuarioLogado;
    const id = Number(this.route.snapshot.paramMap.get('id'));

    if (!usuarioLogado) {
      console.error('Usuario logado não definido');
      return;
    }

    const dados: Mensagem = {
      idChamado: id,
      idRemetente: usuarioLogado.idUsuario,
      mensagem: this.enviarMensagemForm.value.mensagem!,
    };

    this.conversaService.postMensagem(dados).subscribe({
      next: (res) => {
        console.log('Mensagem enviada com sucesso');
        this.enviarMensagemForm.reset();
        // buscar imediatamente as mensagens novas
        this.fetchNewMessagesOnce();
      },
      error: (erro) => {
        console.log('Erro ao enviar a mensagem: ', erro);
      },
    });
  }

  getStatusLabel(status: string): string {
    switch (status) {
      case 'ABERTO':
        return 'Aberto';
      case 'PENDENTE':
        return 'Pendente';
      case 'RESOLVIDO':
        return 'Resolvido';
      case 'EM_ANDAMENTO':
        return 'Em Andamento';
      default:
        return status;
    }
  }

  getPrioridadeLabel(prioridade: string): string {
    switch (prioridade) {
      case 'ALTA':
        return 'Alta';
      case 'MEDIA':
        return 'Média';
      case 'BAIXA':
        return 'Baixa';
      default:
        return prioridade;
    }
  }
}
