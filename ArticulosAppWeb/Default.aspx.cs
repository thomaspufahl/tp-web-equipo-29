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
            if (!IsPostBack)
            {
                ArticuloService service = new ArticuloService();
                ListaArticulos = service.GetAll();
                ParentRepeater.DataSource = ListaArticulos;
                ParentRepeater.DataBind();
            }
        }

        protected void ItemBound(object sender, RepeaterItemEventArgs args)
        {
            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
                ImagenService service = new ImagenService();
                ListaArticulos[args.Item.ItemIndex].Imagenes = new List<Imagen>();
                ListaArticulos[args.Item.ItemIndex].Imagenes = service.GetAllByIdArticulo(ListaArticulos[args.Item.ItemIndex].Id);                

                Repeater childRepeater = (Repeater)args.Item.FindControl("ChildRepeater");
                childRepeater.DataSource = ListaArticulos[args.Item.ItemIndex].Imagenes;
                childRepeater.DataBind();
            }
        }



    
    }
}