using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLSubCategoria : IMetodos<MLSubCategoria>
    {
        public int Adicionar(MLSubCategoria subCategoria)
        {
            DlConexao con = new DlConexao();
            var id = 0;

            try
            {
                con.limparParametros();
                con.AdicionarParametros("@Descricao", subCategoria.Descricao);
                con.AdicionarParametros("@CategoriaId", subCategoria.CategoriaId);

                id = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_InserirSubCategoria"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }

        public void Atualizar(MLSubCategoria subCategoria)
        {
            DlConexao con = new DlConexao();
            var id = 0;

            try
            {
                con.limparParametros();

                con.AdicionarParametros("@SubCategoriaId", subCategoria.SubCategoriaId);
                con.AdicionarParametros("@Descricao", subCategoria.Descricao);
                con.AdicionarParametros("@CategoriaId", subCategoria.CategoriaId);

                id = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_AtualizarSubCategorias"));
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

                objDLConexao.AdicionarParametros("@SubCategoriaId", id);
                objDLConexao.ExecutarManipulacao(CommandType.StoredProcedure, "P_ExcluirSubCategoria");

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

        public MLSubCategoria Consultar(MLSubCategoria subCategoria)
        {
            DlConexao con = new DlConexao();
            try
            {
                con.limparParametros();
                con.AdicionarParametros("@SubCategoriaId", subCategoria.SubCategoriaId);

                var dt = con.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarSubCategoria]");
                if (dt.Rows.Count > 0)
                {
                    subCategoria = new MLSubCategoria();
                    subCategoria = Genericos.Popular<MLSubCategoria>(dt, 0);
                    subCategoria.Categoria = new DLCategoria().Consultar(new MLCategoria() { CategoriaId = subCategoria.CategoriaId });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return subCategoria;
        }

        public List<MLSubCategoria> Listar(MLSubCategoria subCategoria)
        {
            var listaSubCategoria = new List<MLSubCategoria>();
            var con = new DlConexao();
            try
            {
                con.limparParametros();

                if (subCategoria.CategoriaId > 0)
                    con.AdicionarParametros("@CategoriaId", subCategoria.CategoriaId);

                if (!string.IsNullOrEmpty(subCategoria.Descricao))
                    con.AdicionarParametros("@Descricao", subCategoria.Descricao);

                var dt = con.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarSubCategoria]");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    subCategoria = new MLSubCategoria();
                    subCategoria = Genericos.Popular<MLSubCategoria>(dt, i);
                    subCategoria.Categoria = new DLCategoria().Consultar(new MLCategoria() { CategoriaId = subCategoria.CategoriaId });

                    listaSubCategoria.Add(subCategoria);
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
            return listaSubCategoria;
        }
    }
}
