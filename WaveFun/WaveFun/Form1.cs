using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace WaveFun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var stream = new MemoryStream())
            {
                List<Note> notes = new translate(textBox1.Text).noten;
                WaveGenerator wave = new WaveGenerator(notes);
                wave.Save(stream);

                stream.Seek(0, SeekOrigin.Begin);
                SoundPlayer player = new SoundPlayer(stream);
                player.Play();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                if (saveFileDialog1.FileName.IndexOf('.') == -1)
                {
                    saveFileDialog1.FileName += ".wav";
                }
                WaveGenerator wave = new WaveGenerator(new translate(textBox1.Text).noten);
                wave.Save(saveFileDialog1.FileName);
                SoundPlayer player = new SoundPlayer(saveFileDialog1.FileName);
                player.Play();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0)
            {
                save.Enabled = true;
                play.Enabled = true;
            }
            else
            {
                save.Enabled = false;
                play.Enabled = false;
            }
        }
    }
}
