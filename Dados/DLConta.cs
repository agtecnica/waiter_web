using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLConta 
    {
        public int Adicionar(MLConta modelo)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(MLConta modelo)
        {
            throw new NotImplementedException();
        }

        public MLConta Consultar(MLConta modelo)
        {
            DlConexao con = new DlConexao();
            DataTable dt = new DataTable();
            MLConta mLConta = new MLConta();
            try
            {
                con.limparParametros();
                con.AdicionarParametros("@ContaId", modelo.ContaId);
                dt = con.ExecutarConsulta(CommandType.StoredProcedure, "P_ListarConta");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    mLConta = new MLConta();
                    mLConta = Genericos.Popular<MLConta>(dt, i);

                    if (mLConta.Fornecedor == null) mLConta.Fornecedor = new MLFornecedor();
                    mLConta.Fornecedor = new DLFornecedor().Consultar(new MLFornecedor() { FornecedorId = mLConta.FornecedorId });
                   
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

            return mLConta;
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<MLConta> Listar(MLConta mLConta)
        {
            DlConexao con = new DlConexao();
            DataTable dt = new DataTable();
            List<MLConta> listaConta = new List<MLConta>();
            try
            {
                con.limparParametros();
                con.AdicionarParametros("@ContaId", mLConta.ContaId);
                dt = con.ExecutarConsulta(CommandType.StoredProcedure, "P_ListarConta");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    mLConta = new MLConta();
                    mLConta = Genericos.Popular<MLConta>(dt, i);

                    if (mLConta.Fornecedor == null) mLConta.Fornecedor = new MLFornecedor();
                    mLConta.Fornecedor = new DLFornecedor().Consultar(new MLFornecedor() { FornecedorId = mLConta.FornecedorId });
                    listaConta.Add(mLConta);
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

            return listaConta;
        }
    }
}
