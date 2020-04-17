using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLEstoqueAjuste
    {
        public int Adicionar(MLEstoqueAjuste ajuste)
        {

            DlConexao con = new DlConexao();
            var id = 0;

            try
            {
                con.limparParametros();

                con.AdicionarParametros("@Tipo", ajuste.Tipo);
                con.AdicionarParametros("@ProdutoId", ajuste.ProdutoId);
                con.AdicionarParametros("@Quantidade", ajuste.Quantidade);
                con.AdicionarParametros("@MovimentoCancelado", ajuste.MovimentoCancelado);
                con.AdicionarParametros("@Data", ajuste.Data);
                con.AdicionarParametros("@UsuarioId", ajuste.UsuarioId);
                con.AdicionarParametros("@Justificativa", ajuste.Justificativa);

                id = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_InserirEstoqueAjuste"));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }

        //public void Atualizar(MLEstoqueAjuste modelo)
        //{

        //}

        //public MLEstoqueAjuste Consultar(MLEstoqueAjuste modelo)
        //{

        //}

        //public void Excluir(int id)
        //{

        //}


        public List<MLEstoqueAjuste> Listar(MLEstoqueAjuste modelo)
        {
            DlConexao con = new DlConexao();
            DataTable dt = new DataTable();
            List<MLEstoqueAjuste> lstAjuste = new List<MLEstoqueAjuste>();
            try
            {
                con.limparParametros();
               
                dt = con.ExecutarConsulta(CommandType.StoredProcedure, "P_ListarEstoqueAjuste");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MLEstoqueAjuste ajuste = new MLEstoqueAjuste();
                    ajuste = Genericos.Popular<MLEstoqueAjuste>(dt, i);

                    var produto = new MLProduto() { ProdutoId = ajuste.ProdutoId };
                    ajuste.Produto = new DLProduto().Consultar(produto);

                    lstAjuste.Add(ajuste);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAjuste;
        }
    }
}
