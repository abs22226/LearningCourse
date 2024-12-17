namespace _2048WinFormsApp
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
            label1 = new Label();
            scoreLabel = new Label();
            menuStrip1 = new MenuStrip();
            менюToolStripMenuItem = new ToolStripMenuItem();
            правилаToolStripMenuItem = new ToolStripMenuItem();
            рестартToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(257, 9);
            label1.Name = "label1";
            label1.Size = new Size(49, 21);
            label1.TabIndex = 0;
            label1.Text = "Счет:";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // scoreLabel
            // 
            scoreLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            scoreLabel.Location = new Point(242, 34);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(64, 21);
            scoreLabel.TabIndex = 1;
            scoreLabel.Text = "0";
            scoreLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { менюToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(318, 29);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            менюToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { правилаToolStripMenuItem, рестартToolStripMenuItem, выходToolStripMenuItem });
            менюToolStripMenuItem.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            менюToolStripMenuItem.Size = new Size(69, 25);
            менюToolStripMenuItem.Text = "Меню";
            // 
            // правилаToolStripMenuItem
            // 
            правилаToolStripMenuItem.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            правилаToolStripMenuItem.Name = "правилаToolStripMenuItem";
            правилаToolStripMenuItem.Size = new Size(180, 24);
            правилаToolStripMenuItem.Text = "Правила";
            правилаToolStripMenuItem.Click += правилаToolStripMenuItem_Click;
            // 
            // рестартToolStripMenuItem
            // 
            рестартToolStripMenuItem.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            рестартToolStripMenuItem.Name = "рестартToolStripMenuItem";
            рестартToolStripMenuItem.Size = new Size(180, 24);
            рестартToolStripMenuItem.Text = "Рестарт";
            рестартToolStripMenuItem.Click += рестартToolStripMenuItem_Click;
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(180, 24);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(318, 378);
            Controls.Add(scoreLabel);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "2048";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label scoreLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem менюToolStripMenuItem;
        private ToolStripMenuItem правилаToolStripMenuItem;
        private ToolStripMenuItem рестартToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
    }
}
