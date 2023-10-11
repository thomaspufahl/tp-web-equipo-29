<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ArticulosAppWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <section class="px-5 py-4">
        <h2 class="mb-4">Articulos</h2>
        <ul class="d-flex flex-wrap row-gap-5 m-0 p-0" style="place-content: space-between; list-style: none">
            <asp:Repeater id = "ParentRepeater" runat="server">
                <ItemTemplate>
                    <li>
                        <article class="card d-flex" style="max-width: 21rem">
                            <header class="card-body text-wrap">
                                <img id="imagenArt" src="<%#Eval("Imagenes[0].UrlImagen")%>" alt="Alternate Text" onerror='javascript: this.src="https://cdn4.iconfinder.com/data/icons/ui-beast-3/32/ui-49-4096.png"' class="card-img-top"/>
                                <h5 class="card-title"><%#Eval("Nombre")%></h5>
                                <p class="card-text"><%#Eval("Descripcion") %></p>
                            </header>
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item"><%#Eval("Categoria.Description") %> </li>
                                <li class="list-group-item"><%#Eval("Marca.Description") %></li>
                            </ul>
                            <footer class="card-footer d-flex gap-2">
                                <a class = "btn btn-dark" href="Producto.aspx?id=<%#Eval("id")%>">Mas información</a>
                                <asp:Button ID="btnAgregarCarrito" Onclick="btnAgregarCarrito_Click" CommandArgument='<%#Eval("id")%>' CommandName="ArticuloId" cssclass = "btn btn-danger" runat="server" Text="Agregar al carrito"/>
                            </footer>
                        </article>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </section>
</asp:Content>
