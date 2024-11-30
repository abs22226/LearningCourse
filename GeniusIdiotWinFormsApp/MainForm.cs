using GeniusIdiotConsApp;
using System.Windows;

namespace GeniusIdiotWinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            SetSizes();


        }

        private void SetSizes()
        {
            this.MaximumSize = new Size(430, 489);
            this.MinimumSize = new Size(430, 489);

            questionTextLabel.MaximumSize = new Size(296, 90);
        }
    }
}
