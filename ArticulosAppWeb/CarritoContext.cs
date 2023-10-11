using ArticulosAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArticulosAppWeb
{
    public class CarritoContext
    {
        private static readonly CarritoContext _Instance = new CarritoContext();
        public Carrito CarritoArticulos { get; private set; }
        private CarritoContext() 
        {
            CarritoArticulos = new Carrito();
        }

        public static CarritoContext Instance
        {
            get
            {
                return _Instance;
            }
        }
    }
}