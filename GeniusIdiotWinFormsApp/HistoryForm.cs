using GeniusIdiotCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

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
            if (File.Exists("UsersStorage.txt"))
            {
                var allUsers = UsersStorage.GetAll();
                foreach (var user in allUsers)
                {
                    historyDataGridView.Rows.Add(user.Name, user.Score, user.Diagnosis);
                }
            }
        }
    }
}
