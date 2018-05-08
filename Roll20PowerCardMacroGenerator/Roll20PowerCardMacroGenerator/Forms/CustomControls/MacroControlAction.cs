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
    public partial class MacroControlAction : MacroControlBase
    {
        List<string> actionTypes;
        public MacroControlAction(string action)
        {
            InitializeComponent();
            DataLoader loader = new DataLoader();
            actionTypes = loader.LoadData(@"Data\ActionType.txt");
            comboBox1.DataSource = actionTypes;
            tag.TagValue = "action";
            //this.MacroTag.ContentValue = action;
            comboBox1.DataBindings.Add("Text", this.MacroTag, "ContentValue");
        }

        public MacroControlAction() : this("") { }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tag.ContentValue = comboBox1.Text;
        }
    }
}