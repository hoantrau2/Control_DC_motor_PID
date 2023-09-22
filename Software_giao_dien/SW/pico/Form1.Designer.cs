namespace pico
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btconnect = new System.Windows.Forms.Button();
            this.txtspeed = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btdisconnect = new System.Windows.Forms.Button();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKp = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsetpoint = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btsend = new System.Windows.Forms.Button();
            this.btstopmotor = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btconnect
            // 
            this.btconnect.Location = new System.Drawing.Point(32, 35);
            this.btconnect.Name = "btconnect";
            this.btconnect.Size = new System.Drawing.Size(93, 38);
            this.btconnect.TabIndex = 1;
            this.btconnect.Text = "Connect";
            this.btconnect.UseVisualStyleBackColor = true;
            this.btconnect.Click += new System.EventHandler(this.btconnect_Click);
            // 
            // txtspeed
            // 
            this.txtspeed.Location = new System.Drawing.Point(9, 27);
            this.txtspeed.Multiline = true;
            this.txtspeed.Name = "txtspeed";
            this.txtspeed.Size = new System.Drawing.Size(131, 31);
            this.txtspeed.TabIndex = 2;
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.DtrEnable = true;
            this.serialPort1.PortName = "COM3";
            this.serialPort1.RtsEnable = true;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Speed (rpm)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btdisconnect
            // 
            this.btdisconnect.Location = new System.Drawing.Point(32, 79);
            this.btdisconnect.Name = "btdisconnect";
            this.btdisconnect.Size = new System.Drawing.Size(93, 37);
            this.btdisconnect.TabIndex = 4;
            this.btdisconnect.Text = "Disconnect";
            this.btdisconnect.UseVisualStyleBackColor = true;
            this.btdisconnect.Click += new System.EventHandler(this.btdisconnect_Click);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(497, 3);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1245, 636);
            this.zedGraphControl1.TabIndex = 5;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtsetpoint);
            this.groupBox1.Location = new System.Drawing.Point(32, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 196);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.txtKd);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtKi);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.txtKp);
            this.groupBox5.Location = new System.Drawing.Point(277, 21);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(165, 169);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "PID parameter";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Kd";
            // 
            // txtKd
            // 
            this.txtKd.Location = new System.Drawing.Point(34, 127);
            this.txtKd.Multiline = true;
            this.txtKd.Name = "txtKd";
            this.txtKd.Size = new System.Drawing.Size(100, 31);
            this.txtKd.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ki";
            // 
            // txtKi
            // 
            this.txtKi.Location = new System.Drawing.Point(34, 79);
            this.txtKi.Multiline = true;
            this.txtKi.Name = "txtKi";
            this.txtKi.Size = new System.Drawing.Size(100, 31);
            this.txtKi.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Kp";
            // 
            // txtKp
            // 
            this.txtKp.Location = new System.Drawing.Point(35, 31);
            this.txtKp.Multiline = true;
            this.txtKp.Name = "txtKp";
            this.txtKp.Size = new System.Drawing.Size(100, 31);
            this.txtKp.TabIndex = 8;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox4);
            this.groupBox4.Location = new System.Drawing.Point(149, 90);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(113, 77);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Yes or No PID";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(6, 43);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(53, 20);
            this.checkBox4.TabIndex = 8;
            this.checkBox4.Text = "Yes";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Location = new System.Drawing.Point(6, 90);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(113, 77);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Direction of rotation";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 43);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 20);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Forward";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Setpoint (rpm)";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtsetpoint
            // 
            this.txtsetpoint.Location = new System.Drawing.Point(135, 33);
            this.txtsetpoint.Multiline = true;
            this.txtsetpoint.Name = "txtsetpoint";
            this.txtsetpoint.Size = new System.Drawing.Size(100, 31);
            this.txtsetpoint.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtspeed);
            this.groupBox2.Location = new System.Drawing.Point(309, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 99);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // btsend
            // 
            this.btsend.Location = new System.Drawing.Point(167, 35);
            this.btsend.Name = "btsend";
            this.btsend.Size = new System.Drawing.Size(93, 38);
            this.btsend.TabIndex = 9;
            this.btsend.Text = "Send";
            this.btsend.UseVisualStyleBackColor = true;
            this.btsend.Click += new System.EventHandler(this.btsend_Click);
            // 
            // btstopmotor
            // 
            this.btstopmotor.Location = new System.Drawing.Point(167, 79);
            this.btstopmotor.Name = "btstopmotor";
            this.btstopmotor.Size = new System.Drawing.Size(93, 38);
            this.btstopmotor.TabIndex = 10;
            this.btstopmotor.Text = "Stop motor";
            this.btstopmotor.UseVisualStyleBackColor = true;
            this.btstopmotor.Click += new System.EventHandler(this.stopmotor_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(209, 364);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 405);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(16, 32);
            this.button1.TabIndex = 12;
            this.button1.Text = "S";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1755, 652);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btstopmotor);
            this.Controls.Add(this.btsend);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.btdisconnect);
            this.Controls.Add(this.btconnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btconnect;
        private System.Windows.Forms.TextBox txtspeed;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btdisconnect;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsetpoint;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btsend;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKp;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btstopmotor;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
    }
}

