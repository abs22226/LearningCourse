using GeniusIdiotCommon;

namespace GeniusIdiotWinFormsApp
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            var allUsers = UsersStorage.GetAll();
            foreach (var user in allUsers)
            {
                historyDataGridView.Rows.Add(user.Name, user.Score, user.Diagnosis);
            }
        }
    }
}
