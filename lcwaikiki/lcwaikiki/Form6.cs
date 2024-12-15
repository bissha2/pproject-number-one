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
        string connectionString = "Server=localhost;Database=hierarchy;User Id=root;Password=Bisshamon22;";
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

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
    }
}
