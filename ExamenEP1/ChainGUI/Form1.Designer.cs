namespace ChainGUI
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
            this.chainsTextBox = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.textBoxProgress = new System.Windows.Forms.TextBox();
            this.textBoxControle = new System.Windows.Forms.TextBox();
            this.textBoxTijd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chainsTextBox
            // 
            this.chainsTextBox.Location = new System.Drawing.Point(13, 13);
            this.chainsTextBox.Multiline = true;
            this.chainsTextBox.Name = "chainsTextBox";
            this.chainsTextBox.Size = new System.Drawing.Size(131, 429);
            this.chainsTextBox.TabIndex = 0;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(198, 149);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(295, 149);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // textBoxProgress
            // 
            this.textBoxProgress.Location = new System.Drawing.Point(198, 178);
            this.textBoxProgress.Name = "textBoxProgress";
            this.textBoxProgress.ReadOnly = true;
            this.textBoxProgress.Size = new System.Drawing.Size(172, 20);
            this.textBoxProgress.TabIndex = 3;
            // 
            // textBoxControle
            // 
            this.textBoxControle.Location = new System.Drawing.Point(198, 254);
            this.textBoxControle.Name = "textBoxControle";
            this.textBoxControle.ReadOnly = true;
            this.textBoxControle.Size = new System.Drawing.Size(172, 20);
            this.textBoxControle.TabIndex = 4;
            // 
            // textBoxTijd
            // 
            this.textBoxTijd.Location = new System.Drawing.Point(198, 216);
            this.textBoxTijd.Name = "textBoxTijd";
            this.textBoxTijd.ReadOnly = true;
            this.textBoxTijd.Size = new System.Drawing.Size(172, 20);
            this.textBoxTijd.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "progress";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "tijd";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "controle";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 454);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTijd);
            this.Controls.Add(this.textBoxControle);
            this.Controls.Add(this.textBoxProgress);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.chainsTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox chainsTextBox;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TextBox textBoxProgress;
        private System.Windows.Forms.TextBox textBoxControle;
        private System.Windows.Forms.TextBox textBoxTijd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

