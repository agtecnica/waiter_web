using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Ferramentas
{
    public class Erro
    {
        public static void ExibirMenssagemException(Exception exception, string msgPersonlizada = "")
        {
            if (exception != null)
            {
                if (exception.InnerException != null)
                {
                    if (exception.InnerException.InnerException != null)
                    {
                        //MessageBoxEx.Show(@"Erro: " + exception.Message, @"Erro", exception.InnerException.InnerException.Message + ", " + exception.StackTrace, MessageIcon.Error, MessageButton.OK);
                    }
                    else
                    {
                        //MessageBoxEx.Show(@"Erro: " + exception.Message, @"Erro", exception.InnerException.Message + ", " + exception.StackTrace, MessageIcon.Error, MessageButton.OK);
                    }
                }
                else
                {
                    //MessageBoxEx.Show(@"Erro: " + exception.Message, @"Erro", MessageIcon.Error, MessageButton.OK);
                }

            }

        }
    }
}
