using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
namespace Dados
{
    public class DLEmpresa : IMetodos<MLEmpresa>
    {
        public int Adicionar(MLEmpresa modelo)
        {
            DlConexao con = new DlConexao();
            var id = 0;

            try
            {
                con.limparParametros();

                #region Paramentros do Empresa
                con.AdicionarParametros("@NomeRazaoSocial", modelo.NomeRazaoSocial);
                con.AdicionarParametros("@NomeFantasia", modelo.NomeFantasia);
                con.AdicionarParametros("@TipoPessoa", modelo.TipoPessoa);
                con.AdicionarParametros("@Observacao", modelo.Observacao);
                con.AdicionarParametros("@Ativo", modelo.Ativo);

                con.AdicionarParametros("@Logradouro", modelo.Logradouro);
                con.AdicionarParametros("@Numero", modelo.Numero);
                con.AdicionarParametros("@Complemento", modelo.Complemento);
                con.AdicionarParametros("@Cep", modelo.Cep);
                con.AdicionarParametros("@Bairro", modelo.Bairro);
                con.AdicionarParametros("@CidadeId", modelo.CidadeId);
                con.AdicionarParametros("@EstadoId", modelo.EstadoId);

                con.AdicionarParametros("@Telefone1", modelo.Telefone1);
                con.AdicionarParametros("@Telefone2", modelo.Telefone2);
                con.AdicionarParametros("@Celular1", modelo.Celular1);
                con.AdicionarParametros("@Celular2", modelo.Celular2);
                con.AdicionarParametros("@Email", modelo.Email);
                con.AdicionarParametros("@Site", modelo.Site);
                con.AdicionarParametros("@Facebook", modelo.Facebook);
                con.AdicionarParametros("@Twitter", modelo.Twitter);
                con.AdicionarParametros("@Youtube", modelo.Youtube);
                con.AdicionarParametros("@Instagram", modelo.Instagram);

                con.AdicionarParametros("@Banco", modelo.Banco);
                con.AdicionarParametros("@Agencia", modelo.Agencia);
                con.AdicionarParametros("@Conta", modelo.Conta);

                con.AdicionarParametros("@IE", modelo.IE);
                con.AdicionarParametros("@CNPJ", modelo.CNPJ);
                con.AdicionarParametros("@IM", modelo.IM);

                con.AdicionarParametros("@Foto", modelo.foto);

                #endregion

                id = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "P_InserirEmpresa"));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }

        public void Atualizar(MLEmpresa modelo)
        {
            DlConexao con = new DlConexao();
            var id = 0;
            try
            {
                con.limparParametros();
                con.AdicionarParametros("@EmpresaId", modelo.EmpresaId);

                #region Paramentros do Empresa
                con.AdicionarParametros("@NomeRazaoSocial", modelo.NomeRazaoSocial);
                con.AdicionarParametros("@NomeFantasia", modelo.NomeFantasia);
                con.AdicionarParametros("@TipoPessoa", modelo.TipoPessoa);
                con.AdicionarParametros("@Observacao", modelo.Observacao);
                con.AdicionarParametros("@Ativo", modelo.Ativo);

                con.AdicionarParametros("@Logradouro", modelo.Logradouro);
                con.AdicionarParametros("@Numero", modelo.Numero);
                con.AdicionarParametros("@Complemento", modelo.Complemento);
                con.AdicionarParametros("@Cep", modelo.Cep);
                con.AdicionarParametros("@Bairro", modelo.Bairro);
                con.AdicionarParametros("@CidadeId", modelo.CidadeId);
                con.AdicionarParametros("@EstadoId", modelo.EstadoId);

                con.AdicionarParametros("@Telefone1", modelo.Telefone1);
                con.AdicionarParametros("@Telefone2", modelo.Telefone2);
                con.AdicionarParametros("@Celular1", modelo.Celular1);
                con.AdicionarParametros("@Celular2", modelo.Celular2);
                con.AdicionarParametros("@Email", modelo.Email);
                con.AdicionarParametros("@Site", modelo.Site);
                con.AdicionarParametros("@Facebook", modelo.Facebook);
                con.AdicionarParametros("@Twitter", modelo.Twitter);
                con.AdicionarParametros("@Youtube", modelo.Youtube);
                con.AdicionarParametros("@Instagram", modelo.Instagram);

                con.AdicionarParametros("@Banco", modelo.Banco);
                con.AdicionarParametros("@Agencia", modelo.Agencia);
                con.AdicionarParametros("@Conta", modelo.Conta);

                con.AdicionarParametros("@IE", modelo.IE);
                con.AdicionarParametros("@CNPJ", modelo.CNPJ);
                con.AdicionarParametros("@IM", modelo.IM);

                con.AdicionarParametros("@Foto", modelo.foto);

                #endregion

                id = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "P_AtualizarEmpresa"));
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

                objDLConexao.AdicionarParametros("@EmpresaId", id);
                objDLConexao.ExecutarManipulacao(CommandType.StoredProcedure, "P_ExcluirEmpresa");

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
        }
        public MLEmpresa Consultar(MLEmpresa modelo)
        {
            DlConexao con = new DlConexao();
            var empresa = new MLEmpresa();
            DataTable dat = new DataTable();
            try
            {
                con.limparParametros();
                if (modelo.EmpresaId > 0)
                {
                    con.AdicionarParametros("@EmpresaId", modelo.EmpresaId);
                }
                else
                {
                    con.AdicionarParametros("@Ativo", modelo.Ativo);
                }


                dat = con.ExecutarConsulta(CommandType.StoredProcedure, "P_ListarEmpresa");
                if (dat.Rows.Count > 0)
                {
                    empresa = Genericos.Popular<MLEmpresa>(dat, 0);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return empresa;
        }

        public List<MLEmpresa> Listar(MLEmpresa empresa)
        {
            DlConexao con = new DlConexao();
            List<MLEmpresa> novalista = new List<MLEmpresa>();
            var dat = new DataTable();
            try
            {
                con.limparParametros();

                if (empresa != null)
                {
                    if (empresa.EmpresaId > 0)
                        con.AdicionarParametros("@EmpresaId", empresa.EmpresaId);

                    if (empresa.NomeRazaoSocial != "")
                        con.AdicionarParametros("@NomeRazaoSocial", empresa.NomeRazaoSocial);
                }

                dat = con.ExecutarConsulta(CommandType.StoredProcedure, "P_ListarEmpresa");
                for (int i = 0; i < dat.Rows.Count; i++)
                {
                    var Empresa = new MLEmpresa();
                    Empresa = Genericos.Popular<MLEmpresa>(dat, i);
                    novalista.Add(Empresa);
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
            return novalista;
        }
    }
}
