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
    public partial class MacroControlKeywords : MacroControlBase
    {
        List<string> keywords;
        KeywordsToolbox toolbox;
        public MacroControlKeywords()
        {
            InitializeComponent();
            DataLoader loader = new DataLoader();
            keywords = loader.LoadData(@"Data\Keyword.txt");
            toolbox = new KeywordsToolbox(keywords);
            tag.TagValue = "Keywords";
        }

        private void buttonKeywordsToolbox_Click(object sender, EventArgs e)
        {
            toolbox.ShowDialog();
            string content = "";
            bool first = true;
            foreach (var item in toolbox.checkedListBoxKeywords.CheckedItems)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    content += ", ";
                }
                content += item.ToString();
            }
            tag.ContentValue = content;
        }
    }
}
