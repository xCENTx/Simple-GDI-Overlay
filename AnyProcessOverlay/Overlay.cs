using Any_Process_Overlay.Helpers;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Any_Process_Overlay
{
    public partial class Overlay : Form
    {
        RECT rect;

        public string WINDOW_NAME { get; }

        public struct RECT
        {
            public int left, top, right, bottom;
        }

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
            WINDOW_NAME = MainForm.WINDOW_NAME;
        }

        private void Overlay_Load(object sender, EventArgs e)
        {
            IntPtr handle = FindWindow(null, WINDOW_NAME);
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

            KeyAssign();
        }

        private void OverlayTimer_Tick(object sender, EventArgs e)
        {
            IntPtr handle = FindWindow(null, WINDOW_NAME);
            GetWindowRect(handle, out rect);
            Size = new Size(rect.right - rect.left, rect.bottom - rect.top);
            Top = rect.top;
            Left = rect.left;
            this.Refresh();
        }

        private void Overlay_Paint(object sender, PaintEventArgs e)
        {
            if (bMenuControl)
            {
                DrawMenuInfo(sender, e);
            }
            if (bShowBox)
            {
                DrawEntityBox(sender, e);
            }
        }

        #region DRAW

        #region //Methods
        public void DrawEntityBox(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen entityOutline = new Pen(Color.Red);
            Rectangle EntitySize = new Rectangle(693, 328, 80, 195);
            g.DrawRectangle(entityOutline, EntitySize);
        }

        public void DrawMenuInfo(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen myPen = new Pen(Color.Black);
            Brush redBrush = new SolidBrush(Color.Red);
            Brush blueBrush = new SolidBrush(Color.Blue);
            Brush GreenBrush = new SolidBrush(Color.LimeGreen);
            Brush blackFill = new SolidBrush(Color.Black);
            Font HeaderFont = new Font("Arial", 16);
            Font InfoTextFont = new Font("Arial", 10);
            PointF HeaderTextPos = new PointF(10.0F, 33.0F);
            PointF MenuOption1Pos = new PointF(10.0F, 50.0F);
            PointF MenuOption2Pos = new PointF(10.0F, 70.0F);
            PointF MenuOption3Pos = new PointF(10.0F, 149.0F);
            PointF MenuOption4Pos = new PointF(10.0F, 140.0F);
            Rectangle InfoBox = new Rectangle(8, 33, 168, 140);
            g.FillRectangle(blackFill, InfoBox);
            g.DrawString("xCENTx Menu", HeaderFont, redBrush, HeaderTextPos);
            if (!bAutoShoot)
            {
                g.DrawString("AUTOSHOOT (F9) : [ OFF ]", InfoTextFont, blueBrush, MenuOption1Pos);
            }
            else
            {
                g.DrawString("AUTOSHOOT (F9) : [ ON ]", InfoTextFont, GreenBrush, MenuOption1Pos);
            }
            if (!bShowBox)
            {
                g.DrawString("SHOW BOX (F10) : [ OFF ]", InfoTextFont, blueBrush, MenuOption2Pos);
            }
            else
            {
                g.DrawString("SHOW BOX (F10) : [ ON ]", InfoTextFont, GreenBrush, MenuOption2Pos);
            }
            g.DrawString("SHOW / HIDE (INSERT)", InfoTextFont, redBrush, MenuOption3Pos);
            g.DrawString("QUIT MENU (DELETE)", InfoTextFont, redBrush, MenuOption4Pos);
        }
        #endregion

        #endregion

        #region KEYBINDS
        public void KeyAssign()
        {
            KeysMgr keyMgr = new KeysMgr();
            keyMgr.AddKey(Keys.Insert);     // MENU
            keyMgr.AddKey(Keys.Up);         // UP
            keyMgr.AddKey(Keys.Down);       // DOWN
            keyMgr.AddKey(Keys.Delete);     // QUIT

            keyMgr.AddKey(Keys.F9);         // Auto Shoot
            keyMgr.AddKey(Keys.F10);        // Show Box

            keyMgr.AddKey(Keys.Left);
            keyMgr.AddKey(Keys.Right);

            keyMgr.KeyDownEvent += new KeysMgr.KeyHandler(KeyDownEvent);
        }

        public static bool IsKeyDown(int key)
        {
            return Convert.ToBoolean(Manager.GetKeyState(key) & Manager.KEY_PRESSED);
        }

        private void KeyDownEvent(int Id, string Name)
        {
            switch ((Keys)Id)
            {
                case Keys.Insert:
                    this.bMenuControl = !this.bMenuControl;
                    break;
                case Keys.Delete:
                    Quit();
                    break;
                case Keys.F9:
                    this.bAutoShoot = !this.bAutoShoot;
                    break;
                case Keys.F10:
                    this.bShowBox = !this.bShowBox;
                    break;
                case Keys.Up:
                    CycleMenuUp();
                    break;
                case Keys.Down:
                    CycleMenuDown();
                    break;
            }
        }
        #endregion

        #region MENU
        #region Variables
        private bool bMenuControl = true;
        private bool bAutoShoot = false;
        private bool bShowBox = false;

        private enum MnIndex
        {
            MN_AUTO_SHOOT,
            MN_SHOW_BOX,
        };
        private MnIndex currMnIndex = MnIndex.MN_AUTO_SHOOT;
        private int LastMenuIndex = Enum.GetNames(typeof(MnIndex)).Length - 1;
        #endregion

        #region Methods
        private void Toggle(MnIndex index)
        {
            switch (index)
            {
                case MnIndex.MN_AUTO_SHOOT:
                    bAutoShoot = !bAutoShoot;
                    break;
                case MnIndex.MN_SHOW_BOX:
                    bShowBox = !bShowBox;
                    break;
            }
        }

        private void CycleMenuDown()
        {
            if (bMenuControl)
                currMnIndex = (MnIndex)((int)currMnIndex >= LastMenuIndex ? 0 : (int)currMnIndex + 1);
        }

        private void CycleMenuUp()
        {
            if (bMenuControl)
                currMnIndex = (MnIndex)((int)currMnIndex <= 0 ? LastMenuIndex : (int)currMnIndex - 1);
        }
        #endregion
        #endregion

        private void Quit()
        {
            // Close main process
            Environment.Exit(0);
        }
    }
}
