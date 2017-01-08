namespace miniGame
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.playerC = new System.Windows.Forms.Button();
            this.connectingBUTTON = new System.Windows.Forms.Button();
            this.serverPORT = new System.Windows.Forms.TextBox();
            this.MessageToSend = new System.Windows.Forms.TextBox();
            this.sendBUTTON = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.moveCheckbox = new System.Windows.Forms.CheckBox();
            this.connectionStatusLABEL = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.serverIP = new System.Windows.Forms.ComboBox();
            this.map = new System.Windows.Forms.Panel();
            this.playerH = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.coordinates = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.map.SuspendLayout();
            this.SuspendLayout();
            // 
            // playerC
            // 
            this.playerC.BackColor = System.Drawing.Color.Black;
            this.playerC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playerC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.playerC.Location = new System.Drawing.Point(225, 175);
            this.playerC.Name = "playerC";
            this.playerC.Size = new System.Drawing.Size(24, 24);
            this.playerC.TabIndex = 0;
            this.playerC.Text = "C";
            this.playerC.UseVisualStyleBackColor = false;
            this.playerC.Click += new System.EventHandler(this.playerC_Click);
            this.playerC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mover);
            // 
            // connectingBUTTON
            // 
            this.connectingBUTTON.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.connectingBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.connectingBUTTON.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectingBUTTON.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.connectingBUTTON.Location = new System.Drawing.Point(679, 9);
            this.connectingBUTTON.Name = "connectingBUTTON";
            this.connectingBUTTON.Size = new System.Drawing.Size(309, 21);
            this.connectingBUTTON.TabIndex = 1;
            this.connectingBUTTON.Text = "CONNECT";
            this.connectingBUTTON.UseVisualStyleBackColor = false;
            this.connectingBUTTON.Click += new System.EventHandler(this.connectingBUTTON_Click);
            // 
            // serverPORT
            // 
            this.serverPORT.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverPORT.Location = new System.Drawing.Point(939, 35);
            this.serverPORT.Name = "serverPORT";
            this.serverPORT.Size = new System.Drawing.Size(49, 21);
            this.serverPORT.TabIndex = 5;
            this.serverPORT.Text = "9999";
            this.serverPORT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MessageToSend
            // 
            this.MessageToSend.Location = new System.Drawing.Point(527, 339);
            this.MessageToSend.Name = "MessageToSend";
            this.MessageToSend.Size = new System.Drawing.Size(461, 20);
            this.MessageToSend.TabIndex = 9;
            this.MessageToSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageToSend_KeyDown);
            // 
            // sendBUTTON
            // 
            this.sendBUTTON.BackColor = System.Drawing.Color.CadetBlue;
            this.sendBUTTON.Enabled = false;
            this.sendBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sendBUTTON.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendBUTTON.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sendBUTTON.Location = new System.Drawing.Point(527, 365);
            this.sendBUTTON.Name = "sendBUTTON";
            this.sendBUTTON.Size = new System.Drawing.Size(461, 23);
            this.sendBUTTON.TabIndex = 10;
            this.sendBUTTON.Text = "SEND";
            this.sendBUTTON.UseVisualStyleBackColor = false;
            this.sendBUTTON.Click += new System.EventHandler(this.sendBUTTON_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Lime;
            this.richTextBox1.Location = new System.Drawing.Point(527, 61);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(461, 272);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "";
            // 
            // moveCheckbox
            // 
            this.moveCheckbox.AutoSize = true;
            this.moveCheckbox.Enabled = false;
            this.moveCheckbox.Location = new System.Drawing.Point(679, 37);
            this.moveCheckbox.Name = "moveCheckbox";
            this.moveCheckbox.Size = new System.Drawing.Size(82, 17);
            this.moveCheckbox.TabIndex = 12;
            this.moveCheckbox.Text = "Move mode";
            this.moveCheckbox.UseVisualStyleBackColor = true;
            this.moveCheckbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // connectionStatusLABEL
            // 
            this.connectionStatusLABEL.AutoSize = true;
            this.connectionStatusLABEL.ForeColor = System.Drawing.Color.Red;
            this.connectionStatusLABEL.Location = new System.Drawing.Point(529, 38);
            this.connectionStatusLABEL.Name = "connectionStatusLABEL";
            this.connectionStatusLABEL.Size = new System.Drawing.Size(78, 13);
            this.connectionStatusLABEL.TabIndex = 15;
            this.connectionStatusLABEL.Text = "Not connected";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(529, 13);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(48, 17);
            this.checkBox2.TabIndex = 16;
            this.checkBox2.Text = "Host";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // serverIP
            // 
            this.serverIP.BackColor = System.Drawing.SystemColors.Window;
            this.serverIP.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverIP.FormattingEnabled = true;
            this.serverIP.Items.AddRange(new object[] {
            "25.108.14.68",
            "25.108.14.186",
            "127.0.0.1"});
            this.serverIP.Location = new System.Drawing.Point(794, 34);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(139, 24);
            this.serverIP.TabIndex = 17;
            this.serverIP.Text = "25.108.14.68";
            // 
            // map
            // 
            this.map.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.map.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.map.Controls.Add(this.playerH);
            this.map.Controls.Add(this.playerC);
            this.map.ForeColor = System.Drawing.SystemColors.ControlText;
            this.map.Location = new System.Drawing.Point(12, 13);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(510, 375);
            this.map.TabIndex = 18;
            this.map.Click += new System.EventHandler(this.map_Click);
            // 
            // playerH
            // 
            this.playerH.BackColor = System.Drawing.Color.Black;
            this.playerH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playerH.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.playerH.Location = new System.Drawing.Point(255, 175);
            this.playerH.Name = "playerH";
            this.playerH.Size = new System.Drawing.Size(24, 24);
            this.playerH.TabIndex = 1;
            this.playerH.Text = "H";
            this.playerH.UseVisualStyleBackColor = false;
            this.playerH.Click += new System.EventHandler(this.playerH_Click);
            this.playerH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "C = Client // H = Host";
            // 
            // coordinates
            // 
            this.coordinates.AutoSize = true;
            this.coordinates.Location = new System.Drawing.Point(438, 392);
            this.coordinates.Name = "coordinates";
            this.coordinates.Size = new System.Drawing.Size(0, 13);
            this.coordinates.TabIndex = 20;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 150;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 409);
            this.Controls.Add(this.coordinates);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.map);
            this.Controls.Add(this.serverIP);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.connectionStatusLABEL);
            this.Controls.Add(this.connectingBUTTON);
            this.Controls.Add(this.serverPORT);
            this.Controls.Add(this.moveCheckbox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.sendBUTTON);
            this.Controls.Add(this.MessageToSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "miniGame";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.map.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playerC;
        private System.Windows.Forms.Button connectingBUTTON;
        private System.Windows.Forms.TextBox serverPORT;
        private System.Windows.Forms.TextBox MessageToSend;
        private System.Windows.Forms.Button sendBUTTON;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox moveCheckbox;
        private System.Windows.Forms.Label connectionStatusLABEL;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ComboBox serverIP;
        private System.Windows.Forms.Panel map;
        private System.Windows.Forms.Button playerH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label coordinates;
        private System.Windows.Forms.Timer timer1;
    }
}

