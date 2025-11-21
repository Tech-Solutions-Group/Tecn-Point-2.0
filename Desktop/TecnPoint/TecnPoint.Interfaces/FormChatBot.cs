using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnPoint.Modelos;
using TecnPoint.Interfaces.Utils;
using TecnPoint.Modelos.DTO;

namespace TecnPoint.Interfaces
{
    public partial class FormChatBot : Form
    {
        private FrmMDIPrincipal frmMDIPrincipal;
        private UsuarioLogadoDTO _usuarioLogado;
        private bool _modoDaltonico;
        private MensagensChatBot _mensagens;

        public FormChatBot(bool modoDaltonico, FrmMDIPrincipal frmMDIPrincipal, UsuarioLogadoDTO usuarioLogado)
        {
            this.frmMDIPrincipal = frmMDIPrincipal;
            this._usuarioLogado = usuarioLogado;
            this._modoDaltonico = modoDaltonico;
            this._mensagens = new MensagensChatBot();
            InitializeComponent();
            ModoDaltonismo();
        }

        private string MensagemFinal = $"Espero que eu tenha resolvido o seu problema" +
                        "\nGostaria de abrir um chamado?" +
                        "\n1 - Sim, gostaria de abrir um chamado!\n2 - Não, não será necessário abrir um chamado";
        private string estadoChat = "inicio";

        private string RetornaRespostaBot(string opcaoUsuario)
        {
            switch (estadoChat)
            {

                case "inicio":

                    if (opcaoUsuario == "1")
                    {
                        //faz o chat começar lá embaixo, quando o txtMensagemUsuario está definido como subopções_Software
                        estadoChat = "sub_Software";
                        return _mensagens.SubSoftware();
                    }
                    else if (opcaoUsuario == "2")
                    {
                        //faz o chat começar lá embaixo, quando o estado está definido como subopções de hardware
                        estadoChat = "sub_Hardware";
                        return _mensagens.SubHardware();
                    }
                    else if (opcaoUsuario == "3")
                    {
                        //também faz o chat começar lá embaixo nas subopções de redes
                        estadoChat = "sub_Rede";
                        return _mensagens.SubRede();
                    }
                    else
                    {
                        return "Opção inválida! Insira uma das respostas acima";
                    }

                case "sub_Software":
                    if (opcaoUsuario == "1")
                    {
                        estadoChat = "final";
                        AdicionaMensagem(_mensagens.Opcao1Software());
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "2")
                    {
                        estadoChat = "final";
                        AdicionaMensagem(_mensagens.Opcao2Software());
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "3")
                    {
                        estadoChat = "final";
                        AdicionaMensagem(_mensagens.Opcao3Software());
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "4")
                    {
                        estadoChat = "final";
                        AdicionaMensagem(_mensagens.Opcao4Software());
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "5")
                    {
                        estadoChat = "final";
                        AdicionaMensagem(_mensagens.Opcao5Software());
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "6")
                    {
                        estadoChat = "confirma_chamado";
                        return _mensagens.ProblemaNaoEncontrado();
                    }
                    else
                    {
                        return "Opção inválida! Insira uma das respostas acima";
                    }
                case "sub_Hardware":
                    if (opcaoUsuario == "1")
                    {
                        estadoChat = "final";
                        AdicionaMensagem(_mensagens.Opcao1Hardware());
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "2")
                    {
                        estadoChat = "final";
                        AdicionaMensagem(_mensagens.Opcao2Hardware());
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "3")
                    {
                        estadoChat = "final";
                        AdicionaMensagem(_mensagens.Opcao3Hardware());
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "4")
                    {
                        estadoChat = "final";
                        AdicionaMensagem(_mensagens.Opcao4Hardware());
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "5")
                    {
                        estadoChat = "final";
                        AdicionaMensagem(_mensagens.Opcao5Hardware());
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "6")
                    {
                        estadoChat = "confirma_chamado";
                        return _mensagens.ProblemaNaoEncontrado();
                    }
                    else
                    {
                        return "Opção inválida! Insira uma das respostas acima";
                    }
                case "sub_Rede":
                    if (opcaoUsuario == "1")
                    {
                        estadoChat = "final";
                        AdicionaMensagem(_mensagens.Opcao1Rede());
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "2")
                    {
                        estadoChat = "final";
                        AdicionaMensagem(_mensagens.Opcao2Rede());
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "3")
                    {
                        estadoChat = "final";
                        AdicionaMensagem(_mensagens.Opcao3Rede());
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "4")
                    {
                        estadoChat = "final";
                        AdicionaMensagem(_mensagens.Opcao4Rede());
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "5")
                    {
                        estadoChat = "final";
                        AdicionaMensagem(_mensagens.Opcao5Rede());
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "6")
                    {
                        estadoChat = "confirma_chamado";
                        return _mensagens.ProblemaNaoEncontrado();
                    }
                    else
                    {
                        return "Opção inválida! Insira uma das respostas acima";
                    }
                case "confirma_chamado":
                    if (opcaoUsuario == "1")
                    {
                        frmMDIPrincipal.CarregaAberturaChamado();
                        return "Chamado aberto com sucesso.";
                    }
                    else if (opcaoUsuario == "2")
                    {
                        frmMDIPrincipal.CarregaFormLogo();
                        return "Chamado fechado";
                    }
                    else
                    {
                        return "Opção inválida. Deseja abrir um chamado?" +
                            "\n1 - Sim, gostaria de abrir um chamado!\n2 - Não, não será necessário abrir um chamado";
                    }
                case "final":
                    if (opcaoUsuario == "1")
                    {
                        frmMDIPrincipal.CarregaAberturaChamado();
                    }
                    else if (opcaoUsuario == "2")
                    {
                        frmMDIPrincipal.CarregaFormLogo();
                    }
                    else
                    {
                        estadoChat = "final";
                        return "Não entendi, poderia tentar novamente?";
                    }
                    return "Tenha um ótimo dia.";
                default:
                    return "default";
            }
        }

