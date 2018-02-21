using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicInterface;
using LogicImplementation;

namespace FilterGUI
{
    public partial class Form1 : Form
    {
        IImageFilter backend = new ImageFilter();
        
        public Form1()
        {
            InitializeComponent();
            DialogResult res = new DialogResult();
            do
            {
                try
                {
                    loadPhoto();
                }
                catch (Exception)
                {
                    res = MessageBox.Show("Failed to load image!", "Load Fail", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                }
            } while (res == DialogResult.Retry);

            if (res == DialogResult.Cancel) Close();
            comboBox1.DataSource = Enum.GetNames(typeof(Filter));
        }

        private void loadPhoto()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                backend.Load(openFileDialog1.FileName);
            }
            else
            {
                throw new Exception();
            }
            pictureBox1.Image = backend.FilteredImage;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            backend.ApplyFilter((Filter) comboBox1.SelectedIndex);
            backend.progressEvent += progressAchieved;
            pictureBox1.Image = (Image) backend.FilteredImage;
        }

        private void buttonImg_Click(object sender, EventArgs e)
        {            
            try
            {
                loadPhoto();
            }
            catch { }
        }

        private void progressAchieved(int percentage)
        {
            progressBar1.Value = percentage;
        }
    }
}
