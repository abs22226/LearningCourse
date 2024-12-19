namespace _2048WinFormsApp
{
    public partial class MainForm : Form
    {
        private Label[,] labelsMap;
        private const int mapSize = 4;
        private static Random random = new Random();
        private int score = 0;
        private int bestScore = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitMap();
            GenerateNumber();
            ShowScore();
            CalculateBestScore();
        }

        private void InitMap()
        {
            labelsMap = new Label[mapSize, mapSize];

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    var newLabel = GetNewLabel(i, j);
                    labelsMap[i, j] = newLabel;
                    Controls.Add(labelsMap[i, j]);
                }
            }
        }

        private void GenerateNumber()
        {
            var mapHasEmptyLabels = MapHasEmptyLabels();
            while (mapHasEmptyLabels)
            {
                var randomLabelNumber = random.Next(mapSize * mapSize);
                var rowIndex = randomLabelNumber / mapSize;
                var columnIndex = randomLabelNumber % mapSize;
                if (labelsMap[rowIndex, columnIndex].Text == string.Empty)
                {
                    //randomly generate either 2 or 4... in 75% of times generate 2 and in 25% of times generate 4
                    labelsMap[rowIndex, columnIndex].Text = random.Next(1, 101) <= 75 ? "2" : "4";
                    break;
                }
            }
        }

        private bool MapHasEmptyLabels()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (labelsMap[i, j].Text == string.Empty)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private Label GetNewLabel(int rowIndex, int columnIndex)
        {
            var newLabel = new Label();
            newLabel.BackColor = SystemColors.ButtonShadow;
            newLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            newLabel.Size = new Size(70, 70);
            newLabel.TextAlign = ContentAlignment.MiddleCenter;
            int x = 10 + columnIndex * 76;
            int y = 70 + rowIndex * 76;
            newLabel.Location = new Point(x, y);
            return newLabel;
        }

        private void ShowScore()
        {
            scoreLabel.Text = score.ToString();
        }

        private void CalculateBestScore()
        {
            var users = UserManager.GetAll();
            if (users.Count == 0)
            {
                return;
            }

            bestScore = users[0].Score;
            foreach (var user in users)
            {
                if (user.Score > bestScore)
                {
                    bestScore = user.Score;
                }
            }

            ShowBestScore();
        }

        private void ShowBestScore()
        {
            if (score > bestScore)
            {
                bestScore = score;
            }
            bestScoreLabel.Text = bestScore.ToString();
        }

        private void рестартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void правилаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("»спользуйте клавиши со стрелками, чтобы перемещать плитки.  огда две плитки с одинаковыми номерами соприкасаютс€, они сливаютс€ в одну.  огда ходов не осталось, игра закончена!");
        }

        private void результатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resultsForm = new ResultsForm();
            resultsForm.ShowDialog();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Right &&
                e.KeyCode != Keys.Left &&
                e.KeyCode != Keys.Up &&
                e.KeyCode != Keys.Down)
            {
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Right: HandleRight(); break;
                case Keys.Left: HandleLeft(); break;
                case Keys.Up: HandleUp(); break;
                case Keys.Down: HandleDown(); break;
            }

            GenerateNumber();
            ShowScore();
            ShowBestScore();

            if (UserWon())
            {
                UserManager.Add(new User() { Name = "»м€", Score = score });
                MessageBox.Show("”ра! ¬ы победили!");
                return;
            }

            if (GameOver())
            {
                UserManager.Add(new User() { Name = "»м€", Score = score });
                MessageBox.Show("  сожалению вы проиграли!");
                return;
            }
        }

        private void HandleRight()
        {
            MergeRight();
            MoveRight();
        }

        private void MergeRight()
        {
            for (int i = 0; i < mapSize; i++) // ¬ каждой строчке...
            {
                for (int j = mapSize - 1; j >= 0; j--) // проходимс€ по каждой €чейке справа налево.
                {
                    var rightCell = labelsMap[i, j];
                    if (rightCell.Text != string.Empty) // ≈сли находим непустую €чейку,...
                    {
                        for (int k = j - 1; k >= 0; k--) // то проходимс€ по каждой €чейке слева от нее,...
                        {
                            var leftCell = labelsMap[i, k];
                            if (leftCell.Text != string.Empty) // и когда находим слева ближайшую непустую €чейку,...
                            {
                                if (leftCell.Text == rightCell.Text) // то, если числа в этих €чейках равны,...
                                {
                                    var number = int.Parse(rightCell.Text);
                                    rightCell.Text = (number * 2).ToString(); // в правую записываем их сумму,...
                                    leftCell.Text = string.Empty; // а левую очищаем.
                                    score += number * 2; // » увеличиваем счет на эту сумму.
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void MoveRight()
        {
            for (int i = 0; i < mapSize; i++) // ¬ каждой строчке...
            {
                for (int j = mapSize - 1; j >= 0; j--) // проходимс€ по каждой €чейке справа налево...
                {
                    var rightCell = labelsMap[i, j];
                    if (rightCell.Text == string.Empty) // и когда находим пустую €чейку...
                    {
                        for (int k = j - 1; k >= 0; k--) // проходимс€ по каждой €чейке слева от нее...
                        {
                            var leftCell = labelsMap[i, k];
                            if (leftCell.Text != string.Empty) // и когда находим слева ближайшую непустую €чейку...
                            {
                                rightCell.Text = leftCell.Text; // в правую €чейку записываем число из левой €чейки...
                                leftCell.Text = string.Empty; // а левую очищаем.
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void HandleLeft()
        {
            MergeLeft();
            MoveLeft();
        }

        private void MergeLeft()
        {
            for (int i = 0; i < mapSize; i++) // ¬ каждой строчке...
            {
                for (int j = 0; j < mapSize; j++) // проходимс€ по каждой €чейке слева направо...
                {
                    var leftCell = labelsMap[i, j];
                    if (leftCell.Text != string.Empty) // и когда находим непустую €чейку...
                    {
                        for (int k = j + 1; k < mapSize; k++) // то проходимс€ по каждой €чейке справа от нее...
                        {
                            var rightCell = labelsMap[i, k];
                            if (rightCell.Text != string.Empty) // и когда находим справа ближайшую непустую €чейку...
                            {
                                if (rightCell.Text == leftCell.Text) // то если числа в этих €чейках равны...
                                {
                                    var number = int.Parse(leftCell.Text);
                                    leftCell.Text = (number * 2).ToString(); // в левую записываем их сумму...
                                    rightCell.Text = string.Empty; // а правую очищаем...
                                    score += number * 2; // и увеличиваем счет на эту сумму.
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void MoveLeft()
        {
            for (int i = 0; i < mapSize; i++) // ¬ каждой строчке...
            {
                for (int j = 0; j < mapSize; j++) // проходимс€ по каждой €чейке слева направо...
                {
                    var leftCell = labelsMap[i, j];
                    if (leftCell.Text == string.Empty) // и когда находим пустую €чейку...
                    {
                        for (int k = j + 1; k < mapSize; k++) // проходимс€ по каждой €чейке справа от нее...
                        {
                            var rightCell = labelsMap[i, k];
                            if (rightCell.Text != string.Empty) // и когда находим справа ближайшую непустую €чейку...
                            {
                                leftCell.Text = rightCell.Text; // в левую €чейку записываем число из правой €чейки...
                                rightCell.Text = string.Empty; // а правую очищаем.
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void HandleUp()
        {
            MergeUp();
            MoveUp();
        }

        private void MergeUp()
        {
            for (int j = 0; j < mapSize; j++) // ¬ каждой колонке...
            {
                for (int i = 0; i < mapSize; i++) // проходимс€ по каждой €чейке сверху вниз...
                {
                    var upperCell = labelsMap[i, j];
                    if (upperCell.Text != string.Empty) // и когда находим непустую €чейку...
                    {
                        for (int k = i + 1; k < mapSize; k++) // то проходимс€ по каждой €чейке вниз от нее...
                        {
                            var lowerCell = labelsMap[k, j];
                            if (lowerCell.Text != string.Empty) // и когда находим снизу ближайшую непустую €чейку...
                            {
                                if (lowerCell.Text == upperCell.Text) // то если числа в этих €чейках равны...
                                {
                                    var number = int.Parse(upperCell.Text);
                                    upperCell.Text = (number * 2).ToString(); // в верхнюю записываем их сумму...
                                    lowerCell.Text = string.Empty; // а нижнюю очищаем...
                                    score += number * 2; // и увеличиваем счет на эту сумму.
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void MoveUp()
        {
            for (int j = 0; j < mapSize; j++) // ¬ каждой колонке...
            {
                for (int i = 0; i < mapSize; i++) // проходимс€ по каждой €чейке сверху вниз...
                {
                    var upperCell = labelsMap[i, j];
                    if (upperCell.Text == string.Empty) // и когда находим пустую €чейку...
                    {
                        for (int k = i + 1; k < mapSize; k++) // проходимс€ по каждой €чейке вниз от нее...
                        {
                            var lowerCell = labelsMap[k, j];
                            if (lowerCell.Text != string.Empty) // и когда находим снизу ближайшую непустую €чейку...
                            {
                                upperCell.Text = lowerCell.Text; // в верхнюю €чейку записываем число из нижней €чейки...
                                lowerCell.Text = string.Empty; // а нижнюю очищаем.
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void HandleDown()
        {
            MergeDown();
            MoveDown();
        }

        private void MergeDown()
        {
            for (int j = 0; j < mapSize; j++) // ¬ каждой колонке...
            {
                for (int i = mapSize - 1; i >= 0; i--) // проходимс€ по каждой €чейке снизу вверх...
                {
                    var lowerCell = labelsMap[i, j];
                    if (lowerCell.Text != string.Empty) // и когда находим непустую €чейку...
                    {
                        for (int k = i - 1; k >= 0; k--) // то проходимс€ по каждой €чейке вверх от нее...
                        {
                            var upperCell = labelsMap[k, j];
                            if (upperCell.Text != string.Empty) // и когда находим сверху ближайшую непустую €чейку...
                            {
                                if (upperCell.Text == lowerCell.Text) // то если числа в этих €чейках равны...
                                {
                                    var number = int.Parse(lowerCell.Text);
                                    lowerCell.Text = (number * 2).ToString(); // в нижнюю записываем их сумму...
                                    upperCell.Text = string.Empty; // а верхнюю очищаем...
                                    score += number * 2; // и увеличиваем счет на эту сумму.
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void MoveDown()
        {
            for (int j = 0; j < mapSize; j++) // ¬ каждой колонке...
            {
                for (int i = mapSize - 1; i >= 0; i--) // проходимс€ по каждой €чейке снизу вверх...
                {
                    var lowerCell = labelsMap[i, j];
                    if (lowerCell.Text == string.Empty) // и когда находим пустую €чейку...
                    {
                        for (int k = i - 1; k >= 0; k--) // то проходимс€ по каждой €чейке вверх от нее...
                        {
                            var upperCell = labelsMap[k, j];
                            if (upperCell.Text != string.Empty) // и когда находим сверху ближайшую непустую €чейку...
                            {
                                lowerCell.Text = upperCell.Text; // в нижнюю €чейку записываем число из верхней €чейки...
                                upperCell.Text = string.Empty; // а верхнюю очищаем.
                                break;
                            }
                        }
                    }
                }
            }
        }

        private bool UserWon()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (labelsMap[i, j].Text == "2048")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool GameOver()
        {
            if (MapHasEmptyLabels())
            {
                return false;
            }

            //if(CellsCanBeMerged())
            //{
            //    return false;
            //}

            for (int i = 0; i < mapSize - 1; i++) // TODO: надо i < mapSize, иначе €чейки нижней строки не провер€ютс€ на равенство с правой €чейкой.
            {
                for (int j = 0; j < mapSize - 1; j++) // TODO: надо j < mapSize, иначе €чейки самой правой колонки не провер€ютс€ на равенство с нижней €чейкой.
                {
                    if (labelsMap[i, j].Text == labelsMap[i, j + 1].Text ||
                        labelsMap[i, j].Text == labelsMap[i + 1, j].Text)
                    {
                        return false;
                    }
                }
            }

            return true;
        }


    }
}
