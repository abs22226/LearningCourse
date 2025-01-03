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
            redLeftLabel = new Label();
            redTopLabel = new Label();
            redBottomLabel = new Label();
            redRightLabel = new Label();
            blueLeftLabel = new Label();
            blueRightLabel = new Label();
            blueTopLabel = new Label();
            blueBottomLabel = new Label();
            SuspendLayout();
            // 
            // redLeftLabel
            // 
            redLeftLabel.AutoSize = true;
            redLeftLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            redLeftLabel.ForeColor = Color.Red;
            redLeftLabel.Location = new Point(12, 184);
            redLeftLabel.Name = "redLeftLabel";
            redLeftLabel.Size = new Size(15, 17);
            redLeftLabel.TabIndex = 0;
            redLeftLabel.Text = "0";
            // 
            // redTopLabel
            // 
            redTopLabel.AutoSize = true;
            redTopLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            redTopLabel.ForeColor = Color.Red;
            redTopLabel.Location = new Point(373, 9);
            redTopLabel.Name = "redTopLabel";
            redTopLabel.Size = new Size(15, 17);
            redTopLabel.TabIndex = 0;
            redTopLabel.Text = "0";
            // 
            // redBottomLabel
            // 
            redBottomLabel.AutoSize = true;
            redBottomLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            redBottomLabel.ForeColor = Color.Red;
            redBottomLabel.Location = new Point(373, 424);
            redBottomLabel.Name = "redBottomLabel";
            redBottomLabel.Size = new Size(15, 17);
            redBottomLabel.TabIndex = 0;
            redBottomLabel.Text = "0";
            // 
            // redRightLabel
            // 
            redRightLabel.AutoSize = true;
            redRightLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            redRightLabel.ForeColor = Color.Red;
            redRightLabel.Location = new Point(773, 184);
            redRightLabel.Name = "redRightLabel";
            redRightLabel.Size = new Size(15, 17);
            redRightLabel.TabIndex = 0;
            redRightLabel.Text = "0";
            // 
            // blueLeftLabel
            // 
            blueLeftLabel.AutoSize = true;
            blueLeftLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            blueLeftLabel.ForeColor = Color.DodgerBlue;
            blueLeftLabel.Location = new Point(12, 222);
            blueLeftLabel.Name = "blueLeftLabel";
            blueLeftLabel.Size = new Size(15, 17);
            blueLeftLabel.TabIndex = 0;
            blueLeftLabel.Text = "0";
            // 
            // blueRightLabel
            // 
            blueRightLabel.AutoSize = true;
            blueRightLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            blueRightLabel.ForeColor = Color.DodgerBlue;
            blueRightLabel.Location = new Point(773, 222);
            blueRightLabel.Name = "blueRightLabel";
            blueRightLabel.Size = new Size(15, 17);
            blueRightLabel.TabIndex = 0;
            blueRightLabel.Text = "0";
            // 
            // blueTopLabel
            // 
            blueTopLabel.AutoSize = true;
            blueTopLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            blueTopLabel.ForeColor = Color.DodgerBlue;
            blueTopLabel.Location = new Point(417, 9);
            blueTopLabel.Name = "blueTopLabel";
            blueTopLabel.Size = new Size(15, 17);
            blueTopLabel.TabIndex = 0;
            blueTopLabel.Text = "0";
            // 
            // blueBottomLabel
            // 
            blueBottomLabel.AutoSize = true;
            blueBottomLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            blueBottomLabel.ForeColor = Color.DodgerBlue;
            blueBottomLabel.Location = new Point(417, 424);
            blueBottomLabel.Name = "blueBottomLabel";
            blueBottomLabel.Size = new Size(15, 17);
            blueBottomLabel.TabIndex = 0;
            blueBottomLabel.Text = "0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(blueRightLabel);
            Controls.Add(redRightLabel);
            Controls.Add(blueBottomLabel);
            Controls.Add(redBottomLabel);
            Controls.Add(blueTopLabel);
            Controls.Add(blueLeftLabel);
            Controls.Add(redTopLabel);
            Controls.Add(redLeftLabel);
            Name = "MainForm";
            Text = "Биллиардные шарики";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label redLeftLabel;
        private Label redTopLabel;
        private Label redBottomLabel;
        private Label redRightLabel;
        private Label blueLeftLabel;
        private Label blueRightLabel;
        private Label blueTopLabel;
        private Label blueBottomLabel;
    }
}
