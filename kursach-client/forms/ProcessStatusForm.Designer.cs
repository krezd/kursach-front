namespace kursach_client.forms
{
    partial class ProcessStatusForm
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
            this.statusFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // statusFlowLayout
            // 
            this.statusFlowLayout.AutoScroll = true;
            this.statusFlowLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusFlowLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.statusFlowLayout.Location = new System.Drawing.Point(0, 64);
            this.statusFlowLayout.Name = "statusFlowLayout";
            this.statusFlowLayout.Size = new System.Drawing.Size(580, 654);
            this.statusFlowLayout.TabIndex = 0;
            this.statusFlowLayout.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(148, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Статусы процессов";
            // 
            // ProcessStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(580, 718);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusFlowLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcessStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProcessStatusForm";
            this.Load += new System.EventHandler(this.ProcessStatusForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel statusFlowLayout;
        private System.Windows.Forms.Label label1;
    }
}