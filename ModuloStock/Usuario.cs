using System;

namespace ModuloStock
{
    public class Usuario
    {
        private static int actual_codigo;
        protected int codigo;
        protected String name;
        protected double balance;
        protected String type;

        public Usuario()
        {
            codigo = 00;
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
