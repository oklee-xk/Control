using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics;

namespace Control {
    public partial class Main : Form {
        [STAThread]
        public static void MainThread() {
            Debug.WriteLine("App Started");
            Application.Run(new Main());
        }

        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;

        public Main() {
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("LGTV Test", Load_LGTV);
            trayMenu.MenuItems.Add("GamePad Test", Load_GamePad);
            trayMenu.MenuItems.Add("Exit", OnExit);

            trayIcon = new NotifyIcon();
            trayIcon.Text = "Remote Control";
            Icon appIcon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            trayIcon.Icon = new Icon(appIcon, 40, 40);

            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
        }

        protected override void OnLoad(EventArgs e) {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            Orchestration.Start(); //Start with all the managment

            base.OnLoad(e);
        }

        private void OnExit(object sender, EventArgs e) {
            Application.Exit();
        }

        private void Load_LGTV(object sender, EventArgs e) {
            new Control().ShowDialog();
        }

        private void Load_GamePad(object sender, EventArgs e) {
            new XInput().ShowDialog();
        }

        protected override void Dispose(bool isDisposing) {
            if (isDisposing) {
                // Release the icon resource.
                trayIcon.Dispose();
            }

            base.Dispose(isDisposing);
        }
    }
}
