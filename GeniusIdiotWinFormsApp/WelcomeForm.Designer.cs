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
            StartButton = new Button();
            CommentLabel = new Label();
            SuspendLayout();
            // 
            // inputNameLabel
            // 
            inputNameLabel.AutoSize = true;
            inputNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            inputNameLabel.Location = new Point(30, 31);
            inputNameLabel.Name = "inputNameLabel";
            inputNameLabel.Size = new Size(175, 42);
            inputNameLabel.TabIndex = 1;
            inputNameLabel.Text = "Введите ваше имя:\r(символ # недопустим)";
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            UserNameTextBox.Location = new Point(30, 97);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new Size(355, 29);
            UserNameTextBox.TabIndex = 2;
            // 
            // StartButton
            // 
            StartButton.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            StartButton.Location = new Point(30, 195);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(355, 69);
            StartButton.TabIndex = 3;
            StartButton.Text = "Начать";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // CommentLabel
            // 
            CommentLabel.AutoSize = true;
            CommentLabel.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            CommentLabel.Location = new Point(30, 140);
            CommentLabel.Name = "CommentLabel";
            CommentLabel.Size = new Size(164, 21);
            CommentLabel.TabIndex = 4;
            CommentLabel.Text = "Текст комментария";
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 313);
            Controls.Add(CommentLabel);
            Controls.Add(StartButton);
            Controls.Add(UserNameTextBox);
            Controls.Add(inputNameLabel);
            MaximumSize = new Size(430, 352);
            MinimumSize = new Size(430, 352);
            Name = "WelcomeForm";
            Text = "Регистрация";
            Load += WelcomeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label inputNameLabel;
        public TextBox UserNameTextBox;
        private Button StartButton;
        private Label CommentLabel;
    }
}