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
        int a;
        string columnName;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
        private void DeleteSelectedCorporateCustomer()
        {
            try
            {
                if (row >= 0) // Geçerli bir satır seçilmiş mi?
                {
                    // Seçili satırdan Corporate Customer ID'yi al
                    int corpId = Convert.ToInt32(dataGridView1.Rows[row].Cells["CorporateCustomerId"].Value);

                    // Kullanıcıdan silme işlemi için onay al
                    DialogResult result = MessageBox.Show(
                        "Bu kurumsal müşteriyi silmek istediğinize emin misiniz?",
                        "Silme Onayı",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Veritabanı bağlantısı ve prosedür çağrısı
                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = "CALL deleteCorporateCustomer(@corpId);";

                            using (MySqlCommand cmd = new MySqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@corpId", corpId);

                                // Sorguyu çalıştır
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Kurumsal müşteri başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // DataGridView'den satırı kaldır
                        dataGridView1.Rows.RemoveAt(row);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir satır seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteSelectedPerson()
        {
            try
            {
                if (row >= 0) // Geçerli bir satır seçilmiş mi?
                {
                    // Seçili satırdan Person ID'yi al
                    int personId = Convert.ToInt32(dataGridView1.Rows[row].Cells["Person ID"].Value);

                    // Kullanıcıdan silme işlemi için onay al
                    DialogResult result = MessageBox.Show(
                        "Bu kişiyi silmek istediğinize emin misiniz?",
                        "Silme Onayı",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Veritabanı bağlantısı ve prosedür çağrısı
                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = "CALL deletePerson(@personId);";

                            using (MySqlCommand cmd = new MySqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@personId", personId);

                                // Sorguyu çalıştır
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Kişi başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // DataGridView'i güncelle
                        dataGridView1.Rows.RemoveAt(row);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir satır seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateDatabase2(int rowIndex, int columnIndex, string newValue)
        {
            try
            {
                // Seçilen satırdan gerekli kimlik bilgisini al (PersonId)
                int personId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["Person ID"].Value);

                // Sütunun başlığına göre hangi sütunun güncelleneceğini belirleyelim
                string columnName = dataGridView1.Columns[columnIndex].HeaderText;

                // Veritabanı sorgusunda sütun adını eşleştirmek için uygun bir isimlendirme yap
                string dbColumnName = columnName switch
                {
                    "Name" => "FirstName",
                    "Surname" => "LastName",
                    "Email" => "Email",
                    "Phone" => "PhoneNumber",
                    "Corporate Customer ID" => "CorporateCustomerId",
                    "Position" => "Position",
                    "Hire Date" => "HireDate",
                    _ => throw new Exception("Bu sütun güncellenemez.")
                };

                // "Corporate Customer ID" ve "EmployeeId" sütunları güncellenemez
                if (columnName == "Employee Id" || columnName == "Corporate Customer ID")
                {
                    MessageBox.Show("Bu sütun güncellenemez.");
                    return;
                }

                // Veritabanı bağlantısı ve sorgu
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = columnName switch
                    {
                        // "Person" tablosunda güncellenmesi gereken sütunlar
                        "Name" or "Surname" or "Email" or "Phone" => $@"
                    UPDATE Person
                    SET {dbColumnName} = @newValue
                    WHERE PersonId = @personId",

                        // "CorporateEmployee" tablosunda güncellenmesi gereken sütunlar
                        "Position" or "Hire Date" => $@"
                    UPDATE CorporateEmployee
                    SET {dbColumnName} = @newValue
                    WHERE PersonId = @personId",

                        _ => throw new Exception("Geçersiz sütun.")
                    };

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
        private void UpdateDatabase1(int rowIndex, int columnIndex, string newValue)
        {
            try
            {
                // Seçilen satırdan gerekli kimlik bilgisini al (CorporateCustomerId)
                int corporateCustomerId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["CorporateCustomerId"].Value);

                // Sütunun başlığına göre hangi sütunun güncelleneceğini belirleyelim
                string columnName = dataGridView1.Columns[columnIndex].HeaderText;

                // Veritabanı sorgusunda sütun adını eşleştirmek için uygun bir isimlendirme yap
                string dbColumnName = columnName switch
                {
                    "CompanyName" => "CompanyName",
                    "TaxNumber" => "TaxNumber",
                    "Email" => "Email",
                    "PhoneNumber" => "PhoneNumber",
                    "Address" => "Address",
                    "City" => "City",
                    "Country" => "Country",
                    "CreatedDate" => "CreatedDate",
                    _ => throw new Exception("Bu sütun güncellenemez.")
                };

                // Veritabanı bağlantısı ve sorgu
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $@"
                UPDATE CorporateCustomer
                SET {dbColumnName} = @newValue
                WHERE CorporateCustomerId = @corporateCustomerId";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@newValue", newValue);
                        cmd.Parameters.AddWithValue("@corporateCustomerId", corporateCustomerId);

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
            a = 1;
            try
            {
                a = 1;
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
            a = 2;
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
            a = 3;
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
                    c.EmployeeId AS 'Employee Id',
                    c.CorporateCustomerId AS 'Corporate Customer ID',
                    c.Position,
                    c.HireDate AS 'Hire Date'
                    FROM
                      person p
                    JOIN
                      corporateemployee c ON p.personId = c.personId;";
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
                    if (a == 1)
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
                    else if (a == 2)
                    {
                        if (columnName == "CorporateCustomerId" || columnName == "TaxNumber")
                        {
                            MessageBox.Show("Bu sütun güncellenemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        string newValue = textBox1.Text;

                        dataGridView1.Rows[row].Cells[column].Value = newValue;

                        UpdateDatabase1(row, column, newValue);

                        MessageBox.Show("Değer güncellendi!");
                    }
                    else if (a == 3)
                    {
                        if (columnName == "Corporate Customer ID" || columnName == "Person ID" || columnName == "Employee Id")
                        {
                            MessageBox.Show("Bu sütun güncellenemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        string newValue = textBox1.Text;

                        dataGridView1.Rows[row].Cells[column].Value = newValue;

                        UpdateDatabase2(row, column, newValue);

                        MessageBox.Show("Değer güncellendi!");
                    }
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
                if (columnName == "Person ID" || columnName == "Individual ID" || columnName == "Corporate ID" || columnName == "CorporateCustomerId" || columnName == "TaxNumber"
                    || columnName == "Corporate Customer ID" || columnName == "Employee Id")
                {
                    MessageBox.Show("Bu sütun güncellenemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Seçili hücrenin değerini TextBox'a yükle
                textBox1.Text = dataGridView1.Rows[row].Cells[column].Value?.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (a == 1)
            {
                DeleteSelectedPerson();
            }
            else if(a == 2)
            {
                DeleteSelectedCorporateCustomer();
            }
            else if (a == 3)
            {
                DeleteSelectedPerson();
            }
            {
                
            }
        }
    }
}
