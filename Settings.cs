using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureNeuralVoice
{
    public partial class Settings : Form
    {
        private Dictionary<string, string> audioDevicesByName = new Dictionary<string, string>();

        public Settings()
        {
            InitializeComponent();
            Load += Settings_Load;
        }
        public List<KeyValuePair<string, string>> GetAudioDeviceList()
        {
            var devices = new MMDeviceEnumerator();
            var deviceList = new List<KeyValuePair<string, string>>();
            foreach (var endpoint in devices.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
            {
                deviceList.Add(new KeyValuePair<string, string>(endpoint.ID, endpoint.FriendlyName));
            }

            return deviceList;
        }

        private void SelectDeviceInListBox(string deviceName)
        {
            int index = cmbAudioDevice.Items.IndexOf(deviceName);
            if (index != -1)
            {
                cmbAudioDevice.SelectedIndex = index;
            }
            else
            {
                // Handle the case where the device is not found
                cmbAudioDevice.SelectedIndex = -1;
            }
        }

        private void Settings_Load(object? sender, EventArgs e)
        {
            var devices = GetAudioDeviceList();
            var selectedDeviceText = "";
            foreach (var device in devices)
            {
                cmbAudioDevice.Items.Add(device.Value);
                audioDevicesByName.Add(device.Value, device.Key);
                if (device.Key == Properties.Settings.Default.AudioDeviceId)
                {
                    selectedDeviceText = device.Value;
                }
            }
            SelectDeviceInListBox(selectedDeviceText);
            txtSubscriptionKey.Text = Properties.Settings.Default.SubscriptionKey;
            txtAzureRegion.Text = Properties.Settings.Default.VoiceRegion;
            txtVoiceName.Text = Properties.Settings.Default.VoiceName;
            // set up defaults
            if (String.IsNullOrEmpty(txtAzureRegion.Text))
            {
                txtAzureRegion.Text = "westus2";
                Properties.Settings.Default.VoiceRegion = txtAzureRegion.Text;
                Properties.Settings.Default.Save();
            }
            if (String.IsNullOrEmpty(txtVoiceName.Text))
            {
                txtVoiceName.Text = "en-US-JennyNeural";
                Properties.Settings.Default.VoiceName = txtVoiceName.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void cmbAudioDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDeviceName = cmbAudioDevice.SelectedItem.ToString();
            if (audioDevicesByName.TryGetValue(selectedDeviceName, out string selectedDeviceId))
            {
                Properties.Settings.Default.AudioDeviceId = selectedDeviceId;
            }
            else
            {
                Properties.Settings.Default.AudioDeviceId = "";
            }
            Properties.Settings.Default.Save();
        }

        private void txtSubscriptionKey_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SubscriptionKey = txtSubscriptionKey.Text;
            Properties.Settings.Default.Save();
        }

        private void txtAzureRegion_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.VoiceRegion = txtAzureRegion.Text;
            Properties.Settings.Default.Save();
        }

        private void txtVoiceName_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.VoiceName = txtVoiceName.Text;
            Properties.Settings.Default.Save();
        }
    }
}
