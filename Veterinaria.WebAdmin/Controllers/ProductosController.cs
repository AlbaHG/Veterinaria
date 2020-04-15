using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Veterinaria.BL;

namespace Veterinaria.WebAdmin.Controllers
{
    [Authorize]
    public class ProductosController : Controller
    {
        ProductosBL _productosBL;
        CategoriasBL _categoriasBL;

        public ProductosController()
        {
            _productosBL = new ProductosBL();
            _categoriasBL = new CategoriasBL();
        }

        // GET: Productos
        public ActionResult Index()
        {
            var listadeproductos = _productosBL.ObtenerProductos();

            return View(listadeproductos);
        }

    
        public ActionResult Crear()
        {
            var nuevoProducto = new Productos();
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");

            return View(nuevoProducto);
        }

        [HttpPost]
        public ActionResult Crear(Productos productos, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (productos.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(productos);
                }

                if (imagen != null)
                {
                    productos.UrlImagen = GuardarImagen(imagen);
                }
                _productosBL.GuardarProductos(productos);

                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");

            return View(productos);
            
        }

        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);

            return "/Imagenes/" + imagen.FileName;

        }



        public ActionResult Editar(int id)
        {
            var productos = _productosBL.ObtenerProductos(id);
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion", productos.CategoriaId);

            return View(productos);
        }

        [HttpPost]
        public ActionResult Editar(Productos productos, HttpPostedFileBase imagen)  //Agregue HTT IMAG
        {
            if (ModelState.IsValid)
            {
                if (productos.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(productos);
                }
                if (imagen != null) // AGREGUE
                {
                    productos.UrlImagen = GuardarImagen(imagen); //AGREGUE
                }
                _productosBL.GuardarProductos(productos);

                return RedirectToAction("Index");

            }

            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");

            return View(productos);
        }

        public ActionResult Detalles(int id)
        {
            var producto = _productosBL.ObtenerProductos(id);

            return View(producto);
        }

        public ActionResult Eliminar(int id)
        {
            var producto = _productosBL.ObtenerProductos(id);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(Productos productos)
        {
            _productosBL.EliminarProductos(productos.Id);

            return RedirectToAction("Index");
        }

   
        }
    }
