using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll20PowerCardMacroGenerator.Factories
{

    public class DefaultTagButtonFactory : ITagButtonFactory
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public DefaultTagButtonFactory()
        {
        }

        public Button CreateTagButton(Tag tag)
        {
            Button button = new Button();
            button.Text = tag.TagValue;
            button.AutoSize = true;
            button.Tag = tag;
            return button;
        }
    }
}
