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
        public int contador { get; set; }
        public Articulo articulo { get; set; }
        private List<Articulo> ListaArticulos = null;
        private List<Articulo> Carrito = new List<Articulo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                contador = 0;
                ArticuloService service = new ArticuloService();
                ImagenService serviceImagen = new ImagenService();
                
                ListaArticulos = service.GetAll();

                foreach (Articulo articulo in ListaArticulos)
                {
                    articulo.Imagenes = new List<Imagen>();
                    articulo.Imagenes = serviceImagen.GetAllByIdArticulo(articulo.Id);
                }                               

                ParentRepeater.DataSource = ListaArticulos;
                ParentRepeater.DataBind();


            }
        }           

        private void validateImages()
        {
            //imagen.UrlImagen = "https://cdn4.iconfinder.com/data/icons/ui-beast-3/32/ui-49-4096.png";
        }

        protected void Image1_Unload(object sender, EventArgs e)
        {
            Image img = (Image)sender;

            System.Diagnostics.Debug.WriteLine("Image1_Unload");    

            img.ImageUrl = "https://cdn4.iconfinder.com/data/icons/ui-beast-3/32/ui-49-4096.png";
        }

        private void AgregarAlCarrito (Articulo articulo)
        {
            Carrito.Add(articulo);

        }

        protected void miRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "btnAgregarCarrito_Click")
            {
                // Accede al objeto asociado al ítem del Repeater
                articulo = (Articulo)e.Item.DataItem;

                AgregarAlCarrito(articulo);
                contador++;
                ViewState["Pasaje"] = "contador";


            }
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
           
        }
    }
}