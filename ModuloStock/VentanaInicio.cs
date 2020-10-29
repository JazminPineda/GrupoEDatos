using System;
using System.Threading;

namespace ModuloStock
{
    class VentanaInicio
    {
        public void IniciarAplicacion()
        {
            VentanaAdmin admin = new VentanaAdmin();
            int usuario;

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
            Console.WriteLine("Ingresa tu codigo de usuario: Ingresá 00 para entrar como administrador");
            usuario = Convert.ToInt32(Console.ReadLine());
            if (usuario == 00)
            {
                admin.PanelAdmin();
            }
            else
            {
                Thread.Sleep(500);
                VentanaUsuario user = new VentanaUsuario();
                user.PanelUsuario();
            }
        }
    }
}
