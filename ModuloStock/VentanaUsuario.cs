using System;
using System.Collections.Generic;

namespace ModuloStock
{
    class VentanaUsuario
    {
        VentanaInicio inicio = new VentanaInicio();
        private double montoInicial = 500; //Variable temporal
        private string producto;
        private Queue<string> list = new Queue<string>();

        public void PanelUsuario()
        {
            Console.Clear();
            Console.WriteLine($"Usuario: IFTS \nSaldo: {montoInicial} \n\nLista de productos:");
            Stock.stock.ImprimirProductos();
            MenuOpciones();   
        }

        public void ComprarDevuelta(Queue<string> lista)
        {
            string otraCompra;
            string otraCompraLower;

            Console.WriteLine("Desea seguir comprando? SI / NO");
            otraCompra = Console.ReadLine();
            otraCompraLower = otraCompra.ToLower();
            int posicion = 1;

            if (otraCompraLower == "si")
            {
                PanelUsuario();
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

        public void ComprarProducto(int producto)
        {
            double saldo = saldoDisponible(montoInicial, Stock.stock.ObtenerPrecio(producto));

            if (saldo > 0)
            {
                list.Enqueue(Stock.stock.ObtenerNombreProducto(producto));
                montoInicial= saldo;
                Stock.stock.ObtenerProducto(producto);
                //usuarios.ObtenerProducto(productoNro);
                ComprarDevuelta(list);
            }
            else
            {
                Console.WriteLine("No tiene saldo suficiente.");
                Console.ReadLine();
                PanelUsuario();
            }
        }

        public double saldoDisponible(double saldoCuenta, double precioProducto)
        {
            return saldoCuenta - precioProducto;
        }

        public void MenuOpciones()
        {
            string opcionUsuario;
            
            Console.WriteLine("\nMenu Usuario: \n1) Saldo disponible \n2) Comprar \n3) Salir");
            Console.WriteLine("\nIngrese una opción:");
            opcionUsuario = Console.ReadLine();

            if (!string.IsNullOrEmpty(opcionUsuario)) {
                int opcionUsuarioNro = Convert.ToInt32(opcionUsuario);
                
                switch (opcionUsuarioNro)
                {
                    case 1:                        
                        //saldoDisponible(montoInicial, Y);
                        Console.WriteLine("Tu saldo es: " + montoInicial);
                        Console.ReadKey();
                        PanelUsuario();
                        break;
                    case 2:
                        Console.WriteLine("\nIngrese el número del producto que quiere:");
                        producto = Console.ReadLine();

                        if (!string.IsNullOrEmpty(producto))  //Valida que el código de producto no sea nulo
                        {
                            int productoNro = Convert.ToInt32(producto);
                            if (productoNro > 0 && productoNro < 5) {
                                ComprarProducto(productoNro);
                            }
                            else
                            {
                                Console.WriteLine("Codigo invalido.");
                                Console.ReadLine();
                                PanelUsuario();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Codigo invalido, volvé a intentarlo");
                            Console.ReadLine();
                            PanelUsuario();
                        }
                        break;
                    case 3:
                        Console.WriteLine("\nGracias!");
                        Console.ReadLine();
                        Console.Clear();
                        inicio.IniciarAplicacion();
                        break;
                    default:
                        Console.WriteLine("La opción no existe.");
                        Console.ReadLine();
                        Console.Clear();
                        PanelUsuario();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Codigo invalido, volvé a intentarlo");
                Console.ReadLine();
                PanelUsuario();
            }
        }
    }
}
