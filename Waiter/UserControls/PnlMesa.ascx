<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PnlMesa.ascx.cs" Inherits="Waiter.UserControls.PnlMesa" %>


<asp:Panel ID="pnlMesa" runat="server" name="pnlMesat" onclick="PanelClick(this.id);" Style="background-color: gray; width: 100px; height: 100px; float:left; margin:5px; padding:5px; cursor: pointer;">
    <i class="glyphicon glyphicon-cog"></i>
    <asp:Label runat="server" ID="lblMesa"  />
</asp:Panel>
