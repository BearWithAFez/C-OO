namespace WaveFun
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
            this.play = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // play
            // 
            this.play.Enabled = false;
            this.play.Location = new System.Drawing.Point(240, 28);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(116, 104);
            this.play.TabIndex = 0;
            this.play.Text = "SPORTPALEIS MAKE SOME NOISE!";
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 28);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(222, 311);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // save
            // 
            this.save.Enabled = false;
            this.save.Location = new System.Drawing.Point(241, 233);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(115, 105);
            this.save.TabIndex = 2;
            this.save.Text = "How jong dees gaan we toch bijhoude, éh?";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 351);
            this.Controls.Add(this.save);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.play);
            this.Name = "Form1";
            this.Text = "WaveFun";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

