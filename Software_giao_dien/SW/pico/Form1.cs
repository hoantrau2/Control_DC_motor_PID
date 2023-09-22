using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.IO;
using System.Xml;

namespace pico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double time = 0;
        double speed;
        double setpoint = 100;
        const int BUFFER_SIZE = 34;
        byte[] txbuff = new byte[BUFFER_SIZE]; // 1 byte == 8 bit unsigned integer
        /* Transfer data buffer txbuff[] */
        // 0   | 1      | 2 - 9     | 10 - 17  | 18 - 25   | 26 - 33  | 
        // dir | PID    | Setpoint  | Kp       | Ki        | Kd       | 
        /// <Explanation>
        /// - dir = 1, forward; dir = 0, reverse
        /// - PID = 1, update PID; PID = 0, none PID
        /// - Kp, Ki, Kd, setpoint are all double variables [double -- 64 bits -- 8 bytes]       
        /// </summary>
        private void btconnect_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serialPort1.Open();
            }

            btconnect.Enabled = false;
            btdisconnect.Enabled = true;
            timer1.Enabled = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Control.CheckForIllegalCrossThreadCalls = false;
            comboBox1.DataSource = SerialPort.GetPortNames();
            //serialPort1.PortName = "COM7";
            //serialPort1.BaudRate = 9600;
            //serialPort1.DataBits = 8;
            //serialPort1.Parity = System.IO.Ports.Parity.None;
            //serialPort1.StopBits = System.IO.Ports.StopBits.One;


            graph_Init();
        }
        string rcv_data;
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            rcv_data = "";
            rcv_data = serialPort1.ReadLine();
            serialPort1.DiscardInBuffer();
            txtspeed.Text = rcv_data;


            speed = double.Parse(rcv_data);
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btdisconnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            serialPort1.RtsEnable = true;
            serialPort1.DtrEnable = true;

            timer1.Enabled = true;
            btconnect.Enabled = true;
            btdisconnect.Enabled = false;
            timer1.Enabled = false;
            txtKd.Text = String.Empty;
            txtKi.Text = String.Empty;
            txtKp.Text = String.Empty;
            txtsetpoint.Text = String.Empty;
            txtspeed.Text = String.Empty;

            resetGraph();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            time += timer1.Interval; // update time elapsed
            GraphPane pane = zedGraphControl1.GraphPane;
            LineItem curve_1 = pane.CurveList[0] as LineItem;
            LineItem curve_2 = pane.CurveList[1] as LineItem;

            IPointListEdit List_1 = curve_1.Points as IPointListEdit;
            IPointListEdit List_2 = curve_2.Points as IPointListEdit;

            List_1.Add(time, speed); // add the new point 
            List_2.Add(time, setpoint);

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btsend_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = true;
                setpoint = double.Parse(txtsetpoint.Text);


                if (checkBox1.Checked) txbuff[0] = (byte)'1';
                else txbuff[0] = (byte)'0';
                if (checkBox4.Checked) txbuff[1] = (byte)'1';
                else txbuff[1] = (byte)'0';


                /*--------- Setpoint ---------*/
                byte[] setPoint = new byte[8];
                byte[] tmpSP = Encoding.ASCII.GetBytes(txtsetpoint.Text);
                for (int i = 0; i < tmpSP.Length; i++)
                    setPoint[i] = tmpSP[i];
                Array.Copy(setPoint, 0, txbuff, 2, 8);
                /*--------- Kp ---------*/
                byte[] kp = new byte[8];
                byte[] tmpKP = Encoding.ASCII.GetBytes(txtKp.Text);
                for (int i = 0; i < tmpKP.Length; i++)
                    kp[i] = tmpKP[i];
                Array.Copy(kp, 0, txbuff, 10, 8);

                /*--------- Ki ---------*/
                byte[] ki = new byte[8];
                byte[] tmpKI = Encoding.ASCII.GetBytes(txtKi.Text);
                for (int i = 0; i < tmpKI.Length; i++)
                    ki[i] = tmpKI[i];
                Array.Copy(ki, 0, txbuff, 18, 8);

                /*--------- Kd ---------*/
                byte[] kd = new byte[8];
                byte[] tmpKD = Encoding.ASCII.GetBytes(txtKd.Text);
                for (int i = 0; i < tmpKD.Length; i++)
                    kd[i] = tmpKD[i];
                Array.Copy(kd, 0, txbuff, 26, 8);
                //  serialPort1.Write(txbuff, 0, BUFFER_SIZE);
                serialPort1.Write("S");
                serialPort1.Write(txbuff, 0, txbuff.Length);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void stopmotor_Click(object sender, EventArgs e)
        {
            for (int i = 2; i < 10; i++)
                txbuff[i] = (byte)'0';
            //  timer1.Enabled = false;
            serialPort1.Write("S");
            serialPort1.Write(txbuff, 0, txbuff.Length);

        }

        private void graph_Init()
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.Title.Text = "Đồ thị đáp ứng";
            pane.XAxis.Title.Text = "Thời gian (ms)";
            pane.YAxis.Title.Text = "Vận tốc (rpm)";

            RollingPointPairList speed_motor = new RollingPointPairList(20000);
            RollingPointPairList setpoint_motor = new RollingPointPairList(20000);
            LineItem curve_1 = pane.AddCurve("speed", speed_motor, Color.Blue, SymbolType.None);
            LineItem curve_2 = pane.AddCurve("setpoint", setpoint_motor, Color.Red, SymbolType.None);
            
        }

        private void resetGraph()
        {
            // Voi zedgraph, khi xoa di thi phai khai bao lai, neu khong se khong hien thi do thi
            zedGraphControl1.GraphPane.CurveList.Clear();       // Xoa moi duong cong
            zedGraphControl1.GraphPane.GraphObjList.Clear();    // xoa moi doi tuong 
            zedGraphControl1.Invalidate();
            

            // khai bao lai...         
            graph_Init();
            time = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Write("S");
        }
    }
}
