<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="ArticulosAppWeb.Producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <section>
        <h2 id="TituloProducto" runat="server"></h2>
        <p>----------------</p>
        <p>IMAGEN PRINCIPAL</p>
        <p>URL IMAGEN: <%#Eval("UrlImagen") %></p>
        <img runat="server" id="ImagenPrincipalArticulo" src="#" alt="Alternate Text" />
        <p>----------------</p>
        <br />
        <p>----------------</p>
        <p>LISTA IMAGENES</p>
        <ul>
            <asp:Repeater runat="server" ID="ListaImagenesRepeater">
                <ItemTemplate>
                    <p>----------------</p>
                    <li>
                        <p>URL IMAGEN: <%#Eval("UrlImagen") %></p>
                        <img src="<%#Eval("UrlImagen") %>" alt="Alternate Text" />
                    </li>
                    <p>----------------</p>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <p>FIN LISTA IMAGENES</p>
        <p>----------------</p>
    </section>
</asp:Content>
