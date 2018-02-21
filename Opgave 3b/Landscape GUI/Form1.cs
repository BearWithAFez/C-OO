using System.Windows.Forms;
using LandscapeGeneratorImplementation;
using LandscapeGeneratorInterface;
using System.Drawing;
using System;

namespace Opgave_3b
{
    public partial class Form1 : Form
    {
        private Bitmap DrawArea;    //bitmap (het "teken platform")
        private Pen pen = new Pen(Brushes.Orange);  //kleur lijn
        private ILandscapeGenerator backend;

        public Form1()
        {
            backend = new LandscapeGenerator();
            InitializeComponent();
            DrawArea = new Bitmap(pictureBox.Width, pictureBox.Height); //tekenPlatform juiste groote
            backend.ResetPointList(pictureBox.Width,pictureBox.Height); //start waarde Points
            drawIt();                                                   
        }

        private void buttonLoad_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (LoadScreen.ShowDialog() == DialogResult.OK)
                {
                    backend.LoadLandscape(LoadScreen.FileName);
                    drawIt();
                }
            }
            catch (Exception)
            {
                //?                
            }
            
        }

        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PictureName.Text)) {
                backend.SaveLandscape(PictureName.Text);
            }
        }

        private void buttonRecalculate_Click(object sender, System.EventArgs e)
        {
            backend.ResetPointList(pictureBox.Width, pictureBox.Height); //start waarde Points
            backend.CalculateLandscape( Convert.ToInt32(numericUDIterations.Value), Convert.ToInt32(numericUDHeightstep.Value));
            drawIt();
        }

        private void drawIt()
        {
            Graphics g; //nieuw "blad"
            g = Graphics.FromImage(DrawArea);   //blad op groote van tekenPlatform
            g.Clear(Color.White);               //vul het met wit
            g.DrawLines(pen, backend.PointList.ToArray());  //teken de lijntjes
            pictureBox.Image = DrawArea;    //Wat op het tekenplatform ligt in de picbox
            g.Dispose();    //smijt blad weg
        }
    }
}
