import { Component, ElementRef, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { UsuarioService } from '../../service/usuario.service';
import { Router } from '@angular/router';

interface Mensagem {
  remetente: 'bot' | 'usuario';
  texto: string;
  dataHora: Date;
}

@Component({
  selector: 'app-chat-bot',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './chat-bot.component.html',
  styleUrls: ['./chat-bot.component.css'],
})
export class ChatBotComponent {
  @ViewChild('scrollContainer') scrollContainer!: ElementRef;

  enviarMensagemForm: FormGroup;
  conversas: Mensagem[] = [];
  estadoChat: string = 'inicio';
  usuarioNome: string = this.usuarioService.obterUsuarioLogado()!.nome;
  modoDaltonico: boolean = false;

  mensagemFinal: string =
    'Espero que eu tenha resolvido o seu problema.\nGostaria de abrir um chamado?\n1 - Sim, gostaria de abrir um chamado!\n2 - Não, não será necessário abrir um chamado';

  constructor(
    readonly fb: FormBuilder,
    readonly usuarioService: UsuarioService,
    readonly router: Router
  ) {
    this.enviarMensagemForm = this.fb.group({
      mensagem: [''],
    });
  }

  ngOnInit() {
    this.adicionarMensagem(
      `Olá ${this.usuarioNome}! sou o TecnBot, que pena que está com problemas :( 
      mas estou aqui para te ajudar! Onde está o problema?
      \n1 - Software (aplicativos/programas)\n2 - Hardware (componentes físicos)\n3 - Rede (Internet)`,
      'bot'
    );
  }

  onSubmit() {
    const mensagem = this.enviarMensagemForm.value.mensagem.trim();
    if (!mensagem) return;

    this.adicionarMensagem(mensagem, 'usuario');
    const resposta = this.retornaRespostaBot(mensagem);
    this.adicionarMensagem(resposta, 'bot');

    this.enviarMensagemForm.reset();
    setTimeout(() => this.scrollToBottom(), 100);
  }

  adicionarMensagem(texto: string, remetente: 'bot' | 'usuario') {
    this.conversas.push({ texto, remetente, dataHora: new Date() });
  }

  private scrollToBottom(): void {
    try {
      this.scrollContainer.nativeElement.scrollTop =
        this.scrollContainer.nativeElement.scrollHeight;
    } catch {}
  }

  retornaRespostaBot(opcaoUsuario: string): string {
    const op = opcaoUsuario.trim();

    switch (this.estadoChat) {
      case 'inicio':
        if (op === '1') {
          this.estadoChat = 'sub_Software';
          return `O seu problema está relacionado a algum Software ❓
1 - Aplicativo externo não está abrindo
2 - Lentidão e travamentos frequentes
3 - Mensagem de erro desconhecida
4 - Programa pedindo senha/código
5 - Como cadastrar novo usuário
6 - Não encontrei meu problema`;
        } else if (op === '2') {
          this.estadoChat = 'sub_Hardware';
          return `O seu problema está relacionado a Hardware ❓
1 - Teclado/mouse
2 - Monitor sem imagem
3 - Impressora não imprime
4 - Falhas no som
5 - Superaquecimento
6 - Não encontrei meu problema`;
        } else if (op === '3') {
          this.estadoChat = 'sub_Rede';
          return `O seu problema está relacionado à Rede ❓
1 - Sem conexão
2 - Conexão instável
3 - Acesso negado a sites
4 - Internet lenta
5 - Ícone de rede sumiu
6 - Não encontrei meu problema`;
        } else {
          return 'Opção inválida! Digite 1, 2 ou 3.';
        }

      case 'sub_Software':
        if (['1', '2', '3', '4', '5'].includes(op)) {
          this.estadoChat = 'final';
          return this.mensagemFinal;
        } else if (op === '6') {
          this.estadoChat = 'confirma_chamado';
          return `Certo, então seu problema não está na lista. Deseja abrir um chamado?\n1 - Sim\n2 - Não`;
        } else return 'Opção inválida!';

      case 'sub_Hardware':
        if (['1', '2', '3', '4', '5'].includes(op)) {
          this.estadoChat = 'final';
          return this.mensagemFinal;
        } else if (op === '6') {
          this.estadoChat = 'confirma_chamado';
          return `Certo, então seu problema não está na lista. Deseja abrir um chamado?\n1 - Sim\n2 - Não`;
        } else return 'Opção inválida!';

      case 'sub_Rede':
        if (['1', '2', '3', '4', '5'].includes(op)) {
          this.estadoChat = 'final';
          return this.mensagemFinal;
        } else if (op === '6') {
          this.estadoChat = 'confirma_chamado';
          return `Certo, então seu problema não está na lista. Deseja abrir um chamado?\n1 - Sim\n2 - Não`;
        } else return 'Opção inválida!';

      case 'confirma_chamado':
        if (op === '1') {
          this.adicionarMensagem('Abrindo um chamado...', 'bot');

          setTimeout(() => {
            this.router.navigate(['/app/open-chamado']);
          }, 1000);
          return '';
        } else if (op === '2') {
          this.adicionarMensagem('Tudo bem. Se precisar, estou aqui!', 'bot');

          setTimeout(() => {
            this.router.navigate(['/app/home']);
          }, 2000);
          return '';
        } else return 'Opção inválida! Digite 1 ou 2.';

      case 'final':
        if (op === '1') {
          this.adicionarMensagem('Abrindo um chamado...', 'bot');

          setTimeout(() => {
            this.router.navigate(['/app/open-chamado']);
          }, 1000);

          return '';
        } else if (op === '2') {
          this.adicionarMensagem('Tudo bem, tenha um ótimo dia!', 'bot');

          setTimeout(() => {
            this.router.navigate(['/app/home']);
          }, 2000);
          return '';
        } else {
          return 'Não entendi, poderia tentar novamente?';
        }

      default:
        return 'Desculpe, não entendi.';
    }
  }
}
