using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuloStock
{
    public class Stock //se crea la clase stock para compartir funcionalidades en comun admin y usuario.
    {
        public static readonly Stock stock = new Stock();// es una instancia de la clase stock con un atributo estatico de solo lectura
        private List<Producto> listaProductos;  // la lista es una lista de productos esto es un atribuo de la clase de stock
        private const int cantidadMaxima = 5; // se crea un atributo del maximo de elementos por cada producto y esuna constante
        Dictionary<String, int> addStock = new Dictionary<string, int>();
        private int cantidadStock;
        private Stock()// Defino constructor 
        {
            this.listaProductos = new List<Producto>();  //Inicializo el atributo con una nueva lista de productos 
        }


        public void InicializarStock() // Funcion de inicializacion de stock, se crean los productos precargados 
        {
            Producto alfajor = new Producto(1, "Alfajor Jorgito", 10.5);
            Producto gaseosa = new Producto(2, "Coca-Cola", 30);
            Producto galletitas = new Producto(3, "Galletitas Chocolinas", 35);//se crean lo espirales
            Producto agua = new Producto(4, "Agua", 40);

            listaProductos.Add(alfajor);
            listaProductos.Add(gaseosa);
            listaProductos.Add(galletitas);
            listaProductos.Add(agua);


            for (int i = 0; i < listaProductos.Count; i++) //se recorre la lista de los productos para crear cada elmento
            {
                /* Console.WriteLine(listaProductos[i]); se accede al producto
                 Console.WriteLine(listaProductos); se accede a la lista de productos
                 Console.WriteLine(i) se accede a la posicion del producto */

                int cantidadFaltanProduc = cantidadMaxima - listaProductos[i].MostrarCantidad(); // variable cantidad faltante de stock
                for (int j = 0; j < cantidadFaltanProduc; j++) //se agrega un nuevo elemento de cada
                                                               //producto (son 5 elementos como maximo)
                {
                    listaProductos[i].AgregarElemento(listaProductos[i].MostrarNombre() + j.ToString());
                    /*se recorre la lista con la posiciòn luego se agrega un elmento al producto de la lista trayendo 
                    la funcion muestra nombre q esta en la clase producto y se convierte j en string para identificar q se 
                    agrego el elemento esta es una funcion .toString*/
                    //agregar func admon 5max//
                }
            }
        }

        public void AgregarProducto(Producto producto)
        {
            this.listaProductos.Add(producto);
        }

        public double ObtenerPrecio(int codProducto) //EDIT Eze: función para obtener el precio del producto

        {
            return listaProductos.First(x => x.MostrarCodigo() == codProducto).MostrarPrecio();
        }

        public string ObtenerNombreProducto(int codProducto) //Edit Eze: función para obtener el nombre del producto

        {
            return listaProductos.First(x => x.MostrarCodigo() == codProducto).MostrarNombre();//Jaz. Se cambia indice porque se tuliza el codig del producto
        }

        public string ObtenerProducto(int codProducto)
        {
            int i = 0; //
            for (i = 0; i < listaProductos.Count; i++)
            {
                if (codProducto == listaProductos[i].MostrarCodigo())//ingresamos al producto y obtenemos codigo para comparar
                {

                    break;
                }
            }//se quita con el indicie un elmento del producto llamando la pila Quitar elemento
            return listaProductos[i].QuitarElemento();
        }
        public void AgregarStock(int cod, int cant)
        {
            for (int j = 0; j < cant; j++) //se agrega un nuevo elemento a cada producto (espiral)
            {
                listaProductos.First(x => x.MostrarCodigo() == cod).AgregarElemento(listaProductos.First(x => x.MostrarCodigo() == cod).MostrarNombre());
            }
        }

        public bool ExisteElCodigo(int codigoProducto) //verifica si existe el codigo o no
        {
            return listaProductos.Exists(x => x.MostrarCodigo() == codigoProducto);// llaama la funcion exist para saber si existe el cod en la lista
        }

        public void ImprimirProductos()
        {
            string format = "{0,-10}{1,-30}{2,12}{3,12:N2}";// se crea formato para imprimir posicion y espacios
            Console.WriteLine(format, "Código", "Nombre", "Cantidad", "Precio ");
            for (int i = 0; i < listaProductos.Count; i++) //se recorre la lista del producto para imprimir
            {
                Console.WriteLine(format, listaProductos[i].MostrarCodigo(), listaProductos[i].MostrarNombre(),
                   listaProductos[i].MostrarCantidad(), listaProductos[i].MostrarPrecio());

            }

            //Console.ReadLine();
        }
        public static int ValidarCodProducto(string codigoProducto)
        {
            int codigoNumero = 0;
            bool esNumero = int.TryParse(codigoProducto, out codigoNumero); // out codinumer es la salida en entero, el resulta se guarda en un booleano para luego usarlo en valadaciones
            while (!esNumero || !Stock.stock.ExisteElCodigo(codigoNumero))// hace dos verificaciones tiene q ser numero y  si existe el cod en el stock
            {
                Console.WriteLine("\n\nEl codigo de producto no es válido o ya existe");
                Console.WriteLine("\n\nIngrese nuevamente el codigo del producto:");
                codigoProducto = Console.ReadLine();
                esNumero = int.TryParse(codigoProducto, out codigoNumero);
            }
            return codigoNumero;
        }

        
    }
}

