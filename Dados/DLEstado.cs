using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLEstado
    {
        public MLEstado Consultar(MLEstado estado)
        {
            DlConexao con = new DlConexao();
            try
            {
                con.limparParametros();
                con.AdicionarParametros("@EstadoId", estado.EstadoId);

                var dt = con.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarEstado]");
                if (dt.Rows.Count > 0)
                {
                    estado = Genericos.Popular<MLEstado>(dt, 0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return estado;
        }

        public List<MLEstado> Listar(MLEstado estado)
        {
            var listaEstado = new List<MLEstado>();
            var objDLConexao = new DlConexao();
            try
            {
                objDLConexao.limparParametros();

                if (estado.EstadoId > 0)
                    objDLConexao.AdicionarParametros("@EstadoId", estado.EstadoId);

                if (!string.IsNullOrEmpty(estado.Nome))
                    objDLConexao.AdicionarParametros("@Nome", estado.Nome);


                var dt = objDLConexao.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarEstado]");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    estado = new MLEstado();
                    estado = Genericos.Popular<MLEstado>(dt, i);

                    listaEstado.Add(estado);
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
            return listaEstado;
        }
    }
}
