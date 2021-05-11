
namespace GDI_OVERLAY
{
    partial class MainForm
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
            this.OverlayCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // OverlayCheckBox
            // 
            this.OverlayCheckBox.AutoSize = true;
            this.OverlayCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.OverlayCheckBox.ForeColor = System.Drawing.Color.Red;
            this.OverlayCheckBox.Location = new System.Drawing.Point(12, 12);
            this.OverlayCheckBox.Name = "OverlayCheckBox";
            this.OverlayCheckBox.Size = new System.Drawing.Size(217, 35);
            this.OverlayCheckBox.TabIndex = 0;
            this.OverlayCheckBox.Text = "Toggle Overlay";
            this.OverlayCheckBox.UseVisualStyleBackColor = true;
            this.OverlayCheckBox.CheckedChanged += new System.EventHandler(this.OverlayCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(234, 61);
            this.Controls.Add(this.OverlayCheckBox);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "GDI Overlay";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox OverlayCheckBox;
    }
}

