using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Waiter
{
    public partial class Pedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var mesa = Request["mesa"]; 
                var status = Request["status"];

                lblTitulo.InnerHtml = mesa + " - " + status;

            }

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }
    }
}