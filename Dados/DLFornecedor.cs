using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLFornecedor : IMetodos<MLFornecedor>
    {
        public int Adicionar(MLFornecedor fornecedor)
        {
            DlConexao con = new DlConexao();
            var id = 0;

            try
            {
                con.limparParametros();
                con.AdicionarParametros("@NomeRazaoSocial", fornecedor.NomeRazaoSocial);
                con.AdicionarParametros("@NomeFantasia", fornecedor.NomeFantasia);
                con.AdicionarParametros("@TipoPessoa", fornecedor.TipoPessoa);
                con.AdicionarParametros("@Observacao", fornecedor.Observacao);
                con.AdicionarParametros("@Ativo", fornecedor.Ativo);

                con.AdicionarParametros("@Logradouro", fornecedor.Logradouro);
                con.AdicionarParametros("@Numero", fornecedor.Numero);
                con.AdicionarParametros("@Complemento", fornecedor.Complemento);
                con.AdicionarParametros("@Cep", fornecedor.Cep);
                con.AdicionarParametros("@Bairro", fornecedor.Bairro);
                con.AdicionarParametros("@CidadeId", fornecedor.CidadeId);
                con.AdicionarParametros("@EstadoId", fornecedor.EstadoId);

                con.AdicionarParametros("@Telefone1", fornecedor.Telefone1);
                con.AdicionarParametros("@Telefone2", fornecedor.Telefone2);
                con.AdicionarParametros("@Celular1", fornecedor.Celular1);
                con.AdicionarParametros("@Celular2", fornecedor.Celular2);
                con.AdicionarParametros("@Email", fornecedor.Email);
                con.AdicionarParametros("@Site", fornecedor.Site);
                con.AdicionarParametros("@Facebook", fornecedor.Facebook);
                con.AdicionarParametros("@Twitter", fornecedor.Twitter);
                con.AdicionarParametros("@Youtube", fornecedor.Youtube);
                con.AdicionarParametros("@Instagram", fornecedor.Instagram);

                con.AdicionarParametros("@Banco", fornecedor.Banco);
                con.AdicionarParametros("@Agencia", fornecedor.Agencia);
                con.AdicionarParametros("@Conta", fornecedor.Conta);

                con.AdicionarParametros("@IE", fornecedor.IE);
                con.AdicionarParametros("@CNPJ", fornecedor.CNPJ);
                con.AdicionarParametros("@IM", fornecedor.IM);

                id = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "P_InserirFornecedor"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }

        public void Atualizar(MLFornecedor fornecedor)
        {
            DlConexao con = new DlConexao();
            var id = 0;

            try
            {
                con.limparParametros();

                con.AdicionarParametros("@FornecedorId", fornecedor.FornecedorId);
                con.AdicionarParametros("@NomeRazaoSocial", fornecedor.NomeRazaoSocial);
                con.AdicionarParametros("@NomeFantasia", fornecedor.NomeFantasia);
                con.AdicionarParametros("@TipoPessoa", fornecedor.TipoPessoa);
                con.AdicionarParametros("@Observacao", fornecedor.Observacao);
                con.AdicionarParametros("@Ativo", fornecedor.Ativo);

                con.AdicionarParametros("@Logradouro", fornecedor.Logradouro);
                con.AdicionarParametros("@Numero", fornecedor.Numero);
                con.AdicionarParametros("@Complemento", fornecedor.Complemento);
                con.AdicionarParametros("@Cep", fornecedor.Cep);
                con.AdicionarParametros("@Bairro", fornecedor.Bairro);
                if (fornecedor.CidadeId > 0)
                    con.AdicionarParametros("@CidadeId", fornecedor.CidadeId);
                if (fornecedor.EstadoId > 0)
                    con.AdicionarParametros("@EstadoId", fornecedor.EstadoId);

                con.AdicionarParametros("@Telefone1", fornecedor.Telefone1);
                con.AdicionarParametros("@Telefone2", fornecedor.Telefone2);
                con.AdicionarParametros("@Celular1", fornecedor.Celular1);
                con.AdicionarParametros("@Celular2", fornecedor.Celular2);
                con.AdicionarParametros("@Email", fornecedor.Email);
                con.AdicionarParametros("@Site", fornecedor.Site);
                con.AdicionarParametros("@Facebook", fornecedor.Facebook);
                con.AdicionarParametros("@Twitter", fornecedor.Twitter);
                con.AdicionarParametros("@Youtube", fornecedor.Youtube);
                con.AdicionarParametros("@Instagram", fornecedor.Instagram);

                con.AdicionarParametros("@Banco", fornecedor.Banco);
                con.AdicionarParametros("@Agencia", fornecedor.Agencia);
                con.AdicionarParametros("@Conta", fornecedor.Conta);

                con.AdicionarParametros("@IE", fornecedor.IE);
                con.AdicionarParametros("@CNPJ", fornecedor.CNPJ);
                con.AdicionarParametros("@IM", fornecedor.IM);


                id = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "P_AtualizarFornecedor"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(int id)
        {
            DlConexao objDLConexao = new DlConexao();

            try
            {
                objDLConexao.limparParametros();

                objDLConexao.AdicionarParametros("@FornecedorId", id);
                objDLConexao.ExecutarManipulacao(CommandType.StoredProcedure, "P_ExcluirFornecedor").ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDLConexao = null;
            }
        }

        public MLFornecedor Consultar(MLFornecedor fornecedor)
        {
            DlConexao con = new DlConexao();
            try
            {
                con.limparParametros();
                con.AdicionarParametros("@FornecedorId", fornecedor.FornecedorId);

                var dt = con.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarFornecedor]");
                if (dt.Rows.Count > 0)
                {
                    fornecedor = Genericos.Popular<MLFornecedor>(dt, 0);

                    fornecedor.Cidade = new DLCidade().Consultar(new MLCidade() { CidadeId = (int)fornecedor.CidadeId });
                    fornecedor.Estado = new DLEstado().Consultar(new MLEstado() { EstadoId = (int)fornecedor.EstadoId });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return fornecedor;
        }

        public List<MLFornecedor> Listar(MLFornecedor fornecedor)
        {
            var listaFornecedor = new List<MLFornecedor>();
            var objDLConexao = new DlConexao();
            try
            {
                objDLConexao.limparParametros();

                if (fornecedor.FornecedorId > 0)
                    objDLConexao.AdicionarParametros("@FornecedorId", fornecedor.FornecedorId);

                if (!string.IsNullOrEmpty(fornecedor.NomeRazaoSocial))
                    objDLConexao.AdicionarParametros("@NomeRazaoSocial", fornecedor.NomeRazaoSocial);

                if (fornecedor.Ativo != null)
                    objDLConexao.AdicionarParametros("@Ativo", fornecedor.Ativo);

                var dt = objDLConexao.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarFornecedor]");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    fornecedor = new MLFornecedor();
                    fornecedor = Genericos.Popular<MLFornecedor>(dt, i);

                    fornecedor.Cidade = new DLCidade().Consultar(new MLCidade() { CidadeId = (int)fornecedor.CidadeId });
                    fornecedor.Estado = new DLEstado().Consultar(new MLEstado() { EstadoId = (int)fornecedor.EstadoId });

                    listaFornecedor.Add(fornecedor);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDLConexao = null;
            }
            return listaFornecedor;
        }
    }
}
