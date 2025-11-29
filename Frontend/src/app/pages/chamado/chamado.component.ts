import {
  Component,
  OnInit,
  OnDestroy,
  AfterViewChecked,
  ViewChild,
  ElementRef,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { timer, switchMap, filter, Subscription, catchError, of } from 'rxjs';
import {
  Conversa,
  Mensagem,
  ConversaService,
} from '../../service/conversa.service';
import { Chamado, ChamadoService } from '../../service/chamado.service';
import { Usuario, UsuarioService } from '../../service/usuario.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-chamado',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './chamado.component.html',
  styleUrls: ['./chamado.component.css'],
})
export class ChamadoComponent implements OnInit, OnDestroy, AfterViewChecked {
  @ViewChild('scrollContainer') readonly scrollContainer!: ElementRef;
  chamados!: Chamado;
  conversas: Conversa[] = [];
  usuarios: Usuario[] = [];
  funcionarios: number = 0;
  isClienteLogado: boolean = false;
  showPermissionError: boolean = false;

  usuarioLogado = this.usuarioService.obterUsuarioLogado();

  private pollingSubscription?: Subscription;
  private lastConversaId = 0;
  private pollingIntervalMs = 3000;

  constructor(
    readonly route: ActivatedRoute,
    readonly chamadoService: ChamadoService,
    readonly conversaService: ConversaService,
    readonly usuarioService: UsuarioService,
    readonly router: Router,
    readonly fb: FormBuilder
  ) {}

  enviarMensagemForm = this.fb.group({
    mensagem: ['', Validators.required],
  });

  ngOnInit(): void {
    if (this.usuarioLogado?.tipoUsuario === 'CLIENTE') {
      this.isClienteLogado = true;
    }
    this.loadChamados();
    this.loadConversas().then(() => this.startPolling());
    this.loadFuncionarios();
  }

  ngAfterViewChecked(): void {
    this.scrollToBottom();
  }

  private scrollToBottom(): void {
    try {
      this.scrollContainer.nativeElement.scrollTop =
        this.scrollContainer.nativeElement.scrollHeight;
    } catch (err) {}
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
            this.lastConversaId = Math.max(
              0,
              ...this.conversas.map((c: any) => c.idConversa ?? 0)
            );
            resolve();
          },
          error: (err) => {
            console.error('Erro ao carregar conversas', err);
            resolve();
          },
        });
    });
  }

  loadFuncionarios(): void {
    this.usuarioService.getFuncionarios().subscribe({
      next: (data) => {
        this.usuarios = data;
      },
      error: (err) => console.error('Erro ao carregar funcionários', err),
    });
  }

  startPolling(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.stopPolling();

    this.pollingSubscription = timer(0, this.pollingIntervalMs)
      .pipe(
        filter(() => typeof document !== 'undefined' && !document.hidden),
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
      .subscribe((novas: Conversa[]) => {
        if (novas.length > 0) {
          this.conversas = [...this.conversas, ...novas];
          const maxId = Math.max(...novas.map((c: any) => c.idConversa ?? 0));
          this.lastConversaId = Math.max(this.lastConversaId, maxId);
          this.scrollToBottom();
        }
      });
  }

  stopPolling(): void {
    if (this.pollingSubscription) {
      this.pollingSubscription.unsubscribe();
      this.pollingSubscription = undefined;
    }
  }

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
            this.scrollToBottom();
          }
        },
        error: (err) => console.error('Erro ao buscar novas mensagens', err),
      });
  }

  onSubmit(): void {
    if (this.enviarMensagemForm.invalid) return;

    const usuarioLogado = this.usuarioService.obterUsuarioLogado();
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
      next: () => {
        this.enviarMensagemForm.reset();
        this.fetchNewMessagesOnce();
      },
      error: (erro) => {
        console.error('Erro ao enviar a mensagem: ', erro);

        if (erro.status === 400) {
          this.showPermissionError = true; // 👈 abre o modal
        }
      },
    });
  }

  closePermissionErrorModal() {
    this.showPermissionError = false;
  }

  onPatch(campo: string, valor: any): void {
    const idChamado = Number(this.route.snapshot.paramMap.get('id'));
    if (!idChamado) {
      console.error('ID do chamado inválido');
      return;
    }

    const payload: any = {};

    switch (campo) {
      case 'status':
        payload.status = valor;
        break;
      case 'prioridade':
        payload.prioridade = valor;
        break;
      case 'idUsuario':
        payload.idUsuario = Number(valor);
        break;
      case 'idModulo':
        payload.idModulo = Number(valor);
        break;
      case 'idJornada':
        payload.idJornada = Number(valor);
        break;
    }

    this.chamadoService.patchChamado(idChamado, payload).subscribe({
      next: (chamadoAtualizado) => {
        this.chamados = chamadoAtualizado;
      },
      error: (err) => {
        console.error('Erro ao atualizar chamado:', err);
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

  goToHome() {
    this.router.navigate(['/app/list-chamado']);
  }
}
