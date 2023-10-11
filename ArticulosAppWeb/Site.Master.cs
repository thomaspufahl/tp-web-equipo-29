using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArticulosAppWeb
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public string cantidadEnCarrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblCarrito.Text = "0";               
            }
            else
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
            if (ViewState["Contador"] != null)
            {
                cantidadEnCarrito = ViewState["Contador"].ToString();
            }
            else
            {
            cantidadEnCarrito = "No funca";

            }
            return cantidadEnCarrito;
           


        }
    }
}