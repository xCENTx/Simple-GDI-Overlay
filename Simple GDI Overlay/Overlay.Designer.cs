
namespace GDI_OVERLAY
{
    partial class Overlay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.OverlayTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // OverlayTimer
            // 
            this.OverlayTimer.Tick += new System.EventHandler(this.OverlayTimer_Tick);
            // 
            // Overlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Name = "Overlay";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FormOverlay_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormOverlay_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer OverlayTimer;
    }
}