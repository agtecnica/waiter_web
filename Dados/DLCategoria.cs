using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLCategoria : IMetodos<MLCategoria>
    {
        public int Adicionar(MLCategoria categoria)
        {
            DlConexao con = new DlConexao();
            var id = 0;

            try
            {
                con.limparParametros();
                con.AdicionarParametros("@Descricao", categoria.Descricao);


                id = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_InserirCategoria"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }

        public void Atualizar(MLCategoria categoria)
        {
            DlConexao objDLConexao = new DlConexao();
            var id = 0;

            try
            {
                objDLConexao.limparParametros();

                objDLConexao.AdicionarParametros("@CategoriaId", categoria.CategoriaId);
                objDLConexao.AdicionarParametros("@Descricao", categoria.Descricao);

                id = Convert.ToInt32(objDLConexao.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_AtualizarCategorias"));
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

                objDLConexao.AdicionarParametros("@CategoriaId", id);
                objDLConexao.ExecutarManipulacao(CommandType.StoredProcedure, "P_ExcluirCategoria");

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

        public MLCategoria Consultar(MLCategoria categoria)
        {
            DlConexao con = new DlConexao();
            try
            {
                con.limparParametros();
                con.AdicionarParametros("@CategoriaId", categoria.CategoriaId);

                var dt = con.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarCategoria]");
                if (dt.Rows.Count > 0)
                {
                    categoria = Genericos.Popular<MLCategoria>(dt, 0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return categoria;
        }

        public List<MLCategoria> Listar(MLCategoria categoria)
        {
            var listaCategoria = new List<MLCategoria>();
            var objDLConexao = new DlConexao();
            try
            {
                objDLConexao.limparParametros();

                if (categoria.CategoriaId > 0)
                    objDLConexao.AdicionarParametros("@CategoriaId", categoria.CategoriaId);

                if (!string.IsNullOrEmpty(categoria.Descricao))
                    objDLConexao.AdicionarParametros("@Descricao", categoria.Descricao);
                

                var dt = objDLConexao.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarCategoria]");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    categoria = new MLCategoria();
                    categoria = Genericos.Popular<MLCategoria>(dt, i);

                    
                    listaCategoria.Add(categoria);
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
            return listaCategoria;
        }
    }
}
