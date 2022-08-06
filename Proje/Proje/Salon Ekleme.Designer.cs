namespace Proje
{
    partial class frmSalonEkleme
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalonEkleme));
            this.lblSalon = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ımageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btn_SalonEkleme = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dilSeçinizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.türkçeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblSatir = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSalon
            // 
            this.lblSalon.AutoSize = true;
            this.lblSalon.BackColor = System.Drawing.Color.Transparent;
            this.lblSalon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSalon.ForeColor = System.Drawing.Color.White;
            this.lblSalon.Location = new System.Drawing.Point(79, 51);
            this.lblSalon.Name = "lblSalon";
            this.lblSalon.Size = new System.Drawing.Size(78, 16);
            this.lblSalon.TabIndex = 0;
            this.lblSalon.Text = "Salon Adı";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(170, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(111, 20);
            this.textBox1.TabIndex = 1;
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "cancel.png");
            // 
            // ımageList2
            // 
            this.ımageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList2.ImageStream")));
            this.ımageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList2.Images.SetKeyName(0, "cinema.png");
            // 
            // btn_SalonEkleme
            // 
            this.btn_SalonEkleme.BackColor = System.Drawing.Color.MintCream;
            this.btn_SalonEkleme.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_SalonEkleme.ImageIndex = 0;
            this.btn_SalonEkleme.ImageList = this.ımageList2;
            this.btn_SalonEkleme.Location = new System.Drawing.Point(198, 124);
            this.btn_SalonEkleme.Name = "btn_SalonEkleme";
            this.btn_SalonEkleme.Size = new System.Drawing.Size(83, 49);
            this.btn_SalonEkleme.TabIndex = 9;
            this.btn_SalonEkleme.Text = "Salon Ekle";
            this.btn_SalonEkleme.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_SalonEkleme.UseVisualStyleBackColor = false;
            this.btn_SalonEkleme.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Yellow;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dilSeçinizToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(338, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dilSeçinizToolStripMenuItem
            // 
            this.dilSeçinizToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.türkçeToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.dilSeçinizToolStripMenuItem.Name = "dilSeçinizToolStripMenuItem";
            this.dilSeçinizToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.dilSeçinizToolStripMenuItem.Text = "Languages";
            // 
            // türkçeToolStripMenuItem
            // 
            this.türkçeToolStripMenuItem.Name = "türkçeToolStripMenuItem";
            this.türkçeToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.türkçeToolStripMenuItem.Text = "Türkçe";
            this.türkçeToolStripMenuItem.Click += new System.EventHandler(this.türkçeToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(170, 89);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(111, 20);
            this.textBox2.TabIndex = 33;
            // 
            // lblSatir
            // 
            this.lblSatir.AutoSize = true;
            this.lblSatir.BackColor = System.Drawing.Color.Transparent;
            this.lblSatir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSatir.ForeColor = System.Drawing.Color.White;
            this.lblSatir.Location = new System.Drawing.Point(116, 89);
            this.lblSatir.Name = "lblSatir";
            this.lblSatir.Size = new System.Drawing.Size(41, 16);
            this.lblSatir.TabIndex = 35;
            this.lblSatir.Text = "Satır";
            // 
            // frmSalonEkleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(338, 243);
            this.Controls.Add(this.lblSatir);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btn_SalonEkleme);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblSalon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmSalonEkleme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSalon;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.ImageList ımageList2;
        private System.Windows.Forms.Button btn_SalonEkleme;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dilSeçinizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem türkçeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblSatir;
    }
}