using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System.Runtime.InteropServices;


namespace AzureNeuralVoice
{
    public partial class Form1 : Form
    {
        const int SW_RESTORE = 9;  // Command to restore the window

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            txtContent.KeyDown += TxtContent_KeyDown;
            Resize += Form1_Resize;
        }

        private void ShowWindow()
        {
            // Make sure the window is not minimized
            if (this.WindowState == FormWindowState.Minimized)
            {
                ShowWindow(this.Handle, SW_RESTORE);
            }

            // Show the window (in case it was hidden) and bring it to front
            this.Show();
            this.BringToFront();

            // Set the window to be the foreground window
            SetForegroundWindow(this.Handle);

            // Optionally, activate the window and focus on a specific control
            this.Activate();
            txtContent.Focus();
        }

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private void Form1_Resize(object? sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void TxtContent_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var textToSpeak = txtContent.Text;
                Task.Run(async () =>
                {
                    await Speak(textToSpeak, Properties.Settings.Default.AudioDeviceId);
                });
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (!e.Shift)
                {
                    txtContent.Text = "";
                }
            }
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
        }

        public async Task Speak(string text, string selectedDeviceId)
        {
            //
            // For more samples please visit https://github.com/Azure-Samples/cognitive-services-speech-sdk 
            // 

            // Creates an instance of a speech config with specified subscription key and service region.
            AudioConfig audioConfig = AudioConfig.FromSpeakerOutput(selectedDeviceId);
            var config = SpeechConfig.FromSubscription(Properties.Settings.Default.SubscriptionKey, Properties.Settings.Default.VoiceRegion);
            // Note: the voice setting will not overwrite the voice element in input SSML.
            config.SpeechSynthesisVoiceName = Properties.Settings.Default.VoiceName;

            // use the default speaker as audio output.
            using (var synthesizer = new SpeechSynthesizer(config, audioConfig))
            {
                using (var result = await synthesizer.SpeakTextAsync(text))
                {
                    if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                    {
                        Console.WriteLine($"Speech synthesized for text [{text}]");
                    }
                    else if (result.Reason == ResultReason.Canceled)
                    {
                        var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                        Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                        if (cancellation.Reason == CancellationReason.Error)
                        {
                            Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                            Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                            Console.WriteLine($"CANCELED: Did you update the subscription info?");
                        }
                    }
                }
            }

        }

        private void btnSpeak_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Properties.Settings.Default.SubscriptionKey))
            {
                MessageBox.Show("Must provide Subscription Key in settings. Get this from Azure speech studio or azure portal.", "Subscription Key", MessageBoxButtons.OK);
                return;
            }
            else if (String.IsNullOrEmpty(Properties.Settings.Default.VoiceRegion))
            {
                MessageBox.Show("Must provide Azure Region. This is \"westus2\" for example. Must match your speech resource.", "Voice Region", MessageBoxButtons.OK);
                return;
            }
            else if (String.IsNullOrEmpty(Properties.Settings.Default.AudioDeviceId))
            {
                MessageBox.Show("Must set audio device for output in settings", "Audio Device", MessageBoxButtons.OK);
                return;
            }
            Task.Run(async () =>
            {
                await Speak(txtContent.Text, Properties.Settings.Default.AudioDeviceId);
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowWindow();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowWindow();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
