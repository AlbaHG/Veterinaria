using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.BL;

namespace Veterinaria.BL
{
    public class ClientesBL
    {
        Contexto _contexto;
        public List<Clientes> ListadeClientes { get; set; }

        public ClientesBL()
        {
           _contexto = new Contexto();
           ListadeClientes = new List<Clientes>();
        }

        public List<Clientes> ObtenerClientes()
        {
            ListadeClientes = _contexto.Clientes
                .OrderBy(r => r.Nombre)
                .ToList();

            return ListadeClientes;
        }
        public List<Clientes> ObtenerClientesActivos()
        {
            ListadeClientes = _contexto.Clientes
                .Where(r => r.Activo == true)
                .OrderBy(r => r.Nombre)
                .ToList();

           return ListadeClientes;

        }
        public void GuardarCliente(Clientes clientes)
        {
              if (clientes.Id == 0)
             {
            _contexto.Clientes.Add(clientes);
            
            }
             else        
            {
                var clienteExistente = _contexto.Clientes.Find(clientes.Id);

                clienteExistente.Nombre = clientes.Nombre;
                clienteExistente.Telefono = clientes.Telefono;
                clienteExistente.Direccion = clientes.Direccion;
                clienteExistente.Activo = clientes.Activo;
                               
                }

             _contexto.SaveChanges();

        }
       public Clientes ObtenerClientes(int id)
       {
            var cliente = _contexto.Clientes.Find(id);

            return cliente;
       }
        public void EliminarClientes(int id)
        {
            var clientes = _contexto.Clientes.Find(id);

            _contexto.Clientes.Remove(clientes);
            _contexto.SaveChanges();

        }


        }

    }

