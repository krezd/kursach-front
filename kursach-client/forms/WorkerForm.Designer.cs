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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.trackingButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            this.workerSettingsButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.updateSessionButton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.searchByDateButton = new System.Windows.Forms.Button();
            this.processPanel = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.SessionNameLabel = new System.Windows.Forms.Label();
            this.processDataGrid = new System.Windows.Forms.DataGridView();
            this.statusButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.processPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // trackingButton
            // 
            this.trackingButton.Location = new System.Drawing.Point(29, 93);
            this.trackingButton.Margin = new System.Windows.Forms.Padding(6);
            this.trackingButton.Name = "trackingButton";
            this.trackingButton.Size = new System.Drawing.Size(214, 94);
            this.trackingButton.TabIndex = 0;
            this.trackingButton.Text = "Начать отслеживание";
            this.trackingButton.UseVisualStyleBackColor = true;
            this.trackingButton.Click += new System.EventHandler(this.trackingButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logoutButton.Location = new System.Drawing.Point(2790, 48);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(181, 57);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Выйти";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click_1);
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.AutoEllipsis = true;
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelName.Location = new System.Drawing.Point(2580, 36);
            this.labelName.Name = "labelName";
            this.labelName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelName.Size = new System.Drawing.Size(108, 39);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "name";
            // 
            // labelPosition
            // 
            this.labelPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPosition.AutoEllipsis = true;
            this.labelPosition.AutoSize = true;
            this.labelPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPosition.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelPosition.Location = new System.Drawing.Point(2564, 102);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelPosition.Size = new System.Drawing.Size(119, 33);
            this.labelPosition.TabIndex = 3;
            this.labelPosition.Text = "Position";
            // 
            // workerSettingsButton
            // 
            this.workerSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.workerSettingsButton.Location = new System.Drawing.Point(2790, 137);
            this.workerSettingsButton.Name = "workerSettingsButton";
            this.workerSettingsButton.Size = new System.Drawing.Size(181, 77);
            this.workerSettingsButton.TabIndex = 4;
            this.workerSettingsButton.Text = "Настройки пользователя";
            this.workerSettingsButton.UseVisualStyleBackColor = true;
            this.workerSettingsButton.Click += new System.EventHandler(this.workerSettingsButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 433);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1180, 582);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // updateSessionButton
            // 
            this.updateSessionButton.Location = new System.Drawing.Point(995, 378);
            this.updateSessionButton.Name = "updateSessionButton";
            this.updateSessionButton.Size = new System.Drawing.Size(214, 42);
            this.updateSessionButton.TabIndex = 6;
            this.updateSessionButton.Text = "Обновить";
            this.updateSessionButton.UseVisualStyleBackColor = true;
            this.updateSessionButton.Click += new System.EventHandler(this.updateSessionButton_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "\"yyyy-MM-dd\"";
            this.dateTimePicker1.Location = new System.Drawing.Point(29, 389);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(236, 31);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // searchByDateButton
            // 
            this.searchByDateButton.Location = new System.Drawing.Point(296, 385);
            this.searchByDateButton.Name = "searchByDateButton";
            this.searchByDateButton.Size = new System.Drawing.Size(214, 42);
            this.searchByDateButton.TabIndex = 8;
            this.searchByDateButton.Text = "Поиск";
            this.searchByDateButton.UseVisualStyleBackColor = true;
            this.searchByDateButton.Click += new System.EventHandler(this.searchByDateButton_Click);
            // 
            // processPanel
            // 
            this.processPanel.Controls.Add(this.chart1);
            this.processPanel.Controls.Add(this.pictureBox2);
            this.processPanel.Controls.Add(this.SessionNameLabel);
            this.processPanel.Controls.Add(this.processDataGrid);
            this.processPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.processPanel.Location = new System.Drawing.Point(0, 287);
            this.processPanel.Name = "processPanel";
            this.processPanel.Size = new System.Drawing.Size(2564, 598);
            this.processPanel.TabIndex = 9;
            this.processPanel.Visible = false;
            this.processPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.processPanel_Paint);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(1322, 8);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1207, 606);
            this.chart1.TabIndex = 103;
            this.chart1.Text = "chart1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::kursach_client.Properties.Resources.back_icon;
            this.pictureBox2.Location = new System.Drawing.Point(15, 8);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(74, 68);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 102;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // SessionNameLabel
            // 
            this.SessionNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SessionNameLabel.AutoEllipsis = true;
            this.SessionNameLabel.AutoSize = true;
            this.SessionNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SessionNameLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SessionNameLabel.Location = new System.Drawing.Point(117, 27);
            this.SessionNameLabel.Name = "SessionNameLabel";
            this.SessionNameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SessionNameLabel.Size = new System.Drawing.Size(225, 39);
            this.SessionNameLabel.TabIndex = 10;
            this.SessionNameLabel.Text = "SessionDate";
            // 
            // processDataGrid
            // 
            this.processDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.processDataGrid.Location = new System.Drawing.Point(12, 85);
            this.processDataGrid.Name = "processDataGrid";
            this.processDataGrid.RowHeadersWidth = 82;
            this.processDataGrid.RowTemplate.Height = 33;
            this.processDataGrid.Size = new System.Drawing.Size(1180, 585);
            this.processDataGrid.TabIndex = 6;
            this.processDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.processDataGrid_CellClick);
            // 
            // statusButton
            // 
            this.statusButton.Location = new System.Drawing.Point(2365, 110);
            this.statusButton.Name = "statusButton";
            this.statusButton.Size = new System.Drawing.Size(187, 77);
            this.statusButton.TabIndex = 10;
            this.statusButton.Text = "Статусы процессов";
            this.statusButton.UseVisualStyleBackColor = true;
            this.statusButton.Click += new System.EventHandler(this.statusButton_Click);
            // 
            // WorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(2564, 885);
            this.Controls.Add(this.statusButton);
            this.Controls.Add(this.processPanel);
            this.Controls.Add(this.searchByDateButton);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.updateSessionButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.workerSettingsButton);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.trackingButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "WorkerForm";
            this.Text = "WorkerPanel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WorkerForm_FormClosed_1);
            this.Load += new System.EventHandler(this.WorkerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.processPanel.ResumeLayout(false);
            this.processPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button trackingButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Button workerSettingsButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button updateSessionButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button searchByDateButton;
        private System.Windows.Forms.Panel processPanel;
        private System.Windows.Forms.DataGridView processDataGrid;
        private System.Windows.Forms.Label SessionNameLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button statusButton;
    }
}