namespace Configuracao
{
    partial class frmUsuario
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
            this.tbcUsuario = new System.Windows.Forms.TabControl();
            this.pagLista = new System.Windows.Forms.TabPage();
            this.dgvUsuario = new System.Windows.Forms.DataGridView();
            this.Acao = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNovo = new System.Windows.Forms.Button();
            this.pagCadastro = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.ckbAtivo = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tbcUsuario.SuspendLayout();
            this.pagLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).BeginInit();
            this.panel1.SuspendLayout();
            this.pagCadastro.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcUsuario
            // 
            this.tbcUsuario.Controls.Add(this.pagLista);
            this.tbcUsuario.Controls.Add(this.pagCadastro);
            this.tbcUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcUsuario.Location = new System.Drawing.Point(0, 49);
            this.tbcUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.tbcUsuario.Name = "tbcUsuario";
            this.tbcUsuario.SelectedIndex = 0;
            this.tbcUsuario.Size = new System.Drawing.Size(637, 331);
            this.tbcUsuario.TabIndex = 1;
            // 
            // pagLista
            // 
            this.pagLista.Controls.Add(this.dgvUsuario);
            this.pagLista.Controls.Add(this.panel1);
            this.pagLista.Location = new System.Drawing.Point(4, 22);
            this.pagLista.Margin = new System.Windows.Forms.Padding(2);
            this.pagLista.Name = "pagLista";
            this.pagLista.Padding = new System.Windows.Forms.Padding(2);
            this.pagLista.Size = new System.Drawing.Size(629, 305);
            this.pagLista.TabIndex = 0;
            this.pagLista.Text = "Lista";
            this.pagLista.UseVisualStyleBackColor = true;
            // 
            // dgvUsuario
            // 
            this.dgvUsuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Acao});
            this.dgvUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuario.Location = new System.Drawing.Point(2, 2);
            this.dgvUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.dgvUsuario.Name = "dgvUsuario";
            this.dgvUsuario.RowTemplate.Height = 28;
            this.dgvUsuario.Size = new System.Drawing.Size(625, 236);
            this.dgvUsuario.TabIndex = 2;
            this.dgvUsuario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuario_CellContentClick);
            // 
            // Acao
            // 
            this.Acao.HeaderText = "Ação";
            this.Acao.Name = "Acao";
            this.Acao.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Acao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Acao.Text = "Selecionar";
            this.Acao.UseColumnTextForButtonValue = true;
            this.Acao.Width = 57;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnNovo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 238);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 65);
            this.panel1.TabIndex = 1;
            // 
            // btnNovo
            // 
            this.btnNovo.Image = global::Configuracao.Properties.Resources.add;
            this.btnNovo.Location = new System.Drawing.Point(8, 18);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(66, 31);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "Novo";
            this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // pagCadastro
            // 
            this.pagCadastro.BackColor = System.Drawing.SystemColors.Control;
            this.pagCadastro.Controls.Add(this.label6);
            this.pagCadastro.Controls.Add(this.cmbTipo);
            this.pagCadastro.Controls.Add(this.txtSenha);
            this.pagCadastro.Controls.Add(this.txtLogin);
            this.pagCadastro.Controls.Add(this.btnExcluir);
            this.pagCadastro.Controls.Add(this.btnCancelar);
            this.pagCadastro.Controls.Add(this.btnSalvar);
            this.pagCadastro.Controls.Add(this.ckbAtivo);
            this.pagCadastro.Controls.Add(this.label5);
            this.pagCadastro.Controls.Add(this.label4);
            this.pagCadastro.Controls.Add(this.label3);
            this.pagCadastro.Controls.Add(this.txtNome);
            this.pagCadastro.Controls.Add(this.label2);
            this.pagCadastro.Controls.Add(this.txtCodigo);
            this.pagCadastro.Controls.Add(this.label1);
            this.pagCadastro.Location = new System.Drawing.Point(4, 22);
            this.pagCadastro.Margin = new System.Windows.Forms.Padding(2);
            this.pagCadastro.Name = "pagCadastro";
            this.pagCadastro.Padding = new System.Windows.Forms.Padding(2);
            this.pagCadastro.Size = new System.Drawing.Size(629, 305);
            this.pagCadastro.TabIndex = 1;
            this.pagCadastro.Text = "Cadastro";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 73);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tipo:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(54, 70);
            this.cmbTipo.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(262, 21);
            this.cmbTipo.TabIndex = 5;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(54, 119);
            this.txtSenha.Margin = new System.Windows.Forms.Padding(2);
            this.txtSenha.MaxLength = 100;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(262, 20);
            this.txtSenha.TabIndex = 9;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(54, 95);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(2);
            this.txtLogin.MaxLength = 100;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(262, 20);
            this.txtLogin.TabIndex = 7;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = global::Configuracao.Properties.Resources.trash;
            this.btnExcluir.Location = new System.Drawing.Point(240, 176);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(2);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(76, 28);
            this.btnExcluir.TabIndex = 14;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Configuracao.Properties.Resources.cancel;
            this.btnCancelar.Location = new System.Drawing.Point(134, 176);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(76, 28);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::Configuracao.Properties.Resources.check;
            this.btnSalvar.Location = new System.Drawing.Point(54, 176);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(76, 28);
            this.btnSalvar.TabIndex = 12;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // ckbAtivo
            // 
            this.ckbAtivo.AutoSize = true;
            this.ckbAtivo.Location = new System.Drawing.Point(54, 143);
            this.ckbAtivo.Margin = new System.Windows.Forms.Padding(2);
            this.ckbAtivo.Name = "ckbAtivo";
            this.ckbAtivo.Size = new System.Drawing.Size(15, 14);
            this.ckbAtivo.TabIndex = 11;
            this.ckbAtivo.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 144);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ativo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 120);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Senha:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Login:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(54, 46);
            this.txtNome.Margin = new System.Windows.Forms.Padding(2);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(262, 20);
            this.txtNome.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 51);
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
            this.panel2.Size = new System.Drawing.Size(637, 49);
            this.panel2.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(2, 9);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(297, 31);
            this.lblTitulo.TabIndex = 11;
            this.lblTitulo.Text = "Cadastro de Usuários";
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 380);
            this.Controls.Add(this.tbcUsuario);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmUsuario";
            this.Text = "Usuários";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tbcUsuario.ResumeLayout(false);
            this.pagLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pagCadastro.ResumeLayout(false);
            this.pagCadastro.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcUsuario;
        private System.Windows.Forms.TabPage pagLista;
        private System.Windows.Forms.DataGridView dgvUsuario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.TabPage pagCadastro;
        private System.Windows.Forms.CheckBox ckbAtivo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.DataGridViewButtonColumn Acao;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTitulo;
    }
}