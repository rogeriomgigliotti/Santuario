namespace Configuracao
{
    partial class frmListaPreco
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
            this.dgvListaPreco = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEvento = new System.Windows.Forms.Button();
            this.lblEvento = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPreco)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListaPreco
            // 
            this.dgvListaPreco.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvListaPreco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaPreco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListaPreco.Location = new System.Drawing.Point(0, 49);
            this.dgvListaPreco.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListaPreco.Name = "dgvListaPreco";
            this.dgvListaPreco.RowTemplate.Height = 28;
            this.dgvListaPreco.Size = new System.Drawing.Size(637, 266);
            this.dgvListaPreco.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 315);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 65);
            this.panel1.TabIndex = 2;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::Configuracao.Properties.Resources.check;
            this.btnSalvar.Location = new System.Drawing.Point(8, 18);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(66, 31);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
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
            this.panel2.Size = new System.Drawing.Size(637, 49);
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
            // frmListaPreco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 380);
            this.Controls.Add(this.dgvListaPreco);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmListaPreco";
            this.Text = "Lista de Preços";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPreco)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListaPreco;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblEvento;
        private System.Windows.Forms.Button btnEvento;
    }
}