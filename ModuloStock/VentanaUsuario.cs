using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ModuloStock
{
    class VentanaUsuario
    {
        //Stock usuarios = new Stock();
        VentanaInicio inicio = new VentanaInicio();
        private double montoInicial = 500; //Variable temporal
        private string producto;
        private Queue<string> list = new Queue<string>();

        public void ventanaUsuario()
        {

            Console.Clear();
            Console.WriteLine($"Usuario: IFTS \nSaldo: {montoInicial} \n\nLista de productos:");
            Stock.stock.ImprimirProductos();
            menuOpciones();
            
        }

        public void comprarDevuelta(Queue<string> lista)
        {
            string otraCompra;
            Console.WriteLine("Desea seguir comprando? SI / NO");
            otraCompra = Console.ReadLine();
            otraCompra.ToLower();
            int posicion = 1;
            if (otraCompra == "si")
            {
                ventanaUsuario();
            }
            else
            {
                Console.WriteLine("\nRetire los productos de la bandeja:");
                foreach (string producto in lista)
                {
                    Console.WriteLine($"#{posicion++} {producto}");
                }
                Console.WriteLine("\nGracias!");
                Console.ReadLine();
                Console.Clear();
                inicio.IniciarAplicacion();
            }
        }

        public void comprarProducto(int producto)
        {
            if (montoInicial - Stock.stock.ObtenerPrecio(producto) > 0)
            {
                list.Enqueue(Stock.stock.ObtenerNombreProducto(producto));
                montoInicial = montoInicial - Stock.stock.ObtenerPrecio(producto);
                Stock.stock.ObtenerProducto(producto);
                //usuarios.ObtenerProducto(productoNro);
                comprarDevuelta(list);
            }
            else
            {
                Console.WriteLine("No tiene saldo suficiente.");
                Console.ReadLine();
                ventanaUsuario();
            }

            /*
            switch (productoNro)
            {
                case 1:
                    if (montoInicial - Stock.stock.ObtenerPrecio(productoNro) > 0)
                    {
                        list.Enqueue("Alfajor de membrillo");
                        montoInicial = montoInicial - Stock.stock.ObtenerPrecio(productoNro);
                        Stock.stock.ObtenerProducto(productoNro);

                        //usuarios.ObtenerProducto(productoNro);
                        comprarDevuelta(list);
                    }
                    else
                    {
                        Console.WriteLine("No tiene saldo suficiente.");
                        Console.ReadLine();
                        ventanaUsuario();
                    }
                    break;
                case 2:
                    if (montoInicial - usuarios.ObtenerPrecio(productoNro) > 0)
                    {
                        Console.WriteLine("Entre");
                        list.Enqueue("Pepsi");
                        Console.WriteLine("Sali");
                        montoInicial = montoInicial - usuarios.ObtenerPrecio(productoNro);
                        usuarios.ObtenerProducto(productoNro);
                        comprarDevuelta(list);
                    }
                    else
                    {
                        Console.WriteLine("No tiene saldo suficiente.");
                        Console.ReadLine();
                        ventanaUsuario();
                    }
                    break;
                case 3:
                    if (montoInicial - usuarios.ObtenerPrecio(productoNro) > 0)
                    {
                        list.Enqueue("Galletitas sonrisas light");
                        montoInicial = montoInicial - usuarios.ObtenerPrecio(productoNro);
                        usuarios.ObtenerProducto(productoNro);
                        comprarDevuelta(list);
                    }
                    else
                    {
                        Console.WriteLine("No tiene saldo suficiente.");
                        Console.ReadLine();
                        ventanaUsuario();
                    }
                    break;
                case 4:
                    if (montoInicial - usuarios.ObtenerPrecio(productoNro) > 0)
                    {
                        list.Enqueue("Levité de zanahoria");
                        montoInicial = montoInicial - usuarios.ObtenerPrecio(productoNro);
                        usuarios.ObtenerProducto(productoNro);
                        comprarDevuelta(list);
                    }
                    else
                    {
                        Console.WriteLine("No tiene saldo suficiente.");
                        Console.ReadLine();
                        ventanaUsuario();
                    }
                    break;
                default:
                    Console.WriteLine("Código inválido.");
                    Console.ReadLine();
                    ventanaUsuario();
                    break;
            }*/
        }

        public void menuOpciones()
        {
            string opcionUsuario;

            Console.WriteLine("Menu Usuario: \n1) Saldo disponible \n2) Comprar \n3) Salir");
            Console.WriteLine("\nIngrese una opción:");
            opcionUsuario = Console.ReadLine();

            if (!string.IsNullOrEmpty(opcionUsuario)) {
                int opcionUsuarioNro = Convert.ToInt32(opcionUsuario);
                switch (opcionUsuarioNro)
                {
                    case 1:
                        Console.WriteLine("En construcción...");
                        break;
                    case 2:
                        Console.WriteLine("\nIngrese el número del producto que quiere:");
                        producto = Console.ReadLine();

                        if (!string.IsNullOrEmpty(producto))  //Valida que el código de producto no sea nulo
                        {
                            int productoNro = Convert.ToInt32(producto);
                            if (productoNro > 0 && productoNro < 5) {
                                comprarProducto(productoNro);
                            }
                            else
                            {
                                Console.WriteLine("Codigo invalido.");
                                Console.ReadLine();
                                ventanaUsuario();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Codigo invalido, volvé a intentarlo");
                            Console.ReadLine();
                            ventanaUsuario();
                        }
                        break;
                    case 3:
                        Console.WriteLine("En construcción...");
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
