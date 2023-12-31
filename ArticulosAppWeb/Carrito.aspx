﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="ArticulosAppWeb.Carrito1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <asp:Panel ID="NoHayProductos" runat="server" Visible="false" CssClass="text-center">
        <section class="p-5">
            <img runat="server" id="ImagenBolsa" style="width: 450px" src="https://imgs.search.brave.com/PW8qry7f0BsFCTAbmrzJfKohuDfrc4JAhVqbF3jj96I/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9pbWFn/ZXMudmV4ZWxzLmNv/bS9tZWRpYS91c2Vy/cy8zLzE5MjQ1MS9p/c29sYXRlZC9wcmV2/aWV3LzY3NzIzZjJl/OWU4ZWQ2YjZhMTgx/OGUyMTU1NzkzMTMy/LWJvbHNhcy1kZS1j/b21wcmFzLWRlLWlu/dmllcm5vLXBsYW5h/cy5wbmc  " alt="Alternate Text" visible="true" />
            <p>¡Empieza un carrito de compras!</p>
            <p>Sumá productos y conseguí envío gratis.</p>
            <a href="Default.aspx" class="btn btn-primary px-4 py-2">Descubrir Productos</a>
        </section>
    </asp:Panel>

    <asp:Panel ID="TablaCarrito" runat="server" Visible="true">
        <section class="py-5">
            <table class="table text-start px-5">
                <thead class="table-dark">
                    <tr>
                        <th scope="col"></th>
                        <th scope="col">Imagen</th>
                        <th scope="col">Nombre</th>
                        <th scope="col">Categoria</th>
                        <th scope="col">Marca</th>
                        <th scope="col">Precio</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="CarritoRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Button ID="EliminarProducto" CssClass="btn btn-danger" OnClick="EliminarProducto_Click" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloParaBorrarId" runat="server" Text="X" />
                                </td>
                                <td>
                                    <img src="<%#Eval("Imagenes[0].UrlImagen")%>" alt="Alternate Text" onerror='javascript: this.src="https://cdn4.iconfinder.com/data/icons/ui-beast-3/32/ui-49-4096.png"' width="100" />
                                </td>
                                <td><%#Eval("Nombre")%></td>
                                <td><%#Eval("Categoria.Description")%></td>
                                <td><%#Eval("Marca.Description")%></td>
                                <td>
                                    <%#Eval("Precio")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="5" class="text-end">Total</td>
                        <td>
                            <asp:Label ID="Total" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                </tfoot>
            </table>
        </section>
    </asp:Panel>
</asp:Content>
