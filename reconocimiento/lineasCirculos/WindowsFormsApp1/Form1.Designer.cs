namespace WindowsFormsApp1
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbInput = new System.Windows.Forms.PictureBox();
            this.pbProcesado = new System.Windows.Forms.PictureBox();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudIP1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudIP2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudIP3 = new System.Windows.Forms.NumericUpDown();
            this.nudIP4 = new System.Windows.Forms.NumericUpDown();
            this.buConectar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buDesconectar = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.label4 = new System.Windows.Forms.Label();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProcesado)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIP3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIP4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pbProcesado, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbInput, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rtbConsole, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(403, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 219);
            this.panel1.TabIndex = 0;
            // 
            // pbInput
            // 
            this.pbInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbInput.Location = new System.Drawing.Point(3, 3);
            this.pbInput.Name = "pbInput";
            this.pbInput.Size = new System.Drawing.Size(394, 219);
            this.pbInput.TabIndex = 1;
            this.pbInput.TabStop = false;
            // 
            // pbProcesado
            // 
            this.pbProcesado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbProcesado.Location = new System.Drawing.Point(3, 228);
            this.pbProcesado.Name = "pbProcesado";
            this.pbProcesado.Size = new System.Drawing.Size(394, 219);
            this.pbProcesado.TabIndex = 2;
            this.pbProcesado.TabStop = false;
            // 
            // rtbConsole
            // 
            this.rtbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbConsole.Location = new System.Drawing.Point(403, 228);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.ReadOnly = true;
            this.rtbConsole.Size = new System.Drawing.Size(394, 219);
            this.rtbConsole.TabIndex = 3;
            this.rtbConsole.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buDesconectar);
            this.groupBox1.Controls.Add(this.nudPort);
            this.groupBox1.Controls.Add(this.buConectar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nudIP4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudIP3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudIP2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nudIP1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camara IP";
            // 
            // nudIP1
            // 
            this.nudIP1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nudIP1.Location = new System.Drawing.Point(36, 19);
            this.nudIP1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudIP1.Name = "nudIP1";
            this.nudIP1.Size = new System.Drawing.Size(45, 20);
            this.nudIP1.TabIndex = 0;
            this.nudIP1.Value = new decimal(new int[] {
            192,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "-";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(142, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "-";
            // 
            // nudIP2
            // 
            this.nudIP2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nudIP2.Location = new System.Drawing.Point(96, 19);
            this.nudIP2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudIP2.Name = "nudIP2";
            this.nudIP2.Size = new System.Drawing.Size(45, 20);
            this.nudIP2.TabIndex = 3;
            this.nudIP2.Value = new decimal(new int[] {
            168,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(203, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "-";
            // 
            // nudIP3
            // 
            this.nudIP3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nudIP3.Location = new System.Drawing.Point(157, 19);
            this.nudIP3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudIP3.Name = "nudIP3";
            this.nudIP3.Size = new System.Drawing.Size(45, 20);
            this.nudIP3.TabIndex = 5;
            this.nudIP3.Value = new decimal(new int[] {
            31,
            0,
            0,
            0});
            // 
            // nudIP4
            // 
            this.nudIP4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nudIP4.Location = new System.Drawing.Point(219, 19);
            this.nudIP4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudIP4.Name = "nudIP4";
            this.nudIP4.Size = new System.Drawing.Size(45, 20);
            this.nudIP4.TabIndex = 7;
            this.nudIP4.Value = new decimal(new int[] {
            89,
            0,
            0,
            0});
            // 
            // buConectar
            // 
            this.buConectar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buConectar.Location = new System.Drawing.Point(106, 45);
            this.buConectar.Name = "buConectar";
            this.buConectar.Size = new System.Drawing.Size(85, 23);
            this.buConectar.TabIndex = 1;
            this.buConectar.Text = "Conectar";
            this.buConectar.UseVisualStyleBackColor = true;
            this.buConectar.Click += new System.EventHandler(this.buIniciar_Click);
            // 
            // buDesconectar
            // 
            this.buDesconectar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buDesconectar.Location = new System.Drawing.Point(197, 45);
            this.buDesconectar.Name = "buDesconectar";
            this.buDesconectar.Size = new System.Drawing.Size(85, 23);
            this.buDesconectar.TabIndex = 2;
            this.buDesconectar.Text = "Desconectar";
            this.buDesconectar.UseVisualStyleBackColor = true;
            this.buDesconectar.Click += new System.EventHandler(this.buTerminar_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(270, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = ":";
            // 
            // nudPort
            // 
            this.nudPort.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nudPort.Location = new System.Drawing.Point(289, 19);
            this.nudPort.Maximum = new decimal(new int[] {
            64738,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(63, 20);
            this.nudPort.TabIndex = 9;
            this.nudPort.Value = new decimal(new int[] {
            4747,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProcesado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIP3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIP4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbProcesado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buConectar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudIP4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudIP3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudIP2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudIP1;
        private System.Windows.Forms.PictureBox pbInput;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buDesconectar;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

