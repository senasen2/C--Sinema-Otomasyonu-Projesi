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
    public partial class frmSalonEkleme : Form
    {
        public frmSalonEkleme()
        {
            InitializeComponent();
        }

        public void diller (string culture)
        {
            Thread.CurrentThread.CurrentUICulture.ClearCachedData();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            lblSalon.Text = Localization.lblSalon;
            lblSatir.Text = Localization.lblSatir;
            btn_SalonEkleme.Text = Localization.btn_SalonEkleme;
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Sinema_Otomasyonu;Integrated Security=True");
        sinemaTableAdapters.Salon_BilgileriTableAdapter salon = new sinemaTableAdapters.Salon_BilgileriTableAdapter();
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                salon.SalonEkleme(textBox1.Text, textBox2.Text);
                MessageBox.Show("Salon eklendi.", "Kayıt");
            }
            catch (Exception)
            {

                MessageBox.Show("Aynı isme sahip bir salon bulunmaktadır!");
            }
            textBox1.Text = "";
            textBox2.Text = "";
           






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
