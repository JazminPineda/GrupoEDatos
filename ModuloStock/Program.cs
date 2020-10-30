using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace ModuloStock
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock.stock.InicializarStock();
            VentanaInicio inicio = new VentanaInicio();
            inicio.IniciarAplicacion();
            
        }
    }
}
