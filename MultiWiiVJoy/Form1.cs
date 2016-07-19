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
        private const int Roll = 0;
        private const int Pitch = 1;
        private const int Yaw = 2;

        // KissFC settings.
        private bool settingsAcquired = false;
        private int[] rate = new int[3];
        private double[] rcRate = new double[3];
        private double[] expo = new double[3];
        private double[] curve = new double[3];

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
            settingsAcquired = false;
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
            return (short) (value[startIndex] << 8 | value[startIndex + 1]);
        }

        public static int convertRange(int originalStart, int originalEnd, int newStart, int newEnd, int value)
        {
            double scale = (double) (newEnd - newStart)/(originalEnd - originalStart);
            return (int) (newStart + ((value - originalStart)*scale));
        }

        public static double calculateDegSec(int input, double rate, double grate, double usecurve)
        {
            double setpoint = Convert.ToDouble(input)/1000;
            double rpyUseRates = 1 - Math.Abs(setpoint)*grate;
            double rxRaw = Convert.ToDouble(input);
            double curve = rxRaw*rxRaw/1000000;
            setpoint = ((setpoint*curve)*usecurve + setpoint*(1 - usecurve))*(rate/10);
            double tmp = ((2000*(1/rpyUseRates))*setpoint)*100;
            return (double) Math.Round(tmp)/100;
        }

        void serial_DataReceived(object sender, DataReceivedArgs e)
        {
            // There's probably a better way to check for valid data...
            if (e.Data.Length < 16)
            {
                return;
            }

            // Get RC rate, expo and curve.
            if (!settingsAcquired)
            {
                rcRate[Roll] = (double) toInt16(e.Data, 30)/1000;
                rcRate[Pitch] = (double) toInt16(e.Data, 32)/1000;
                rcRate[Yaw] = (double) toInt16(e.Data, 34)/1000;
                expo[Roll] = (double) toInt16(e.Data, 36)/1000;
                expo[Pitch] = (double) toInt16(e.Data, 38)/1000;
                expo[Yaw] = (double) toInt16(e.Data, 40)/1000;
                curve[Roll] = (double) toInt16(e.Data, 42)/1000;
                curve[Pitch] = (double) toInt16(e.Data, 44)/1000;
                curve[Yaw] = (double) toInt16(e.Data, 46)/1000;

                // Output KissFC Rates.
                rate[Roll] = (int) calculateDegSec(1000, rcRate[Roll], expo[Roll], curve[Roll]);
                rate[Pitch] = (int) calculateDegSec(1000, rcRate[Pitch], expo[Pitch], curve[Pitch]);
                rate[Yaw] = (int) calculateDegSec(1000, rcRate[Yaw], expo[Yaw], curve[Yaw]);
                setControlText(lblRateRoll, rate[Roll].ToString());
                setControlText(lblRatePitch, rate[Pitch].ToString());
                setControlText(lblRateYaw, rate[Yaw].ToString());

                settingsAcquired = true;
            }

            // Get RAW axis values from KissFC.
            int throttleValue = toInt16(e.Data, 2);
            int rollValue = toInt16(e.Data, 4);
            int pitchValue = toInt16(e.Data, 6);
            int yawValue = toInt16(e.Data, 8);

            // Apply KissFC rates/expo.
            if (chkExpoFC.Checked)
            {
                rollValue = convertRange(-rate[Roll], rate[Roll], -1000, 1000,
                    (int) calculateDegSec(rollValue, rcRate[Roll], expo[Roll], curve[Roll]));
                pitchValue = convertRange(-rate[Pitch], rate[Pitch], -1000, 1000,
                    (int) calculateDegSec(pitchValue, rcRate[Pitch], expo[Pitch], curve[Pitch]));
                yawValue = convertRange(-rate[Yaw], rate[Yaw], -1000, 1000,
                    (int) calculateDegSec(yawValue, rcRate[Yaw], expo[Yaw], curve[Yaw]));
            }

            // Reverse.
            if (cbxThrottle.Checked)
            {
                throttleValue = throttleValue*-1;
            }

            if (cbxRoll.Checked)
            {
                rollValue = rollValue*-1;
            }

            if (cbxPitch.Checked)
            {
                pitchValue = pitchValue*-1;
            }

            if (cbxYaw.Checked)
            {
                yawValue = yawValue*-1;
            }

            // Update UI.
            displayRcValueThrottle.Value = throttleValue;
            displayRcValueYaw.Value = yawValue;
            displayRcValuePitch.Value = pitchValue;
            displayRcValueRoll.Value = rollValue;

            // Convert to vJoy range (1-32767).
            throttleValue = convertRange(0, 1000, 1, 32767, throttleValue);
            rollValue = convertRange(-1000, 1000, 1, 32767, rollValue);
            pitchValue = convertRange(-1000, 1000, 1, 32767, pitchValue);
            yawValue = convertRange(-1000, 1000, 1, 32767, yawValue);

            // Send values to vJoy.
            vJoy.SetAxis(throttleValue, HID_USAGES.HID_USAGE_Y);
            vJoy.SetAxis(yawValue, HID_USAGES.HID_USAGE_X);

            vJoy.SetAxis(rollValue, HID_USAGES.HID_USAGE_RX);
            vJoy.SetAxis(pitchValue, HID_USAGES.HID_USAGE_RY);
        }

        void serial_Disconnected(object sender)
        {
            btnConnect.Visible = true;
            btnDisconnect.Visible = false;
            timerRc.Enabled = false;
            lblRateRoll.Text = "0";
            lblRatePitch.Text = "0";
            lblRateYaw.Text = "0";
        }

        void serial_Connected(object sender)
        {
            // Get Settings.
            byte[] data = new byte[8];
            data[0] = Convert.ToByte(48);
            serial.Write(data);

            btnConnect.Visible = false;
            btnDisconnect.Visible = true;
            timerRc.Enabled = true;
        }

        private void timerRc_Tick(object sender, EventArgs e)
        {
            // Get Telemetry.
            byte[] data = new byte[8];
            data[0] = Convert.ToByte(32);
            serial.Write(data);
        }

        private void setControlText(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                control.Invoke((MethodInvoker) delegate { control.Text = text; });
            }
            else
            {
                control.Text = text;
            }
        }

        private void cbxInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerRc.Interval = Convert.ToInt32(cbxInterval.SelectedItem);
        }
    }
}