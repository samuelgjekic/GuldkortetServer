namespace GuldkortetServer
{
    partial class mainForm
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
            label1 = new Label();
            listUsers = new ListBox();
            txtStatus = new Label();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 4;
            label1.Text = "Senaste användare:";
            // 
            // listUsers
            // 
            listUsers.FormattingEnabled = true;
            listUsers.ItemHeight = 15;
            listUsers.Location = new Point(12, 27);
            listUsers.Name = "listUsers";
            listUsers.Size = new Size(413, 229);
            listUsers.TabIndex = 5;
            // 
            // txtStatus
            // 
            txtStatus.AutoSize = true;
            txtStatus.Location = new Point(199, 288);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(39, 15);
            txtStatus.TabIndex = 7;
            txtStatus.Text = "Status";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(164, 262);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(109, 23);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Uppdatera Lista";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 311);
            Controls.Add(btnUpdate);
            Controls.Add(txtStatus);
            Controls.Add(listUsers);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "mainForm";
            Text = "Guldkortet Server - Samuel Gjekic";
            Load += mainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private ListBox listUsers;
        private Label txtStatus;
        private Button btnUpdate;
    }
}