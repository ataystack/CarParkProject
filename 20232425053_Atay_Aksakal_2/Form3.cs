using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;



namespace _20232425053_Atay_Aksakal_2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public string conString = "Data Source=LAPTOP-3DNF55C3;Initial Catalog=Istanbul_Katli_Otopark;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            string Email = textBox1.Text;
            string Sifre = textBox2.Text;


            using (SqlConnection baglanti = new SqlConnection(conString))
            {
                try
                {
                    baglanti.Open();
                    string query = "SELECT COUNT(1) FROM Calisanlar WHERE Email=@Email AND Sifre=@Sifre";
                    using (SqlCommand command = new SqlCommand(query, baglanti))
                    {
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@Sifre", Sifre);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        if (count == 1)
                        {
                            
                            MessageBox.Show("Giriş başarılı!","Personel Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                             Form4 form1 = new Form4();
                            form1.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre hatalı.","Personel Girişi Başarısız.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                          
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = "Personel Girişi";

        }
    }

}
