namespace TougouSystem.DebugForm
{
    partial class textInputForm
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
            this.viewTextBox = new System.Windows.Forms.TextBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.changeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // viewTextBox
            // 
            this.viewTextBox.Location = new System.Drawing.Point(12, 12);
            this.viewTextBox.Multiline = true;
            this.viewTextBox.Name = "viewTextBox";
            this.viewTextBox.Size = new System.Drawing.Size(776, 213);
            this.viewTextBox.TabIndex = 0;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(12, 272);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(776, 25);
            this.inputTextBox.TabIndex = 1;
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(616, 358);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(151, 57);
            this.changeButton.TabIndex = 3;
            this.changeButton.Text = "変更";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_onClick);
            // 
            // changeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.viewTextBox);
            this.Name = "changeForm";
            this.Text = "changeForm";
            this.Load += new System.EventHandler(this.changeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox viewTextBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button changeButton;
    }
}