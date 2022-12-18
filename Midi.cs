using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons.Music.Midi;
using Commons.Music.Midi.WinMM;
using CoreMidi;

namespace MidiBinder
{
    internal static class Midi
    {
        internal static IMidiAccess access = MidiAccessManager.Default;

        public static IEnumerable<IMidiPortDetails> GetDevices() => access.Inputs;

        internal static IMidiInput midiInput;

        // Opens the midi input port with the selected device from the mainform
        public static void OpenMidiInput()
        {
            if (midiInput != null && midiInput.Connection == MidiPortConnectionState.Open)
                return;
            midiInput = access.OpenInputAsync(MainForm.SelectedMidiDevice.Id).Result;
            midiInput.MessageReceived += HandleMidiInput_MessageReceived;
        }
        public static void ReopenMidiInput()
        {
            if (midiInput != null)
            {
                midiInput.CloseAsync();
                while (midiInput.Connection == MidiPortConnectionState.Open)
                {
                    Thread.Sleep(100);
                }
            }
            OpenMidiInput();
        }

        internal static bool gettingNextNote = false;
        // Changes the message received event handler so the next Midi note input is set to the note updown box (uses NextNote_MessageReceived)
        public static void GetNextNote()
        {
            if (MainForm.SelectedMidiDevice == null)
                return;

            // OpenMidiInput();
            gettingNextNote = true;
            midiInput.MessageReceived -= HandleMidiInput_MessageReceived;
            midiInput.MessageReceived += NextNote_MessageReceived;
        }

        // Cancels the GetNextNote command by replacing the message received event handler with the default
        public static void CancelGetNextNote()
        {
            if (!gettingNextNote)
                return;

            midiInput.MessageReceived += HandleMidiInput_MessageReceived;
            midiInput.MessageReceived -= NextNote_MessageReceived;
            gettingNextNote = false;
        }

        // Used by GetNextNote to get the next note and set the current binding's in midi note
        private static void NextNote_MessageReceived(object? sender, MidiReceivedEventArgs e)
        {
            if (e.Data[0] == MidiEvent.NoteOn)
            {
                gettingNextNote = false;
                MainForm.Instance.Invoke(() =>
                {
                    MainForm.Instance.noteNumericUpDown.Value = e.Data[1];
                    MainForm.Instance.detectButton.Text = "Detect";
                });
                midiInput.MessageReceived -= NextNote_MessageReceived;
                midiInput.MessageReceived += HandleMidiInput_MessageReceived;
            }
        }

        // Main event to handle midi input and execute the binding
        private static void HandleMidiInput_MessageReceived(object? sender, MidiReceivedEventArgs e)
        {
            if (e.Data[0] == MidiEvent.NoteOn)
            {
                int note = e.Data[1];
                int velocity = e.Data[2];
                foreach (Binding binding in MainForm.bindings)
                {
                    if (binding.in_MidiNote == note && velocity > 50)
                    {
                        binding.Execute();
                    }
                }
            }
        }
    }
}
