using ArticulosAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArticulosAppWeb
{
    public partial class Carrito1 : System.Web.UI.Page
    {
        List<Articulo> lista;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lista = ((Site)Master).ObtenerSesion();
                if (lista.Count() == 0 && lista != null)
                {
                    NoHayProductos.Visible = true;
                    TablaCarrito.Visible = false;
                }
            }
            catch 
            {
                NoHayProductos.Visible = true;
                TablaCarrito.Visible = false;

            }

            if (!IsPostBack)
            {
                CarritoRepeater.DataSource = ((Site)Master).ObtenerSesion();
                CarritoRepeater.DataBind();
            }

        }
    }
}