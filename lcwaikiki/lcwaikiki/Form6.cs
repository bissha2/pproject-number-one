using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lcwaikiki
{
    public partial class Form6 : Form
    {
        kullaniciekleme kullanıcıform = new kullaniciekleme();
        string connectionString = "Server=localhost;Database=hierarchy;User Id=root;Password=Bisshamon22;";
        int row;
        int column;
        string columnName;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
        private void UpdateDatabase(int rowIndex, int columnIndex, string newValue)
        {
            try
            {
                // Seçilen satırdan gerekli kimlik bilgisini al (PersonId)
                int personId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["Person ID"].Value);

                // Sütunun başlığına göre hangi sütunun güncelleneceğini belirleyelim
                columnName = dataGridView1.Columns[columnIndex].HeaderText;

                // Veritabanı sorgusunda sütun adını eşleştirmek için uygun bir isimlendirme yap
                string dbColumnName = columnName switch
                {
                    "Name" => "FirstName",
                    "Surname" => "LastName",
                    "Email" => "Email",
                    "Phone" => "PhoneNumber",
                    "Corporate ID" => "CorporateCustomerId",
                    "Date of Birth" => "DateOfBirth",
                    _ => throw new Exception("Bu sütun güncellenemez.")
                };

                // Veritabanı bağlantısı ve sorgu
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $@"
                UPDATE IndividualCustomer i
                JOIN Person p ON p.PersonId = i.PersonId
                SET {dbColumnName} = @newValue
                WHERE p.PersonId = @personId";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@newValue", newValue);
                        cmd.Parameters.AddWithValue("@personId", personId);

                        // Sorguyu çalıştır
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Veritabanı güncellendi.");
                        else
                            MessageBox.Show("Veritabanında hiçbir satır güncellenmedi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı güncelleme hatası: " + ex.Message);
            }
        }
        private void incustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Veriyi çekmek için bağlantı ve komut
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT DISTINCT
                    p.FirstName AS 'Name',
                    p.LastName AS 'Surname',
                    p.email AS 'Email',
                    p.PhoneNumber AS 'Phone',
                    p.PersonId AS 'Person ID',
                    i.IndividualCustomerId AS 'Individual ID',
                    i.CorporateCustomerId AS 'Corporate ID',
                    i.DateOfBirth AS 'Date of Birth'
                FROM 
                    Person p
                JOIN 
                    Individualcustomer i ON p.PersonId = i.PersonId;
            ";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable); // Veriyi DataTable'a doldur

                            // DataGridView'a veriyi bağla
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void cocustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Veriyi çekmek için bağlantı ve komut
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT CorporateCustomerId, CompanyName, TaxNumber, Email, PhoneNumber, 
                               Address, City, Country, CreatedDate
                        FROM corporatecustomer;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable); // Veriyi DataTable'a doldur

                            // DataGridView'a veriyi bağla
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void coempToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(menuStrip2.)
            try
            {
                // Veriyi çekmek için bağlantı ve komut
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT DISTINCT
                    p.FirstName AS 'Name',
                    p.LastName AS 'Surname',
                    p.email AS 'Email',
                    p.PhoneNumber AS 'Phone',
                    p.PersonId AS 'Person ID',
                    c.EmployeeId AS 'EmployeeId',
                    c.CorporateCustomerId AS 'Corporate Customer ID',
                    c.Position,
                    c.HireDate AS 'Hire Date'
                    FROM
                      person p
                    JOIN
                      corporateemployee c ON p.personId = c.personId;               
";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable); // Veriyi DataTable'a doldur

                            // DataGridView'a veriyi bağla
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kullanıcıform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (row >= 0 && column >= 0) // Geçerli bir hücre seçilmiş mi?
                {
                    if (columnName == "Person ID" || columnName == "Individual ID" || columnName == "Corporate ID")
                    {
                        MessageBox.Show("Bu sütun güncellenemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // TextBox'tan yeni değeri al
                    string newValue = textBox1.Text;

                    // Seçilen hücreyi güncelle
                    dataGridView1.Rows[row].Cells[column].Value = newValue;

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Geçerli bir hücre seçilmiş mi?
            {
                // Satır ve sütun indekslerini kaydet
                row = e.RowIndex;
                column = e.ColumnIndex;
                columnName = dataGridView1.Columns[column].HeaderText;
                if (columnName == "Person ID" || columnName == "Individual ID" || columnName == "Corporate ID")
                {
                    MessageBox.Show("Bu sütun güncellenemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Seçili hücrenin değerini TextBox'a yükle
                textBox1.Text = dataGridView1.Rows[row].Cells[column].Value?.ToString();
            }
        }
    }
}
