using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ModuloStock
{
    class VentanaInicio
    {
        List<Usuario> usuarios = new List<Usuario>();

        public VentanaInicio()
        {
            InizializarUsuarios();
        }

        private void InizializarUsuarios()
        {
            usuarios.Add(new Usuario(1, "Juan", 200, "e"));
            usuarios.Add(new Usuario(2, "Mariel", 10, "a"));
            usuarios.Add(new Usuario(3, "Juana", 10, "e"));
        }

        public void IniciarAplicacion()
        {

            Console.Title = "Trabajo Practico Estructura de datos.";
            string titulo = @"                 
             _____  ______  _______  _____        __   ___  
            |_   _||  ____||__   __|/ ____|      /_ | / _ \ 
              | |  | |__      | |  | (___         | || (_) |
              | |  |  __|     | |   \___ \        | | > _ < 
             _| |_ | |        | |   ____) |       | || (_) |
            |_____||_|        |_|  |_____/        |_| \___/ 
                                                             
                                                             ";
            Console.WriteLine(titulo);
            // en la variable stockInv//
            Console.Write("Ingresa tu codigo de usuario: ");
            string respuesta = Console.ReadLine();
            int codigoUsuario = 0;
            int.TryParse(respuesta, out codigoUsuario);
            if (!usuarios.Any(x => x.Codigo == codigoUsuario))
            {
                Console.WriteLine("Error el usuario no existe, intente de nuevo");
                Thread.Sleep(1800);
                Console.Clear();
                IniciarAplicacion();
            }
            else
            {
                Usuario usuario = usuarios.First(x => x.Codigo == codigoUsuario);
                if (usuario.Type == "a")
                {
                    VentanaAdmin admin = new VentanaAdmin();
                    admin.PanelAdmin();
                }
                else
                {
                    VentanaUsuario ventanaUsuario = new VentanaUsuario();
                    ventanaUsuario.ventanaUsuario(usuario);
                }

            }


        }
    }
}
