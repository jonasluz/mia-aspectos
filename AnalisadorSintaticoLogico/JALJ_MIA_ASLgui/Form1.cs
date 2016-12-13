using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using JALJ_MIA_ASLlib;

namespace JALJ_MIA_ASLgui
{
    /// <summary>
    /// The main application form.
    /// </summary>
    public partial class FormMain : Form
    {
        TreeFiller m_treeFiller = null;

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
            string expr = textBoxInput.Text;    // expression input.

            // Cleanup and setup.
            ClearErrorMsgs();
            tabControl1.SelectedIndex = 0;

            // Creates a new analyzer for the expression.
            Analyzer asl = new Analyzer(expr);
            // Tokenization phase.
            if (!Tokenize(asl)) return;
            // Parsing phase.
            AST ast = asl.Parse();

            // Add the tree to the image.
            if (m_treeFiller == null) m_treeFiller = new TreeFiller(pictureBoxTree);
            m_treeFiller.Draw(ast);
        }

        private void buttonFNC_Click(object sender, EventArgs e)
        {
            string expr = textBoxInput.Text;    // expression input.

            tabControl1.SelectedIndex = 1;

            // Creates a new analyzer for the expression.
            Analyzer asl = new Analyzer(expr);
            // Tokenization phase.
            if (!Tokenize(asl)) return;
            // Parsing phase.
            AST ast = CNF.Convert(asl.Parse());
            string fnc = ASTFormat.Format(ast, ASTFormat.FormatType.PLAIN);
            IEnumerable<CnfOr> orClauses = CNF.Separate(ast, true);

            // Add this formula to the FNC list.
            RichTextTool rtt = new RichTextTool(ref richTextBoxCNF);
            rtt.AppendText(expr + " - ");
            richTextBoxCNF.SelectionBackColor = Color.Aquamarine;
            rtt.ToggleBold();
            rtt.AppendText(fnc);
            richTextBoxCNF.SelectionBackColor = Color.White;
            rtt.ToggleBold(); rtt.AppendText(" - "); rtt.ToggleBold();
            richTextBoxCNF.SelectionBackColor = Color.LawnGreen;
            rtt.AppendText(string.Join(", ", orClauses));
            rtt.Eol();

            // Add the tree to the image.
            /*
            if (m_treeFiller == null) m_treeFiller = new TreeFiller(pictureBoxTree);
            m_treeFiller.Draw(ast);
            */
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            // Clear outputs.
            pictureBoxTree.Image = null;
            richTextBoxCNF.Clear();
            // Clear errors.
            ClearErrorMsgs();
        }

        #endregion Button actions

        /// <summary>
        /// Tokenization Phase
        /// </summary>
        /// <param name="asl">Syntatic Analyzer</param>
        /// <returns>If tokenization succedded.</returns>
        private bool Tokenize(Analyzer asl)
        {
            if (!asl.Tokenize())
            { // There are errors from the tokenization. 
                foreach (string error in asl.Errors)
                    listBoxErrors.Items.Add(error);
                string alert = string.Format(
                    "Há {0} erros identificados. Por favor, revise-os.",
                    asl.Errors.Count());
                errorProviderInput.SetError(textBoxInput, alert);

                return false;
            }

            return true;
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
