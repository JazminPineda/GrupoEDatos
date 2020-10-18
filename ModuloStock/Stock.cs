using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ModuloStock
{
    public class Stock //se crea la clase stock para compartir funcionalidades en comun admin y usuario.
    {
        private List<Producto> listaProductos;  // la lista es una lista de productos esto es un atribuo de la clase de stock
        private const int cantidadMaxima = 5; // se crea un atributo del maximo de elementos por cada producto. 
        public Stock()// Defino constructor 
        {
            this.listaProductos = new List<Producto>();  //Inicializo el atributo con una nueva lista de productos 
        }


        public void InicializarStock() // Funcion de inicializacion de stock, se crean los productos precargados 
        {
            Producto alfajor = new Producto(1, "Alfajor Jorgito", 10.5);
            Producto gaseosa = new Producto(2, "Coca-Cola", 30);
            Producto galletitas = new Producto(3, "Galletitas Chocolinas", 35);
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
                    listaProductos[i].AgregarElemento(listaProductos[i].MostrarNombre()+j.ToString());
                    /*se recorre la lista con la posiciòn luego se agrega un elmento al producto de la lista trayendo 
                    la funcion mostrar nombre q esta en la clase producto y se convierte j en string para identificar q se 
                    agrego el elemento esta es una funcion .toString*/
                    //agregar func admon 5max//
                }
            }
            
        }
        
        public void AgregarProducto(Producto producto)
        {
            this.listaProductos.Add(producto);
        }

        public string ObtenerProducto(int codProducto)
        {
            for (int i = 0; i < listaProductos.Count; i++)
            {
                if (codProducto == listaProductos[i].MostrarCodigo())//ingresamos al producto y obtenemos codigo para comparar
                {
                    return listaProductos[i].QuitarElemento();//se quita el elemento del producto llamando la pila 
                }
            }
        }



        public void ImprimirProductos()
        {
            string format = "{0,-10}{1,-30}{2,12}{3,12:N2}";// se crea formato para imprimir posicion y espacios
            Console.WriteLine(format, "Código", "Nombre", "Cantidad", "Precio ");
            for (int i = 0; i < listaProductos.Count; i++) //se recorre la lista del producto para imprimir
            {
                Console.WriteLine(format, listaProductos[i].MostrarCodigo(), listaProductos[i].MostrarNombre(),
                   listaProductos[i].MostrarCantidad(),listaProductos[i].MostrarPrecio());
            }
               
            Console.ReadLine();
        }
    }
}
