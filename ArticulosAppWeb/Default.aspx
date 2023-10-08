<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ArticulosAppWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <section class="px-5 py-4">
        <h2 class="mb-4">Articulos</h2>
        <ul class="d-flex flex-wrap row-gap-5 m-0 p-0" style="place-content: space-between; list-style: none">
            <asp:Repeater id = "ParentRepeater" runat="server" OnItemDataBound="ItemBound">
                <ItemTemplate>
                    <li>
                        <article class="card d-flex" style="max-width: 21rem">
                            <header class="card-body text-wrap">
                                <asp:Repeater id="ChildRepeater" runat="server">
                                    <ItemTemplate>
                                        <img src="<%#Eval("UrlImagen")%>" class="card-img-top" alt="Imagen">
                                        <p>
                                            <%#Eval("UrlImagen")%>
                                        </p>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <h5 class="card-title"> <%#Eval("Nombre") %> </h5>
                                <p class="card-text"><%#Eval("Descripcion") %></p>
                            </header>
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item"><%#Eval("Categoria.Description") %> </li>
                                <li class="list-group-item"><%#Eval("Marca.Description") %></li>
                            </ul>
                            <footer class="card-footer d-flex gap-2">
                                <asp:Button ID="btnInformacion" cssclass = "btn btn-dark"  runat ="server" Text="Mas Informacion"/>
                                <asp:Button ID="btnAgregarCarrito" cssclass = "btn btn-danger" runat="server" Text="Agregar al carrito"/>
                            </footer>
                        </article>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </section>
</asp:Content>
