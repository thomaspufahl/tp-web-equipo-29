<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="ArticulosAppWeb.Producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <section>
        <asp:GridView runat="server" ID="gvArticulo" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image ID="imgArticulo" runat="server" CssClass="img-thumbnail" ImageUrl=<%# Eval("imagenes[0].UrlImagen") %> Width="700px" Height="500px" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="flex-row px-5 py-5">
                            <h5 class="text-dark ">$ <%#Eval("Precio") %></h5>
                            <br />
                            <h4><%#Eval("Descripcion") %></h4>
                            <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary" Text="Agregar" OnClick="btnAgregar_Click" />
                            <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" />

                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>



        </asp:GridView>
    </section>
</asp:Content>
