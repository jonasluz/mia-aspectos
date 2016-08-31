using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorSintaticoLogico
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            QuitWithError("Expressão não informada.\nUse AnalisadorSintaticoLogico <expressao>");

            string expr = args[0];
            AnalisadorSintaticoLogico asl = new AnalisadorSintaticoLogico();
            if (asl.Valida(expr))
            {
                Console.WriteLine("Expressão válida.");
                Console.WriteLine(asl.Tree);
            } else 
                QuitWithError(asl.Error);

            Environment.Exit(0);
        }

        static void QuitWithError(string err)
        {
            Console.WriteLine(err);
            Environment.Exit(1);
        }
    }
}
