using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Control {
    class Pc {
        private bool pcIsSleeping = false;
        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;
        private const UInt32 MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const UInt32 MOUSEEVENTF_RIGHTUP = 0x0010;
        private const UInt32 MOUSEEVENTF_WHEEL = 0x0800;
        private const UInt32 MOUSEEVENTF_HWHEEL = 0x01000;

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, int dwData, uint dwExtraInf);

        public Pc() {
            SystemEvents.PowerModeChanged += OnPowerChange;
        }

        public bool isSleeping {
            get { return pcIsSleeping; }
        }

        public void sleep() {
            pcIsSleeping = true;
            Application.SetSuspendState(PowerState.Suspend, true, true);
        }

        public void moveCursor(int x, int y, bool fromCurrentPosition = false) {
            if (fromCurrentPosition) {
                x += Cursor.Position.X;
                y += Cursor.Position.Y;
            }

            Cursor.Position = new Point(x, y);
        }

        public void leftClickDown() {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        }

        public void leftClickUp() {
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public void rightClickUp() {
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
        }

        public void rightClickDown() {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
        }

        public void wheel(int direction) {
            mouse_event(MOUSEEVENTF_WHEEL, 0, 0, direction * 120, 0);
        }

        public void hWheel(int direction) {
            mouse_event(MOUSEEVENTF_HWHEEL, 0, 0, direction * 120, 0);
        }

        private void OnPowerChange(object s, PowerModeChangedEventArgs e) {
            pcIsSleeping = e.Mode == PowerModes.Suspend && e.Mode != PowerModes.Resume;
        }
    }
}
