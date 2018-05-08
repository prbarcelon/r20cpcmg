using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll20PowerCardMacroGenerator.Forms
{
    public partial class KeywordsToolbox : Form
    {
        public KeywordsToolbox(List<string> keywords)
        {
            InitializeComponent();
            checkedListBoxKeywords.Items.AddRange(keywords.ToArray());
        }
    }
}
