using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roll20PowerCardMacroGenerator.Forms.CustomControls;

namespace Roll20PowerCardMacroGenerator.Factories
{
    public interface IMacroControlFactory
    {
        MacroControlBase Create(Tag tagContent);

    }
}
