using System;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = "Breno";
            Console.WriteLine("Hello World!");

            var a = Console.ReadLine();


            if (b.GetHashCode() == a.GetHashCode()) {

                Console.WriteLine("Sucess", b.Equals(a));
            }
            else
            {
                Console.WriteLine("Sem sucesso");
            }
        }
    }
}
