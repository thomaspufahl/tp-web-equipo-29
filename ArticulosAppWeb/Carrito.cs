using ArticulosAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArticulosAppWeb
{
    public class Carrito
    {
        private List<Articulo> _ListaArticulos;

        public Carrito()
        {
            _ListaArticulos = new List<Articulo>();
        }

        public void AgregarArticulo(Articulo articulo)
        {
            _ListaArticulos.Add(articulo);
        }

        public void EliminarArticulo(Articulo articulo)
        {
            _ListaArticulos.Remove(articulo);
        }

        public List<Articulo> ListaArticulos
        {
            get { return _ListaArticulos; }
        }

        public int CantidadArticulos
        {
            get { return _ListaArticulos.Count; }
        }
    }
}