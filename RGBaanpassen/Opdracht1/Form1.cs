using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opdracht1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageLeft.Image = new Bitmap(Image.FromFile(openFileDialog1.FileName));
                imageRight.Image = new Bitmap(imageLeft.Image);
            }
            else
            {
                this.Close();
            }
        }

        private void resolutionSlider_Scroll(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(imageLeft.Image);
            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    Color pixel = bm.GetPixel(x, y);

                    byte red = (byte)(pixel.R & ((byte)(255-(Math.Pow(2,8-resolutionSlider.Value)-1))));
                    byte green = (byte)(pixel.G & ((byte)(255 - (Math.Pow(2, 8 - resolutionSlider.Value) - 1))));
                    byte blue = (byte)(pixel.B & ((byte)(255 - (Math.Pow(2, 8 - resolutionSlider.Value) - 1))));

                    Color newColor = Color.FromArgb(red, green, blue);
                    bm.SetPixel(x, y, newColor);
                }
            }
            imageRight.Image = bm;
        }

        private void resolutionButton_Click(object sender, EventArgs e)
        {
            resolutionSlider.Value = 8;
            resolutionSlider.Visible = true;           
            imageRight.Image = (Bitmap)imageLeft.Image;
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            resolutionSlider.Visible = false;
            Bitmap bm = new Bitmap(imageLeft.Image);
            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    Color pixel = bm.GetPixel(x, y);
                    Color newColor = Color.FromArgb(0, 0, pixel.B);
                    bm.SetPixel(x, y, newColor);
                }
            }
            imageRight.Image = bm;
        }

        private void greenButton_Click(object sender, EventArgs e)
        {
            resolutionSlider.Visible = false;
            Bitmap bm = new Bitmap(imageLeft.Image);
            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    Color pixel = bm.GetPixel(x, y);
                    Color newColor = Color.FromArgb(0, pixel.G, 0);
                    bm.SetPixel(x, y, newColor);
                }
            }
            imageRight.Image = bm;
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            resolutionSlider.Visible = false;
            Bitmap bm = new Bitmap(imageLeft.Image);
            for(int x = 0; x < bm.Width; x++)
            {
                for(int y = 0; y < bm.Height; y++)
                {
                    Color pixel = bm.GetPixel(x, y);                    
                    Color newColor = Color.FromArgb(pixel.R,0,0);
                    bm.SetPixel(x, y, newColor);
                }
            }
            imageRight.Image = bm;            
        }
    }
}
