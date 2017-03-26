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
            this.CollegeIdTxt = new System.Windows.Forms.TextBox();
            this.ExamIdTxt = new System.Windows.Forms.MaskedTextBox();
            this.CollegeIdLabel = new System.Windows.Forms.Label();
            this.ExamIdLabel = new System.Windows.Forms.Label();
            this.UploadBtn = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.ImgeFolder = new System.Windows.Forms.TextBox();
            this.ImageFolderLabel = new System.Windows.Forms.Label();
            this.DirDialogBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CollegeIdTxt
            // 
            this.CollegeIdTxt.Cursor = System.Windows.Forms.Cursors.Default;
            this.CollegeIdTxt.Location = new System.Drawing.Point(162, 14);
            this.CollegeIdTxt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CollegeIdTxt.Name = "CollegeIdTxt";
            this.CollegeIdTxt.Size = new System.Drawing.Size(300, 26);
            this.CollegeIdTxt.TabIndex = 0;
            // 
            // ExamIdTxt
            // 
            this.ExamIdTxt.Cursor = System.Windows.Forms.Cursors.Default;
            this.ExamIdTxt.Location = new System.Drawing.Point(162, 79);
            this.ExamIdTxt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ExamIdTxt.Name = "ExamIdTxt";
            this.ExamIdTxt.Size = new System.Drawing.Size(300, 26);
            this.ExamIdTxt.TabIndex = 1;
            // 
            // CollegeIdLabel
            // 
            this.CollegeIdLabel.AutoSize = true;
            this.CollegeIdLabel.Enabled = false;
            this.CollegeIdLabel.Location = new System.Drawing.Point(34, 24);
            this.CollegeIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CollegeIdLabel.Name = "CollegeIdLabel";
            this.CollegeIdLabel.Size = new System.Drawing.Size(108, 20);
            this.CollegeIdLabel.TabIndex = 2;
            this.CollegeIdLabel.Text = "College Name";
            // 
            // ExamIdLabel
            // 
            this.ExamIdLabel.AutoSize = true;
            this.ExamIdLabel.Location = new System.Drawing.Point(72, 85);
            this.ExamIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ExamIdLabel.Name = "ExamIdLabel";
            this.ExamIdLabel.Size = new System.Drawing.Size(70, 20);
            this.ExamIdLabel.TabIndex = 3;
            this.ExamIdLabel.Text = "Exam ID";
            // 
            // UploadBtn
            // 
            this.UploadBtn.Location = new System.Drawing.Point(162, 201);
            this.UploadBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UploadBtn.Name = "UploadBtn";
            this.UploadBtn.Size = new System.Drawing.Size(213, 35);
            this.UploadBtn.TabIndex = 4;
            this.UploadBtn.Text = "Start Upload";
            this.UploadBtn.UseVisualStyleBackColor = true;
            this.UploadBtn.Click += new System.EventHandler(this.StartUploadClick);
            // 
            // ImgeFolder
            // 
            this.ImgeFolder.Location = new System.Drawing.Point(162, 138);
            this.ImgeFolder.Name = "ImgeFolder";
            this.ImgeFolder.ReadOnly = true;
            this.ImgeFolder.Size = new System.Drawing.Size(300, 26);
            this.ImgeFolder.TabIndex = 6;
            // 
            // ImageFolderLabel
            // 
            this.ImageFolderLabel.AutoSize = true;
            this.ImageFolderLabel.Enabled = false;
            this.ImageFolderLabel.Location = new System.Drawing.Point(39, 141);
            this.ImageFolderLabel.Name = "ImageFolderLabel";
            this.ImageFolderLabel.Size = new System.Drawing.Size(103, 20);
            this.ImageFolderLabel.TabIndex = 7;
            this.ImageFolderLabel.Text = "Image Folder";
            // 
            // DirDialogBtn
            // 
            this.DirDialogBtn.Location = new System.Drawing.Point(485, 141);
            this.DirDialogBtn.Name = "DirDialogBtn";
            this.DirDialogBtn.Size = new System.Drawing.Size(75, 23);
            this.DirDialogBtn.TabIndex = 8;
            this.DirDialogBtn.Text = "***";
            this.DirDialogBtn.UseVisualStyleBackColor = true;
            // 
            // FileUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 318);
            this.Controls.Add(this.DirDialogBtn);
            this.Controls.Add(this.ImageFolderLabel);
            this.Controls.Add(this.ImgeFolder);
            this.Controls.Add(this.label);
            this.Controls.Add(this.UploadBtn);
            this.Controls.Add(this.ExamIdLabel);
            this.Controls.Add(this.CollegeIdLabel);
            this.Controls.Add(this.ExamIdTxt);
            this.Controls.Add(this.CollegeIdTxt);
            this.Enabled = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FileUpload";
            this.Text = "FileUpload";
            this.Load += new System.EventHandler(this.FileUpload_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CollegeIdTxt;
        private System.Windows.Forms.MaskedTextBox ExamIdTxt;
        private System.Windows.Forms.Label CollegeIdLabel;
        private System.Windows.Forms.Label ExamIdLabel;
        private System.Windows.Forms.Button UploadBtn;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox ImgeFolder;
        private System.Windows.Forms.Label ImageFolderLabel;
        private System.Windows.Forms.Button DirDialogBtn;
    }
}