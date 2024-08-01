
namespace Frame_Ninja
{
    partial class CursorTrailNodes
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
            this.trailtimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // trailtimer
            // 
            this.trailtimer.Enabled = true;
            this.trailtimer.Interval = 1;
            this.trailtimer.Tick += new System.EventHandler(this.trailtimer_Tick);
            // 
            // CursorTrailNodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(10, 10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(10, 10);
            this.Name = "CursorTrailNodes";
            this.Text = "CursorTrailNodes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer trailtimer;
    }
}