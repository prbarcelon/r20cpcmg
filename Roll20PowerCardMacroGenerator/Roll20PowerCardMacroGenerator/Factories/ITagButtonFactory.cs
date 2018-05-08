using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll20PowerCardMacroGenerator.Factories
{

    public interface ITagButtonFactory
    {
        Button CreateTagButton(Tag tag);
    }
}
