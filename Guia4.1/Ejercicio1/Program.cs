using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjercicioDB.Models;

namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Envio e = new Envio();

            foreach (var env in e.ListarTodo())
            {
                Console.WriteLine(env);
            }

            Console.ReadKey();
        }
    }
}
