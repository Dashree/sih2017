namespace client
{
    partial class FileUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileUpload));
            this.CollegeIdTxt = new System.Windows.Forms.TextBox();
            this.ExamIdTxt = new System.Windows.Forms.MaskedTextBox();
            this.CollegeIdLabel = new System.Windows.Forms.Label();
            this.ExamIdLabel = new System.Windows.Forms.Label();
            this.UploadBtn = new System.Windows.Forms.Button();
            this.ImgeFolder = new System.Windows.Forms.TextBox();
            this.ImageFolderLabel = new System.Windows.Forms.Label();
            this.DirDialogBtn = new System.Windows.Forms.Button();
            this.LogoutBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CollegeIdTxt
            // 
            this.CollegeIdTxt.Cursor = System.Windows.Forms.Cursors.Default;
            this.CollegeIdTxt.Location = new System.Drawing.Point(331, 12);
            this.CollegeIdTxt.Name = "CollegeIdTxt";
            this.CollegeIdTxt.Size = new System.Drawing.Size(201, 20);
            this.CollegeIdTxt.TabIndex = 0;
            // 
            // ExamIdTxt
            // 
            this.ExamIdTxt.Cursor = System.Windows.Forms.Cursors.Default;
            this.ExamIdTxt.Location = new System.Drawing.Point(331, 54);
            this.ExamIdTxt.Name = "ExamIdTxt";
            this.ExamIdTxt.Size = new System.Drawing.Size(201, 20);
            this.ExamIdTxt.TabIndex = 1;
            this.ExamIdTxt.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.ExamIdTxt_MaskInputRejected);
            // 
            // CollegeIdLabel
            // 
            this.CollegeIdLabel.AutoSize = true;
            this.CollegeIdLabel.Location = new System.Drawing.Point(245, 18);
            this.CollegeIdLabel.Name = "CollegeIdLabel";
            this.CollegeIdLabel.Size = new System.Drawing.Size(73, 13);
            this.CollegeIdLabel.TabIndex = 2;
            this.CollegeIdLabel.Text = "College Name";
            // 
            // ExamIdLabel
            // 
            this.ExamIdLabel.AutoSize = true;
            this.ExamIdLabel.Location = new System.Drawing.Point(271, 58);
            this.ExamIdLabel.Name = "ExamIdLabel";
            this.ExamIdLabel.Size = new System.Drawing.Size(47, 13);
            this.ExamIdLabel.TabIndex = 3;
            this.ExamIdLabel.Text = "Exam ID";
            // 
            // UploadBtn
            // 
            this.UploadBtn.Enabled = false;
            this.UploadBtn.Location = new System.Drawing.Point(278, 140);
            this.UploadBtn.Name = "UploadBtn";
            this.UploadBtn.Size = new System.Drawing.Size(121, 28);
            this.UploadBtn.TabIndex = 4;
            this.UploadBtn.Text = "Start Upload";
            this.UploadBtn.UseVisualStyleBackColor = true;
            this.UploadBtn.Click += new System.EventHandler(this.StartUploadClick);
            // 
            // ImgeFolder
            // 
            this.ImgeFolder.Location = new System.Drawing.Point(331, 92);
            this.ImgeFolder.Margin = new System.Windows.Forms.Padding(2);
            this.ImgeFolder.Name = "ImgeFolder";
            this.ImgeFolder.Size = new System.Drawing.Size(201, 20);
            this.ImgeFolder.TabIndex = 6;
            // 
            // ImageFolderLabel
            // 
            this.ImageFolderLabel.AutoSize = true;
            this.ImageFolderLabel.Location = new System.Drawing.Point(249, 95);
            this.ImageFolderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ImageFolderLabel.Name = "ImageFolderLabel";
            this.ImageFolderLabel.Size = new System.Drawing.Size(68, 13);
            this.ImageFolderLabel.TabIndex = 7;
            this.ImageFolderLabel.Text = "Image Folder";
            // 
            // DirDialogBtn
            // 
            this.DirDialogBtn.Location = new System.Drawing.Point(546, 96);
            this.DirDialogBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DirDialogBtn.Name = "DirDialogBtn";
            this.DirDialogBtn.Size = new System.Drawing.Size(50, 15);
            this.DirDialogBtn.TabIndex = 8;
            this.DirDialogBtn.Text = "***";
            this.DirDialogBtn.UseVisualStyleBackColor = true;
            this.DirDialogBtn.Click += new System.EventHandler(this.DirDialogBtn_Click);
            // 
            // LogoutBtn
            // 
            this.LogoutBtn.Location = new System.Drawing.Point(428, 140);
            this.LogoutBtn.Name = "LogoutBtn";
            this.LogoutBtn.Size = new System.Drawing.Size(75, 28);
            this.LogoutBtn.TabIndex = 10;
            this.LogoutBtn.Text = "Logout";
            this.LogoutBtn.UseVisualStyleBackColor = true;
            this.LogoutBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(49, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(179, 165);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(228, 82);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(0, 13);
            this.label.TabIndex = 12;
            // 
            // FileUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(613, 381);
            this.Controls.Add(this.label);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LogoutBtn);
            this.Controls.Add(this.DirDialogBtn);
            this.Controls.Add(this.ImageFolderLabel);
            this.Controls.Add(this.ImgeFolder);
            this.Controls.Add(this.UploadBtn);
            this.Controls.Add(this.ExamIdLabel);
            this.Controls.Add(this.CollegeIdLabel);
            this.Controls.Add(this.ExamIdTxt);
            this.Controls.Add(this.CollegeIdTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FileUpload";
            this.Text = "FileUpload";
            this.Load += new System.EventHandler(this.FileUpload_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CollegeIdTxt;
        private System.Windows.Forms.MaskedTextBox ExamIdTxt;
        private System.Windows.Forms.Label CollegeIdLabel;
        private System.Windows.Forms.Label ExamIdLabel;
        private System.Windows.Forms.Button UploadBtn;
        private System.Windows.Forms.TextBox ImgeFolder;
        private System.Windows.Forms.Label ImageFolderLabel;
        private System.Windows.Forms.Button DirDialogBtn;
        private System.Windows.Forms.Button LogoutBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label;
    }
}