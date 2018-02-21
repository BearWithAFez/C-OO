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

namespace ChainGUI
{
    public partial class Form1 : Form
    {
        IChainChecker backend = new ChainChecker();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            backend.ProgressChanged += update;
            backend.CalculationFinished += controle;
            backend.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            backend.Abort();
        }

        private void update()
        {
            
                int percent = backend.PercentageCompleted;
                IDictionary<int, long> display = backend.ChainLengthDictionary;
                if (percent == 99) percent = 100;
                textBoxProgress.Text = "" + percent + "%";
                chainsTextBox.Text = "";
                foreach (var item in display)
                {
                    chainsTextBox.AppendText(item.Key + " => " + item.Value + "\n");
                }
                     
        }

        private void controle()
        {
            textBoxControle.Text = "" + backend.ControlNumber;
        }
    }
}
