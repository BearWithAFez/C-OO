namespace Opdracht1
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
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.imageLeft = new System.Windows.Forms.PictureBox();
            this.imageRight = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.redButton = new System.Windows.Forms.Button();
            this.greenButton = new System.Windows.Forms.Button();
            this.blueButton = new System.Windows.Forms.Button();
            this.resolutionButton = new System.Windows.Forms.Button();
            this.resolutionSlider = new System.Windows.Forms.TrackBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageRight)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.imageLeft, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.imageRight, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 2;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(684, 311);
            this.TableLayoutPanel1.TabIndex = 0;
            // 
            // imageLeft
            // 
            this.imageLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageLeft.Location = new System.Drawing.Point(3, 3);
            this.imageLeft.Name = "imageLeft";
            this.imageLeft.Size = new System.Drawing.Size(336, 242);
            this.imageLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageLeft.TabIndex = 0;
            this.imageLeft.TabStop = false;
            // 
            // imageRight
            // 
            this.imageRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageRight.Location = new System.Drawing.Point(345, 3);
            this.imageRight.Name = "imageRight";
            this.imageRight.Size = new System.Drawing.Size(336, 242);
            this.imageRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageRight.TabIndex = 1;
            this.imageRight.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.redButton);
            this.flowLayoutPanel1.Controls.Add(this.greenButton);
            this.flowLayoutPanel1.Controls.Add(this.blueButton);
            this.flowLayoutPanel1.Controls.Add(this.resolutionButton);
            this.flowLayoutPanel1.Controls.Add(this.resolutionSlider);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 251);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 15, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(678, 57);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // redButton
            // 
            this.redButton.Location = new System.Drawing.Point(23, 18);
            this.redButton.Name = "redButton";
            this.redButton.Size = new System.Drawing.Size(75, 23);
            this.redButton.TabIndex = 0;
            this.redButton.Text = "Only red";
            this.redButton.UseVisualStyleBackColor = true;
            this.redButton.Click += new System.EventHandler(this.redButton_Click);
            // 
            // greenButton
            // 
            this.greenButton.Location = new System.Drawing.Point(104, 18);
            this.greenButton.Name = "greenButton";
            this.greenButton.Size = new System.Drawing.Size(75, 23);
            this.greenButton.TabIndex = 1;
            this.greenButton.Text = "Only green";
            this.greenButton.UseVisualStyleBackColor = true;
            this.greenButton.Click += new System.EventHandler(this.greenButton_Click);
            // 
            // blueButton
            // 
            this.blueButton.Location = new System.Drawing.Point(185, 18);
            this.blueButton.Name = "blueButton";
            this.blueButton.Size = new System.Drawing.Size(75, 23);
            this.blueButton.TabIndex = 2;
            this.blueButton.Text = "Only blue";
            this.blueButton.UseVisualStyleBackColor = true;
            this.blueButton.Click += new System.EventHandler(this.blueButton_Click);
            // 
            // resolutionButton
            // 
            this.resolutionButton.Location = new System.Drawing.Point(266, 18);
            this.resolutionButton.Name = "resolutionButton";
            this.resolutionButton.Size = new System.Drawing.Size(75, 23);
            this.resolutionButton.TabIndex = 3;
            this.resolutionButton.Text = "Resolution";
            this.resolutionButton.UseVisualStyleBackColor = true;
            this.resolutionButton.Click += new System.EventHandler(this.resolutionButton_Click);
            // 
            // resolutionSlider
            // 
            this.resolutionSlider.Location = new System.Drawing.Point(347, 18);
            this.resolutionSlider.Maximum = 8;
            this.resolutionSlider.Name = "resolutionSlider";
            this.resolutionSlider.Size = new System.Drawing.Size(179, 45);
            this.resolutionSlider.TabIndex = 4;
            this.resolutionSlider.Value = 8;
            this.resolutionSlider.Visible = false;
            this.resolutionSlider.Scroll += new System.EventHandler(this.resolutionSlider_Scroll);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 311);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageRight)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionSlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        private System.Windows.Forms.PictureBox imageLeft;
        private System.Windows.Forms.PictureBox imageRight;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button redButton;
        private System.Windows.Forms.Button greenButton;
        private System.Windows.Forms.Button blueButton;
        private System.Windows.Forms.Button resolutionButton;
        private System.Windows.Forms.TrackBar resolutionSlider;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

