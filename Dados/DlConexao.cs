using Dados.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Dados
{
    public class DlConexao : IDisposable
    {
        string caminhoEArquivo = @"C:\StringCon.txt";
        public string stringConexao;
        private SqlConnection conectarBanco()
        {
            try
            {
                //Cria uma instância do StreamReader para ler o arquivo. A declaração using fecha o stream no fim do escopo
                using (StreamReader sr = new StreamReader(caminhoEArquivo))
                {
                    //Ler e exibe as linhas até alcançar o fim do arquivo.
                    while ((stringConexao = sr.ReadLine()) != null)
                    {
                        return new SqlConnection(stringConexao);
                    }
                }
                return new SqlConnection("");
            }
            catch (Exception e)
            {
                throw e;
            }
            return new SqlConnection(Settings.Default.stringConexao);
            //return new SqlConnection(Settings.Default.stringConexaoNuvem);
        }

        private SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;

        public void limparParametros()
        {
            sqlParameterCollection.Clear();
        }
        public int ContarParametros()
        {
            return sqlParameterCollection.Count;
        }
        public void AdicionarParametros(string nomeParametro, Object valorParametro)
        {
            sqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));
        }

        //metodo para inserir, alterar, excluir
        public object ExecutarManipulacao(CommandType commandType, string nomeStoreProcedureOuTextoSql)
        {
            var sqlcommand = new SqlCommand();
            var sqlConnection = new SqlConnection();

            try
            {
                sqlConnection = conectarBanco();
                sqlConnection.Open();

                //Criar comando que ira levar a informação ao BD
                sqlcommand = sqlConnection.CreateCommand();

                //Insere os dados no comando
                sqlcommand.CommandText = nomeStoreProcedureOuTextoSql;

                //tipo
                sqlcommand.CommandType = CommandType.StoredProcedure;
                //sqlcommand.CommandType = CommandType.Text;

                sqlcommand.CommandTimeout = 7200; //em segundos para derrubar conexao == 2hrs

                //adcionaos parametros do comando
                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlcommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }
                //ExecuteScalar() retorna somente primeira coluna da primeira linha
                return sqlcommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlcommand.Dispose();
            }
        }

        //Consulta registros no BD
        public DataTable ExecutarConsulta(CommandType commandType, string nomeStoreProcedureOuTextoSql)
        {
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlcommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            try
            {
                // CommandType.StoredProcedure
                sqlConnection = conectarBanco();
                sqlConnection.Open();

                //Criar comando que ria levar a informação ao BD
                sqlcommand = sqlConnection.CreateCommand();

                //Insere os dados no comando
                sqlcommand.CommandType = commandType;
                sqlcommand.CommandText = nomeStoreProcedureOuTextoSql;
                sqlcommand.CommandType = CommandType.StoredProcedure;
                //sqlcommand.CommandType = CommandType.Text;
                sqlcommand.CommandTimeout = 7200; //em segundos para derrubar conexao == 2hrs

                //adcionaos parametros do comando
                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlcommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }

                //cria uma adaptador
                sqlDataAdapter = new SqlDataAdapter(sqlcommand);

                //transforma os dados do BD para C#
                sqlDataAdapter.Fill(dataTable);

                //ExecuteScalar() retorna somente primeira coluna da primeira linh
                return dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlcommand.Dispose();
            }

        }

        public void Dispose()
        {
        }
    }
}
