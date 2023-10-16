using ArticulosAppModels;
using ArticulosAppServices;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Management;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace ArticulosAppWeb
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ActualizarContadorCarrito();
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
                List<Imagen> imagenes = serviceImagen.GetAllByIdArticulo(articulo.Id);
                articulo.Imagenes = OrganizarImagenes(imagenes);
            }

            return ListaArticulos; 
        }

        private bool esImagenValida(string url)
        { 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.AllowAutoRedirect = false;

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode) return true;

                return false;
            }
        }

        private List<Imagen> OrganizarImagenes(List<Imagen> imagenes)
        {
            List<Imagen> imagenesOrganizadas = new List<Imagen>();

            foreach (Imagen imagen in imagenes)
            {
                if (esImagenValida(imagen.UrlImagen))
                {
                    imagenesOrganizadas.Insert(0, imagen);
                }
                else
                {
                    imagenesOrganizadas.Add(imagen);
                }
            }

            return imagenesOrganizadas;
        }


        public bool ExisteSesion()
        {
            if (Session["Carrito"] != null)
            {
                return true;
            }           

            return false;
        }

        private void IniciarSesion()
        {
            if (ExisteSesion()) return;

            Session.Add("Carrito", new List<Articulo>());
            ActualizarContadorCarrito();
        }

        private void CerrarSesion()
        {
            if (!ExisteSesion()) return;

            Session.Remove("Carrito");
            ActualizarContadorCarrito();
        }

        public void VaciarSesion()
        {
            if (!ExisteSesion()) return;

            ObtenerSesion().Clear();
            ActualizarContadorCarrito();
        }

        public List<Articulo> ObtenerSesion()
        {
            return (List<Articulo>)Session["Carrito"];
        }

        public void AgregarArticuloSesion(Articulo articulo)
        {
            if (!ExisteSesion())
            {
                Debug.WriteLine("No existe sesion pero...");

                IniciarSesion();

                Debug.WriteLine("Se creo sesion");
            };

            ObtenerSesion().Add(articulo);
            ActualizarContadorCarrito();
        }

        public void SacarArticuloSesion(Articulo articulo)
        {
            if (!ExisteSesion()) return;
            if (!(ObtenerSesion().Exists(x => x.Id == articulo.Id)))
            {
                return;
            }

            MostrarSesion();

            if (ObtenerSesion().Remove(ObtenerSesion().Where(x => x.Id == articulo.Id).First()))
            {
                Debug.WriteLine("Se removio articulo");
            }
            else
            {
                Debug.WriteLine("No se removio articulo");
            }

            ActualizarContadorCarrito();
            Response.Redirect("/Carrito.aspx");
        }

        private void ActualizarContadorCarrito()
        {
            if (!ExisteSesion())
            {
                lblCarrito.Text = "0";
                return;
            }

            lblCarrito.Text = ObtenerSesion().Count.ToString();
        }

        public void MostrarSesion()
        {
            if (!ExisteSesion())
            {
                System.Diagnostics.Debug.WriteLine("No existe sesion");
                return;
            }

            foreach (Articulo articulo in ObtenerSesion())
            {
                System.Diagnostics.Debug.WriteLine("ID: " + articulo.Id + ", NOMBRE: " + articulo.Nombre);
            }

            System.Diagnostics.Debug.WriteLine("Cantidad de articulos: " + ObtenerSesion().Count);
            System.Diagnostics.Debug.WriteLine("FINALIZO MUESTREO");
        }

    }
}