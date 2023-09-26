namespace Comuns.Janelas
{
    partial class frmEventoSelecao
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
            this.dgvEventos = new System.Windows.Forms.DataGridView();
            this.Selecionar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEventos
            // 
            this.dgvEventos.AllowUserToAddRows = false;
            this.dgvEventos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selecionar});
            this.dgvEventos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEventos.Location = new System.Drawing.Point(0, 0);
            this.dgvEventos.Name = "dgvEventos";
            this.dgvEventos.ReadOnly = true;
            this.dgvEventos.Size = new System.Drawing.Size(770, 303);
            this.dgvEventos.TabIndex = 3;
            this.dgvEventos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvento_CellClick);
            // 
            // Selecionar
            // 
            this.Selecionar.HeaderText = "Ação";
            this.Selecionar.Name = "Selecionar";
            this.Selecionar.ReadOnly = true;
            this.Selecionar.Text = "Selecionar";
            this.Selecionar.UseColumnTextForButtonValue = true;
            this.Selecionar.Width = 38;
            // 
            // frmEventoSelecao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 303);
            this.Controls.Add(this.dgvEventos);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmEventoSelecao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecione um evento";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEventos;
        private System.Windows.Forms.DataGridViewButtonColumn Selecionar;
    }
}