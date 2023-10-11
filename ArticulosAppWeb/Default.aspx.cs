using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ArticulosAppServices;
using ArticulosAppModels;
using System.Web.DynamicData;
using System.Net;
using static System.Net.WebRequestMethods;
using System.Net.Http;

namespace ArticulosAppWeb
{
    public partial class Default : System.Web.UI.Page
    {
        private CarritoContext _Context = CarritoContext.Instance;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ParentRepeater.DataSource = ((Site)Page.Master).ObtenerListaArticulos();
                ParentRepeater.DataBind();
            }
        }           

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.CommandName.Equals("ArticuloId"))
            {
                Articulo ArticuloParaCarrito = ((Site)Master).ObtenerListaArticulos().Where(a => a.Id == int.Parse(btn.CommandArgument)).First();

                System.Diagnostics.Debug.WriteLine("ArticuloParaCarrito.Id: " + ArticuloParaCarrito.Id);    
                System.Diagnostics.Debug.WriteLine("ArticuloParaCarrito.Nombre: " + ArticuloParaCarrito.Descripcion);

                _Context.CarritoArticulos.AgregarArticulo(ArticuloParaCarrito);
            }
        }
    }
}