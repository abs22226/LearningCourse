namespace GeniusIdiotWinFormsApp
{
    partial class QuestionRemovalForm
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
            TextColumn = new DataGridViewTextBoxColumn();
            deleteButton = new Button();
            ((System.ComponentModel.ISupportInitialize)questionRemovalDataGridView).BeginInit();
            SuspendLayout();
            // 
            // questionRemovalDataGridView
            // 
            questionRemovalDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            questionRemovalDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            questionRemovalDataGridView.Columns.AddRange(new DataGridViewColumn[] { TextColumn });
            questionRemovalDataGridView.Location = new Point(12, 12);
            questionRemovalDataGridView.Name = "questionRemovalDataGridView";
            questionRemovalDataGridView.RowTemplate.Height = 25;
            questionRemovalDataGridView.Size = new Size(390, 342);
            questionRemovalDataGridView.TabIndex = 0;
            // 
            // TextColumn
            // 
            TextColumn.HeaderText = "Текст вопроса";
            TextColumn.Name = "TextColumn";
            TextColumn.ReadOnly = true;
            TextColumn.Width = 330;
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
            // QuestionRemovalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 511);
            Controls.Add(deleteButton);
            Controls.Add(questionRemovalDataGridView);
            MaximumSize = new Size(430, 550);
            MinimumSize = new Size(430, 550);
            Name = "QuestionRemovalForm";
            Text = "Удаление вопроса";
            Load += DeleteQuestionForm_Load;
            ((System.ComponentModel.ISupportInitialize)questionRemovalDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView questionRemovalDataGridView;
        private Button deleteButton;
        private DataGridViewTextBoxColumn TextColumn;
    }
}