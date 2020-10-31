using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ModuloStock
{
    public class Producto  // se crea la CLASE producto 
    {
        private int codigo;
        private string nombre;
        private double precio;
        private Stack<string> elementos;//atributo
        public Producto( int codigo, string nombre, double precio) // constructor de la clase
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
        public void AgregarElemento(string nombre)// se crean metodos del producto 
        {
            this.elementos.Push(nombre);

        }
        public string QuitarElemento()
        {
            return this.elementos.Pop();
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
