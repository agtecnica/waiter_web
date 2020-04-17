using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLResumoMovimento 
    {
        public MLResumoMovimento Consultar(int mLResumoMovimentoId)
        {
            DlConexao con = new DlConexao();
            DataTable dt = new DataTable();
            MLResumoMovimento resumo = new MLResumoMovimento ();

            con.limparParametros();
            con.AdicionarParametros("@CaixaControleMovimentoId", mLResumoMovimentoId);
            dt = con.ExecutarConsulta(CommandType.StoredProcedure, "P_ListarMovimento");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                resumo = Genericos.Popular<MLResumoMovimento>(dt, i);
            }

            return resumo;
        }
        public List<MLResumoMovimento> Listar(MLResumoMovimento mLResumoMovimento)
        {

            return new List<MLResumoMovimento>();
        }
    }
}
