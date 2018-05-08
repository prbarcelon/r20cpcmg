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
    public partial class MacroControlBase : UserControl
    {
        protected Tag tag;

        public Tag MacroTag
        {
            get { return tag; }
        }

        public MacroControlBase()
        {
            InitializeComponent();
            tag = new Tag();
            toolTip1.SetToolTip(buttonRight, "Increase indentation of macro.");
            toolTip1.SetToolTip(buttonLeft, "Decrease indentation of macro.");
            toolTip1.SetToolTip(buttonUp, "Increase order of macro.");
            toolTip1.SetToolTip(buttonDown, "Decrease order of macro.");
            toolTip1.SetToolTip(buttonDelete, "Delete macro entry.");
            toolTip1.SetToolTip(labelIndentation, "Indentation level.");
            toolTip1.SetToolTip(textBoxTag, "Enter custom tag for macro.");
            textBoxTag.DataBindings.Add("Text", this.MacroTag, "TagValue");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            tag.IncreaseIndentation();
            labelIndentation.Text = tag.IndentLevel.ToString();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            tag.DecreaseIndentation();
            labelIndentation.Text = tag.IndentLevel.ToString();
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            int index = this.Parent.Controls.IndexOf(this);
            if (index > 0)
            {
                this.Parent.Controls.SetChildIndex(this, index - 1);
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            int index = this.Parent.Controls.IndexOf(this);
            this.Parent.Controls.SetChildIndex(this, index + 1);
        }
    }
}
