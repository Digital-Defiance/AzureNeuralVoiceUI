namespace AzureNeuralVoice
{
    partial class Settings
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
            lblAudioDevice = new Label();
            cmbAudioDevice = new ComboBox();
            lblSubscriptionKey = new Label();
            txtSubscriptionKey = new TextBox();
            txtAzureRegion = new TextBox();
            lblAzureRegion = new Label();
            txtVoiceName = new TextBox();
            lblVoiceName = new Label();
            SuspendLayout();
            // 
            // lblAudioDevice
            // 
            lblAudioDevice.AutoSize = true;
            lblAudioDevice.Location = new Point(48, 9);
            lblAudioDevice.Name = "lblAudioDevice";
            lblAudioDevice.Size = new Size(161, 32);
            lblAudioDevice.TabIndex = 3;
            lblAudioDevice.Text = "Audio Device:";
            // 
            // cmbAudioDevice
            // 
            cmbAudioDevice.FormattingEnabled = true;
            cmbAudioDevice.Location = new Point(218, 6);
            cmbAudioDevice.Name = "cmbAudioDevice";
            cmbAudioDevice.Size = new Size(568, 40);
            cmbAudioDevice.TabIndex = 2;
            cmbAudioDevice.SelectedIndexChanged += cmbAudioDevice_SelectedIndexChanged;
            // 
            // lblSubscriptionKey
            // 
            lblSubscriptionKey.AutoSize = true;
            lblSubscriptionKey.Location = new Point(12, 55);
            lblSubscriptionKey.Name = "lblSubscriptionKey";
            lblSubscriptionKey.Size = new Size(197, 32);
            lblSubscriptionKey.TabIndex = 4;
            lblSubscriptionKey.Text = "Subscription Key:";
            // 
            // txtSubscriptionKey
            // 
            txtSubscriptionKey.Location = new Point(218, 52);
            txtSubscriptionKey.Name = "txtSubscriptionKey";
            txtSubscriptionKey.Size = new Size(568, 39);
            txtSubscriptionKey.TabIndex = 5;
            txtSubscriptionKey.TextChanged += txtSubscriptionKey_TextChanged;
            // 
            // txtAzureRegion
            // 
            txtAzureRegion.Location = new Point(218, 97);
            txtAzureRegion.Name = "txtAzureRegion";
            txtAzureRegion.Size = new Size(568, 39);
            txtAzureRegion.TabIndex = 7;
            txtAzureRegion.TextChanged += txtAzureRegion_TextChanged;
            // 
            // lblAzureRegion
            // 
            lblAzureRegion.AutoSize = true;
            lblAzureRegion.Location = new Point(48, 100);
            lblAzureRegion.Name = "lblAzureRegion";
            lblAzureRegion.Size = new Size(161, 32);
            lblAzureRegion.TabIndex = 6;
            lblAzureRegion.Text = "Azure Region:";
            // 
            // txtVoiceName
            // 
            txtVoiceName.Location = new Point(220, 142);
            txtVoiceName.Name = "txtVoiceName";
            txtVoiceName.Size = new Size(568, 39);
            txtVoiceName.TabIndex = 9;
            txtVoiceName.TextChanged += txtVoiceName_TextChanged;
            // 
            // lblVoiceName
            // 
            lblVoiceName.AutoSize = true;
            lblVoiceName.Location = new Point(62, 145);
            lblVoiceName.Name = "lblVoiceName";
            lblVoiceName.Size = new Size(147, 32);
            lblVoiceName.TabIndex = 8;
            lblVoiceName.Text = "Voice Name:";
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 198);
            Controls.Add(txtVoiceName);
            Controls.Add(lblVoiceName);
            Controls.Add(txtAzureRegion);
            Controls.Add(lblAzureRegion);
            Controls.Add(txtSubscriptionKey);
            Controls.Add(lblSubscriptionKey);
            Controls.Add(lblAudioDevice);
            Controls.Add(cmbAudioDevice);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Settings";
            Text = "Settings";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAudioDevice;
        private ComboBox cmbAudioDevice;
        private Label lblSubscriptionKey;
        private TextBox txtSubscriptionKey;
        private TextBox txtAzureRegion;
        private Label lblAzureRegion;
        private TextBox txtVoiceName;
        private Label lblVoiceName;
    }
}