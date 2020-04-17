using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Waiter.UserControls;

namespace Waiter
{
    public class MesaBaclao
    {
        public String MesaId { get; set; }
        public String Status { get; set; }
    }

    public partial class Mesas : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //AdicionarBotao();

            if (!IsPostBack)
            {
                AdicionarBotao();

                List<MesaBaclao> BandaLista = GetIdLista();

                //this.rptMesa.DataSource = BandaLista;
                //this.rptMesa.DataBind();

                //foreach (RepeaterItem item in rptMesa.Items)
                //{
                //    var pnlm = ((Panel)item.FindControl("pnlMesa"));
                //    var lbl = ((Label)item.FindControl("lblMesa"));

                //    if (lbl.Text.Contains("Fechada"))
                //        pnlm.CssClass = "btn btnMesa btnMesaNaoReservada";
                //    else if (lbl.Text.Contains("Aberta"))
                //        pnlm.CssClass = "btn btnMesa btnMesaReservada";

                //}


                Control myControl1 = FindControl("divMesa");
                if (myControl1 != null)
                {
                    //do stuff
                }
            }

            for (int i = 0; i < 5; i++)
            {
                var uc = (PnlMesa)Page.LoadControl("~/UserControls/PnlMesa.ascx");
                uc.Mesa = "Mesa " + i.ToString();
                uc.Status = ((i % 2) == 0) ? "Aberta" : "Fechada";
                uc.ID = "mesa" + i.ToString();

                divMesa2.Controls.Add(uc);
            }


            var controlName = Request.Params.Get("__EVENTTARGET");
            var argument = Request.Params.Get("__EVENTARGUMENT");
            if (controlName != null)
                if ((controlName == "pnlMesa" || controlName.Contains("pnlMesa")) && argument == "Click")
                    PanelClick(controlName);
        }

        private void AdicionarBotao()
        {
            //var btn = new Button();
            //btn.ID = "btnGrupoId";
            //btn.Text = "(X)";
            //btn.CommandName = "Grupo|";
            //btn.CommandArgument = "COMMANDARGUMENT";
            //btn.CssClass = "botao btn btn-outline-dark";
            //btn.Click += new EventHandler(btnExcluirFiltro_Click);

            //divMesa2.Controls.Add(btn);
        }

        private void btnExcluirFiltro_Click(object sender, EventArgs e)
        {

        }

        protected void pnlMesa_Click(object sender, EventArgs e)
        {

        }
        public void PanelClick(string controlName)
        {
            var idControl = controlName.Replace("MainContent_", "").Replace("_pnlMesa", "");
            var control = divMesa2.FindControl(idControl);

            var mesa = ((PnlMesa)control).Mesa;
            var status = ((PnlMesa)control).Status;

            SiteMaster.Show(mesa + " - " + status, this);

            Response.Redirect("~/Pedido?mesa=" + mesa + "&status=" + status);
        }




        private List<MesaBaclao> GetIdLista()
        {
            List<MesaBaclao> lst = new List<MesaBaclao>();
            for (int i = 1; i < 09; i++)
            {
                MesaBaclao mesaBaclao = new MesaBaclao() { MesaId = i.ToString(), Status = ((i % 2) == 0) ? "Aberta" : "Fechada" };
                lst.Add(mesaBaclao);
            }

            return lst;
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            SiteMaster.Show("Novo Pedido Aberto", this);

        }

        protected void rptMesa_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "Selecionar")
            {
                var btn = ((System.Web.UI.Control)e.Item.Controls[0]).ClientID;

                var li = (Button)e.Item.FindControl("btnSave");

                if (li.CssClass == "btn btnMesa btnMesaReservada")
                    li.CssClass = "btn btnMesa btnMesaNaoReservada";
                else
                    li.CssClass = "btn btnMesa btnMesaReservada";

                Response.Redirect("Pedido");

            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {

        }
    }
    public static class MessageBox
    {
        public static void Show(this Page Page, String Message)
        {
            Page.ClientScript.RegisterStartupScript(
               Page.GetType(),
               "MessageBox",
               "<script language='javascript'>alert('" + Message + "');</script>"
            );
        }
    }
}