namespace lcwaikiki
{
    partial class Siparis
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
            dgwStock = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbproduct = new TextBox();
            tbMiktar = new TextBox();
            tbFiyat = new TextBox();
            btnSiparis = new Button();
            ((System.ComponentModel.ISupportInitialize)dgwStock).BeginInit();
            SuspendLayout();
            // 
            // dgwStock
            // 
            dgwStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwStock.Location = new Point(8, 26);
            dgwStock.Name = "dgwStock";
            dgwStock.Size = new Size(474, 331);
            dgwStock.TabIndex = 0;
            dgwStock.CellClick += dgwStock_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(545, 26);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 1;
            label1.Text = "Ürün";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(545, 103);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 2;
            label2.Text = "Miktar";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(545, 191);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 3;
            label3.Text = "Öngörüle Fiyat";
            // 
            // tbproduct
            // 
            tbproduct.Location = new Point(556, 62);
            tbproduct.Name = "tbproduct";
            tbproduct.Size = new Size(100, 23);
            tbproduct.TabIndex = 4;
            // 
            // tbMiktar
            // 
            tbMiktar.Location = new Point(547, 142);
            tbMiktar.Name = "tbMiktar";
            tbMiktar.Size = new Size(100, 23);
            tbMiktar.TabIndex = 5;
            tbMiktar.TextChanged += tbMiktar_TextChanged;
            // 
            // tbFiyat
            // 
            tbFiyat.Location = new Point(555, 226);
            tbFiyat.Name = "tbFiyat";
            tbFiyat.Size = new Size(100, 23);
            tbFiyat.TabIndex = 6;
            // 
            // btnSiparis
            // 
            btnSiparis.Location = new Point(580, 311);
            btnSiparis.Name = "btnSiparis";
            btnSiparis.Size = new Size(75, 23);
            btnSiparis.TabIndex = 7;
            btnSiparis.Text = "button1";
            btnSiparis.UseVisualStyleBackColor = true;
            btnSiparis.Click += btnSiparis_Click;
            // 
            // Siparis
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 543);
            Controls.Add(btnSiparis);
            Controls.Add(tbFiyat);
            Controls.Add(tbMiktar);
            Controls.Add(tbproduct);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgwStock);
            Name = "Siparis";
            Text = "Siparis";
            Load += Siparis_Load;
            ((System.ComponentModel.ISupportInitialize)dgwStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgwStock;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbproduct;
        private TextBox tbMiktar;
        private TextBox tbFiyat;
        private Button btnSiparis;
    }
}