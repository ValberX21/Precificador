using Precificador.Core.Domain;

using System;
using System.Windows.Forms;

namespace Precificador.App.Colecoes
{
    public partial class FrmDetalheColecao : Form
    {
        /// <summary>
        /// Id da Coleção, caso seja Consulta ou Edição
        /// </summary>
        public int IdColecao { get; set; }

        /// <summary>
        /// Habilita ou desabilita componentes
        /// </summary>
        public bool ModoEdicao { get; set; }

        public FrmDetalheColecao()
        {
            InitializeComponent();
            ModoEdicao = true;
        }

        public FrmDetalheColecao(int idColecao, bool modoEdicao)
        {
            InitializeComponent();
            IdColecao = idColecao;
            ModoEdicao = modoEdicao;
        }

        private void FrmDetalheColecao_Load(object sender, EventArgs e)
        {
            if (IdColecao > 0)
            {
                var colecao = CarregaDadosColecao(IdColecao);
                PreencherTela(colecao);
            }

            HabilitaDesabilitaComponentes(ModoEdicao);
        }

        private void PreencherTela(Colecao colecao)
        {
            txtColecao.Text = colecao.Nome;
            dtpDataLancamento.Value = colecao.DataLancamento;
        }

        private void HabilitaDesabilitaComponentes(bool modoEdicao)
        {
            txtColecao.Enabled = modoEdicao;
            dtpDataLancamento.Enabled = modoEdicao;
            btnSalvar.Visible = modoEdicao;
            btnLimpar.Visible = modoEdicao;
            btnCancelar.Visible = modoEdicao;
            btnEditar.Visible = !modoEdicao;
            btnExcluir.Visible = !modoEdicao;
            btnFechar.Visible = !modoEdicao;
        }

        private Colecao CarregaDadosColecao(int idColecao)
        {
            return Colecao.Consultar(idColecao);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ModoEdicao = true;
            HabilitaDesabilitaComponentes(ModoEdicao);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //TODO: Mensagem Confirmação
            Colecao.Excluir(IdColecao);
            //TODO: Mensagem Confirmação
            Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtColecao.Text = string.Empty;
            dtpDataLancamento.Value = DateTime.Now;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Colecao colecao = BaixarDados();
            ValidarDados(colecao);
            Colecao.Salvar(colecao);
        }

        private void ValidarDados(Colecao colecao)
        {
            try
            {
                colecao.Validar();
            }
            catch (Exception ex)
            {
                //TODO: Mensagem de erro
                //MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private Colecao BaixarDados()
        {
            Colecao colecao = new Colecao();

            if (IdColecao > 0)
            {
                colecao.Id = IdColecao;
            }

            colecao.Nome = txtColecao.Name;
            colecao.DataLancamento = dtpDataLancamento.Value;
            return colecao;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ModoEdicao = false;
            HabilitaDesabilitaComponentes(ModoEdicao);
            CarregaDadosColecao(IdColecao);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}