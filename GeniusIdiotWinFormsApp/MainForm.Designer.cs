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
            nextButton = new Button();
            questionNumberLabel = new Label();
            questionTextLabel = new Label();
            userAnswerTextBox = new TextBox();
            commentLabel = new Label();
            menuStrip1 = new MenuStrip();
            менюToolStripMenuItem = new ToolStripMenuItem();
            новыйТестToolStripMenuItem = new ToolStripMenuItem();
            показатьИсториюToolStripMenuItem = new ToolStripMenuItem();
            добавитьВопросToolStripMenuItem = new ToolStripMenuItem();
            удалитьВопросToolStripMenuItem = new ToolStripMenuItem();
            перезапускToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // nextButton
            // 
            nextButton.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            nextButton.Location = new Point(30, 327);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(355, 69);
            nextButton.TabIndex = 0;
            nextButton.Text = "Далее";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += NextButton_Click;
            // 
            // questionNumberLabel
            // 
            questionNumberLabel.AutoSize = true;
            questionNumberLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            questionNumberLabel.Location = new Point(30, 55);
            questionNumberLabel.Name = "questionNumberLabel";
            questionNumberLabel.Size = new Size(97, 21);
            questionNumberLabel.TabIndex = 1;
            questionNumberLabel.Text = "Вопрос № 1";
            // 
            // questionTextLabel
            // 
            questionTextLabel.AutoSize = true;
            questionTextLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            questionTextLabel.Location = new Point(30, 121);
            questionTextLabel.MaximumSize = new Size(296, 90);
            questionTextLabel.Name = "questionTextLabel";
            questionTextLabel.Size = new Size(111, 21);
            questionTextLabel.TabIndex = 2;
            questionTextLabel.Text = "Текст вопроса";
            // 
            // userAnswerTextBox
            // 
            userAnswerTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            userAnswerTextBox.Location = new Point(30, 219);
            userAnswerTextBox.Name = "userAnswerTextBox";
            userAnswerTextBox.Size = new Size(355, 29);
            userAnswerTextBox.TabIndex = 3;
            // 
            // commentLabel
            // 
            commentLabel.AutoSize = true;
            commentLabel.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            commentLabel.Location = new Point(30, 261);
            commentLabel.Name = "commentLabel";
            commentLabel.Size = new Size(164, 21);
            commentLabel.TabIndex = 4;
            commentLabel.Text = "Текст комментария";
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
            менюToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { новыйТестToolStripMenuItem, показатьИсториюToolStripMenuItem, добавитьВопросToolStripMenuItem, удалитьВопросToolStripMenuItem, перезапускToolStripMenuItem, выходToolStripMenuItem });
            менюToolStripMenuItem.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            менюToolStripMenuItem.Size = new Size(65, 23);
            менюToolStripMenuItem.Text = "МЕНЮ";
            // 
            // новыйТестToolStripMenuItem
            // 
            новыйТестToolStripMenuItem.Name = "новыйТестToolStripMenuItem";
            новыйТестToolStripMenuItem.Size = new Size(195, 24);
            новыйТестToolStripMenuItem.Text = "Новый тест";
            новыйТестToolStripMenuItem.Click += НовыйТестToolStripMenuItem_Click;
            // 
            // показатьИсториюToolStripMenuItem
            // 
            показатьИсториюToolStripMenuItem.Name = "показатьИсториюToolStripMenuItem";
            показатьИсториюToolStripMenuItem.Size = new Size(195, 24);
            показатьИсториюToolStripMenuItem.Text = "Показать историю";
            показатьИсториюToolStripMenuItem.Click += ПоказатьИсториюToolStripMenuItem_Click;
            // 
            // добавитьВопросToolStripMenuItem
            // 
            добавитьВопросToolStripMenuItem.Name = "добавитьВопросToolStripMenuItem";
            добавитьВопросToolStripMenuItem.Size = new Size(195, 24);
            добавитьВопросToolStripMenuItem.Text = "Добавить вопрос";
            добавитьВопросToolStripMenuItem.Click += ДобавитьВопросToolStripMenuItem_Click;
            // 
            // удалитьВопросToolStripMenuItem
            // 
            удалитьВопросToolStripMenuItem.Name = "удалитьВопросToolStripMenuItem";
            удалитьВопросToolStripMenuItem.Size = new Size(195, 24);
            удалитьВопросToolStripMenuItem.Text = "Удалить вопрос";
            удалитьВопросToolStripMenuItem.Click += УдалитьВопросToolStripMenuItem_Click;
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 450);
            Controls.Add(commentLabel);
            Controls.Add(userAnswerTextBox);
            Controls.Add(questionTextLabel);
            Controls.Add(questionNumberLabel);
            Controls.Add(nextButton);
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

        private Button nextButton;
        private Label questionNumberLabel;
        private Label questionTextLabel;
        private TextBox userAnswerTextBox;
        private Label commentLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem менюToolStripMenuItem;
        private ToolStripMenuItem показатьИсториюToolStripMenuItem;
        private ToolStripMenuItem перезапускToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem новыйТестToolStripMenuItem;
        private ToolStripMenuItem добавитьВопросToolStripMenuItem;
        private ToolStripMenuItem удалитьВопросToolStripMenuItem;
    }
}
