using System;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace lcwaikiki
{

    public partial class Siparis : Form
    {
        private string connectionString = "Server=localhost;Database=hierarchy;User Id=root;Password=Bisshamon22;";

        private string email, ürün, fiyat, miktar;

        public Siparis()
        {
            InitializeComponent();
        }

        public void Siparis_Load(object sender, EventArgs e)
        {
            LoadProducts(1);
        }

        private void LoadProducts(int individualCustomerId)
        {
            string query = @"
            SELECT p.ProductId, p.ProductName, p.Description, p.Price
            FROM seasons.product p
            WHERE p.AddedBy IN (
            SELECT cc.CorporateCustomerId 
            FROM hierarchy.corporatecustomer cc
            WHERE cc.CorporateCustomerId IN (
            SELECT ic.CorporateCustomerId
            FROM hierarchy.individualcustomer ic
            WHERE ic.IndividualCustomerId = ?
                )
            );
        ";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("?", individualCustomerId);

                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        DataTable productsTable = new DataTable();
                        adapter.Fill(productsTable);

                        // DataGridView'e veri ata
                        dgwStock.DataSource = productsTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void dgwStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgwStock.Rows[e.RowIndex];

                tbproduct.Text = selectedRow.Cells["ProductName"].Value.ToString();
            }

            ürün = tbproduct.Text;

        }

        private void tbMiktar_TextChanged(object sender, EventArgs e)
        {
            if (dgwStock.CurrentRow != null &&
                int.TryParse(tbMiktar.Text, out int miktarDegeri) && miktarDegeri >= 0)
            {
                DataGridViewRow selectedRow = dgwStock.CurrentRow;

                if (decimal.TryParse(selectedRow.Cells["Price"].Value.ToString(), out decimal fiyat))
                {
                    decimal toplamFiyat = miktarDegeri * fiyat;

                    tbFiyat.Text = toplamFiyat.ToString("F2"); // 2 ondalık basamak
                }

                miktar = miktarDegeri.ToString();

            }
            else
            {
                tbFiyat.Text = "0.00";
            }

            fiyat = tbFiyat.Text;

        }

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            email = ("Ürün Adı: " + ürün + "\n" + "Miktar: " + miktar + "\n" + "Öngörülen Fiyat: " + fiyat + "\n").ToString();
            try
            {
                // SMTP istemcisi ve sunucu bilgileri
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new NetworkCredential("serhat4aydin@gmail.com", "lqbo dwoe bicr emwb");
                smtpClient.EnableSsl = true;

                // Gönderilecek e-posta mesajı
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("serhat4aydin@gmail.com");
                mailMessage.To.Add("mehmet16mkp@hotmail.com");
                mailMessage.Subject = "Sipariş Talebi";
                mailMessage.Body = email;
                mailMessage.IsBodyHtml = false;

                // E-posta gönderimi
                smtpClient.Send(mailMessage);

                MessageBox.Show("Sipariş iletildi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sipariş iletilirken bir hata oluştu" + ex.Message);
            }
        }
    }

}

