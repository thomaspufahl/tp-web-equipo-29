﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ArticulosAppWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <main class="d-flex flex-column flex-xxl-row gap-5 px-5 py-4" style="background: #dcdcdc; place-content: right;">
        <aside class="d-flex flex-column justify-content-start" style="width: 25rem">
            <h2 class="mb-4">Filtros</h2>
            <div class="d-flex flex-column gap-2 card py-4 px-3">

                <div class="d-flex me-3" role="search">
                    <input runat="server" id="InputBuscar" class="form-control me-2" type="search" placeholder="buscar por nombre" aria-label="buscar">
                    <asp:Button id="btnBuscar" runat="server" class="btn btn-outline-success" type="submit" Text="Buscar" OnClick="btnBuscar_Click"/>
                </div>

                <a class="btn btn-primary" href="/">Borrar filtro</a>

                <div class="d-flex flex-column gap-3 mt-2">
                    <div>
                        <p>Marcas</p>
                        <ul class="d-flex flex-column gap-2 mt-1 ps-3" style="list-style: none;">
                            <asp:Repeater ID="MarcasRepeater" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <a style="color: inherit" href="Default.aspx?filtro=marca&value=<%#Eval("Description")%>"><%#Eval("Description")%></a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div>
                        <p>Categorías</p>
                        <ul class="d-flex flex-column gap-2 mt-1 ps-3" style="list-style: none;">
                            <asp:Repeater ID="CategoriasRepeater" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <a style="color: inherit" href="Default.aspx?filtro=categoria&value=<%#Eval("Description")%>"><%#Eval("Description")%></a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </div>
        </aside>
        <section>
            <h2 class="mb-4">Artículos</h2>
            <ul runat="server" id="listaArticulos" class="d-flex flex-wrap row-gap-5 m-0 p-0 place justify-content-evenly justify-content-xxl-between" style="list-style: none">
                <asp:Repeater ID="ParentRepeater" runat="server">
                    <ItemTemplate>
                        <li>
                            <article class="card d-flex" style="max-width: 21rem">
                                <header class="card-body text-wrap">
                                    <div style="min-height: 302px" class="d-flex">
                                        <img id="imagenArt" src="<%#Eval("Imagenes[0].UrlImagen")%>" alt="<%#Eval("Nombre")%>" onerror='javascript: this.src="https://cdn4.iconfinder.com/data/icons/ui-beast-3/32/ui-49-4096.png"' class="card-img" style="height: fit-content; align-self: center"/>
                                    </div>
                                    <h5 class="card-title"><%#Eval("Nombre")%></h5>
                                    <p class="card-text"><%#Eval("Descripcion") %></p>
                                </header>
                                <ul class="list-group list-group-flush">
                                    <li class="list-group-item" style="color: #4aaa2e"><%#Eval("Categoria.Description") %> </li>
                                    <li class="list-group-item" style="color: #4aaa2e"><%#Eval("Marca.Description") %></li>
                                </ul>
                                <footer class="card-footer d-flex gap-2">
                                    <a class="btn btn-dark" href="Producto.aspx?id=<%#Eval("id")%>">Mas información</a>
                                    <asp:Button ID="btnAgregarCarrito" OnClick="btnAgregarCarrito_Click" CommandArgument='<%#Eval("id")%>' CommandName="ArticuloId" CssClass="btn btn-danger" runat="server" Text="Agregar al carrito" />
                                </footer>
                            </article>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </section>
    </main>
</asp:Content>
