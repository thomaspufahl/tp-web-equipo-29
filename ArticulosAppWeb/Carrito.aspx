<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="ArticulosAppWeb.Carrito1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <br />
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
</asp:Content>
<asp:Content ID="FooterCarrito" ContentPlaceHolderID="FooterPredeterminado" runat="server">
    <footer class="bg-dark text-center text-bg-secondary fst-italic p-3" style="bottom:0;position:absolute;width: 100%">
        <ul class="d-flex flex-rows justify-content-between p-0 m-0" style="list-style: none;">
            <li class="fw-bolder text-start text-">Año 2023 </li>
            <li class="fst-italic text-center">Nicolas Rodriguez    Thomas Pufahl</li>
            <li class="fst-italic text-end">Programacion 3</li>
        </ul>
    </footer>
</asp:Content>
