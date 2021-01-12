
namespace price
{
    partial class Price
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFile = new System.Windows.Forms.Button();
            this.saveAt = new System.Windows.Forms.Button();
            this.file_location = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(345, 12);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(75, 23);
            this.openFile.TabIndex = 0;
            this.openFile.Text = "Файл";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // saveAt
            // 
            this.saveAt.Location = new System.Drawing.Point(345, 41);
            this.saveAt.Name = "saveAt";
            this.saveAt.Size = new System.Drawing.Size(75, 23);
            this.saveAt.TabIndex = 1;
            this.saveAt.Text = "Сохранить";
            this.saveAt.UseVisualStyleBackColor = true;
            this.saveAt.Click += new System.EventHandler(this.SaveAt_Click);
            // 
            // file_location
            // 
            this.file_location.Location = new System.Drawing.Point(12, 12);
            this.file_location.Name = "file_location";
            this.file_location.Size = new System.Drawing.Size(327, 23);
            this.file_location.TabIndex = 3;
            // 
            // openFileDialog
            // 
            this.openFileDialog.SupportMultiDottedExtensions = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xlsm";
            this.saveFileDialog.FileName = "*.xlsm";
            // 
            // Price
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 71);
            this.Controls.Add(this.file_location);
            this.Controls.Add(this.saveAt);
            this.Controls.Add(this.openFile);
            this.Name = "Price";
            this.Text = "Создать прейскурант";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Button saveAt;
        private System.Windows.Forms.TextBox file_location;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

