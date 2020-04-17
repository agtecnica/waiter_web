using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLTransportador : IMetodos<MLTransportador>
    {
        public int Adicionar(MLTransportador transportador)
        {
            DlConexao con = new DlConexao();
            var id = 0;

            try
            {
                con.limparParametros();
                con.AdicionarParametros("@NomeRazaoSocial", transportador.NomeRazaoSocial);
                con.AdicionarParametros("@NomeFantasia", transportador.NomeFantasia);
                con.AdicionarParametros("@TipoPessoa", transportador.TipoPessoa);
                con.AdicionarParametros("@Observacao", transportador.Observacao);
                con.AdicionarParametros("@Ativo", transportador.Ativo);

                con.AdicionarParametros("@Logradouro", transportador.Logradouro);
                con.AdicionarParametros("@Numero", transportador.Numero);
                con.AdicionarParametros("@Complemento", transportador.Complemento);
                con.AdicionarParametros("@Cep", transportador.Cep);
                con.AdicionarParametros("@Bairro", transportador.Bairro);
                con.AdicionarParametros("@CidadeId", transportador.CidadeId);
                con.AdicionarParametros("@EstadoId", transportador.EstadoId);

                con.AdicionarParametros("@Telefone1", transportador.Telefone1);
                con.AdicionarParametros("@Telefone2", transportador.Telefone2);
                con.AdicionarParametros("@Celular1", transportador.Celular1);
                con.AdicionarParametros("@Celular2", transportador.Celular2);
                con.AdicionarParametros("@Email", transportador.Email);
                con.AdicionarParametros("@Site", transportador.Site);
                con.AdicionarParametros("@Facebook", transportador.Facebook);
                con.AdicionarParametros("@Twitter", transportador.Twitter);
                con.AdicionarParametros("@Youtube", transportador.Youtube);
                con.AdicionarParametros("@Instagram", transportador.Instagram);

                con.AdicionarParametros("@Banco", transportador.Banco);
                con.AdicionarParametros("@Agencia", transportador.Agencia);
                con.AdicionarParametros("@Conta", transportador.Conta);

                con.AdicionarParametros("@IE", transportador.IE);
                con.AdicionarParametros("@CNPJ", transportador.CNPJ);
                con.AdicionarParametros("@IM", transportador.IM);

                id = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "P_InserirTransportador"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }

        public void Atualizar(MLTransportador transportador)
        {
            DlConexao con = new DlConexao();
            var id = 0;

            try
            {
                con.limparParametros();

                con.AdicionarParametros("@TransportadorId", transportador.TransportadorId);
                con.AdicionarParametros("@NomeRazaoSocial", transportador.NomeRazaoSocial);
                con.AdicionarParametros("@NomeFantasia", transportador.NomeFantasia);
                con.AdicionarParametros("@TipoPessoa", transportador.TipoPessoa);
                con.AdicionarParametros("@Observacao", transportador.Observacao);
                con.AdicionarParametros("@Ativo", transportador.Ativo);

                con.AdicionarParametros("@Logradouro", transportador.Logradouro);
                con.AdicionarParametros("@Numero", transportador.Numero);
                con.AdicionarParametros("@Complemento", transportador.Complemento);
                con.AdicionarParametros("@Cep", transportador.Cep);
                con.AdicionarParametros("@Bairro", transportador.Bairro);
                con.AdicionarParametros("@CidadeId", transportador.CidadeId);
                con.AdicionarParametros("@EstadoId", transportador.EstadoId);

                con.AdicionarParametros("@Telefone1", transportador.Telefone1);
                con.AdicionarParametros("@Telefone2", transportador.Telefone2);
                con.AdicionarParametros("@Celular1", transportador.Celular1);
                con.AdicionarParametros("@Celular2", transportador.Celular2);
                con.AdicionarParametros("@Email", transportador.Email);
                con.AdicionarParametros("@Site", transportador.Site);
                con.AdicionarParametros("@Facebook", transportador.Facebook);
                con.AdicionarParametros("@Twitter", transportador.Twitter);
                con.AdicionarParametros("@Youtube", transportador.Youtube);
                con.AdicionarParametros("@Instagram", transportador.Instagram);

                con.AdicionarParametros("@Banco", transportador.Banco);
                con.AdicionarParametros("@Agencia", transportador.Agencia);
                con.AdicionarParametros("@Conta", transportador.Conta);

                con.AdicionarParametros("@IE", transportador.IE);
                con.AdicionarParametros("@CNPJ", transportador.CNPJ);
                con.AdicionarParametros("@IM", transportador.IM);


                id = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "P_AtualizarTransportador"));
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

                objDLConexao.AdicionarParametros("@TransportadorId", id);
                objDLConexao.ExecutarManipulacao(CommandType.StoredProcedure, "P_ExcluirTransportador").ToString();

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

        public MLTransportador Consultar(MLTransportador transportador)
        {
            DlConexao con = new DlConexao();
            try
            {
                con.limparParametros();
                con.AdicionarParametros("@TransportadorId", transportador.TransportadorId);

                var dt = con.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarTransportador]");
                if (dt.Rows.Count > 0)
                {
                    transportador = Genericos.Popular<MLTransportador>(dt, 0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return transportador;
        }

        public List<MLTransportador> Listar(MLTransportador transportador)
        {
            var listaTransportador = new List<MLTransportador>();
            var objDLConexao = new DlConexao();
            try
            {
                objDLConexao.limparParametros();

                if (transportador.TransportadorId > 0)
                    objDLConexao.AdicionarParametros("@TransportadorId", transportador.TransportadorId);

                if (!string.IsNullOrEmpty(transportador.NomeRazaoSocial))
                    objDLConexao.AdicionarParametros("@NomeRazaoSocial", transportador.NomeRazaoSocial);


                var dt = objDLConexao.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarTransportador]");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    transportador = new MLTransportador();
                    transportador = Genericos.Popular<MLTransportador>(dt, i);

                    transportador.Cidade = new DLCidade().Consultar(new MLCidade() { CidadeId = (int)transportador.CidadeId });
                    transportador.Estado = new DLEstado().Consultar(new MLEstado() { EstadoId = (int)transportador.EstadoId });

                    listaTransportador.Add(transportador);
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
            return listaTransportador;
        }
    }
}
