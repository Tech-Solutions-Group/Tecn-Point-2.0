using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnPoint.Interfaces.Utils
{
    public class MensagensChatBot
    {
        public string SubSoftware()
        {
            return "O seu problema está relacionado a algum Software ❓ \nUm programa não abre \nUm programa está travando ❓" +
                            "\n\nSelecione uma das opções abaixo para eu tentar te ajudar..." +
                            "\n1 - Aplicativo externo não está abrindo" +
                            "\n2 - Lentidão e travamentos frequentes do sistema ou aplicativos" +
                            "\n3 - Aparece uma mensagem de erro e você não sabe o que é" +
                            "\n4 - Um programa externo pede uma senha ou código que você não tem" +
                            "\n5 - Como cadastrar um novo usuário" +
                            "\n6 - Não encontrei meu problema";
        }

        public string Opcao1Software()
        {
            return "1 - Aplicativo externo não está abrindo." +
                            "\n• Tente reiniciar o computador e abrir o programa novamente. " +
                            "\nSe o problema continuar, pode ser necessário atualizar o computador ou consultar " +
                            "\no suporte.";
        }

        public string Opcao2Software()
        {
            return "2 - Lentidão e travamentos frequentes do sistema ou aplicativos." +
                            "\n• Reiniciar o programa ou o computador para eliminar erros temporários.";
        }

        public string Opcao3Software()
        {
            return "3 - Aparece uma mensagem de erro e você não sabe o que é" +
                            "\n• Reiniciar o aplicativo e, se necessário, o computador." +
                            "\n• Desinstalar e reinstalar o aplicativo para corrigir arquivos corrompidos." +
                            "\n• Se o erro continuar, informe a mensagem para o suporte técnico.";
        }

        public string Opcao4Software()
        {
            return "4 - O programa pede uma senha ou código que você não tem" +
                            "\n• Verifique com o responsável pelo sistema ou setor de TI se você tem " +
                            "\nacesso autorizado." +
                            "\nSe for um programa novo, peça que enviem a senha ou licença correta.";
        }

        public string Opcao5Software()
        {
            return "5 - Como cadastrar um novo usuário ❓" +
                            "\n• Para cadastrar um novo usuário, por favor encaminhar um chamado para o " +
                            "\nsuporte com os seguintes dados: nome, e-mail, senha padrão, tipo do usuário.";
        }

        public string SubHardware()
        {
            return "O seu problema está relacionado a Hardware??\nUm componente está apresentando falhas ❓" +
                            "\n\nSelecione uma das opções abaixo para eu tentar te ajudar..." +
                            "\n1 - Problemas com teclado/mouse" +
                            "\n2 - Monitor sem imagem" +
                            "\n3 - Impressora não está imprimindo" +
                            "\n4 - Falhas no som (alto-falante/fone)" +
                            "\n5 - Superaquecimento do computador" +
                            "\n6 - Não encontrei meu problema";
        }

        public string Opcao1Hardware()
        {
            return "1 - Teclado ou mouse não funcionam" +
                            "\n• Desconecte e conecte novamente. Tente trocar de porta USB. " +
                            "\nSe for sem fio, verifique a bateria.";
        }

        public string Opcao2Hardware()
        {
            return "2 - Monitor sem imagem" +
                            "\n• Verifique se o cabo de vídeo (HDMI) está bem conectado e se o monitor está ligado. " +
                            "\nCaso o problema continuar, desligue e ligue o computador.";
        }

        public string Opcao3Hardware()
        {
            return "3 - Impressora não está imprimindo" +
                            "\n• Verifique se a impressora está conectada corretamente e ligada. " +
                            "\nConfira também se há papel e tinta/cartucho.";
        }

        public string Opcao4Hardware()
        {
            return "4 - Falhas no som (alto-falante/fone)" +
                            "\n• Veja se o volume está ativado e se o dispositivo correto está selecionado " +
                            "\n(clique no ícone de som no canto inferior direito >> seta para cima >> selecione " +
                            "\no dispositvo). Teste com outro fone ou alto-falante.";
        }

        public string Opcao5Hardware()
        {
            return "5 - Superaquecimento do computador" +
                            "\n• Verifique se a ventoinha que se localiza na parte de trás do gabinete " +
                            "\n(caixa do computador) está funcionando. Caso não esteja funcionando (girando), " +
                            "\nabra um chamado para o suporte.";
        }

        public string SubRede()
        {
            return "O seu problema está relacionado à Rede??\nA sua internet está lenta ❓" +
                            "\n\nSelecione uma das opções abaixo para eu tentar te ajudar..." +
                            "\n1 - Sem conexão com a internet" +
                            "\n2 - Conexão instável (cai toda hora)" +
                            "\n3 - Acesso negado a sites específicos" +
                            "\n4 - Internet muito lenta" +
                            "\n5 - Ícone de rede não aparece no computador" +
                            "\n6 - Não encontrei meu problema";
        }

        public string Opcao1Rede()
        {
            return "1 - Sem conexão com a internet" +
                            "\n• Tente se reconectar à rede Wi-Fi ou conectar o cabo de rede (cabo azul com a " +
                            "\nponta transparente) no computador novamente.";
        }

        public string Opcao2Rede()
        {
            return "2 - Conexão instável (cai toda hora)" +
                            "\n• Pode ser interferência ou sinal fraco. Tente se aproximar do roteador ou reconectar " +
                            "\no cabo de rede se possível.";
        }

        public string Opcao3Rede()
        {
            return "3 - Acesso negado a sites específicos" +
                            "\n• Teste o acesso com outro navegador ou dispositivo. Se o problema persistir, " +
                            "\nverifique se há restrições no antivírus ou na rede com um suporte";
        }

        public string Opcao4Rede()
        {
            return "4 - Internet muito lenta" +
                            "\n• Desconecte os dispositivos que não estão em uso. Se o problema persistir, " +
                            "\ncontate um suporte";
        }

        public string Opcao5Rede()
        {
            return "5 - Ícone de rede não aparece no computador" +
                            "\n• Verifique se o Wi-Fi está ativado no seu dispositivo. Se estiver, tente reiniciar " +
                            "\no computador. Caso esteja usando conexão cabeada, desconecte e reconecte o cabo " +
                            "\nde rede com cuidado para garantir um bom encaixe. Se o problema persistir contate " +
                            "\no suporte.";
        }


        public string ProblemaNaoEncontrado()
        {
            return "6 - Não encontrei meu problema" +
                               "\nCerto, então seu problema não está na lista acima." +
                               "\nDeseja abrir um chamado?" +
                               "\n1 - Sim, gostaria de abrir um chamado!\n2 - Não, não será necessário abrir um chamado";
        }
    }
}
