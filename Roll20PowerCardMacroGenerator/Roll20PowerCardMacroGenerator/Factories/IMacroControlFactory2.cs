using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roll20PowerCardMacroGenerator.Forms.CustomControls;

namespace Roll20PowerCardMacroGenerator.Factory
{

    public interface IMacroControlFactory2
    {
        IEnumerable<MacroControlBase2> CreateMacroControls(Tag tag);
        MacroControlBase2 CreateMacroControl(Tag tag);
    }
}
