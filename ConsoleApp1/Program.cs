using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Usuario> listUsu = new List<Usuario>();

            listUsu.Add(new Usuario("Juan", 1.2, "e"));
            listUsu.Add(new Usuario("Mariel", 2.3, "a"));
            listUsu.Add(new Usuario("Juana", 6.5, "e"));

            foreach (var usuario in listUsu)
            {
                Console.WriteLine("CODIGO: {0}, NOMBRE: {1}, BALANCE: {2}, TIPO: {3}", usuario.Codigo, usuario.Name, usuario.Balance, usuario.Type);
            }
        }

            public class Usuario
        {
            private static int actual_codigo;
            protected int codigo;
            protected String name;
            protected double balance;
            protected String type;

            public Usuario()
            {
                codigo = 0;
                name = "Nombre";
                balance = 1.2;
                type = "e";
            }

            public int Codigo
            { 
                get { return codigo; } 
                set { codigo = value; } 
            }

            public String Name
            {
                get { return name; }
                set { name = value; }
            }

            public double Balance
            {
                get { return balance; }
                set { Balance = value; }
            }

            public String Type
            {
                get { return type; }
                set { type = value; }
            }
            
            public Usuario(String name, double balance, String type)
            {
                this.codigo = GetNextID();
                this.name = name;
                this.balance = balance;
                this.type = type;
            }

            static Usuario() => actual_codigo = 0;
            
            protected int GetNextID() => ++actual_codigo;

            public void Update(string name, double balance, String type)
            {
                this.Name = name;
                this.Balance = balance;
                this.Type = type;
            }
            public override string ToString() => $"{this.Codigo} - {this.Name} - {this.Balance} - {this.Type}";
        }

    }   
}


