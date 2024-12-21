namespace _2048WinFormsApp
{
    partial class StartForm
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
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            label2 = new Label();
            userNameTextBox = new TextBox();
            startButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(33, 24);
            label1.Name = "label1";
            label1.Size = new Size(135, 21);
            label1.TabIndex = 0;
            label1.Text = "Выберите поле:";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton1.Location = new Point(40, 59);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(61, 24);
            radioButton1.TabIndex = 1;
            radioButton1.TabStop = true;
            radioButton1.Text = "4 х 4";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton2.Location = new Point(107, 59);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(59, 24);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "5 х 5";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton3.Location = new Point(40, 89);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(59, 24);
            radioButton3.TabIndex = 1;
            radioButton3.TabStop = true;
            radioButton3.Text = "6 х 6";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton4.Location = new Point(107, 89);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(59, 24);
            radioButton4.TabIndex = 1;
            radioButton4.TabStop = true;
            radioButton4.Text = "7 х 7";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(33, 141);
            label2.Name = "label2";
            label2.Size = new Size(113, 21);
            label2.TabIndex = 0;
            label2.Text = "Введите имя:";
            // 
            // userNameTextBox
            // 
            userNameTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            userNameTextBox.Location = new Point(29, 182);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(148, 25);
            userNameTextBox.TabIndex = 2;
            // 
            // startButton
            // 
            startButton.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            startButton.Location = new Point(29, 234);
            startButton.Name = "startButton";
            startButton.Size = new Size(148, 44);
            startButton.TabIndex = 3;
            startButton.Text = "Начать";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += StartButton_Click;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(208, 305);
            Controls.Add(startButton);
            Controls.Add(userNameTextBox);
            Controls.Add(radioButton4);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximumSize = new Size(224, 344);
            MinimumSize = new Size(224, 344);
            Name = "StartForm";
            Text = "2048";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private Label label2;
        public TextBox userNameTextBox;
        private Button startButton;
    }
}