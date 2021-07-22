
namespace Any_Process_Overlay
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
            this.components = new System.ComponentModel.Container();
            this.ProcessTimer = new System.Windows.Forms.Timer(this.components);
            this.SelectedProcess_textBox = new System.Windows.Forms.TextBox();
            this.SelectProcess_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ProcStatus_Label = new System.Windows.Forms.Label();
            this.WindowStatus_Label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SelectWindow_Button = new System.Windows.Forms.Button();
            this.SelectedWindow_textBox = new System.Windows.Forms.TextBox();
            this.SELECTEDPROCESS_LABEL = new System.Windows.Forms.Label();
            this.SELECTEDWINDOW_LABEL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ProcessTimer
            // 
            this.ProcessTimer.Enabled = true;
            this.ProcessTimer.Tick += new System.EventHandler(this.ProcessTimer_Tick);
            // 
            // SelectedProcess_textBox
            // 
            this.SelectedProcess_textBox.Location = new System.Drawing.Point(12, 28);
            this.SelectedProcess_textBox.Name = "SelectedProcess_textBox";
            this.SelectedProcess_textBox.Size = new System.Drawing.Size(100, 20);
            this.SelectedProcess_textBox.TabIndex = 0;
            // 
            // SelectProcess_button
            // 
            this.SelectProcess_button.Location = new System.Drawing.Point(118, 26);
            this.SelectProcess_button.Name = "SelectProcess_button";
            this.SelectProcess_button.Size = new System.Drawing.Size(75, 23);
            this.SelectProcess_button.TabIndex = 1;
            this.SelectProcess_button.Text = "SELECT";
            this.SelectProcess_button.UseVisualStyleBackColor = true;
            this.SelectProcess_button.Click += new System.EventHandler(this.SelectProcess_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "PROCESS:";
            // 
            // ProcStatus_Label
            // 
            this.ProcStatus_Label.AutoSize = true;
            this.ProcStatus_Label.Location = new System.Drawing.Point(199, 31);
            this.ProcStatus_Label.Name = "ProcStatus_Label";
            this.ProcStatus_Label.Size = new System.Drawing.Size(83, 13);
            this.ProcStatus_Label.TabIndex = 4;
            this.ProcStatus_Label.Text = "PROC STATUS";
            // 
            // WindowStatus_Label
            // 
            this.WindowStatus_Label.AutoSize = true;
            this.WindowStatus_Label.Location = new System.Drawing.Point(199, 75);
            this.WindowStatus_Label.Name = "WindowStatus_Label";
            this.WindowStatus_Label.Size = new System.Drawing.Size(102, 13);
            this.WindowStatus_Label.TabIndex = 8;
            this.WindowStatus_Label.Text = "WINDOW STATUS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "WINDOW NAME:";
            // 
            // SelectWindow_Button
            // 
            this.SelectWindow_Button.Location = new System.Drawing.Point(118, 70);
            this.SelectWindow_Button.Name = "SelectWindow_Button";
            this.SelectWindow_Button.Size = new System.Drawing.Size(75, 23);
            this.SelectWindow_Button.TabIndex = 6;
            this.SelectWindow_Button.Text = "SELECT";
            this.SelectWindow_Button.UseVisualStyleBackColor = true;
            this.SelectWindow_Button.Click += new System.EventHandler(this.SelectWindow_Button_Click);
            // 
            // SelectedWindow_textBox
            // 
            this.SelectedWindow_textBox.Location = new System.Drawing.Point(12, 72);
            this.SelectedWindow_textBox.Name = "SelectedWindow_textBox";
            this.SelectedWindow_textBox.Size = new System.Drawing.Size(100, 20);
            this.SelectedWindow_textBox.TabIndex = 5;
            // 
            // SELECTEDPROCESS_LABEL
            // 
            this.SELECTEDPROCESS_LABEL.AutoSize = true;
            this.SELECTEDPROCESS_LABEL.ForeColor = System.Drawing.SystemColors.Control;
            this.SELECTEDPROCESS_LABEL.Location = new System.Drawing.Point(79, 12);
            this.SELECTEDPROCESS_LABEL.Name = "SELECTEDPROCESS_LABEL";
            this.SELECTEDPROCESS_LABEL.Size = new System.Drawing.Size(14, 13);
            this.SELECTEDPROCESS_LABEL.TabIndex = 9;
            this.SELECTEDPROCESS_LABEL.Text = "~";
            // 
            // SELECTEDWINDOW_LABEL
            // 
            this.SELECTEDWINDOW_LABEL.AutoSize = true;
            this.SELECTEDWINDOW_LABEL.ForeColor = System.Drawing.SystemColors.Control;
            this.SELECTEDWINDOW_LABEL.Location = new System.Drawing.Point(111, 56);
            this.SELECTEDWINDOW_LABEL.Name = "SELECTEDWINDOW_LABEL";
            this.SELECTEDWINDOW_LABEL.Size = new System.Drawing.Size(14, 13);
            this.SELECTEDWINDOW_LABEL.TabIndex = 10;
            this.SELECTEDWINDOW_LABEL.Text = "~";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 98);
            this.Controls.Add(this.SELECTEDWINDOW_LABEL);
            this.Controls.Add(this.SELECTEDPROCESS_LABEL);
            this.Controls.Add(this.WindowStatus_Label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SelectWindow_Button);
            this.Controls.Add(this.SelectedWindow_textBox);
            this.Controls.Add(this.ProcStatus_Label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectProcess_button);
            this.Controls.Add(this.SelectedProcess_textBox);
            this.Name = "MainForm";
            this.Text = "AnyWindowOverlay";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer ProcessTimer;
        private System.Windows.Forms.TextBox SelectedProcess_textBox;
        private System.Windows.Forms.Button SelectProcess_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ProcStatus_Label;
        private System.Windows.Forms.Label WindowStatus_Label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SelectWindow_Button;
        private System.Windows.Forms.TextBox SelectedWindow_textBox;
        private System.Windows.Forms.Label SELECTEDPROCESS_LABEL;
        private System.Windows.Forms.Label SELECTEDWINDOW_LABEL;
    }
}

