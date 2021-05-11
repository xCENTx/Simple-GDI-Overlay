using System;
using System.Windows.Forms;

namespace GDI_OVERLAY
{
    public partial class MainForm : Form
    {
        Overlay frm = new Overlay();

        public MainForm()
        {
            InitializeComponent();
        }

        private void OverlayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OverlayCheckBox.Checked)
            {
                frm.Show();
            }
            else
            {
                frm.Hide();
            }
        }
    }
}
