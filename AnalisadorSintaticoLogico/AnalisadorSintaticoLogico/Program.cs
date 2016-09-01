using System;

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
            bool valid = asl.Valida(expr);
            string result = valid ? "válida" : "inválida!";
            Console.WriteLine("Expressão: " + expr + " é " + result);

            if (!valid)
                QuitWithError(asl.Error);

            if (args.Length > 1 && args[1].Equals("-t"))
            {
                Console.WriteLine("== ÁRVORE ==\n");
                Console.WriteLine(asl.Tree);
            }

            Environment.Exit(0);
        }

        static void QuitWithError(string err)
        {
            Console.WriteLine(err);
            Environment.Exit(1);
        }
    }
}
