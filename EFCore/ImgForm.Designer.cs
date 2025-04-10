namespace EFCore
{
    partial class ImgForm
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
            label1 = new Label();
            bttnUploadPicture = new Button();
            pictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 20.2909088F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.FromArgb(255, 130, 163);
            label1.Location = new Point(194, 216);
            label1.Name = "label1";
            label1.Size = new Size(212, 42);
            label1.TabIndex = 0;
            label1.Text = "upload photo";
            // 
            // bttnUploadPicture
            // 
            bttnUploadPicture.BackColor = Color.FromArgb(255, 130, 163);
            bttnUploadPicture.Font = new Font("Segoe UI Semibold", 18.3272724F, FontStyle.Bold, GraphicsUnit.Point, 204);
            bttnUploadPicture.ForeColor = Color.White;
            bttnUploadPicture.Location = new Point(464, 210);
            bttnUploadPicture.Name = "bttnUploadPicture";
            bttnUploadPicture.Size = new Size(186, 56);
            bttnUploadPicture.TabIndex = 1;
            bttnUploadPicture.Text = "load";
            bttnUploadPicture.UseVisualStyleBackColor = false;
            bttnUploadPicture.Click += bttnUploadPicture_Click;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(322, 340);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(194, 219);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;
            // 
            // ImgForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 4, 68);
            ClientSize = new Size(843, 742);
            Controls.Add(pictureBox);
            Controls.Add(bttnUploadPicture);
            Controls.Add(label1);
            Name = "ImgForm";
            Text = "ImgForm";
            Load += ImgForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button bttnUploadPicture;
        private PictureBox pictureBox;
    }
}