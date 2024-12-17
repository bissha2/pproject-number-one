using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lcwaikiki
{
    public partial class Form4 : Form
    {

        int row, column;
        string columnName;

        private string connectionString = "Server=localhost;Database=seasons;User Id=root;Password=Bisshamon22;";

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2.Instance.Show();
            this.Hide();
        }

        public void Form4_Load(object sender, EventArgs e)
        {
            LoadProducts(1);
        }

        private void LoadProducts(int corporateCustomerId)
        {
            string query = @"
            SELECT p.ProductId, p.ProductName, p.Description, p.Price, p.IsActive, p.Stock
            FROM seasons.product p
            WHERE EXISTS (
            SELECT 1 
            FROM hierarchy.corporatecustomer cc
            WHERE cc.CorporateCustomerId = p.AddedBy
            AND cc.CorporateCustomerId = ?
                );
            ";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("?", corporateCustomerId);

                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        DataTable productsTable = new DataTable();
                        adapter.Fill(productsTable);

                        dgvProducts.DataSource = productsTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void UpdateDatabase(int rowIndex, int columnIndex, string newValue)
        {
            try
            {
                // Seçilen satırdan gerekli kimlik bilgisini al (PersonId)
                int personId = Convert.ToInt32(dgvProducts.Rows[rowIndex].Cells["ProductId"].Value);

                // Sütunun başlığına göre hangi sütunun güncelleneceğini belirleyelim
                columnName = dgvProducts.Columns[columnIndex].HeaderText;

                // Veritabanı sorgusunda sütun adını eşleştirmek için uygun bir isimlendirme yap
                string dbColumnName = columnName switch
                {
                    "ProductId" => "ProductId",
                    "ProductName" => "ProductName",
                    "Description" => "Description",
                    "Price" => "Price",
                    _ => throw new Exception("Bu sütun güncellenemez.")
                };

                // Veritabanı bağlantısı ve sorgu
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $@"
                    UPDATE product p
                    SET {dbColumnName} = @newValue
                    WHERE p.productId = @personId";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@newValue", newValue);
                        cmd.Parameters.AddWithValue("@personId", personId);

                        // Sorguyu çalıştır
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Veritabanı güncellendi.");
                        else
                            MessageBox.Show("Veritabanı güncellenmedi");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı güncelleme hatası: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (row >= 0 && column >= 0) // Geçerli bir hücre seçilmiş mi?
                {
                    if (columnName == "ProductId")
                    {
                        MessageBox.Show("Bu sütun güncellenemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // TextBox'tan yeni değeri al
                    string newValue = tbData.Text;

                    // Seçilen hücreyi güncelle
                    dgvProducts.Rows[row].Cells[column].Value = newValue;

                    // Eğer bu veri veritabanıyla ilişkili bir sütunsa, veritabanını güncelle
                    UpdateDatabase(row, column, newValue);

                    MessageBox.Show("Değer güncellendi!");
                }
                else
                {
                    MessageBox.Show("Lütfen bir hücre seçin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Geçerli bir hücre seçilmiş mi?
            {
                // Satır ve sütun indekslerini kaydet
                row = e.RowIndex;
                column = e.ColumnIndex;
                columnName = dgvProducts.Columns[column].HeaderText;
                if (columnName == "ProductID")
                {
                    MessageBox.Show("Bu sütun güncellenemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Seçili hücrenin değerini TextBox'a yükle
                tbData.Text = dgvProducts.Rows[row].Cells[column].Value?.ToString();
            }
        }
    }
}
