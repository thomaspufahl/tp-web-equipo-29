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
        Articulo ArticuloPagina;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArticuloId = Request.QueryString["id"].ToString();
                //TituloProducto.InnerText = "Producto " + ArticuloId;
                ArticuloService articuloService = new ArticuloService();
                ArticuloPagina = articuloService.GetAll().Find(x => x.Id == int.Parse(ArticuloId));
            }
            catch (Exception)
            {
                Response.Redirect("/");
            }
        }
    }
}