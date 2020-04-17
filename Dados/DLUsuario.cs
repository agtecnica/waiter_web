using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLUsuario : IMetodos<MLUsuario>
    {
        public int Adicionar(MLUsuario objMlUsuarios)
        {
            DlConexao con = new DlConexao();
            var id = 0;

            try
            {
                con.limparParametros();

                con.AdicionarParametros("@Nome", objMlUsuarios.Nome);
                con.AdicionarParametros("@Login", objMlUsuarios.Login);
                con.AdicionarParametros("@Senha", objMlUsuarios.Senha);
                con.AdicionarParametros("@DataExpiraSenha", objMlUsuarios.DataExpiraSenha);
                con.AdicionarParametros("@Observacao", objMlUsuarios.Observacao);
                con.AdicionarParametros("@isGerente", objMlUsuarios.isGerente);

                id = Convert.ToInt32(con.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_InserirUsuarios"));

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

                objDLConexao.AdicionarParametros("@UsuarioId", id);
                objDLConexao.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_ExcluirUsuario");

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

        public void Atualizar(MLUsuario objMlUsuarios)
        {
            DlConexao con = new DlConexao();

            try
            {
                con.limparParametros();


                con.AdicionarParametros("@UsuarioId", objMlUsuarios.UsuarioId);
                con.AdicionarParametros("@Nome", objMlUsuarios.Nome);
                con.AdicionarParametros("@Login", objMlUsuarios.Login);
                if (!string.IsNullOrEmpty(objMlUsuarios.Senha))
                    con.AdicionarParametros("@Senha", objMlUsuarios.Senha);
                con.AdicionarParametros("@DataExpiraSenha", objMlUsuarios.DataExpiraSenha);
                if (objMlUsuarios.Tentativas != null)
                    con.AdicionarParametros("@Tentativas", objMlUsuarios.Tentativas);
                con.AdicionarParametros("@Ativo", objMlUsuarios.Ativo);
                con.AdicionarParametros("@Observacao", objMlUsuarios.Observacao);
                con.AdicionarParametros("@isGerente", objMlUsuarios.isGerente);

                con.ExecutarManipulacao(CommandType.StoredProcedure, "dbo.P_AtualizarUsuarios");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MLUsuario Consultar(MLUsuario modelo)
        {
            DlConexao con = new DlConexao();
            var usuario = new MLUsuario();
            try
            {
                con.limparParametros();
                con.AdicionarParametros("@Login", modelo.Login);
                con.AdicionarParametros("@Senha", modelo.Senha);

                var dt = con.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ConsultarUsuario]");
                if (dt.Rows.Count > 0)
                {
                    usuario = Genericos.Popular<MLUsuario>(dt, 0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usuario;
        }

        public List<MLUsuario> Listar(MLUsuario usuario)
        {
            var listaUsuario = new List<MLUsuario>();
            var objDLConexao = new DlConexao();
            try
            {
                objDLConexao.limparParametros();
                if (usuario == null) usuario = new MLUsuario();

                if (usuario.UsuarioId > 0)
                    objDLConexao.AdicionarParametros("@UsuarioId", usuario.UsuarioId);

                if (!string.IsNullOrEmpty(usuario.Nome))
                    objDLConexao.AdicionarParametros("@Nome", usuario.Nome);

                if (!string.IsNullOrEmpty(usuario.Login))
                    objDLConexao.AdicionarParametros("@Login", usuario.Login);

                if (usuario.Ativo != null)
                    objDLConexao.AdicionarParametros("@Ativo", usuario.Ativo);

                var dt = objDLConexao.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarUsuario]");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    usuario = new MLUsuario();
                    usuario = Genericos.Popular<MLUsuario>(dt, i);

                    listaUsuario.Add(usuario);
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
            return listaUsuario;
        }
    }
}
