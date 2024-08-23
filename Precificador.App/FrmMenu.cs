using Precificador.App.Produtos;
using System;

using System.Windows.Forms;

namespace Precificador.App
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnInsumos_Click(object sender, EventArgs e)
        {
            //TODO: Abrir Lista de Insumos
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            var form = new FrmListaProdutos();
            form.ShowDialog();
        }

        private void btnColecoes_Click(object sender, EventArgs e)
        {
            //TODO: Abrir Lista de Coleções
        }
    }
}
