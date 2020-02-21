using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.BL
{
    public class ProductosBL
    {
        Contexto _contexto;

        public List<Productos> ListadeProductos { get; set; }

        public ProductosBL()
        {
            _contexto = new Contexto();
            ListadeProductos = new List<Productos>();

        }
        public List<Productos> ObtenerProductos()
        {
                  
            ListadeProductos = _contexto.Productos.ToList();
            return ListadeProductos;
        }
    }
}
