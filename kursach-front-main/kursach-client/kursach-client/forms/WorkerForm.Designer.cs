namespace kursach_client.forms
{
    partial class WorkerForm
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
            this.trackingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // trackingButton
            // 
            this.trackingButton.Location = new System.Drawing.Point(47, 359);
            this.trackingButton.Name = "trackingButton";
            this.trackingButton.Size = new System.Drawing.Size(107, 49);
            this.trackingButton.TabIndex = 0;
            this.trackingButton.Text = "Начать отслеживание";
            this.trackingButton.UseVisualStyleBackColor = true;
            this.trackingButton.Click += new System.EventHandler(this.trackingButton_Click);
            // 
            // WorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 623);
            this.Controls.Add(this.trackingButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "WorkerForm";
            this.Text = "WorkerForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WorkerForm_FormClosed_1);
            this.Load += new System.EventHandler(this.WorkerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button trackingButton;
    }
}