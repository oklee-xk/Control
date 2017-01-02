namespace Control {
    partial class Control {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Control));
            this.Status = new System.Windows.Forms.Timer(this.components);
            this.ConnectionBtn = new System.Windows.Forms.Button();
            this.PairBtn = new System.Windows.Forms.Button();
            this.TurnOffBtn = new System.Windows.Forms.Button();
            this.ControlBtns = new System.Windows.Forms.Panel();
            this.Ch_Down = new System.Windows.Forms.Button();
            this.Vol_Up = new System.Windows.Forms.Button();
            this.Ch_Up = new System.Windows.Forms.Button();
            this.ChannelLbl = new System.Windows.Forms.Label();
            this.VolumeLbl = new System.Windows.Forms.Label();
            this.Vol_Down = new System.Windows.Forms.Button();
            this.ControlBtns.SuspendLayout();
            this.SuspendLayout();
            // 
            // Status
            // 
            this.Status.Enabled = true;
            this.Status.Interval = 250;
            this.Status.Tick += new System.EventHandler(this.Status_Tick);
            // 
            // ConnectionBtn
            // 
            this.ConnectionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectionBtn.FlatAppearance.BorderSize = 0;
            this.ConnectionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionBtn.Location = new System.Drawing.Point(12, 12);
            this.ConnectionBtn.Name = "ConnectionBtn";
            this.ConnectionBtn.Size = new System.Drawing.Size(228, 55);
            this.ConnectionBtn.TabIndex = 0;
            this.ConnectionBtn.Text = "Connect";
            this.ConnectionBtn.UseVisualStyleBackColor = false;
            this.ConnectionBtn.Click += new System.EventHandler(this.ConnectionBtn_Click);
            // 
            // PairBtn
            // 
            this.PairBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PairBtn.FlatAppearance.BorderSize = 0;
            this.PairBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PairBtn.Location = new System.Drawing.Point(12, 73);
            this.PairBtn.Name = "PairBtn";
            this.PairBtn.Size = new System.Drawing.Size(104, 55);
            this.PairBtn.TabIndex = 1;
            this.PairBtn.Text = "Pair";
            this.PairBtn.UseVisualStyleBackColor = false;
            this.PairBtn.Click += new System.EventHandler(this.PairBtn_Click);
            // 
            // TurnOffBtn
            // 
            this.TurnOffBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TurnOffBtn.FlatAppearance.BorderSize = 0;
            this.TurnOffBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TurnOffBtn.Location = new System.Drawing.Point(122, 73);
            this.TurnOffBtn.Name = "TurnOffBtn";
            this.TurnOffBtn.Size = new System.Drawing.Size(118, 55);
            this.TurnOffBtn.TabIndex = 2;
            this.TurnOffBtn.Text = "Off";
            this.TurnOffBtn.UseVisualStyleBackColor = false;
            this.TurnOffBtn.Click += new System.EventHandler(this.TurnOffBtn_Click);
            // 
            // ControlBtns
            // 
            this.ControlBtns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlBtns.BackColor = System.Drawing.Color.Gray;
            this.ControlBtns.Controls.Add(this.Vol_Down);
            this.ControlBtns.Controls.Add(this.Ch_Down);
            this.ControlBtns.Controls.Add(this.Vol_Up);
            this.ControlBtns.Controls.Add(this.Ch_Up);
            this.ControlBtns.Controls.Add(this.ChannelLbl);
            this.ControlBtns.Controls.Add(this.VolumeLbl);
            this.ControlBtns.Location = new System.Drawing.Point(12, 134);
            this.ControlBtns.Name = "ControlBtns";
            this.ControlBtns.Size = new System.Drawing.Size(228, 250);
            this.ControlBtns.TabIndex = 3;
            // 
            // Ch_Down
            // 
            this.Ch_Down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ch_Down.BackColor = System.Drawing.Color.Transparent;
            this.Ch_Down.BackgroundImage = global::Control.Properties.Resources.arrow_down;
            this.Ch_Down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Ch_Down.FlatAppearance.BorderSize = 0;
            this.Ch_Down.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.Ch_Down.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Ch_Down.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Ch_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ch_Down.Location = new System.Drawing.Point(119, 148);
            this.Ch_Down.Name = "Ch_Down";
            this.Ch_Down.Size = new System.Drawing.Size(90, 82);
            this.Ch_Down.TabIndex = 4;
            this.Ch_Down.UseVisualStyleBackColor = false;
            this.Ch_Down.Click += new System.EventHandler(this.Ch_Down_Click);
            // 
            // Vol_Up
            // 
            this.Vol_Up.BackColor = System.Drawing.Color.Transparent;
            this.Vol_Up.BackgroundImage = global::Control.Properties.Resources.arrow1;
            this.Vol_Up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Vol_Up.FlatAppearance.BorderSize = 0;
            this.Vol_Up.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.Vol_Up.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Vol_Up.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Vol_Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Vol_Up.Location = new System.Drawing.Point(16, 16);
            this.Vol_Up.Name = "Vol_Up";
            this.Vol_Up.Size = new System.Drawing.Size(90, 82);
            this.Vol_Up.TabIndex = 3;
            this.Vol_Up.UseVisualStyleBackColor = false;
            this.Vol_Up.Click += new System.EventHandler(this.Vol_Up_Click);
            // 
            // Ch_Up
            // 
            this.Ch_Up.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Ch_Up.BackColor = System.Drawing.Color.Transparent;
            this.Ch_Up.BackgroundImage = global::Control.Properties.Resources.arrow1;
            this.Ch_Up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Ch_Up.FlatAppearance.BorderSize = 0;
            this.Ch_Up.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.Ch_Up.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Ch_Up.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Ch_Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ch_Up.Location = new System.Drawing.Point(119, 16);
            this.Ch_Up.Name = "Ch_Up";
            this.Ch_Up.Size = new System.Drawing.Size(90, 82);
            this.Ch_Up.TabIndex = 2;
            this.Ch_Up.UseVisualStyleBackColor = false;
            this.Ch_Up.Click += new System.EventHandler(this.Ch_Up_Click);
            // 
            // ChannelLbl
            // 
            this.ChannelLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ChannelLbl.AutoSize = true;
            this.ChannelLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChannelLbl.Location = new System.Drawing.Point(138, 109);
            this.ChannelLbl.Name = "ChannelLbl";
            this.ChannelLbl.Size = new System.Drawing.Size(51, 30);
            this.ChannelLbl.TabIndex = 1;
            this.ChannelLbl.Text = "CH";
            this.ChannelLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VolumeLbl
            // 
            this.VolumeLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.VolumeLbl.AutoSize = true;
            this.VolumeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolumeLbl.Location = new System.Drawing.Point(29, 108);
            this.VolumeLbl.Name = "VolumeLbl";
            this.VolumeLbl.Size = new System.Drawing.Size(64, 30);
            this.VolumeLbl.TabIndex = 0;
            this.VolumeLbl.Text = "VOL";
            this.VolumeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Vol_Down
            // 
            this.Vol_Down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Vol_Down.BackColor = System.Drawing.Color.Transparent;
            this.Vol_Down.BackgroundImage = global::Control.Properties.Resources.arrow_down;
            this.Vol_Down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Vol_Down.FlatAppearance.BorderSize = 0;
            this.Vol_Down.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.Vol_Down.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Vol_Down.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Vol_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Vol_Down.Location = new System.Drawing.Point(16, 148);
            this.Vol_Down.Name = "Vol_Down";
            this.Vol_Down.Size = new System.Drawing.Size(90, 82);
            this.Vol_Down.TabIndex = 5;
            this.Vol_Down.UseVisualStyleBackColor = false;
            this.Vol_Down.Click += new System.EventHandler(this.Vol_Down_Click);
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 396);
            this.Controls.Add(this.ControlBtns);
            this.Controls.Add(this.TurnOffBtn);
            this.Controls.Add(this.PairBtn);
            this.Controls.Add(this.ConnectionBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Control";
            this.Text = "Remote Control";
            this.Load += new System.EventHandler(this.Control_Load);
            this.ControlBtns.ResumeLayout(false);
            this.ControlBtns.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Status;
        private System.Windows.Forms.Button ConnectionBtn;
        private System.Windows.Forms.Button PairBtn;
        private System.Windows.Forms.Button TurnOffBtn;
        private System.Windows.Forms.Panel ControlBtns;
        private System.Windows.Forms.Label ChannelLbl;
        private System.Windows.Forms.Label VolumeLbl;
        private System.Windows.Forms.Button Ch_Up;
        private System.Windows.Forms.Button Ch_Down;
        private System.Windows.Forms.Button Vol_Up;
        private System.Windows.Forms.Button Vol_Down;
    }
}

