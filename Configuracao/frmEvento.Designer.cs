namespace Configuracao
{
    partial class frmEvento
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
            this.tbcEvento = new System.Windows.Forms.TabControl();
            this.pagLista = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvEvento = new System.Windows.Forms.DataGridView();
            this.Acao = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pagCadastro = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.DateTimePicker();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.tbcEvento.SuspendLayout();
            this.pagLista.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvento)).BeginInit();
            this.pagCadastro.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcEvento
            // 
            this.tbcEvento.Controls.Add(this.pagLista);
            this.tbcEvento.Controls.Add(this.pagCadastro);
            this.tbcEvento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcEvento.Location = new System.Drawing.Point(0, 49);
            this.tbcEvento.Margin = new System.Windows.Forms.Padding(2);
            this.tbcEvento.Name = "tbcEvento";
            this.tbcEvento.SelectedIndex = 0;
            this.tbcEvento.Size = new System.Drawing.Size(691, 335);
            this.tbcEvento.TabIndex = 1;
            // 
            // pagLista
            // 
            this.pagLista.Controls.Add(this.panel1);
            this.pagLista.Controls.Add(this.dgvEvento);
            this.pagLista.Location = new System.Drawing.Point(4, 22);
            this.pagLista.Margin = new System.Windows.Forms.Padding(2);
            this.pagLista.Name = "pagLista";
            this.pagLista.Padding = new System.Windows.Forms.Padding(2);
            this.pagLista.Size = new System.Drawing.Size(683, 309);
            this.pagLista.TabIndex = 0;
            this.pagLista.Text = "Lista";
            this.pagLista.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnNovo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 242);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 65);
            this.panel1.TabIndex = 1;
            // 
            // dgvEvento
            // 
            this.dgvEvento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEvento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Acao});
            this.dgvEvento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEvento.Location = new System.Drawing.Point(2, 2);
            this.dgvEvento.Margin = new System.Windows.Forms.Padding(2);
            this.dgvEvento.Name = "dgvEvento";
            this.dgvEvento.RowTemplate.Height = 28;
            this.dgvEvento.Size = new System.Drawing.Size(679, 305);
            this.dgvEvento.TabIndex = 0;
            this.dgvEvento.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvento_CellContentClick);
            // 
            // Acao
            // 
            this.Acao.HeaderText = "Ação";
            this.Acao.Name = "Acao";
            this.Acao.Text = "Selecionar";
            this.Acao.UseColumnTextForButtonValue = true;
            this.Acao.Width = 38;
            // 
            // pagCadastro
            // 
            this.pagCadastro.BackColor = System.Drawing.SystemColors.Control;
            this.pagCadastro.Controls.Add(this.btnExcluir);
            this.pagCadastro.Controls.Add(this.btnCancelar);
            this.pagCadastro.Controls.Add(this.btnSalvar);
            this.pagCadastro.Controls.Add(this.label3);
            this.pagCadastro.Controls.Add(this.txtData);
            this.pagCadastro.Controls.Add(this.txtNome);
            this.pagCadastro.Controls.Add(this.label2);
            this.pagCadastro.Controls.Add(this.txtCodigo);
            this.pagCadastro.Controls.Add(this.label1);
            this.pagCadastro.Location = new System.Drawing.Point(4, 22);
            this.pagCadastro.Margin = new System.Windows.Forms.Padding(2);
            this.pagCadastro.Name = "pagCadastro";
            this.pagCadastro.Padding = new System.Windows.Forms.Padding(2);
            this.pagCadastro.Size = new System.Drawing.Size(683, 309);
            this.pagCadastro.TabIndex = 1;
            this.pagCadastro.Text = "Cadastro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data:";
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(54, 81);
            this.txtData.Margin = new System.Windows.Forms.Padding(2);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(262, 20);
            this.txtData.TabIndex = 5;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(54, 52);
            this.txtNome.Margin = new System.Windows.Forms.Padding(2);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(262, 20);
            this.txtNome.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.SystemColors.Menu;
            this.txtCodigo.Location = new System.Drawing.Point(54, 22);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(65, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.lblTitulo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(691, 49);
            this.panel2.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(2, 9);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(287, 31);
            this.lblTitulo.TabIndex = 11;
            this.lblTitulo.Text = "Cadastro de Eventos";
            // 
            // btnNovo
            // 
            this.btnNovo.Image = global::Configuracao.Properties.Resources.add;
            this.btnNovo.Location = new System.Drawing.Point(14, 19);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(70, 28);
            this.btnNovo.TabIndex = 7;
            this.btnNovo.Text = "Novo";
            this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = global::Configuracao.Properties.Resources.trash;
            this.btnExcluir.Location = new System.Drawing.Point(240, 122);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(2);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(76, 28);
            this.btnExcluir.TabIndex = 8;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Configuracao.Properties.Resources.cancel;
            this.btnCancelar.Location = new System.Drawing.Point(134, 122);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(76, 28);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::Configuracao.Properties.Resources.check;
            this.btnSalvar.Location = new System.Drawing.Point(54, 122);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(76, 28);
            this.btnSalvar.TabIndex = 6;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // frmEvento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 384);
            this.Controls.Add(this.tbcEvento);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmEvento";
            this.Text = "Eventos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tbcEvento.ResumeLayout(false);
            this.pagLista.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvento)).EndInit();
            this.pagCadastro.ResumeLayout(false);
            this.pagCadastro.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tbcEvento;
        private System.Windows.Forms.TabPage pagLista;
        private System.Windows.Forms.DataGridView dgvEvento;
        private System.Windows.Forms.TabPage pagCadastro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtData;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.DataGridViewButtonColumn Acao;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTitulo;
    }
}