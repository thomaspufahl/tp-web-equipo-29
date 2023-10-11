using ArticulosAppModels;
using ArticulosAppServices;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArticulosAppWeb
{
    public partial class Site : System.Web.UI.MasterPage
    {
        private CarritoContext _Context = CarritoContext.Instance;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblCarrito.Text = "0";
            }

            if (_Context.CarritoArticulos.CantidadArticulos > 0)
            {
                lblCarrito.Text = _Context.CarritoArticulos.CantidadArticulos.ToString();
            }
        }
        
        public List<Articulo> ObtenerListaArticulos()
        {
            ArticuloService service = new ArticuloService();
            ImagenService serviceImagen = new ImagenService();

            List<Articulo> ListaArticulos = service.GetAll();

            foreach (Articulo articulo in ListaArticulos)
            {
                articulo.Imagenes = new List<Imagen>();
                articulo.Imagenes = serviceImagen.GetAllByIdArticulo(articulo.Id);
            }

            return ListaArticulos; 
        }
    }
}