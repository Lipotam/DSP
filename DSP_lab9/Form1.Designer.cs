namespace DSP_lab9
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.button6 = new System.Windows.Forms.Button();
            this.numericUpDownALFA = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBeta = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownD = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownALFA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownD)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(149, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1104, 463);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Add for teaching";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 288);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Recognize";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 464);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 435);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Inverse";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 67);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(44, 17);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "First";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(13, 90);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(62, 17);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.Text = "Second";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(13, 113);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(49, 17);
            this.radioButton3.TabIndex = 8;
            this.radioButton3.Text = "Third";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(13, 259);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = "Teach";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // numericUpDownALFA
            // 
            this.numericUpDownALFA.DecimalPlaces = 2;
            this.numericUpDownALFA.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownALFA.Location = new System.Drawing.Point(13, 165);
            this.numericUpDownALFA.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownALFA.Name = "numericUpDownALFA";
            this.numericUpDownALFA.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownALFA.TabIndex = 10;
            this.numericUpDownALFA.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownBeta
            // 
            this.numericUpDownBeta.DecimalPlaces = 2;
            this.numericUpDownBeta.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownBeta.Location = new System.Drawing.Point(12, 191);
            this.numericUpDownBeta.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownBeta.Name = "numericUpDownBeta";
            this.numericUpDownBeta.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownBeta.TabIndex = 11;
            this.numericUpDownBeta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownD
            // 
            this.numericUpDownD.DecimalPlaces = 2;
            this.numericUpDownD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownD.Location = new System.Drawing.Point(12, 217);
            this.numericUpDownD.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownD.Name = "numericUpDownD";
            this.numericUpDownD.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownD.TabIndex = 12;
            this.numericUpDownD.Value = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1261, 499);
            this.Controls.Add(this.numericUpDownD);
            this.Controls.Add(this.numericUpDownBeta);
            this.Controls.Add(this.numericUpDownALFA);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownALFA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.NumericUpDown numericUpDownALFA;
        private System.Windows.Forms.NumericUpDown numericUpDownBeta;
        private System.Windows.Forms.NumericUpDown numericUpDownD;
    }
}