        //Método para exibir as mensagens no FlowLayoutPanel (apenas)
        private void AdicionaMensagem(string mensagem)
        {
            Panel mensagemNoPanel = new Panel()
            {
                BackColor = _modoDaltonico ? Color.FromArgb(171, 126, 105) : Color.FromArgb(167, 112, 197),
                AutoSize = true,
                Margin = new Padding(5),
                Padding = new Padding(10),
                MaximumSize = new Size(flpConversaChatBot.Width - 10, 0),
            };

            Label lblMensagem = new Label()
            {
                Text = $"{mensagem}",
                AutoSize = true,
                Font = new Font("Consolas", 11),
            };

            mensagemNoPanel.Controls.Add(lblMensagem);
            flpConversaChatBot.Controls.Add(mensagemNoPanel);

            flpConversaChatBot.ScrollControlIntoView(mensagemNoPanel);
        }

        private void ModoDaltonismo()
        {
            if (_modoDaltonico)
            {
                pnlCabecalhoChatBot.BackgroundImage = Interfaces.Properties.Resources.TelaInicioDaltonico1;
                btnEnviar.BackgroundImage = Interfaces.Properties.Resources.IconEnviarDaltonico;
            }
            else
            {
                pnlCabecalhoChatBot.BackgroundImage = Interfaces.Properties.Resources.TelaFundo;
                btnEnviar.BackgroundImage = Interfaces.Properties.Resources.IconEnviar;
            }
        }

        private void FormChatBot_Load(object sender, EventArgs e)
        {
            AdicionaMensagem($"Olá {_usuarioLogado.nome} ! sou o TecnBot, que pena que está com problemas :(\nmas estou aqui para te ajudar! Onde está o problema? " +
                           "\n\t1 - Software (aplicativos/programas)\n\t2 - Hardware (componentes físicos)\n\t3 - Rede");
            AjustarLayoutDinamico();
            CentralizarElementosChatBot();
        }

        private void lblAtalho_Click(object sender, EventArgs e)
        {

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            AdicionaMensagem(txtMensagemUsuario.Text);
            string respostaBot = RetornaRespostaBot(txtMensagemUsuario.Text);
            AdicionaMensagem(respostaBot);
            txtMensagemUsuario.Clear();
        }

        private void CentralizarElementosChatBot()
        {
            // Pega o centro horizontal do formulário
            int centroHorizontal = this.ClientSize.Width / 2;

            // Larguras dos elementos
            int larguraTxt = txtMensagemUsuario.Width;
            int larguraBtn = btnEnviar.Width;
            int espacoEntre = 10;
            int larguraTotal = larguraTxt + espacoEntre + larguraBtn;

            // Calcula a posição inicial (esquerda) para centralizar tudo
            int posicaoInicial = centroHorizontal - (larguraTotal / 2);

            // Centraliza os elementos na horizontal
            txtMensagemUsuario.Left = posicaoInicial;
            btnEnviar.Left = txtMensagemUsuario.Right + espacoEntre;

            // Ajusta o label "Enviar" logo abaixo do botão
            lblAtalho.Left = btnEnviar.Left + (btnEnviar.Width / 2) - (lblAtalho.Width / 2);
            lblAtalho.Top = btnEnviar.Bottom + 5;

            // Centraliza verticalmente o bloco inferior (textbox + botão) a uma distância do fundo
            int margemInferior = 30;
            int alturaTotal = btnEnviar.Height + lblAtalho.Height + margemInferior;
            int posicaoTop = this.ClientSize.Height - alturaTotal;

            txtMensagemUsuario.Top = posicaoTop;
            btnEnviar.Top = posicaoTop;
            lblAtalho.Top = btnEnviar.Bottom + 5;

            // Ajusta o FlowLayoutPanel para ocupar o restante da tela acima dos controles
            flpConversaChatBot.Top = pnlCabecalhoChatBot.Bottom;
            flpConversaChatBot.Height = txtMensagemUsuario.Top - flpConversaChatBot.Top - 10;
            flpConversaChatBot.Width = this.ClientSize.Width;
        }

        private void AjustarLayoutDinamico()
        {
            // Cabeçalho ocupa o topo inteiro
            pnlCabecalhoChatBot.Dock = DockStyle.Top;
            pnlCabecalhoChatBot.Height = 96;

            // Área de conversa ocupa o espaço entre o cabeçalho e a barra inferior
            flpConversaChatBot.Dock = DockStyle.Fill;
            flpConversaChatBot.WrapContents = false;
            flpConversaChatBot.AutoScroll = true;

            // O botão e o textbox ficam posicionados fixos na parte inferior
            txtMensagemUsuario.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnEnviar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblAtalho.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void FormChatBot_Resize(object sender, EventArgs e)
        {
            CentralizarElementosChatBot();
        }
    }
}
