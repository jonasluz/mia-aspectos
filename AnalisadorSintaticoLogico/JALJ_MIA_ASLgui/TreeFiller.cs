using System.Windows.Forms;
using System.Drawing;

using TreeGenerator;
using JALJ_MIA_ASLlib;

namespace JALJ_MIA_ASLgui
{
    // Fills the graphical tree with the AST content.
    class TreeFiller
    {
        private TreeBuilder m_treeBuilder = null;
        private TreeGenerator.TreeData.TreeDataTableDataTable m_treeDT;
        private PictureBox m_picture;
        private int m_id = 0;

        // Constructor
        public TreeFiller(PictureBox pictureBox)
        {
            m_picture = pictureBox;
            m_treeDT = new TreeData.TreeDataTableDataTable();

        }

        public void Draw(AST ast, string parentId = "")
        {
            string id = Fill(ast);
            InitTreeBuilder();
            m_picture.Image = Image.FromStream(m_treeBuilder.GenerateTree(id, System.Drawing.Imaging.ImageFormat.Bmp));
        }

        private string Fill(AST ast, string parentId = "")
        {
            string id = (m_id++).ToString();
            switch (ast.GetType().Name)
            {
                case "ASTProp":
                    string value = (ast as ASTProp).value.ToString();
                    m_treeDT.AddTreeDataTableRow(id, parentId, value, "");
                    break;
                case "ASTOpUnary":
                    ASTOpUnary opNeg = ast as ASTOpUnary;
                    value = opNeg.value.ToString();
                    m_treeDT.AddTreeDataTableRow(id, parentId, value, "");
                    Fill(opNeg.ast, id);
                    break;
                case "ASTOpBinary":
                    ASTOpBinary opBin = ast as ASTOpBinary;
                    value = opBin.value.ToString();
                    m_treeDT.AddTreeDataTableRow(id, parentId, value, "");
                    Fill(opBin.left, id);
                    Fill(opBin.right, id);
                    break;
            } // switch

            return id;
        }

        private void InitTreeBuilder()
        {
            m_treeBuilder = new TreeBuilder(m_treeDT);
            m_treeBuilder.BGColor = Color.LightSteelBlue;
            m_treeBuilder.FontColor = Color.Black;
            m_treeBuilder.BoxFillColor = Color.LightGoldenrodYellow;
            m_treeBuilder.BoxHeight = 30; m_treeBuilder.BoxWidth = 40;
        }
    }
}
