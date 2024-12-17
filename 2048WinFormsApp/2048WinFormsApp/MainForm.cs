namespace _2048WinFormsApp
{
    public partial class MainForm : Form
    {
        private Label[,] labelsMap;
        private const int mapSize = 4;
        private static Random random = new Random();
        private int score = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            KeyDown += MainForm_KeyDown;

            InitMap();
            ShowScore();
            GenerateNumber();
        }

        private void MainForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                HandleRightArrowKeyPressing();
                ShowScore();
                GenerateNumber();
            }
            if (e.KeyCode == Keys.Left)
            {
                HandleLeftArrowKeyPressing();
                ShowScore();
                GenerateNumber();
            }
            if (e.KeyCode == Keys.Up)
            {
                HandleUpArrowKeyPressing();
                ShowScore();
                GenerateNumber();
            }
            if (e.KeyCode == Keys.Down)
            {
                HandleDownArrowKeyPressing();
                ShowScore();
                GenerateNumber();
            }
        }

        private void HandleDownArrowKeyPressing()
        {
            for (int j = 0; j < mapSize; j++) // ¬ каждой колонке...
            {
                for (int i = mapSize - 1; i >= 0; i--) // проходимс€ по каждой €чейке снизу вверх...
                {
                    if (labelsMap[i, j].Text != string.Empty) // и когда находим непустую €чейку...
                    {
                        for (int k = i - 1; k >= 0; k--) // проходимс€ по каждой €чейке вверх от нее...
                        {
                            if (labelsMap[k, j].Text != string.Empty) // и когда находим ближайшую непустую €чейку...
                            {
                                if (labelsMap[k, j].Text == labelsMap[i, j].Text) // то если числа в этих непустых €чейках равны...
                                {
                                    var number = int.Parse(labelsMap[i, j].Text);
                                    labelsMap[i, j].Text = (number * 2).ToString(); // в нижнюю записываем их сумму...
                                    labelsMap[k, j].Text = string.Empty; // а верхнюю очищаем...
                                    score += number * 2; // и увеличиваем счет на эту сумму.
                                }
                                break;
                            }
                        }
                    }
                }
            }

            for (int j = 0; j < mapSize; j++) // ¬ каждой колонке...
            {
                for (int i = mapSize - 1; i >= 0; i--) // проходимс€ по каждой €чейке снизу вверх...
                {
                    if (labelsMap[i, j].Text == string.Empty) // и когда находим пустую €чейку...
                    {
                        for (int k = i - 1; k >= 0; k--) // проходимс€ по каждой €чейке вверх от нее...
                        {
                            if (labelsMap[k, j].Text != string.Empty) // и когда находим ближайшую непустую €чейку...
                            {
                                labelsMap[i, j].Text = labelsMap[k, j].Text; // в нижнюю €чейку записываем число из верхней €чейки...
                                labelsMap[k, j].Text = string.Empty; // а верхнюю очищаем.
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void HandleUpArrowKeyPressing()
        {
            for (int j = 0; j < mapSize; j++) // ¬ каждой колонке...
            {
                for (int i = 0; i < mapSize; i++) // проходимс€ по каждой €чейке сверху вниз...
                {
                    if (labelsMap[i, j].Text != string.Empty) // и когда находим непустую €чейку...
                    {
                        for (int k = i + 1; k < mapSize; k++) // проходимс€ по каждой €чейке вниз от нее...
                        {
                            if (labelsMap[k, j].Text != string.Empty) // и когда находим ближайшую непустую €чейку...
                            {
                                if (labelsMap[k, j].Text == labelsMap[i, j].Text) // то если числа в этих непустых €чейках равны...
                                {
                                    var number = int.Parse(labelsMap[i, j].Text);
                                    labelsMap[i, j].Text = (number * 2).ToString(); // в верхнюю записываем их сумму...
                                    labelsMap[k, j].Text = string.Empty; // а нижнюю очищаем...
                                    score += number * 2; // и увеличиваем счет на эту сумму.
                                }
                                break;
                            }
                        }
                    }
                }
            }

            for (int j = 0; j < mapSize; j++) // ¬ каждой колонке...
            {
                for (int i = 0; i < mapSize; i++) // проходимс€ по каждой €чейке сверху вниз...
                {
                    if (labelsMap[i, j].Text == string.Empty) // и когда находим пустую €чейку...
                    {
                        for (int k = i + 1; k < mapSize; k++) // проходимс€ по каждой €чейке вниз от нее...
                        {
                            if (labelsMap[k, j].Text != string.Empty) // и когда находим ближайшую непустую €чейку...
                            {
                                labelsMap[i, j].Text = labelsMap[k, j].Text; // в верхнюю €чейку записываем число из нижней €чейки...
                                labelsMap[k, j].Text = string.Empty; // а нижнюю очищаем.
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void HandleLeftArrowKeyPressing()
        {
            for (int i = 0; i < mapSize; i++) // ¬ каждой строчке...
            {
                for (int j = 0; j < mapSize; j++) // проходимс€ по каждой €чейке слева направо...
                {
                    if (labelsMap[i, j].Text != string.Empty) // и когда находим непустую €чейку...
                    {
                        for (int k = j + 1; k < mapSize; k++) // проходимс€ по каждой €чейке справа от нее...
                        {
                            if (labelsMap[i, k].Text != string.Empty) // и когда находим ближайшую непустую €чейку...
                            {
                                if (labelsMap[i, k].Text == labelsMap[i, j].Text) // то если числа в этих непустых €чейках равны...
                                {
                                    var number = int.Parse(labelsMap[i, j].Text);
                                    labelsMap[i, j].Text = (number * 2).ToString(); // в левую записываем их сумму...
                                    labelsMap[i, k].Text = string.Empty; // а правую очищаем...
                                    score += number * 2; // и увеличиваем счет на эту сумму.
                                }
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < mapSize; i++) // ¬ каждой строчке...
            {
                for (int j = 0; j < mapSize; j++) // проходимс€ по каждой €чейке слева направо...
                {
                    if (labelsMap[i, j].Text == string.Empty) // и когда находим пустую €чейку...
                    {
                        for (int k = j + 1; k < mapSize; k++) // проходимс€ по каждой €чейке справа от нее...
                        {
                            if (labelsMap[i, k].Text != string.Empty) // и когда находим ближайшую непустую €чейку...
                            {
                                labelsMap[i, j].Text = labelsMap[i, k].Text; // в левую €чейку записываем число из правой €чейки...
                                labelsMap[i, k].Text = string.Empty; // а правую очищаем.
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void HandleRightArrowKeyPressing()
        {
            for (int i = 0; i < mapSize; i++) // ¬ каждой строчке...
            {
                for (int j = mapSize - 1; j >= 0; j--) // проходимс€ по каждой €чейке справа налево...
                {
                    if (labelsMap[i, j].Text != string.Empty) // и когда находим непустую €чейку...
                    {
                        for (int k = j - 1; k >= 0; k--) // проходимс€ по каждой €чейке слева от нее...
                        {
                            if (labelsMap[i, k].Text != string.Empty) // и когда находим ближайшую непустую €чейку...
                            {
                                if (labelsMap[i, k].Text == labelsMap[i, j].Text) // то если числа в этих непустых €чейках равны...
                                {
                                    var number = int.Parse(labelsMap[i, j].Text);
                                    labelsMap[i, j].Text = (number * 2).ToString(); // в правую записываем их сумму...
                                    labelsMap[i, k].Text = string.Empty; // а левую очищаем...
                                    score += number * 2; // и увеличиваем счет на эту сумму.
                                }
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < mapSize; i++) // ¬ каждой строчке...
            {
                for (int j = mapSize - 1; j >= 0; j--) // проходимс€ по каждой €чейке справа налево...
                {
                    if (labelsMap[i, j].Text == string.Empty) // и когда находим пустую €чейку...
                    {
                        for (int k = j - 1; k >= 0; k--) // проходимс€ по каждой €чейке слева от нее...
                        {
                            if (labelsMap[i, k].Text != string.Empty) // и когда находим ближайшую непустую €чейку...
                            {
                                labelsMap[i, j].Text = labelsMap[i, k].Text; // в правую €чейку записываем число из левой €чейки...
                                labelsMap[i, k].Text = string.Empty; // а левую очищаем.
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void GenerateNumber()
        {
            var mapHasEmptyLabels = MapHasEmptyLabels();
            while (mapHasEmptyLabels)
            {
                var labelNumber = random.Next(mapSize * mapSize);
                var rowIndex = labelNumber / mapSize;
                var columnIndex = labelNumber % mapSize;
                if (labelsMap[rowIndex, columnIndex].Text == string.Empty)
                {
                    //randomly generate either 2 or 4... 75% for 2 and 25% for 4
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

        private void ShowScore()
        {
            scoreLabel.Text = score.ToString();
        }

        private void InitMap()
        {
            labelsMap = new Label[mapSize, mapSize];

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    var newLabel = GetNewLabel(i, j);
                    Controls.Add(newLabel);
                    labelsMap[i, j] = newLabel;
                }
            }
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
    }
}
