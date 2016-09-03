using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JALJ_MIA_Fundamentos
{
    class Program
    {
        private static string INFO =
            "Uso: AnalisadorSintaticoLogico <expressão>\n";

        static void Main(string[] args)
        {
            if (args.Length == 0)
                QuitWithError("Parâmetros necessários.\n" + INFO);

            string expr = args[0];
            Console.WriteLine("Expressão: " + expr + "\n");

            Analyzer analyzer = new Analyzer(expr);

            if (analyzer.Tokenize())
            {
                Console.WriteLine("Expressão válida");
            } else
            {
                QuitWithError(analyzer.Error);
            }
        }

        static void QuitWithError(string error)
        {
            Console.WriteLine(error);
            Environment.Exit(1);
        }
    }
}
