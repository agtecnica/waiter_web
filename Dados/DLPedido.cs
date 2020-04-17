using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Dados
{
    public class DLPedido : IMetodos<MLPedido>
    {
        public MLEstoqueMovimentacao EstoqueMovimentacao { get; private set; }

        public int Adicionar(MLPedido objetoModelo)
        {
            DlConexao objDlConexao = new DlConexao();
            objDlConexao.limparParametros();
            int ret = 0;

            objDlConexao.AdicionarParametros("@DataEmissao", objetoModelo.DataEmissao);
            objDlConexao.AdicionarParametros("@Tipo", objetoModelo.Tipo);
            objDlConexao.AdicionarParametros("@NotaFiscal", objetoModelo.NotaFiscal);
            objDlConexao.AdicionarParametros("@NumeroParcelas", objetoModelo.NrParcelas);
            if (objetoModelo.StatusPedidoId > 0)
                objDlConexao.AdicionarParametros("@StatusId", objetoModelo.StatusPedidoId);
            else
                objDlConexao.AdicionarParametros("@StatusId", 1);
            objDlConexao.AdicionarParametros("@FornecedorId", objetoModelo.FornecedorId);
            objDlConexao.AdicionarParametros("@TipoPagamentoId", objetoModelo.TipoPagamentoId);
            objDlConexao.AdicionarParametros("@ValorTotal", objetoModelo.ValorTotal);
            objDlConexao.AdicionarParametros("@DataCancelamento", objetoModelo.DataCancelamento);
            objDlConexao.AdicionarParametros("@CompradorId", objetoModelo.UsuarioId);
            objDlConexao.AdicionarParametros("@OrcamentoFornecedor", objetoModelo.NrOrcamentoFornecedor);
            objDlConexao.AdicionarParametros("@ValidadeProposta", objetoModelo.ValidadeProposta);
            objDlConexao.AdicionarParametros("@Frete", objetoModelo.Frete);
            objDlConexao.AdicionarParametros("@TransportadorId", objetoModelo.TransportadorId);
            objDlConexao.AdicionarParametros("@ValorFrete", objetoModelo.ValorFrete);
            objDlConexao.AdicionarParametros("@IsCotacao", objetoModelo.IsCotacao);
            objDlConexao.AdicionarParametros("@ClienteId", objetoModelo.ClienteId);

            if (objetoModelo.CondicaoPgtoId > 0)
                objDlConexao.AdicionarParametros("@CondicaoPgtoId", objetoModelo.CondicaoPgtoId);
            if (objetoModelo.DataInicioPgto != DateTime.MinValue)
                objDlConexao.AdicionarParametros("@DataInicialPgto", objetoModelo.DataInicioPgto);
            objDlConexao.AdicionarParametros("@Observacao", objetoModelo.Observacao);
            objDlConexao.AdicionarParametros("@Desconto", objetoModelo.Desconto);
            objDlConexao.AdicionarParametros("@Acrescimo", objetoModelo.Acrescimo);
            if (objetoModelo.CaixaId > 0)
                objDlConexao.AdicionarParametros("@CaixaId", objetoModelo.CaixaId);
            //objDlConexao.AdicionarParametros("@ValorTroco", objetoModelo.ValorTroco);
            if (objetoModelo.ControleMovimentoCaixaId > 0)
                objDlConexao.AdicionarParametros("@ControleMovimentoCaixaId", objetoModelo.ControleMovimentoCaixaId);
            objDlConexao.AdicionarParametros("@ValorParcelas", objetoModelo.ValorParcelas);

            ret = Convert.ToInt32(objDlConexao.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_InserirPedido"));// "Cliente cadastrado com sucesso!"



            objDlConexao.limparParametros();
            objDlConexao.AdicionarParametros("@PedidoId", objetoModelo.PedidoId);
            objDlConexao.ExecutarManipulacao(CommandType.StoredProcedure, "P_Excluir_ItensPedido");//veirifica se existe itens e exclui

            if (objetoModelo.listaPedidoItem == null)
                objetoModelo.listaPedidoItem = new List<MLPedidoItem>();

            for (int i = 0; i < objetoModelo.listaPedidoItem.Count; i++)
            {
                objDlConexao.limparParametros();
                objDlConexao.AdicionarParametros("@ProdutoId", objetoModelo.listaPedidoItem[i].ProdutoId);
                objDlConexao.AdicionarParametros("@PedidoId", ret);
                objDlConexao.AdicionarParametros("@Quantidade", objetoModelo.listaPedidoItem[i].Quantidade);
                objDlConexao.AdicionarParametros("@SubTotal", objetoModelo.listaPedidoItem[i].SubTotal);
                objDlConexao.AdicionarParametros("@DiasPrevisaoEntrega", objetoModelo.listaPedidoItem[i].DiasPrevisaoEntrega);
                if (objetoModelo.listaPedidoItem[i].DataEntrega != null && objetoModelo.listaPedidoItem[i].DataEntrega != DateTime.MinValue)
                    objDlConexao.AdicionarParametros("@DataEntrega", objetoModelo.listaPedidoItem[i].DataEntrega);
                objDlConexao.AdicionarParametros("@ObservacaoItem", objetoModelo.listaPedidoItem[i].ObservacaoItem);

                Convert.ToInt32(objDlConexao.ExecutarManipulacao(CommandType.StoredProcedure, "[dbo].[P_InserirItensPedido]"));
            }

            return ret;
        }

        public List<MLPedidoContasPagar> ListarPedidoContasPagar(int pedidoid = 0, string tipoPedido = "C")
        {
            DlConexao con = new DlConexao();
            DataTable dt = new DataTable();
            List<MLPedidoContasPagar> lstPedidoContasPagar = new List<MLPedidoContasPagar>();

            try
            {
                con.limparParametros();
                if (pedidoid > 0)
                    con.AdicionarParametros("@PedidoId", pedidoid);
                con.AdicionarParametros("@TipoPedido", tipoPedido);
                dt = con.ExecutarConsulta(CommandType.StoredProcedure, "P_ListarPedidoContasPagar");

                for (int p = 0; p < dt.Rows.Count; p++)
                {
                    MLPedidoContasPagar pedidoContasPagar = new MLPedidoContasPagar();
                    pedidoContasPagar = Genericos.Popular<MLPedidoContasPagar>(dt, p);

                    lstPedidoContasPagar.Add(pedidoContasPagar);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                    con.Dispose();
                con = null;
            }
            return lstPedidoContasPagar;
        }

        public void Atualizar(MLPedido modelo)
        {
            DlConexao objDlConexao = new DlConexao();
            objDlConexao.limparParametros();

            if (modelo.listaPedidoItem != null)
            {

                objDlConexao.limparParametros();
                objDlConexao.AdicionarParametros("@PedidoId", modelo.PedidoId);
                objDlConexao.ExecutarManipulacao(CommandType.StoredProcedure, "P_Excluir_ItensPedido");//veirifica se existe itens e exclui

                for (int i = 0; i < modelo.listaPedidoItem.Count; i++)
                {
                    objDlConexao.limparParametros();
                    objDlConexao.AdicionarParametros("@ProdutoId", modelo.listaPedidoItem[i].ProdutoId);
                    objDlConexao.AdicionarParametros("@PedidoId", modelo.PedidoId);
                    objDlConexao.AdicionarParametros("@Quantidade", modelo.listaPedidoItem[i].Quantidade);
                    objDlConexao.AdicionarParametros("@SubTotal", modelo.listaPedidoItem[i].SubTotal);
                    if (modelo.listaPedidoItem[i].DiasPrevisaoEntrega != null)
                        objDlConexao.AdicionarParametros("@DiasPrevisaoEntrega", modelo.listaPedidoItem[i].DiasPrevisaoEntrega);
                    if (modelo.listaPedidoItem[i].DataEntrega != null && modelo.listaPedidoItem[i].DataEntrega != DateTime.MinValue)
                        objDlConexao.AdicionarParametros("@DataEntrega", modelo.listaPedidoItem[i].DataEntrega);
                    objDlConexao.AdicionarParametros("@ObservacaoItem", modelo.listaPedidoItem[i].ObservacaoItem);
                    //objDlConexao.AdicionarParametros("@Tipo", modelo.Tipo);

                    objDlConexao.ExecutarManipulacao(CommandType.StoredProcedure, "[dbo].[P_InserirItensPedido]");
                }
            }

            objDlConexao.limparParametros();
            objDlConexao.AdicionarParametros("@PedidoId", modelo.PedidoId);

            if (modelo.Tipo == "C")//compra
            {
                //objDlConexao.AdicionarParametros("@DataEmissao", modelo.DataEmissao);
                objDlConexao.AdicionarParametros("@Tipo", modelo.Tipo);
                objDlConexao.AdicionarParametros("@NotaFiscal", modelo.NotaFiscal);
                //objDlConexao.AdicionarParametros("@NumeroParcelas", modelo.NumeroParcelas);
                objDlConexao.AdicionarParametros("@StatusId", modelo.StatusPedidoId);
                //objDlConexao.AdicionarParametros("@FornecedorId", modelo.FornecedorId);
                //objDlConexao.AdicionarParametros("@TipoPagamentoId", modelo.TipoPagamentoId);
                //objDlConexao.AdicionarParametros("@ValorTotal", modelo.ValorTotal);
                objDlConexao.AdicionarParametros("@DataCancelamento", modelo.DataCancelamento);
                //objDlConexao.AdicionarParametros("@CompradorId", modelo.CompradorId);
                objDlConexao.AdicionarParametros("@OrcamentoFornecedor", modelo.NrOrcamentoFornecedor);
                objDlConexao.AdicionarParametros("@ValidadeProposta", modelo.ValidadeProposta);
                //objDlConexao.AdicionarParametros("@Frete", modelo.Frete);
                //objDlConexao.AdicionarParametros("@TransportadorId", modelo.TransportadorId);
                objDlConexao.AdicionarParametros("@ValorFrete", modelo.ValorFrete);
                objDlConexao.AdicionarParametros("@IsCotacao", modelo.IsCotacao);
                //objDlConexao.AdicionarParametros("@CondicaoPgtoId", modelo.CondicaoPgtoId);
                //objDlConexao.AdicionarParametros("@DataInicialPgto", modelo.DataInicioPgto);
                objDlConexao.AdicionarParametros("@Observacao", modelo.Observacao);
                //objDlConexao.AdicionarParametros("@Desconto", objetoModelo.ValorDesconto);
            }
            else if (modelo.Tipo == "V")//venda
            {
                //objDlConexao.AdicionarParametros("@DataEmissao", modelo.DataEmissao);
                objDlConexao.AdicionarParametros("@Tipo", modelo.Tipo);
                //objDlConexao.AdicionarParametros("@NotaFiscal", modelo.NotaFiscal);
                //objDlConexao.AdicionarParametros("@NumeroParcelas", modelo.NrParcelas);
                objDlConexao.AdicionarParametros("@StatusId", modelo.StatusPedidoId);
                //objDlConexao.AdicionarParametros("@FornecedorId", modelo.FornecedorId);
                //objDlConexao.AdicionarParametros("@TipoPagamentoId", modelo.TipoPagamentoId);
                objDlConexao.AdicionarParametros("@ValorTotal", modelo.ValorTotal);
                if(modelo.DataPagto != DateTime.MinValue)
                objDlConexao.AdicionarParametros("@DataPagamento", modelo.DataPagto);
                //objDlConexao.AdicionarParametros("@DataCancelamento", modelo.DataCancelamento);
                //objDlConexao.AdicionarParametros("@CompradorId", modelo.UsuarioId);
                //objDlConexao.AdicionarParametros("@OrcamentoFornecedor", modelo.NrOrcamentoFornecedor);
                //objDlConexao.AdicionarParametros("@ValidadeProposta", modelo.ValidadeProposta);
                //objDlConexao.AdicionarParametros("@Frete", modelo.Frete);
                //objDlConexao.AdicionarParametros("@TransportadorId", modelo.TransportadorId);
                //objDlConexao.AdicionarParametros("@ValorFrete", modelo.ValorFrete);
                //objDlConexao.AdicionarParametros("@IsCotacao", modelo.IsCotacao);
                //objDlConexao.AdicionarParametros("@CondicaoPgtoId", modelo.CondicaoPgtoId);
                //if (modelo.DataInicioPgto != DateTime.MinValue)
                //    objDlConexao.AdicionarParametros("@DataInicialPgto", modelo.DataInicioPgto);
                //objDlConexao.AdicionarParametros("@Observacao", modelo.Observacao);
                if (modelo.CpfCnpj != null && modelo.CpfCnpj.Length > 10)
                    objDlConexao.AdicionarParametros("@CpfCnpj", modelo.CpfCnpj);
                objDlConexao.AdicionarParametros("@ClienteId", modelo.ClienteId);
                if (modelo.Desconto == null)
                    objDlConexao.AdicionarParametros("@Desconto", 0);
                else
                    objDlConexao.AdicionarParametros("@Desconto", modelo.Desconto);

                if (modelo.Acrescimo == null)
                    objDlConexao.AdicionarParametros("@Acrescimo", 0);
                else
                    objDlConexao.AdicionarParametros("@Acrescimo", modelo.Acrescimo);
                objDlConexao.AdicionarParametros("@CaixaId", modelo.CaixaId);
                if (modelo.ControleMovimentoCaixaId > 0)
                    objDlConexao.AdicionarParametros("@ControleMovimentoCaixaId", modelo.ControleMovimentoCaixaId);


            }


            objDlConexao.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_AtualizarPedido");// "Cliente alterado com sucesso!"

        }

        public List<MLResumoMovimento> ListarDetalheFaturamento(int tipo, int ControleMovimentoCaixaId)
        {
            throw new NotImplementedException();
        }

        public List<MLDetalheMovimento> ListarDetalheMovimento(int tipo, int ControleMovimentoCaixaId)
        {
            DlConexao con = new DlConexao();
            DataTable dt = new DataTable();
            List<MLDetalheMovimento> listDetalheMovimento = new List<MLDetalheMovimento>();
            try
            {
                con.limparParametros();
                con.AdicionarParametros("@tipo", tipo);
                con.AdicionarParametros("@ControleMovimentoCaixaId", ControleMovimentoCaixaId);
                dt = con.ExecutarConsulta(CommandType.StoredProcedure, "P_ListarDetalheMovimento");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MLDetalheMovimento mLDetalheMovimento = new MLDetalheMovimento();

                    mLDetalheMovimento = Genericos.Popular<MLDetalheMovimento>(dt, i);
                    listDetalheMovimento.Add(mLDetalheMovimento);
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
            return listDetalheMovimento;
        }

        public MLPedido Consultar(MLPedido modelo)
        {
            DlConexao con = new DlConexao();
            DataTable dt = new DataTable();
            MLPedido mlpedido = new MLPedido();
            try
            {
                con.limparParametros();
                con.AdicionarParametros("@PedidoId", modelo.PedidoId);
                con.AdicionarParametros("@Tipo", modelo.Tipo);
                dt = con.ExecutarConsulta(CommandType.StoredProcedure, "P_ListarPedido");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    mlpedido = new MLPedido();
                    mlpedido = Genericos.Popular<MLPedido>(dt, i);

                    if (mlpedido.Usuario == null) mlpedido.Usuario = new MLUsuario();
                    if (mlpedido.Fornecedor == null) mlpedido.Fornecedor = new MLFornecedor();
                    if (mlpedido.Transportador == null) mlpedido.Transportador = new MLTransportador();
                    if (mlpedido.CondicaoPagamento == null) mlpedido.CondicaoPagamento = new MLCondicaoPagamento();

                    mlpedido.Usuario.Nome = Convert.ToString(dt.Rows[i].ItemArray[26]);
                    mlpedido.Fornecedor.NomeRazaoSocial = Convert.ToString(dt.Rows[i].ItemArray[27]);
                    mlpedido.Transportador.NomeRazaoSocial = Convert.ToString(dt.Rows[i].ItemArray[28]);
                    mlpedido.CondicaoPagamento.FormaPgtoEntradaDesc = Convert.ToString(dt.Rows[i].ItemArray[29]);


                    con.limparParametros();
                    con.AdicionarParametros("@PedidoId", mlpedido.PedidoId);
                    DataTable dtCompraItens = con.ExecutarConsulta(CommandType.StoredProcedure, "dbo.P_ListarPedidoItens");

                    if (mlpedido.listaPedidoItem == null)
                        mlpedido.listaPedidoItem = new List<MLPedidoItem>();

                    for (int ci = 0; ci < dtCompraItens.Rows.Count; ci++)
                    {
                        MLPedidoItem compraItem = new MLPedidoItem();
                        compraItem = Genericos.Popular<MLPedidoItem>(dtCompraItens, ci);

                        con.limparParametros();
                        con.AdicionarParametros("@ProdutoId", compraItem.ProdutoId);
                        DataTable dtProduto = con.ExecutarConsulta(CommandType.StoredProcedure, "dbo.P_ListarProduto");

                        for (int p = 0; p < dtProduto.Rows.Count; p++)
                        {
                            compraItem.Produto.ProdutoId = Convert.ToInt32(dtProduto.Rows[p].ItemArray[0]);
                            compraItem.Produto.Descricao = Convert.ToString(dtProduto.Rows[p].ItemArray[1]);
                            compraItem.Produto.ValorVenda = Convert.ToDecimal(dtProduto.Rows[p].ItemArray[5]);
                            compraItem.Produto.CodigoBarras = Convert.ToString(dtProduto.Rows[p].ItemArray[6]);
                        }

                        mlpedido.listaPedidoItem.Add(compraItem);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                    con.Dispose();
                con = null;
            }

            return mlpedido;
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<MLPedido> Listar(MLPedido modelo)
        {
            DlConexao con = new DlConexao();
            DataTable dt = new DataTable();
            List<MLPedido> lst = new List<MLPedido>();
            try
            {
                con.limparParametros();
                if (modelo != null)
                {
                    if (modelo.PedidoId > 0)
                        con.AdicionarParametros("@PedidoId", modelo.PedidoId);
                    if (modelo.UsuarioId > 0)
                        con.AdicionarParametros("@UsuarioId", modelo.UsuarioId);
                    if (modelo.FornecedorId > 0)
                        con.AdicionarParametros("@FornecedorId", modelo.FornecedorId);
                    if (modelo.ControleMovimentoCaixaId > 0)
                        con.AdicionarParametros("@ControleMovimentoCaixaId", modelo.ControleMovimentoCaixaId);
                    con.AdicionarParametros("@Tipo", modelo.Tipo);
                }
                dt = con.ExecutarConsulta(CommandType.StoredProcedure, "P_ListarPedido");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MLPedido pedido = new MLPedido();
                    pedido = Genericos.Popular<MLPedido>(dt, i);

                    if (pedido.Usuario == null) pedido.Usuario = new MLUsuario();
                    if (pedido.Fornecedor == null) pedido.Fornecedor = new MLFornecedor();
                    if (pedido.Transportador == null) pedido.Transportador = new MLTransportador();
                    if (pedido.CondicaoPagamento == null) pedido.CondicaoPagamento = new MLCondicaoPagamento();

                    pedido.Usuario.Nome = Convert.ToString(dt.Rows[i].ItemArray[26]);
                    pedido.Fornecedor.NomeRazaoSocial = Convert.ToString(dt.Rows[i].ItemArray[27]);
                    pedido.Transportador.NomeRazaoSocial = Convert.ToString(dt.Rows[i].ItemArray[28]);
                    pedido.CondicaoPagamento.FormaPgtoEntradaDesc = Convert.ToString(dt.Rows[i].ItemArray[29]);


                    con.limparParametros();
                    con.AdicionarParametros("@PedidoId", pedido.PedidoId);
                    DataTable dtCompraItens = con.ExecutarConsulta(CommandType.StoredProcedure, "dbo.P_ListarPedidoItens");

                    if (pedido.listaPedidoItem == null)
                        pedido.listaPedidoItem = new List<MLPedidoItem>();

                    for (int ci = 0; ci < dtCompraItens.Rows.Count; ci++)
                    {
                        MLPedidoItem compraItem = new MLPedidoItem();
                        compraItem = Genericos.Popular<MLPedidoItem>(dtCompraItens, ci);

                        con.limparParametros();
                        con.AdicionarParametros("@ProdutoId", compraItem.ProdutoId);
                        DataTable dtProduto = con.ExecutarConsulta(CommandType.StoredProcedure, "dbo.P_ListarProduto");

                        for (int p = 0; p < dtProduto.Rows.Count; p++)
                        {
                            compraItem.PedidoItemId = Convert.ToInt32(dtProduto.Rows[p].ItemArray[0]);
                            compraItem.Produto.ProdutoId = Convert.ToInt32(dtProduto.Rows[p].ItemArray[0]);
                            compraItem.Produto.Descricao = Convert.ToString(dtProduto.Rows[p].ItemArray[1]);
                            compraItem.Produto.CodigoBarras = Convert.ToString(dtProduto.Rows[p].ItemArray[6]);
                            compraItem.Produto.ValorVenda = Convert.ToDecimal(dtProduto.Rows[p].ItemArray[5]);
                        }

                        pedido.listaPedidoItem.Add(compraItem);
                    }

                    lst.Add(pedido);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                    con.Dispose();
                con = null;
            }

            return lst;
        }
        public List<MLPgtoEntrada> ListarFormaPgtoPedido(int pedidoId)
        {
            List<MLPgtoEntrada> listMLPedido = new List<MLPgtoEntrada>();
            DlConexao objDlConexao = new DlConexao();

            objDlConexao.limparParametros();
            objDlConexao.AdicionarParametros("@PedidoId", pedidoId);

            DataTable dt = objDlConexao.ExecutarConsulta(CommandType.StoredProcedure, "P_ListarFormaPgtoPedido");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //var cliente = Genericos.Popular<MlPedido>(dt, i);
                MLPgtoEntrada objMlPgtoEntrada = new MLPgtoEntrada();

                objMlPgtoEntrada.PedidoId = Convert.ToInt32(dt.Rows[i].ItemArray[0]);
                objMlPgtoEntrada.FormaPgtoId = Convert.ToInt32(dt.Rows[i].ItemArray[1]);
                objMlPgtoEntrada.Valor = Convert.ToDecimal(dt.Rows[i].ItemArray[2]);
                listMLPedido.Add(objMlPgtoEntrada);
            }

            return listMLPedido;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public void InserirFormaPgtoPedido(List<MLPgtoEntrada> lstMLPgtoEntrada)
        {
            Int32 pedidoId = 0;

            DlConexao objDlConexao = new DlConexao();
            try
            {
                for (int i = 0; i < lstMLPgtoEntrada.Count; i++)//Carrega formas de pagamento
                {
                    objDlConexao.limparParametros();
                    objDlConexao.AdicionarParametros("@PedidoId", lstMLPgtoEntrada[i].PedidoId);
                    objDlConexao.AdicionarParametros("@FormaPgtoEntradaId", lstMLPgtoEntrada[i].FormaPgtoId);
                    objDlConexao.AdicionarParametros("@Valor", lstMLPgtoEntrada[i].Valor);

                    objDlConexao.ExecutarManipulacao(CommandType.StoredProcedure, "P_InserirFormaPgtoPedido");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
