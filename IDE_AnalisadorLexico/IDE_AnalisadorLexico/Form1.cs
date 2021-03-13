using IDE_AnalisadorLexico.BLL;
using IDE_AnalisadorLexico.Models;
using System;
using System.IO;
using System.Windows.Forms;

namespace IDE_AnalisadorLexico
{
    public partial class Form1 : Form
    {
        private bool programaIniciado = false;
        private ProgramaFonte cdFonte;

        public Form1()
        {
            cdFonte = new ProgramaFonte();

            InitializeComponent();
            IniciarBotoes();
        }

        private void IniciarBotoes()
        {
            sairItem.Click += onSairClick;
            abrirProgramaItem.Click += onAbrirProgramaClick;
            compilarProgramaItem.Click += onCompilarClick;
        }

        public void onSairClick(object sender, EventArgs e)
        {
            cdFonte.PathNome = null;
            cdFonteTextBox.Text = String.Empty;
            programaIniciado = false;
        }

        public void onAbrirProgramaClick(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            if (!string.IsNullOrWhiteSpace(fileDialog.FileName))
            {
                cdFonte.PathNome = fileDialog.FileName;
                carregarCodigoFonte();
            }
            programaIniciado = true;
        }

        public void onCompilarClick(object sender, EventArgs e)
        {
            var result = MeuCompiladorBLL.compilarPrograma(cdFonte);

            if (result != null)
            {
                MessageBox.Show($"Erro: {result.Message}");
                return;
            }

            MessageBox.Show("Programa compilado com sucesso!");
        }

        private void carregarCodigoFonte()
        {
            using (StreamReader sr = new StreamReader(cdFonte.PathNome))
            {
                cdFonteTextBox.Text = sr.ReadToEnd();
            }
        }
    }
}
