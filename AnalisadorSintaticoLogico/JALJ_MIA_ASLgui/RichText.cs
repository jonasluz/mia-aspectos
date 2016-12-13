using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JALJ_MIA_ASLgui
{
    class RichTextTool
    {
        private RichTextBox m_rtb;

        // Constructor.
        public RichTextTool(ref RichTextBox rtb)
        {
            m_rtb = rtb;
        }

        /// <summary>
        /// Append text to the box.
        /// </summary>
        /// <param name="text">Text do be appended.</param>
        public void AppendText(string text)
        {
            m_rtb.AppendText(text);
        }

        public void Eol()
        {
            m_rtb.AppendText("\n");
        }

        /// <summary>
        /// Toggle bold font.
        /// <see cref="https://msdn.microsoft.com/pt-br/library/system.windows.forms.richtextbox.selectionfont(v=vs.110).aspx"/>
        /// </summary>
        public void ToggleBold()
        {
            if (m_rtb.SelectionFont != null)
            {
                System.Drawing.Font currentFont = m_rtb.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                newFontStyle = m_rtb.SelectionFont.Bold == true ? 
                    newFontStyle = FontStyle.Regular
                    : newFontStyle = FontStyle.Bold
                  ;

                m_rtb.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }

    }
}
