using System;

namespace ModuloStock
{
    class VentanaAdmin
    {
        VentanaInicio vent = new VentanaInicio();

        public void PanelAdmin()
        {
            Console.Clear();
            Console.WriteLine("Usuario: Administrador\n-------------------------------\n\n");
            Stock.stock.ImprimirProductos();
            Console.WriteLine("\n\nMenú de administrador: \n1- Ingresar nuevo producto \n2- Agregar stock \n3- Volver al login \n");
            int opcion = Convert.ToInt32(Console.ReadLine());
            if(opcion == 1)
            {
                AgregarProducto();
            }
            else if(opcion == 2)
            {
                AgregarStock();
            }
            else
            {
                Console.Clear();
                vent.IniciarAplicacion();
            }
        }

        public void AgregarProducto()
        {
            string producto;
            double precio;

            Console.WriteLine("Ingrese el nombre del producto:");
            producto = Console.ReadLine();

            Console.WriteLine("Ingrese el codigo del producto:");
            string codigoProducto = Console.ReadLine();
            int codigoNumero = 0;
            bool esNumero = int.TryParse(codigoProducto, out codigoNumero); // out codinumer es la salida en entero, el resulta se guarda en un booleano para luego usarlo en valadaciones
            while (!esNumero || Stock.stock.ExisteElCodigo(codigoNumero))
            {
                Console.WriteLine("\n\nEl codigo de producto no es válido o ya existe");
                Console.WriteLine("\n\nIngrese nuevamente el codigo del producto:");
                codigoProducto = Console.ReadLine();
                esNumero = int.TryParse(codigoProducto, out codigoNumero);
            }

            Console.WriteLine("Ingrese el precio del producto:");
            precio = Convert.ToDouble(Console.ReadLine());

            Stock.stock.AgregarProducto(new Producto(codigoNumero, producto,precio));// se guarda el producto(espiral)

            PanelAdmin();// muestra nuevamente la lista y el menu con las opciones
        }

        public void AgregarStock() //se agrega el elemento a la pila
        {
            Console.WriteLine("\nIngrese el codigo del producto:");
            string codigoProducto = Console.ReadLine();
            int codigoNumero = 0;
            bool esNumero = int.TryParse(codigoProducto, out codigoNumero);// validacion de codigo cuando no existe
            while (!esNumero || !Stock.stock.ExisteElCodigo(codigoNumero))// aca se niega sino existe no puedo agregarlo en el stock
            {
                Console.WriteLine("\n\nEl codigo de producto no es válido o no existe");
                Console.WriteLine("\n\nIngrese nuevamente el codigo del producto:");
                codigoProducto = Console.ReadLine();
                esNumero = int.TryParse(codigoProducto, out codigoNumero);
            }

            Console.WriteLine("Ingrese el stock del producto:");
            int stock = Convert.ToInt32(Console.ReadLine());

            Stock.stock.AgregarStock(codigoNumero, stock);

            PanelAdmin();
        }
    }
}
