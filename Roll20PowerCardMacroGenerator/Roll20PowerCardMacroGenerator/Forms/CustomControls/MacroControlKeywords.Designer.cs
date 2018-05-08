namespace Roll20PowerCardMacroGenerator.Forms.CustomControls
{
    partial class MacroControlKeywords
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKeywordsToolbox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "Keywords";
            // 
            // buttonKeywordsToolbox
            // 
            this.buttonKeywordsToolbox.Location = new System.Drawing.Point(448, 1);
            this.buttonKeywordsToolbox.Name = "buttonKeywordsToolbox";
            this.buttonKeywordsToolbox.Size = new System.Drawing.Size(300, 23);
            this.buttonKeywordsToolbox.TabIndex = 12;
            this.buttonKeywordsToolbox.Text = "Select Keywords";
            this.buttonKeywordsToolbox.UseVisualStyleBackColor = true;
            this.buttonKeywordsToolbox.Click += new System.EventHandler(this.buttonKeywordsToolbox_Click);
            // 
            // MacroControlKeywords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonKeywordsToolbox);
            this.Controls.Add(this.label1);
            this.Name = "MacroControlKeywords";
            this.Controls.SetChildIndex(this.textBoxTag, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.buttonKeywordsToolbox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonKeywordsToolbox;

    }
}
