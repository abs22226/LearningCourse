namespace BilliardBallsWinFormsApp
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
            leftLabel = new Label();
            topLabel = new Label();
            bottomLabel = new Label();
            rightLabel = new Label();
            SuspendLayout();
            // 
            // leftLabel
            // 
            leftLabel.AutoSize = true;
            leftLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            leftLabel.Location = new Point(12, 194);
            leftLabel.Name = "leftLabel";
            leftLabel.Size = new Size(15, 17);
            leftLabel.TabIndex = 0;
            leftLabel.Text = "0";
            // 
            // topLabel
            // 
            topLabel.AutoSize = true;
            topLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            topLabel.Location = new Point(398, 9);
            topLabel.Name = "topLabel";
            topLabel.Size = new Size(15, 17);
            topLabel.TabIndex = 0;
            topLabel.Text = "0";
            // 
            // bottomLabel
            // 
            bottomLabel.AutoSize = true;
            bottomLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            bottomLabel.Location = new Point(398, 424);
            bottomLabel.Name = "bottomLabel";
            bottomLabel.Size = new Size(15, 17);
            bottomLabel.TabIndex = 0;
            bottomLabel.Text = "0";
            // 
            // rightLabel
            // 
            rightLabel.AutoSize = true;
            rightLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            rightLabel.Location = new Point(773, 194);
            rightLabel.Name = "rightLabel";
            rightLabel.Size = new Size(15, 17);
            rightLabel.TabIndex = 0;
            rightLabel.Text = "0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rightLabel);
            Controls.Add(bottomLabel);
            Controls.Add(topLabel);
            Controls.Add(leftLabel);
            Name = "MainForm";
            Text = "Биллиардные шарики";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label leftLabel;
        private Label topLabel;
        private Label bottomLabel;
        private Label rightLabel;
    }
}
