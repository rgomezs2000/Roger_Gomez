<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>CORRESPONSALES Y OFICINAS</h1>
    </div>

    <div class="row">
        <div class="col-md-12">
            <h2>Listar Corresponsales</h2>
            <br />
            <asp:DropDownList ID="corresponsales" runat="server">
                <asp:ListItem Value="">-Seleccione-</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
</asp:Content>
