<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="ArticulosAppWeb.Producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <section >

        <div class="product-container">
            <div class="product-image">
                <h2 id="NombreProducto" runat="server"></h2>
                <br />
                <img runat="server" id="ImagenPrincipalArticulo" src="#" alt="Alternate Text" class="img-thumbnail" onerror='javascript: this.src="https://cdn4.iconfinder.com/data/icons/ui-beast-3/32/ui-49-4096.png"' />
            </div>
            <div class="product-details">
                <asp:Label ID="PrecioProducto" Style="font-size:40px" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="DescripcionArticulo" runat="server" placeholder="Descripción del producto"></asp:Label>
                <br />
                <div class=" py-5 gap-1">
                    <p>Imagenes</p>         
                    <asp:Button ID="Atras" OnClick="Atras_Click" CssClass="btn btn-outline-secondary" runat="server" Text="Atras" />
                    <asp:Button ID="Siguiente" OnClick="Siguiente_Click" CssClass="btn btn-outline-primary" runat="server" Text="Siguiente" />
                </div>
                <div>
                    <asp:Button ID="Button1" CssClass="btn btn-primary btn-lg" style="margin-bottom: 10px; width: 300px; height: 60px" runat="server" Text="Comprar Ahora" />  
                    <br />
                    <asp:Button ID="Button2" CssClass="btn btn-secondary btn-lg" style="margin-top: 10px; width: 300px; height: 60px" runat="server" Text="Agregar al carrito" />
                </div>
            </div>
        </div>

        <link href="StyleProductos.css" rel="stylesheet" />
    </section>
</asp:Content>
