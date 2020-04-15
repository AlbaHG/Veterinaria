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

            ListadeProductos = _contexto.Productos
                .Include("Categoria")
                .OrderBy(r => r.Categoria.Descripcion) //AGREGADO
                .ThenBy(r => r.Descripcion)            //AGREGADO
                .ToList();


            return ListadeProductos;
        }

        public List<Productos> ObtenerProductosActivo()
        {

            ListadeProductos = _contexto.Productos
                .Include("Categoria")
                .Where(r => r.Activo == true)
                .OrderBy(r => r.Categoria.Descripcion) //AGREGADO
                .ThenBy(r => r.Descripcion)            //AGREGADO
                .ToList();


            return ListadeProductos;
        }

        public List<Productos> ObtenerProductosActivos()
        {
            ListadeProductos = _contexto.Productos
                   .Include("Categoria")
                   .Where(r => r.Activo == true)
                   .OrderBy(r => r.Descripcion)
                   .ToList();

            return ListadeProductos;
        }

        public void GuardarProductos(Productos productos)
        {
            if(productos.Id == 0)
            {
                _contexto.Productos.Add(productos);
            } else
            {
                var productosExistente = _contexto.Productos.Find(productos.Id);

                productosExistente.Descripcion = productos.Descripcion;
                productosExistente.CategoriaId = productos.CategoriaId;
                productosExistente.Precio = productos.Precio;
                
                productosExistente.UrlImagen = productos.UrlImagen;
                
            }
            
            _contexto.SaveChanges();
        }

        public Productos ObtenerProductos(int id)
        {
            var productos = _contexto.Productos
                .Include("Categoria").FirstOrDefault(p => p.Id == id);

            return productos;
        }

        public void EliminarProductos(int id)
        {
            var productos = _contexto.Productos.Find(id);

            _contexto.Productos.Remove(productos);
            _contexto.SaveChanges();
        }
    }
}
