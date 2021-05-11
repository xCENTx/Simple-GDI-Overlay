using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GDI_OVERLAY
{
    public partial class Overlay : Form
    {
        RECT rect;

        //Make sure you insert the window name for which you want to draw over
        public const string WINDOW_NAME = "INSERT WINDOW NAME HERE";
        IntPtr handle = FindWindow(null, WINDOW_NAME);

        public struct RECT
        {
            public int left, top, right, bottom;
        }

        public void drawSnapLines(int x, int y)
        {
            g.DrawLine(myPen, 1920 / 2, 1080, x, y);
        }

        public void drawBox(int x, int y, float width, float height)
        {
            g.DrawRectangle(myPen, x, y, width, height);
        }

        Graphics g;
        Pen myPen = new Pen(Color.Red);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string IpClassName, string IpWindowName);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT IpRect);

        public Overlay()
        {
            InitializeComponent();
        }

        private void FormOverlay_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Orange;
            this.TransparencyKey = Color.Orange;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;

            int InitialStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, InitialStyle | 0x800000 | 0x20);

            GetWindowRect(handle, out rect);
            this.Size = new Size(rect.right - rect.left, rect.bottom - rect.top);
            this.Top = rect.top;
            this.Left = rect.left;

        }

        private void OverlayTimer_Tick(object sender, EventArgs e)
        {
            GetWindowRect(handle, out rect);
            Size = new Size(rect.right - rect.left, rect.bottom - rect.top);
            Top = rect.top;
            Left = rect.left;
            this.Refresh();
            //Stuff.GetEntityPosition();
            //Stuff.GetHeadPosition();
        }

        private void FormOverlay_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawRectangle(myPen, 960, 540, 100, 100);
        }
    }
}
