using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Data.SqlClient;

namespace Proje
{
    public partial class frmYönetici : Form
    {
        public frmYönetici()
        {
            InitializeComponent();
        }

        private void diller (string culture)
        {
            Thread.CurrentThread.CurrentUICulture.ClearCachedData();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            label1.Text = Localization1.label1;
            label2.Text = Localization1.label2;
            button1.Text = Localization1.button1;
            
        }
        
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private void button1_Click(object sender, EventArgs e)
        {
            string KullaniciAdi = textBox1.Text;
            string Sifre = textBox2.Text;
            con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Sinema_Otomasyonu;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Yonetici where KullaniciAdi='" + textBox1.Text + "' AND Sifre='" + textBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                frmYöneticiGirişi girişi = new frmYöneticiGirişi();
                girişi.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.(Check your username and password)");
            }
            con.Close();
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