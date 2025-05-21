using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _20232425053_Atay_Aksakal_2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public string conString = "Data Source=LAPTOP-3DNF55C3;Initial Catalog=Istanbul_Katli_Otopark;Integrated Security=True";

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadData();
            this.Text = "Araç Kayıt Sistemi";

        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Musteriler";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO Musteriler (Isim, Soyisim, Plaka, Kat) VALUES (@Isim, @Soyisim, @Plaka, @Kat)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Isim", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Soyisim", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Plaka", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Kat", textBox4.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Veri başarıyla eklendi.","Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Veri eklenirken bir hata oluştu.", "Veri eklenemedi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Musteriler SET Isim = @Isim, Soyisim = @Soyisim, Plaka = @Plaka, Kat = @Kat WHERE MusteriID = @MusteriID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Isim", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Soyisim", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Plaka", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Kat", textBox4.Text);
                    cmd.Parameters.AddWithValue("@MusteriID", textBox5.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Kayıt güncellendi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt güncellenirken bir hata oluştu.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Musteriler WHERE MusteriID = @MusteriID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MusteriID", textBox5.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Kayıt silindi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt silinirken bir hata oluştu.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["Isim"].Value.ToString();
                textBox2.Text = row.Cells["Soyisim"].Value.ToString();
                textBox3.Text = row.Cells["Plaka"].Value.ToString();
                textBox4.Text = row.Cells["Kat"].Value.ToString();
                textBox5.Text = row.Cells["MusteriID"].Value.ToString();
            }
        }

        private void button4_Click_1(object sender, EventArgs e) 
        {
            LoadData();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
               
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                
                if (selectedRow.Cells.Count >= 4)
                {
                    textBox1.Text = selectedRow.Cells[1].Value.ToString();
                    textBox2.Text = selectedRow.Cells[2].Value.ToString();
                    textBox3.Text = selectedRow.Cells[3].Value.ToString();
                    textBox4.Text = selectedRow.Cells[4].Value.ToString();
                    textBox5.Text = selectedRow.Cells[0].Value.ToString();
                }
            }
        }

    }
}
