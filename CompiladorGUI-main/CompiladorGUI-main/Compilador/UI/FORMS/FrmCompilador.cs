
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using Compilador.UI.CORE;

namespace Compilador.UI.Forms
{
    public partial class FrmCompilador : Form
    {
        private RichTextBox txtEditor;
        private Panel pnlLineNumbers;
        private bool isDarkTheme = false;

        public FrmCompilador()
        {
            InitializeComponent();
            InicializarEditor();
            AplicarTemaClaro();

            btnTema.Click += BtnTema_Click;
        }


        private void InicializarEditor()
        {
            pnlLineNumbers = new Panel
            {
                Dock = DockStyle.Left,
                Width = 50
            };
            pnlLineNumbers.Paint += PnlLineNumbers_Paint;

            txtEditor = new RichTextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 11F),
                WordWrap = false,
                BorderStyle = BorderStyle.None,
                ScrollBars = RichTextBoxScrollBars.Vertical
            };

            txtEditor.VScroll += (s, e) => pnlLineNumbers.Invalidate();
            txtEditor.TextChanged += (s, e) => pnlLineNumbers.Invalidate();
            txtEditor.Resize += (s, e) => pnlLineNumbers.Invalidate();

            splitEditor.Panel1.Controls.Add(txtEditor);
            splitEditor.Panel1.Controls.Add(pnlLineNumbers);
        }


        private void PnlLineNumbers_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(pnlLineNumbers.BackColor);

            int firstIndex = txtEditor.GetCharIndexFromPosition(new Point(0, 0));
            int firstLine = txtEditor.GetLineFromCharIndex(firstIndex);

            int lastIndex = txtEditor.GetCharIndexFromPosition(new Point(0, txtEditor.Height));
            int lastLine = txtEditor.GetLineFromCharIndex(lastIndex);

            for (int i = firstLine; i <= lastLine + 1; i++)
            {
                int charIndex = txtEditor.GetFirstCharIndexFromLine(i);
                if (charIndex == -1) continue;

                Point pos = txtEditor.GetPositionFromCharIndex(charIndex);

                string lineNumber = (i + 1).ToString();
                SizeF size = e.Graphics.MeasureString(lineNumber, txtEditor.Font);

                e.Graphics.DrawString(
                    lineNumber,
                    txtEditor.Font,
                    Brushes.Gray,
                    pnlLineNumbers.Width - size.Width - 5,
                    pos.Y
                );
            }
        }


        private void BtnTema_Click(object sender, EventArgs e)
        {
            isDarkTheme = !isDarkTheme;

            if (isDarkTheme)
                AplicarTemaOscuro();
            else
                AplicarTemaClaro();
        }

        private void AplicarTemaClaro()
        {
            txtEditor.BackColor = Color.White;
            txtEditor.ForeColor = Color.Black;
            pnlLineNumbers.BackColor = Color.FromArgb(245, 245, 245);
        }

        private void AplicarTemaOscuro()
        {
            txtEditor.BackColor = Color.FromArgb(30, 30, 30);
            txtEditor.ForeColor = Color.Gainsboro;
            pnlLineNumbers.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void limpiar()
        {
            try
            {
                txtEditor.Clear();
                txtTokens.Clear();
                txtEstatus.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al limpiar los campos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    limpiar();
                    string filePath = openFileDialog1.FileName;
                    string fileContent = File.ReadAllText(filePath);
                    txtEditor.Text = fileContent;

                    txtEstatus.AppendText("Archivo abierto: " + filePath + Environment.NewLine);
                }
                else
                {
                    txtEstatus.AppendText("Operación de apertura cancelada." + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog1.FileName;
                    File.WriteAllText(filePath, txtEditor.Text);
                    txtEstatus.AppendText("Archivo guardado: " + filePath + Environment.NewLine);
                }
                else
                {
                    txtEstatus.AppendText("Operación de guardado cancelada." + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCompilar_Click(object sender, EventArgs e)
        {
            txtTokens.Clear();
            txtEstatus.Clear();

            if (txtEditor.Text.Length == 0)
            {
                txtEstatus.AppendText("Codigo fuente vacio." + Environment.NewLine);
                return;
            }

            var fuente = CodigoFuente.DesdeTexto(txtEditor.Text);
            var analizador = new AnalizadorLexico();
            var resultado = analizador.Analizar(fuente);

            foreach (var aviso in resultado.Avisos)
            {
                txtEstatus.AppendText(aviso + Environment.NewLine);
            }

            var tokensPorLinea = resultado.Tokens.GroupBy(t => t.Linea);

            foreach (var grupo in tokensPorLinea)
            {
                txtTokens.AppendText($"[{grupo.Key}] " + string.Join(", ", grupo.Select(t => t.Tipo)) + Environment.NewLine);
            }

            txtEstatus.AppendText("Fase 2 [Sintáctico] INICIADO" + Environment.NewLine);
            var analizadorSintactico = new AnalizadorSintactico();
            analizadorSintactico.Parse(resultado.Tokens);
            if (analizadorSintactico.Errores.Count == 0)
            {
                txtEstatus.AppendText("Análisis Sintáctico finalizado con éxito" + Environment.NewLine);
            }
            else
            {
                foreach (var error in analizadorSintactico.Errores)
                {
                    txtEstatus.AppendText(error + Environment.NewLine);
                }
            }
        }

        private void txtEstatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txtTokens_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitEditor_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
