namespace Opgave_3b
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonRecalculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUDIterations = new System.Windows.Forms.NumericUpDown();
            this.numericUDHeightstep = new System.Windows.Forms.NumericUpDown();
            this.PictureName = new System.Windows.Forms.TextBox();
            this.LoadScreen = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDHeightstep)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 50);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(400, 300);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(252, 19);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(337, 19);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonRecalculate
            // 
            this.buttonRecalculate.Location = new System.Drawing.Point(466, 179);
            this.buttonRecalculate.Name = "buttonRecalculate";
            this.buttonRecalculate.Size = new System.Drawing.Size(75, 23);
            this.buttonRecalculate.TabIndex = 3;
            this.buttonRecalculate.Text = "Recalculate";
            this.buttonRecalculate.UseVisualStyleBackColor = true;
            this.buttonRecalculate.Click += new System.EventHandler(this.buttonRecalculate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Picture name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(419, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Heightstep:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(419, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Iterations:";
            // 
            // numericUDIterations
            // 
            this.numericUDIterations.Location = new System.Drawing.Point(486, 153);
            this.numericUDIterations.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUDIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUDIterations.Name = "numericUDIterations";
            this.numericUDIterations.Size = new System.Drawing.Size(55, 20);
            this.numericUDIterations.TabIndex = 7;
            this.numericUDIterations.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUDHeightstep
            // 
            this.numericUDHeightstep.Location = new System.Drawing.Point(486, 127);
            this.numericUDHeightstep.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericUDHeightstep.Name = "numericUDHeightstep";
            this.numericUDHeightstep.Size = new System.Drawing.Size(55, 20);
            this.numericUDHeightstep.TabIndex = 8;
            this.numericUDHeightstep.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // PictureName
            // 
            this.PictureName.Location = new System.Drawing.Point(87, 19);
            this.PictureName.Name = "PictureName";
            this.PictureName.Size = new System.Drawing.Size(159, 20);
            this.PictureName.TabIndex = 9;
            // 
            // LoadScreen
            // 
            this.LoadScreen.FileName = "openFileDialog1";
            this.LoadScreen.Filter = "Pointdinges|*.bin";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 357);
            this.Controls.Add(this.PictureName);
            this.Controls.Add(this.numericUDHeightstep);
            this.Controls.Add(this.numericUDIterations);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRecalculate);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Landscape generator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDHeightstep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonRecalculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUDIterations;
        private System.Windows.Forms.NumericUpDown numericUDHeightstep;
        private System.Windows.Forms.TextBox PictureName;
        private System.Windows.Forms.OpenFileDialog LoadScreen;
    }
}

