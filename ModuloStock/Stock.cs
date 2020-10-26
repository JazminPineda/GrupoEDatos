using System;
using System.Collections.Generic;

namespace ModuloStock
{
    public class Stock //se crea la clase stock para compartir funcionalidades en comun admin y usuario.
    {
        public static readonly Stock stock = new Stock();
        private List<Producto> listaProductos;  // la lista es una lista de productos esto es un atribuo de la clase de stock
        private const int cantidadMaxima = 5; // se crea un atributo del maximo de elementos por cada producto. 
        private int addProducto = 1;
        private int cantidadStock;
        Dictionary<String, int> addStock = new Dictionary<string, int>();

        private Stock()// Defino constructor 
        {
            this.listaProductos = new List<Producto>();  //Inicializo el atributo con una nueva lista de productos 
        }

        public void InicializarStock() // Funcion de inicializacion de stock, agrega el stock a la lista de productos
        {
            for(int i = 0; i < listaProductos.Count; i++){
                if (addStock.ContainsKey(listaProductos[i].MostrarNombre()))
                    //Busca en el diccionario addStock si existe el nombre del producto
                {
                    if (addStock[listaProductos[i].MostrarNombre()] == cantidadStock) 
                        /* Compara que la cantidad de stock que se va a agregar es la misma 
                        y para que no agregue stock de más a otros productos */
                    {
                        for (int e = 1; e <= addStock[listaProductos[i].MostrarNombre()]; e++)
                            //Hace un push segun la cantidad de stock de un producto
                        {
                            listaProductos[i].AgregarElemento(e);
                        }
                    }
                }
            }
        }

        public void AgregarProducto(string prod, double valor)
        {
            listaProductos.Add(new Producto(addProducto, prod, valor));
            addProducto++; // Variable que sirve para agregar el codigo del producto
        }

        public void AgregarStock(int cod, int cant)
        {
            if (addStock.ContainsKey(listaProductos[cod - 1].MostrarNombre()))
                // Si ya existe el producto en el diccionario solo modifica su "stock"
            {
                listaProductos[cod - 1].ReiniciarElementos();
                cantidadStock = addStock[listaProductos[cod - 1].MostrarNombre()] + cant;
                addStock[listaProductos[cod - 1].MostrarNombre()] += cant;
            }
            else // Agrega el prodcuto y el stock al diccionario en caso de que no exista
            {
                addStock.Add(ObtenerNombreProducto(cod), cant);
                cantidadStock = cant;
            }
        }

        public double ObtenerPrecio(int codProducto) //EDIT Eze: función para obtener el precio del producto

        {
            return listaProductos[codProducto - 1].MostrarPrecio();
        }

        public string ObtenerNombreProducto(int codProducto) //Edit Eze: función para obtener el nombre del producto

        {
            return listaProductos[codProducto - 1].MostrarNombre();
        }

        public string ObtenerProducto(int codProducto)
        {
            for (int i = 0; i < listaProductos.Count; i++)
            {
                if (codProducto == listaProductos[i].MostrarCodigo())//ingresamos al producto y obtenemos codigo para comparar
                {
                    addStock[listaProductos[i].MostrarNombre()] -= 1;
                    cantidadStock -= 1;
                    return listaProductos[i].QuitarElemento();//se quita el elemento del producto llamando la pila 
                }
            }
            return "Error al obtener el código del producto.";
        }

        public void ImprimirProductos()
        {
            string format = "{0,-10}{1,-30}{2,12}{3,12:N2}";// se crea formato para imprimir posicion y espacios
            string format1 = "{0,-10}{1,-30}";
            string format2 = "{0,12}";
            string format3 = "{0,12:N2}";
            Console.WriteLine(format,"Código", "Nombre", "Cantidad", "Precio");
            for (int i = 0; i < listaProductos.Count; i++) //se recorre la lista del producto para imprimir
            {
                Console.Write(format1, listaProductos[i].MostrarCodigo(), listaProductos[i].MostrarNombre());
                if (listaProductos[i].MostrarCantidad() == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(format2, listaProductos[i].MostrarCantidad());
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(format2, listaProductos[i].MostrarCantidad());
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(format3, listaProductos[i].MostrarPrecio());
            }
        }
    }
}
