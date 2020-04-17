using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLOrdemServico : IMetodos<MLOrdemServico>
    {
        public int Adicionar(MLOrdemServico ordemServico)
        {
            DlConexao con = new DlConexao();
            var ordemServicoId = 0;

            try
            {
                con.limparParametros();

                //con.AdicionarParametros("@OrdemServicoId", ordemServico.OrdemServicoId);
                con.AdicionarParametros("@Descricao", ordemServico.Descricao);
                con.AdicionarParametros("@DataAbertura", ordemServico.DataAbertura);
                con.AdicionarParametros("@DataExecucao", ordemServico.DataExecucao);
                con.AdicionarParametros("@StatusId", ordemServico.StatusId);
                con.AdicionarParametros("@ValorTotal", ordemServico.ValorTotal);
                con.AdicionarParametros("@NrParcelas", ordemServico.NrParcelas);
                con.AdicionarParametros("@Observacao", ordemServico.Observacao);

                ordemServicoId = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_InserirOrdemServico"));

                for (int i = 0; i < ordemServico.ListaServicos.Count; i++)
                {
                    con.limparParametros();
                    con.AdicionarParametros("@OrdemServicoId", ordemServico.OrdemServicoId);
                    con.AdicionarParametros("@ServicoId", ordemServico.ListaServicos[i].ServicoId);

                    ordemServicoId = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_InserirServicoOS"));
                }

                for (int i = 0; i < ordemServico.ListaProdutos.Count; i++)
                {
                    con.limparParametros();
                    con.AdicionarParametros("@OrdemServicoId", ordemServico.OrdemServicoId);
                    con.AdicionarParametros("@ProdutoId", ordemServico.ListaProdutos[i].ProdutoId);
                    con.AdicionarParametros("@Quantidade", ordemServico.ListaProdutos[i].Quantidade);
                    con.AdicionarParametros("@SubTotal", ordemServico.ListaProdutos[i].SubTotal);

                    ordemServicoId = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_InserirProdutoOS"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ordemServicoId;
        }

        public void Atualizar(MLOrdemServico ordemServico)
        {
            DlConexao con = new DlConexao();

            try
            {
                con.limparParametros();

                if (ordemServico.OrdemServicoId > 0)
                    con.AdicionarParametros("@OrdemServicoId", ordemServico.OrdemServicoId);

                con.AdicionarParametros("@Descricao", ordemServico.Descricao);

                if (ordemServico.DataAbertura != DateTime.MinValue)
                    con.AdicionarParametros("@DataAbertura", ordemServico.DataAbertura);
                if (ordemServico.DataExecucao != DateTime.MinValue)
                    con.AdicionarParametros("@DataExecucao", ordemServico.DataExecucao);
                if (ordemServico.StatusId > 0)
                    con.AdicionarParametros("@StatusId", ordemServico.StatusId);

                con.AdicionarParametros("@ValorTotal", ordemServico.ValorTotal);
                con.AdicionarParametros("@NrParcelas", ordemServico.NrParcelas);
                con.AdicionarParametros("@Observacao", ordemServico.Observacao);

                con.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_AtualizarProdutos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MLOrdemServico Consultar(MLOrdemServico modelo)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<MLOrdemServico> Listar(MLOrdemServico ordemServico)
        {
            DlConexao con = new DlConexao();
            List<MLOrdemServico> lstMLOrdemServico = new List<MLOrdemServico>();

            try
            {
                con.limparParametros();

                if (ordemServico.OrdemServicoId > 0)
                    con.AdicionarParametros("@OrdemServicoId", ordemServico.OrdemServicoId);

                con.AdicionarParametros("@Descricao", ordemServico.Descricao);

                if (ordemServico.DataAbertura != DateTime.MinValue)
                    con.AdicionarParametros("@DataAbertura", ordemServico.DataAbertura);
                if (ordemServico.DataExecucao != DateTime.MinValue)
                    con.AdicionarParametros("@DataExecucao", ordemServico.DataExecucao);
                if (ordemServico.StatusId > 0)
                    con.AdicionarParametros("@StatusId", ordemServico.StatusId);

                con.AdicionarParametros("@ValorTotal", ordemServico.ValorTotal);
                con.AdicionarParametros("@NrParcelas", ordemServico.NrParcelas);
                con.AdicionarParametros("@Observacao", ordemServico.Observacao);

                DataTable dt = con.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarOrdemServico]");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ordemServico = new MLOrdemServico();
                    ordemServico = Genericos.Popular<MLOrdemServico>(dt, i);
                    lstMLOrdemServico.Add(ordemServico);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                    con = null;
            }
            return lstMLOrdemServico;
        }
    }
}
