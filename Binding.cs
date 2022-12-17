using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using WindowsInput;
using WindowsInput.Native;

namespace MidiBinder
{
    public class Binding
    {
        private static InputSimulator inputSim = new InputSimulator();

        public int in_MidiNote = 0;

        public BindingFunction out_Function = BindingFunction.Key;
        public VirtualKeyCode out_Key = VirtualKeyCode.CAPITAL;
        public string out_Command = "";
        public string out_SoundPath = "";

        public string Name;

        public Binding()
        {

        }
        public Binding(string name)
        {
            this.Name = name;
        }

        internal void Execute()
        {
            if (out_Function == BindingFunction.None)
                return;
            // Key press
            else if (out_Function == BindingFunction.Key)
            {
                inputSim.Keyboard.KeyPress(out_Key);
            }
            // Command
            else if (out_Function == BindingFunction.Command)
            {
                if (string.IsNullOrWhiteSpace(out_Command))
                    return;

                try
                {
                    string[] splitCommand = out_Command.Split(new char[0], 2); // split
                    if (splitCommand.Length > 1)
                        Process.Start(splitCommand[0], splitCommand[1]);
                    else
                        Process.Start(out_Command);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while running command \"{out_Command}\" from {Name}:\r\n{ex.Message}", "MidiBinder command error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Sound play
            else if (out_Function == BindingFunction.Sound)
            {
                if (string.IsNullOrWhiteSpace(out_SoundPath))
                    return;

                try
                {
                    FileInfo soundFile = new FileInfo(out_SoundPath);
                    if (!soundFile.Exists)
                    {
                        throw new FileNotFoundException($"File not found");
                    }

                    WaveStream provider;
                    if (soundFile.Extension == ".mp3")
                    {
                        provider = new Mp3FileReader(soundFile.FullName);
                    }
                    else if (soundFile.Extension == ".wav")
                    {
                        provider = new WaveFileReader(soundFile.FullName);
                    }
                    else
                    {
                        throw new FileFormatException("File type not supported");
                    }

                    WaveOutEvent player = new WaveOutEvent();
                    player.Init(provider);
                    player.PlaybackStopped += (obj, e) => {
                        player.Dispose();
                        provider.Dispose();
                    };
                    player.Play();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while playing sound \"{out_SoundPath}\" from {Name}:\r\n{ex.Message}", "MidiBinder sound error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public string GetNoteName()
        {
            return GetNoteName(in_MidiNote);
        }

        public static string GetNoteName(int note)
        {
            string octave = (Math.Floor(note / 12d) - 2).ToString();
            switch (note % 12)
            {
                case 0:
                    return "C " + octave;
                case 1:
                    return "C# " + octave;
                case 2:
                    return "D " + octave;
                case 3:
                    return "D# " + octave;
                case 4:
                    return "E " + octave;
                case 5:
                    return "F " + octave;
                case 6:
                    return "F# " + octave;
                case 7:
                    return "G " + octave;
                case 8:
                    return "G# " + octave;
                case 9:
                    return "A " + octave;
                case 10:
                    return "A# " + octave;
                case 11:
                    return "B " + octave;
                default:
                    return "?";
            }
        }
    }

    public enum BindingFunction
    {
        None,
        Key,
        Command,
        Sound,
    }
}
