using System;
using System.Linq;
using System.Windows.Forms;
using JALJ_MIA_ASLlib;

namespace JALJ_MIA_ASLgui
{
    /// <summary>
    /// The main application form.
    /// </summary>
    public partial class FormMain : Form
    {
        #region Created by Form Designer
        public FormMain()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) { ; }
        #endregion Created by Form Designer

        #region Buttons actions

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            // Clear previous execution error messages.
            listBoxErrors.Items.Clear();

            // Run analysis.
            Execute();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            // Limpa resultados na árvore.
            treeViewResult.Nodes.Clear();
            // Limpa eventuais erros.
            ClearErrorMsgs();
        }

        #endregion Button actions

        /// <summary>
        /// Analysis procedure.
        /// </summary>
        private void Execute()
        {
            // Expression input.
            string expr = textBoxInput.Text;

            // Creates a new analyzer for the expression.
            Analyzer asl = new Analyzer(expr);

            // Tokenization phase.
            if (!asl.Tokenize())
            { // There are errors from the tokenization. 
                foreach (string error in asl.Errors)
                    listBoxErrors.Items.Add(error);
                string alert = string.Format(
                    "Há {0} erros identificados. Por favor, revise-os.", 
                    asl.Errors.Count());
                errorProviderInput.SetError(textBoxInput, alert);

                return;
            }

            // Parsing phase.
            AST ast = asl.Parse();

            // Convert the AST node to a tree view.
            TreeNode node = new TreeNode(expr);
            node.Nodes.Add(FillTree(ast));
            treeViewResult.Nodes.Add(node);
            treeViewResult.Select();
            treeViewResult.SelectedNode = node;
            node.ExpandAll();
        }

        /// <summary>
        /// Fill a treeview node with an AST node.
        /// </summary>
        /// <param name="ast">AST node</param>
        /// <returns>AST's TreeView node representation</returns>
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

        /// <summary>
        /// Clear the error messages exibition control.
        /// </summary>
        private void ClearErrorMsgs()
        {
            errorProviderInput.SetError(textBoxInput, null);
            listBoxErrors.Items.Clear();
        }
    }
}
