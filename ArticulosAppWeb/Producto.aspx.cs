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
        private CarritoContext _Context = CarritoContext.Instance;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlUnidades.Items.Add("1 Unidad");
                ddlUnidades.Items.Add("2 Unidades");
                ddlUnidades.Items.Add("3 Unidades");
                ddlUnidades.Items.Add("4 Unidades");
                ddlUnidades.Items.Add("5 Unidades");
                ddlUnidades.Items.Add("Mas de 5 Unidades");
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
            _Context.CarritoArticulos.AgregarArticulo(ArticuloPagina);
            }

            ((Site)Master).ObtenerContadorCarrito().Text = _Context.CarritoArticulos.CantidadArticulos.ToString();

        }
    }
}