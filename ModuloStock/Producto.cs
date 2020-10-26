using System.Collections.Generic;

namespace ModuloStock
{
    public class Producto
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

        public void AgregarElemento(int nombre)
        {
            this.elementos.Push($"{nombre}");
        }
        public string QuitarElemento()
        {
            return this.elementos.Pop();
        }

        public void ReiniciarElementos()
        {
            this.elementos.Clear();
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
            return this.elementos.Count;//Herenda la propiedad Count 
        }
    }
}
