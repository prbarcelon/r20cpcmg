using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll20PowerCardMacroGenerator.Forms
{
    public partial class MacroParserForm : Form
    {
        private CancellationTokenSource cancelSource;
        public string Status
        {
            get { return labelStatus.Text; }
            set { labelStatus.Text = value; }
        }

        public List<Tag> Tags;
        public MacroParserForm()
        {
            InitializeComponent();
        }

        private void MacroParserForm_Load(object sender, EventArgs e)
        {
            errorProvider1.SetIconAlignment(buttonParse, ErrorIconAlignment.MiddleLeft);
            cancelSource = new CancellationTokenSource();
            buttonOk.Enabled = false;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private async void buttonParse_Click(object sender, EventArgs e)
        {
            if (richTextBoxPowerCommand.TextLength == 0)
                DisplayError(sender as Control, "Please enter a power command in the top text box");
            Status = "Parsing";
            buttonOk.Enabled = false;
            buttonParse.Enabled = false;
            richTextBoxResults.Clear();
            MacroParseResults results = null;
            try
            {
                Tags = new List<Tag>();
                string command = richTextBoxPowerCommand.Text;
                // this should really be so fast that we really don't need to provide cancellation support.
                await Task.Run(() =>
                {
                    results = Roll20PowerCardMacroGenerator.Tag.TryParseMacro(command, out Tags);
                }, cancelSource.Token);
                buttonOk.Enabled = Tags.Count > 0;
                richTextBoxResults.Text = results.ToString();
                if (results.TokenErrors.Count > 0)
                    DisplayError(sender as Control, "There were errors, see results for details");
            }
            catch (Exception exception)
            {
                DisplayError(sender as Control, "Error parsing.  See results for information");
                richTextBoxResults.Text = exception.Message;
            }
            Status = results != null ? string.Format("Parsing complete with {0} Errors", results.TokenErrors.Count) : string.Format("Parsing complete");
            buttonParse.Enabled = true;

        }

        private void DisplayError(Control control, string message)
        {
            errorProvider1.SetError(control, message);
        }

        private void richTextBoxPowerCommand_TextChanged(object sender, EventArgs e)
        {
            buttonParse.Enabled = richTextBoxPowerCommand.TextLength > 0;
        }
    }
}
