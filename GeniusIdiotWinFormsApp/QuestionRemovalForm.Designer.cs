namespace GeniusIdiotWinFormsApp
{
    partial class questionRemovalForm
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
            questionRemovalDataGridView = new DataGridView();
            numberColumn = new DataGridViewTextBoxColumn();
            TextColumn = new DataGridViewTextBoxColumn();
            deleteButton = new Button();
            label1 = new Label();
            questionNumberTextBox = new TextBox();
            commentLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)questionRemovalDataGridView).BeginInit();
            SuspendLayout();
            // 
            // questionRemovalDataGridView
            // 
            questionRemovalDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            questionRemovalDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            questionRemovalDataGridView.Columns.AddRange(new DataGridViewColumn[] { numberColumn, TextColumn });
            questionRemovalDataGridView.Location = new Point(12, 12);
            questionRemovalDataGridView.Name = "questionRemovalDataGridView";
            questionRemovalDataGridView.RowTemplate.Height = 25;
            questionRemovalDataGridView.Size = new Size(390, 210);
            questionRemovalDataGridView.TabIndex = 0;
            // 
            // numberColumn
            // 
            numberColumn.HeaderText = "№";
            numberColumn.Name = "numberColumn";
            numberColumn.Width = 30;
            // 
            // TextColumn
            // 
            TextColumn.HeaderText = "Текст";
            TextColumn.Name = "TextColumn";
            TextColumn.Width = 300;
            // 
            // deleteButton
            // 
            deleteButton.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            deleteButton.Location = new Point(30, 388);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(355, 69);
            deleteButton.TabIndex = 1;
            deleteButton.Text = "Удалить";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += DeleteButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(30, 245);
            label1.Name = "label1";
            label1.Size = new Size(272, 21);
            label1.TabIndex = 2;
            label1.Text = "Введите номер удаляемого вопроса:";
            // 
            // questionNumberTextBox
            // 
            questionNumberTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            questionNumberTextBox.Location = new Point(30, 290);
            questionNumberTextBox.Name = "questionNumberTextBox";
            questionNumberTextBox.Size = new Size(355, 29);
            questionNumberTextBox.TabIndex = 3;
            // 
            // commentLabel
            // 
            commentLabel.AutoSize = true;
            commentLabel.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            commentLabel.Location = new Point(30, 333);
            commentLabel.Name = "commentLabel";
            commentLabel.Size = new Size(164, 21);
            commentLabel.TabIndex = 4;
            commentLabel.Text = "Текст комментария";
            // 
            // questionRemovalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 511);
            Controls.Add(commentLabel);
            Controls.Add(questionNumberTextBox);
            Controls.Add(label1);
            Controls.Add(deleteButton);
            Controls.Add(questionRemovalDataGridView);
            MaximumSize = new Size(430, 550);
            MinimumSize = new Size(430, 550);
            Name = "questionRemovalForm";
            Text = "Удаление вопроса";
            Load += DeleteQuestionForm_Load;
            ((System.ComponentModel.ISupportInitialize)questionRemovalDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView questionRemovalDataGridView;
        private Button deleteButton;
        private Label label1;
        private TextBox questionNumberTextBox;
        private Label commentLabel;
        private DataGridViewTextBoxColumn numberColumn;
        private DataGridViewTextBoxColumn TextColumn;
    }
}