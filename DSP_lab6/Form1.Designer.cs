namespace DSP_lab6
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.separateValue = new System.Windows.Forms.NumericUpDown();
            this.MinSquare = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.KMedianNumber = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.areaCoefficient = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.perimeterCoefficient = new System.Windows.Forms.NumericUpDown();
            this.elongationCoefficient = new System.Windows.Forms.NumericUpDown();
            this.massCenterCoefficient = new System.Windows.Forms.NumericUpDown();
            this.DensityCoefficient = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separateValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinSquare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KMedianNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaCoefficient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perimeterCoefficient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elongationCoefficient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.massCenterCoefficient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DensityCoefficient)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(122, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(375, 247);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(503, 37);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(371, 247);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(503, 321);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(371, 247);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Location = new System.Drawing.Point(122, 321);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(375, 247);
            this.zedGraphControl2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Source Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(517, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Binary image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(517, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Recognized Items";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Separating threshold";
            // 
            // separateValue
            // 
            this.separateValue.Location = new System.Drawing.Point(12, 93);
            this.separateValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.separateValue.Name = "separateValue";
            this.separateValue.Size = new System.Drawing.Size(75, 20);
            this.separateValue.TabIndex = 13;
            this.separateValue.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // MinSquare
            // 
            this.MinSquare.Location = new System.Drawing.Point(12, 135);
            this.MinSquare.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MinSquare.Name = "MinSquare";
            this.MinSquare.Size = new System.Drawing.Size(75, 20);
            this.MinSquare.TabIndex = 14;
            this.MinSquare.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Minimal Square";
            // 
            // KMedianNumber
            // 
            this.KMedianNumber.Location = new System.Drawing.Point(12, 174);
            this.KMedianNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.KMedianNumber.Name = "KMedianNumber";
            this.KMedianNumber.Size = new System.Drawing.Size(75, 20);
            this.KMedianNumber.TabIndex = 16;
            this.KMedianNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Median number";
            // 
            // areaCoefficient
            // 
            this.areaCoefficient.DecimalPlaces = 2;
            this.areaCoefficient.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.areaCoefficient.Location = new System.Drawing.Point(12, 286);
            this.areaCoefficient.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.areaCoefficient.Name = "areaCoefficient";
            this.areaCoefficient.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.areaCoefficient.Size = new System.Drawing.Size(75, 20);
            this.areaCoefficient.TabIndex = 18;
            this.areaCoefficient.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Area";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 309);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Perimeter";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 350);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Elongation";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 389);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Mass center";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 428);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Density";
            // 
            // perimeterCoefficient
            // 
            this.perimeterCoefficient.DecimalPlaces = 2;
            this.perimeterCoefficient.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.perimeterCoefficient.Location = new System.Drawing.Point(12, 327);
            this.perimeterCoefficient.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.perimeterCoefficient.Name = "perimeterCoefficient";
            this.perimeterCoefficient.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.perimeterCoefficient.Size = new System.Drawing.Size(75, 20);
            this.perimeterCoefficient.TabIndex = 28;
            this.perimeterCoefficient.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // elongationCoefficient
            // 
            this.elongationCoefficient.DecimalPlaces = 2;
            this.elongationCoefficient.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.elongationCoefficient.Location = new System.Drawing.Point(10, 366);
            this.elongationCoefficient.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.elongationCoefficient.Name = "elongationCoefficient";
            this.elongationCoefficient.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.elongationCoefficient.Size = new System.Drawing.Size(75, 20);
            this.elongationCoefficient.TabIndex = 29;
            this.elongationCoefficient.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // massCenterCoefficient
            // 
            this.massCenterCoefficient.DecimalPlaces = 2;
            this.massCenterCoefficient.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.massCenterCoefficient.Location = new System.Drawing.Point(10, 405);
            this.massCenterCoefficient.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.massCenterCoefficient.Name = "massCenterCoefficient";
            this.massCenterCoefficient.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.massCenterCoefficient.Size = new System.Drawing.Size(75, 20);
            this.massCenterCoefficient.TabIndex = 30;
            this.massCenterCoefficient.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // DensityCoefficient
            // 
            this.DensityCoefficient.DecimalPlaces = 2;
            this.DensityCoefficient.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.DensityCoefficient.Location = new System.Drawing.Point(10, 444);
            this.DensityCoefficient.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.DensityCoefficient.Name = "DensityCoefficient";
            this.DensityCoefficient.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DensityCoefficient.Size = new System.Drawing.Size(75, 20);
            this.DensityCoefficient.TabIndex = 31;
            this.DensityCoefficient.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 595);
            this.Controls.Add(this.DensityCoefficient);
            this.Controls.Add(this.massCenterCoefficient);
            this.Controls.Add(this.elongationCoefficient);
            this.Controls.Add(this.perimeterCoefficient);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.areaCoefficient);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.KMedianNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MinSquare);
            this.Controls.Add(this.separateValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zedGraphControl2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separateValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinSquare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KMedianNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaCoefficient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perimeterCoefficient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elongationCoefficient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.massCenterCoefficient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DensityCoefficient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown separateValue;
        private System.Windows.Forms.NumericUpDown MinSquare;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown KMedianNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown areaCoefficient;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown perimeterCoefficient;
        private System.Windows.Forms.NumericUpDown elongationCoefficient;
        private System.Windows.Forms.NumericUpDown massCenterCoefficient;
        private System.Windows.Forms.NumericUpDown DensityCoefficient;
    }
}

