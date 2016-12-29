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
            this.serverIP = new System.Windows.Forms.TextBox();
            this.serverPORT = new System.Windows.Forms.TextBox();
            this.MessageToSend = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // pg
            // 
            this.pg.BackColor = System.Drawing.Color.Black;
            this.pg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pg.Location = new System.Drawing.Point(414, 236);
            this.pg.Name = "pg";
            this.pg.Size = new System.Drawing.Size(15, 15);
            this.pg.TabIndex = 0;
            this.pg.UseVisualStyleBackColor = false;
            this.pg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mover);
            // 
            // connectingBUTTON
            // 
            this.connectingBUTTON.Location = new System.Drawing.Point(505, 12);
            this.connectingBUTTON.Name = "connectingBUTTON";
            this.connectingBUTTON.Size = new System.Drawing.Size(150, 21);
            this.connectingBUTTON.TabIndex = 1;
            this.connectingBUTTON.Text = "MI CONNEGGIO";
            this.connectingBUTTON.UseVisualStyleBackColor = true;
            this.connectingBUTTON.Click += new System.EventHandler(this.button2_Click);
            // 
            // serverIP
            // 
            this.serverIP.Location = new System.Drawing.Point(669, 12);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(146, 20);
            this.serverIP.TabIndex = 4;
            this.serverIP.Text = "25.108.14.68";
            this.serverIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // serverPORT
            // 
            this.serverPORT.Location = new System.Drawing.Point(821, 12);
            this.serverPORT.Name = "serverPORT";
            this.serverPORT.Size = new System.Drawing.Size(60, 20);
            this.serverPORT.TabIndex = 5;
            this.serverPORT.Text = "9999";
            this.serverPORT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MessageToSend
            // 
            this.MessageToSend.Location = new System.Drawing.Point(630, 226);
            this.MessageToSend.Name = "MessageToSend";
            this.MessageToSend.Size = new System.Drawing.Size(251, 20);
            this.MessageToSend.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(630, 252);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(251, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "SEND";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(630, 39);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(251, 181);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(782, 479);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Move mode";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 478);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 17);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Host";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(103, 479);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(51, 17);
            this.radioButton2.TabIndex = 13;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Client";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(894, 508);
            this.Controls.Add(this.connectingBUTTON);
            this.Controls.Add(this.serverIP);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.serverPORT);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.MessageToSend);
            this.Controls.Add(this.pg);
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
        private System.Windows.Forms.TextBox serverIP;
        private System.Windows.Forms.TextBox serverPORT;
        private System.Windows.Forms.TextBox MessageToSend;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}

