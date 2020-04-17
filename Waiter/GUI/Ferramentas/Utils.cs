using Dados;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GUI.Ferramentas
{
    public class Utils
    {
        public static Operacao tipoOperacao { get; set; }
        public enum Operacao
        {
            Inserir,   //0
            Alterar,   //1
            Excluir,   //2
            Salvar,    //3
            Cancelar,  //4
            Localizar, //5
            Carregar   //6
        }

        private void AlterarStringDeConexao()
        {
            var config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            var connectionStrings = config.ConnectionStrings;
            foreach (System.Configuration.ConnectionStringSettings connectionString in connectionStrings.ConnectionStrings)
            {
                connectionString.ConnectionString = new DlConexao().stringConexao; //string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}\\Banco1.mdb", Environment.CurrentDirectory);
            }
            config.Save(System.Configuration.ConfigurationSaveMode.Modified);
            System.Configuration.ConfigurationManager.RefreshSection("connectionStrings");
        }

        public static string RemoveCifrao(String valor)
        {
            try
            {
                String Novovalor = valor.Remove(0, 2);
                return Novovalor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return String.Empty;
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

        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
        public static bool IsPis(string pis)
        {
            int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            if (pis.Trim().Length != 11)
                return false;
            pis = pis.Trim();
            pis = pis.Replace("-", "").Replace(".", "").PadLeft(11, '0');

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(pis[i].ToString()) * multiplicador[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            return pis.EndsWith(resto.ToString());
        }
        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public void StringConexao()
        {
            //Seta um objeto capaz de ler o App.Config
            AppSettingsReader configurationAppSettings = new AppSettingsReader();
           
            

            //Monta parcialmente a string de conexão lendo a partir do App.Config
            string DataSource = configurationAppSettings.GetValue("Data Source", typeof(String)).ToString();
            string UserId = configurationAppSettings.GetValue("User ID", typeof(String)).ToString();
            string Password = configurationAppSettings.GetValue("Password", typeof(String)).ToString();
            string InitialCatalog = configurationAppSettings.GetValue("Initial Catalog", typeof(String)).ToString();

            //Monta a string de conexão
            string ConnectionString = "Data Source=" + DataSource + ";";
            ConnectionString += "User ID=" + UserId + ";";
            ConnectionString += "Password=" + Password + ";";
            ConnectionString += "Initial Catalog=" + InitialCatalog;

            //Cria uma instância do atributo SqlConnection estático em memória
            var conn = new SqlConnection();

            //Atribui a string de conexão e abre a conexão
            conn.ConnectionString = ConnectionString;
            conn.Open();



            XmlDocument doc = new XmlDocument();
            string path = @"C:\MyFiles\TestApp\WindowsFormsApplication1\WindowsFormsApplication1\XMLFile1.xml";
            doc.Load(path);
            //doc.SelectSingleNode("/appSettings/add").Attributes["value"].Value = "hello";
            doc.SelectNodes("/appSettings/add").Item(2).Attributes["value"].Value = "hello";

            doc.Save(path);
        }
    }
}
