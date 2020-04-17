using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLTipoConta
    {
        public int Adicionar(MLTipoConta modelo)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(MLTipoConta modelo)
        {
            throw new NotImplementedException();
        }

        public MLTipoConta Consultar(MLTipoConta tipoConta)
        {
            DlConexao con = new DlConexao();
            try
            {
                con.limparParametros();
                    con.AdicionarParametros("TipoContaId", tipoConta.TipoContaId);

                var dt = con.ExecutarConsulta(CommandType.StoredProcedure, "P_listarTipoConta");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tipoConta = new MLTipoConta();
                    tipoConta = Genericos.Popular<MLTipoConta>(dt, i);

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
            return tipoConta;
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<MLTipoConta> Listar(MLTipoConta tipoConta)
        {
            List<MLTipoConta> listaTipoConta = new List<MLTipoConta>();
            DlConexao con = new DlConexao();
            try
            {

                con.limparParametros();
                if (tipoConta.TipoContaId > 0)
                    con.AdicionarParametros("@TipoContaId", tipoConta.TipoContaId);
                if (!string.IsNullOrEmpty(tipoConta.Descricao))
                    con.AdicionarParametros("@Descricao", tipoConta.Descricao);
                con.AdicionarParametros("@Ativo", tipoConta.Ativo);

                var dt = con.ExecutarConsulta(CommandType.StoredProcedure, "P_listarTipoConta");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tipoConta = new MLTipoConta();
                    tipoConta = Genericos.Popular<MLTipoConta>(dt, i);

                    tipoConta.Descricao = tipoConta.Descricao.ToUpper();

                    listaTipoConta.Add(tipoConta);
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
            return listaTipoConta;
        }
    }
}
 