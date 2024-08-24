using Precificador.Core.Domain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Precificador.App.Produtos
{
    public partial class FrmListaProdutos : Form
    {
        private int filtroColecao = 0;
        private string filtroProduto = string.Empty;

        public FrmListaProdutos()
        {
            InitializeComponent();
        }

        #region Eventos

        private void FrmListaProdutos_Load(object sender, EventArgs e)
        {
            CarregarFiltros();
        }

        private void cmbColecao_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarFiltros();
        }

        private void txtProduto_TextChanged(object sender, EventArgs e)
        {
            CarregarFiltros();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarProdutos();
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
            filtroColecao = cmbColecao.SelectedIndex;
            filtroProduto = txtProduto.Text;
            CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            List<Produto> produtos = Produto.Listar(filtroColecao, filtroProduto);
            dgvProdutos.DataSource = produtos;
        }

        private void LimparFiltros()
        {
            cmbColecao.SelectedIndex = 0;
            txtProduto.Text = string.Empty;
            CarregarFiltros();
        }
    }
}