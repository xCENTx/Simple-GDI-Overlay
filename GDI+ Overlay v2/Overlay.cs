using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using Memory;
using GDI__Overlay_v2.Helpers;

namespace GDI__Overlay_v2
{
    public partial class Overlay : Form
    {
        #region WINDOW SETUP

        public const string WINDOW_NAME = "Grand Theft Auto V";
        IntPtr handle = FindWindow(null, WINDOW_NAME);

        RECT rect;

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

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        #endregion

        #region INITIALIZE
        public Overlay()
        {
            InitializeComponent();
        }

        private void Overlay_Load(object sender, EventArgs e)
        {
            int PID = m.GetProcIdFromName(GTAVPROCESSNAME);
            if (PID > 0)
            {
                m.OpenProcess(PID);
                Thread TB = new Thread(triggerbot) { IsBackground = true };
                TB.Start();
            }

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

            // Init Key Listener
            KeyAssign();
        }

        private void OverlayClose(object sender, FormClosingEventArgs e)
        {
            Quit();
        }

        private void WindowHookTimer_Tick(object sender, EventArgs e)
        {
            GetWindowRect(handle, out rect);
            Size = new Size(rect.right - rect.left, rect.bottom - rect.top);
            Top = rect.top;
            Left = rect.left;
            this.Refresh();
            //Stuff.GetEntityPosition();
            //Stuff.GetHeadPosition();
        }

        private void ProcessTimer_Tick(object sender, EventArgs e)
        {
            int PID = m.GetProcIdFromName(GTAVPROCESSNAME);
            if (PID > 0)
            {
                m.OpenProcess(PID);
                gtavRunning = true;
                return;
            }
            gtavRunning = false;
        }

        private void MemoryTimer_Tick(object sender, EventArgs e)
        {

        }

        #endregion

        #region PROCESS INFO
        Mem m = new Mem();
        private const string GTAVPROCESSNAME = "GTA5.exe";
        bool gtavRunning;

        [DllImport("user32.dll")]
        public static extern void mouse_event(int a, int b, int c, int d, int damnIwonderifpeopleactuallyreadsthis);

        int leftDown = 0x02;
        int leftUp = 0x04;
        int flag = 0;

        #region // Auto Shoot
        void shoot(int delay)
        {
            mouse_event(leftDown, 0, 0, 0, 0);
            Thread.Sleep(1);
            mouse_event(leftUp, 0, 0, 0, 0);
            Thread.Sleep(delay);
        }

        void triggerbot()
        {

            while (true)
            {
                if (GetAsyncKeyState(Keys.RButton) < 0)
                {
                    flag = m.ReadInt("GTA5.exe+1FB2380");
                    if (flag >= 1 && bAutoShoot)
                    {
                        shoot(10);
                        shoot(1);
                    }
                }
                Thread.Sleep(1);
            }
        }
        #endregion

        #endregion

        #region DRAW
        Graphics g;
        Pen myPen = new Pen(Color.Red);

        public void drawSnapLines(int x, int y)
        {
            g.DrawLine(myPen, 1920 / 2, 1080, x, y);
        }

        public void drawBox(int x, int y, float width, float height)
        {
            g.DrawRectangle(myPen, x, y, width, height);
        }

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
            PointF HeaderTextPos = new PointF(0.0F, 25.0F);
            PointF MenuOption1Pos = new PointF(2.0F, 50.0F);
            PointF MenuOption2Pos = new PointF(2.0F, 70.0F);
            PointF MenuOption3Pos = new PointF(2.0F, 149.0F);
            PointF MenuOption4Pos = new PointF(2.0F, 140.0F);
            Rectangle InfoBox = new Rectangle(3, 26, 168, 140);
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

        private string GetMenuString(MnIndex idx)
        {
            string result = "";

            switch (idx)
            {
                case MnIndex.MN_AUTO_SHOOT:
                    result = "AUTO SHOOT : " + (bAutoShoot ? "[ ON ]" : "[ OFF ]");
                    break;
                case MnIndex.MN_SHOW_BOX:
                    result = "SHOW BOX" + (bShowBox ? "[ ON ]" : "[ OFF ]");
                    break;
            }

            return result;
        }
        #endregion
        #endregion

        private void OverlayPaint(object sender, PaintEventArgs e)
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

        private void Quit()
        {
            m.CloseProcess();

            // Close main process
            Environment.Exit(0);
        }
    }
}
