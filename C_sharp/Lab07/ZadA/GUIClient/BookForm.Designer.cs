
namespace GUIClient
{
    partial class BookForm
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
            this.AddButton = new System.Windows.Forms.Button();
            this.ModifyButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.MyDataInfoButton = new System.Windows.Forms.Button();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.BooksListBox = new System.Windows.Forms.ListBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.MyDataClientButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(12, 12);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(77, 77);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ModifyButton
            // 
            this.ModifyButton.Location = new System.Drawing.Point(95, 12);
            this.ModifyButton.Name = "ModifyButton";
            this.ModifyButton.Size = new System.Drawing.Size(77, 77);
            this.ModifyButton.TabIndex = 1;
            this.ModifyButton.Text = "Modify";
            this.ModifyButton.UseVisualStyleBackColor = true;
            this.ModifyButton.Click += new System.EventHandler(this.ModifyButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(178, 12);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(77, 77);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // MyDataInfoButton
            // 
            this.MyDataInfoButton.Location = new System.Drawing.Point(595, 12);
            this.MyDataInfoButton.Name = "MyDataInfoButton";
            this.MyDataInfoButton.Size = new System.Drawing.Size(94, 77);
            this.MyDataInfoButton.TabIndex = 3;
            this.MyDataInfoButton.Text = "MyDataService";
            this.MyDataInfoButton.UseVisualStyleBackColor = true;
            this.MyDataInfoButton.Click += new System.EventHandler(this.MyDataInfoButton_Click);
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Enabled = false;
            this.TitleTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TitleTextBox.Location = new System.Drawing.Point(12, 95);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(677, 20);
            this.TitleTextBox.TabIndex = 4;
            // 
            // BooksListBox
            // 
            this.BooksListBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BooksListBox.FormattingEnabled = true;
            this.BooksListBox.Location = new System.Drawing.Point(12, 121);
            this.BooksListBox.Name = "BooksListBox";
            this.BooksListBox.Size = new System.Drawing.Size(677, 316);
            this.BooksListBox.TabIndex = 5;
            this.BooksListBox.SelectedIndexChanged += new System.EventHandler(this.BooksListBox_SelectedIndexChanged);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(261, 12);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(77, 77);
            this.RefreshButton.TabIndex = 6;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // MyDataClientButton
            // 
            this.MyDataClientButton.Location = new System.Drawing.Point(495, 12);
            this.MyDataClientButton.Name = "MyDataClientButton";
            this.MyDataClientButton.Size = new System.Drawing.Size(94, 77);
            this.MyDataClientButton.TabIndex = 7;
            this.MyDataClientButton.Text = "MyDataClient";
            this.MyDataClientButton.UseVisualStyleBackColor = true;
            this.MyDataClientButton.Click += new System.EventHandler(this.MyDataClientButton_Click);
            // 
            // BookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 450);
            this.Controls.Add(this.MyDataClientButton);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.BooksListBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.MyDataInfoButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.ModifyButton);
            this.Controls.Add(this.AddButton);
            this.Name = "BookForm";
            this.Text = "BookForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button ModifyButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button MyDataInfoButton;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.ListBox BooksListBox;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button MyDataClientButton;
    }
}