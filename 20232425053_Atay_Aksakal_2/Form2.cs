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

namespace _20232425053_Atay_Aksakal_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string conString = "Data Source=LAPTOP-3DNF55C3;Initial Catalog=Istanbul_Katli_Otopark;Integrated Security=True";

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Personel Kayıt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(conString);
            baglanti.Open();
            if (baglanti.State == System.Data.ConnectionState.Open)
            {
                string query = "insert into Calisanlar values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                SqlCommand komut = new SqlCommand(query, baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Başarıyla Kayıt Oldunuz.", "Personel Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                baglanti.Close();
            }
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
   




        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();

        }
    }
}
