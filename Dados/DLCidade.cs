using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLCidade 
    {
        public MLCidade Consultar(MLCidade cidade)
        {
            DlConexao con = new DlConexao();
            try
            {
                con.limparParametros();
                con.AdicionarParametros("@CidadeId", cidade.CidadeId);

                var dt = con.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarCidade]");
                if (dt.Rows.Count > 0)
                {
                    cidade = Genericos.Popular<MLCidade>(dt, 0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cidade;
        }

        public List<MLCidade> Listar(MLCidade cidade)
        {
            var listaCidade = new List<MLCidade>();
            var objDLConexao = new DlConexao();
            try
            {
                objDLConexao.limparParametros();

                if (cidade.CidadeId > 0)
                    objDLConexao.AdicionarParametros("@CidadeId", cidade.CidadeId);

                if (cidade.EstadoId > 0)
                    objDLConexao.AdicionarParametros("@EstadoId", cidade.EstadoId);

                if (!string.IsNullOrEmpty(cidade.Nome))
                    objDLConexao.AdicionarParametros("@Nome", cidade.Nome);


                var dt = objDLConexao.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarCidade]");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cidade = new MLCidade();
                    cidade = Genericos.Popular<MLCidade>(dt, i);

                    listaCidade.Add(cidade);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDLConexao = null;
            }
            return listaCidade;
        }
    }
}
