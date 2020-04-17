using Modelo;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dados
{
    public class DLCaixa
    {
        public string AdcionarCaixa(String caixa)
        {
            DlConexao objDlConexao = new DlConexao();
            string ret = "";

            objDlConexao.limparParametros();
            objDlConexao.AdicionarParametros("@Descricao", caixa);
            objDlConexao.AdicionarParametros("@CaixaStatus", false);
            ret = objDlConexao.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.PI_Caixa").ToString();

            return ret;
        }

        public string ExcluirCaixa(int caixa)
        {
            DlConexao objDlConexao = new DlConexao();
            string ret = "";

            objDlConexao.limparParametros();
            objDlConexao.AdicionarParametros("@caixaId", caixa);
            ret = objDlConexao.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.PD_Caixa").ToString();


            return ret;
        }

        public List<MLCaixa> ListarCaixa(int caixaId = 0)
        {
            DlConexao objDlConexao = new DlConexao();
            DataTable dt = new DataTable();
            List<MLCaixa> lstMLCaixa = new List<MLCaixa>();

            objDlConexao.limparParametros();
            if (caixaId != 0) objDlConexao.AdicionarParametros("@caixaId", caixaId);

            dt = objDlConexao.ExecutarConsulta(CommandType.StoredProcedure, "dbo.P_ListarCaixa");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MLCaixa oblMLCaixa = new MLCaixa();

                oblMLCaixa.CaixaId = Convert.ToInt32(dt.Rows[i].ItemArray[0]);
                oblMLCaixa.CaixaDescricao = Convert.ToString(dt.Rows[i].ItemArray[1]);
                oblMLCaixa.Status = Convert.ToBoolean(dt.Rows[i].ItemArray[2]);
                if (!String.IsNullOrEmpty(dt.Rows[i].ItemArray[3].ToString()))
                    oblMLCaixa.Usuario.UsuarioId = Convert.ToInt32(dt.Rows[i].ItemArray[3]);
                if (!String.IsNullOrEmpty(dt.Rows[i].ItemArray[4].ToString()))
                    oblMLCaixa.Usuario.Nome = Convert.ToString(dt.Rows[i].ItemArray[4]);

                lstMLCaixa.Add(oblMLCaixa);
            }
            return lstMLCaixa;
        }

        public int AbrirFecharCaixa(MLCaixa objMLCaixa, bool isAbrirCaixa, MLControleMovimento ControleMovimento = null)
        {
            DlConexao objDlConexao = new DlConexao();
            DataTable dt = new DataTable();
            List<MLCaixa> lstMLCaixa = new List<MLCaixa>();

            objDlConexao.limparParametros();
            objDlConexao.AdicionarParametros("@CaixaId", objMLCaixa.CaixaId);
            objDlConexao.AdicionarParametros("@Descricao", objMLCaixa.CaixaDescricao);
            objDlConexao.AdicionarParametros("@UsuarioId", objMLCaixa.Usuario.UsuarioId);
            objDlConexao.AdicionarParametros("@CaixaStatusLogId", objMLCaixa.CaixaStatusLogId);
            objDlConexao.AdicionarParametros("@ControleMovimentoCaixaId", objMLCaixa.ControleMovimentoCaixaId);

            if (isAbrirCaixa)
            {
                objDlConexao.AdicionarParametros("@CaixaStatus", objMLCaixa.Status);
                objDlConexao.AdicionarParametros("@HoraAbertura", objMLCaixa.DataHoraAbertura);
                objDlConexao.AdicionarParametros("@TrocoInicial", objMLCaixa.SaldoInicial);
            }
            else
            {
                objDlConexao.AdicionarParametros("@CaixaStatus", objMLCaixa.Status);
                objDlConexao.AdicionarParametros("@HoraFechamento", objMLCaixa.DataHoraFechamento);
                objDlConexao.AdicionarParametros("@TrocoFinal", objMLCaixa.SaldoFinal);
                if (ControleMovimento != null)
                {
                    objDlConexao.AdicionarParametros("@MotivoDivergencia", ControleMovimento.MotivoDivergencia);
                    objDlConexao.AdicionarParametros("@ValorDivergencia", ControleMovimento.ValorDivergencia);
                }
            }
            var ret = objDlConexao.ExecutarManipulacao(CommandType.StoredProcedure, "AbrirFecharCaixa");

            int ControleMovimentoCaixaId = 0;
            if (ret != null)
                int.TryParse(ret.ToString(), out ControleMovimentoCaixaId);

            return ControleMovimentoCaixaId;
        }

        public List<MLCaixa> ListarCaixaLog()
        {
            DlConexao objDlConexao = new DlConexao();
            DataTable dt = new DataTable();
            List<MLCaixa> lstMLCaixa = new List<MLCaixa>();

            objDlConexao.limparParametros();

            dt = objDlConexao.ExecutarConsulta(CommandType.StoredProcedure, "Caixa.PS_CaixaLog");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MLCaixa oblMLCaixa = new MLCaixa();

                //oblMLCaixa.CaixaId = Convert.ToInt32(dt.Rows[i].ItemArray[0]);
                oblMLCaixa.CaixaDescricao = Convert.ToString(dt.Rows[i].ItemArray[0]);
                //oblMLCaixa.Status = Convert.ToBoolean(dt.Rows[i].ItemArray[2]);

                lstMLCaixa.Add(oblMLCaixa);
            }
            return lstMLCaixa;
        }

        public int BuscarMovimentoAtivo(int caixaid)
        {
            DlConexao objDlConexao = new DlConexao();
            DataTable dt = new DataTable();
            int movimentoId = 0;
            objDlConexao.limparParametros();
            objDlConexao.AdicionarParametros("@Caixaid", caixaid);
            dt = objDlConexao.ExecutarConsulta(CommandType.StoredProcedure, "P_BuscarMovimentoAtivo");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                movimentoId = Convert.ToInt32(dt.Rows[i].ItemArray[0]);
            }
            return movimentoId;
        }
    }
}
