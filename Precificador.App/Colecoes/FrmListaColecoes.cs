using Precificador.Core.Domain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Precificador.App.Colecoes
{
    public partial class FrmListaColecoes : Form
    {
        private string filtroColecao = string.Empty;
        private int filtroAnoLancamento = 0;

        public FrmListaColecoes()
        {
            InitializeComponent();
        }

        #region Eventos

        private void FrmListaColecoes_Load(object sender, EventArgs e)
        {
            CarregarFiltros();
        }

        private void txtColecao_TextChanged(object sender, EventArgs e)
        {
            CarregarFiltros();
        }

        private void cmbAnoLancamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarFiltros();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarColecoes();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparFiltros();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        private void CarregarFiltros()
        {
            filtroColecao = txtColecao.Text;
            int.TryParse(cmbAnoLancamento.SelectedValue.ToString(), out filtroAnoLancamento);
            CarregarColecoes();
        }

        private void CarregarColecoes()
        {
            List<Colecao> colecoes = Colecao.Listar(filtroColecao, filtroAnoLancamento);
            dgvColecoes.DataSource = colecoes;
        }

        private void LimparFiltros()
        {
            txtColecao.Text = string.Empty;
            cmbAnoLancamento.SelectedIndex = 0;
            CarregarFiltros();
        }
    }
}