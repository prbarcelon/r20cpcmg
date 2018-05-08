using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll20PowerCardMacroGenerator.Forms.CustomControls
{
    public partial class MacroControlTextBox : MacroControlBase
    {
        public MacroControlTextBox(Tag tag) : base()
        {
            InitializeComponent();
            this.tag = tag;
            textBoxContent.DataBindings.Add("Text", this.MacroTag, "ContentValue");
        }

        private void textBoxTag_TextChanged(object sender, EventArgs e)
        {
            //MacroTag.TagValue = textBoxTag.Text;
        }

        private void textBoxTag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                textBoxTag.SelectAll();
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                textBoxTag.DeselectAll();
            }
        }
    }
}
