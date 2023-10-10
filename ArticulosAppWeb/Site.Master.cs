using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArticulosAppWeb
{
    public partial class Site : System.Web.UI.MasterPage
    {
        string cantidadEnCarrito = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                cantidadEnCarrito = ObtenerCantidadEnCarrito();

                ActualizarContador();
            }
        }

        // Función para actualizar el contador en el control Label
        private void ActualizarContador()
        {
            lblCarrito.Text = cantidadEnCarrito;
        }

        
        private string ObtenerCantidadEnCarrito()
        {
           
            if (ViewState["Pasaje"] != null)
            {
                cantidadEnCarrito = ViewState["Pasaje"].ToString();
            }

            return cantidadEnCarrito; 
        }
    }
}