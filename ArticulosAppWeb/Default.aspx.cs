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
using System.Diagnostics;

namespace ArticulosAppWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MarcaService marcaService = new MarcaService();
                CategoriaService categoriaService = new CategoriaService();

                MarcasRepeater.DataSource = marcaService.GetAll();
                MarcasRepeater.DataBind();

                CategoriasRepeater.DataSource = categoriaService.GetAll();
                CategoriasRepeater.DataBind();


                if (Request.QueryString["filtro"] == null)
                {
                    ParentRepeater.DataSource = ((Site)Page.Master).ObtenerListaArticulos();
                    ParentRepeater.DataBind();
                }
            }

            ActualizarListaPorFiltro();
        }           

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.CommandName.Equals("ArticuloId"))
            {
                Articulo ArticuloParaCarrito = ((Site)Master).ObtenerListaArticulos().Where(a => a.Id == int.Parse(btn.CommandArgument)).First();

                ((Site)Master).AgregarArticuloSesion(ArticuloParaCarrito);
            }
        }

        private void ActualizarListaPorFiltro()
        {
            if (Request.QueryString["filtro"] != null)
            {
                string filtro = Request.QueryString["filtro"].ToString();
                string value = Request.QueryString["value"].ToString() ?? string.Empty;

                if (value.Equals(string.Empty))
                {
                    Response.Redirect("Default.aspx");
                    return;
                }

                if (filtro.Equals("marca"))
                {
                    ParentRepeater.DataSource = ((Site)Page.Master).ObtenerListaArticulos().FindAll(a => a.Marca.Description.Equals(value));
                    ParentRepeater.DataBind();
                }

                if (filtro.Equals("categoria"))
                {
                    ParentRepeater.DataSource = ((Site)Page.Master).ObtenerListaArticulos().FindAll(a => a.Categoria.Description.Equals(value));
                    ParentRepeater.DataBind();
                }

                if (filtro.Equals("busqueda"))
                {
                    ParentRepeater.DataSource = ((Site)Page.Master).ObtenerListaArticulos().FindAll(a => a.Nombre.ToLower().Contains(value.ToLower()));
                    ParentRepeater.DataBind();
                }

                listaArticulos.Attributes["class"] = "d-flex flex-wrap row-gap-5 gap-5 m-0 p-0 place justify-content-evenly justify-content-xxl-between";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx?filtro=busqueda&value=" + InputBuscar.Value);
        }
    }
}