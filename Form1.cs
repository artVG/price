using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace price
{
    public partial class Price : Form
    {
        public Price()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                file_location.Text = openFileDialog.FileName;
            }
        }

        private void SaveAt_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] file = FileIO.OpenFile(file_location.Text);
                List<string[]> prices = PriceListParser.ParseLines(file);
                FileIO.WriteFile(saveFileDialog.FileName, prices);
            }
        }
    }
}
