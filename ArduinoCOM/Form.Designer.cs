namespace ArduinoCOM
{
    partial class Form
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.port = new System.IO.Ports.SerialPort(this.components);
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.cb_ports = new System.Windows.Forms.ComboBox();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.lbl_select = new System.Windows.Forms.Label();
            this.tb_commands = new System.Windows.Forms.TextBox();
            this.btn_sendcmd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(198, 12);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(166, 36);
            this.btn_connect.TabIndex = 1;
            this.btn_connect.Text = "Connecz";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Enabled = false;
            this.btn_disconnect.Location = new System.Drawing.Point(198, 67);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(166, 36);
            this.btn_disconnect.TabIndex = 2;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // cb_ports
            // 
            this.cb_ports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ports.FormattingEnabled = true;
            this.cb_ports.Location = new System.Drawing.Point(12, 27);
            this.cb_ports.Name = "cb_ports";
            this.cb_ports.Size = new System.Drawing.Size(180, 21);
            this.cb_ports.TabIndex = 4;
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(12, 118);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.ReadOnly = true;
            this.tb_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_log.Size = new System.Drawing.Size(352, 174);
            this.tb_log.TabIndex = 5;
            // 
            // lbl_select
            // 
            this.lbl_select.AutoSize = true;
            this.lbl_select.Location = new System.Drawing.Point(45, 9);
            this.lbl_select.Name = "lbl_select";
            this.lbl_select.Size = new System.Drawing.Size(107, 13);
            this.lbl_select.TabIndex = 6;
            this.lbl_select.Text = "Select COM Port";
            // 
            // tb_commands
            // 
            this.tb_commands.Enabled = false;
            this.tb_commands.Location = new System.Drawing.Point(13, 299);
            this.tb_commands.Name = "tb_commands";
            this.tb_commands.Size = new System.Drawing.Size(351, 20);
            this.tb_commands.TabIndex = 7;
            // 
            // btn_sendcmd
            // 
            this.btn_sendcmd.Enabled = false;
            this.btn_sendcmd.Location = new System.Drawing.Point(13, 326);
            this.btn_sendcmd.Name = "btn_sendcmd";
            this.btn_sendcmd.Size = new System.Drawing.Size(351, 23);
            this.btn_sendcmd.TabIndex = 8;
            this.btn_sendcmd.Text = "Send";
            this.btn_sendcmd.UseVisualStyleBackColor = true;
            this.btn_sendcmd.Click += new System.EventHandler(this.btn_sendcmd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 361);
            this.Controls.Add(this.btn_sendcmd);
            this.Controls.Add(this.tb_commands);
            this.Controls.Add(this.lbl_select);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.cb_ports);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.btn_connect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ArduinoCOM";
            this.Text = "ArduinoCOM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort port;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.ComboBox cb_ports;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.Label lbl_select;
        private System.Windows.Forms.TextBox tb_commands;
        private System.Windows.Forms.Button btn_sendcmd;
    }
}

