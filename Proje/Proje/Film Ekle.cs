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
    public partial class Film_Ekle : Form
    {
        public Film_Ekle()
        {
            InitializeComponent();
        }

        public void diller (string culture)
        {
            Thread.CurrentThread.CurrentUICulture.ClearCachedData();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            label1.Text = Localization4.label1;
            label2.Text = Localization4.label2;
            label3.Text = Localization4.label3;
            label4.Text = Localization4.label4;
            label5.Text = Localization4.label5;
            label6.Text = Localization4.label6;
            label7.Text = Localization4.label7;
            button1.Text = Localization4.button1;
            button2.Text = Localization4.button2;
            button4.Text = Localization4.button4;
            button5.Text = Localization4.button5;

        }




        sinemaTableAdapters.FilmBilgileriTableAdapter film = new sinemaTableAdapters.FilmBilgileriTableAdapter();
        

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                film.FilmEkleme(textBox1.Text, textBox2.Text, comboBox1.Text, textBox4.Text, dateTimePicker1.Text, textBox5.Text, pictureBox1.ImageLocation, txtfilmhakkinda.Text);
                MessageBox.Show("Film eklendi.", "Kayıt");
                dataGridView1.DataSource = film.FilmListesi2();
            }
            catch (Exception)
            {
                MessageBox.Show("Tüm bilgileri giriniz.", "Uyarı");
            }
            
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            comboBox1.Text = "";
            pictureBox1.Image = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Film_Ekle_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = film.FilmListesi2();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            film.FilmSilme(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            dataGridView1.DataSource = film.FilmListesi2();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtfilmhakkinda.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Sinema_Otomasyonu;Integrated Security=True");
        private void button4_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = baglanti;
                command.CommandText = "update FilmBilgileri set FilmAdi='" + textBox1.Text + "',Yonetmen='" + textBox2.Text + "',FilmTuru='" + comboBox1.Text + "',FilmSuresi='" + textBox4.Text + "',YapimYili='" + textBox5.Text + "',Resim='" + pictureBox1.ImageLocation + "',FilmHakkinda='" + txtfilmhakkinda.Text + "' where FilmId=@numara";
                command.Parameters.AddWithValue("@numara", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                command.ExecuteNonQuery();
                command.Dispose();
                baglanti.Close();
                dataGridView1.DataSource = film.FilmListesi2();
            }
        }

        private void türkçeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            diller("");
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            diller("en-US");
        }

        
    }
}
