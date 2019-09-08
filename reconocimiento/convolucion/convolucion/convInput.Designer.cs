namespace convolucion
{
    partial class convInput
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
            this.buAplicarFiltro = new System.Windows.Forms.Button();
            this.pbFiltro = new System.Windows.Forms.PictureBox();
            this.dgvFiltro = new System.Windows.Forms.DataGridView();
            this.pbOrigen = new System.Windows.Forms.PictureBox();
            this.buCargarImg = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbFiltroN = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbFiltro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiltro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrigen)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buAplicarFiltro
            // 
            this.buAplicarFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buAplicarFiltro.Location = new System.Drawing.Point(483, 3);
            this.buAplicarFiltro.Name = "buAplicarFiltro";
            this.buAplicarFiltro.Size = new System.Drawing.Size(314, 37);
            this.buAplicarFiltro.TabIndex = 12;
            this.buAplicarFiltro.Text = "Aplicar filtro";
            this.buAplicarFiltro.UseVisualStyleBackColor = true;
            this.buAplicarFiltro.Click += new System.EventHandler(this.aplicarFiltro_click);
            // 
            // pbFiltro
            // 
            this.pbFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbFiltro.Location = new System.Drawing.Point(483, 46);
            this.pbFiltro.Name = "pbFiltro";
            this.pbFiltro.Size = new System.Drawing.Size(314, 401);
            this.pbFiltro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFiltro.TabIndex = 11;
            this.pbFiltro.TabStop = false;
            // 
            // dgvFiltro
            // 
            this.dgvFiltro.AllowUserToAddRows = false;
            this.dgvFiltro.AllowUserToResizeColumns = false;
            this.dgvFiltro.AllowUserToResizeRows = false;
            this.dgvFiltro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFiltro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiltro.ColumnHeadersVisible = false;
            this.dgvFiltro.Location = new System.Drawing.Point(3, 157);
            this.dgvFiltro.Name = "dgvFiltro";
            this.dgvFiltro.RowHeadersVisible = false;
            this.dgvFiltro.Size = new System.Drawing.Size(148, 131);
            this.dgvFiltro.TabIndex = 10;
            // 
            // pbOrigen
            // 
            this.pbOrigen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbOrigen.Location = new System.Drawing.Point(3, 46);
            this.pbOrigen.Name = "pbOrigen";
            this.pbOrigen.Size = new System.Drawing.Size(314, 401);
            this.pbOrigen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOrigen.TabIndex = 8;
            this.pbOrigen.TabStop = false;
            // 
            // buCargarImg
            // 
            this.buCargarImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buCargarImg.Location = new System.Drawing.Point(3, 3);
            this.buCargarImg.Name = "buCargarImg";
            this.buCargarImg.Size = new System.Drawing.Size(314, 37);
            this.buCargarImg.TabIndex = 7;
            this.buCargarImg.Text = "Cargar Imagen";
            this.buCargarImg.UseVisualStyleBackColor = true;
            this.buCargarImg.Click += new System.EventHandler(this.buscarImg_click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buCargarImg, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buAplicarFiltro, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbOrigen, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbFiltro, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.777778F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.22222F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(323, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 43);
            this.label1.TabIndex = 8;
            this.label1.Text = "Seleccionar Filtro";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buCancelar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbFiltroN);
            this.panel1.Controls.Add(this.dgvFiltro);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(323, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 401);
            this.panel1.TabIndex = 15;
            // 
            // cbFiltroN
            // 
            this.cbFiltroN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltroN.FormattingEnabled = true;
            this.cbFiltroN.Items.AddRange(new object[] {
            "3",
            "5"});
            this.cbFiltroN.Location = new System.Drawing.Point(3, 100);
            this.cbFiltroN.Name = "cbFiltroN";
            this.cbFiltroN.Size = new System.Drawing.Size(148, 21);
            this.cbFiltroN.TabIndex = 11;
            this.cbFiltroN.SelectedIndexChanged += new System.EventHandler(this.cbFiltroN_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tamanio Filtro:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Filtro:";
            // 
            // buCancelar
            // 
            this.buCancelar.Location = new System.Drawing.Point(40, 294);
            this.buCancelar.Name = "buCancelar";
            this.buCancelar.Size = new System.Drawing.Size(75, 23);
            this.buCancelar.TabIndex = 14;
            this.buCancelar.Text = "Cancelar";
            this.buCancelar.UseVisualStyleBackColor = true;
            this.buCancelar.Click += new System.EventHandler(this.buCancelar_Click);
            // 
            // convInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "convInput";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbFiltro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiltro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrigen)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buAplicarFiltro;
        private System.Windows.Forms.PictureBox pbFiltro;
        private System.Windows.Forms.DataGridView dgvFiltro;
        private System.Windows.Forms.PictureBox pbOrigen;
        private System.Windows.Forms.Button buCargarImg;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buCancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFiltroN;
    }
}

