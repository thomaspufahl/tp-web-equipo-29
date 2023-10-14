using ArticulosAppModels;
using ArticulosAppServices;
using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                ArticuloId = Request.QueryString["id"].ToString();
                ArticuloPagina = ((Site)Master).ObtenerListaArticulos().Where(x => x.Id == int.Parse(ArticuloId)).FirstOrDefault();

                NombreProducto.InnerText = ArticuloPagina.Nombre.ToString();
                ImagenPrincipalArticulo.Src = ArticuloPagina.Imagenes.ElementAt(0).UrlImagen;
                PrecioProducto.Text = "$ " +  ArticuloPagina.Precio.ToString();   
                DescripcionArticulo.Text = ArticuloPagina.Descripcion.ToString();
                
                

                //ListaImagenesRepeater.DataSource = ArticuloPagina.Imagenes;
                //ListaImagenesRepeater.DataBind();
            }
            catch (Exception)
            {
                Response.Redirect("/");
            }          
        }

        protected void Siguiente_Click(object sender, EventArgs e)
        {
            try
            {
            ImagenPrincipalArticulo.Src = ArticuloPagina.Imagenes.ElementAt(0 + 1).UrlImagen;

            }
            catch
            {
                ImagenPrincipalArticulo.Src = ArticuloPagina.Imagenes.ElementAt(0).UrlImagen;
             
            }
        }

        protected void Atras_Click(object sender, EventArgs e)
        {

            try
            {
                ImagenPrincipalArticulo.Src = ArticuloPagina.Imagenes.ElementAt(0 - 1).UrlImagen;

            }
            catch 
            { 
                ImagenPrincipalArticulo.Src = ArticuloPagina.Imagenes.ElementAt(0).UrlImagen;
               
            }

        }
    }
}