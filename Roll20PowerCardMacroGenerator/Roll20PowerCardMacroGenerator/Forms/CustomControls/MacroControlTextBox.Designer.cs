namespace Roll20PowerCardMacroGenerator.Forms.CustomControls
{
    partial class MacroControlTextBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxContent
            // 
            this.textBoxContent.Location = new System.Drawing.Point(419, 2);
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(291, 20);
            this.textBoxContent.TabIndex = 12;
            this.textBoxContent.TextChanged += new System.EventHandler(this.textBoxTag_TextChanged);
            // 
            // MacroControlTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxContent);
            this.Name = "MacroControlTextBox";
            this.Controls.SetChildIndex(this.textBoxTag, 0);
            this.Controls.SetChildIndex(this.textBoxContent, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxContent;
    }
}
