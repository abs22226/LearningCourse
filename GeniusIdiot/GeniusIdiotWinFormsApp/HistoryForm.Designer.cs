namespace GeniusIdiotWinFormsApp
{
    partial class HistoryForm
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
            historyDataGridView = new DataGridView();
            UserNameColumn = new DataGridViewTextBoxColumn();
            UserResultColumn = new DataGridViewTextBoxColumn();
            UserDiagnosisColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)historyDataGridView).BeginInit();
            SuspendLayout();
            // 
            // historyDataGridView
            // 
            historyDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            historyDataGridView.Columns.AddRange(new DataGridViewColumn[] { UserNameColumn, UserResultColumn, UserDiagnosisColumn });
            historyDataGridView.Location = new Point(14, 12);
            historyDataGridView.Name = "historyDataGridView";
            historyDataGridView.RowTemplate.Height = 25;
            historyDataGridView.Size = new Size(388, 426);
            historyDataGridView.TabIndex = 0;
            // 
            // UserNameColumn
            // 
            UserNameColumn.HeaderText = "Имя";
            UserNameColumn.Name = "UserNameColumn";
            UserNameColumn.Width = 153;
            // 
            // UserResultColumn
            // 
            UserResultColumn.HeaderText = "Результат";
            UserResultColumn.Name = "UserResultColumn";
            UserResultColumn.Width = 75;
            // 
            // UserDiagnosisColumn
            // 
            UserDiagnosisColumn.HeaderText = "Диагноз";
            UserDiagnosisColumn.Name = "UserDiagnosisColumn";
            // 
            // HistoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 450);
            Controls.Add(historyDataGridView);
            MaximumSize = new Size(430, 489);
            MinimumSize = new Size(430, 489);
            Name = "HistoryForm";
            Text = "История";
            Load += HistoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)historyDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView historyDataGridView;
        private DataGridViewTextBoxColumn UserNameColumn;
        private DataGridViewTextBoxColumn UserResultColumn;
        private DataGridViewTextBoxColumn UserDiagnosisColumn;
    }
}