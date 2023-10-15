<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="ArticulosAppWeb.Carrito1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <asp:Panel ID="NoHayProductos" runat="server" Visible="false" CssClass="text-center">

        <img runat="server" id="ImagenBolsa" style="width: 450px" src="https://imgs.search.brave.com/PW8qry7f0BsFCTAbmrzJfKohuDfrc4JAhVqbF3jj96I/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9pbWFn/ZXMudmV4ZWxzLmNv/bS9tZWRpYS91c2Vy/cy8zLzE5MjQ1MS9p/c29sYXRlZC9wcmV2/aWV3LzY3NzIzZjJl/OWU4ZWQ2YjZhMTgx/OGUyMTU1NzkzMTMy/LWJvbHNhcy1kZS1j/b21wcmFzLWRlLWlu/dmllcm5vLXBsYW5h/cy5wbmc  " alt="Alternate Text" visible="true" />
        <p>¡Empieza un carrito de compras!</p>
        <p>Sumá productos y conseguí envío gratis.</p>
        <a href="Default.aspx" class="btn btn-primary" style="width: 200px; height: 50px; padding: 10px">Descubrir Productos</a>
    </asp:Panel>

    <asp:Panel ID="TablaCarrito" runat="server" Visible="true">
        <table class="table">
            <thead class="table-dark">
                <tr>
                    <th scope="col">Imagen</th>
                    <th scope="col">Nombre</th>
                    <th scope="col">Categoria</th>
                    <th scope="col">Marca</th>
                    <th scope="col">Precio</th>
                </tr>
            </thead>
            <asp:Repeater ID="CarritoRepeater" runat="server">
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td>
                                <img src="<%#Eval("Imagenes[0].UrlImagen")%>" alt="Alternate Text" onerror='javascript: this.src="https://cdn4.iconfinder.com/data/icons/ui-beast-3/32/ui-49-4096.png"' width="100px" height="100px" />
                            </td>
                            <td><%#Eval("Nombre")%></td>
                            <td><%#Eval("Categoria.Description")%></td>
                            <td><%#Eval("Marca.Description")%></td>
                            <td><%#Eval("Precio")%></td>
                    </tbody>

                </ItemTemplate>
            </asp:Repeater>
        </table>
    </asp:Panel>
</asp:Content>

<asp:Content ID="FooterCarrito" ContentPlaceHolderID="FooterPredeterminado" runat="server">
    <footer class="bg-dark text-center text-bg-secondary fst-italic p-3" style="bottom: 0; position: absolute; width: 100%">
        <ul class="d-flex flex-rows justify-content-between p-0 m-0" style="list-style: none;">
            <li class="fw-bolder text-start text-">Año 2023 </li>
            <li class="fst-italic text-center">Nicolas Rodriguez    Thomas Pufahl</li>
            <li class="fst-italic text-end">Programacion 3</li>
        </ul>
    </footer>
</asp:Content>
