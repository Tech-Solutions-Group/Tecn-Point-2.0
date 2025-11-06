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

namespace TecnPoint.Interfaces
{
    public partial class FormChatBot : Form
    {
        private FrmMDIPrincipal frmMDIPrincipal;
        private Usuario _usuarioLogado;
        private bool _modoDaltonico;

        public FormChatBot(bool modoDaltonico, FrmMDIPrincipal frmMDIPrincipal, Usuario usuarioLogado)
        {
            this.frmMDIPrincipal = frmMDIPrincipal;
            this._usuarioLogado = usuarioLogado;
            this._modoDaltonico = modoDaltonico;
            InitializeComponent();
            ModoDaltonismo();
        }

        private string MensagemFinal = $"Espero que eu tenha resolvido o seu problema" +
                        "\nGostaria de abrir um chamado?" +
                        "\n1 - Sim, gostaria de abrir um chamado!\n2 - Não, não será necessário abrir um chamado";
        private string estadoChat = "inicio";

        private void pbEnviar_Click(object sender, EventArgs e)
        {
            //adicionar usuarioLogado
            AdicionaMensagem(txtMensagemUsuario.Text);
            string respostaBot = RetornaRespostaBot(txtMensagemUsuario.Text);
            AdicionaMensagem(respostaBot);
            txtMensagemUsuario.Clear();
        }

