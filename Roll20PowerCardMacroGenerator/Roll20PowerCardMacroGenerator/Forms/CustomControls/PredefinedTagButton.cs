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
    public partial class PredefinedTagButton : Button
    {
        public Tag TagControl { get; set; }

        public PredefinedTagButton(Tag tag)
        {
            InitializeComponent();
            Text = tag.DisplayName;
            TagControl = tag;
        }

        public PredefinedTagButton(Tag tag, ToolTip toolTip) : this(tag)
        {
            toolTip.SetToolTip(this, tag.TagDescription);
        }
    }
}
