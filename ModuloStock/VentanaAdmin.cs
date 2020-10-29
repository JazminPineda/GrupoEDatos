using System;

namespace ModuloStock
{
    class VentanaAdmin
    {
        int cod = 1;
        VentanaInicio vent = new VentanaInicio();

        public void PanelAdmin()
        {
            Console.Clear();
            Console.WriteLine("Usuario: Administrador \n\nMenú de administrador: \n1- Ingresar nuevo producto \n2- Agregar stock \n3- Volver al login \n");
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

            Console.WriteLine("Ingrese el precio del producto:");
            precio = Convert.ToDouble(Console.ReadLine());

            Stock.stock.AgregarProducto(new Producto(cod,producto,precio));

            cod++;

            PanelAdmin();
        }

        public void AgregarStock()
        {
            Console.WriteLine("Lista de productos:");
            Stock.stock.ImprimirProductos();

            Console.WriteLine("\nIngrese el codigo del producto:");
            int cod = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el stock del producto:");
            int stock = Convert.ToInt32(Console.ReadLine());

            Stock.stock.AgregarStock(cod, stock);

            Stock.stock.InicializarStock();

            PanelAdmin();
        }
    }
}
