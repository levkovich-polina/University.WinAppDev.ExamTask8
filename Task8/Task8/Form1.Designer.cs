namespace Task8
{
    partial class Form1
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
            this.Panel = new System.Windows.Forms.Panel();
            this.NewPasswordButton = new System.Windows.Forms.Button();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.SetLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.SystemColors.Window;
            this.Panel.Location = new System.Drawing.Point(19, 11);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(466, 387);
            this.Panel.TabIndex = 0;
            this.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);
            this.Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.Panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            this.Panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseUp);
            // 
            // NewPasswordButton
            // 
            this.NewPasswordButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.NewPasswordButton.Location = new System.Drawing.Point(544, 27);
            this.NewPasswordButton.Name = "NewPasswordButton";
            this.NewPasswordButton.Size = new System.Drawing.Size(217, 61);
            this.NewPasswordButton.TabIndex = 1;
            this.NewPasswordButton.Text = "Задать новый ключ";
            this.NewPasswordButton.UseVisualStyleBackColor = true;
            this.NewPasswordButton.Click += new System.EventHandler(this.NewPasswordButton_Click);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(549, 164);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(0, 20);
            this.PasswordLabel.TabIndex = 2;
            // 
            // SetLabel
            // 
            this.SetLabel.AutoSize = true;
            this.SetLabel.Location = new System.Drawing.Point(546, 221);
            this.SetLabel.Name = "SetLabel";
            this.SetLabel.Size = new System.Drawing.Size(0, 20);
            this.SetLabel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(523, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Заданный пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(523, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Вводимый пароль";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SetLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.NewPasswordButton);
            this.Controls.Add(this.Panel);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel Panel;
        private Button NewPasswordButton;
        private Label PasswordLabel;
        private Label SetLabel;
        private Label label2;
        private Label label3;
    }
}