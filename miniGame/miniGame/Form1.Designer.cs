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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.serverIP = new System.Windows.Forms.TextBox();
            this.hostingIP = new System.Windows.Forms.TextBox();
            this.serverPORT = new System.Windows.Forms.TextBox();
            this.hostingPORT = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(491, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(15, 15);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 21);
            this.button2.TabIndex = 1;
            this.button2.Text = "MI CONNEGGIO";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(29, 34);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "APRO IL SERVER";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "AHHHHHHHHHHHHHHHHHH";
            // 
            // serverIP
            // 
            this.serverIP.Location = new System.Drawing.Point(193, 39);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(146, 20);
            this.serverIP.TabIndex = 4;
            this.serverIP.Text = "25.108.14.68";
            this.serverIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hostingIP
            // 
            this.hostingIP.Location = new System.Drawing.Point(193, 34);
            this.hostingIP.Name = "hostingIP";
            this.hostingIP.Size = new System.Drawing.Size(146, 20);
            this.hostingIP.TabIndex = 6;
            this.hostingIP.Text = "25.108.14.68";
            this.hostingIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // serverPORT
            // 
            this.serverPORT.Location = new System.Drawing.Point(345, 39);
            this.serverPORT.Name = "serverPORT";
            this.serverPORT.Size = new System.Drawing.Size(60, 20);
            this.serverPORT.TabIndex = 5;
            this.serverPORT.Text = "8888";
            this.serverPORT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hostingPORT
            // 
            this.hostingPORT.Location = new System.Drawing.Point(345, 34);
            this.hostingPORT.Name = "hostingPORT";
            this.hostingPORT.Size = new System.Drawing.Size(60, 20);
            this.hostingPORT.TabIndex = 7;
            this.hostingPORT.Text = "8888";
            this.hostingPORT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(161, 65);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.serverIP);
            this.splitContainer1.Panel1.Controls.Add(this.serverPORT);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button3);
            this.splitContainer1.Panel2.Controls.Add(this.hostingIP);
            this.splitContainer1.Panel2.Controls.Add(this.hostingPORT);
            this.splitContainer1.Size = new System.Drawing.Size(444, 186);
            this.splitContainer1.SplitterDistance = 94;
            this.splitContainer1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(819, 437);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "miniGame";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mover);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverIP;
        private System.Windows.Forms.TextBox hostingIP;
        private System.Windows.Forms.TextBox serverPORT;
        private System.Windows.Forms.TextBox hostingPORT;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

