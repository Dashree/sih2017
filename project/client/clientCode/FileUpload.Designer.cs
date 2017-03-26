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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UploadBtn = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.ImgeFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.CollegeIdTxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ExamIdTxt
            // 
            this.ExamIdTxt.Cursor = System.Windows.Forms.Cursors.Default;
            this.ExamIdTxt.Location = new System.Drawing.Point(162, 79);
            this.ExamIdTxt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ExamIdTxt.Name = "ExamIdTxt";
            this.ExamIdTxt.Size = new System.Drawing.Size(300, 26);
            this.ExamIdTxt.TabIndex = 1;
            this.ExamIdTxt.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "College Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Exam ID";
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
            this.UploadBtn.Click += new System.EventHandler(this.Files_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(608, 138);
            this.label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(0, 20);
            this.label.TabIndex = 5;
            this.label.Visible = false;
            // 
            // ImgeFolder
            // 
            this.ImgeFolder.Location = new System.Drawing.Point(162, 138);
            this.ImgeFolder.Name = "ImgeFolder";
            this.ImgeFolder.ReadOnly = true;
            this.ImgeFolder.Size = new System.Drawing.Size(300, 26);
            this.ImgeFolder.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Image Folder";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // DirDialogBtn
            // 
            this.DirDialogBtn.Location = new System.Drawing.Point(485, 141);
            this.DirDialogBtn.Name = "DirDialogBtn";
            this.DirDialogBtn.Size = new System.Drawing.Size(75, 23);
            this.DirDialogBtn.TabIndex = 8;
            this.DirDialogBtn.Text = "...";
            this.DirDialogBtn.UseVisualStyleBackColor = true;
            // 
            // FileUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 731);
            this.Controls.Add(this.DirDialogBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ImgeFolder);
            this.Controls.Add(this.label);
            this.Controls.Add(this.UploadBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExamIdTxt);
            this.Controls.Add(this.CollegeIdTxt);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button UploadBtn;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox ImgeFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button DirDialogBtn;
    }
}