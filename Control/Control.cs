using System;
using System.Windows.Forms;
using System.Diagnostics;
using Remote;
using System.Drawing;

namespace Control {
    public partial class Control : Form {
        private LGTV tv;
        public Control() {
            InitializeComponent();
        }

        private void Control_Load(object sender, EventArgs e) {
            Debug.WriteLine("Application started");
        }

        private void Status_Tick(object sender, EventArgs e) {
            if (tv != null && tv.isConnected) {
                connectBtn();

                TurnOffBtn.Enabled = tv.isPaired;
                PairBtn.Enabled = !tv.isPromptVisible && !tv.isPaired;
            } else disconnectBtn();

            Vol_Up.Enabled = TurnOffBtn.Enabled;
            Vol_Down.Enabled = TurnOffBtn.Enabled;
            Ch_Up.Enabled = TurnOffBtn.Enabled;
            Ch_Down.Enabled = TurnOffBtn.Enabled;
        }

        private void disconnectBtn() {
            ConnectionBtn.BackColor = Color.Firebrick;
            ConnectionBtn.ForeColor = Color.White;
            ConnectionBtn.Text = "Desconectado";
            ConnectionBtn.Enabled = true;

            PairBtn.Enabled = false;
            TurnOffBtn.Enabled = false;
        }

        private void connectBtn() {
            ConnectionBtn.BackColor = Color.LimeGreen;
            ConnectionBtn.ForeColor = Color.White;
            ConnectionBtn.Text = "Conectado";
            ConnectionBtn.Enabled = false;
        }

        private async void ConnectionBtn_Click(object sender, EventArgs e) {
            ConnectionBtn.Enabled = false;
            tv = new LGTV(Constants.IP);
            await tv.getConnection().connect();
            ConnectionBtn.Enabled = true;
        }

        private void PairBtn_Click(object sender, EventArgs e) {
            if (!tv.isPaired && tv.isConnected) tv.pair();
        }

        private void TurnOffBtn_Click(object sender, EventArgs e) {
            tv.off();
        }

        private void Vol_Up_Click(object sender, EventArgs e) {
            tv.volumeUp();
        }

        private void Ch_Up_Click(object sender, EventArgs e) {
            tv.channelUp();
        }

        private void Vol_Down_Click(object sender, EventArgs e) {
            tv.volumeDown();
        }

        private void Ch_Down_Click(object sender, EventArgs e) {
            tv.channelDown();
        }
    }
}
