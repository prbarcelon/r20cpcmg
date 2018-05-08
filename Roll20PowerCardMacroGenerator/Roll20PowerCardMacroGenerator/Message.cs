using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Roll20PowerCardMacroGenerator
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class Message
    {
        public string type = "api";
        public string who = "player";
        public string inlinerolls = "";
        public string content = "";
        public Message(string content)
        {
            this.content = content;
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //var obj = new[] { new object[] { } };
            //var json = JsonConvert.SerializeObject(obj);
            //inlinerolls = json;
        }
    }
}
