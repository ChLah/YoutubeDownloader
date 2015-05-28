using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeDownloader.Models;

namespace YoutubeDownloader
{
    public partial class FrmPickSearchResult : Form
    {
        private List<SearchVideoModel> m_searchResults;

        public SearchVideoModel GetSelectedVideo()
        {
            if (dgvResults.SelectedRows.Count != 1)
                return null;

            return dgvResults.SelectedRows[0].DataBoundItem as SearchVideoModel;
        }

        public FrmPickSearchResult(List<SearchVideoModel> searchResults)
        {
            InitializeComponent();

            if (searchResults == null)
                throw new ArgumentNullException("searchResults must not be null!");

            m_searchResults = searchResults;
            dgvResults.DataSource = m_searchResults;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(dgvResults.SelectedRows.Count != 1)
                MessageBox.Show("Es muss ein Video gewählt werden!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
