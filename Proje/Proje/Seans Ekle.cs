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
    public partial class Seans_Ekle : Form
    {
        public Seans_Ekle()
        {
            InitializeComponent();
        }

        public void diller (string culture)
        {
            Thread.CurrentThread.CurrentUICulture.ClearCachedData();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            label1.Text = Localization6.label1;
            label2.Text = Localization6.label2;
            label3.Text = Localization6.label3;
            label4.Text = Localization6.label4;
            button4.Text = Localization6.button4;
            button1.Text = Localization6.button1;
            button2.Text = Localization6.button2;
        }

        
        sinemaTableAdapters.SeansBilgileriTableAdapter filmseansı = new sinemaTableAdapters.SeansBilgileriTableAdapter();

        SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Sinema_Otomasyonu;Integrated Security=True");

        private void FilmveSalonGoster(ComboBox combo,string sql,string sql2)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read()==true)
            {
                combo.Items.Add(read[sql2].ToString());
            }
            baglanti.Close();
        }
        
        string seans = "";
        private void RadioButtonSeçiliyse()
        {
            if (radioButton1.Checked ==true)seans = radioButton1.Text;
         else  if (radioButton1.Checked == true) seans = radioButton1.Text;
            else if (radioButton2.Checked == true) seans = radioButton2.Text;
            else if (radioButton3.Checked == true) seans = radioButton3.Text;
            else if (radioButton4.Checked == true) seans = radioButton4.Text;
            else if (radioButton5.Checked == true) seans = radioButton5.Text;
            else if (radioButton6.Checked == true) seans = radioButton6.Text;
            else if (radioButton7.Checked == true) seans = radioButton7.Text;
            else if (radioButton8.Checked == true) seans = radioButton8.Text;
            else if (radioButton9.Checked == true) seans = radioButton9.Text;
            else if (radioButton10.Checked == true) seans = radioButton10.Text;
            else if (radioButton11.Checked == true) seans = radioButton11.Text;
            else if (radioButton12.Checked == true) seans = radioButton12.Text;

        }
        private void button4_Click(object sender, EventArgs e)
        {
            RadioButtonSeçiliyse();
            if (seans != "")
            {
                filmseansı.SeansEkleme(comboBox1.Text, comboBox2.Text, dateTimePicker1.Text, seans);
                dataGridView1.DataSource = filmseansı.SeansListesi2();
                MessageBox.Show("Seans Eklendi.", "Kayıt");
            }
            else if (seans == "")
            {
                MessageBox.Show("Seans seçimi yapmadınız!", "Uyarı");
            }
            
            comboBox2.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToLongDateString();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton12.Checked = false;
        }

        private void Seans_Ekle_Load(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = filmseansı.SeansListesi2();
            FilmveSalonGoster(comboBox1, "select *from FilmBilgileri","FilmAdi");
            FilmveSalonGoster(comboBox2, "select *from Salon_Bilgileri", "SalonAdi");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            foreach (Control item3 in groupBox1.Controls)
            {
                item3.Enabled = true;
            }
            DateTime bugün = DateTime.Parse(DateTime.Now.ToLongDateString());
            DateTime yeni = DateTime.Parse(dateTimePicker1.Text);
            if (yeni==bugün)
            {
                foreach (Control item in groupBox1.Controls)
                {
                    if (DateTime.Parse(DateTime.Now.ToLongDateString()) > DateTime.Parse(dateTimePicker1.Text))  
                    {
                        item.Enabled = false;
                    }
                }
                Tarihi_Karşılaştır();
            }
            else if (yeni>bugün)
            {
                Tarihi_Karşılaştır();
            }
            else if (yeni<bugün)
            {
                MessageBox.Show("Geriye dönük işlem yapılamaz!","Uyarı");
                dateTimePicker1.Text = DateTime.Now.ToLongDateString();
            }
        }

        private void Tarihi_Karşılaştır()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from SeansBilgileri where SalonAdi='" + comboBox2.Text + "' and tarih='" + dateTimePicker1.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read() == true)
            {
                foreach (Control item2 in groupBox1.Controls)
                {
                    if (read["seans"].ToString() == item2.Text)
                    {
                        item2.Enabled = false;
                    }
                }
            }
            baglanti.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
        }
        //boş buton dataGridView1.CurrentRow.Cells[0].Value.ToString());
        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = baglanti;
                command.CommandText = "update SeansBilgileri set FilmAdi='" + comboBox1.Text + "',SalonAdi='" + comboBox2.Text + "',Tarih='" + dateTimePicker1.Text + "',Seans='" + seans + "' where SeansId=@numara";
                command.Parameters.AddWithValue("@numara", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                command.ExecuteNonQuery();
                command.Dispose();
                baglanti.Close();
                dataGridView1.DataSource = filmseansı.SeansListesi2();
            }

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = baglanti;
                command.CommandText = "delete from SeansBilgileri where SeansId=@numara";
                command.Parameters.AddWithValue("@numara", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Güncel bir seansı sildiyseniz satılan biletleri iptal ediniz!", "Uyarı");
                command.ExecuteNonQuery();
                command.Dispose();
                baglanti.Close();
                dataGridView1.DataSource = filmseansı.SeansListesi2();
            } 
            
            
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
          
           
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            seans = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            diller("en-US");
        }

        private void türkçeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            diller("");
        }
    }
}
