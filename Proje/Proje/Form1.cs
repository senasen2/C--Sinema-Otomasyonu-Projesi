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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void diller(string culture)
        {
            Thread.CurrentThread.CurrentUICulture.ClearCachedData();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            label1.Text = Localization.label1;
            label2.Text = Localization.label2;
            label3.Text = Localization.label3;
            button1.Text = Localization.button1;
            button2.Text = Localization.button2;
            
        }



        SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Sinema_Otomasyonu;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            frmYönetici yönetici = new frmYönetici();
            yönetici.Show();
            Hide();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            frmBiletSatışı satis = new frmBiletSatışı();
            satis.Show();
            Hide();
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
