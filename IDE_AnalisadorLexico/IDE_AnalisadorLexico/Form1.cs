using IDE_AnalisadorLexico.BLL;
using IDE_AnalisadorLexico.Models;
using IDE_AnalisadorLexico.Utils;
using System;
using System.IO;
using System.Text;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            MeuCompiladorBLL.Conecta();
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
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
            cdFonteTextBox.Text = string.Empty;
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
            MeuCompiladorBLL.CompilarPrograma(cdFonte);

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
                return;
            }

            StringBuilder textoValidacao = new StringBuilder();
            foreach(string valor in ExtratoDeTokens.Tokens)
                textoValidacao.Append($"{valor}\n");

            MessageBox.Show(textoValidacao.ToString());
        }

        private void carregarCodigoFonte()
        {
            using (StreamReader sr = new StreamReader(cdFonte.PathNome))
            {
                cdFonteTextBox.Text = sr.ReadToEnd();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MeuCompiladorBLL.Desconecta();
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
        }
    }
}
