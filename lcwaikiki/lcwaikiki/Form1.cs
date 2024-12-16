namespace lcwaikiki
{
    using MySql.Data.MySqlClient;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Oauth2.v2;
    using Google.Apis.Oauth2.v2.Data;
    using Google.Apis.Auth.OAuth2.Responses;
    using Google.Apis.Auth.OAuth2.Flows;
    using System.Net.Http;
    using Newtonsoft.Json.Linq;
    using System.Data;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
    using MySqlX.XDevAPI.Relational;
    using Google.Apis.Services;

    public partial class Form1 : Form
    {
        public static bool a;
        string email2;
        string password;
        Form2 form2 = new Form2();
        string connectionString = "Server=localhost;Database=hierarchy;User Id=root;Password=Bisshamon22;";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }



        public int GetPersonIdByEmail(string email)
        {
            int personId = 0; // Varsayýlan olarak 0 dönecek (bulunamazsa)

            // SQL sorgusu: Email'e göre PersonId çek
            string query = "SELECT PersonId FROM Person WHERE Email = @Email LIMIT 1";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); // Veritabaný baðlantýsýný aç
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Parametre ekleme
                        cmd.Parameters.AddWithValue("@Email", email);

                        // SQL sorgusunu çalýþtýr ve sonucu al
                        object result = cmd.ExecuteScalar();

                        // Eðer sonuç null deðilse PersonId'yi al
                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            personId = id;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message); // Hata mesajýný yazdýr
                }
            }

            return personId; // Bulunan PersonId veya 0
        }
        public bool IsUserManager(string email)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL sorgusu
                    string query = @"
                    SELECT COUNT(*) 
                    FROM hierarchy.person p
                    JOIN hierarchy.corporateemployee ce ON p.PersonId = ce.PersonId
                    WHERE p.Email = @Email AND ce.Position = 'manager';";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        // Sorgu sonucu
                        var result = cmd.ExecuteScalar();

                        // Eðer 1 dönerse, kullanýcý manager
                        if (result != null && Convert.ToInt32(result) > 0)
                        {
                            a = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                Console.WriteLine("Hata: " + ex.Message);
            }

            return a;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string inputPassword = textBox2.Text;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // 1. Bireysel kullanýcý doðrulamasý
                    string queryPerson = "SELECT checkPassword(@Email, @InputPassword) AS IsValid;";
                    MySqlCommand cmdPerson = new MySqlCommand(queryPerson, connection);
                    cmdPerson.Parameters.AddWithValue("@Email", email);
                    cmdPerson.Parameters.AddWithValue("@InputPassword", inputPassword);
                    var personResult = cmdPerson.ExecuteScalar();

                    if (personResult != null && Convert.ToBoolean(personResult))
                    {
                        IsUserManager(email);
                        this.Hide();
                        form2.Show();
                        return;
                    }

                    // 2. Þirket kullanýcýsý doðrulamasý
                    string queryCorp = "SELECT checkCorpPassword(@Email, @InputPassword) AS IsValid;";
                    MySqlCommand cmdCorp = new MySqlCommand(queryCorp, connection);
                    cmdCorp.Parameters.AddWithValue("@Email", email);
                    cmdCorp.Parameters.AddWithValue("@InputPassword", inputPassword);
                    var corpResult = cmdCorp.ExecuteScalar();

                    if (corpResult != null && Convert.ToBoolean(corpResult))
                    {
                        a = false;
                        this.Hide();
                        form2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Þifre yanlýþ veya kullanýcý bulunamadý.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // OAuth 2.0 istemci ayarlarý
                string[] scopes = { "https://www.googleapis.com/auth/userinfo.profile", "https://www.googleapis.com/auth/userinfo.email" };

                UserCredential credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets
                    {
                        ClientId = "1060539556489-r5avvucc0s5nb61sffmflnsei2l39bdk.apps.googleusercontent.com",       // Google'dan aldýðýn Client ID
                        ClientSecret = "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" // Google'dan aldýðýn Client Secret
                    },
                    scopes,
                    "user",
                    CancellationToken.None
                );

                // OAuth2 servisini baþlat
                var service = new Oauth2Service(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Google Login Example"
                });

                // Kullanýcý bilgilerini çek
                Userinfo userInfo = await service.Userinfo.Get().ExecuteAsync();

                if (GetPersonIdByEmail(userInfo.Email) > 0)
                {
                    MessageBox.Show("Giriþ Baþarýlý");
                    this.Hide();
                    form2.Show();
                }

                else
                {
                    MessageBox.Show("Hesap bulunamadý");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriþ sýrasýnda bir hata oluþtu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

