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

namespace Proje
{
    public partial class frmYöneticiGirişi : Form
    {
        public frmYöneticiGirişi()
        {
            InitializeComponent();
        }

       public void diller (string culture)
        {
            Thread.CurrentThread.CurrentUICulture.ClearCachedData();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            button1.Text = Localization2.button1;
            button2.Text = Localization2.button2;
            button4.Text = Localization2.button4;
            button5.Text = Localization2.button5;
            button6.Text = Localization2.button6;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Film_Ekle film_Ekle = new Film_Ekle();
            film_Ekle.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSalonEkleme salonEkleme = new frmSalonEkleme();
            salonEkleme.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Seans_Ekle seans = new Seans_Ekle();
            seans.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmSeansListeleme seansListeleme = new frmSeansListeleme();
            seansListeleme.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmSatislisteleme satislisteleme = new frmSatislisteleme();
            satislisteleme.Show();
        }

        private void frmYöneticiGirişi_Load(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            YoneticiEkleme yoneticiekleme = new YoneticiEkleme();
            yoneticiekleme.Show();
        }
    }
}
