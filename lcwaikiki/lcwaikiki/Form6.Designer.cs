namespace lcwaikiki
{
    partial class Form6
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
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            menuStrip2 = new MenuStrip();
            incustomerToolStripMenuItem = new ToolStripMenuItem();
            cocustomerToolStripMenuItem = new ToolStripMenuItem();
            coempToolStripMenuItem = new ToolStripMenuItem();
            button2 = new Button();
            button1 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(767, 548);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(819, 139);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(321, 23);
            textBox1.TabIndex = 2;
            // 
            // menuStrip2
            // 
            menuStrip2.Items.AddRange(new ToolStripItem[] { incustomerToolStripMenuItem, cocustomerToolStripMenuItem, coempToolStripMenuItem });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(1168, 24);
            menuStrip2.TabIndex = 4;
            menuStrip2.Text = "menuStrip2";
            // 
            // incustomerToolStripMenuItem
            // 
            incustomerToolStripMenuItem.Name = "incustomerToolStripMenuItem";
            incustomerToolStripMenuItem.Size = new Size(79, 20);
            incustomerToolStripMenuItem.Text = "incustomer";
            incustomerToolStripMenuItem.Click += incustomerToolStripMenuItem_Click;
            // 
            // cocustomerToolStripMenuItem
            // 
            cocustomerToolStripMenuItem.Name = "cocustomerToolStripMenuItem";
            cocustomerToolStripMenuItem.Size = new Size(82, 20);
            cocustomerToolStripMenuItem.Text = "cocustomer";
            cocustomerToolStripMenuItem.Click += cocustomerToolStripMenuItem_Click;
            // 
            // coempToolStripMenuItem
            // 
            coempToolStripMenuItem.Name = "coempToolStripMenuItem";
            coempToolStripMenuItem.Size = new Size(56, 20);
            coempToolStripMenuItem.Text = "coemp";
            coempToolStripMenuItem.Click += coempToolStripMenuItem_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1065, 198);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "update";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(819, 459);
            button1.Name = "button1";
            button1.Size = new Size(321, 23);
            button1.TabIndex = 6;
            button1.Text = "yeni kulllanıcı kaydı";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(819, 414);
            button3.Name = "button3";
            button3.Size = new Size(321, 23);
            button3.TabIndex = 7;
            button3.Text = "kullanıcıyı sil";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1168, 587);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip2);
            MainMenuStrip = menuStrip2;
            Name = "Form6";
            Text = "Form6";
            Load += Form6_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private TextBox textBox1;
        private ToolStripMenuItem toolStripMenuItem2;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem incustomerToolStripMenuItem;
        private ToolStripMenuItem cocustomerToolStripMenuItem;
        private ToolStripMenuItem coempToolStripMenuItem;
        private Button button2;
        private Button button1;
        private Button button3;
    }
}