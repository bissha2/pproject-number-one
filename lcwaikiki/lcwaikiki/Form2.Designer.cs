namespace lcwaikiki
{
    partial class Form2
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
            menuStrip1 = new MenuStrip();
            müşteriYönetimiToolStripMenuItem = new ToolStripMenuItem();
            ürünYönetimiToolStripMenuItem = new ToolStripMenuItem();
            raporlamaToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(16, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { müşteriYönetimiToolStripMenuItem, ürünYönetimiToolStripMenuItem, raporlamaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1094, 29);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // müşteriYönetimiToolStripMenuItem
            // 
            müşteriYönetimiToolStripMenuItem.Font = new Font("Segoe UI", 12F);
            müşteriYönetimiToolStripMenuItem.Name = "müşteriYönetimiToolStripMenuItem";
            müşteriYönetimiToolStripMenuItem.Size = new Size(140, 25);
            müşteriYönetimiToolStripMenuItem.Text = "Müşteri Yönetimi";
            müşteriYönetimiToolStripMenuItem.Click += müşteriYönetimiToolStripMenuItem_Click;
            // 
            // ürünYönetimiToolStripMenuItem
            // 
            ürünYönetimiToolStripMenuItem.Font = new Font("Segoe UI", 12F);
            ürünYönetimiToolStripMenuItem.Name = "ürünYönetimiToolStripMenuItem";
            ürünYönetimiToolStripMenuItem.Size = new Size(122, 25);
            ürünYönetimiToolStripMenuItem.Text = "Ürün Yönetimi";
            ürünYönetimiToolStripMenuItem.Click += ürünYönetimiToolStripMenuItem_Click;
            // 
            // raporlamaToolStripMenuItem
            // 
            raporlamaToolStripMenuItem.Font = new Font("Segoe UI", 12F);
            raporlamaToolStripMenuItem.Name = "raporlamaToolStripMenuItem";
            raporlamaToolStripMenuItem.Size = new Size(98, 25);
            raporlamaToolStripMenuItem.Text = "Raporlama";
            raporlamaToolStripMenuItem.Click += raporlamaToolStripMenuItem_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(989, 500);
            button1.Name = "button1";
            button1.Size = new Size(93, 37);
            button1.TabIndex = 1;
            button1.Text = "Çıkış Yap";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F);
            button2.Location = new Point(757, 500);
            button2.Name = "button2";
            button2.Size = new Size(207, 37);
            button2.TabIndex = 2;
            button2.Text = "Kullanıcı Bilgilerini Düzenle";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.img_LCWaikiki;
            pictureBox1.Location = new Point(211, 179);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(636, 214);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1094, 568);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem müşteriYönetimiToolStripMenuItem;
        private ToolStripMenuItem ürünYönetimiToolStripMenuItem;
        private ToolStripMenuItem raporlamaToolStripMenuItem;
        private Button button1;
        private Button button2;
        private PictureBox pictureBox1;
    }
}