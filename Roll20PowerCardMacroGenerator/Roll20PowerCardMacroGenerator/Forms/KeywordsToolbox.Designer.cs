namespace Roll20PowerCardMacroGenerator.Forms
{
    partial class KeywordsToolbox
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
            this.checkedListBoxKeywords = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // checkedListBoxKeywords
            // 
            this.checkedListBoxKeywords.CheckOnClick = true;
            this.checkedListBoxKeywords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxKeywords.FormattingEnabled = true;
            this.checkedListBoxKeywords.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxKeywords.Name = "checkedListBoxKeywords";
            this.checkedListBoxKeywords.Size = new System.Drawing.Size(184, 311);
            this.checkedListBoxKeywords.TabIndex = 0;
            // 
            // KeywordsToolbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 311);
            this.Controls.Add(this.checkedListBoxKeywords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "KeywordsToolbox";
            this.Text = "Keywords";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.CheckedListBox checkedListBoxKeywords;
    }
}