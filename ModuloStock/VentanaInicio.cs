using System;
using System.Collections.Generic;
using System.Text;
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
            // en la variable stockInv//
            
            //stockInv.ImprimirProductos();//se llama la funcion imprimir de la clase stock

            Console.Write("Ingresa tu codigo de usuario: ");
            Console.ReadLine();
            Thread.Sleep(1000);
            //Stock.stock.InicializarStock();
            //stockInv.InicializarStock();
            VentanaUsuario user = new VentanaUsuario();
            user.ventanaUsuario();
        }
    }
}
