using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace HandGestureMouseControl
{
    public partial class Form1 : Form
    {
        private SerialPort myport;
        private string in_data;
        private Boolean IsStart = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            string[] unique_ports = ports.Distinct().ToArray();
            myport = new SerialPort();
            myport.BaudRate = 9600;
            myport.PortName = unique_ports[0];
            myport.Parity = Parity.None;
            myport.DataBits = 8;
            myport.StopBits = StopBits.One;
            myport.DataReceived += Myport_DataReceived;
            timer1.Start();

            try
            {
                myport.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            foreach (string port_name in unique_ports)
            {
                portBox.Items.Add(port_name);
            }

        }

        private void Myport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            in_data = myport.ReadLine();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsStart)
            {
                string[] ACC = in_data.Split(',');
                ACCX.Text = ACC[0];
                ACCY.Text = ACC[1];
                Cursor.Position = new System.Drawing.Point(Cursor.Position.X + Convert.ToInt32(ACC[0]), Cursor.Position.Y + Convert.ToInt32(ACC[1]));
            }
        }

        private void StartBTN_Click(object sender, EventArgs e)
        {
            IsStart = true;
            //myport.PortName = portBox.GetItemText(portBox.SelectedItem); => I want to use combobox to choose comport
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == (Keys.Control | Keys.Z) || keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
