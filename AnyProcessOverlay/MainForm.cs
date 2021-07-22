using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Memory;


namespace Any_Process_Overlay
{
    public partial class MainForm : Form
    {
        Mem m = new Mem();
        bool ProcessConnected = false;
        public static string WINDOW_NAME;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            WindowStatus_Label.Text = "WAITING . . .";
            WindowStatus_Label.ForeColor = Color.FromArgb(169, 0, 0);
        }

        private void ProcessTimer_Tick(object sender, EventArgs e)
        {
            Process[] SELECTEDPROCESS = Process.GetProcessesByName(SELECTEDPROCESS_LABEL.Text);
            if (SELECTEDPROCESS.Length > 0)
            {
                ProcessConnected = true;
                ProcStatus_Label.Text = "CONNECTED";
                ProcStatus_Label.ForeColor = Color.FromArgb(0, 169, 0);
                return;
            }
            ProcStatus_Label.Text = "WAITING . . .";
            ProcStatus_Label.ForeColor = Color.FromArgb(169, 0, 0);
            ProcessConnected = false;


        }

        private void SelectProcess_button_Click(object sender, EventArgs e)
        {
            SELECTEDPROCESS_LABEL.Text = SelectedProcess_textBox.Text;
        }

        private void SelectWindow_Button_Click(object sender, EventArgs e)
        {
            if (!ProcessConnected)
            {
                return;
            }

            if (SelectedWindow_textBox.Text != "")
            {
                WindowStatus_Label.Text = "HOOKED";
                WindowStatus_Label.ForeColor = Color.FromArgb(0, 169, 0);

                //Generate overlay based on text input
                SELECTEDWINDOW_LABEL.Text = SelectedWindow_textBox.Text;
                WINDOW_NAME = SELECTEDWINDOW_LABEL.Text;
                Overlay frm2 = new Overlay();
                frm2.Show();
            }
        }
    }
}
