using System;
using System.Threading;

namespace ModuloStock
{
    class VentanaInicio
    {
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
            Console.Write("Ingresa tu codigo de usuario: ");
            Console.ReadLine();
            Thread.Sleep(500);
            VentanaUsuario user = new VentanaUsuario();
            user.PanelUsuario();
        }
    }
}
