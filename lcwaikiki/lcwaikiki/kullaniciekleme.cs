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
    public partial class kullaniciekleme : Form
    {
        string connectionString = "Server=localhost;Database=hierarchy;User Id=root;Password=Bisshamon22;";
        public kullaniciekleme()
        {
            InitializeComponent();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Seçilen öğenin indeksini alın
            int selectedIndex = e.Index;

            // Tüm öğeleri dolaşarak diğerlerini işaretsiz hale getirin
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (i != selectedIndex)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
            if (e.Index == 0)
            {
                label1.Text = "İsim";
                label2.Text = "Soyisim";
                label3.Text = "Telefon Numarası";
                label4.Text = "Email";
                label5.Text = "Şifre";
                label6.Text = "Doğum Tarihi";
                label7.Text = "Şirket Bilgisi";
                label8.Text = "Oluşturma Tarihi";
                dateTimePicker1.Show();
                textBox6.Visible = false;
            }
            if (e.Index == 1)
            {
                label1.Text = "İsim";
                label2.Text = "Soyisim";
                label3.Text = "Email";
                label4.Text = "Telefon Numarası";
                label5.Text = "Şifre";
                label6.Text = "pozisyon";
                label7.Text = "Şirket Bilgisi";
                label8.Text = "İşe Giriş Tarihi";
                dateTimePicker1.Show();
                textBox6.Visible = false;

            }
            if (e.Index == 2)
            {
                label1.Text = "Şirket Adı";
                label2.Text = "Vergi Numarası";
                label3.Text = "Email";
                label4.Text = "Telefon Numarası";
                label5.Text = "Şifre";
                label6.Text = "Adres";
                label7.Text = "Şehir";
                label8.Text = "Ülke";
                dateTimePicker1.Hide();
                textBox6.Visible = true;


            }
        }

        private void kullaniciekleme_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex == 0)
            {
                string firstName = textBox1.Text;
                string lastName = textBox2.Text;
                string email = textBox4.Text;
                string phone = textBox3.Text;
                string password = textBox5.Text;
                DateTime date = dateTimePicker1.Value;
                string worksFor = textBox7.Text;
                DateTime createDate = DateTime.Now; // Alternatif: txtCreateDate.Text parse edilebilir
                bool active = checkBox1.Checked;
                try
                {
                    using(MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                       connection.Open();
                        using (MySqlCommand cmd = new MySqlCommand("addIndividual", connection))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;

                            // Prosedür parametrelerini ekle
                            cmd.Parameters.AddWithValue("firstN", firstName);
                            cmd.Parameters.AddWithValue("lastN", lastName);
                            cmd.Parameters.AddWithValue("mail", email);
                            cmd.Parameters.AddWithValue("phoneNo", phone);
                            cmd.Parameters.AddWithValue("password", password);
                            cmd.Parameters.AddWithValue("dob", date);
                            cmd.Parameters.AddWithValue("worksFor", worksFor);
                            cmd.Parameters.AddWithValue("createDate", null);
                            cmd.Parameters.AddWithValue("active", active);

                            // Prosedürü çalıştır
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Kayıt başarıyla eklendi.");
                        }
                    }
                }
                catch (Exception ex){
                    MessageBox.Show("Hata: " + ex.Message);
                }

            }
            else if (checkedListBox1.SelectedIndex == 1)
            {
                string firstName = textBox1.Text;
                string lastName = textBox2.Text;
                string email = textBox3.Text;
                string phone = textBox4.Text;
                string password = textBox5.Text;
                DateTime date = dateTimePicker1.Value;
                string position =textBox8.Text;
                string looksafter = textBox7.Text;
                DateTime createDate = DateTime.Now;
                bool active = checkBox1.Checked;
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (MySqlCommand cmd = new MySqlCommand("addEmployee", connection))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;

                            // Prosedür parametrelerini ekle
                            cmd.Parameters.AddWithValue("firstN", firstName);
                            cmd.Parameters.AddWithValue("lastN", lastName);
                            cmd.Parameters.AddWithValue("mail", email);
                            cmd.Parameters.AddWithValue("phoneNo", phone);
                            cmd.Parameters.AddWithValue("password", password);
                            cmd.Parameters.AddWithValue("pos", position);
                            cmd.Parameters.AddWithValue("hiredDate", date);
                            cmd.Parameters.AddWithValue("looksAfter", looksafter);
                            cmd.Parameters.AddWithValue("createDate", null);
                            cmd.Parameters.AddWithValue("active", active);

                            // Prosedürü çalıştır
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Kayıt başarıyla eklendi.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }

            }
            else
            {
                string coName = textBox1.Text;
                string taxnum = textBox2.Text;
                string email = textBox3.Text;
                string phone = textBox4.Text;
                string password = textBox5.Text;
                DateTime date = dateTimePicker1.Value;
                string city = textBox7.Text;
                string address= textBox8.Text;
                string country = textBox6.Text;
                DateTime createdate= DateTime.Now;
                bool active =checkBox1.Checked;
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (MySqlCommand cmd = new MySqlCommand("addCorp", connection))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;

                            // Prosedür parametrelerini ekle
                            cmd.Parameters.AddWithValue("compName", coName);
                            cmd.Parameters.AddWithValue("tax", taxnum);
                            cmd.Parameters.AddWithValue("mail", email);
                            cmd.Parameters.AddWithValue("phoneNo", phone);
                            cmd.Parameters.AddWithValue("password", password);
                            cmd.Parameters.AddWithValue("addressA", address);
                            cmd.Parameters.AddWithValue("cityA", city);
                            cmd.Parameters.AddWithValue("countryA", country);
                            cmd.Parameters.AddWithValue("createDate", null);
                            cmd.Parameters.AddWithValue("active", active);

                            // Prosedürü çalıştır
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Kayıt başarıyla eklendi.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }

            }
        }
    }
}
