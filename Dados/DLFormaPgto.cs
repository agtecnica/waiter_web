using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class DLFormaPgto 
    {
        public List<MLFormaPgto> Listar(MLFormaPgto formaPgto)
        {
            DlConexao objDLConexao = new DlConexao();
            List<MLFormaPgto> lstMLFormaPgto = new List<MLFormaPgto>();
            
            try
            {
                objDLConexao.limparParametros();
                DataTable dt = objDLConexao.ExecutarConsulta(CommandType.StoredProcedure, "[dbo].[P_ListarFormaPgto]");

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        formaPgto = new MLFormaPgto();
                        formaPgto = Genericos.Popular<MLFormaPgto>(dt, i);
                        lstMLFormaPgto.Add(formaPgto);
                    }
                }
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
            return lstMLFormaPgto;
        }
    }
}
