using System;
using System.Collections.Generic;
using JALJ_MIA_ASLlib;

namespace JALJ_MIA_Fundamentos
{
    class Program
    {
        private static string INFO =
            "Uso: AnalisadorSintaticoLogico [-<format>] <expressão>\n";

        /// <summary>
        /// Chamada principal ao programa.
        /// </summary>
        /// <param name="args">Parâmetros</param>
        static void Main(string[] args)
        {
            string expr = "";

            if (args.Length == 0)   // parâmetros não informados.
                QuitWithError("\nParâmetros necessários.\n" + INFO);
            else if (args.Length > 1)
            {
                expr = args[1];
                string format = args[0];
                if (format.Equals("-tree")) AST.format = ASTFormat.FormatType.TREE;
                else if (format.Equals("-json")) AST.format = ASTFormat.FormatType.JSON;
                else QuitWithError("\nParâmetro não reconhecido: " + format + "\n" + INFO);
            } else
            {
                expr = args[0];
            }
            
            // Expressão informada.
            
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
