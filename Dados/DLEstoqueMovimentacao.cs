using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLEstoqueMovimentacao 
    {
        public int Adicionar(MLEstoqueMovimentacao estoqueMovimentacao)
        {
            DlConexao con = new DlConexao();
            var id = 0;

            try
            {
                con.limparParametros();

                con.AdicionarParametros("@TipoMovimentacao", estoqueMovimentacao.TipoMovimentacao);
                con.AdicionarParametros("@PedidoId", estoqueMovimentacao.PedidoId);
                con.AdicionarParametros("@ProdutoId", estoqueMovimentacao.ProdutoId);
                con.AdicionarParametros("@Quantidade", estoqueMovimentacao.Quantidade);
                con.AdicionarParametros("@MovimentoCancelado", estoqueMovimentacao.MovimentoCancelado);
                con.AdicionarParametros("@DataMovimentacao", estoqueMovimentacao.DataMovimentacao);
                con.AdicionarParametros("@FornecedorId", estoqueMovimentacao.FornecedorId);
                con.AdicionarParametros("@EmpresaId", estoqueMovimentacao.EmpresaId);
                con.AdicionarParametros("@UsuarioId", estoqueMovimentacao.UsuarioId);
                con.AdicionarParametros("@ClienteId", estoqueMovimentacao.ClienteId);

                id = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_InserirEstoqueMovimentacao"));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }

        public MLEstoqueMovimentacao Consultar(MLEstoqueMovimentacao modelo)
        {
            throw new NotImplementedException();
        }

        public List<MLEstoqueMovimentacao> Listar(MLEstoqueMovimentacao modelo)
        {
            throw new NotImplementedException();
        }
    }
}
