using System;
using System.Windows.Forms;
using XInputDotNetPure;

namespace Control {
    public partial class XInput : Form {
        public XInput() {
            InitializeComponent();
        }

        private void XInput_Load(object sender, EventArgs e) {
            
        }

        private void timer_Tick(object sender, EventArgs e) {
            GamePadState reader = XInputDotNetPure.GamePad.GetState(PlayerIndex.One);
            if (reader.IsConnected) {

                buttons.Text = reader.Buttons.ToString();
                leftThumbstickX.Text = reader.ThumbSticks.Left.X.ToString();
                rightThumbstickX.Text = reader.ThumbSticks.Right.X.ToString();
                leftThumbstickY.Text = reader.ThumbSticks.Left.Y.ToString();
                rightThumbstickY.Text = reader.ThumbSticks.Right.X.ToString();
                leftTrigger.Text = reader.Triggers.Left.ToString();
                rightTrigger.Text = reader.Triggers.Right.ToString();
            }
        }
    }
}
