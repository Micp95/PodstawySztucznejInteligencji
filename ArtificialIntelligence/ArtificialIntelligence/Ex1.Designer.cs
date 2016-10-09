namespace ArtificialIntelligence
{
    partial class Ex1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonORLern = new System.Windows.Forms.Button();
            this.buttonANDLern = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.buttonNOTLern = new System.Windows.Forms.Button();
            this.iterationLabel = new System.Windows.Forms.Label();
            this.lernValueLable = new System.Windows.Forms.Label();
            this.buttonNOTAsk = new System.Windows.Forms.Button();
            this.buttonANDAsk = new System.Windows.Forms.Button();
            this.buttonORAsk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonNOTRestart = new System.Windows.Forms.Button();
            this.buttonANDRestart = new System.Windows.Forms.Button();
            this.buttonORRestart = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonORLern
            // 
            this.buttonORLern.Location = new System.Drawing.Point(12, 12);
            this.buttonORLern.Name = "buttonORLern";
            this.buttonORLern.Size = new System.Drawing.Size(75, 23);
            this.buttonORLern.TabIndex = 0;
            this.buttonORLern.Text = "Lern OR";
            this.buttonORLern.UseVisualStyleBackColor = true;
            this.buttonORLern.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonANDLern
            // 
            this.buttonANDLern.Location = new System.Drawing.Point(12, 41);
            this.buttonANDLern.Name = "buttonANDLern";
            this.buttonANDLern.Size = new System.Drawing.Size(75, 23);
            this.buttonANDLern.TabIndex = 1;
            this.buttonANDLern.Text = "Lern AND";
            this.buttonANDLern.UseVisualStyleBackColor = true;
            this.buttonANDLern.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(114, 129);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(114, 155);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(424, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(114, 12);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "1";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(114, 41);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 6;
            this.textBox4.Text = "1";
            // 
            // buttonNOTLern
            // 
            this.buttonNOTLern.Location = new System.Drawing.Point(12, 70);
            this.buttonNOTLern.Name = "buttonNOTLern";
            this.buttonNOTLern.Size = new System.Drawing.Size(75, 23);
            this.buttonNOTLern.TabIndex = 7;
            this.buttonNOTLern.Text = "Lern NOT";
            this.buttonNOTLern.UseVisualStyleBackColor = true;
            this.buttonNOTLern.Click += new System.EventHandler(this.buttonNOTLern_Click);
            // 
            // iterationLabel
            // 
            this.iterationLabel.AutoSize = true;
            this.iterationLabel.Location = new System.Drawing.Point(234, 17);
            this.iterationLabel.Name = "iterationLabel";
            this.iterationLabel.Size = new System.Drawing.Size(45, 13);
            this.iterationLabel.TabIndex = 8;
            this.iterationLabel.Text = "Iteration";
            // 
            // lernValueLable
            // 
            this.lernValueLable.AutoSize = true;
            this.lernValueLable.Location = new System.Drawing.Point(234, 46);
            this.lernValueLable.Name = "lernValueLable";
            this.lernValueLable.Size = new System.Drawing.Size(57, 13);
            this.lernValueLable.TabIndex = 9;
            this.lernValueLable.Text = "Lern value";
            // 
            // buttonNOTAsk
            // 
            this.buttonNOTAsk.Location = new System.Drawing.Point(12, 187);
            this.buttonNOTAsk.Name = "buttonNOTAsk";
            this.buttonNOTAsk.Size = new System.Drawing.Size(75, 23);
            this.buttonNOTAsk.TabIndex = 12;
            this.buttonNOTAsk.Text = "Ask NOT";
            this.buttonNOTAsk.UseVisualStyleBackColor = true;
            this.buttonNOTAsk.Click += new System.EventHandler(this.buttonNOTAsk_Click);
            // 
            // buttonANDAsk
            // 
            this.buttonANDAsk.Location = new System.Drawing.Point(12, 158);
            this.buttonANDAsk.Name = "buttonANDAsk";
            this.buttonANDAsk.Size = new System.Drawing.Size(75, 23);
            this.buttonANDAsk.TabIndex = 11;
            this.buttonANDAsk.Text = "Ask AND";
            this.buttonANDAsk.UseVisualStyleBackColor = true;
            this.buttonANDAsk.Click += new System.EventHandler(this.buttonANDAsk_Click);
            // 
            // buttonORAsk
            // 
            this.buttonORAsk.Location = new System.Drawing.Point(12, 129);
            this.buttonORAsk.Name = "buttonORAsk";
            this.buttonORAsk.Size = new System.Drawing.Size(75, 23);
            this.buttonORAsk.TabIndex = 10;
            this.buttonORAsk.Text = "Ask OR";
            this.buttonORAsk.UseVisualStyleBackColor = true;
            this.buttonORAsk.Click += new System.EventHandler(this.buttonORAsk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "X1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "X2";
            // 
            // buttonNOTRestart
            // 
            this.buttonNOTRestart.Location = new System.Drawing.Point(321, 187);
            this.buttonNOTRestart.Name = "buttonNOTRestart";
            this.buttonNOTRestart.Size = new System.Drawing.Size(75, 23);
            this.buttonNOTRestart.TabIndex = 17;
            this.buttonNOTRestart.Text = "Restart NOT";
            this.buttonNOTRestart.UseVisualStyleBackColor = true;
            this.buttonNOTRestart.Click += new System.EventHandler(this.buttonNOTRestart_Click);
            // 
            // buttonANDRestart
            // 
            this.buttonANDRestart.Location = new System.Drawing.Point(321, 158);
            this.buttonANDRestart.Name = "buttonANDRestart";
            this.buttonANDRestart.Size = new System.Drawing.Size(75, 23);
            this.buttonANDRestart.TabIndex = 16;
            this.buttonANDRestart.Text = "Restart AND";
            this.buttonANDRestart.UseVisualStyleBackColor = true;
            this.buttonANDRestart.Click += new System.EventHandler(this.buttonANDRestart_Click);
            // 
            // buttonORRestart
            // 
            this.buttonORRestart.Location = new System.Drawing.Point(321, 129);
            this.buttonORRestart.Name = "buttonORRestart";
            this.buttonORRestart.Size = new System.Drawing.Size(75, 23);
            this.buttonORRestart.TabIndex = 15;
            this.buttonORRestart.Text = "Restart OR";
            this.buttonORRestart.UseVisualStyleBackColor = true;
            this.buttonORRestart.Click += new System.EventHandler(this.buttonORRestart_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(351, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Output";
            // 
            // Ex1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 261);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonNOTRestart);
            this.Controls.Add(this.buttonANDRestart);
            this.Controls.Add(this.buttonORRestart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonNOTAsk);
            this.Controls.Add(this.buttonANDAsk);
            this.Controls.Add(this.buttonORAsk);
            this.Controls.Add(this.lernValueLable);
            this.Controls.Add(this.iterationLabel);
            this.Controls.Add(this.buttonNOTLern);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonANDLern);
            this.Controls.Add(this.buttonORLern);
            this.Name = "Ex1";
            this.Text = "Ex1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Ex1_FormClosed);
            this.Load += new System.EventHandler(this.Ex1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonORLern;
        private System.Windows.Forms.Button buttonANDLern;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button buttonNOTLern;
        private System.Windows.Forms.Label iterationLabel;
        private System.Windows.Forms.Label lernValueLable;
        private System.Windows.Forms.Button buttonNOTAsk;
        private System.Windows.Forms.Button buttonANDAsk;
        private System.Windows.Forms.Button buttonORAsk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonNOTRestart;
        private System.Windows.Forms.Button buttonANDRestart;
        private System.Windows.Forms.Button buttonORRestart;
        private System.Windows.Forms.Label label4;
    }
}