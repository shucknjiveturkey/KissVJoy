using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using vJoyInterfaceWrap;

namespace MultiWiiVJoy
{
    public partial class Form1 : Form
    {
        private Serial serial = new Serial();
        private VirtualJoystick vJoy = new VirtualJoystick();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serial.Connected += new Serial.ConnectedHandler(serial_Connected);
            serial.Disconnected += new Serial.DisconnectedHandler(serial_Disconnected);
            serial.DataReceived += new Serial.DataReceivedHandler(serial_DataReceived);
            serial.Error += new Serial.ErrorHandler(serial_Error);

            vJoy.Success += new VirtualJoystick.SuccessHandler(vJoy_Success);
            vJoy.Error += new VirtualJoystick.ErrorHandler(vJoy_Error);

            serial.Init();
            vJoy.Init();

            fillCbxPortNames();
            if (cbxPortNames.Items.Count > 0)
            {
                cbxPortNames.SelectedIndex = 0;
            }

            cbxBaudRate.SelectedIndex = 3;
            cbxInterval.SelectedIndex = 0;
        }

        void vJoy_Error(object sender, ErrorArgs e)
        {
            panelVJoy.BackColor = Color.OrangeRed;
            MessageBox.Show(e.Error);
        }

        void vJoy_Success(object sender)
        {
            panelVJoy.BackColor = Color.GreenYellow;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            serial.PortName = (cbxPortNames.SelectedItem == null) ? "" : cbxPortNames.SelectedItem.ToString();
            serial.BaudRate = Convert.ToInt32(cbxBaudRate.SelectedItem.ToString());
            serial.Connect();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            serial.Disconnect();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            fillCbxPortNames();
        }

        private void fillCbxPortNames()
        {
            cbxPortNames.Items.Clear();
            cbxPortNames.Items.AddRange(serial.PortNames);
        }

        void serial_Error(object sender, ErrorArgs e)
        {
            MessageBox.Show(e.Error);
        }

        private static short toInt16(byte[] value, int startIndex)
        {
            return (short)(value[startIndex] << 8 | value[startIndex + 1]);
        }

        public static int convertRange(
            int originalStart, int originalEnd, // original range
            int newStart, int newEnd, // desired range
            int value) // value to convert
        {
            double scale = (double)(newEnd - newStart) / (originalEnd - originalStart);
            return (int)(newStart + ((value - originalStart) * scale));
        }

        // calculateDegSec: input: -1000 to 1000, rate: 1.25, grate: 0.7, usecurve: 0.04
        // output 833.33 to -833.33
        public static double calculateDegSec(int input, double rate, double grate, double usecurve)
        {
            double setpoint = Convert.ToDouble(input) / 1000;
            double RPY_useRates = 1 - Math.Abs(setpoint) * grate;
            double rxRAW = Convert.ToDouble(input);
            double curve = rxRAW * rxRAW / 1000000;
            setpoint = ((setpoint * curve) * usecurve + setpoint * (1 - usecurve)) * (rate / 10);
            double tmp = ((2000 * (1 / RPY_useRates)) * setpoint) * 100;
            return (double)Math.Round(tmp) / 100;
        }

        void serial_DataReceived(object sender, DataReceivedArgs e)
        {
            if (e.Data.Length < 16)
            {
                return;
            }

            int throttle = toInt16(e.Data, 2);
            int roll = toInt16(e.Data, 4);
            int pitch = toInt16(e.Data, 6);
            int yaw = toInt16(e.Data, 8);

            bool ratesEnabled = true;
            if (ratesEnabled)
            {
                roll = convertRange(-1110, 1110, -1000, 1000, (int)calculateDegSec(roll, 1.11, 0.8, 0.04));
                pitch = convertRange(-1110, 1110, -1000, 1000, (int)calculateDegSec(pitch, 1.11, 0.8, 0.04));
                yaw = convertRange(-833, 833, -1000, 1000, (int)calculateDegSec(yaw, 1.25, 0.7, 0.04));
            }

            displayRcValueThrottle.Value = throttle;
            displayRcValueYaw.Value = yaw;
            displayRcValuePitch.Value = pitch;
            displayRcValueRoll.Value = roll;

            throttle = convertRange(0, 1000, 1, 32768, throttle);
            roll = convertRange(-1000, 1000, 1, 32768, roll);
            pitch = convertRange(-1000, 1000, 1, 32768, pitch);
            yaw = convertRange(-1000, 1000, 1, 32768, yaw);

            // VJoy Axis value is an integer in the range of 1-32767.
            vJoy.SetAxis(throttle, HID_USAGES.HID_USAGE_RX);
            vJoy.SetAxis(yaw, HID_USAGES.HID_USAGE_X);

            vJoy.SetAxis(roll, HID_USAGES.HID_USAGE_RY);
            vJoy.SetAxis(pitch, HID_USAGES.HID_USAGE_Y);
        }

        void serial_Disconnected(object sender)
        {
            btnConnect.Visible = true;
            btnDisconnect.Visible = false;
            timerRc.Enabled = false;
        }

        void serial_Connected(object sender)
        {
            btnConnect.Visible = false;
            btnDisconnect.Visible = true;
            timerRc.Enabled = true;
        }

        private void timerRc_Tick(object sender, EventArgs e)
        {
            byte[] data = new byte[8];
            data[0] = Convert.ToByte(32);
            serial.Write(data);
        }

        private void setTextBox(TextBox textBox, string text)
        {
            if (textBox.InvokeRequired)
            {
                textBox.Invoke((MethodInvoker)delegate { textBox.Text = text; });
            }
            else
            {
                textBox.Text = text;
            }
        }

        private void setProgressBar(ProgressBar progressBar, int value)
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke((MethodInvoker)delegate { progressBar.Value = value; });
            }
            else
            {
                progressBar.Value = value;
            }
        }

        private void cbxInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerRc.Interval = Convert.ToInt32(cbxInterval.SelectedItem);
        }

        private void displayRcValueThrottle_Load(object sender, EventArgs e)
        {

        }
    }
}
