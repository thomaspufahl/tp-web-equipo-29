using ArticulosAppModels;
using ArticulosAppServices;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                articulo.Imagenes = serviceImagen.GetAllByIdArticulo(articulo.Id);
            }

            return ListaArticulos; 
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

            ObtenerSesion().Remove(articulo);
            ActualizarContadorCarrito();
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