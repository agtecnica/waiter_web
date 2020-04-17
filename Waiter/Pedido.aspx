<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pedido.aspx.cs" Inherits="Waiter.Pedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .btn{
            width: 47%;
            margin: 5px;
        }
        .conteudo{
            margin: 10px auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 runat="server" id="lblTitulo"></h2>
    <div class="conteudo">
        <asp:Button runat="server" Text="Refrigerantes" CssClass="btn btn-warning" OnClick="Unnamed_Click" />
        <asp:Button runat="server" Text="Lanches" CssClass="btn btn-warning" OnClick="Unnamed_Click" />
        <asp:Button runat="server" Text="Porções" CssClass="btn btn-warning" OnClick="Unnamed_Click" />
        <asp:Button runat="server" Text="Cervejas" CssClass="btn btn-warning" OnClick="Unnamed_Click" />
        <asp:Button runat="server" Text="Doces e Sobremesas" CssClass="btn btn-warning" OnClick="Unnamed_Click" />
        <asp:Button runat="server" Text="Pizzas" CssClass="btn btn-warning" OnClick="Unnamed_Click" />
        <asp:Button runat="server" Text="Refeições" CssClass="btn btn-warning" OnClick="Unnamed_Click" />
        <asp:Button runat="server" Text="Sucos" CssClass="btn btn-warning" OnClick="Unnamed_Click" />

    </div>
        <asp:LinkButton runat="server" Text="Voltar" CssClass="btn btn-sucess" PostBackUrl="~/Mesas.aspx" />

</asp:Content>
