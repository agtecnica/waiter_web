using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLUnidadeMedida : IMetodos<MLUnidadeMedida>
    {
        public int Adicionar(MLUnidadeMedida unidadeMedida)
        {
            DlConexao con = new DlConexao();
            var id = 0;

            try
            {
                con.limparParametros();
                con.AdicionarParametros("@Descricao", unidadeMedida.Descricao);
                con.AdicionarParametros("@DescricaoCompleta", unidadeMedida.DescricaoCompleta);

                id = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_InserirUnidadeMedida"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }

        public void Atualizar(MLUnidadeMedida unidadeMedida)
        {
            DlConexao objDLConexao = new DlConexao();
            var id = 0;

            try
            {
                objDLConexao.limparParametros();

                objDLConexao.AdicionarParametros("@UnidadeMedidaId", unidadeMedida.UnidadeMedidaId);
                objDLConexao.AdicionarParametros("@Descricao", unidadeMedida.Descricao);

                id = Convert.ToInt32(objDLConexao.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_AtualizarUnidadeMedidas"));
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

                objDLConexao.AdicionarParametros("@UnidadeMedidaId", id);
                objDLConexao.ExecutarManipulacao(CommandType.StoredProcedure, "P_ExcluirUnidadeMedida");

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

        public MLUnidadeMedida Consultar(MLUnidadeMedida unidadeMedida)
        {
            DlConexao con = new DlConexao();
            try
            {
                con.limparParametros();
                con.AdicionarParametros("@UnidadeMedidaId", unidadeMedida.UnidadeMedidaId);

                var dt = con.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarUnidadeMedida]");
                if (dt.Rows.Count > 0)
                {
                    unidadeMedida = Genericos.Popular<MLUnidadeMedida>(dt, 0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return unidadeMedida;
        }

        public List<MLUnidadeMedida> Listar(MLUnidadeMedida unidadeMedida)
        {
            var listaUnidadeMedida = new List<MLUnidadeMedida>();
            var objDLConexao = new DlConexao();
            try
            {
                objDLConexao.limparParametros();

                if (unidadeMedida.UnidadeMedidaId > 0)
                    objDLConexao.AdicionarParametros("@UnidadeMedidaId", unidadeMedida.UnidadeMedidaId);

                if (!string.IsNullOrEmpty(unidadeMedida.Descricao))
                    objDLConexao.AdicionarParametros("@Descricao", unidadeMedida.Descricao);


                var dt = objDLConexao.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarUnidadeMedida]");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    unidadeMedida = new MLUnidadeMedida();
                    unidadeMedida = Genericos.Popular<MLUnidadeMedida>(dt, i);


                    listaUnidadeMedida.Add(unidadeMedida);
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
            return listaUnidadeMedida;
        }
    }
}
