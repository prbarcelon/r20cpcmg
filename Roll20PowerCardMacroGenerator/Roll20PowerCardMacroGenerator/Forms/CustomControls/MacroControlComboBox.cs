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
    public partial class MacroControlComboBox : MacroControlBase
    {
        public MacroControlComboBox(Tag tag)
        {
            InitializeComponent();
            this.tag = tag;

            comboBoxContent.DataBindings.Add("Text", this.MacroTag, "ContentValue");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tag.TagValue = textBoxTag.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tag.ContentValue = comboBoxContent.Text;
        }
    }
}
