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
            this.pg = new System.Windows.Forms.Button();
            this.connectingBUTTON = new System.Windows.Forms.Button();
            this.serverPORT = new System.Windows.Forms.TextBox();
            this.MessageToSend = new System.Windows.Forms.TextBox();
            this.sendBUTTON = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.connectionStatusLABEL = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.serverIP = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // pg
            // 
            this.pg.BackColor = System.Drawing.Color.Black;
            this.pg.Enabled = false;
            this.pg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pg.Location = new System.Drawing.Point(369, 35);
            this.pg.Name = "pg";
            this.pg.Size = new System.Drawing.Size(21, 20);
            this.pg.TabIndex = 0;
            this.pg.UseVisualStyleBackColor = false;
            this.pg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mover);
            // 
            // connectingBUTTON
            // 
            this.connectingBUTTON.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.connectingBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.connectingBUTTON.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectingBUTTON.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.connectingBUTTON.Location = new System.Drawing.Point(281, 10);
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
            this.serverPORT.Location = new System.Drawing.Point(541, 36);
            this.serverPORT.Name = "serverPORT";
            this.serverPORT.Size = new System.Drawing.Size(49, 21);
            this.serverPORT.TabIndex = 5;
            this.serverPORT.Text = "9999";
            this.serverPORT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MessageToSend
            // 
            this.MessageToSend.Location = new System.Drawing.Point(12, 338);
            this.MessageToSend.Name = "MessageToSend";
            this.MessageToSend.Size = new System.Drawing.Size(578, 20);
            this.MessageToSend.TabIndex = 9;
            this.MessageToSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageToSend_KeyDown);
            // 
            // sendBUTTON
            // 
            this.sendBUTTON.BackColor = System.Drawing.Color.CadetBlue;
            this.sendBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sendBUTTON.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendBUTTON.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sendBUTTON.Location = new System.Drawing.Point(12, 364);
            this.sendBUTTON.Name = "sendBUTTON";
            this.sendBUTTON.Size = new System.Drawing.Size(578, 23);
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
            this.richTextBox1.Location = new System.Drawing.Point(12, 62);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(578, 270);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(281, 38);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Move mode";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.connectionStatusLABEL.AutoSize = true;
            this.connectionStatusLABEL.ForeColor = System.Drawing.Color.Red;
            this.connectionStatusLABEL.Location = new System.Drawing.Point(12, 39);
            this.connectionStatusLABEL.Name = "label1";
            this.connectionStatusLABEL.Size = new System.Drawing.Size(78, 13);
            this.connectionStatusLABEL.TabIndex = 15;
            this.connectionStatusLABEL.Text = "Not connected";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(12, 14);
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
            this.serverIP.Location = new System.Drawing.Point(396, 35);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(139, 24);
            this.serverIP.TabIndex = 17;
            this.serverIP.Text = "25.108.14.68";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(602, 397);
            this.Controls.Add(this.serverIP);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.connectionStatusLABEL);
            this.Controls.Add(this.connectingBUTTON);
            this.Controls.Add(this.serverPORT);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.sendBUTTON);
            this.Controls.Add(this.MessageToSend);
            this.Controls.Add(this.pg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "miniGame";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pg;
        private System.Windows.Forms.Button connectingBUTTON;
        private System.Windows.Forms.TextBox serverPORT;
        private System.Windows.Forms.TextBox MessageToSend;
        private System.Windows.Forms.Button sendBUTTON;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label connectionStatusLABEL;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ComboBox serverIP;
    }
}

