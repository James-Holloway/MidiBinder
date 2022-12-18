using System.Windows.Forms;
using System.Xml.Serialization;
using Commons.Music.Midi;
using WindowsInput.Native;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MidiBinder
{
    public partial class MainForm : Form
    {
        const string filename = "bindings.xml";
        internal static MainForm Instance;

        public MainForm()
        {
            InitializeComponent();
            Instance = this;
        }

        // List of bindings, used throughout
        internal static List<Binding> bindings = new List<Binding>();
        // Current selected binding
        internal static Binding? currentBinding;

        // Midi Input devices for use in the drop down combobox
        private static List<IMidiPortDetails> devices;
        internal static IMidiPortDetails SelectedMidiDevice => devices[Instance.midiDevicesCombo.SelectedIndex];

        // Setup of the midi devices, comboboxes and attempts to load xml bindings
        private void MainForm_Load(object sender, EventArgs e)
        {
            devices = Midi.GetDevices().ToList();
            foreach (var device in devices)
            {
                midiDevicesCombo.Items.Add($"{device.Name} ({device.Id})");
            }
            if (midiDevicesCombo.Items.Count > 0)
                midiDevicesCombo.SelectedIndex = 0;

            try
            {
                Midi.OpenMidiInput();
            }
            catch { }

            outputFunctionCombo.DataSource = Enum.GetValues(typeof(BindingFunction));
            outputKeyCombo.DataSource = Enum.GetValues(typeof(VirtualKeyCode));

            LoadXMLBindings();
        }

        // Used for updating the name of the binding
        private void RegenerateBindingsList()
        {
            var oldIndicies = bindingsListView.SelectedIndices;
            int previouslyFocusedItem = bindingsListView?.FocusedItem?.Index ?? 0;

            bindingsListView.Items.Clear();
            foreach (Binding binding in bindings)
            {
                bindingsListView.Items.Add(binding.Name);
            }

            foreach (int oldIndex in oldIndicies)
                bindingsListView.SelectedIndices.Add(oldIndex);

            bindingsListView.FocusedItem = bindingsListView.Items[previouslyFocusedItem];

        }

        // "Add" button
        private void addBindingButton_Click(object sender, EventArgs e)
        {
            Binding binding = new Binding("New Binding");
            bindings.Add(binding);
            RegenerateBindingsList();
        }

        // "Delete" button
        private void deleteBindingButton_Click(object sender, EventArgs e)
        {
            if (bindingsListView.SelectedIndices.Count < 1)
                return;
            bindings.RemoveAt(bindingsListView.SelectedIndices[0]);
            RegenerateBindingsList();
        }

        // Gets the note name in square brackets for the label next to the "Detect" button
        private string GetBindingNoteName()
        {
            if (currentBinding == null)
                return "[?]";

            return $"[{currentBinding.GetNoteName()}]";
        }

        // Changes what on the right side is enabled based on the current binding's output function
        private void ChangeFunctionEnableState()
        {
            if (currentBinding == null)
                return;

            outputKeyCombo.Enabled = currentBinding.out_Function == BindingFunction.Key;
            outputCommandTextBox.Enabled = currentBinding.out_Function == BindingFunction.Command;
            browseSoundButton.Enabled = currentBinding.out_Function == BindingFunction.Sound;
            browseSoundTextBox.Enabled = currentBinding.out_Function == BindingFunction.Sound;
        }

        // When the selected binding in the list changes, we need to update the right hand side
        private void bindingsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindingsListView.SelectedIndices.Count < 1)
            {
                currentBinding = null;
                bindingPanel.Enabled = false;
                // Reset right side values
                bindingNameTextBox.Text = string.Empty;
                noteNumericUpDown.Value = 0;
                midiNoteLabel.Text = GetBindingNoteName();
                Midi.CancelGetNextNote();
                return;
            }

            currentBinding = bindings[bindingsListView.SelectedIndices[0]];
            bindingPanel.Enabled = true;

            // Set the right side values
            // Inputs
            bindingNameTextBox.Text = currentBinding.Name;
            noteNumericUpDown.Value = currentBinding.in_MidiNote;
            midiNoteLabel.Text = GetBindingNoteName();

            // Outputs
            outputFunctionCombo.SelectedItem = currentBinding.out_Function;
            outputKeyCombo.SelectedItem = currentBinding.out_Key;
            outputCommandTextBox.Text = currentBinding.out_Command;
            browseSoundTextBox.Text = currentBinding.out_SoundPath;

            ChangeFunctionEnableState();
        }

        // When the note numerical up down changes, we change the midi note label and the current binding's midi note input
        private void noteNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (currentBinding == null)
                return;
            currentBinding.in_MidiNote = (int)Math.Floor(noteNumericUpDown.Value);
            midiNoteLabel.Text = GetBindingNoteName();
        }

        // When the "Detect" button is clicked, we want to get the next note (or cancel the action)
        private void detectButton_Click(object sender, EventArgs e)
        {
            if (!Midi.gettingNextNote)
            {
                Midi.GetNextNote();
                detectButton.Text = "Cancel";
            }
            else
            {
                Midi.CancelGetNextNote();
                detectButton.Text = "Detect";
            }
        }

        // When the binding name is updated, update the currentBinding and update the list
        private void bindingNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (currentBinding == null)
                return;
            currentBinding.Name = bindingNameTextBox.Text;
            RegenerateBindingsList();
        }

        // Change the current binding's output function to match the one presented in the combobox
        private void outputFunctionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentBinding == null)
                return;
            Enum.TryParse(outputFunctionCombo.SelectedValue.ToString(), out BindingFunction bf);
            currentBinding.out_Function = bf;
            ChangeFunctionEnableState();
        }

        // Change the current binding's output key to match the one presented in the combobox
        private void outputKeyCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentBinding == null)
                return;
            Enum.TryParse(outputKeyCombo.SelectedValue.ToString(), out VirtualKeyCode vk);
            currentBinding.out_Key = vk;
        }

        // Update the out_Command with the "Command" text box
        private void outputCommandTextBox_TextChanged(object sender, EventArgs e)
        {
            if (currentBinding == null)
                return;
            currentBinding.out_Command = outputCommandTextBox.Text;
        }

        // "Save" button saves to bindings.xml
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveXMLBindings();
        }
        
        // "Load" button loads from bindings.xml
        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadXMLBindings();
        }

        // Saves the current bindings list to bindings.xml
        private void SaveXMLBindings()
        {
            XmlSerializer serializer = new XmlSerializer(bindings.GetType());
            using (TextWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, bindings);
            }
        }

        // Attempts to load the bindings from bindings.xml and put them into the List<Binding> bindings
        private void LoadXMLBindings()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(bindings.GetType());
                if (new FileInfo(filename).Exists)
                {
                    using (Stream reader = new FileStream(filename, FileMode.Open))
                    {
                        bindings = (List<Binding>)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while parsing binding file \"{filename}\":\r\n{ex.Message}", "MidiBinder loading error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RegenerateBindingsList();
            bindingPanel.Enabled = false;
            bindingsListView.SelectedIndices.Clear();
        }

        // Attempt to open the midi device when the selected midi device changes
        private void midiDevicesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Midi.OpenMidiInput();
            }
            catch { }
        }

        // "Browse..." button opens up the file dialog
        private void browseSoundButton_Click(object sender, EventArgs e)
        {
            openSoundFileDialog.ShowDialog();
        }

        // Once file has been browsed to, update the relevant text box and current binding's sound path
        private void openSoundFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (currentBinding == null)
                return;

            string filepath = openSoundFileDialog.FileName;
            currentBinding.out_SoundPath = filepath;
            browseSoundTextBox.Text = filepath;
        }

        // Update the binding's sound path if the user changes the text box manually
        private void browseSoundTextBox_TextChanged(object sender, EventArgs e)
        {
            if (currentBinding == null)
                return;
            currentBinding.out_SoundPath = browseSoundTextBox.Text;
        }

        private void minimiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            trayNotifyIcon.ShowBalloonTip(500);
            trayNotifyIcon.Visible = true;
        }

        private void trayNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            trayNotifyIcon.Visible = false;
        }
    }
}