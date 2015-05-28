using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeDownloader.Controllers;
using YoutubeDownloader.Models;

namespace YoutubeDownloader
{
    public partial class FrmChooseQuality : Form
    {
        public ChooseQualityController m_controller;
                
        public VideoQualityModel GetSelectedQuality()
        {
            return cbAvailableQualities.SelectedItem as VideoQualityModel;
        }

        public FrmChooseQuality(YoutubeVideoModel model)
        {
            InitializeComponent();

            m_controller = new ChooseQualityController(model);
            cbAvailableQualities.DataSource = m_controller.GetQualities();
            cbAvailableQualities.SelectedItem = m_controller.GetSelectedQuality();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (GetSelectedQuality() != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Bitte Eingabe überprüfen, es muss eine Qualität ausgewählt werden!",
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cbAvailableQualities_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedElem = GetSelectedQuality();
            if(selectedElem != null)
            {
                txtDimension.Text = selectedElem.Dimensions.Width + "x" + selectedElem.Dimensions.Height;
                txtExtension.Text = selectedElem.Extension;
            }
        }
    }
}
