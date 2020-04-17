using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLCliente : IMetodos<MLCliente>
    {
        public int Adicionar(MLCliente objMLClientes)
        {
            DlConexao con = new DlConexao();
            var id = 0;

            try
            {
                con.limparParametros();

                #region Paramentros do Cliente
                con.AdicionarParametros("@NomeRazaoSocial", objMLClientes.NomeRazaoSocial);
                con.AdicionarParametros("@NomeFantasia", objMLClientes.NomeFantasia);
                con.AdicionarParametros("@Apelido", objMLClientes.Apelido);
                con.AdicionarParametros("@TipoPessoa", objMLClientes.TipoPessoa);
                con.AdicionarParametros("@Observacao", objMLClientes.Observacao);
                con.AdicionarParametros("@Ativo", objMLClientes.Ativo);
                con.AdicionarParametros("@Sexo", objMLClientes.Sexo);

                con.AdicionarParametros("@Logradouro", objMLClientes.Logradouro);
                con.AdicionarParametros("@Numero", objMLClientes.Numero);
                con.AdicionarParametros("@Complemento", objMLClientes.Complemento);
                con.AdicionarParametros("@Cep", objMLClientes.Cep);
                con.AdicionarParametros("@Bairro", objMLClientes.Bairro);
                con.AdicionarParametros("@CidadeId", objMLClientes.CidadeId);
                con.AdicionarParametros("@EstadoId", objMLClientes.EstadoId);

                con.AdicionarParametros("@Telefone1", objMLClientes.Telefone1);
                con.AdicionarParametros("@Telefone2", objMLClientes.Telefone2);
                con.AdicionarParametros("@Celular1", objMLClientes.Celular1);
                con.AdicionarParametros("@Celular2", objMLClientes.Celular2);
                con.AdicionarParametros("@Email", objMLClientes.Email);
                con.AdicionarParametros("@Site", objMLClientes.Site);
                con.AdicionarParametros("@Facebook", objMLClientes.Facebook);
                con.AdicionarParametros("@Twitter", objMLClientes.Twitter);
                con.AdicionarParametros("@Youtube", objMLClientes.Youtube);
                con.AdicionarParametros("@Instagram", objMLClientes.Instagram);

                con.AdicionarParametros("@Banco", objMLClientes.Banco);
                con.AdicionarParametros("@Agencia", objMLClientes.Agencia);
                con.AdicionarParametros("@Conta", objMLClientes.Conta);

                con.AdicionarParametros("@RG", objMLClientes.RG);
                con.AdicionarParametros("@CPF", objMLClientes.CPF);
                con.AdicionarParametros("@CNH", objMLClientes.CNH);
                con.AdicionarParametros("@TituloEleitor", objMLClientes.TituloEleitor);
                con.AdicionarParametros("@CertidaoMilitar", objMLClientes.CertidaoMilitar);
                con.AdicionarParametros("@Ctps", objMLClientes.Ctps);
                con.AdicionarParametros("@SerieCtps", objMLClientes.SerieCtps);
                con.AdicionarParametros("@IE", objMLClientes.IE);
                con.AdicionarParametros("@CNPJ", objMLClientes.CNPJ);
                con.AdicionarParametros("@IM", objMLClientes.IM);

                #endregion


                id = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "P_InserirClientes"));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;

        }

        public void Excluir(int id)
        {
            DlConexao objDLConexao = new DlConexao();

            try
            {
                objDLConexao.limparParametros();

                objDLConexao.AdicionarParametros("@ClienteId", id);
                objDLConexao.ExecutarManipulacao(CommandType.StoredProcedure, "P_ExcluirCliente");

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

        public void Atualizar(MLCliente objMLClientes)
        {
            DlConexao con = new DlConexao();
            var id = 0;

            try
            {
                con.limparParametros();

                #region Paramentros do Cliente
                con.AdicionarParametros("@ClienteId", objMLClientes.ClienteId);
                con.AdicionarParametros("@NomeRazaoSocial", objMLClientes.NomeRazaoSocial);
                con.AdicionarParametros("@NomeFantasia", objMLClientes.NomeFantasia);
                con.AdicionarParametros("@Apelido", objMLClientes.Apelido);
                con.AdicionarParametros("@TipoPessoa", objMLClientes.TipoPessoa);
                con.AdicionarParametros("@Observacao", objMLClientes.Observacao);
                con.AdicionarParametros("@Ativo", objMLClientes.Ativo);
                con.AdicionarParametros("@Sexo", objMLClientes.Sexo);

                con.AdicionarParametros("@Logradouro", objMLClientes.Logradouro);
                con.AdicionarParametros("@Numero", objMLClientes.Numero);
                con.AdicionarParametros("@Complemento", objMLClientes.Complemento);
                con.AdicionarParametros("@Cep", objMLClientes.Cep);
                con.AdicionarParametros("@Bairro", objMLClientes.Bairro);
                con.AdicionarParametros("@CidadeId", objMLClientes.CidadeId);
                con.AdicionarParametros("@EstadoId", objMLClientes.EstadoId);

                con.AdicionarParametros("@Telefone1", objMLClientes.Telefone1);
                con.AdicionarParametros("@Telefone2", objMLClientes.Telefone2);
                con.AdicionarParametros("@Celular1", objMLClientes.Celular1);
                con.AdicionarParametros("@Celular2", objMLClientes.Celular2);
                con.AdicionarParametros("@Email", objMLClientes.Email);
                con.AdicionarParametros("@Site", objMLClientes.Site);
                con.AdicionarParametros("@Facebook", objMLClientes.Facebook);
                con.AdicionarParametros("@Twitter", objMLClientes.Twitter);
                con.AdicionarParametros("@Youtube", objMLClientes.Youtube);
                con.AdicionarParametros("@Instagram", objMLClientes.Instagram);

                con.AdicionarParametros("@Banco", objMLClientes.Banco);
                con.AdicionarParametros("@Agencia", objMLClientes.Agencia);
                con.AdicionarParametros("@Conta", objMLClientes.Conta);

                con.AdicionarParametros("@RG", objMLClientes.RG);
                con.AdicionarParametros("@CPF", objMLClientes.CPF);
                con.AdicionarParametros("@CNH", objMLClientes.CNH);
                con.AdicionarParametros("@TituloEleitor", objMLClientes.TituloEleitor);
                con.AdicionarParametros("@CertidaoMilitar", objMLClientes.CertidaoMilitar);
                con.AdicionarParametros("@Ctps", objMLClientes.Ctps);
                con.AdicionarParametros("@SerieCtps", objMLClientes.SerieCtps);
                con.AdicionarParametros("@IE", objMLClientes.IE);
                con.AdicionarParametros("@CNPJ", objMLClientes.CNPJ);
                con.AdicionarParametros("@IM", objMLClientes.IM);
                #endregion

                id = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "P_AtualizarClientes"));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MLCliente Consultar(MLCliente Cliente)
        {
            DlConexao con = new DlConexao();
            try
            {
                con.limparParametros();
                if (Cliente.ClienteId > 0)
                    con.AdicionarParametros("@ClienteId", Cliente.ClienteId);

                con.AdicionarParametros("@Ativo", Cliente.Ativo);

                var dt = con.ExecutarConsulta(CommandType.StoredProcedure, "P_ListarCliente");
                if (dt.Rows.Count > 0)
                {
                    Cliente = new MLCliente();
                    Cliente = Genericos.Popular<MLCliente>(dt, 0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Cliente;


        }

        public List<MLCliente> Listar(MLCliente Cliente)
        {
            var listaCliente = new List<MLCliente>();
            var objDLConexao = new DlConexao();
            var dt = new DataTable();
            try
            {
                objDLConexao.limparParametros();

                if (Cliente.ClienteId > 0)
                    objDLConexao.AdicionarParametros("@ClienteId", Cliente.ClienteId);
                //if (!string.IsNullOrEmpty(Cliente.NomeFantasia))
                //    objDLConexao.AdicionarParametros("@NomeFantasia", Cliente.NomeFantasia);
                if (Cliente.NomeRazaoSocial != null && Cliente.NomeRazaoSocial != "")
                    objDLConexao.AdicionarParametros("@NomeRazaoSocial", Cliente.NomeRazaoSocial);
                if (Cliente.CidadeId > 0)
                    objDLConexao.AdicionarParametros("@CidadeId", Cliente.CidadeId);
                if (Cliente.EstadoId > 0)
                    objDLConexao.AdicionarParametros("@EstadoId", Cliente.EstadoId);
                if (Cliente.CNPJ != null && Cliente.CNPJ.Length == 14)
                    objDLConexao.AdicionarParametros("@CNPJ", Cliente.CNPJ);
                if (Cliente.CPF != null && Cliente.CPF.Length == 11)
                    objDLConexao.AdicionarParametros("@CPF", Cliente.CPF);
                objDLConexao.AdicionarParametros("@Ativo", Cliente.Ativo);

                if (objDLConexao.ContarParametros() > 0)
                {
                    dt = objDLConexao.ExecutarConsulta(CommandType.StoredProcedure, "P_ListarCliente");
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Cliente = new MLCliente();
                    Cliente = Genericos.Popular<MLCliente>(dt, i);
                    if (Cliente.CidadeId != null)
                    {
                        var cidade = new MLCidade() { CidadeId = (int)Cliente.CidadeId };
                        Cliente.Cidade = new DLCidade().Consultar(cidade);
                    }
                    if (Cliente.EstadoId != null)
                    {
                        var estado = new MLEstado() { EstadoId = (int)Cliente.EstadoId };
                        Cliente.Estado = new DLEstado().Consultar(estado);
                    }

                    listaCliente.Add(Cliente);
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
            return listaCliente;
        }
    }
}
