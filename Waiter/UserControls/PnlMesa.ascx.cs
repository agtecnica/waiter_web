using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Waiter.UserControls
{
    public partial class PnlMesa : System.Web.UI.UserControl
    {
        private string status;
        public string Status {

            get => status;
            set => status = value;
        }

        private string mesa;
        public string Mesa
        {
            get => mesa;
            set => mesa = value;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (mesa != null && status != null)
                    if (lblMesa != null)
                    {
                        lblMesa = new Label();
                        ((Label)this.FindControl("lblMesa")).Text = mesa + " - " + status;
                    }
            }

        }
    }
}