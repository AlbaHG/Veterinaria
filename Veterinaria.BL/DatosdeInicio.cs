using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.BL
{
    public class DatosdeInicio: CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var nuevoUsuario = new Usuario();
            nuevoUsuario.Nombre = "admin";
            nuevoUsuario.Contrasena = Encriptar.CodificarContrasena("123");

            var primerUsuario = new Usuario();
            primerUsuario.Nombre = "Alba";
            primerUsuario.Contrasena = Encriptar.CodificarContrasena("Gomez123");

            var segundoUsuario = new Usuario();
            segundoUsuario.Nombre = "Rosendo";
            segundoUsuario.Contrasena = Encriptar.CodificarContrasena("Yanes123");

            var tercerUsuario = new Usuario();
            tercerUsuario.Nombre = "Dalila";
            tercerUsuario.Contrasena = Encriptar.CodificarContrasena("Daly123");


            contexto.Usuarios.Add(nuevoUsuario);
            contexto.Usuarios.Add(primerUsuario);
            contexto.Usuarios.Add(segundoUsuario);
            contexto.Usuarios.Add(tercerUsuario);

            base.Seed(contexto);
        }
    }
}
