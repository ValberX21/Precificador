namespace Precificador.App.Colecoes
{
    partial class FrmListaColecoes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblAnoLancamento = new System.Windows.Forms.Label();
            this.txtColecao = new System.Windows.Forms.TextBox();
            this.lblColecao = new System.Windows.Forms.Label();
            this.dgvColecoes = new System.Windows.Forms.DataGridView();
            this.cmbAnoLancamento = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColecoes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(672, 16);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(100, 41);
            this.btnFechar.TabIndex = 15;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(566, 16);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(100, 41);
            this.btnLimpar.TabIndex = 14;
            this.btnLimpar.Text = "Remover Filtros";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(460, 16);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 41);
            this.btnBuscar.TabIndex = 13;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblAnoLancamento
            // 
            this.lblAnoLancamento.AutoSize = true;
            this.lblAnoLancamento.Location = new System.Drawing.Point(228, 16);
            this.lblAnoLancamento.Name = "lblAnoLancamento";
            this.lblAnoLancamento.Size = new System.Drawing.Size(103, 13);
            this.lblAnoLancamento.TabIndex = 12;
            this.lblAnoLancamento.Text = "Ano do Lançamento";
            // 
            // txtColecao
            // 
            this.txtColecao.Location = new System.Drawing.Point(15, 37);
            this.txtColecao.Name = "txtColecao";
            this.txtColecao.Size = new System.Drawing.Size(210, 20);
            this.txtColecao.TabIndex = 11;
            this.txtColecao.TextChanged += new System.EventHandler(this.txtColecao_TextChanged);
            // 
            // lblColecao
            // 
            this.lblColecao.AutoSize = true;
            this.lblColecao.Location = new System.Drawing.Point(12, 16);
            this.lblColecao.Name = "lblColecao";
            this.lblColecao.Size = new System.Drawing.Size(46, 13);
            this.lblColecao.TabIndex = 10;
            this.lblColecao.Text = "Coleção";
            // 
            // dgvColecoes
            // 
            this.dgvColecoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColecoes.Location = new System.Drawing.Point(12, 63);
            this.dgvColecoes.Name = "dgvColecoes";
            this.dgvColecoes.Size = new System.Drawing.Size(760, 481);
            this.dgvColecoes.TabIndex = 8;
            // 
            // cmbAnoLancamento
            // 
            this.cmbAnoLancamento.FormattingEnabled = true;
            this.cmbAnoLancamento.Location = new System.Drawing.Point(231, 36);
            this.cmbAnoLancamento.Name = "cmbAnoLancamento";
            this.cmbAnoLancamento.Size = new System.Drawing.Size(210, 21);
            this.cmbAnoLancamento.TabIndex = 9;
            this.cmbAnoLancamento.SelectedIndexChanged += new System.EventHandler(this.cmbAnoLancamento_SelectedIndexChanged);
            // 
            // FrmListaColecoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblAnoLancamento);
            this.Controls.Add(this.txtColecao);
            this.Controls.Add(this.lblColecao);
            this.Controls.Add(this.cmbAnoLancamento);
            this.Controls.Add(this.dgvColecoes);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmListaColecoes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coleções";
            this.Load += new System.EventHandler(this.FrmListaColecoes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColecoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblAnoLancamento;
        private System.Windows.Forms.TextBox txtColecao;
        private System.Windows.Forms.Label lblColecao;
        private System.Windows.Forms.DataGridView dgvColecoes;
        private System.Windows.Forms.ComboBox cmbAnoLancamento;
    }
}