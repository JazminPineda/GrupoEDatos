using System;
using System.Collections.Generic;

namespace ModuloStock
{
    class VentanaUsuario
    {
        //Stock usuarios = new Stock();
        VentanaInicio inicio = new VentanaInicio();
        private double montoInicial = 50; //Variable temporal
        private string producto;
        private Queue<string> list = new Queue<string>();

        public void ventanaUsuario()
        {

            Console.Clear();
            Console.WriteLine($"Usuario: IFTS \nSaldo: {montoInicial} \n\nLista de productos:");
            Stock.stock.ImprimirProductos();
            menuOpciones();

        }


        public void comprar()
        {
            ComprarProducto();
            Console.WriteLine("Desea seguir comprando? SI / NO");
            string respuesta = Console.ReadLine();
            while (respuesta.ToLower() == "si")
            {
                Console.Clear();
                Console.WriteLine($"Usuario: IFTS \nSaldo: {montoInicial} \n\nLista de productos:");
                Stock.stock.ImprimirProductos();
                ComprarProducto();
                Console.WriteLine("Desea seguir comprando? SI / NO");
                respuesta = Console.ReadLine();
            }
            menuOpciones();
        }

        private void ComprarProducto()
        {
            Console.WriteLine("\nIngrese el número del producto que quiere:");
            producto = Console.ReadLine();

            if (!string.IsNullOrEmpty(producto))  //Valida que el código de producto no sea nulo
            {
                int productoNro = Convert.ToInt32(producto);
                if (productoNro > 0 && productoNro < 5)
                {
                    double saldo = saldoDisponible(montoInicial, Stock.stock.ObtenerPrecio(productoNro));
                    if (saldo > 0)
                    {
                        list.Enqueue(Stock.stock.ObtenerNombreProducto(productoNro));
                        montoInicial = saldo;
                        Stock.stock.ObtenerProducto(productoNro); 
                    }
                    else
                    {
                        Console.WriteLine("\nUsted no tiene saldo disponible");
                    }
                }
                else
                {
                    Console.WriteLine("Codigo invalido.");
                    Console.ReadLine();
                }

            }
            else
            {
                Console.WriteLine("Codigo invalido, volvé a intentarlo");
                Console.ReadLine();
            }
        }

        public double saldoDisponible(double saldoCuenta, double precioProducto)
        {
            return saldoCuenta - precioProducto;
        }

        public void menuOpciones()
        {
            string opcionUsuario;

            Console.WriteLine("Menu Usuario: \n1) Saldo disponible \n2) Comprar \n3) Salir");
            Console.WriteLine("\nIngrese una opción:");
            opcionUsuario = Console.ReadLine();

            if (!string.IsNullOrEmpty(opcionUsuario))
            {
                int opcionUsuarioNro = Convert.ToInt32(opcionUsuario);
                switch (opcionUsuarioNro)
                {
                    case 1:
                        //saldoDisponible(montoInicial, Y);
                        Console.WriteLine("Tu saldo es: " + montoInicial);
                        Console.ReadKey();
                        ventanaUsuario();
                        break;
                    case 2:
                        comprar();
                        break;
                    case 3:
                        Console.WriteLine("Muchas gracias por su compra.");
                        break;
                    default:
                        Console.WriteLine("La opción no existe.");
                        Console.ReadLine();
                        Console.Clear();
                        ventanaUsuario();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Codigo invalido, volvé a intentarlo");
                Console.ReadLine();
                ventanaUsuario();
            }
        }
    }
}
