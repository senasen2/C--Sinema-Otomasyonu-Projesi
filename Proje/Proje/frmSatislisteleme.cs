using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace Proje
{
    public partial class frmSatislisteleme : Form
    {
        public frmSatislisteleme()
        {
            InitializeComponent();
        }

        public void diller (string culture)
        {
            Thread.CurrentThread.CurrentUICulture.ClearCachedData();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

          
            label2.Text = Localization5.label2;
            label4.Text = Localization5.label4;
            label5.Text = Localization5.label5;
            button1.Text = Localization5.button1;
            button6.Text = Localization5.button6;
            
        }




        SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Sinema_Otomasyonu;Integrated Security=True");
        sinemaTableAdapters.SatisBilgileriTableAdapter satislistesi = new sinemaTableAdapters.SatisBilgileriTableAdapter();
        DataTable tablo = new DataTable();
        



        private void frmSatislisteleme_Load(object sender, EventArgs e)
        {
        
        }

        private void ToplamUcretHesapla()
        {
            int ucrettoplami = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                ucrettoplami += Convert.ToInt32(dataGridView1.Rows[i].Cells["ucret"].Value);
            }
            label3.Text = "Toplam Satış=" + ucrettoplami + " TL";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = satislistesi.SatışListesi2();
            ToplamUcretHesapla();
        }
        
        
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = baglanti;
                command.CommandText = "delete from SatisBilgileri where SatisId=@numara";
                command.Parameters.AddWithValue("@numara", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Satış[lar] silindi", "Uyarı");
                command.ExecuteNonQuery();
                command.Dispose();
                baglanti.Close();
                dataGridView1.DataSource = satislistesi.SatışListesi2();
            }
        }

       
        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            tablo.Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from SatisBilgileri where SalonAdi like '" + textBox2.Text + "'", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            ToplamUcretHesapla();
            baglanti.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            tablo.Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from SatisBilgileri where FilmAdi like '" + textBox3.Text + "'", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            ToplamUcretHesapla();
            baglanti.Close();
        }

        private void türkçeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            diller("");
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            diller("en-US");
            label3.Text = "Total Sales";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tablo.Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from SatisBilgileri where Ad like '" + textBox1.Text + "'", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            ToplamUcretHesapla();
            baglanti.Close();
        }
    }
}
