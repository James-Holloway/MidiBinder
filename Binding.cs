using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace MidiBinder
{
    public class Binding
    {
        private static InputSimulator inputSim = new InputSimulator();

        public int in_MidiNote = 0;

        public BindingFunction out_Function = BindingFunction.Key;
        public string out_Command = "";
        public VirtualKeyCode out_Key = VirtualKeyCode.CAPITAL;

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
            else if (out_Function == BindingFunction.Key)
            {
                inputSim.Keyboard.KeyPress(out_Key);
            }
            else if (out_Function == BindingFunction.Command)
            {
                if (string.IsNullOrWhiteSpace(out_Command))
                    return;

                try
                {
                    string[] splitCommand = out_Command.Split(new char[0], 2);
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
        }
    }

    public enum BindingFunction
    {
        None,
        Key,
        Command,
    }
}
