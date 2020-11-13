using System.Collections.Generic;

namespace ModuloStock
{
    public class Producto  // se crea la CLASE producto 
    {
        private int codigo;
        private string nombre;
        private double precio;
        private Stack<string> elementos;//atributo Pila

        // constructor de la clase, funciona cuando ingresa un nuevo producto a la maquina porque representa un nuevo espiral
        public Producto( int codigo, string nombre, double precio) 
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.precio = precio;
            this.elementos = new Stack<string>(); // constructor de la pila

        }
        public void ReiniciarElementos()
        {
            this.elementos.Clear();
        }
        public void AgregarElemento(string nombre)// se agrega un elemento al espiral de la pila
        {
            this.elementos.Push(nombre); //se introduce un nuevo elmeento con la variable nombre formando la pila 

        }
        public string QuitarElemento()
        {
            return this.elementos.Pop();// quita el elmento q hay encima es decir que desapila estructura LIFO PEPS
        }

        public int MostrarCodigo()
        {
            return this.codigo;

        }
        public string MostrarNombre()
        {
            return this.nombre;
        }
        public double MostrarPrecio()
        {
            return this.precio;
        }
        
        public int MostrarCantidad()
        {
            return this.elementos.Count;// 
        }
    }
}
