using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLEstoque
    {
        public MLEstoque Consultar(MLEstoque estoque)
        {
            var con = new DlConexao();
            try
            {
                con.limparParametros();
                con.AdicionarParametros("@ProdutoId", estoque.ProdutoId);


                var dt = con.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarEstoque]");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    estoque = new MLEstoque();
                    estoque = Genericos.Popular<MLEstoque>(dt, i);
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
            return estoque;
        }

        public List<MLEstoque> Listar(MLEstoque estoque)
        {
            var listaEstoqueProduto = new List<MLEstoque>();
            var con = new DlConexao();
            try
            {
                con.limparParametros();
                con.AdicionarParametros("@ProdutoId", estoque.ProdutoId);


                var dt = con.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarProduto]");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    estoque = new MLEstoque();
                    estoque = Genericos.Popular<MLEstoque>(dt, i);
                    listaEstoqueProduto.Add(estoque);
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
            return listaEstoqueProduto;
        }
    }
}
