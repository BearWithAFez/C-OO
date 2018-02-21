using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlobalTools;
using LogicInterface;
using LogicImplementation;

namespace GUI
{
    public partial class Form1 : Form
    {
        private IMD5CollisionCalculator calculator = new MD5CollisionCalculator();
        private String hash = "";
        private String password = "";
        private decimal possibilities = 0;
        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Value = 4;
            var generator = new PasswordGenerator((int)numericUpDown1.Value);
            possibilities = generator.Count();
            passwordLbl.Text = $"passwords: {possibilities:N0}";
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            var generator = new PasswordGenerator((int)numericUpDown1.Value);
            possibilities = generator.Count();
            passwordLbl.Text = $"passwords: {possibilities:N0}";

            if (textBoxPassword.Text.Trim().Length == (int)numericUpDown1.Value)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                hash = "";
                password = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            password = textBoxPassword.Text.Trim();
            hash = MD5Calculator.GetHash(password);
            textBoxHash.Text = hash;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (hash != "")
            {
                calculator.NrOfWorkerTasks = (int) numericUpDown2.Value;
                calculator.ProgressChanged += progressAchieved;
                calculator.CollisionFound += collisionAchieved;
                calculator.StartCalculatingMD5Collision(hash,(int)numericUpDown1.Value);

                buttonAfbreken.Enabled = true;
                button2.Enabled = false;
            }            
        }

        private void buttonAfbreken_Click(object sender, EventArgs e)
        {
            calculator.Abort();
            calculator.ProgressChanged -= progressAchieved;
            calculator.CollisionFound -= collisionAchieved;
            buttonAfbreken.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            calculator.Close();
            calculator.ProgressChanged -= progressAchieved;
            calculator.CollisionFound -= collisionAchieved;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPassword.Text.Trim().Length == (int)numericUpDown1.Value)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                hash = "";
                password = "";
            }
        }

        private void textBoxHash_TextChanged(object sender, EventArgs e)
        {
            if (textBoxHash.Text.Trim() != "")
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void progressAchieved(decimal done)
        {
            progressBar.Value =(((int)done)*100)/((int)possibilities);
        }

        private void collisionAchieved(string collision)
        {
            textBoxCollisions.Text += collision + "\n";
        }
    }
}
