using ArticulosAppModels;
using ArticulosAppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;



namespace ArticulosAppWeb
{
    public partial class Producto : System.Web.UI.Page
    {
        public string ArticuloId;
        public Articulo ArticuloPagina;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("/");
            }

            try
            {
                ArticuloId = Request.QueryString["id"].ToString();
                ArticuloPagina = ((Site)Master).ObtenerListaArticulos().Where(x => x.Id == int.Parse(ArticuloId)).FirstOrDefault();

                NombreProducto.InnerText = ArticuloPagina.Nombre.ToString();
                ImagenPrincipalArticulo.Src = ArticuloPagina.Imagenes.ElementAt(0).UrlImagen;
                PrecioProducto.Text = "$ " + ArticuloPagina.Precio.ToString();
                DescripcionArticulo.Text = ArticuloPagina.Descripcion.ToString();
                lblCategoria.Text = ArticuloPagina.Categoria.ToString();
                lblMarca.Text = ArticuloPagina.Marca.ToString();

                ActualizarIndiceImagen();
            }
            catch (Exception)
            {
                Response.Redirect("/");
            }

            if (!IsPostBack)
            {

                ddlUnidades.Items.Add("1 Unidad");
                ddlUnidades.Items.Add("2 Unidades");
                ddlUnidades.Items.Add("3 Unidades");
                ddlUnidades.Items.Add("4 Unidades");
                ddlUnidades.Items.Add("5 Unidades");
                ddlUnidades.Items.Add("Mas de 5 Unidades");
            }

        }

        private void ActualizarIndiceImagen()
        {
            int indiceImagen = IndiceImagenPrincipal();

            if (indiceImagen == -1)
            {
                return;
            }

            CantidadImagenes.InnerText = $"Imagen {indiceImagen+1}/{ArticuloPagina.Imagenes.Count}";
        }

        private int IndiceImagenPrincipal()
        {
            foreach (Imagen imagen in ArticuloPagina.Imagenes)
            {
                if (imagen.UrlImagen == ImagenPrincipalArticulo.Src)
                {
                    return ArticuloPagina.Imagenes.IndexOf(imagen);
                }
            }

            return -1;
        }

        protected void Siguiente_Click(object sender, EventArgs e)
        {
            int indiceImagen = IndiceImagenPrincipal();

            if (indiceImagen < ArticuloPagina.Imagenes.Count - 1)
            {
                ImagenPrincipalArticulo.Src = ArticuloPagina.Imagenes.ElementAt(indiceImagen+1).UrlImagen;
                ActualizarIndiceImagen();
            }
        }


        protected void Atras_Click(object sender, EventArgs e)
        {
            int indiceImagen = IndiceImagenPrincipal();

            if (indiceImagen > 0)
            {
                ImagenPrincipalArticulo.Src = ArticuloPagina.Imagenes.ElementAt(indiceImagen-1).UrlImagen;
                ActualizarIndiceImagen();
            }
        }

        protected void btnAgregarAlCarrito_Click(object sender, EventArgs e)
        {
            int cantidadUndiades = 0;
            switch (ddlUnidades.Text)
            {
                case "1 Unidad": cantidadUndiades = 1; break;   
                case "2 Unidades": cantidadUndiades = 2; break;   
                case "3 Unidades": cantidadUndiades = 3; break;   
                case "4 Unidades": cantidadUndiades = 4; break;   
                case "5 Unidades": cantidadUndiades = 5; break;   
                case "Mas de 5 Unidades": cantidadUndiades = 6; break;   

            }
            for (int i = 0; i < cantidadUndiades; i++)
            {
                ((Site)Master).AgregarArticuloSesion(ArticuloPagina);
            }
        }
    }
}