namespace BallGamesWinFormsApp
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
            startButton = new Button();
            stopButton = new Button();
            clearButton = new Button();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.Location = new Point(693, 12);
            startButton.Name = "startButton";
            startButton.Size = new Size(95, 23);
            startButton.TabIndex = 0;
            startButton.Text = "Создать";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(693, 41);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(95, 23);
            stopButton.TabIndex = 0;
            stopButton.Text = "Остановить";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(693, 70);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(95, 23);
            clearButton.TabIndex = 0;
            clearButton.Text = "Очистить";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(startButton);
            Controls.Add(clearButton);
            Controls.Add(stopButton);
            Name = "MainForm";
            Text = "Мячики";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button startButton;
        private Button stopButton;
        private Button clearButton;
    }
}
