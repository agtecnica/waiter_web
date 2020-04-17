using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLProduto : IMetodos<MLProduto>
    {
        public int Adicionar(MLProduto objMlProdutos)
        {
            DlConexao con = new DlConexao();
            var id = 0;

            try
            {
                con.limparParametros();

                con.AdicionarParametros("@Descricao", objMlProdutos.Descricao);
                con.AdicionarParametros("@CodigoBarras", (objMlProdutos.CodigoBarras == null) ? "" : objMlProdutos.CodigoBarras);
                //objDLConexao.AdicionarParametros("@CodInterno", objMlProdutos.CodInterno);
                con.AdicionarParametros("@ValorCompra", objMlProdutos.ValorCompra);
                con.AdicionarParametros("@ValorVenda", objMlProdutos.ValorVenda);
                con.AdicionarParametros("@QtdeUnitaria", objMlProdutos.QtdeUnitaria);
                con.AdicionarParametros("@QtdeMaster", objMlProdutos.QtdeMaster);
                con.AdicionarParametros("@QtdeMaxEstoque", objMlProdutos.QtdeMaxEstoque);
                con.AdicionarParametros("@Lucro", objMlProdutos.Lucro);
                con.AdicionarParametros("@QtdeMinEstoque", objMlProdutos.QtdeMinEstoque);
                con.AdicionarParametros("@Ativo", objMlProdutos.Ativo);
                //objDLConexao.AdicionarParametros("@Perecivel", objMlProdutos.IsNaoPerecivel);

                if (objMlProdutos.CategoriaId > 0)
                    con.AdicionarParametros("@CategoriaId", objMlProdutos.CategoriaId);

                if (objMlProdutos.SubCategoriaId > 0)
                    con.AdicionarParametros("@SubCategoriaId", objMlProdutos.SubCategoriaId);

                if (objMlProdutos.MarcaId > 0)
                    con.AdicionarParametros("@MarcaId", objMlProdutos.MarcaId);

                con.AdicionarParametros("@Observacao", objMlProdutos.Observacao);

                if (objMlProdutos.UnidMedidaId > 0)
                    con.AdicionarParametros("@UnidMedidaId", objMlProdutos.UnidMedidaId);

                con.AdicionarParametros("@Foto", objMlProdutos.foto);

                id = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_InserirProdutos"));

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

                objDLConexao.AdicionarParametros("@ProdutoId", id);
                objDLConexao.ExecutarManipulacao(CommandType.StoredProcedure, "P_ExcluirProduto");

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

        public void Atualizar(MLProduto objMlProdutos)
        {

            DlConexao objDLConexao = new DlConexao();

            try
            {
                objDLConexao.limparParametros();


                objDLConexao.AdicionarParametros("@ProdutoId", objMlProdutos.ProdutoId);
                objDLConexao.AdicionarParametros("@Descricao", objMlProdutos.Descricao);
                objDLConexao.AdicionarParametros("@CodigoBarras", objMlProdutos.CodigoBarras);
                //objDLConexao.AdicionarParametros("@CodInterno", objMlProdutos.CodInterno);
                objDLConexao.AdicionarParametros("@ValorCompra", objMlProdutos.ValorCompra);
                objDLConexao.AdicionarParametros("@ValorVenda", objMlProdutos.ValorVenda);
                objDLConexao.AdicionarParametros("@QtdeUnitaria", objMlProdutos.QtdeUnitaria);
                objDLConexao.AdicionarParametros("@QtdeMaster", objMlProdutos.QtdeMaster);
                objDLConexao.AdicionarParametros("@QtdeMaxEstoque", objMlProdutos.QtdeMaxEstoque);
                objDLConexao.AdicionarParametros("@Lucro", objMlProdutos.Lucro);
                objDLConexao.AdicionarParametros("@QtdeMinEstoque", objMlProdutos.QtdeMinEstoque);
                objDLConexao.AdicionarParametros("@Ativo", objMlProdutos.Ativo);
                //objDLConexao.AdicionarParametros("@Perecivel", objMlProdutos.IsNaoPerecivel);

                if (objMlProdutos.CategoriaId > 0)
                    objDLConexao.AdicionarParametros("@CategoriaId", objMlProdutos.CategoriaId);

                if (objMlProdutos.SubCategoriaId > 0)
                    objDLConexao.AdicionarParametros("@SubCategoriaId", objMlProdutos.SubCategoriaId);

                if (objMlProdutos.MarcaId > 0)
                    objDLConexao.AdicionarParametros("@MarcaId", objMlProdutos.MarcaId);

                objDLConexao.AdicionarParametros("@Observacao", objMlProdutos.Observacao);

                if (objMlProdutos.UnidMedidaId > 0)
                    objDLConexao.AdicionarParametros("@UnidMedidaId", objMlProdutos.UnidMedidaId);

                objDLConexao.AdicionarParametros("@Foto", objMlProdutos.foto);

                objDLConexao.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_AtualizarProdutos");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MLProduto Consultar(MLProduto modelo)
        {
            DlConexao con = new DlConexao();
            var produto = new MLProduto();
            produto.Estoque = new MLEstoque();
            try
            {
                con.limparParametros();
                if (modelo.ProdutoId > 0)
                    con.AdicionarParametros("@ProdutoId", modelo.ProdutoId);

                if (modelo.CodigoBarras != null)
                    con.AdicionarParametros("@CodigoBarras", modelo.CodigoBarras);
                var dt = con.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarProduto]");
                if (dt.Rows.Count > 0)
                {
                    produto = Genericos.Popular<MLProduto>(dt, 0);
                    var mlEstoque = new MLEstoque() { ProdutoId = modelo.ProdutoId };
                    var unidadeMedida = new MLUnidadeMedida() { UnidadeMedidaId = (int)produto.UnidMedidaId };
                    produto.UnidadeMedida = new DLUnidadeMedida().Consultar(unidadeMedida);
                    mlEstoque = new DLEstoque().Consultar(mlEstoque);
                    produto.Estoque = mlEstoque;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return produto;
        }

        public List<MLProduto> Listar(MLProduto produto)
        {
            var listaProduto = new List<MLProduto>();
            var objDLConexao = new DlConexao();
            var estoque = new MLEstoque();
            var dlEstoque = new DLEstoque();
            try
            {
                objDLConexao.limparParametros();
                if (produto == null) produto = new MLProduto();

                if (produto.ProdutoId > 0)
                    objDLConexao.AdicionarParametros("@ProdutoId", produto.ProdutoId);

                if (!string.IsNullOrEmpty(produto.Descricao))
                    objDLConexao.AdicionarParametros("@Descricao", produto.Descricao);

                if (produto.CategoriaId > 0)
                    objDLConexao.AdicionarParametros("@CategoriaId", produto.CategoriaId);

                if (produto.SubCategoriaId > 0)
                    objDLConexao.AdicionarParametros("@SubCategoriaId", produto.SubCategoriaId);

                if (produto.CodigoBarras != "")
                    objDLConexao.AdicionarParametros("@CodigoBarras", produto.CodigoBarras);

                if (produto.UnidMedidaId > 0)
                    objDLConexao.AdicionarParametros("@UnidMedidaId", produto.UnidMedidaId);

                if (produto.MarcaId > 0)
                    objDLConexao.AdicionarParametros("@MarcaId", produto.MarcaId);



                if (produto.Ativo != null)
                    objDLConexao.AdicionarParametros("@Ativo", produto.Ativo);

                var dt = objDLConexao.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarProduto]");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    produto = new MLProduto();
                    produto = Genericos.Popular<MLProduto>(dt, i);

                    estoque.ProdutoId = produto.ProdutoId;
                    produto.Estoque = dlEstoque.Consultar(estoque);
                    produto.Categoria = new MLCategoria();
                    produto.SubCategoria = new MLSubCategoria();
                    produto.Marca = new MLMarca();
                    produto.UnidadeMedida = new MLUnidadeMedida();

                    if (produto.CategoriaId > 0)
                    {
                        var categoria = new MLCategoria() { CategoriaId = produto.CategoriaId };
                        produto.Categoria = new DLCategoria().Consultar(categoria);
                    }


                    if (produto.SubCategoriaId != null)
                    {
                        var subcategoria = new MLSubCategoria() { SubCategoriaId = (int)produto.SubCategoriaId };
                        produto.SubCategoria = new DLSubCategoria().Consultar(subcategoria);
                    }

                    if (produto.UnidMedidaId != null)
                    {
                        var unidademedida = new MLUnidadeMedida() { UnidadeMedidaId = (int)produto.UnidMedidaId };
                        produto.UnidadeMedida = new DLUnidadeMedida().Consultar(unidademedida);
                    }

                    if (produto.MarcaId != null)
                    {
                        var marca = new MLMarca() { MarcaId = (int)produto.MarcaId };
                        produto.Marca = new DLMarca().Consultar(marca);
                    }

                    listaProduto.Add(produto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDLConexao = null;
                dlEstoque = null;
                estoque = null;
            }
            return listaProduto;
        }
    }
}
