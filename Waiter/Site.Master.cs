using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Waiter
{
    public partial class SiteMaster : MasterPage
    {
        public static void Show(string message, Page page)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "MessageBox", "<script language='javascript'>alert('" + message + "');</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {

        }

        protected void btnReservar_Click(object sender, EventArgs e)
        {

        }
    }
}