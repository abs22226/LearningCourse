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
            label1 = new Label();
            inputNameLabel = new Label();
            UserNameTextBox = new TextBox();
            StartButton = new Button();
            CommentTextLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(73, 30);
            label1.Name = "label1";
            label1.Size = new Size(152, 21);
            label1.TabIndex = 0;
            label1.Text = "Добро пожаловать!";
            // 
            // inputNameLabel
            // 
            inputNameLabel.AutoSize = true;
            inputNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            inputNameLabel.Location = new Point(61, 69);
            inputNameLabel.Name = "inputNameLabel";
            inputNameLabel.Size = new Size(175, 42);
            inputNameLabel.TabIndex = 1;
            inputNameLabel.Text = "Введите ваше имя:\r(символ # недопустим)";
            inputNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            UserNameTextBox.Location = new Point(52, 136);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new Size(193, 29);
            UserNameTextBox.TabIndex = 2;
            // 
            // StartButton
            // 
            StartButton.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            StartButton.Location = new Point(86, 242);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(125, 48);
            StartButton.TabIndex = 3;
            StartButton.Text = "Начать";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // CommentTextLabel
            // 
            CommentTextLabel.AutoSize = true;
            CommentTextLabel.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            CommentTextLabel.Location = new Point(70, 182);
            CommentTextLabel.MaximumSize = new Size(193, 90);
            CommentTextLabel.Name = "CommentTextLabel";
            CommentTextLabel.Size = new Size(159, 42);
            CommentTextLabel.TabIndex = 4;
            CommentTextLabel.Text = "Необходимо ввести корректное имя!";
            CommentTextLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(301, 325);
            Controls.Add(CommentTextLabel);
            Controls.Add(StartButton);
            Controls.Add(UserNameTextBox);
            Controls.Add(inputNameLabel);
            Controls.Add(label1);
            Name = "WelcomeForm";
            Text = "WelcomeForm";
            Load += WelcomeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label inputNameLabel;
        public TextBox UserNameTextBox;
        private Button StartButton;
        private Label CommentTextLabel;
    }
}