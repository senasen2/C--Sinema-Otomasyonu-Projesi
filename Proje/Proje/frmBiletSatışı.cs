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
    public partial class frmBiletSatışı : Form
    {
        public frmBiletSatışı()
        {
            InitializeComponent();
        }

        public void diller (string culture)
        {
            Thread.CurrentThread.CurrentUICulture.ClearCachedData();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            button1.Text = Localization3.button1;
            button2.Text = Localization3.button2;
            label1.Text = Localization3.label1;
            label2.Text = Localization3.label2;
            label3.Text = Localization3.label3;
            label4.Text = Localization3.label4;
            label5.Text = Localization3.label5;
            label6.Text = Localization3.label6;
            label7.Text = Localization3.label7;
            label8.Text = Localization3.label8;
            label9.Text = Localization3.label9;
            label10.Text = Localization3.label10;
            label11.Text = Localization3.label11;
            label12.Text = Localization3.label12;
            label13.Text = Localization3.label13;
            groupBox1.Text = Localization3.groupBox1;
            groupBox2.Text = Localization3.groupBox2;
            groupBox4.Text = Localization3.groupBox4;
        }




        SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Sinema_Otomasyonu;Integrated Security=True");

        private void Film_Tarihi_Getir()
        {
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from SeansBilgileri where FilmAdi='" + comboBox1.SelectedItem + "' and SalonAdi='" + comboBox2.SelectedItem + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (DateTime.Parse(read["Tarih"].ToString())>=DateTime.Parse(DateTime.Now.ToLongDateString()))
                {
                    if (!comboBox3.Items.Contains(read["Tarih"].ToString()))
                    {
                        comboBox3.Items.Add(read["Tarih"].ToString());

                    }

                }
            }
            baglanti.Close();
        }
        

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Film_Tarihi_Getir();
            Boş_Koltuklar();
            
        }

        
        int sayac = 0;
        private void FilmveSalonGoster(ComboBox combo, string sql1, string sql2)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sql1, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read .Read())
            {
                combo.Items.Add(read[sql2].ToString());
            }
            baglanti.Close();
        }
        private void FilmAfisiGoster()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from FilmBilgileri where FilmAdi='"+comboBox1.SelectedItem.ToString()+"'",baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                pictureBox1.ImageLocation = read["Resim"].ToString();
            }
            baglanti.Close();
        }
        
        

        private void Combo_Dolu_Koltuklar()
        {
            comboBox6.Items.Clear();
            comboBox6.Text = "";
            foreach (Control item in panel1.Controls)
            {
                if (item is Button)
                {
                    if (item.BackColor==Color.Red)
                    {
                        comboBox6.Items.Add(item.Text);
                    }
                }
            }
        }


        private void YenidenRenklendir()
        {
            foreach (Control item in panel1.Controls)
            {
                if (item is Button)
                {
                    item.BackColor = Color.White;
                }
            }
        }

        private void Veritabani_Dolu_Koltuklar()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from SatisBilgileri where FilmAdi ='"+comboBox1.SelectedItem+"' and SalonAdi ='"+comboBox2.SelectedItem+"' and Tarih ='"+comboBox3.SelectedItem+"' and saat='"+comboBox4.SelectedItem+"'",baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                
               
                    foreach (Control item in panel1.Controls)
                    {
                        if (item is Button)
                        {
                            if (read["KoltukNo"].ToString()==item.Text)
                            {
                                item.BackColor = Color.Red;

                            }
                        }
                    }
                
            }
            baglanti.Close();
        }

        private void frmBiletSatışı_Load(object sender, EventArgs e)
        {
            
            FilmveSalonGoster(comboBox1, "select *from FilmBilgileri", "FilmAdi");
            FilmveSalonGoster(comboBox2, "select *from Salon_Bilgileri", "SalonAdi");
        }

        int X;
        
        private void Boş_Koltuklar()
        {
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Salon_Bilgileri where SalonAdi='" + comboBox2.SelectedItem + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                X = Convert.ToInt16(read["X"]);
                

            }
            panel1.Controls.Clear();
            sayac = 1;
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(40, 40);
                    btn.BackColor = Color.White;
                    btn.ImageList = ımageList2;
                    btn.ImageIndex = 4;
                    btn.ForeColor = Color.Black;
                    btn.Location = new Point(j * 40 + 30, i * 40 + 40);
                    btn.Name = sayac.ToString();
                    btn.Text = sayac.ToString();
                    if (j == 4)
                    {
                        continue;
                    }
                    sayac++;
                    this.panel1.Controls.Add(btn);
                    btn.Click += Btn_Click;
                }  
                
                
            }
            baglanti.Close();
            
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.BackColor==Color.White)
            {
                textBox1.Text = b.Text;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void FilmHakkindaGoster()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from FilmBilgileri where FilmAdi='" + comboBox1.SelectedItem.ToString() + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                groupBox4.Text = read["FilmHakkinda"].ToString();
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox3.Items.Clear();
            comboBox2.Text = "";
            comboBox4.Text = "";
            comboBox3.Text = "";
            foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
            FilmAfisiGoster();
            FilmHakkindaGoster();
            YenidenRenklendir();
            Combo_Dolu_Koltuklar();
        }
        sinemaTableAdapters.SatisBilgileriTableAdapter satis = new sinemaTableAdapters.SatisBilgileriTableAdapter();

        public short Satir { get; private set; }
        public short Sutun { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                try
                {
                    satis.Satış_Yap(textBox1.Text, comboBox2.Text, comboBox1.Text, comboBox3.Text, comboBox4.Text, textBox2.Text, textBox3.Text, comboBox5.Text, DateTime.Now.ToString());
                    foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
                    YenidenRenklendir();
                    Veritabani_Dolu_Koltuklar();
                    Combo_Dolu_Koltuklar();


                }
                catch (Exception hata)
                {

                    MessageBox.Show("Hata oluştu."+hata.Message, "Uyarı");
                } 
            }
            else
            {
                MessageBox.Show("Koltuk seçimi yapınız.", "Uyarı");
            }
        }
        private void Film_Seansi_Getir()
        {
            comboBox4.Text = "";
            comboBox4.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from SeansBilgileri where FilmAdi='" + comboBox1.SelectedItem + "' and SalonAdi='" + comboBox2.SelectedItem + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (DateTime.Parse(read["Tarih"].ToString()) == DateTime.Parse(DateTime.Now.ToLongDateString()))
                {
                    if (DateTime.Parse(read["Seans"].ToString()) > DateTime.Parse(DateTime.Now.ToLongTimeString()))
                    {
                        comboBox4.Items.Add(read["Seans"].ToString());
                    }

                }
               else if (DateTime.Parse(read["Tarih"].ToString()) > DateTime.Parse(DateTime.Now.ToLongDateString()))
                {
                    
                        comboBox4.Items.Add(read["Seans"].ToString());

                    

                }
            }
            baglanti.Close();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Film_Seansi_Getir();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            YenidenRenklendir();
            Veritabani_Dolu_Koltuklar();
            Combo_Dolu_Koltuklar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text!="")
            {
                try
                {
                  satis.Satış_iptal(comboBox1.Text,comboBox2.Text,comboBox3.Text,comboBox4.Text,comboBox6.Text);
                  YenidenRenklendir();
                  Veritabani_Dolu_Koltuklar();
                  Combo_Dolu_Koltuklar();
                }  
                catch (Exception hata)
                {
                    MessageBox.Show("Hata Oluştu"+hata.Message, "Uyarı");
                    
                }
            }
            else
            {
                MessageBox.Show("Koltuk Seçmediniz!","Uyarı");
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
