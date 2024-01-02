namespace VNVC_Jackpot
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblNumber = new System.Windows.Forms.Label();
            this.cbbSelectNumber = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDat = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNextSlot = new System.Windows.Forms.Label();
            this.lblInfoUser = new System.Windows.Forms.Label();
            this.dgvJackPot = new System.Windows.Forms.DataGridView();
            this.pieChart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pieChart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJackPot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieChart2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.Location = new System.Drawing.Point(41, 48);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(191, 33);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "Số Hiện Tại:  ";
            // 
            // cbbSelectNumber
            // 
            this.cbbSelectNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSelectNumber.FormattingEnabled = true;
            this.cbbSelectNumber.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbbSelectNumber.Location = new System.Drawing.Point(195, 161);
            this.cbbSelectNumber.Name = "cbbSelectNumber";
            this.cbbSelectNumber.Size = new System.Drawing.Size(121, 32);
            this.cbbSelectNumber.TabIndex = 1;
            this.cbbSelectNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbSelectNumber_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lựa chọn số: ";
            // 
            // btnDat
            // 
            this.btnDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDat.Location = new System.Drawing.Point(195, 207);
            this.btnDat.Name = "btnDat";
            this.btnDat.Size = new System.Drawing.Size(121, 36);
            this.btnDat.TabIndex = 3;
            this.btnDat.Text = "Đặt";
            this.btnDat.UseVisualStyleBackColor = true;
            this.btnDat.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Slot tiếp theo: ";
            // 
            // lblNextSlot
            // 
            this.lblNextSlot.AutoSize = true;
            this.lblNextSlot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextSlot.Location = new System.Drawing.Point(118, 322);
            this.lblNextSlot.Name = "lblNextSlot";
            this.lblNextSlot.Size = new System.Drawing.Size(0, 20);
            this.lblNextSlot.TabIndex = 5;
            // 
            // lblInfoUser
            // 
            this.lblInfoUser.AutoSize = true;
            this.lblInfoUser.Location = new System.Drawing.Point(13, 329);
            this.lblInfoUser.Name = "lblInfoUser";
            this.lblInfoUser.Size = new System.Drawing.Size(0, 13);
            this.lblInfoUser.TabIndex = 6;
            // 
            // dgvJackPot
            // 
            this.dgvJackPot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJackPot.Location = new System.Drawing.Point(404, 27);
            this.dgvJackPot.Name = "dgvJackPot";
            this.dgvJackPot.Size = new System.Drawing.Size(699, 302);
            this.dgvJackPot.TabIndex = 7;
            // 
            // pieChart1
            // 
            chartArea1.Name = "ChartArea1";
            this.pieChart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.pieChart1.Legends.Add(legend1);
            this.pieChart1.Location = new System.Drawing.Point(414, 368);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "s1";
            this.pieChart1.Series.Add(series1);
            this.pieChart1.Size = new System.Drawing.Size(333, 271);
            this.pieChart1.TabIndex = 8;
            this.pieChart1.Text = "chart1";
            // 
            // pieChart2
            // 
            chartArea2.Name = "ChartArea1";
            this.pieChart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.pieChart2.Legends.Add(legend2);
            this.pieChart2.Location = new System.Drawing.Point(770, 368);
            this.pieChart2.Name = "pieChart2";
            this.pieChart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "s1";
            this.pieChart2.Series.Add(series2);
            this.pieChart2.Size = new System.Drawing.Size(333, 271);
            this.pieChart2.TabIndex = 9;
            this.pieChart2.Text = "chart1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 665);
            this.Controls.Add(this.pieChart2);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.dgvJackPot);
            this.Controls.Add(this.lblInfoUser);
            this.Controls.Add(this.lblNextSlot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbSelectNumber);
            this.Controls.Add(this.lblNumber);
            this.Name = "MainForm";
            this.Text = "VNVC JackPot";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJackPot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieChart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.ComboBox cbbSelectNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNextSlot;
        private System.Windows.Forms.Label lblInfoUser;
        private System.Windows.Forms.DataGridView dgvJackPot;
        private System.Windows.Forms.DataVisualization.Charting.Chart pieChart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart pieChart2;
    }
}

