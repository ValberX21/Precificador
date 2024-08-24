namespace Precificador.App.Produtos
{
    partial class FrmListaProdutos
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
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.cmbColecao = new System.Windows.Forms.ComboBox();
            this.lblColecao = new System.Windows.Forms.Label();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Location = new System.Drawing.Point(12, 68);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.Size = new System.Drawing.Size(595, 150);
            this.dgvProdutos.TabIndex = 0;
            // 
            // cmbColecao
            // 
            this.cmbColecao.FormattingEnabled = true;
            this.cmbColecao.Location = new System.Drawing.Point(12, 41);
            this.cmbColecao.Name = "cmbColecao";
            this.cmbColecao.Size = new System.Drawing.Size(180, 21);
            this.cmbColecao.TabIndex = 1;
            this.cmbColecao.SelectedIndexChanged += new System.EventHandler(this.cmbColecao_SelectedIndexChanged);
            // 
            // lblColecao
            // 
            this.lblColecao.AutoSize = true;
            this.lblColecao.Location = new System.Drawing.Point(13, 22);
            this.lblColecao.Name = "lblColecao";
            this.lblColecao.Size = new System.Drawing.Size(46, 13);
            this.lblColecao.TabIndex = 2;
            this.lblColecao.Text = "Coleção";
            // 
            // txtProduto
            // 
            this.txtProduto.Location = new System.Drawing.Point(198, 42);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(180, 20);
            this.txtProduto.TabIndex = 3;
            this.txtProduto.TextChanged += new System.EventHandler(this.txtProduto_TextChanged);
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(195, 22);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(44, 13);
            this.lblProduto.TabIndex = 4;
            this.lblProduto.Text = "Produto";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(401, 39);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 23);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(507, 39);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(100, 23);
            this.btnLimpar.TabIndex = 6;
            this.btnLimpar.Text = "Remover Filtros";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // FrmListaProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 230);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.txtProduto);
            this.Controls.Add(this.lblColecao);
            this.Controls.Add(this.cmbColecao);
            this.Controls.Add(this.dgvProdutos);
            this.Name = "FrmListaProdutos";
            this.Text = "Produtos";
            this.Load += new System.EventHandler(this.FrmListaProdutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.ComboBox cmbColecao;
        private System.Windows.Forms.Label lblColecao;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpar;
    }
}