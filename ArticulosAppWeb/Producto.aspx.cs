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

                TituloProducto.InnerText = "Producto " + ArticuloId;
                ImagenPrincipalArticulo.Src = ArticuloPagina.Imagenes.ElementAt(0).UrlImagen;

                ListaImagenesRepeater.DataSource = ArticuloPagina.Imagenes;
                ListaImagenesRepeater.DataBind();
            }
            catch (Exception)
            {
                Response.Redirect("/");
            }          
        }
    }
}