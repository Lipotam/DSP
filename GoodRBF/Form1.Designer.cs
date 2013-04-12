namespace GoodRBF
{
    partial class GoodRBF
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

        private MyPictureBox pbInputImage;
        private MyPictureBox pbImage5;
        private MyPictureBox pbImage4;
        private MyPictureBox pbImage3;
        private MyPictureBox pbImage2;
        private MyPictureBox pbImage1;

        private void UserInitializeComponent()
        {
            this.pbInputImage = new MyPictureBox();
            this.pbImage5 = new MyPictureBox();
            this.pbImage4 = new MyPictureBox();
            this.pbImage3 = new MyPictureBox();
            this.pbImage2 = new MyPictureBox();
            this.pbImage1 = new MyPictureBox();

            // 
            // pbInputImage
            // 
            this.pbInputImage.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pbInputImage.ContextMenuStrip = this.cmsImageContext;
            this.pbInputImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbInputImage.Location = new System.Drawing.Point(3, 3);
            this.pbInputImage.Name = "pbInputImage";
            this.pbInputImage.Size = new System.Drawing.Size(783, 253);
            this.pbInputImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbInputImage.TabIndex = 2;
            this.pbInputImage.TabStop = false;

            // 
            // pbImage5
            // 
            this.pbImage5.BackColor = System.Drawing.SystemColors.Info;
            this.pbImage5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImage5.Location = new System.Drawing.Point(499, 3);
            this.pbImage5.Name = "pbImage5";
            this.pbImage5.Size = new System.Drawing.Size(119, 123);
            this.pbImage5.TabIndex = 4;
            this.pbImage5.TabStop = false;
            this.pbImage5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // pbImage4
            // 
            this.pbImage4.BackColor = System.Drawing.SystemColors.Info;
            this.pbImage4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImage4.Location = new System.Drawing.Point(375, 3);
            this.pbImage4.Name = "pbImage4";
            this.pbImage4.Size = new System.Drawing.Size(118, 123);
            this.pbImage4.TabIndex = 3;
            this.pbImage4.TabStop = false;
            this.pbImage4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // pbImage3
            // 
            this.pbImage3.BackColor = System.Drawing.SystemColors.Info;
            this.pbImage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImage3.Location = new System.Drawing.Point(251, 3);
            this.pbImage3.Name = "pbImage3";
            this.pbImage3.Size = new System.Drawing.Size(118, 123);
            this.pbImage3.TabIndex = 2;
            this.pbImage3.TabStop = false;
            this.pbImage3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // pbImage2
            // 
            this.pbImage2.BackColor = System.Drawing.SystemColors.Info;
            this.pbImage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImage2.Location = new System.Drawing.Point(127, 3);
            this.pbImage2.Name = "pbImage2";
            this.pbImage2.Size = new System.Drawing.Size(118, 123);
            this.pbImage2.TabIndex = 1;
            this.pbImage2.TabStop = false;
            this.pbImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // pbImage1
            // 
            this.pbImage1.BackColor = System.Drawing.SystemColors.Info;
            this.pbImage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImage1.Location = new System.Drawing.Point(3, 3);
            this.pbImage1.Name = "pbImage1";
            this.pbImage1.Size = new System.Drawing.Size(118, 123);
            this.pbImage1.TabIndex = 0;
            this.pbImage1.TabStop = false;
            this.pbImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;


            this.tlpImageGrid.Controls.Add(this.pbImage1, 0, 0);
            this.tlpImageGrid.Controls.Add(this.pbImage2, 1, 0);
            this.tlpImageGrid.Controls.Add(this.pbImage3, 2, 0);
            this.tlpImageGrid.Controls.Add(this.pbImage4, 3, 0);
            this.tlpImageGrid.Controls.Add(this.pbImage5, 4, 0);
            this.tlpMainGrid.Controls.Add(this.pbInputImage, 0, 0);

        }



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tlpMainGrid = new System.Windows.Forms.TableLayoutPanel();
            this.tlpInfoGrid = new System.Windows.Forms.TableLayoutPanel();
            this.gbImages = new System.Windows.Forms.GroupBox();
            this.tlpImageGrid = new System.Windows.Forms.TableLayoutPanel();
            this.bLearn1 = new System.Windows.Forms.Button();
            this.bLearn2 = new System.Windows.Forms.Button();
            this.bLearn3 = new System.Windows.Forms.Button();
            this.bLearn4 = new System.Windows.Forms.Button();
            this.bLearn6 = new System.Windows.Forms.Button();
            this.gbValues = new System.Windows.Forms.GroupBox();
            this.tlpValuesGrid = new System.Windows.Forms.TableLayoutPanel();
            this.tbVal5 = new System.Windows.Forms.TextBox();
            this.tbVal4 = new System.Windows.Forms.TextBox();
            this.tbVal3 = new System.Windows.Forms.TextBox();
            this.tbVal2 = new System.Windows.Forms.TextBox();
            this.tbVal1 = new System.Windows.Forms.TextBox();
            this.tlpControlGrid = new System.Windows.Forms.TableLayoutPanel();
            this.bReset = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.gbSpeed = new System.Windows.Forms.GroupBox();
            this.tlpSpeedGrid = new System.Windows.Forms.TableLayoutPanel();
            this.tbSpeed5 = new System.Windows.Forms.TextBox();
            this.tbSpeed4 = new System.Windows.Forms.TextBox();
            this.tbSpeed3 = new System.Windows.Forms.TextBox();
            this.tbSpeed2 = new System.Windows.Forms.TextBox();
            this.tbSpeed1 = new System.Windows.Forms.TextBox();
            this.cmsImageContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LoadItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NoiseItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.ofdOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.tlpMainGrid.SuspendLayout();
            this.tlpInfoGrid.SuspendLayout();
            this.gbImages.SuspendLayout();
            this.tlpImageGrid.SuspendLayout();
            this.gbValues.SuspendLayout();
            this.tlpValuesGrid.SuspendLayout();
            this.tlpControlGrid.SuspendLayout();
            this.gbSpeed.SuspendLayout();
            this.tlpSpeedGrid.SuspendLayout();
            this.cmsImageContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMainGrid
            // 
            this.tlpMainGrid.ColumnCount = 1;
            this.tlpMainGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainGrid.Controls.Add(this.tlpInfoGrid, 0, 1);
            this.tlpMainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainGrid.Location = new System.Drawing.Point(0, 0);
            this.tlpMainGrid.Name = "tlpMainGrid";
            this.tlpMainGrid.RowCount = 2;
            this.tlpMainGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMainGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMainGrid.Size = new System.Drawing.Size(789, 519);
            this.tlpMainGrid.TabIndex = 0;
            // 
            // tlpInfoGrid
            // 
            this.tlpInfoGrid.ColumnCount = 2;
            this.tlpInfoGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInfoGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpInfoGrid.Controls.Add(this.gbImages, 0, 0);
            this.tlpInfoGrid.Controls.Add(this.gbValues, 0, 1);
            this.tlpInfoGrid.Controls.Add(this.tlpControlGrid, 1, 0);
            this.tlpInfoGrid.Controls.Add(this.bClose, 1, 2);
            this.tlpInfoGrid.Controls.Add(this.gbSpeed, 0, 2);
            this.tlpInfoGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInfoGrid.Location = new System.Drawing.Point(3, 262);
            this.tlpInfoGrid.Name = "tlpInfoGrid";
            this.tlpInfoGrid.RowCount = 3;
            this.tlpInfoGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInfoGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpInfoGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpInfoGrid.Size = new System.Drawing.Size(783, 254);
            this.tlpInfoGrid.TabIndex = 3;
            // 
            // gbImages
            // 
            this.gbImages.Controls.Add(this.tlpImageGrid);
            this.gbImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbImages.Location = new System.Drawing.Point(3, 3);
            this.gbImages.Name = "gbImages";
            this.gbImages.Size = new System.Drawing.Size(627, 148);
            this.gbImages.TabIndex = 2;
            this.gbImages.TabStop = false;
            this.gbImages.Text = "Образы";
            // 
            // tlpImageGrid
            // 
            this.tlpImageGrid.ColumnCount = 5;
            this.tlpImageGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpImageGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpImageGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpImageGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpImageGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpImageGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpImageGrid.Controls.Add(this.bLearn1, 0, 1);
            this.tlpImageGrid.Controls.Add(this.bLearn2, 1, 1);
            this.tlpImageGrid.Controls.Add(this.bLearn3, 2, 1);
            this.tlpImageGrid.Controls.Add(this.bLearn4, 3, 1);
            this.tlpImageGrid.Controls.Add(this.bLearn6, 4, 1);
            this.tlpImageGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpImageGrid.Location = new System.Drawing.Point(3, 16);
            this.tlpImageGrid.Name = "tlpImageGrid";
            this.tlpImageGrid.RowCount = 2;
            this.tlpImageGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImageGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpImageGrid.Size = new System.Drawing.Size(621, 129);
            this.tlpImageGrid.TabIndex = 0;
            // 
            // bLearn1
            // 
            this.bLearn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLearn1.Location = new System.Drawing.Point(3, 82);
            this.bLearn1.Name = "bLearn1";
            this.bLearn1.Size = new System.Drawing.Size(118, 44);
            this.bLearn1.TabIndex = 5;
            this.bLearn1.Text = "Запомни";
            this.bLearn1.UseVisualStyleBackColor = true;
            this.bLearn1.Click += new System.EventHandler(this.bLearn1_Click);
            // 
            // bLearn2
            // 
            this.bLearn2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLearn2.Location = new System.Drawing.Point(127, 82);
            this.bLearn2.Name = "bLearn2";
            this.bLearn2.Size = new System.Drawing.Size(118, 44);
            this.bLearn2.TabIndex = 6;
            this.bLearn2.Text = "Запомни";
            this.bLearn2.UseVisualStyleBackColor = true;
            this.bLearn2.Click += new System.EventHandler(this.bLearn2_Click);
            // 
            // bLearn3
            // 
            this.bLearn3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLearn3.Location = new System.Drawing.Point(251, 82);
            this.bLearn3.Name = "bLearn3";
            this.bLearn3.Size = new System.Drawing.Size(118, 44);
            this.bLearn3.TabIndex = 7;
            this.bLearn3.Text = "Запомни";
            this.bLearn3.UseVisualStyleBackColor = true;
            this.bLearn3.Click += new System.EventHandler(this.bLearn3_Click);
            // 
            // bLearn4
            // 
            this.bLearn4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLearn4.Location = new System.Drawing.Point(375, 82);
            this.bLearn4.Name = "bLearn4";
            this.bLearn4.Size = new System.Drawing.Size(118, 44);
            this.bLearn4.TabIndex = 8;
            this.bLearn4.Text = "Запомни";
            this.bLearn4.UseVisualStyleBackColor = true;
            this.bLearn4.Click += new System.EventHandler(this.bLearn4_Click);
            // 
            // bLearn6
            // 
            this.bLearn6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLearn6.Location = new System.Drawing.Point(499, 82);
            this.bLearn6.Name = "bLearn6";
            this.bLearn6.Size = new System.Drawing.Size(119, 44);
            this.bLearn6.TabIndex = 9;
            this.bLearn6.Text = "Запомни";
            this.bLearn6.UseVisualStyleBackColor = true;
            this.bLearn6.Click += new System.EventHandler(this.bLearn6_Click);
            // 
            // gbValues
            // 
            this.gbValues.Controls.Add(this.tlpValuesGrid);
            this.gbValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbValues.Location = new System.Drawing.Point(3, 157);
            this.gbValues.Name = "gbValues";
            this.gbValues.Size = new System.Drawing.Size(627, 44);
            this.gbValues.TabIndex = 3;
            this.gbValues.TabStop = false;
            this.gbValues.Text = "Подобие (%)";
            // 
            // tlpValuesGrid
            // 
            this.tlpValuesGrid.ColumnCount = 5;
            this.tlpValuesGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpValuesGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpValuesGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpValuesGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpValuesGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpValuesGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpValuesGrid.Controls.Add(this.tbVal5, 4, 0);
            this.tlpValuesGrid.Controls.Add(this.tbVal4, 3, 0);
            this.tlpValuesGrid.Controls.Add(this.tbVal3, 2, 0);
            this.tlpValuesGrid.Controls.Add(this.tbVal2, 1, 0);
            this.tlpValuesGrid.Controls.Add(this.tbVal1, 0, 0);
            this.tlpValuesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpValuesGrid.Location = new System.Drawing.Point(3, 16);
            this.tlpValuesGrid.Name = "tlpValuesGrid";
            this.tlpValuesGrid.RowCount = 1;
            this.tlpValuesGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpValuesGrid.Size = new System.Drawing.Size(621, 25);
            this.tlpValuesGrid.TabIndex = 0;
            // 
            // tbVal5
            // 
            this.tbVal5.BackColor = System.Drawing.SystemColors.Info;
            this.tbVal5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbVal5.Location = new System.Drawing.Point(499, 3);
            this.tbVal5.Name = "tbVal5";
            this.tbVal5.ReadOnly = true;
            this.tbVal5.Size = new System.Drawing.Size(119, 20);
            this.tbVal5.TabIndex = 4;
            // 
            // tbVal4
            // 
            this.tbVal4.BackColor = System.Drawing.SystemColors.Info;
            this.tbVal4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbVal4.Location = new System.Drawing.Point(375, 3);
            this.tbVal4.Name = "tbVal4";
            this.tbVal4.ReadOnly = true;
            this.tbVal4.Size = new System.Drawing.Size(118, 20);
            this.tbVal4.TabIndex = 3;
            // 
            // tbVal3
            // 
            this.tbVal3.BackColor = System.Drawing.SystemColors.Info;
            this.tbVal3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbVal3.Location = new System.Drawing.Point(251, 3);
            this.tbVal3.Name = "tbVal3";
            this.tbVal3.ReadOnly = true;
            this.tbVal3.Size = new System.Drawing.Size(118, 20);
            this.tbVal3.TabIndex = 2;
            // 
            // tbVal2
            // 
            this.tbVal2.BackColor = System.Drawing.SystemColors.Info;
            this.tbVal2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbVal2.Location = new System.Drawing.Point(127, 3);
            this.tbVal2.Name = "tbVal2";
            this.tbVal2.ReadOnly = true;
            this.tbVal2.Size = new System.Drawing.Size(118, 20);
            this.tbVal2.TabIndex = 1;
            // 
            // tbVal1
            // 
            this.tbVal1.BackColor = System.Drawing.SystemColors.Info;
            this.tbVal1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbVal1.Location = new System.Drawing.Point(3, 3);
            this.tbVal1.Name = "tbVal1";
            this.tbVal1.ReadOnly = true;
            this.tbVal1.Size = new System.Drawing.Size(118, 20);
            this.tbVal1.TabIndex = 0;
            // 
            // tlpControlGrid
            // 
            this.tlpControlGrid.ColumnCount = 1;
            this.tlpControlGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControlGrid.Controls.Add(this.bReset, 0, 1);
            this.tlpControlGrid.Controls.Add(this.bStart, 0, 0);
            this.tlpControlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpControlGrid.Location = new System.Drawing.Point(636, 3);
            this.tlpControlGrid.Name = "tlpControlGrid";
            this.tlpControlGrid.RowCount = 3;
            this.tlpControlGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpControlGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpControlGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControlGrid.Size = new System.Drawing.Size(144, 148);
            this.tlpControlGrid.TabIndex = 4;
            // 
            // bReset
            // 
            this.bReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bReset.Location = new System.Drawing.Point(3, 53);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(138, 44);
            this.bReset.TabIndex = 1;
            this.bReset.Text = "Сброс";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // bStart
            // 
            this.bStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bStart.Location = new System.Drawing.Point(3, 3);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(138, 44);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "Пуск";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bClose
            // 
            this.bClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bClose.Location = new System.Drawing.Point(636, 207);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(144, 44);
            this.bClose.TabIndex = 5;
            this.bClose.Text = "Выход";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // gbSpeed
            // 
            this.gbSpeed.Controls.Add(this.tlpSpeedGrid);
            this.gbSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSpeed.Location = new System.Drawing.Point(3, 207);
            this.gbSpeed.Name = "gbSpeed";
            this.gbSpeed.Size = new System.Drawing.Size(627, 44);
            this.gbSpeed.TabIndex = 6;
            this.gbSpeed.TabStop = false;
            this.gbSpeed.Text = "Скорость";
            // 
            // tlpSpeedGrid
            // 
            this.tlpSpeedGrid.ColumnCount = 5;
            this.tlpSpeedGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpSpeedGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpSpeedGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpSpeedGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpSpeedGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpSpeedGrid.Controls.Add(this.tbSpeed5, 4, 0);
            this.tlpSpeedGrid.Controls.Add(this.tbSpeed4, 3, 0);
            this.tlpSpeedGrid.Controls.Add(this.tbSpeed3, 2, 0);
            this.tlpSpeedGrid.Controls.Add(this.tbSpeed2, 1, 0);
            this.tlpSpeedGrid.Controls.Add(this.tbSpeed1, 0, 0);
            this.tlpSpeedGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSpeedGrid.Location = new System.Drawing.Point(3, 16);
            this.tlpSpeedGrid.Name = "tlpSpeedGrid";
            this.tlpSpeedGrid.RowCount = 1;
            this.tlpSpeedGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSpeedGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpSpeedGrid.Size = new System.Drawing.Size(621, 25);
            this.tlpSpeedGrid.TabIndex = 0;
            // 
            // tbSpeed5
            // 
            this.tbSpeed5.BackColor = System.Drawing.SystemColors.Info;
            this.tbSpeed5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSpeed5.Location = new System.Drawing.Point(499, 3);
            this.tbSpeed5.Name = "tbSpeed5";
            this.tbSpeed5.ReadOnly = true;
            this.tbSpeed5.Size = new System.Drawing.Size(119, 20);
            this.tbSpeed5.TabIndex = 4;
            // 
            // tbSpeed4
            // 
            this.tbSpeed4.BackColor = System.Drawing.SystemColors.Info;
            this.tbSpeed4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSpeed4.Location = new System.Drawing.Point(375, 3);
            this.tbSpeed4.Name = "tbSpeed4";
            this.tbSpeed4.ReadOnly = true;
            this.tbSpeed4.Size = new System.Drawing.Size(118, 20);
            this.tbSpeed4.TabIndex = 3;
            // 
            // tbSpeed3
            // 
            this.tbSpeed3.BackColor = System.Drawing.SystemColors.Info;
            this.tbSpeed3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSpeed3.Location = new System.Drawing.Point(251, 3);
            this.tbSpeed3.Name = "tbSpeed3";
            this.tbSpeed3.ReadOnly = true;
            this.tbSpeed3.Size = new System.Drawing.Size(118, 20);
            this.tbSpeed3.TabIndex = 2;
            // 
            // tbSpeed2
            // 
            this.tbSpeed2.BackColor = System.Drawing.SystemColors.Info;
            this.tbSpeed2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSpeed2.Location = new System.Drawing.Point(127, 3);
            this.tbSpeed2.Name = "tbSpeed2";
            this.tbSpeed2.ReadOnly = true;
            this.tbSpeed2.Size = new System.Drawing.Size(118, 20);
            this.tbSpeed2.TabIndex = 1;
            // 
            // tbSpeed1
            // 
            this.tbSpeed1.BackColor = System.Drawing.SystemColors.Info;
            this.tbSpeed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSpeed1.Location = new System.Drawing.Point(3, 3);
            this.tbSpeed1.Name = "tbSpeed1";
            this.tbSpeed1.ReadOnly = true;
            this.tbSpeed1.Size = new System.Drawing.Size(118, 20);
            this.tbSpeed1.TabIndex = 0;
            // 
            // cmsImageContext
            // 
            this.cmsImageContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadItem,
            this.SaveItem,
            this.NoiseItem});
            this.cmsImageContext.Name = "cmsImageContext";
            this.cmsImageContext.Size = new System.Drawing.Size(105, 70);
            // 
            // LoadItem
            // 
            this.LoadItem.Name = "LoadItem";
            this.LoadItem.Size = new System.Drawing.Size(104, 22);
            this.LoadItem.Text = "Load";
            this.LoadItem.Click += new System.EventHandler(this.LoadItem_Click);
            // 
            // SaveItem
            // 
            this.SaveItem.Name = "SaveItem";
            this.SaveItem.Size = new System.Drawing.Size(104, 22);
            this.SaveItem.Text = "Save";
            this.SaveItem.Click += new System.EventHandler(this.SaveItem_Click);
            // 
            // NoiseItem
            // 
            this.NoiseItem.Name = "NoiseItem";
            this.NoiseItem.Size = new System.Drawing.Size(104, 22);
            this.NoiseItem.Text = "Noise";
            this.NoiseItem.Click += new System.EventHandler(this.NoiseItem_Click);
            // 
            // sfdSaveFile
            // 
            this.sfdSaveFile.Filter = "Portable Networks Graphic(*.PNG)|*.PNG;";
            // 
            // ofdOpenFile
            // 
            this.ofdOpenFile.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            // 
            // GoodRBF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 519);
            this.Controls.Add(this.tlpMainGrid);
            this.Name = "GoodRBF";
            this.Text = "GoodRBF";
            this.tlpMainGrid.ResumeLayout(false);
            this.tlpInfoGrid.ResumeLayout(false);
            this.gbImages.ResumeLayout(false);
            this.tlpImageGrid.ResumeLayout(false);
            this.gbValues.ResumeLayout(false);
            this.tlpValuesGrid.ResumeLayout(false);
            this.tlpValuesGrid.PerformLayout();
            this.tlpControlGrid.ResumeLayout(false);
            this.gbSpeed.ResumeLayout(false);
            this.tlpSpeedGrid.ResumeLayout(false);
            this.tlpSpeedGrid.PerformLayout();
            this.cmsImageContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMainGrid;
        private System.Windows.Forms.TableLayoutPanel tlpInfoGrid;
        private System.Windows.Forms.GroupBox gbImages;
        private System.Windows.Forms.TableLayoutPanel tlpImageGrid;
        private System.Windows.Forms.Button bLearn1;
        private System.Windows.Forms.Button bLearn2;
        private System.Windows.Forms.Button bLearn3;
        private System.Windows.Forms.Button bLearn4;
        private System.Windows.Forms.Button bLearn6;
        private System.Windows.Forms.GroupBox gbValues;
        private System.Windows.Forms.TableLayoutPanel tlpValuesGrid;
        private System.Windows.Forms.TextBox tbVal5;
        private System.Windows.Forms.TextBox tbVal4;
        private System.Windows.Forms.TextBox tbVal3;
        private System.Windows.Forms.TextBox tbVal2;
        private System.Windows.Forms.TextBox tbVal1;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.TableLayoutPanel tlpControlGrid;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.ContextMenuStrip cmsImageContext;
        private System.Windows.Forms.ToolStripMenuItem LoadItem;
        private System.Windows.Forms.ToolStripMenuItem SaveItem;
        private System.Windows.Forms.ToolStripMenuItem NoiseItem;
        private System.Windows.Forms.SaveFileDialog sfdSaveFile;
        private System.Windows.Forms.OpenFileDialog ofdOpenFile;
        private System.Windows.Forms.GroupBox gbSpeed;
        private System.Windows.Forms.TableLayoutPanel tlpSpeedGrid;
        private System.Windows.Forms.TextBox tbSpeed5;
        private System.Windows.Forms.TextBox tbSpeed4;
        private System.Windows.Forms.TextBox tbSpeed3;
        private System.Windows.Forms.TextBox tbSpeed2;
        private System.Windows.Forms.TextBox tbSpeed1;
    }
}

