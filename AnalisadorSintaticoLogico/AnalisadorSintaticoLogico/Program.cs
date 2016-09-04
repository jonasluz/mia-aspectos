using System;
using System.Collections.Generic;

namespace JALJ_MIA_Fundamentos
{
    class Program
    {
        private static string INFO =
            "Uso: AnalisadorSintaticoLogico <expressão>\n";

        /// <summary>
        /// Chamada principal ao programa.
        /// </summary>
        /// <param name="args">Parâmetros</param>
        static void Main(string[] args)
        {
            if (args.Length == 0)   // parâmetros não informados.
                QuitWithError("\nParâmetros necessários.\n" + INFO);

            // Expressão informada.
            string expr = args[0];
            Console.WriteLine("\n=================================\nENTRADA: " + expr);

            // Analisador.
            Analyzer analyzer = new Analyzer(expr);

            if (analyzer.Tokenize())
            {   // tokenização (análise léxica) bem sucedida.
                Console.Write("RESULTADO: Expressão válida!\nTOKENS: ");
                foreach (Token token in analyzer.Tokens)
                    Console.Write(token.value);
                Console.WriteLine();
            } else
            {
                QuitWithError(analyzer.Errors);
            }

            AST ast = analyzer.Parse();
            Console.WriteLine("AST:\n" + ast);
            Console.WriteLine("=================================");
        }

        #region Métodos privados
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
        #endregion Métodos privados
    }
}
