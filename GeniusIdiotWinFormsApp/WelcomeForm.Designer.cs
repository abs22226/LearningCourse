namespace GeniusIdiotWinFormsApp
{
    partial class WelcomeForm
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
            inputNameLabel = new Label();
            UserNameTextBox = new TextBox();
            startButton = new Button();
            commentLabel = new Label();
            SuspendLayout();
            // 
            // inputNameLabel
            // 
            inputNameLabel.AutoSize = true;
            inputNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            inputNameLabel.Location = new Point(30, 31);
            inputNameLabel.Name = "inputNameLabel";
            inputNameLabel.Size = new Size(144, 21);
            inputNameLabel.TabIndex = 1;
            inputNameLabel.Text = "Введите ваше имя:\r";
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            UserNameTextBox.Location = new Point(30, 76);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new Size(355, 29);
            UserNameTextBox.TabIndex = 2;
            // 
            // startButton
            // 
            startButton.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            startButton.Location = new Point(30, 174);
            startButton.Name = "startButton";
            startButton.Size = new Size(355, 69);
            startButton.TabIndex = 3;
            startButton.Text = "Начать";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += StartButton_Click;
            // 
            // commentLabel
            // 
            commentLabel.AutoSize = true;
            commentLabel.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            commentLabel.Location = new Point(30, 119);
            commentLabel.Name = "commentLabel";
            commentLabel.Size = new Size(164, 21);
            commentLabel.TabIndex = 4;
            commentLabel.Text = "Текст комментария";
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 292);
            Controls.Add(commentLabel);
            Controls.Add(startButton);
            Controls.Add(UserNameTextBox);
            Controls.Add(inputNameLabel);
            MaximumSize = new Size(430, 331);
            MinimumSize = new Size(430, 331);
            Name = "WelcomeForm";
            Text = "Регистрация";
            Load += WelcomeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label inputNameLabel;
        public TextBox UserNameTextBox;
        private Button startButton;
        private Label commentLabel;
    }
}