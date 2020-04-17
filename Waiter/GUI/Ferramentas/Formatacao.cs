using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GUI.Ferramentas
{
    public static class Formatacao
    {
        public static string FormatarCpfCnpj(string strCpfCnpj)
        {
            try
            {
                if (strCpfCnpj.Length <= 11)
                {
                    MaskedTextProvider mtpCpf = new MaskedTextProvider(@"000\.000\.000-00");
                    mtpCpf.Set(ZerosEsquerda(strCpfCnpj, 11));
                    return mtpCpf.ToString();
                }
                else
                {
                    MaskedTextProvider mtpCnpj = new MaskedTextProvider(@"00\.000\.000/0000-00");
                    mtpCnpj.Set(ZerosEsquerda(strCpfCnpj, 11));
                    return mtpCnpj.ToString();
                }
            }
            catch 
            {
                return strCpfCnpj;
            }
        }
        public static void Moeda(ref TextBox txt)
        {
            string n = string.Empty;
            double v = 0;
            try
            {
                n = txt.Text.Replace(",", "").Replace(",", "");
                if (n.Equals(""))
                    n = "";
                n = n.PadLeft(3, '0');
                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);
                v = Convert.ToDouble(n) / 100;
                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        public static void Moeda(ref NumericUpDown txt)
        {
            string n = string.Empty;
            double v = 0;
            try
            {
                n = txt.Text.Replace(",", "").Replace(",", "");
                if (n.Equals(""))
                    n = "";
                n = n.PadLeft(3, '0');
                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);
                v = Convert.ToDouble(n) / 100;
                txt.Text = string.Format("{0:N}", v);
                txt.Select(0, txt.Value.ToString().Length);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        public static string ZerosEsquerda(string strString, int intTamanho)
        {
            try
            {
                string strResult = "";
                for (int intCont = 1; intCont <= (intTamanho - strString.Length); intCont++)
                {
                    strResult += "0";
                }
                return strResult + strString;
            }
            catch
            {
                return strString;
            }
        }

        public static string FormatarInscricaoEstadual(string ie)
        {
            try
            {
                ie = ZerosEsquerda(ie, 12);
                return Convert.ToUInt64(ie).ToString(@"000\.000\.000\.000");
            }
            catch
            {
                return ie;
            }
        }

        public static string FormatarCEP(string cep)
        {
            try
            {
                return Convert.ToUInt64(cep).ToString(@"00\.000\-000");
            }
            catch
            {
                return cep;
            }
        }

        public static string FormatarCelular(string celular)
        {
            try
            {
                return Convert.ToUInt64(celular).ToString(@"(00) 0 0000\-0000");
            }
            catch
            {
                return celular;
            }
        }

        public static string FormatarTelefone(string telefone)
        {
            try
            {
                return Convert.ToUInt64(telefone).ToString(@"(00) 0000\-0000");
            }
            catch
            {
                return telefone;
            }
        }
    }
}
