using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLContasPagar
    {
        public MLContasPagar Consultar(MLContasPagar contasPagar)
        {
            DlConexao con = new DlConexao();
            DataTable dt = new DataTable();
            MLContasPagar CP = new MLContasPagar();
            try
            {
                con.limparParametros();

                con.AdicionarParametros("@ContaId", contasPagar.ContaId);
                con.AdicionarParametros("@TipoContaId", contasPagar.TipoContaId);

                dt = con.ExecutarConsulta(CommandType.StoredProcedure, "P_ListarContasPagar");

                if (dt.Rows.Count > 0)
                {
                    CP = Genericos.Popular<MLContasPagar>(dt, 0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CP;
        }

        public List<MLContasPagar> Listar(MLContasPagar contasPagar)
        {
            DlConexao con = new DlConexao();
            DataTable dt = new DataTable();
            List<MLContasPagar> lstCP = new List<MLContasPagar>();
            try
            {
                con.limparParametros();

                if (contasPagar.ContaId > 0)
                    con.AdicionarParametros("@ContaId", contasPagar.ContaId);
                if (contasPagar.TipoContaId > 0)
                    con.AdicionarParametros("@TipoContaId", contasPagar.TipoContaId);
                if (contasPagar.Cancelado)
                    con.AdicionarParametros("@Cancelado", contasPagar.Cancelado);

                dt = con.ExecutarConsulta(CommandType.StoredProcedure, "P_ListarContasPagar");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    contasPagar = new MLContasPagar();
                    contasPagar = Genericos.Popular<MLContasPagar>(dt, i);

                    if (contasPagar.TipoContaId == 1)//Igual a Compra
                        contasPagar.Pedido = new DLPedido().Consultar(new MLPedido() { PedidoId = contasPagar.ContaId, Tipo = "C" });
                    else
                        contasPagar.Conta = new DLConta().Consultar(new MLConta() { ContaId = contasPagar.ContaId, TipoContaId = contasPagar.TipoContaId });
                    lstCP.Add(contasPagar);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstCP;
        }
    }
}
