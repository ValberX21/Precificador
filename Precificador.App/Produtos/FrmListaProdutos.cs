using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Precificador.App.Produtos
{
    public partial class FrmListaProdutos : Form
    {
        public FrmListaProdutos()
        {
            InitializeComponent();
        }

        private void FrmListaProdutos_Load(object sender, EventArgs e)
        {
            List<Produto> produtos = CarregarProdutos();

        }

        private List<Produto> CarregarProdutos()
        {
            var produto = new Produto();
            return produto.Listar();
        }
    }
}
