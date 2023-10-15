using ArticulosAppModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        protected void EliminarProducto_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            Debug.WriteLine("ENTRE");

            if (btn.CommandName.Equals("ArticuloParaBorrarId"))
            {
                Debug.WriteLine("PASE EL IF");
                Articulo ArticuloSeleccionado = ((Site)Master).ObtenerListaArticulos().Where(a => a.Id == int.Parse(btn.CommandArgument)).First();

                ((Site)Master).SacarArticuloSesion(ArticuloSeleccionado);
                Debug.WriteLine("EJECUTE");
            }
        }
    }
}