namespace Precificador.App
{
    partial class FrmMenu
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
            this.btnProdutos = new System.Windows.Forms.Button();
            this.btnColecoes = new System.Windows.Forms.Button();
            this.btnInsumos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProdutos
            // 
            this.btnProdutos.Location = new System.Drawing.Point(93, 12);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(75, 75);
            this.btnProdutos.TabIndex = 0;
            this.btnProdutos.Text = "Produtos";
            this.btnProdutos.UseVisualStyleBackColor = true;
            this.btnProdutos.Click += new System.EventHandler(this.btnProdutos_Click);
            // 
            // btnColecoes
            // 
            this.btnColecoes.Location = new System.Drawing.Point(174, 12);
            this.btnColecoes.Name = "btnColecoes";
            this.btnColecoes.Size = new System.Drawing.Size(75, 75);
            this.btnColecoes.TabIndex = 1;
            this.btnColecoes.Text = "Coleções";
            this.btnColecoes.UseVisualStyleBackColor = true;
            this.btnColecoes.Click += new System.EventHandler(this.btnColecoes_Click);
            // 
            // btnInsumos
            // 
            this.btnInsumos.Location = new System.Drawing.Point(12, 12);
            this.btnInsumos.Name = "btnInsumos";
            this.btnInsumos.Size = new System.Drawing.Size(75, 75);
            this.btnInsumos.TabIndex = 2;
            this.btnInsumos.Text = "Insumos";
            this.btnInsumos.UseVisualStyleBackColor = true;
            this.btnInsumos.Click += new System.EventHandler(this.btnInsumos_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 102);
            this.Controls.Add(this.btnInsumos);
            this.Controls.Add(this.btnColecoes);
            this.Controls.Add(this.btnProdutos);
            this.Name = "FrmMenu";
            this.Text = "Precificador";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProdutos;
        private System.Windows.Forms.Button btnColecoes;
        private System.Windows.Forms.Button btnInsumos;
    }
}