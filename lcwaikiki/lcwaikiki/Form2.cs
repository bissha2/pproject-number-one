using Google.Apis.Auth.OAuth2;
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
    public partial class Form2 : Form
    {
        public static Form2 Instance;
        Form3 form3 = new Form3();
        Form4 form4 = new Form4();
        Form5 form5 = new Form5();
        Siparis siparis = new Siparis();
        public Form2()
        {
            InitializeComponent();
            Instance = this;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=hierarchy;User Id=root;Password=Bisshamon22;";
            if (Form1.a == false)
            {
                button2.Hide();


            }
        }

        private void müşteriYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            form3.Show();

        }

        private void ürünYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            form4.Show();
        }

        private void raporlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            form5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Eğer geçerli bir token varsa, kullanıcıyı oturumdan çıkar (çıkış yap)
                var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets
                    {
                        ClientId = "YOUR_CLIENT_ID",       // Google'dan aldığın Client ID
                        ClientSecret = "YOUR_CLIENT_SECRET" // Google'dan aldığın Client Secret
                    },
                    new[] { "https://www.googleapis.com/auth/userinfo.profile" },
                    "user",
                    CancellationToken.None
                );

                // Token'ı silerek oturumdan çıkış yap
                await credential.RevokeTokenAsync(CancellationToken.None);

                MessageBox.Show("Oturumdan çıkış yapıldı. Lütfen yeniden giriş yapın.", "Çıkış", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Çıkış sırasında bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.Exit();
        }

        private void siparişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            siparis.Show();

        }
    }
}
