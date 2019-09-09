namespace lineasCirculosStatico
{
    partial class input
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
            this.buProcesar = new System.Windows.Forms.Button();
            this.pbFiltro = new System.Windows.Forms.PictureBox();
            this.pbOrigen = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBotones = new System.Windows.Forms.TableLayoutPanel();
            this.buCargarImg = new System.Windows.Forms.Button();
            this.buCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbFiltro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrigen)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // buProcesar
            // 
            this.buProcesar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buProcesar.Location = new System.Drawing.Point(403, 3);
            this.buProcesar.Name = "buProcesar";
            this.buProcesar.Size = new System.Drawing.Size(394, 37);
            this.buProcesar.TabIndex = 12;
            this.buProcesar.Text = "Procesar";
            this.buProcesar.UseVisualStyleBackColor = true;
            this.buProcesar.Click += new System.EventHandler(this.procesar_click);
            // 
            // pbFiltro
            // 
            this.pbFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbFiltro.Location = new System.Drawing.Point(403, 46);
            this.pbFiltro.Name = "pbFiltro";
            this.pbFiltro.Size = new System.Drawing.Size(394, 401);
            this.pbFiltro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFiltro.TabIndex = 11;
            this.pbFiltro.TabStop = false;
            // 
            // pbOrigen
            // 
            this.pbOrigen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbOrigen.Location = new System.Drawing.Point(3, 46);
            this.pbOrigen.Name = "pbOrigen";
            this.pbOrigen.Size = new System.Drawing.Size(394, 401);
            this.pbOrigen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOrigen.TabIndex = 8;
            this.pbOrigen.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tlpBotones, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buProcesar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbOrigen, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbFiltro, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.777778F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.22222F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // tlpBotones
            // 
            this.tlpBotones.ColumnCount = 2;
            this.tlpBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpBotones.Controls.Add(this.buCargarImg, 0, 0);
            this.tlpBotones.Controls.Add(this.buCancelar, 1, 0);
            this.tlpBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBotones.Location = new System.Drawing.Point(3, 3);
            this.tlpBotones.Name = "tlpBotones";
            this.tlpBotones.RowCount = 1;
            this.tlpBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBotones.Size = new System.Drawing.Size(394, 37);
            this.tlpBotones.TabIndex = 13;
            // 
            // buCargarImg
            // 
            this.buCargarImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buCargarImg.Location = new System.Drawing.Point(3, 3);
            this.buCargarImg.Name = "buCargarImg";
            this.buCargarImg.Size = new System.Drawing.Size(269, 31);
            this.buCargarImg.TabIndex = 8;
            this.buCargarImg.Text = "Cargar Imagen";
            this.buCargarImg.UseVisualStyleBackColor = true;
            this.buCargarImg.Click += new System.EventHandler(this.buscarImg_click);
            // 
            // buCancelar
            // 
            this.buCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buCancelar.Location = new System.Drawing.Point(278, 3);
            this.buCancelar.Name = "buCancelar";
            this.buCancelar.Size = new System.Drawing.Size(113, 31);
            this.buCancelar.TabIndex = 9;
            this.buCancelar.Text = "Cancelar";
            this.buCancelar.UseVisualStyleBackColor = true;
            this.buCancelar.Click += new System.EventHandler(this.buCancelar_Click);
            // 
            // input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "input";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbFiltro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrigen)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tlpBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buProcesar;
        private System.Windows.Forms.PictureBox pbFiltro;
        private System.Windows.Forms.PictureBox pbOrigen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tlpBotones;
        private System.Windows.Forms.Button buCargarImg;
        private System.Windows.Forms.Button buCancelar;
    }
}

