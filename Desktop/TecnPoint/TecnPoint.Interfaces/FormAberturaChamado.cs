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
using TecnPoint.Modelos.DTO;
using TecnPoint.Modelos.Enum;
using TecnPoint.Services;

namespace TecnPoint.Interfaces
{
    public partial class FormAberturaChamado : Form
    {
        private ChamadoService chamadoService;
        private Usuario usuarioLogado;

        public FormAberturaChamado(Usuario usuarioLogado)
        {
            this.chamadoService = new ChamadoService();
            this.usuarioLogado = usuarioLogado;
            InitializeComponent();
            cbxPrioridade.SelectedIndex = 0;
            cbxJornada.SelectedIndex = 0;
            cbxModulo.SelectedIndex = 0;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidaDadosChamado(txtTitulo, txtDescricao, cbxPrioridade, cbxJornada, cbxModulo)){

                PrioridadeChamado prioridadeChamado = ConverterPrioridadeParaEnum(cbxPrioridade.SelectedIndex);

                // método para abrir o chamado
                AberturaChamadoDTO aberturaChamadoDTO = new AberturaChamadoDTO(txtTitulo.Text, 
                                                                                txtDescricao.Text, 
                                                                                prioridadeChamado, 
                                                                                usuarioLogado.id_usuario, 
                                                                                cbxModulo.SelectedIndex, 
                                                                                cbxJornada.SelectedIndex);
                var chamado = chamadoService.AbrirChamado(aberturaChamadoDTO);
                if (chamado != null)
                {
                    MessageBox.Show("Chamado aberto com sucesso!",
                                    "TechSolutions",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Não foi possível abrir o chamado",
                                    "TechSolutions",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidaDadosChamado(TextBox Titulo, TextBox Descricao, ComboBox Prioridade, ComboBox Jornada, ComboBox Modulo)
        {
            if(string.IsNullOrWhiteSpace(Titulo.Text)) return false;
            if(string.IsNullOrWhiteSpace(Descricao.Text)) return false;
            if(Prioridade.SelectedIndex < 1) return false;
            if (Jornada.SelectedIndex < 1) return false;
            if (Modulo.SelectedIndex < 1) return false;
            return true;
        }

        private PrioridadeChamado ConverterPrioridadeParaEnum(int selectedIndex)
        {
            if (selectedIndex == 1) return PrioridadeChamado.BAIXA;
            if (selectedIndex == 2) return PrioridadeChamado.MEDIA;
            if (selectedIndex == 3) return PrioridadeChamado.ALTA;
            return PrioridadeChamado.BAIXA;
        }
    }
}
