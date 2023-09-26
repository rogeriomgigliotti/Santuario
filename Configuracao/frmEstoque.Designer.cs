namespace Configuracao
{
    partial class frmEstoque
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbProduto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEvento = new System.Windows.Forms.Button();
            this.lblEvento = new System.Windows.Forms.Label();
            this.cmbTipoMovimento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvEstoque = new System.Windows.Forms.DataGridView();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoque)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Produto:";
            // 
            // cmbProduto
            // 
            this.cmbProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduto.FormattingEnabled = true;
            this.cmbProduto.Location = new System.Drawing.Point(11, 77);
            this.cmbProduto.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProduto.Name = "cmbProduto";
            this.cmbProduto.Size = new System.Drawing.Size(224, 21);
            this.cmbProduto.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Quantidade:";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(349, 78);
            this.txtQuantidade.Margin = new System.Windows.Forms.Padding(2);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(105, 20);
            this.txtQuantidade.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.btnEvento);
            this.panel2.Controls.Add(this.lblEvento);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(727, 49);
            this.panel2.TabIndex = 0;
            // 
            // btnEvento
            // 
            this.btnEvento.Image = global::Configuracao.Properties.Resources.search;
            this.btnEvento.Location = new System.Drawing.Point(8, 9);
            this.btnEvento.Name = "btnEvento";
            this.btnEvento.Size = new System.Drawing.Size(30, 31);
            this.btnEvento.TabIndex = 0;
            this.btnEvento.UseVisualStyleBackColor = true;
            this.btnEvento.Click += new System.EventHandler(this.btnEvento_Click);
            // 
            // lblEvento
            // 
            this.lblEvento.AutoSize = true;
            this.lblEvento.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvento.Location = new System.Drawing.Point(43, 9);
            this.lblEvento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEvento.Name = "lblEvento";
            this.lblEvento.Size = new System.Drawing.Size(135, 31);
            this.lblEvento.TabIndex = 1;
            this.lblEvento.Text = "lblEvento";
            // 
            // cmbTipoMovimento
            // 
            this.cmbTipoMovimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoMovimento.FormattingEnabled = true;
            this.cmbTipoMovimento.Location = new System.Drawing.Point(239, 77);
            this.cmbTipoMovimento.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTipoMovimento.Name = "cmbTipoMovimento";
            this.cmbTipoMovimento.Size = new System.Drawing.Size(106, 21);
            this.cmbTipoMovimento.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Movimento:";
            // 
            // dgvEstoque
            // 
            this.dgvEstoque.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEstoque.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstoque.Location = new System.Drawing.Point(11, 108);
            this.dgvEstoque.Margin = new System.Windows.Forms.Padding(2);
            this.dgvEstoque.Name = "dgvEstoque";
            this.dgvEstoque.RowTemplate.Height = 28;
            this.dgvEstoque.Size = new System.Drawing.Size(705, 342);
            this.dgvEstoque.TabIndex = 8;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.Image = global::Configuracao.Properties.Resources.check;
            this.btnConfirmar.Location = new System.Drawing.Point(598, 70);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(118, 34);
            this.btnConfirmar.TabIndex = 7;
            this.btnConfirmar.Text = "Confirmar (F10)";
            this.btnConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 461);
            this.Controls.Add(this.dgvEstoque);
            this.Controls.Add(this.cmbTipoMovimento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbProduto);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmEstoque";
            this.Text = "Movimentos de Estoque";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmEstoque_KeyUp);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbProduto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbTipoMovimento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvEstoque;
        private System.Windows.Forms.Button btnEvento;
        private System.Windows.Forms.Label lblEvento;
    }
}