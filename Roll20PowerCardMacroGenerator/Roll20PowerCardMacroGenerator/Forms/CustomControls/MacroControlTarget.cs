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
    public partial class MacroControlTarget : MacroControlBase
    {
        List<string> target;
        public MacroControlTarget(string targetStr)
        {
            InitializeComponent();
            target = Form1.Powers.Where(pobj => pobj.target != null).Select(pobj => pobj.target).Distinct().ToList();
            comboBoxContent.DataSource = target;
            List<string> targetTag = new List<string>();
            targetTag.Add("Target");
            targetTag.Add("Primary Target");
            targetTag.Add("Secondary Target");
            targetTag.Add("Tertiary Target");
            comboBoxTag.DataSource = targetTag;
            //this.MacroTag.ContentValue = targetStr;
            comboBoxContent.DataBindings.Add("Text", this.MacroTag, "ContentValue");
        }

        public MacroControlTarget() : this("") { }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tag.TagValue = comboBoxTag.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tag.ContentValue = comboBoxContent.Text;
        }
    }
}
