namespace Roll20PowerCardMacroGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxAutofill = new System.Windows.Forms.TextBox();
            this.buttonAutoFill = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxTotalMacroString = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelMacros = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonHeader = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxGameSystems = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanelPredefinedTags = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageChar = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPowers = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPageMacro = new System.Windows.Forms.TabPage();
            this.tabPageScript = new System.Windows.Forms.TabPage();
            this.textBoxScript = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMacroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savectrlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialogMacro = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogMacro = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanelMacros.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageChar.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPageMacro.SuspendLayout();
            this.tabPageScript.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxAutofill
            // 
            this.textBoxAutofill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAutofill.Location = new System.Drawing.Point(81, 3);
            this.textBoxAutofill.Name = "textBoxAutofill";
            this.textBoxAutofill.Size = new System.Drawing.Size(924, 20);
            this.textBoxAutofill.TabIndex = 0;
            this.textBoxAutofill.Text = "Healing Word";
            this.textBoxAutofill.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxAutoFill_KeyDown);
            // 
            // buttonAutoFill
            // 
            this.buttonAutoFill.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonAutoFill.Location = new System.Drawing.Point(0, 0);
            this.buttonAutoFill.Name = "buttonAutoFill";
            this.buttonAutoFill.Size = new System.Drawing.Size(75, 24);
            this.buttonAutoFill.TabIndex = 1;
            this.buttonAutoFill.Text = "Auto Fill";
            this.buttonAutoFill.UseVisualStyleBackColor = true;
            this.buttonAutoFill.Click += new System.EventHandler(this.buttonAutoFill_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxTotalMacroString, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelMacros, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1020, 504);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // textBoxTotalMacroString
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxTotalMacroString, 2);
            this.textBoxTotalMacroString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTotalMacroString.Location = new System.Drawing.Point(3, 412);
            this.textBoxTotalMacroString.Multiline = true;
            this.textBoxTotalMacroString.Name = "textBoxTotalMacroString";
            this.textBoxTotalMacroString.ReadOnly = true;
            this.textBoxTotalMacroString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTotalMacroString.Size = new System.Drawing.Size(810, 89);
            this.textBoxTotalMacroString.TabIndex = 6;
            this.textBoxTotalMacroString.Text = "Click This Textbox To Get Macro";
            this.textBoxTotalMacroString.Enter += new System.EventHandler(this.textBox2_Enter);
            this.textBoxTotalMacroString.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // flowLayoutPanelMacros
            // 
            this.flowLayoutPanelMacros.AllowDrop = true;
            this.flowLayoutPanelMacros.AutoScroll = true;
            this.flowLayoutPanelMacros.Controls.Add(this.buttonHeader);
            this.flowLayoutPanelMacros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMacros.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMacros.Location = new System.Drawing.Point(207, 33);
            this.flowLayoutPanelMacros.Name = "flowLayoutPanelMacros";
            this.flowLayoutPanelMacros.Size = new System.Drawing.Size(606, 373);
            this.flowLayoutPanelMacros.TabIndex = 8;
            this.flowLayoutPanelMacros.WrapContents = false;
            this.flowLayoutPanelMacros.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanel1_ControlAdded);
            this.flowLayoutPanelMacros.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanel1_ControlRemoved);
            // 
            // buttonHeader
            // 
            this.buttonHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHeader.Location = new System.Drawing.Point(3, 3);
            this.buttonHeader.Name = "buttonHeader";
            this.buttonHeader.Size = new System.Drawing.Size(485, 23);
            this.buttonHeader.TabIndex = 0;
            this.buttonHeader.Text = "Tag List";
            this.buttonHeader.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(819, 33);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 2);
            this.panel1.Size = new System.Drawing.Size(198, 468);
            this.panel1.TabIndex = 9;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.webBrowser1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(198, 468);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Preview";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(192, 449);
            this.webBrowser1.TabIndex = 0;
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 3);
            this.panel2.Controls.Add(this.textBoxAutofill);
            this.panel2.Controls.Add(this.buttonAutoFill);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1014, 24);
            this.panel2.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxGameSystems, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanelPredefinedTags, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 33);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(198, 373);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "Game Systems:";
            // 
            // comboBoxGameSystems
            // 
            this.comboBoxGameSystems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxGameSystems.FormattingEnabled = true;
            this.comboBoxGameSystems.Location = new System.Drawing.Point(3, 23);
            this.comboBoxGameSystems.Name = "comboBoxGameSystems";
            this.comboBoxGameSystems.Size = new System.Drawing.Size(192, 21);
            this.comboBoxGameSystems.TabIndex = 0;
            this.comboBoxGameSystems.SelectedIndexChanged += new System.EventHandler(this.comboBoxGameSystems_SelectedIndexChanged);
            // 
            // flowLayoutPanelPredefinedTags
            // 
            this.flowLayoutPanelPredefinedTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelPredefinedTags.Location = new System.Drawing.Point(3, 53);
            this.flowLayoutPanelPredefinedTags.Name = "flowLayoutPanelPredefinedTags";
            this.flowLayoutPanelPredefinedTags.Size = new System.Drawing.Size(192, 317);
            this.flowLayoutPanelPredefinedTags.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageChar);
            this.tabControl1.Controls.Add(this.tabPageMacro);
            this.tabControl1.Controls.Add(this.tabPageScript);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1034, 536);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.TabStop = false;
            // 
            // tabPageChar
            // 
            this.tabPageChar.Controls.Add(this.groupBox3);
            this.tabPageChar.Location = new System.Drawing.Point(4, 22);
            this.tabPageChar.Name = "tabPageChar";
            this.tabPageChar.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChar.Size = new System.Drawing.Size(1026, 510);
            this.tabPageChar.TabIndex = 1;
            this.tabPageChar.Text = "Setup";
            this.tabPageChar.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBoxPowers);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(8, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(597, 94);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DDI Downloader Powers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Enter the path to the ddi_powers.dat file.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Path to ddi_powers.dat";
            // 
            // textBoxPowers
            // 
            this.textBoxPowers.Location = new System.Drawing.Point(128, 13);
            this.textBoxPowers.Name = "textBoxPowers";
            this.textBoxPowers.Size = new System.Drawing.Size(374, 20);
            this.textBoxPowers.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(508, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonOpenPowers_Click);
            // 
            // tabPageMacro
            // 
            this.tabPageMacro.Controls.Add(this.tableLayoutPanel1);
            this.tabPageMacro.Location = new System.Drawing.Point(4, 22);
            this.tabPageMacro.Name = "tabPageMacro";
            this.tabPageMacro.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMacro.Size = new System.Drawing.Size(1026, 510);
            this.tabPageMacro.TabIndex = 0;
            this.tabPageMacro.Text = "Macro";
            this.tabPageMacro.UseVisualStyleBackColor = true;
            // 
            // tabPageScript
            // 
            this.tabPageScript.Controls.Add(this.textBoxScript);
            this.tabPageScript.Location = new System.Drawing.Point(4, 22);
            this.tabPageScript.Name = "tabPageScript";
            this.tabPageScript.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageScript.Size = new System.Drawing.Size(1026, 510);
            this.tabPageScript.TabIndex = 2;
            this.tabPageScript.Text = "Script";
            this.tabPageScript.UseVisualStyleBackColor = true;
            // 
            // textBoxScript
            // 
            this.textBoxScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxScript.Location = new System.Drawing.Point(3, 3);
            this.textBoxScript.Multiline = true;
            this.textBoxScript.Name = "textBoxScript";
            this.textBoxScript.ReadOnly = true;
            this.textBoxScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxScript.Size = new System.Drawing.Size(1020, 504);
            this.textBoxScript.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1034, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadMacroToolStripMenuItem,
            this.savectrlsToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton1.Text = "File";
            this.toolStripDropDownButton1.Visible = false;
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // loadMacroToolStripMenuItem
            // 
            this.loadMacroToolStripMenuItem.Name = "loadMacroToolStripMenuItem";
            this.loadMacroToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadMacroToolStripMenuItem.Text = "Open...";
            this.loadMacroToolStripMenuItem.Click += new System.EventHandler(this.loadMacroToolStripMenuItem_Click);
            // 
            // savectrlsToolStripMenuItem
            // 
            this.savectrlsToolStripMenuItem.Name = "savectrlsToolStripMenuItem";
            this.savectrlsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.savectrlsToolStripMenuItem.Text = "Save";
            this.savectrlsToolStripMenuItem.Click += new System.EventHandler(this.savectrlsToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(133, 22);
            this.toolStripButton1.Text = "Game System Manager";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(84, 22);
            this.toolStripButton2.Text = "Import Macro";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // openFileDialogMacro
            // 
            this.openFileDialogMacro.FileName = "openFileDialog2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 561);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Roll20 Custom Power Card Macro Generator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanelMacros.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageChar.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPageMacro.ResumeLayout(false);
            this.tabPageScript.ResumeLayout(false);
            this.tabPageScript.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAutofill;
        private System.Windows.Forms.Button buttonAutoFill;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxTotalMacroString;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMacros;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageMacro;
        private System.Windows.Forms.TabPage tabPageChar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPowers;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TabPage tabPageScript;
        private System.Windows.Forms.TextBox textBoxScript;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox comboBoxGameSystems;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPredefinedTags;
        //private System.Windows.Forms.ToolStrip toolStrip1;
        //private System.Windows.Forms.ToolStripButton toolStripButton1;
        private Forms.CustomControls.TextBoxControl textBoxControl1;
        private Forms.CustomControls.TextBoxControl textBoxControl2;
        private Forms.CustomControls.ComboBoxControl comboBoxControl1;
        private Forms.CustomControls.MacroControlBase2 macroControlBase21;
        private Forms.CustomControls.TextBoxControl textBoxControl3;
        private Forms.CustomControls.MacroControlBase2 macroControlBase22;
        private System.Windows.Forms.Button buttonHeader;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savectrlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMacroToolStripMenuItem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.SaveFileDialog saveFileDialogMacro;
        private System.Windows.Forms.OpenFileDialog openFileDialogMacro;
    }
}

