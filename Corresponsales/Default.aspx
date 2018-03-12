<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron text-center">
        <h1>CORRESPONSALES Y OFICINAS</h1>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12 text-center">
            <h3>OFICINAS</h3>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12 text-center form-group">
            <asp:Label runat="server">Corresponsales:</asp:Label>
            <asp:DropDownList ID="lisCorresponsales" OnSelectedIndexChanged="lisCorresponsales_SelectedIndexChanged" AutoPostBack="True" runat="server" CssClass="form-control">
            </asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12 text-center">
            <asp:Label ID="lblInfo" runat="server"></asp:Label>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12 text-center">
            <h3>OFICINAS</h3>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-6">
            <span>Corresponsal:</span>
            <asp:Label ID="lblCorresponsal" runat="server"></asp:Label>
        </div>
        <span>Oficina:</span>
        <asp:Label ID="lblOficina" runat="server"></asp:Label>
    </div>    
    <br />
    <div class="row">
        <div class="col-md-12 text-center">
            <h3>OFICINA CON MAYOR LONGITUD</h3>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12 table-responsive">
            <asp:Table runat="server" ID="tablaOficina" CssClass="table-striped"></asp:Table>
        </div>
    </div>
</asp:Content>
