namespace GeniusIdiotWinFormsApp
{
    partial class AddQuestionForm
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
            addedQuestionTextBox = new TextBox();
            label2 = new Label();
            numericAnswerTextBox = new TextBox();
            addingButton = new Button();
            answerCommentLabel = new Label();
            questionCommentLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(30, 31);
            label1.Name = "label1";
            label1.Size = new Size(186, 21);
            label1.TabIndex = 0;
            label1.Text = "Введите вопрос:";
            // 
            // addedQuestionTextBox
            // 
            addedQuestionTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            addedQuestionTextBox.Location = new Point(30, 76);
            addedQuestionTextBox.Name = "addedQuestionTextBox";
            addedQuestionTextBox.Size = new Size(355, 29);
            addedQuestionTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(30, 163);
            label2.Name = "label2";
            label2.Size = new Size(186, 21);
            label2.TabIndex = 2;
            label2.Text = "Введите числовой ответ:";
            // 
            // numericAnswerTextBox
            // 
            numericAnswerTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericAnswerTextBox.Location = new Point(30, 208);
            numericAnswerTextBox.Name = "numericAnswerTextBox";
            numericAnswerTextBox.Size = new Size(355, 29);
            numericAnswerTextBox.TabIndex = 3;
            // 
            // addingButton
            // 
            addingButton.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            addingButton.Location = new Point(30, 306);
            addingButton.Name = "addingButton";
            addingButton.Size = new Size(355, 69);
            addingButton.TabIndex = 4;
            addingButton.Text = "Добавить";
            addingButton.UseVisualStyleBackColor = true;
            addingButton.Click += AddingButton_Click;
            // 
            // answerCommentLabel
            // 
            answerCommentLabel.AutoSize = true;
            answerCommentLabel.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            answerCommentLabel.Location = new Point(30, 251);
            answerCommentLabel.Name = "answerCommentLabel";
            answerCommentLabel.Size = new Size(164, 21);
            answerCommentLabel.TabIndex = 5;
            answerCommentLabel.Text = "Текст комментария";
            // 
            // questionCommentLabel
            // 
            questionCommentLabel.AutoSize = true;
            questionCommentLabel.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            questionCommentLabel.Location = new Point(30, 119);
            questionCommentLabel.Name = "questionCommentLabel";
            questionCommentLabel.Size = new Size(164, 21);
            questionCommentLabel.TabIndex = 6;
            questionCommentLabel.Text = "Текст комментария";
            // 
            // AddQuestionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 429);
            Controls.Add(questionCommentLabel);
            Controls.Add(answerCommentLabel);
            Controls.Add(addingButton);
            Controls.Add(numericAnswerTextBox);
            Controls.Add(label2);
            Controls.Add(addedQuestionTextBox);
            Controls.Add(label1);
            MaximumSize = new Size(430, 468);
            MinimumSize = new Size(430, 468);
            Name = "AddQuestionForm";
            Text = "Добавление вопроса";
            Load += AddQuestionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox addedQuestionTextBox;
        private Label label2;
        private TextBox numericAnswerTextBox;
        private Button addingButton;
        private Label answerCommentLabel;
        private Label questionCommentLabel;
    }
}