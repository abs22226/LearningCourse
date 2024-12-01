namespace GeniusIdiotWinFormsApp
{
    partial class MainForm
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
            NextButton = new Button();
            QuestionNumberLabel = new Label();
            QuestionTextLabel = new Label();
            UserAnswerTextBox = new TextBox();
            CommentTextLabel = new Label();
            SuspendLayout();
            // 
            // NextButton
            // 
            NextButton.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            NextButton.Location = new Point(56, 327);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(296, 69);
            NextButton.TabIndex = 0;
            NextButton.Text = "Далее";
            NextButton.UseVisualStyleBackColor = true;
            NextButton.Click += NextButton_Click;
            // 
            // QuestionNumberLabel
            // 
            QuestionNumberLabel.AutoSize = true;
            QuestionNumberLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            QuestionNumberLabel.Location = new Point(56, 42);
            QuestionNumberLabel.Name = "QuestionNumberLabel";
            QuestionNumberLabel.Size = new Size(97, 21);
            QuestionNumberLabel.TabIndex = 1;
            QuestionNumberLabel.Text = "Вопрос № 1";
            // 
            // QuestionTextLabel
            // 
            QuestionTextLabel.AutoSize = true;
            QuestionTextLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            QuestionTextLabel.Location = new Point(56, 120);
            QuestionTextLabel.Name = "QuestionTextLabel";
            QuestionTextLabel.Size = new Size(111, 21);
            QuestionTextLabel.TabIndex = 2;
            QuestionTextLabel.Text = "Текст вопроса";
            // 
            // UserAnswerTextBox
            // 
            UserAnswerTextBox.Location = new Point(56, 219);
            UserAnswerTextBox.Name = "UserAnswerTextBox";
            UserAnswerTextBox.Size = new Size(296, 23);
            UserAnswerTextBox.TabIndex = 3;
            // 
            // CommentTextLabel
            // 
            CommentTextLabel.AutoSize = true;
            CommentTextLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CommentTextLabel.Location = new Point(56, 261);
            CommentTextLabel.Name = "CommentTextLabel";
            CommentTextLabel.Size = new Size(149, 21);
            CommentTextLabel.TabIndex = 4;
            CommentTextLabel.Text = "Текст комментария";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 450);
            Controls.Add(CommentTextLabel);
            Controls.Add(UserAnswerTextBox);
            Controls.Add(QuestionTextLabel);
            Controls.Add(QuestionNumberLabel);
            Controls.Add(NextButton);
            Name = "MainForm";
            Text = "Гений-Идиот";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button NextButton;
        private Label QuestionNumberLabel;
        private Label QuestionTextLabel;
        private TextBox UserAnswerTextBox;
        private Label CommentTextLabel;
    }
}
