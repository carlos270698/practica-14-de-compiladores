namespace Compilador
{
    partial class frmCompilador
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            frmSalir = new Button();
            frmCompilar = new Button();
            frmGuardar = new Button();
            frmAbrir = new Button();
            frmNuevo = new Button();
            panel2 = new Panel();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            txtEstatus = new TextBox();
            panel3 = new Panel();
            txtTokens = new TextBox();
            panel4 = new Panel();
            txtFuente = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.AliceBlue;
            panel1.Controls.Add(frmSalir);
            panel1.Controls.Add(frmCompilar);
            panel1.Controls.Add(frmGuardar);
            panel1.Controls.Add(frmAbrir);
            panel1.Controls.Add(frmNuevo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1774, 106);
            panel1.TabIndex = 0;
            // 
            // frmSalir
            // 
            frmSalir.Font = new Font("Segoe UI", 10F);
            frmSalir.Image = Properties.Resources.exit;
            frmSalir.ImageAlign = ContentAlignment.MiddleLeft;
            frmSalir.Location = new Point(912, 19);
            frmSalir.Margin = new Padding(4, 4, 4, 4);
            frmSalir.Name = "frmSalir";
            frmSalir.Size = new Size(156, 68);
            frmSalir.TabIndex = 4;
            frmSalir.Text = "Salir";
            frmSalir.TextAlign = ContentAlignment.MiddleRight;
            frmSalir.UseVisualStyleBackColor = true;
            frmSalir.Click += frmSalir_Click;
            // 
            // frmCompilar
            // 
            frmCompilar.Font = new Font("Segoe UI", 10F);
            frmCompilar.Image = Properties.Resources.compilar;
            frmCompilar.ImageAlign = ContentAlignment.MiddleLeft;
            frmCompilar.Location = new Point(719, 19);
            frmCompilar.Margin = new Padding(4, 4, 4, 4);
            frmCompilar.Name = "frmCompilar";
            frmCompilar.Size = new Size(156, 68);
            frmCompilar.TabIndex = 3;
            frmCompilar.Text = "Compilar";
            frmCompilar.TextAlign = ContentAlignment.MiddleRight;
            frmCompilar.UseVisualStyleBackColor = true;
            frmCompilar.Click += frmCompilar_Click;
            // 
            // frmGuardar
            // 
            frmGuardar.Font = new Font("Segoe UI", 10F);
            frmGuardar.Image = Properties.Resources.save;
            frmGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            frmGuardar.Location = new Point(525, 19);
            frmGuardar.Margin = new Padding(4, 4, 4, 4);
            frmGuardar.Name = "frmGuardar";
            frmGuardar.Size = new Size(156, 68);
            frmGuardar.TabIndex = 2;
            frmGuardar.Text = "Guardar";
            frmGuardar.TextAlign = ContentAlignment.MiddleRight;
            frmGuardar.UseVisualStyleBackColor = true;
            frmGuardar.Click += frmGuardar_Click;
            // 
            // frmAbrir
            // 
            frmAbrir.Font = new Font("Segoe UI", 10F);
            frmAbrir.Image = Properties.Resources.open;
            frmAbrir.ImageAlign = ContentAlignment.MiddleLeft;
            frmAbrir.Location = new Point(331, 19);
            frmAbrir.Margin = new Padding(4, 4, 4, 4);
            frmAbrir.Name = "frmAbrir";
            frmAbrir.Size = new Size(156, 68);
            frmAbrir.TabIndex = 1;
            frmAbrir.Text = "Abrir";
            frmAbrir.TextAlign = ContentAlignment.MiddleRight;
            frmAbrir.UseVisualStyleBackColor = true;
            frmAbrir.Click += frmAbrir_Click;
            // 
            // frmNuevo
            // 
            frmNuevo.Font = new Font("Segoe UI", 10F);
            frmNuevo.Image = Properties.Resources._new;
            frmNuevo.ImageAlign = ContentAlignment.MiddleLeft;
            frmNuevo.Location = new Point(128, 19);
            frmNuevo.Margin = new Padding(4, 4, 4, 4);
            frmNuevo.Name = "frmNuevo";
            frmNuevo.Size = new Size(179, 68);
            frmNuevo.TabIndex = 0;
            frmNuevo.Text = "Nuevo";
            frmNuevo.TextAlign = ContentAlignment.MiddleRight;
            frmNuevo.UseVisualStyleBackColor = true;
            frmNuevo.Click += frmNuevo_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(groupBox2);
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 830);
            panel2.Margin = new Padding(4, 4, 4, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1774, 220);
            panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Dock = DockStyle.Right;
            groupBox2.Location = new Point(1462, 0);
            groupBox2.Margin = new Padding(4, 4, 4, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 4, 4, 4);
            groupBox2.Size = new Size(312, 220);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tabla de símbolos";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtEstatus);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(4, 4, 4, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 4, 4, 4);
            groupBox1.Size = new Size(1774, 220);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Estatus";
            // 
            // txtEstatus
            // 
            txtEstatus.BackColor = Color.White;
            txtEstatus.Dock = DockStyle.Fill;
            txtEstatus.ForeColor = SystemColors.MenuHighlight;
            txtEstatus.Location = new Point(4, 28);
            txtEstatus.Margin = new Padding(4, 4, 4, 4);
            txtEstatus.Multiline = true;
            txtEstatus.Name = "txtEstatus";
            txtEstatus.ReadOnly = true;
            txtEstatus.ScrollBars = ScrollBars.Vertical;
            txtEstatus.Size = new Size(1766, 188);
            txtEstatus.TabIndex = 0;
            txtEstatus.Text = "Lista del Estatus";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(txtTokens);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(1374, 106);
            panel3.Margin = new Padding(4, 4, 4, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(400, 724);
            panel3.TabIndex = 2;
            // 
            // txtTokens
            // 
            txtTokens.BackColor = Color.White;
            txtTokens.Dock = DockStyle.Fill;
            txtTokens.Location = new Point(0, 0);
            txtTokens.Margin = new Padding(4, 4, 4, 4);
            txtTokens.Multiline = true;
            txtTokens.Name = "txtTokens";
            txtTokens.ReadOnly = true;
            txtTokens.ScrollBars = ScrollBars.Vertical;
            txtTokens.Size = new Size(400, 724);
            txtTokens.TabIndex = 0;
            txtTokens.Text = "Listado de tokens";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(txtFuente);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 106);
            panel4.Margin = new Padding(4, 4, 4, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(1374, 724);
            panel4.TabIndex = 3;
            // 
            // txtFuente
            // 
            txtFuente.Dock = DockStyle.Fill;
            txtFuente.Location = new Point(0, 0);
            txtFuente.Margin = new Padding(4, 4, 4, 4);
            txtFuente.Multiline = true;
            txtFuente.Name = "txtFuente";
            txtFuente.ScrollBars = ScrollBars.Vertical;
            txtFuente.Size = new Size(1374, 724);
            txtFuente.TabIndex = 0;
            txtFuente.Text = "Código fuente";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmCompilador
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1774, 1050);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "frmCompilador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Compilador";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button frmSalir;
        private Button frmCompilar;
        private Button frmGuardar;
        private Button frmAbrir;
        private Button frmNuevo;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private TextBox txtEstatus;
        private Panel panel3;
        private TextBox txtTokens;
        private Panel panel4;
        private TextBox txtFuente;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
    }
}
