namespace AzureNeuralVoice
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtContent = new TextBox();
            btnSpeak = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // txtContent
            // 
            txtContent.Location = new Point(12, 12);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(774, 328);
            txtContent.TabIndex = 2;
            // 
            // btnSpeak
            // 
            btnSpeak.Location = new Point(636, 346);
            btnSpeak.Name = "btnSpeak";
            btnSpeak.Size = new Size(150, 46);
            btnSpeak.TabIndex = 3;
            btnSpeak.Text = "Speak";
            btnSpeak.UseVisualStyleBackColor = true;
            btnSpeak.Click += btnSpeak_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 346);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 4;
            button1.Text = "Settings";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 404);
            Controls.Add(button1);
            Controls.Add(btnSpeak);
            Controls.Add(txtContent);
            Name = "Form1";
            Text = "Azure Text to Speech";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtContent;
        private Button btnSpeak;
        private Button button1;
    }
}
