using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll20PowerCardMacroGenerator.Forms.CustomControls
{

    public class ComboBoxControl : MacroControlBase2
    {
        private readonly ComboBox comboBoxContent = new ComboBox();
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ComboBoxControl()
        {
            this.ContentControl = comboBoxContent;
            comboBoxContent.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        }

        public ComboBoxControl(IEnumerable<string> contentList)
        {
            this.ContentControl = comboBoxContent;
            comboBoxContent.DataSource = contentList;
        }

        public override void Init(Tag tag)
        {
            comboBoxContent.DataSource = tag.ContentValueList ?? new BindingList<string> { "Values Not Defined" };
            base.Init(tag);
        }
    }
}
