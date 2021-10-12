
namespace lab2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.trackBarAv9 = new System.Windows.Forms.TrackBar();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.executeV9 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.executeV19 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.executeV29 = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.trackBarAv19 = new System.Windows.Forms.TrackBar();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.trackBarBv29 = new System.Windows.Forms.TrackBar();
            this.trackBarAv29 = new System.Windows.Forms.TrackBar();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAv9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAv19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBv29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAv29)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(514, 591);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.trackBarAv9);
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Controls.Add(this.executeV9);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(506, 562);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Вариант 9";
            // 
            // trackBarAv9
            // 
            this.trackBarAv9.Location = new System.Drawing.Point(326, 14);
            this.trackBarAv9.Name = "trackBarAv9";
            this.trackBarAv9.Size = new System.Drawing.Size(172, 45);
            this.trackBarAv9.TabIndex = 13;
            this.trackBarAv9.Scroll += new System.EventHandler(this.trackBarAv9_Scroll);
            // 
            // chart1
            // 
            chartArea1.AxisX.LabelStyle.Format = "0.00";
            chartArea1.AxisY.LabelStyle.Format = "0.00";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chart1.Location = new System.Drawing.Point(3, 59);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Name = "Series1";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Black;
            series2.LabelBorderWidth = 2;
            series2.Name = "coordX";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Black;
            series3.LabelBorderWidth = 2;
            series3.Name = "coordY";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(500, 500);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // executeV9
            // 
            this.executeV9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.executeV9.Location = new System.Drawing.Point(8, 8);
            this.executeV9.Name = "executeV9";
            this.executeV9.Size = new System.Drawing.Size(100, 40);
            this.executeV9.TabIndex = 1;
            this.executeV9.Text = "Выполнить";
            this.executeV9.UseVisualStyleBackColor = true;
            this.executeV9.Click += new System.EventHandler(this.executeV9_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.trackBarAv19);
            this.tabPage2.Controls.Add(this.chart2);
            this.tabPage2.Controls.Add(this.executeV19);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(506, 562);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Вариант 19";
            // 
            // executeV19
            // 
            this.executeV19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.executeV19.Location = new System.Drawing.Point(8, 8);
            this.executeV19.Name = "executeV19";
            this.executeV19.Size = new System.Drawing.Size(100, 40);
            this.executeV19.TabIndex = 13;
            this.executeV19.Text = "Выполнить";
            this.executeV19.UseVisualStyleBackColor = true;
            this.executeV19.Click += new System.EventHandler(this.executeV19_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.trackBarAv29);
            this.tabPage3.Controls.Add(this.trackBarBv29);
            this.tabPage3.Controls.Add(this.chart3);
            this.tabPage3.Controls.Add(this.executeV29);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(506, 562);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Вариант 29";
            // 
            // executeV29
            // 
            this.executeV29.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.executeV29.Location = new System.Drawing.Point(8, 8);
            this.executeV29.Name = "executeV29";
            this.executeV29.Size = new System.Drawing.Size(100, 40);
            this.executeV29.TabIndex = 11;
            this.executeV29.Text = "Выполнить";
            this.executeV29.UseVisualStyleBackColor = true;
            this.executeV29.Click += new System.EventHandler(this.executeV29_Click);
            // 
            // chart2
            // 
            chartArea2.AxisX.LabelStyle.Format = "0.00";
            chartArea2.AxisY.LabelStyle.Format = "0.00";
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chart2.Location = new System.Drawing.Point(3, 59);
            this.chart2.Name = "chart2";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series4.Name = "Series1";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Black;
            series5.LabelBorderWidth = 2;
            series5.Name = "coordX";
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.Black;
            series6.LabelBorderWidth = 2;
            series6.Name = "coordY";
            this.chart2.Series.Add(series4);
            this.chart2.Series.Add(series5);
            this.chart2.Series.Add(series6);
            this.chart2.Size = new System.Drawing.Size(500, 500);
            this.chart2.TabIndex = 14;
            this.chart2.Text = "chart2";
            // 
            // trackBarAv19
            // 
            this.trackBarAv19.Location = new System.Drawing.Point(326, 14);
            this.trackBarAv19.Name = "trackBarAv19";
            this.trackBarAv19.Size = new System.Drawing.Size(172, 45);
            this.trackBarAv19.TabIndex = 15;
            this.trackBarAv19.Scroll += new System.EventHandler(this.trackBarAv19_Scroll);
            // 
            // chart3
            // 
            chartArea3.AxisX.LabelStyle.Format = "0.00";
            chartArea3.AxisY.LabelStyle.Format = "0.00";
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            this.chart3.Location = new System.Drawing.Point(3, 59);
            this.chart3.Name = "chart3";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series7.Name = "Series1";
            series8.BorderWidth = 2;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Color = System.Drawing.Color.Black;
            series8.LabelBorderWidth = 2;
            series8.Name = "coordX";
            series9.BorderWidth = 2;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Color = System.Drawing.Color.Black;
            series9.LabelBorderWidth = 2;
            series9.Name = "coordY";
            this.chart3.Series.Add(series7);
            this.chart3.Series.Add(series8);
            this.chart3.Series.Add(series9);
            this.chart3.Size = new System.Drawing.Size(500, 500);
            this.chart3.TabIndex = 12;
            this.chart3.Text = "chart3";
            // 
            // trackBarBv29
            // 
            this.trackBarBv29.Location = new System.Drawing.Point(326, 14);
            this.trackBarBv29.Name = "trackBarBv29";
            this.trackBarBv29.Size = new System.Drawing.Size(172, 45);
            this.trackBarBv29.TabIndex = 16;
            this.trackBarBv29.Scroll += new System.EventHandler(this.trackBarBv29_Scroll);
            // 
            // trackBarAv29
            // 
            this.trackBarAv29.Location = new System.Drawing.Point(133, 14);
            this.trackBarAv29.Name = "trackBarAv29";
            this.trackBarAv29.Size = new System.Drawing.Size(172, 45);
            this.trackBarAv29.TabIndex = 17;
            this.trackBarAv29.Scroll += new System.EventHandler(this.trackBarAv29_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 591);
            this.Controls.Add(this.tabControl1);
            this.MaximumSize = new System.Drawing.Size(530, 630);
            this.MinimumSize = new System.Drawing.Size(530, 630);
            this.Name = "Form1";
            this.Text = "Построение кривых методом приращений";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAv9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAv19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBv29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAv29)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button executeV29;
        private System.Windows.Forms.Button executeV9;
        private System.Windows.Forms.Button executeV19;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TrackBar trackBarAv9;
        private System.Windows.Forms.TrackBar trackBarAv19;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.TrackBar trackBarAv29;
        private System.Windows.Forms.TrackBar trackBarBv29;
    }
}

