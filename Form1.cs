using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;


namespace AzureNeuralVoice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            txtContent.KeyDown += TxtContent_KeyDown;
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
            config.SpeechSynthesisVoiceName = "en-US-JennyNeural";

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
    }
}
