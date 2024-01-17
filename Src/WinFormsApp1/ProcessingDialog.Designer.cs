namespace WinFormsApp1
{
    partial class ProcessingDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ProgressBar progressBar1;

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
            progressBar1 = new ProgressBar();
            txtStatus = new TextBox();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(10, 25);
            progressBar1.MarqueeAnimationSpeed = 50;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(373, 23);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 0;
            // 
            // txtStatus
            // 
            txtStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtStatus.BackColor = SystemColors.Control;
            txtStatus.BorderStyle = BorderStyle.FixedSingle;
            txtStatus.Location = new Point(12, 66);
            txtStatus.Multiline = true;
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(371, 65);
            txtStatus.TabIndex = 1;
            // 
            // ProcessingDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(393, 143);
            Controls.Add(txtStatus);
            Controls.Add(progressBar1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProcessingDialog";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "処理中";
            Shown += ProcessingDialog_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtStatus;
    }
}
