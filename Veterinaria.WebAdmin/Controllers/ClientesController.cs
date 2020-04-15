using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Veterinaria.BL;

namespace Veterinaria.WebAdmin.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        ClientesBL _clientesBL;

        public ClientesController()
        {
            _clientesBL = new ClientesBL();

        }
        // GET: Clientes
        public ActionResult Index()
        {
            var listadeClientes = _clientesBL.ObtenerClientes();

            return View(listadeClientes);
        }

        public ActionResult crear()
        {
            var nuevoCliente = new Clientes();

            return View(nuevoCliente);
        }
        [HttpPost]
        public ActionResult Crear(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                _clientesBL.GuardarCliente(cliente);

                return RedirectToAction("Index");
            }
            return View(cliente);
        }


        public ActionResult Editar(int id)
        {
            var cliente = _clientesBL.ObtenerClientes(id);

            return View(cliente);
        }
        [HttpPost]
        public ActionResult Editar(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                _clientesBL.GuardarCliente(cliente);

                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Detalle(int id)
        {
            var cliente = _clientesBL.ObtenerClientes(id);

            return View(cliente);
        }

        public ActionResult Eliminar(int id)
        {

            var cliente = _clientesBL.ObtenerClientes(id);

            return View(cliente);
        }
        [HttpPost]
        public ActionResult Eliminar(Clientes cliente)
        {
            _clientesBL.EliminarClientes(cliente.Id);

            return RedirectToAction("Index");
        }


    }
}


