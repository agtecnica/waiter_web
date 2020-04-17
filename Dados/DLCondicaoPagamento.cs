using Modelo;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dados
{
    public class DLCondicaoPagamento
    {
        public string Adicionar(MLCondicaoPagamento objMlFormaPagamento)
        {
            DlConexao con = new DlConexao();
            String retorno = "";

            try
            {
                con.limparParametros();

                //objDLConexao.adicionarParametros("@CondicaoPgtoId", objMlFormaPagamento.FormaPgtoId);

                con.AdicionarParametros("@CondicaoPgtoDesc", objMlFormaPagamento.CondicaoPgtoDescricao);
                con.AdicionarParametros("@NumeroParcelas", objMlFormaPagamento.NrParcelas);
                con.AdicionarParametros("@DiasEntrada", objMlFormaPagamento.DiasParaEntrada);
                con.AdicionarParametros("@Intervalo", objMlFormaPagamento.Intervalo);
                con.AdicionarParametros("@DiaVencimento", objMlFormaPagamento.Dia1Vencimento);
                con.AdicionarParametros("@FormaPgtoEntradaId", objMlFormaPagamento.FormaPgtoEntradaId);
                con.AdicionarParametros("@TipoPedido", objMlFormaPagamento.Tipopedido);

                retorno = con.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_InserirCondicaoPagamento").ToString();

                if (retorno == "")
                    retorno = "Forma de Pagamento cadastrada com sucesso!";

            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        public string Atualizar(MLCondicaoPagamento objMlFormaPagamento)
        {
            DlConexao objDLConexao = new DlConexao();
            string retorno = "";

            try
            {
                objDLConexao.limparParametros();

                objDLConexao.AdicionarParametros("@CondicaoPgtoId", objMlFormaPagamento.CondicaoPgtoId);
                objDLConexao.AdicionarParametros("@CondicaoPgtoDesc", objMlFormaPagamento.CondicaoPgtoDescricao);
                objDLConexao.AdicionarParametros("@NumeroParcelas", Convert.ToInt32(objMlFormaPagamento.NrParcelas));
                objDLConexao.AdicionarParametros("@DiasEntrada", Convert.ToInt32(objMlFormaPagamento.DiasParaEntrada));
                objDLConexao.AdicionarParametros("@Intervalo", Convert.ToInt32(objMlFormaPagamento.Intervalo));
                objDLConexao.AdicionarParametros("@DiaVencimento", Convert.ToDateTime(objMlFormaPagamento.Dia1Vencimento));
                objDLConexao.AdicionarParametros("@FormaPgtoEntradaId", Convert.ToInt32(objMlFormaPagamento.FormaPgtoEntradaId));
                objDLConexao.AdicionarParametros("@TipoPedido", objMlFormaPagamento.Tipopedido);

                retorno = objDLConexao.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_AlterarCondicaoPagamento").ToString();

                if (retorno == objMlFormaPagamento.CondicaoPgtoId.ToString())
                    retorno = "Forma de Pagamento Alterado com sucesso!";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDLConexao != null)
                    objDLConexao = null;
            }

            return retorno;
        }

        public string Excluir(int FormaPgtoId)
        {
            DlConexao objDLConexao = new DlConexao();
            string retorno = "";

            try
            {
                objDLConexao.limparParametros();

                objDLConexao.AdicionarParametros("@FormaPgtoId", FormaPgtoId);
                retorno = objDLConexao.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_ExcluirCondicaoPagamento").ToString();

                if (retorno == FormaPgtoId.ToString())
                    retorno = "Condição de Pagamento excluída com sucesso!";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDLConexao != null)
                    objDLConexao = null;
            }

            return retorno;
        }

        public List<MLCondicaoPagamento> ListarCondicaoPgto(MLPedido.TipoPedido tipoPedido = MLPedido.TipoPedido.COMPRA)
        {
            DlConexao objDLConexao = new DlConexao();

            List<MLCondicaoPagamento> lstMlFormaPagamento = new List<MLCondicaoPagamento>();
            DataTable dt = new DataTable();
            try
            {
                objDLConexao.limparParametros();
                objDLConexao.AdicionarParametros("@TipoPedido", tipoPedido);
                dt = objDLConexao.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarCondicaoPagamento]");

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        MLCondicaoPagamento objMlFormaPagamento = new MLCondicaoPagamento();

                        objMlFormaPagamento.CondicaoPgtoId = Convert.ToInt32(dt.Rows[i].ItemArray[0]);
                        objMlFormaPagamento.CondicaoPgtoDescricao = Convert.ToString(dt.Rows[i].ItemArray[1]);
                        objMlFormaPagamento.NrParcelas = Convert.ToInt32(dt.Rows[i].ItemArray[2]);
                        objMlFormaPagamento.DiasParaEntrada = Convert.ToInt32(dt.Rows[i].ItemArray[3]);
                        objMlFormaPagamento.Intervalo = Convert.ToInt32(dt.Rows[i].ItemArray[4]);
                        objMlFormaPagamento.Dia1Vencimento = Convert.ToDateTime(dt.Rows[i].ItemArray[5]);
                        if (!String.IsNullOrEmpty(dt.Rows[i].ItemArray[6].ToString()))
                            objMlFormaPagamento.FormaPgtoEntradaId = Convert.ToInt32(dt.Rows[i].ItemArray[6]);
                        if (!String.IsNullOrEmpty(dt.Rows[i].ItemArray[7].ToString()))
                            objMlFormaPagamento.FormaPgtoEntradaDesc = Convert.ToString(dt.Rows[i].ItemArray[7]);

                        lstMlFormaPagamento.Add(objMlFormaPagamento);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDLConexao != null)
                    objDLConexao = null;
            }
            return lstMlFormaPagamento;
        }

        public List<MLFormaPgto> ListarFormaPagamento(int FormaPgtoId = 0)
        {
            DlConexao objDLConexao = new DlConexao();
            DataTable dt = new DataTable();
            List<MLFormaPgto> lst = new List<MLFormaPgto>();
            try
            {
                objDLConexao.limparParametros();

                dt = objDLConexao.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarFormaPgto]");

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        MLFormaPgto objMlFormaPagamento = new MLFormaPgto();
                        objMlFormaPagamento.FormaPgtoId = Convert.ToInt32(dt.Rows[i].ItemArray[0]);
                        objMlFormaPagamento.Descricao = Convert.ToString(dt.Rows[i].ItemArray[1]);
                        lst.Add(objMlFormaPagamento);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDLConexao != null)
                    objDLConexao = null;
            }

            return lst;
        }

        public MLCondicaoPagamento ConsultarCondicaoPagamento(int FormaPgtoId)
        {
            DlConexao objDLConexao = new DlConexao();
            MLCondicaoPagamento condicaoPgto = new MLCondicaoPagamento();
            DataTable dt = new DataTable();

            try
            {
                objDLConexao.limparParametros();

                objDLConexao.AdicionarParametros("@CondicaoPgtoId", FormaPgtoId);
                dt = objDLConexao.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarCondicaoPagamento]");

                if (dt != null)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        condicaoPgto.CondicaoPgtoId = Convert.ToInt32(dt.Rows[i].ItemArray[0]);
                        condicaoPgto.CondicaoPgtoDescricao = Convert.ToString(dt.Rows[i].ItemArray[1]);
                        condicaoPgto.NrParcelas = Convert.ToInt32(dt.Rows[i].ItemArray[2]);
                        condicaoPgto.DiasParaEntrada = Convert.ToInt32(dt.Rows[i].ItemArray[3]);
                        condicaoPgto.Intervalo = Convert.ToInt32(dt.Rows[i].ItemArray[4]);
                        condicaoPgto.Dia1Vencimento = Convert.ToDateTime(dt.Rows[i].ItemArray[5]);
                        if (!String.IsNullOrEmpty(dt.Rows[i].ItemArray[6].ToString()))
                            condicaoPgto.FormaPgtoEntradaId = Convert.ToInt32(dt.Rows[i].ItemArray[6]);
                        if (!String.IsNullOrEmpty(dt.Rows[i].ItemArray[7].ToString()))
                            condicaoPgto.FormaPgtoEntradaDesc = Convert.ToString(dt.Rows[i].ItemArray[7]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDLConexao != null)
                    objDLConexao = null;
            }

            return condicaoPgto;
        }

        public List<MLCondicaoPagamento> PesquisarFormaPagamento(string formaPgto)
        {
            DlConexao objDLConexao = new DlConexao();
            List<MLCondicaoPagamento> listMlFormaPagamento = new List<MLCondicaoPagamento>();
            DataTable dt = new DataTable();
            try
            {
                objDLConexao.limparParametros();

                objDLConexao.AdicionarParametros("@FormaPagamento", formaPgto);
                dt = objDLConexao.ExecutarConsulta(CommandType.StoredProcedure, "[Pedido].[PS_ListarCondicaoPagamentoPorNome]");

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        MLCondicaoPagamento objMlFormaPagamento = new MLCondicaoPagamento();

                        objMlFormaPagamento.CondicaoPgtoId = Convert.ToInt32(dt.Rows[i].ItemArray[0]);
                        objMlFormaPagamento.CondicaoPgtoDescricao = Convert.ToString(dt.Rows[i].ItemArray[1]);
                        objMlFormaPagamento.NrParcelas = Convert.ToInt32(dt.Rows[i].ItemArray[2]);
                        objMlFormaPagamento.DiasParaEntrada = Convert.ToInt32(dt.Rows[i].ItemArray[3]);
                        objMlFormaPagamento.Intervalo = Convert.ToInt32(dt.Rows[i].ItemArray[4]);
                        objMlFormaPagamento.Dia1Vencimento = Convert.ToDateTime(dt.Rows[i].ItemArray[5]);
                        if (!String.IsNullOrEmpty(dt.Rows[i].ItemArray[6].ToString()))
                            objMlFormaPagamento.FormaPgtoEntradaId = Convert.ToInt32(dt.Rows[i].ItemArray[6]);
                        if (!String.IsNullOrEmpty(dt.Rows[i].ItemArray[7].ToString()))
                            objMlFormaPagamento.FormaPgtoEntradaDesc = Convert.ToString(dt.Rows[i].ItemArray[7]);

                        listMlFormaPagamento.Add(objMlFormaPagamento);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDLConexao != null)
                    objDLConexao = null;
            }

            return listMlFormaPagamento;
        }

        public List<MLCondicaoPagamento> ListarFormaPagamentoEntrada()
        {
            DlConexao objDLConexao = new DlConexao();

            List<MLCondicaoPagamento> lstMlFormaPagamento = new List<MLCondicaoPagamento>();
            DataTable dt = new DataTable();
            try
            {
                objDLConexao.limparParametros();
                dt = objDLConexao.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarFormaPgto]");

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        MLCondicaoPagamento objMlFormaPagamento = new MLCondicaoPagamento();

                        if (!String.IsNullOrEmpty(dt.Rows[i].ItemArray[0].ToString()))
                            objMlFormaPagamento.FormaPgtoEntradaId = Convert.ToInt32(dt.Rows[i].ItemArray[0]);
                        if (!String.IsNullOrEmpty(dt.Rows[i].ItemArray[1].ToString()))
                            objMlFormaPagamento.FormaPgtoEntradaDesc = Convert.ToString(dt.Rows[i].ItemArray[1]);

                        lstMlFormaPagamento.Add(objMlFormaPagamento);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDLConexao != null)
                    objDLConexao = null;
            }
            return lstMlFormaPagamento;
        }
    }
}
