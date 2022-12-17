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

        internal static List<Binding> bindings = new List<Binding>();
        internal static Binding? currentBinding;

        private static List<IMidiPortDetails> devices;

        internal static IMidiPortDetails SelectedMidiDevice => devices[Instance.midiDevicesCombo.SelectedIndex];

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

        private void RegenerateBindingsList()
        {
            var oldIndicies = bindingsListView.SelectedIndices;
            bindingsListView.Items.Clear();
            foreach (Binding binding in bindings)
            {
                bindingsListView.Items.Add(binding.Name);
            }
            foreach (int oldIndex in oldIndicies)
                bindingsListView.SelectedIndices.Add(oldIndex);
        }

        private void addBindingButton_Click(object sender, EventArgs e)
        {
            Binding binding = new Binding("New Binding");
            bindings.Add(binding);
            RegenerateBindingsList();
        }

        private void deleteBindingButton_Click(object sender, EventArgs e)
        {
            if (bindingsListView.SelectedIndices.Count < 1)
                return;
            bindings.RemoveAt(bindingsListView.SelectedIndices[0]);
            RegenerateBindingsList();
        }

        private string GetBindingNoteName()
        {
            if (currentBinding == null)
                return "[?]";

            return $"[{currentBinding.GetNoteName()}]";
        }

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
            bindingNameTextBox.Text = currentBinding.Name;
            noteNumericUpDown.Value = currentBinding.in_MidiNote;
            outputKeyCombo.SelectedItem = currentBinding.out_Key;
            outputFunctionCombo.SelectedItem = currentBinding.out_Function;
            outputCommandTextBox.Text = currentBinding.out_Command;
            midiNoteLabel.Text = GetBindingNoteName();

            ChangeFunctionEnableState();
        }

        private void noteNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (currentBinding == null)
                return;
            currentBinding.in_MidiNote = (int)Math.Floor(noteNumericUpDown.Value);
            midiNoteLabel.Text = GetBindingNoteName();
        }

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

        private void bindingNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (currentBinding == null)
                return;
            currentBinding.Name = bindingNameTextBox.Text;
            RegenerateBindingsList();
        }

        private void outputKeyCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentBinding == null)
                return;
            Enum.TryParse(outputFunctionCombo.SelectedValue.ToString(), out BindingFunction bf);
            currentBinding.out_Function = bf;
            ChangeFunctionEnableState();
        }


        private void ChangeFunctionEnableState()
        {
            if (currentBinding == null)
                return;

            outputKeyCombo.Enabled = currentBinding.out_Function == BindingFunction.Key;
            outputCommandTextBox.Enabled = currentBinding.out_Function == BindingFunction.Command;
        }

        private void outputKeyCombo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (currentBinding == null)
                return;
            Enum.TryParse(outputKeyCombo.SelectedValue.ToString(), out VirtualKeyCode vk);
            currentBinding.out_Key = vk;
        }

        private void outputCommandTextBox_TextChanged(object sender, EventArgs e)
        {
            if (currentBinding == null)
                return;
            currentBinding.out_Command = outputCommandTextBox.Text;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveXMLBindings();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadXMLBindings();
        }

        private void SaveXMLBindings()
        {
            XmlSerializer serializer = new XmlSerializer(bindings.GetType());
            using (TextWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, bindings);
            }
        }

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

        private void midiDevicesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Midi.OpenMidiInput();
            }
            catch { }
        }
    }
}