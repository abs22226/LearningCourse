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
            menuStrip1 = new MenuStrip();
            менюToolStripMenuItem = new ToolStripMenuItem();
            показатьИсториюToolStripMenuItem = new ToolStripMenuItem();
            перезапускToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            новыйТестToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
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
            QuestionNumberLabel.Location = new Point(56, 55);
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
            QuestionTextLabel.MaximumSize = new Size(296, 90);
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
            CommentTextLabel.MaximumSize = new Size(296, 90);
            CommentTextLabel.Name = "CommentTextLabel";
            CommentTextLabel.Size = new Size(149, 21);
            CommentTextLabel.TabIndex = 4;
            CommentTextLabel.Text = "Текст комментария";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { менюToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(414, 27);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            менюToolStripMenuItem.BackColor = SystemColors.Control;
            менюToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { новыйТестToolStripMenuItem, показатьИсториюToolStripMenuItem, перезапускToolStripMenuItem, выходToolStripMenuItem });
            менюToolStripMenuItem.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            менюToolStripMenuItem.Size = new Size(65, 23);
            менюToolStripMenuItem.Text = "МЕНЮ";
            // 
            // показатьИсториюToolStripMenuItem
            // 
            показатьИсториюToolStripMenuItem.Name = "показатьИсториюToolStripMenuItem";
            показатьИсториюToolStripMenuItem.Size = new Size(195, 24);
            показатьИсториюToolStripMenuItem.Text = "Показать историю";
            показатьИсториюToolStripMenuItem.Click += ПоказатьИсториюToolStripMenuItem_Click;
            // 
            // перезапускToolStripMenuItem
            // 
            перезапускToolStripMenuItem.Name = "перезапускToolStripMenuItem";
            перезапускToolStripMenuItem.Size = new Size(195, 24);
            перезапускToolStripMenuItem.Text = "Перезапуск";
            перезапускToolStripMenuItem.Click += ПерезапускToolStripMenuItem_Click;
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(195, 24);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += ВыходToolStripMenuItem_Click;
            // 
            // новыйТестToolStripMenuItem
            // 
            новыйТестToolStripMenuItem.Name = "новыйТестToolStripMenuItem";
            новыйТестToolStripMenuItem.Size = new Size(195, 24);
            новыйТестToolStripMenuItem.Text = "Новый тест";
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
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximumSize = new Size(430, 489);
            MinimumSize = new Size(430, 489);
            Name = "MainForm";
            Text = "Гений-Идиот";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button NextButton;
        private Label QuestionNumberLabel;
        private Label QuestionTextLabel;
        private TextBox UserAnswerTextBox;
        private Label CommentTextLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem менюToolStripMenuItem;
        private ToolStripMenuItem показатьИсториюToolStripMenuItem;
        private ToolStripMenuItem перезапускToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem новыйТестToolStripMenuItem;
    }
}
