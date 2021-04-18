using System.Windows.Forms;
using IDE_AnalisadorLexico.DAL;
using IDE_AnalisadorLexico.Utils;

namespace IDE_AnalisadorLexico.BLL
{
    public class AnalisadorSintaticoBLL
    {
        public static void testeTokensValidos()
        {
            var tokensValidos = MeuCompiladorDAL.PopulaDR();
            
            tokensValidos.ForEach(token =>
            {
                if (Erro.getErro() == false)
                {
                    MeuCompiladorDAL.LeUmTokenValido(token);
                }
            });
        }
    }
}