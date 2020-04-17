using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLMarca : IMetodos<MLMarca>
    {
        public int Adicionar(MLMarca marca)
        {
            DlConexao con = new DlConexao();
            var id = 0;

            try
            {
                con.limparParametros();
                con.AdicionarParametros("@Descricao", marca.Descricao);


                id = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_InserirMarca"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }

        public void Atualizar(MLMarca marca)
        {
            DlConexao objDLConexao = new DlConexao();
            var id = 0;

            try
            {
                objDLConexao.limparParametros();

                objDLConexao.AdicionarParametros("@MarcaId", marca.MarcaId);
                objDLConexao.AdicionarParametros("@Descricao", marca.Descricao);

                id = Convert.ToInt32(objDLConexao.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_AtualizarMarcas"));
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

                objDLConexao.AdicionarParametros("@MarcaId", id);
                objDLConexao.ExecutarManipulacao(CommandType.StoredProcedure, "P_ExcluirMarca");

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

        public MLMarca Consultar(MLMarca marca)
        {
            DlConexao con = new DlConexao();
            try
            {
                con.limparParametros();
                con.AdicionarParametros("@MarcaId", marca.MarcaId);

                var dt = con.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarMarca]");
                if (dt.Rows.Count > 0)
                {
                    marca = Genericos.Popular<MLMarca>(dt, 0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return marca;
        }

        public List<MLMarca> Listar(MLMarca marca)
        {
            var listaMarca = new List<MLMarca>();
            var objDLConexao = new DlConexao();
            try
            {
                objDLConexao.limparParametros();

                if (marca.MarcaId > 0)
                    objDLConexao.AdicionarParametros("@MarcaId", marca.MarcaId);

                if (!string.IsNullOrEmpty(marca.Descricao))
                    objDLConexao.AdicionarParametros("@Descricao", marca.Descricao);


                var dt = objDLConexao.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarMarca]");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    marca = new MLMarca();
                    marca = Genericos.Popular<MLMarca>(dt, i);


                    listaMarca.Add(marca);
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
            return listaMarca;
        }
    }
}
