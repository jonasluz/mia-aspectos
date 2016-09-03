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
                QuitWithError("\nParâmetros necessários.\n" + INFO);

            string expr = args[0];
            Console.WriteLine("\nExpressão: " + expr + "\n");

            Analyzer analyzer = new Analyzer(expr);

            if (analyzer.Tokenize())
            {
                Console.WriteLine("Expressão válida!");
            } else
            {
                QuitWithError(analyzer.Errors);
            }
        }

        static void QuitWithError(string error)
        {
            QuitWithError(new string[] { error });
        }
        static void QuitWithError(ICollection<string> errors)
        {
            Console.WriteLine("Expressão Inválida!\n\nERROS ENCONTRADOS: ==============\n");
            foreach(string error in errors)
                Console.WriteLine(error);
            Environment.Exit(1);
        }
    }
}
