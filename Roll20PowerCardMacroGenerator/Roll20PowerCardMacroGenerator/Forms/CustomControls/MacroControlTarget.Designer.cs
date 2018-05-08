namespace Roll20PowerCardMacroGenerator.Forms.CustomControls
{
    partial class MacroControlTarget
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
            this.comboBoxTag = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxContent
            // 
            this.comboBoxContent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxContent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxContent.FormattingEnabled = true;
            this.comboBoxContent.Location = new System.Drawing.Point(448, 3);
            this.comboBoxContent.Name = "comboBoxContent";
            this.comboBoxContent.Size = new System.Drawing.Size(300, 21);
            this.comboBoxContent.TabIndex = 11;
            this.comboBoxContent.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBoxTag
            // 
            this.comboBoxTag.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxTag.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTag.FormattingEnabled = true;
            this.comboBoxTag.Location = new System.Drawing.Point(206, 3);
            this.comboBoxTag.Name = "comboBoxTag";
            this.comboBoxTag.Size = new System.Drawing.Size(236, 21);
            this.comboBoxTag.TabIndex = 5;
            this.comboBoxTag.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // MacroControlTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxTag);
            this.Controls.Add(this.comboBoxContent);
            this.Name = "MacroControlTarget";
            this.Controls.SetChildIndex(this.comboBoxContent, 0);
            this.Controls.SetChildIndex(this.comboBoxTag, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxContent;
        private System.Windows.Forms.ComboBox comboBoxTag;
    }
}
