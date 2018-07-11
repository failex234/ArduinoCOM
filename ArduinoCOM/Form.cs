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

namespace ArduinoCOM
{
    public partial class Form : System.Windows.Forms.Form
    {

        private Boolean connected = false;
        private Boolean opensuccess = true;
        public Form()
        {
            InitializeComponent();
            tb_commands.KeyUp += new KeyEventHandler(tb_commands_KeyUp);
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            //Check all available COM Ports
            foreach (String portname in SerialPort.GetPortNames())
            {
                cb_ports.Items.Add(portname);
                String test = (String) cb_ports.SelectedValue;
            }

            //Only enable the connect button when at least one COM Port was detected
            if (SerialPort.GetPortNames().Length > 0)
            {
                cb_ports.Text = SerialPort.GetPortNames()[0];
            }
            else
            {
                btn_connect.Enabled = false;
            }

        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            port.Close();
            clear();
            log("[I] Trying to open COM Port " + cb_ports.Text + "...");

            //First just try to access the serial port
            port.PortName = cb_ports.Text;
            try
            {
                port.Open();
            }
            catch
            {
                opensuccess = false;
            }

            //If the connection succeeded try to send a command to the arduino
            if (opensuccess)
            {
                log("[I] Successfully opened Port!");
                log("[I] Trying to Connect to Arduino...");

                //Send a "CONNECT-" to the arduino. If you want to communicate with your arduino you NEED to let
                //the arduino respond to "CONNECT-" with "ACK".
                //Also set the timeout to half a second
                port.Write("CONNECT-");
                port.ReadTimeout = 500;
                String response;

                try
                {
                    response = port.ReadLine();
                    if (response.Equals("ACK\r")) connected = true;
                }
                catch
                {
                    //Nothing
                }

                //Enable all other control elements to finally send commands to the arduino
                //Disable the connect button and enable the disconnect button
                if (connected)
                {
                    log("[I] Connection established to Arduino!");
                    btn_connect.Enabled = false;
                    btn_disconnect.Enabled = true;
                    tb_commands.Enabled = true;
                }
                else
                {
                    log("[E] Unable to connect / communicate with the arduino \r\nPlease ensure that the arduino is connected and/or you flashed the correct sketch!");
                    port.Close();
                }
            }
            else
            {
                log("[E] Error while trying to open Port!");
                port.Close();
            }
        }
        
        //Prints messages to the "log". Basically just a multiline textbox
        private void log(String s)
        {

            tb_log.Text = tb_log.Text + s + "\r\n";
            tb_log.SelectionStart = tb_log.Text.Length;
            tb_log.ScrollToCaret();
        }

        //Clear the log
        private void clear()
        {
            tb_log.Clear();
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            //Send "DISC-" to arduino to let it know that we want to close
            //the connection then disable all other control elements
            //and reenable the connect button
            log("[I] Disconnecting from Arduino...");
            port.Write("DISC-");
            port.Close();
            btn_connect.Enabled = true;
            btn_disconnect.Enabled = false;
            tb_commands.Enabled = false;
        }

        //Simulate the send button press whenever the user pressed the return key
        //And also check whether the textbox is empty to enable or disable the send button
        private void tb_commands_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && tb_commands.Text != "")
            {
                String command = tb_commands.Text;
                log(command + ": " + sendCommand(command));
                tb_commands.Clear();
                btn_sendcmd.Enabled = false;
            }
            else
            {
                if (tb_commands.Text == "") btn_sendcmd.Enabled = false;
                else btn_sendcmd.Enabled = true;
            }
        }

        //Send the command with an added dash to the arduino
        private String sendCommand(String command)
        {
            port.Write(command + "-");
            String response = "";

            try
            {
                response = port.ReadLine();
            }
            catch
            {
                //Nothing
            }

            if (response == "")
            {
                return "No response";
            }
            else
            {
                return response;
            }
        }

        private void btn_sendcmd_Click(object sender, EventArgs e)
        {
            String command = tb_commands.Text;

            if (command == "")
            {
                log("[E] Missing command!");
                btn_sendcmd.Enabled = false;
            } else {
                log(command + ":" + sendCommand(command));
                tb_commands.Clear();
                btn_sendcmd.Enabled = false;
            }
        }
    }
}
