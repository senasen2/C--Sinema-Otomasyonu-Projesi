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
    public partial class YoneticiEkleme : Form
    {
        public YoneticiEkleme()
        {
            InitializeComponent();
        }

        private void diller(string culture)
        {
            Thread.CurrentThread.CurrentUICulture.ClearCachedData();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            label1.Text = Localization1.label1;
            label2.Text = Localization1.label2;
            btn_ekle.Text = Localization1.btn_ekle;

        }

        SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Sinema_Otomasyonu;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string kayit = "insert into Yonetici (KullaniciAdi,Sifre) values (@KullaniciAdi,@Sifre)";

                SqlCommand komut = new SqlCommand (kayit, baglanti);
                
                komut.Parameters.AddWithValue("@KullaniciAdi", textBox1.Text);
                komut.Parameters.AddWithValue("@Sifre", textBox2.Text);
                komut.ExecuteNonQuery();
           
                baglanti.Close();
                MessageBox.Show("Yönetici eklendi.");
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
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
