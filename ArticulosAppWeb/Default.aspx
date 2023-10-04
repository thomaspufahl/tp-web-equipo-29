<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ArticulosAppWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:Repeater id = "repDatos" runat="server">
        <ItemTemplate>
            <div class="card" style="width: 18rem;">  
                <img src="#" class="card-img-top" alt="Imagen">
                <div class="card-body">
                    <h5 class="card-title"> <%#Eval("Nombre") %> </h5>
                    <p class="card-text"><%#Eval("Descripcion") %></p>
                </div>
                <ul class="list-group list-group-flush">
                    <li class="list-group-item"><%#Eval("Categoria.Description") %> </li>
                    <li class="list-group-item"><%#Eval("Marca.Description") %></li>
                    <li class="list-group-item"><%#Eval("Precio") %></li>
                </ul>
                <div class="card-body d-flex gap-2">
                    <asp:Button ID="btnInformacion" cssclass = "btn btn-dark"  runat ="server" Text="Mas Informacion"/>
                    <asp:Button ID="btnAgregarCarrito" cssclass = "btn btn-danger" runat="server" Text="Agregar al carrito"/>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
