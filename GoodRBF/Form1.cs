using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GoodRBF
{
    public partial class GoodRBF : Form
    {

        RBFGrid RBF;
        bool FirstLearn = true;

        public GoodRBF()
        {
            InitializeComponent();
            UserInitializeComponent();
            this.Reset();
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void LoadItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.OpenImageMenu();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.SaveImageMenu();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveImageMenu()
        {
            switch (sfdSaveFile.ShowDialog())
            {
                case System.Windows.Forms.DialogResult.OK:
                    {
                        FileStream ImageFile = new FileStream(sfdSaveFile.FileName, FileMode.OpenOrCreate);
                        try
                        {
                            pbInputImage.Image.Save(ImageFile, System.Drawing.Imaging.ImageFormat.Png);
                            MessageBox.Show("Изображение успешно сохранено");
                            break;
                        }
                        catch (ArgumentNullException ex)
                        {
                            MessageBox.Show(ex.ParamName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            ImageFile.Close();
                        }
                    }
                    break;

                case System.Windows.Forms.DialogResult.Cancel:
                    return;
            }
        }
        private void OpenImageMenu()
        {
            switch (ofdOpenFile.ShowDialog())
            {
                case System.Windows.Forms.DialogResult.OK:
                    {
                        FileStream File = new FileStream(ofdOpenFile.FileName, FileMode.Open);
                        try
                        {
                            Image img = Image.FromStream(File);
                            this.pbInputImage.Image = (Bitmap)img;
                            this.pbInputImage.Size = img.Size;
                            this.pbInputImage.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            File.Close();
                        }
                    }
                    break;

                case System.Windows.Forms.DialogResult.Cancel:
                    return;
            }
        }

        private void bLearn1_Click(object sender, EventArgs e)
        {
            try
            {
                Learn(0);
                pbImage1.Image = BMPTransform.DoubleToBitmap(RBF.AVGImage(0), pbInputImage.Image.Width, pbInputImage.Image.Height, -1, 1);
            }
            catch (System.IndexOutOfRangeException)
            {
                MessageBox.Show("Изображение имеет неверный размер");
                RBF.CellReset(0);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void bLearn2_Click(object sender, EventArgs e)
        {
            try 
            {
                Learn(1);
                pbImage2.Image = BMPTransform.DoubleToBitmap(RBF.AVGImage(1), pbInputImage.Image.Width, pbInputImage.Image.Height, -1, 1);
            }
            catch (System.IndexOutOfRangeException)
            {
                MessageBox.Show("Изображение имеет неверный размер");
                RBF.CellReset(1);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bLearn3_Click(object sender, EventArgs e)
        {
            try
            {
                Learn(2);
                pbImage3.Image = BMPTransform.DoubleToBitmap(RBF.AVGImage(2), pbInputImage.Image.Width, pbInputImage.Image.Height, -1, 1);
            }
            catch (System.IndexOutOfRangeException)
            {
                MessageBox.Show("Изображение имеет неверный размер");
                RBF.CellReset(2);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bLearn4_Click(object sender, EventArgs e)
        {
            try
            {
                Learn(3);
                pbImage4.Image = BMPTransform.DoubleToBitmap(RBF.AVGImage(3), pbInputImage.Image.Width, pbInputImage.Image.Height, -1, 1);
            }
            catch (System.IndexOutOfRangeException)
            {
                MessageBox.Show("Изображение имеет неверный размер");
                RBF.CellReset(3);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bLearn6_Click(object sender, EventArgs e)
        {
            try
            {
                Learn(4);
                pbImage5.Image = BMPTransform.DoubleToBitmap(RBF.AVGImage(4), pbInputImage.Image.Width, pbInputImage.Image.Height, -1, 1);
            }
            catch (System.IndexOutOfRangeException)
            {
                MessageBox.Show("Изображение имеет неверный размер");
                RBF.CellReset(4);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Learn(int index)
        {
            double[] input = BMPTransform.BitmapToDouble((Bitmap)pbInputImage.Image);
            RBF.Input = input;
            RBF.LearnImage(index);
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            this.Reset();
        }

        private void Reset()
        {
            RBF = new RBFGrid();
            RBF.InputCellCount = 14 * 14;
            RBF.OutputCellCount = 5;
            
            this.pbImage1.Image = null;
            this.pbImage2.Image = null;
            this.pbImage3.Image = null;
            this.pbImage4.Image = null;
            this.pbImage5.Image = null;
            this.pbInputImage.Image = null;
            
            this.tbVal1.Text = "";
            this.tbVal2.Text = "";
            this.tbVal3.Text = "";
            this.tbVal4.Text = "";
            this.tbVal5.Text = "";

            this.tbSpeed1.Text = "";
            this.tbSpeed2.Text = "";
            this.tbSpeed3.Text = "";
            this.tbSpeed4.Text = "";
            this.tbSpeed5.Text = "";

            FirstLearn = true;
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (FirstLearn)
                {
                    RBF.EndLearn();
                    FirstLearn = false;
                } 
                RBF.Input = BMPTransform.BitmapToDouble((Bitmap)pbInputImage.Image);
                RBF.DoWork();

                tbVal1.Text = ((float)(100 * RBF.Output[0])).ToString();
                tbVal2.Text = ((float)(100 * RBF.Output[1])).ToString();
                tbVal3.Text = ((float)(100 * RBF.Output[2])).ToString();
                tbVal4.Text = ((float)(100 * RBF.Output[3])).ToString();
                tbVal5.Text = ((float)(100 * RBF.Output[4])).ToString();

                tbSpeed1.Text = RBF.OutputCells[0].Iteration.ToString();
                tbSpeed2.Text = RBF.OutputCells[1].Iteration.ToString();
                tbSpeed3.Text = RBF.OutputCells[2].Iteration.ToString();
                tbSpeed4.Text = RBF.OutputCells[3].Iteration.ToString();
                tbSpeed5.Text = RBF.OutputCells[4].Iteration.ToString();
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NoiseItem_Click(object sender, EventArgs e)
        {
            BitmapLocker Locker = new BitmapLocker();
            Locker.Lock((Bitmap)pbInputImage.Image);

            Random R = new Random();
            for (int i = 0; i < Locker.Height; i++)
            {
                for (int j = 0; j < Locker.Width; j++)
                {
                    double val = R.NextDouble();
                    if (val <= 0.1)
                    {
                        byte r, g, b;
                        r = (byte)(Locker[i, j] >> 16);
                        g = (byte)(Locker[i, j] >> 8);
                        b = (byte)(Locker[i, j]);

                        r = (byte)(255 - r);
                        g = (byte)(255 - g);
                        b = (byte)(255 - b);
                        Locker[i, j] = ((uint)255 << 24) + ((uint)r << 16) + ((uint)g << 8) + b;
                    }
                }
            }
            Locker.Unlock();
            this.Refresh();
        }
    }

}
