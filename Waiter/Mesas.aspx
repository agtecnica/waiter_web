<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mesas.aspx.cs" Inherits="Waiter.Mesas" %>

<%@ Register Src="~/UserControls/PnlMesa.ascx" TagPrefix="uc1" TagName="PnlMesa" %>


<asp:Content ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Content/pageMesa.css" type="text/css" media="screen" />
    <script type="text/javascript">
        function PanelClick(e) {
            //eventTarget = eventTarget || window.event;
            //eventTarget = eventTarget.target || eventTarget.srcElement;
            __doPostBack(e, "Click");

            
            //var el = document.getElementById("divMesa");
            //var el = document.getElementsByName('pnlMesat');
            //alert(e);
            //el.addEventListener('Click', function (e) {
            //   alert(e.target.id);
            //    //__doPostBack(e, 'Click');
            ////    alert(e.target.document);
            //});
        }
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel runat="server" ID="divMesa2" CssClass="row" HorizontalAlign="Left"  >

    </asp:Panel>
</asp:Content>
