using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLSubMenu
    {

        public List<MLSubMenu> Listar(MLSubMenu SubMenu)
        {
            var listaSubMenu = new List<MLSubMenu>();
            var objDLConexao = new DlConexao();
            try
            {
                objDLConexao.limparParametros();

                if (SubMenu.MenuId > 0)
                    objDLConexao.AdicionarParametros("@MenuId", SubMenu.MenuId);

                var dt = objDLConexao.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarSubMenu]");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SubMenu = new MLSubMenu();
                    SubMenu = Genericos.Popular<MLSubMenu>(dt, i);


                    listaSubMenu.Add(SubMenu);
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
            return listaSubMenu;
        }
    }
}
