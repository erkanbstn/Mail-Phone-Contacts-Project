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
namespace Mail_ve_Telefon_Rehber_Kayıt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void listele()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Kişiler",bgl);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-PKO8JLN\\SQLEXPRESS;Initial Catalog=DBRehber;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand k = new SqlCommand("insert into Kişiler (ID,Ad,Soyad,Telefon,Mail) values (@p5,@p1,@p2,@p3,@p4)",bgl);
            k.Parameters.AddWithValue("@p5", textBox3.Text);
            k.Parameters.AddWithValue("@p1",textBox1.Text);
            k.Parameters.AddWithValue("@p2",textBox2.Text);
            k.Parameters.AddWithValue("@p3",maskedTextBox1.Text);
            k.Parameters.AddWithValue("@p4",textBox4.Text);         
            k.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Yeni Kişi Eklendi","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand k = new SqlCommand("update Kişiler set Ad=@p1,Soyad=@p2,Telefon=@p3,Mail=@p4 where ID=@p5", bgl);
            k.Parameters.AddWithValue("@p1", textBox1.Text);
            k.Parameters.AddWithValue("@p2", textBox2.Text);
            k.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
            k.Parameters.AddWithValue("@p4", textBox4.Text);
            k.Parameters.AddWithValue("@p5", textBox3.Text);
            k.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Varolan Kişi Güncellendi", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand k = new SqlCommand("delete from Kişiler where ID=@p1",bgl);
            k.Parameters.AddWithValue("@p1",textBox3.Text);
            k.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Kişi Başarıyla Silindi", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();         
            maskedTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
}
