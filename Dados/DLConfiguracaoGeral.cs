using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLConfiguracaoGeral
    {
        public int Adicionar(MLConfiguracaoGeral configuracaoGeral)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(MLConfiguracaoGeral configuracaoGeral)
        {
            var con = new DlConexao();

            con.limparParametros();

            if (configuracaoGeral.tipoImpressoraPDV != 0)
                con.AdicionarParametros("@tipoImpressoraPDV", configuracaoGeral.tipoImpressoraPDV);
            if (configuracaoGeral.tipoImpressoraVendaPadrao != 0)
                con.AdicionarParametros("@tipoImpressoraVendaPadrao", configuracaoGeral.tipoImpressoraVendaPadrao);
            if (configuracaoGeral.QtdeCopiasImpressaoPDV != 0)
                con.AdicionarParametros("@QtdeCopiasImpressaoPDV", configuracaoGeral.QtdeCopiasImpressaoPDV);
            if (configuracaoGeral.QtdeCopiasImpressaoVendaPadrao != 0)
                con.AdicionarParametros("@QtdeCopiasImpressaoVendaPadrao", configuracaoGeral.QtdeCopiasImpressaoVendaPadrao);
            if (configuracaoGeral.DataInstalacao != null && configuracaoGeral.DataInstalacao != DateTime.MinValue)
                con.AdicionarParametros("@DataInstalacao", configuracaoGeral.DataInstalacao);
            if (configuracaoGeral.DataExpiracaoLicenca != null && configuracaoGeral.DataExpiracaoLicenca != DateTime.MinValue)
                con.AdicionarParametros("@DataExpiracaoLicenca", configuracaoGeral.DataExpiracaoLicenca);

            try
            {
                con.ExecutarConsulta(CommandType.StoredProcedure, "P_AtualizarConfiguracaoGeral");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MLConfiguracaoGeral Consultar()
        {
            var configuracaoGeral = new MLConfiguracaoGeral();
            var con = new DlConexao();
            var dt = new DataTable();

            try
            {
                con.limparParametros();
                dt = con.ExecutarConsulta(CommandType.StoredProcedure, "P_ConsultarConfiguracaoGeral");

                if (dt.Rows.Count > 0)
                {
                    configuracaoGeral = Genericos.Popular<MLConfiguracaoGeral>(dt, 0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return configuracaoGeral;
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}
