
namespace lab3
{
    partial class FormPolygon
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.clearGraph = new System.Windows.Forms.Button();
            this.pbGraph = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.findPath = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textPathEnd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textPathStart = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addVertex = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textVertexY = new System.Windows.Forms.TextBox();
            this.textVertexX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textIdVertex = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.addEdge = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textEdgeWeight = new System.Windows.Forms.TextBox();
            this.textEdgeEnd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textEdgeStart = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pbSecond = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pbFirst = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGraph)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecond)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.clearGraph);
            this.tabPage3.Controls.Add(this.pbGraph);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.btnStart);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(646, 502);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Text = "Дополнительное";
            // 
            // clearGraph
            // 
            this.clearGraph.Location = new System.Drawing.Point(536, 471);
            this.clearGraph.Name = "clearGraph";
            this.clearGraph.Size = new System.Drawing.Size(100, 23);
            this.clearGraph.TabIndex = 14;
            this.clearGraph.Text = "Очистить";
            this.clearGraph.UseVisualStyleBackColor = true;
            this.clearGraph.Click += new System.EventHandler(this.clearGraph_Click);
            // 
            // pbGraph
            // 
            this.pbGraph.Location = new System.Drawing.Point(0, 0);
            this.pbGraph.Margin = new System.Windows.Forms.Padding(5);
            this.pbGraph.Name = "pbGraph";
            this.pbGraph.Size = new System.Drawing.Size(440, 500);
            this.pbGraph.TabIndex = 13;
            this.pbGraph.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.findPath);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.textPathEnd);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textPathStart);
            this.groupBox3.Location = new System.Drawing.Point(448, 287);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(195, 108);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Минимальный путь";
            // 
            // findPath
            // 
            this.findPath.Location = new System.Drawing.Point(88, 77);
            this.findPath.Name = "findPath";
            this.findPath.Size = new System.Drawing.Size(100, 23);
            this.findPath.TabIndex = 10;
            this.findPath.Text = "Поиск";
            this.findPath.UseVisualStyleBackColor = true;
            this.findPath.Click += new System.EventHandler(this.findPath_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Вершина 2";
            // 
            // textPathEnd
            // 
            this.textPathEnd.Location = new System.Drawing.Point(88, 49);
            this.textPathEnd.MaxLength = 3;
            this.textPathEnd.Name = "textPathEnd";
            this.textPathEnd.Size = new System.Drawing.Size(100, 22);
            this.textPathEnd.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "Вершина 1";
            // 
            // textPathStart
            // 
            this.textPathStart.Location = new System.Drawing.Point(88, 21);
            this.textPathStart.MaxLength = 3;
            this.textPathStart.Name = "textPathStart";
            this.textPathStart.Size = new System.Drawing.Size(100, 22);
            this.textPathStart.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addVertex);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textVertexY);
            this.groupBox1.Controls.Add(this.textVertexX);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textIdVertex);
            this.groupBox1.Location = new System.Drawing.Point(448, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 136);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление вершины";
            // 
            // addVertex
            // 
            this.addVertex.Location = new System.Drawing.Point(88, 105);
            this.addVertex.Name = "addVertex";
            this.addVertex.Size = new System.Drawing.Size(100, 23);
            this.addVertex.TabIndex = 10;
            this.addVertex.Text = "Добавить";
            this.addVertex.UseVisualStyleBackColor = true;
            this.addVertex.Click += new System.EventHandler(this.addVertex_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Точка У";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Точка Х";
            // 
            // textVertexY
            // 
            this.textVertexY.Location = new System.Drawing.Point(88, 77);
            this.textVertexY.MaxLength = 3;
            this.textVertexY.Name = "textVertexY";
            this.textVertexY.Size = new System.Drawing.Size(100, 22);
            this.textVertexY.TabIndex = 10;
            // 
            // textVertexX
            // 
            this.textVertexX.Location = new System.Drawing.Point(88, 49);
            this.textVertexX.MaxLength = 3;
            this.textVertexX.Name = "textVertexX";
            this.textVertexX.Size = new System.Drawing.Size(100, 22);
            this.textVertexX.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Вершина";
            // 
            // textIdVertex
            // 
            this.textIdVertex.Location = new System.Drawing.Point(88, 21);
            this.textIdVertex.Name = "textIdVertex";
            this.textIdVertex.ReadOnly = true;
            this.textIdVertex.Size = new System.Drawing.Size(100, 22);
            this.textIdVertex.TabIndex = 0;
            this.textIdVertex.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.addEdge);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textEdgeWeight);
            this.groupBox2.Controls.Add(this.textEdgeEnd);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textEdgeStart);
            this.groupBox2.Location = new System.Drawing.Point(448, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 136);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Добавление ребра";
            // 
            // addEdge
            // 
            this.addEdge.Location = new System.Drawing.Point(88, 105);
            this.addEdge.Name = "addEdge";
            this.addEdge.Size = new System.Drawing.Size(100, 23);
            this.addEdge.TabIndex = 10;
            this.addEdge.Text = "Добавить";
            this.addEdge.UseVisualStyleBackColor = true;
            this.addEdge.Click += new System.EventHandler(this.addEdge_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Вес";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Вершина 2";
            // 
            // textEdgeWeight
            // 
            this.textEdgeWeight.Location = new System.Drawing.Point(88, 77);
            this.textEdgeWeight.MaxLength = 3;
            this.textEdgeWeight.Name = "textEdgeWeight";
            this.textEdgeWeight.Size = new System.Drawing.Size(100, 22);
            this.textEdgeWeight.TabIndex = 10;
            // 
            // textEdgeEnd
            // 
            this.textEdgeEnd.Location = new System.Drawing.Point(88, 49);
            this.textEdgeEnd.MaxLength = 3;
            this.textEdgeEnd.Name = "textEdgeEnd";
            this.textEdgeEnd.Size = new System.Drawing.Size(100, 22);
            this.textEdgeEnd.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Вершина 1";
            // 
            // textEdgeStart
            // 
            this.textEdgeStart.Location = new System.Drawing.Point(88, 21);
            this.textEdgeStart.MaxLength = 3;
            this.textEdgeStart.Name = "textEdgeStart";
            this.textEdgeStart.Size = new System.Drawing.Size(100, 22);
            this.textEdgeStart.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(717, 15);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(133, 31);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Запуск";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.pbSecond);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage2.Size = new System.Drawing.Size(646, 502);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Второй";
            // 
            // pbSecond
            // 
            this.pbSecond.Location = new System.Drawing.Point(0, 0);
            this.pbSecond.Margin = new System.Windows.Forms.Padding(5);
            this.pbSecond.Name = "pbSecond";
            this.pbSecond.Size = new System.Drawing.Size(646, 502);
            this.pbSecond.TabIndex = 5;
            this.pbSecond.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.pbFirst);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage1.Size = new System.Drawing.Size(646, 502);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Первый";
            // 
            // pbFirst
            // 
            this.pbFirst.Location = new System.Drawing.Point(0, 0);
            this.pbFirst.Margin = new System.Windows.Forms.Padding(5);
            this.pbFirst.Name = "pbFirst";
            this.pbFirst.Size = new System.Drawing.Size(646, 502);
            this.pbFirst.TabIndex = 5;
            this.pbFirst.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(654, 531);
            this.tabControl1.TabIndex = 4;
            // 
            // FormPolygon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 531);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(670, 570);
            this.MinimumSize = new System.Drawing.Size(670, 570);
            this.Name = "FormPolygon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Построение многоугольников";
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbGraph)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSecond)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFirst)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pbSecond;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pbFirst;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button clearGraph;
        private System.Windows.Forms.PictureBox pbGraph;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button findPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textPathEnd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textPathStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addVertex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textVertexY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textIdVertex;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button addEdge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textEdgeWeight;
        private System.Windows.Forms.TextBox textEdgeEnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textEdgeStart;
        private System.Windows.Forms.TextBox textVertexX;
    }
}

