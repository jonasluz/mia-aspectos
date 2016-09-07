using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JALJ_MIA_ASLlib;

namespace JALJ_MIA_ASLgui
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            // Limpa eventuais mensagens de erro de execução anterior.
            listBoxErrors.Items.Clear();

            // Executa análise.
            Execute();
        }

        private void Execute()
        {
            string expr = textBoxInput.Text;

            // Instancia o analisador sintático lógico.
            Analyzer asl = new Analyzer(expr);

            // Tokeniza.
            if (!asl.Tokenize())
            { // Ocorreram erros na tokenização.
                foreach (string error in asl.Errors)
                    listBoxErrors.Items.Add(error);
                string alert = string.Format(
                    "Há {0} erros identificados. Por favor, revise-os.", 
                    asl.Errors.Count());
                errorProviderInput.SetError(textBoxInput, alert);

                return;
            }

            // Constrói a AST.
            AST ast = asl.Parse();

            TreeNode node = new TreeNode(expr);
            node.Nodes.Add(FillTree(ast));
            treeViewResult.Nodes.Add(node);
            treeViewResult.Select();
            treeViewResult.SelectedNode = node;
            node.ExpandAll();
        }

        private TreeNode FillTree(AST ast)
        {
            TreeNode node, child1, child2;

            switch (ast.GetType().Name)
            {
                case "ASTProp":
                    node = new TreeNode(((ASTProp)ast).value.ToString());
                    break;
                case "ASTOpUnary":
                    node = new TreeNode(((ASTOpUnary)ast).value.ToString());
                    child1 = FillTree(((ASTOpUnary)ast).ast);
                    node.Nodes.Add(child1);
                    break;
                case "ASTOpBinary":
                    node = new TreeNode(((ASTOpBinary)ast).value.ToString());
                    child1 = FillTree(((ASTOpBinary)ast).left);
                    child2 = FillTree(((ASTOpBinary)ast).right);
                    node.Nodes.Add(child1);
                    node.Nodes.Add(child2);
                    break;
                default:
                    node = null;
                    break;
            }

            return node;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Limpa resultados na árvore.
            treeViewResult.Nodes.Clear();
            // Limpa eventuais erros.
            ClearErrorMsgs();
        }

        private void ClearErrorMsgs()
        {
            errorProviderInput.Clear();
            listBoxErrors.Items.Clear();
        }
    }
}
