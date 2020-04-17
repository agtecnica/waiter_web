using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLControleMovimento
    {
        public int Adicionar(MLControleMovimento modelo)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(MLControleMovimento modelo)
        {
            throw new NotImplementedException();
        }

        public MLControleMovimento Consultar(int ControleMovimentoId)
        {
            DlConexao con = new DlConexao();
            MLControleMovimento controleMovimento = new MLControleMovimento();
            try
            {
                con.limparParametros();
                con.AdicionarParametros("@ControleMovimentoId", ControleMovimentoId);

                var dt = con.ExecutarConsulta(CommandType.StoredProcedure, "P_ListarControleMovimento");
                if (dt.Rows.Count > 0)
                {
                    controleMovimento = Genericos.Popular<MLControleMovimento>(dt, 0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con = null;
            }
            return controleMovimento;
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<MLControleMovimento> Listar(MLControleMovimento modelo)
        {
            throw new NotImplementedException();
        }
    }
}
