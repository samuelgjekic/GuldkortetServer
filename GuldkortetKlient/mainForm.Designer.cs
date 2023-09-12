namespace GuldkortetKlient
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
            btnStart = new Button();
            btnSendBothCorrect = new Button();
            label2 = new Label();
            btnSendRightCard = new Button();
            btnSendrightuser = new Button();
            button1 = new Button();
            txtRecieve = new TextBox();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(131, 503);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(113, 33);
            btnStart.TabIndex = 1;
            btnStart.Text = "Anslut";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnSendBothCorrect
            // 
            btnSendBothCorrect.Location = new Point(131, 438);
            btnSendBothCorrect.Name = "btnSendBothCorrect";
            btnSendBothCorrect.Size = new Size(113, 41);
            btnSendBothCorrect.TabIndex = 2;
            btnSendBothCorrect.Text = "Skicka Rätt Användare + Kort";
            btnSendBothCorrect.UseVisualStyleBackColor = true;
            btnSendBothCorrect.Click += btnSendBothCorrect_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(113, 9);
            label2.Name = "label2";
            label2.Size = new Size(160, 25);
            label2.TabIndex = 3;
            label2.Text = "Klient Guldkortet";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // btnSendRightCard
            // 
            btnSendRightCard.Location = new Point(131, 374);
            btnSendRightCard.Name = "btnSendRightCard";
            btnSendRightCard.Size = new Size(113, 58);
            btnSendRightCard.TabIndex = 4;
            btnSendRightCard.Text = "Skicka rätt kortkod men inte användare";
            btnSendRightCard.UseVisualStyleBackColor = true;
            btnSendRightCard.Click += btnSendRightCard_Click;
            // 
            // btnSendrightuser
            // 
            btnSendrightuser.Location = new Point(131, 312);
            btnSendrightuser.Name = "btnSendrightuser";
            btnSendrightuser.Size = new Size(113, 56);
            btnSendrightuser.TabIndex = 5;
            btnSendrightuser.Text = "Skicka rätt användare men inte kort";
            btnSendrightuser.UseVisualStyleBackColor = true;
            btnSendrightuser.Click += btnSendrightuser_Click;
            // 
            // button1
            // 
            button1.Location = new Point(131, 250);
            button1.Name = "button1";
            button1.Size = new Size(113, 56);
            button1.TabIndex = 6;
            button1.Text = "Skicka båda fel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtRecieve
            // 
            txtRecieve.Location = new Point(45, 48);
            txtRecieve.Multiline = true;
            txtRecieve.Name = "txtRecieve";
            txtRecieve.ReadOnly = true;
            txtRecieve.Size = new Size(304, 196);
            txtRecieve.TabIndex = 7;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 548);
            Controls.Add(txtRecieve);
            Controls.Add(button1);
            Controls.Add(btnSendrightuser);
            Controls.Add(btnSendRightCard);
            Controls.Add(label2);
            Controls.Add(btnSendBothCorrect);
            Controls.Add(btnStart);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "mainForm";
            Text = "Guldkortet Klient";
            Load += mainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnStart;
        private Button btnSendBothCorrect;
        private Label label2;
        private Button btnSendRightCard;
        private Button btnSendrightuser;
        private Button button1;
        private TextBox txtRecieve;
    }
}