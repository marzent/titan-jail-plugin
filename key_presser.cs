using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Jail_Plugin
{
    class key_presser
    {
        #region Imports/Structs/Enums
        [StructLayout(LayoutKind.Sequential)]
        public struct KeyboardInput
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MouseInput
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HardwareInput
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)] public MouseInput mi;
            [FieldOffset(0)] public KeyboardInput ki;
            [FieldOffset(0)] public HardwareInput hi;
        }

        public struct Input
        {
            public int type;
            public InputUnion u;
        }

        [Flags]
        public enum InputType
        {
            Mouse = 0,
            Keyboard = 1,
            Hardware = 2
        }

        [Flags]
        public enum KeyEventF
        {
            KeyDown = 0x0000,
            ExtendedKey = 0x0001,
            KeyUp = 0x0002,
            Unicode = 0x0004,
            Scancode = 0x0008
        }


        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();


        #endregion

        #region Wrapper Methods


        private static void SendKeyboardInput(KeyboardInput kbInput)  {
            Input[] inputs = new Input[] {
                new Input {
                    type = (int)InputType.Keyboard,
                    u = new InputUnion {ki = kbInput}
                }
            };
            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
        }

        private static void key_down(ushort scanCode) {
            SendKeyboardInput(new KeyboardInput {
                    wScan = scanCode,
                    dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                    dwExtraInfo = GetMessageExtraInfo()
            });
        }

        private static void key_up(ushort scanCode) {
            SendKeyboardInput(new KeyboardInput {
                    wScan = scanCode,
                    dwFlags = (uint)(KeyEventF.KeyUp | KeyEventF.Scancode),
                    dwExtraInfo = GetMessageExtraInfo()
            });
        }

        public static void combo(int key)
        {
            const byte delay = 5;
            const byte control = 0x1D;
            const byte shift = 0x2A;
            const byte f1 = 0x3B; 
            key_down(control);
            Thread.Sleep(delay);
            key_down(shift);
            Thread.Sleep(delay);
            key_down((byte)(f1 + key));
            Thread.Sleep(delay);
            key_up((byte)(f1 + key));
            Thread.Sleep(delay);
            key_up(shift);
            Thread.Sleep(delay);
            key_up(control);
            Thread.Sleep(delay * 2);
        }

        #endregion
    }
}
