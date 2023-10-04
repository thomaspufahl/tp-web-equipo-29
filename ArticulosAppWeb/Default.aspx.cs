using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ArticulosAppServices;
using ArticulosAppModels;
using System.Web.DynamicData;

namespace ArticulosAppWeb
{
    public partial class Default : System.Web.UI.Page
    {

        private List<Articulo> ListaArticulos = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloService service = new ArticuloService();
            ListaArticulos = service.GetAll();
            repDatos.DataSource = ListaArticulos;
            repDatos.DataBind();

        }


    
    }
}