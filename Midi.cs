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

        public static void OpenMidiInput()
        {
            if (midiInput != null)
                return;
            midiInput = access.OpenInputAsync(MainForm.SelectedMidiDevice.Id).Result;
            midiInput.MessageReceived += HandleMidiInput_MessageReceived;
        }

        internal static bool gettingNextNote = false;
        public static void GetNextNote()
        {
            if (MainForm.SelectedMidiDevice == null)
                return;

            OpenMidiInput();
            gettingNextNote = true;
            midiInput.MessageReceived -= HandleMidiInput_MessageReceived;
            midiInput.MessageReceived += NextNote_MessageReceived;
        }

        public static void CancelGetNextNote()
        {
            if (!gettingNextNote)
                return;

            midiInput.MessageReceived += HandleMidiInput_MessageReceived;
            midiInput.MessageReceived -= NextNote_MessageReceived;
            gettingNextNote = false;
        }

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
