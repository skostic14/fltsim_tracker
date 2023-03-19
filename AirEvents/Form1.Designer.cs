namespace AirEvents
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            simStatus = new Label();
            flightStatus = new Label();
            connectSimBtn = new Button();
            startFlightBtn = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // simStatus
            // 
            simStatus.AutoSize = true;
            simStatus.Location = new Point(251, 32);
            simStatus.Name = "simStatus";
            simStatus.Size = new Size(38, 15);
            simStatus.TabIndex = 0;
            simStatus.Text = "label1";
            // 
            // flightStatus
            // 
            flightStatus.AutoSize = true;
            flightStatus.Location = new Point(251, 64);
            flightStatus.Name = "flightStatus";
            flightStatus.Size = new Size(38, 15);
            flightStatus.TabIndex = 1;
            flightStatus.Text = "label2";
            // 
            // connectSimBtn
            // 
            connectSimBtn.Location = new Point(83, 28);
            connectSimBtn.Name = "connectSimBtn";
            connectSimBtn.Size = new Size(107, 23);
            connectSimBtn.TabIndex = 2;
            connectSimBtn.Text = "Connect Sim";
            connectSimBtn.UseVisualStyleBackColor = true;
            connectSimBtn.Click += simConnectBtn_Click;
            // 
            // startFlightBtn
            // 
            startFlightBtn.Location = new Point(83, 64);
            startFlightBtn.Name = "startFlightBtn";
            startFlightBtn.Size = new Size(107, 23);
            startFlightBtn.TabIndex = 3;
            startFlightBtn.Text = "Start Flight";
            startFlightBtn.UseVisualStyleBackColor = true;
            startFlightBtn.Click += startFlightBtn_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(startFlightBtn);
            Controls.Add(connectSimBtn);
            Controls.Add(flightStatus);
            Controls.Add(simStatus);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label simStatus;
        private Label flightStatus;
        private Button connectSimBtn;
        private Button startFlightBtn;
        private System.Windows.Forms.Timer timer1;




    }
}