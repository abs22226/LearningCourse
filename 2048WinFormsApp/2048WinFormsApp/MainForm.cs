
namespace _2048WinFormsApp
{
    public partial class MainForm : Form
    {
        private const int cellSize = 70;
        private const int padding = 6;
        private const int leftMargin = 10;
        private const int topMargin = 70;
        private const int rightMargin = 4;
        private const int bottomMargin = 4;

        private Label[,] cellsMap;
        private int mapSize = 4;
        private static Random random = new Random();
        private int score = 0;
        private int bestScore = 0;
        private string userName;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var startForm = new StartForm();
            startForm.ShowDialog();

            userName = startForm.userNameTextBox.Text;

            SetMapSize(startForm.radioButtons);
            InitMap();
            GenerateNumber();
            ShowScore();
            CalculateBestScore();
        }

        private void SetMapSize(List<RadioButton> radioButtons)
        {
            foreach (var radioButton in radioButtons)
            {
                if (radioButton.Checked)
                {
                    mapSize = Convert.ToInt32(radioButton.Text[0].ToString());
                    break;
                }
            }
        }

        private void InitMap()
        {
            ClientSize = new Size(leftMargin + (cellSize + padding) * mapSize + rightMargin, topMargin + (cellSize + padding) * mapSize + bottomMargin);

            titleBestScoreLabel.Location = new Point(leftMargin + (cellSize + padding) * mapSize - titleBestScoreLabel.Width - titleBestScoreLabel.Margin.Right, 9);
            bestScoreLabel.Location = new Point(leftMargin + (cellSize + padding) * mapSize - bestScoreLabel.Width - bestScoreLabel.Margin.Right, 34);

            titleScoreLabel.Location = new Point(leftMargin + (cellSize + padding) * mapSize - titleBestScoreLabel.Width - titleBestScoreLabel.Margin.Right - titleScoreLabel.Width - titleScoreLabel.Margin.Right, 9);
            scoreLabel.Location = new Point(leftMargin + (cellSize + padding) * mapSize - titleBestScoreLabel.Width - titleBestScoreLabel.Margin.Right - scoreLabel.Width - scoreLabel.Margin.Right, 34);

            cellsMap = new Label[mapSize, mapSize];

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    var newCell = GetNewCell(i, j);
                    cellsMap[i, j] = newCell;
                    Controls.Add(cellsMap[i, j]);
                }
            }
        }

        private Label GetNewCell(int rowIndex, int columnIndex)
        {
            var newCell = new Label();
            newCell.BackColor = SystemColors.ButtonShadow;
            newCell.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            newCell.Size = new Size(cellSize, cellSize);
            newCell.TextAlign = ContentAlignment.MiddleCenter;
            int x = leftMargin + columnIndex * (cellSize + padding);
            int y = topMargin + rowIndex * (cellSize + padding);
            newCell.Location = new Point(x, y);

            newCell.TextChanged += NewCell_TextChanged;

            return newCell;
        }

        private void NewCell_TextChanged(object? sender, EventArgs e)
        {
            var cell = (Label)sender;
            switch (cell.Text)
            {
                case "": cell.BackColor = SystemColors.ButtonShadow; break;
                case "2": cell.BackColor = Color.FromArgb(179, 229, 252); break;
                case "4": cell.BackColor = Color.FromArgb(200, 230, 201); break;
                case "8": cell.BackColor = Color.FromArgb(242, 177, 121); break;
                case "16": cell.BackColor = Color.FromArgb(255, 224, 178); break;
                case "32": cell.BackColor = Color.FromArgb(255, 204, 188); break;
                case "64": cell.BackColor = Color.FromArgb(255, 171, 145); break;
                case "128": cell.BackColor = Color.FromArgb(255, 138, 101); break;
                case "256": cell.BackColor = Color.FromArgb(255, 213, 79); break;
                case "512": cell.BackColor = Color.FromArgb(255, 202, 40); break;
                case "1024": cell.BackColor = Color.FromArgb(255, 112, 67); break;
                case "20048": cell.BackColor = Color.FromArgb(244, 67, 54); break;
            }
        }

        private void GenerateNumber()
        {
            var mapHasEmptyCells = MapHasEmptyCells();
            while (mapHasEmptyCells)
            {
                var randomCelllNumber = random.Next(mapSize * mapSize);
                var rowIndex = randomCelllNumber / mapSize;
                var columnIndex = randomCelllNumber % mapSize;
                if (cellsMap[rowIndex, columnIndex].Text == string.Empty)
                {
                    //randomly generate either 2 or 4... in 75% of times generate 2 and in 25% of times generate 4
                    cellsMap[rowIndex, columnIndex].Text = random.Next(1, 101) <= 75 ? "2" : "4";
                    break;
                }
            }
        }

        private bool MapHasEmptyCells()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (cellsMap[i, j].Text == string.Empty)
                    {
                        return true;
                    }
                }
            }
            return false;
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
                UserManager.Add(new User() { Name = userName, Score = score });
                MessageBox.Show("”ра! Ёто победа!");
                return;
            }

            if (GameOver())
            {
                UserManager.Add(new User() { Name = userName, Score = score });
                MessageBox.Show("”вы! Ёто поражение!");
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
                    var rightCell = cellsMap[i, j];
                    if (rightCell.Text != string.Empty) // ≈сли находим непустую €чейку,...
                    {
                        for (int k = j - 1; k >= 0; k--) // то проходимс€ по каждой €чейке слева от нее,...
                        {
                            var leftCell = cellsMap[i, k];
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
                    var rightCell = cellsMap[i, j];
                    if (rightCell.Text == string.Empty) // и когда находим пустую €чейку...
                    {
                        for (int k = j - 1; k >= 0; k--) // проходимс€ по каждой €чейке слева от нее...
                        {
                            var leftCell = cellsMap[i, k];
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
                    var leftCell = cellsMap[i, j];
                    if (leftCell.Text != string.Empty) // и когда находим непустую €чейку...
                    {
                        for (int k = j + 1; k < mapSize; k++) // то проходимс€ по каждой €чейке справа от нее...
                        {
                            var rightCell = cellsMap[i, k];
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
                    var leftCell = cellsMap[i, j];
                    if (leftCell.Text == string.Empty) // и когда находим пустую €чейку...
                    {
                        for (int k = j + 1; k < mapSize; k++) // проходимс€ по каждой €чейке справа от нее...
                        {
                            var rightCell = cellsMap[i, k];
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
                    var upperCell = cellsMap[i, j];
                    if (upperCell.Text != string.Empty) // и когда находим непустую €чейку...
                    {
                        for (int k = i + 1; k < mapSize; k++) // то проходимс€ по каждой €чейке вниз от нее...
                        {
                            var lowerCell = cellsMap[k, j];
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
                    var upperCell = cellsMap[i, j];
                    if (upperCell.Text == string.Empty) // и когда находим пустую €чейку...
                    {
                        for (int k = i + 1; k < mapSize; k++) // проходимс€ по каждой €чейке вниз от нее...
                        {
                            var lowerCell = cellsMap[k, j];
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
                    var lowerCell = cellsMap[i, j];
                    if (lowerCell.Text != string.Empty) // и когда находим непустую €чейку...
                    {
                        for (int k = i - 1; k >= 0; k--) // то проходимс€ по каждой €чейке вверх от нее...
                        {
                            var upperCell = cellsMap[k, j];
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
                    var lowerCell = cellsMap[i, j];
                    if (lowerCell.Text == string.Empty) // и когда находим пустую €чейку...
                    {
                        for (int k = i - 1; k >= 0; k--) // то проходимс€ по каждой €чейке вверх от нее...
                        {
                            var upperCell = cellsMap[k, j];
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
                    if (cellsMap[i, j].Text == "2048")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool GameOver()
        {
            if (MapHasEmptyCells())
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
                    if (cellsMap[i, j].Text == cellsMap[i, j + 1].Text ||
                        cellsMap[i, j].Text == cellsMap[i + 1, j].Text)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
