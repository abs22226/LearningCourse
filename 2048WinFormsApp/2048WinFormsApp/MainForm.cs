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
            for (int j = 0; j < mapSize; j++) // В каждой колонке...
            {
                for (int i = mapSize - 1; i >= 0; i--) // проходимся по каждой ячейке снизу вверх...
                {
                    if (labelsMap[i, j].Text != string.Empty) // и когда находим непустую ячейку...
                    {
                        for (int k = i - 1; k >= 0; k--) // проходимся по каждой ячейке вверх от нее...
                        {
                            if (labelsMap[k, j].Text != string.Empty) // и когда находим ближайшую непустую ячейку...
                            {
                                if (labelsMap[k, j].Text == labelsMap[i, j].Text) // то если числа в этих непустых ячейках равны...
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

            for (int j = 0; j < mapSize; j++) // В каждой колонке...
            {
                for (int i = mapSize - 1; i >= 0; i--) // проходимся по каждой ячейке снизу вверх...
                {
                    if (labelsMap[i, j].Text == string.Empty) // и когда находим пустую ячейку...
                    {
                        for (int k = i - 1; k >= 0; k--) // проходимся по каждой ячейке вверх от нее...
                        {
                            if (labelsMap[k, j].Text != string.Empty) // и когда находим ближайшую непустую ячейку...
                            {
                                labelsMap[i, j].Text = labelsMap[k, j].Text; // в нижнюю ячейку записываем число из верхней ячейки...
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
            for (int j = 0; j < mapSize; j++) // В каждой колонке...
            {
                for (int i = 0; i < mapSize; i++) // проходимся по каждой ячейке сверху вниз...
                {
                    if (labelsMap[i, j].Text != string.Empty) // и когда находим непустую ячейку...
                    {
                        for (int k = i + 1; k < mapSize; k++) // проходимся по каждой ячейке вниз от нее...
                        {
                            if (labelsMap[k, j].Text != string.Empty) // и когда находим ближайшую непустую ячейку...
                            {
                                if (labelsMap[k, j].Text == labelsMap[i, j].Text) // то если числа в этих непустых ячейках равны...
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

            for (int j = 0; j < mapSize; j++) // В каждой колонке...
            {
                for (int i = 0; i < mapSize; i++) // проходимся по каждой ячейке сверху вниз...
                {
                    if (labelsMap[i, j].Text == string.Empty) // и когда находим пустую ячейку...
                    {
                        for (int k = i + 1; k < mapSize; k++) // проходимся по каждой ячейке вниз от нее...
                        {
                            if (labelsMap[k, j].Text != string.Empty) // и когда находим ближайшую непустую ячейку...
                            {
                                labelsMap[i, j].Text = labelsMap[k, j].Text; // в верхнюю ячейку записываем число из нижней ячейки...
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
            for (int i = 0; i < mapSize; i++) // В каждой строчке...
            {
                for (int j = 0; j < mapSize; j++) // проходимся по каждой ячейке слева направо...
                {
                    if (labelsMap[i, j].Text != string.Empty) // и когда находим непустую ячейку...
                    {
                        for (int k = j + 1; k < mapSize; k++) // проходимся по каждой ячейке справа от нее...
                        {
                            if (labelsMap[i, k].Text != string.Empty) // и когда находим ближайшую непустую ячейку...
                            {
                                if (labelsMap[i, k].Text == labelsMap[i, j].Text) // то если числа в этих непустых ячейках равны...
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

            for (int i = 0; i < mapSize; i++) // В каждой строчке...
            {
                for (int j = 0; j < mapSize; j++) // проходимся по каждой ячейке слева направо...
                {
                    if (labelsMap[i, j].Text == string.Empty) // и когда находим пустую ячейку...
                    {
                        for (int k = j + 1; k < mapSize; k++) // проходимся по каждой ячейке справа от нее...
                        {
                            if (labelsMap[i, k].Text != string.Empty) // и когда находим ближайшую непустую ячейку...
                            {
                                labelsMap[i, j].Text = labelsMap[i, k].Text; // в левую ячейку записываем число из правой ячейки...
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
            for (int i = 0; i < mapSize; i++) // В каждой строчке...
            {
                for (int j = mapSize - 1; j >= 0; j--) // проходимся по каждой ячейке справа налево...
                {
                    if (labelsMap[i, j].Text != string.Empty) // и когда находим непустую ячейку...
                    {
                        for (int k = j - 1; k >= 0; k--) // проходимся по каждой ячейке слева от нее...
                        {
                            if (labelsMap[i, k].Text != string.Empty) // и когда находим ближайшую непустую ячейку...
                            {
                                if (labelsMap[i, k].Text == labelsMap[i, j].Text) // то если числа в этих непустых ячейках равны...
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

            for (int i = 0; i < mapSize; i++) // В каждой строчке...
            {
                for (int j = mapSize - 1; j >= 0; j--) // проходимся по каждой ячейке справа налево...
                {
                    if (labelsMap[i, j].Text == string.Empty) // и когда находим пустую ячейку...
                    {
                        for (int k = j - 1; k >= 0; k--) // проходимся по каждой ячейке слева от нее...
                        {
                            if (labelsMap[i, k].Text != string.Empty) // и когда находим ближайшую непустую ячейку...
                            {
                                labelsMap[i, j].Text = labelsMap[i, k].Text; // в правую ячейку записываем число из левой ячейки...
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
                    //TODO: randomly generate either 2 or 4
                    labelsMap[rowIndex, columnIndex].Text = "2";
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
    }
}