        private string RetornaRespostaBot(string opcaoUsuario)
        {
            switch (estadoChat)
            {

                case "inicio":

                    if (opcaoUsuario == "1")
                    {
                        //faz o chat começar lá embaixo, quando o txtMensagemUsuario está definido como subopções_Software
                        estadoChat = "sub_Software";
                        return "O seu problema está relacionado a algum Software ❓ \nUm programa não abre \nUm programa está travando ❓" +
                            "\n\nSelecione uma das opções abaixo para eu tentar te ajudar..." +
                            "\n1 - Aplicativo externo não está abrindo" +
                            "\n2 - Lentidão e travamentos frequentes do sistema ou aplicativos" +
                            "\n3 - Aparece uma mensagem de erro e você não sabe o que é" +
                            "\n4 - Um programa externo pede uma senha ou código que você não tem" +
                            "\n5 - Como cadastrar um novo usuário" +
                            "\n6 - Não encontrei meu problema";
                    }
                    else if (opcaoUsuario == "2")
                    {
                        //faz o chat começar lá embaixo, quando o estado está definido como subopções de hardware
                        estadoChat = "sub_Hardware";
                        return "O seu problema está relacionado a Hardware??\nUm componente está apresentando falhas ❓" +
                            "\n\nSelecione uma das opções abaixo para eu tentar te ajudar..." +
                            "\n1 - Problemas com teclado/mouse" +
                            "\n2 - Monitor sem imagem" +
                            "\n3 - Impressora não está imprimindo" +
                            "\n4 - Falhas no som (alto-falante/fone)" +
                            "\n5 - Superaquecimento do computador" +
                            "\n6 - Não encontrei meu problema";
                    }
                    else if (opcaoUsuario == "3")
                    {
                        //também faz o chat começar lá embaixo nas subopções de redes
                        estadoChat = "sub_Rede";
                        return "O seu problema está relacionado à Rede??\nA sua internet está lenta ❓" +
                            "\n\nSelecione uma das opções abaixo para eu tentar te ajudar..." +
                            "\n1 - Sem conexão com a internet" +
                            "\n2 - Conexão instável (cai toda hora)" +
                            "\n3 - Acesso negado a sites específicos" +
                            "\n4 - Internet muito lenta" +
                            "\n5 - Ícone de rede não aparece no computador" +
                            "\n6 - Não encontrei meu problema";
                    }
                    else
                    {
                        return "Opção inválida! Insira uma das respostas acima";
                    }

                case "sub_Software":
                    if (opcaoUsuario == "1")
                    {
                        estadoChat = "final";
                        AdicionaMensagem("1 - Aplicativo externo não está abrindo." +
                            "\nTente reiniciar o computador e abrir o programa novamente. " +
                            "\nSe o problema continuar, pode ser necessário atualizar o computador ou consultar " +
                            "\no suporte.");
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "2")
                    {
                        estadoChat = "final";
                        AdicionaMensagem("2 - Lentidão e travamentos frequentes do sistema ou aplicativos." +
                            "\nReiniciar o programa ou o computador para eliminar erros temporários.");
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "3")
                    {
                        estadoChat = "final";
                        AdicionaMensagem("3 - Aparece uma mensagem de erro e você não sabe o que é" +
                            "\n• Reiniciar o aplicativo e, se necessário, o computador." +
                            "\n• Desinstalar e reinstalar o aplicativo para corrigir arquivos corrompidos." +
                            "\n• Se o erro continuar, informe a mensagem para o suporte técnico.");
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "4")
                    {
                        estadoChat = "final";
                        AdicionaMensagem("4 - O programa pede uma senha ou código que você não tem" +
                            "\n• Verifique com o responsável pelo sistema ou setor de TI se você tem " +
                            "\nacesso autorizado." +
                            "\nSe for um programa novo, peça que enviem a senha ou licença correta.");
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "5")
                    {
                        estadoChat = "final";
                        AdicionaMensagem("5 - Como cadastrar um novo usuário ❓" +
                            "\nPara cadastrar um novo usuário, por favor encaminhar um chamado para o " +
                            "\nsuporte com os seguintes dados: nome, e-mail, senha padrão, tipo do usuário.");
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "6")
                    {
                        estadoChat = "confirma_chamado";
                        return "6 - Não encontrei meu problema" +
                               "\nCerto, então seu problema não está na lista acima." +
                               "\nDeseja abrir um chamado?" +
                               "\n1 - Sim, gostaria de abrir um chamado!\n2 - Não, não será necessário abrir um chamado";
                    }
                    else
                    {
                        return "Opção inválida! Insira uma das respostas acima";
                    }
                case "sub_Hardware":
                    if (opcaoUsuario == "1")
                    {
                        estadoChat = "final";
                        AdicionaMensagem("1 - Teclado ou mouse não funcionam" +
                            "\n• Desconecte e conecte novamente. Tente trocar de porta USB. " +
                            "\nSe for sem fio, verifique a bateria.");
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "2")
                    {
                        estadoChat = "final";
                        AdicionaMensagem("2 - Monitor sem imagem" +
                            "\n• Verifique se o cabo de vídeo (HDMI) está bem conectado e se o monitor está ligado. " +
                            "\nCaso o problema continuar, desligue e ligue o computador.");
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "3")
                    {
                        estadoChat = "final";
                        AdicionaMensagem("3 - Impressora não está imprimindo" +
                            "\n• Verifique se a impressora está conectada corretamente e ligada. " +
                            "\nConfira também se há papel e tinta/cartucho.");
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "4")
                    {
                        estadoChat = "final";
                        AdicionaMensagem("4 - Falhas no som (alto-falante/fone)" +
                            "\n• Veja se o volume está ativado e se o dispositivo correto está selecionado " +
                            "\n(clique no ícone de som no canto inferior direito >> seta para cima >> selecione " +
                            "\no dispositvo). Teste com outro fone ou alto-falante.");
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "5")
                    {
                        estadoChat = "final";
                        AdicionaMensagem("5 - Superaquecimento do computador" +
                            "\n• Verifique se a ventoinha que se localiza na parte de trás do gabinete " +
                            "\n(caixa do computador) está funcionando. Caso não esteja funcionando (girando), " +
                            "\nabra um chamado para o suporte.");
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "6")
                    {
                        estadoChat = "confirma_chamado";
                        return "6 - Não encontrei meu problema" +
                               "\nCerto, então seu problema não está na lista acima." +
                               "\nDeseja abrir um chamado?" +
                               "\n1 - Sim, gostaria de abrir um chamado!\n2 - Não, não será necessário abrir um chamado";
                    }
                    else
                    {
                        return "Opção inválida! Insira uma das respostas acima";
                    }
                case "sub_Rede":
                    if (opcaoUsuario == "1")
                    {
                        estadoChat = "final";
                        AdicionaMensagem("1 - Sem conexão com a internet" +
                            "\n• Tente se reconectar à rede Wi-Fi ou conectar o cabo de rede (cabo azul com a " +
                            "\nponta transparente) no computador novamente.");
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "2")
                    {
                        estadoChat = "final";
                        AdicionaMensagem("2 - Conexão instável (cai toda hora)" +
                            "\n• Pode ser interferência ou sinal fraco. Tente se aproximar do roteador ou reconectar " +
                            "\no cabo de rede se possível.");
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "3")
                    {
                        estadoChat = "final";
                        AdicionaMensagem("3 - Acesso negado a sites específicos" +
                            "\n• Teste o acesso com outro navegador ou dispositivo. Se o problema persistir, " +
                            "\nverifique se há restrições no antivírus ou na rede com um suporte");
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "4")
                    {
                        estadoChat = "final";
                        AdicionaMensagem("4 - Internet muito lenta" +
                            "\n• Desconecte os dispositivos que não estão em uso. Se o problema persistir, " +
                            "\ncontate um suporte");
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "5")
                    {
                        estadoChat = "final";
                        AdicionaMensagem("5 - Ícone de rede não aparece no computador" +
                            "\n• Verifique se o Wi-Fi está ativado no seu dispositivo. Se estiver, tente reiniciar " +
                            "\no computador. Caso esteja usando conexão cabeada, desconecte e reconecte o cabo " +
                            "\nde rede com cuidado para garantir um bom encaixe. Se o problema persistir contate " +
                            "\no suporte.");
                        return $"{MensagemFinal}";
                    }
                    else if (opcaoUsuario == "6")
                    {
                        estadoChat = "confirma_chamado";
                        return "6 - Não encontrei meu problema" +
                               "\nCerto, então seu problema não está na lista acima." +
                               "\nDeseja abrir um chamado?" +
                               "\n1 - Sim, gostaria de abrir um chamado!\n2 - Não, não será necessário abrir um chamado";
                    }
                    else
                    {
                        return "Opção inválida! Insira uma das respostas acima";
                    }
                case "confirma_chamado":
                    if (opcaoUsuario == "1")
                    {
                        frmMDIPrincipal.tspAbrirChamado_Click(null, null);
                        this.Close();
                        return "Chamado aberto com sucesso.";
                    }
                    else if (opcaoUsuario == "2")
                    {
                        AdicionaMensagem("Tudo bem. Se precisar, estou aqui!");
                        frmMDIPrincipal.CarregaFormLogo();
                        this.Close();
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
                        //telaCliente.botaoCriarChamado_Click(null, null);
                        this.Close();
                    }
                    else if (opcaoUsuario == "2")
                    {
                        AdicionaMensagem("Tudo bem. Se precisar, estou aqui!");
                        //telaCliente.CarregarTelaInicio();
                        this.Close();
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
                pbEnviar.Image = Interfaces.Properties.Resources.IconEnviarDaltonico;
            }
            else
            {
                pnlCabecalhoChatBot.BackgroundImage = Interfaces.Properties.Resources.TelaFundo;
                pbEnviar.Image = Interfaces.Properties.Resources.IconEnviar;
            }
        }

        private void FormChatBot_Load(object sender, EventArgs e)
        {
            AdicionaMensagem($"Olá {_usuarioLogado.Nome} ! sou o TecnBot, que pena que está com problemas :(\nmas estou aqui para te ajudar! Onde está o problema? " +
                           "\n\t1 - Software (aplicativos/programas)\n\t2 - Hardware (componentes físicos)\n\t3 - Rede");
        }
    }
}
