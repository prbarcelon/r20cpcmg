namespace Roll20PowerCardMacroGenerator.Forms.CustomControls
{
    partial class MacroControlComboBox
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
            this.comboBoxContent = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxContent
            // 
            this.comboBoxContent.FormattingEnabled = true;
            this.comboBoxContent.Location = new System.Drawing.Point(350, 2);
            this.comboBoxContent.Name = "comboBoxContent";
            this.comboBoxContent.Size = new System.Drawing.Size(398, 21);
            this.comboBoxContent.TabIndex = 12;
            // 
            // MacroControlComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxContent);
            this.Name = "MacroControlComboBox";
            this.Controls.SetChildIndex(this.comboBoxContent, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxContent;
    }
}
