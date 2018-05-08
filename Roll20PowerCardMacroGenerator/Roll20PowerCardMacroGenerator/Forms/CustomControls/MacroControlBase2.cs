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
    public partial class MacroControlBase2 : UserControl, IMacroControl
    {
        #region Callback Access

        /// <summary>
        /// Called when the Up button is clicked
        /// </summary>
        public Action<object> MoveUp
        {
            get { return _callbackMap[buttonUp]; }
            set { _callbackMap[buttonUp] = value; }
        }

        /// <summary>
        /// Called when the down button is clicked
        /// </summary>
        public Action<object> MoveDown
        {
            get { return _callbackMap[buttonDown]; }
            set { _callbackMap[buttonDown] = value; }
        }

        /// <summary>
        /// Called when the Up Indent Left is clicked
        /// </summary>
        public Action<object> IndentLeft
        {
            get { return _callbackMap[buttonLeft]; }
            set { _callbackMap[buttonLeft] = value; }
        }

        /// <summary>
        /// Called when the Up Indent Right is clicked
        /// </summary>
        public Action<object> IndentRight
        {
            get { return _callbackMap[buttonRight]; }
            set { _callbackMap[buttonRight] = value; }
        }

        /// <summary>
        /// Called when the Up Indent Right is clicked
        /// </summary>
        public Action<object> Delete
        {
            get { return _callbackMap[buttonDelete]; }
            set { _callbackMap[buttonDelete] = value; }
        }

        protected Dictionary<object, Action<object>> _callbackMap { get; set; }
        #endregion

        /// <summary>
        /// TagValue control
        /// Set this property to change the TagValue control
        /// </summary>
        protected virtual Control TagControl
        {
            get
            {
                return TablePanel.GetControlFromPosition(5, 0);
            }
            set
            {
                TagControl.Dispose();
                TablePanel.SetCellPosition(value, new TableLayoutPanelCellPosition(5, 0));
            }
        }
        /// <summary>
        /// ContentValue control
        /// Set this property to change the ContentValue control
        /// </summary>
        protected virtual Control ContentControl
        {
            get
            {
                return TablePanel.GetControlFromPosition(6, 0);
            }
            set
            {
                if(ContentControl != null)
                    ContentControl.Dispose();
                TablePanel.Controls.Add(value);
                TablePanel.SetCellPosition(value, new TableLayoutPanelCellPosition(6, 0));
            }
        }
        /// <summary>
        /// Table layout panel
        /// </summary>
        protected TableLayoutPanel TablePanel { get; set; }
        protected int DefaultHeight = 35;
        public MacroControlBase2()
        {
            InitializeComponent();
            TablePanel = tableLayoutPanel1;
            this.Size = new Size(this.Width, DefaultHeight);
            _callbackMap = new Dictionary<object, Action<object>>(); // contains all the callbacks mapped to the gui control
            buttonUp.Tag = this;
            buttonDown.Tag = this;
            IndentLeft = (o) => IndentLevel--; // set the indent left button event
            IndentRight = (o) => IndentLevel++; // set the indent right button event
            Delete = (o) => this.Dispose();
            //Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Initialize the control.
        /// Will set default values and load any tag specific settings.
        /// <remarks>Generally used by the IMacroControlFactory</remarks>
        /// </summary>
        /// <param name="tag">Settings to load</param>
        public virtual void Init(Tag tag)
        {
            TagValue = tag.TagValue;
            ContentValue = tag.ContentValue;
            Position = tag.Position;
            IndentLevel = tag.IndentLevel;
            TagSettings = tag;
        }

        /// <summary>
        /// Tag associated with this macro control
        /// </summary>
        public Tag TagSettings { get; private set; }

        /// <summary>
        /// Generates the tag/content pair for use in the macro.
        /// </summary>
        /// <returns>formatted tag/content pair</returns>
        public string GetTagContentString()
        {
            return string.Format("--{0}{1}|{2}", IndentValue, TagValue, ContentValue);
        }

        /// <summary>
        /// Tag Value
        /// </summary>
        public virtual string TagValue { get { return TagControl.Text; } set { TagControl.Text = value; } }
        /// <summary>
        /// Tag Content Value
        /// </summary>
        public virtual string ContentValue { get { return ContentControl.Text; } set { ContentControl.Text = value; } }
        /// <summary>
        /// Macro Control position
        /// </summary>
        public virtual int Position { get; set; }
        private int _indentLevel = 0;
        /// <summary>
        /// Indent Level
        /// Range of 0-9
        /// </summary>
        public virtual int IndentLevel
        {
            get { return _indentLevel; }
            set
            {
                if (value < 0) _indentLevel = 0;
                else if (value > 9) _indentLevel = 9;
                else _indentLevel = value;
                labelIndent.Text = _indentLevel.ToString();
            }
        }
        /// <summary>
        /// Indent string value
        /// </summary>
        public virtual string IndentValue
        {
            get { return IndentLevel > 0 ? "^" + IndentLevel : string.Empty; }
        }

        // Process all button clicks
        private void button_Click(object sender, EventArgs e)
        {
            if (_callbackMap.ContainsKey(sender))
                _callbackMap[sender](sender);
        }
    }
}
