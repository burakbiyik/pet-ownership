﻿using Petilan.Sayfalar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Petilan
{
    public partial class Anasayfa : Form
    {
        
        public Anasayfa()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btDegistir_Click(object sender, EventArgs e)
        {

        }

        private void btUyeOl_Click(object sender, EventArgs e)
        {
            this.Hide();
            UyeOl uyeOl = new UyeOl();
            uyeOl.ShowDialog();

        }

        private void tbAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti;
        SqlCommand command;
        SqlDataReader dataReader;
        private void btGiris_Click(object sender, EventArgs e)
        {
            string user = tbKAdiAnasayfa.Text;
            string pass = tbSifreAnasayfa.Text;
            baglanti = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
            command = new SqlCommand();
            baglanti.Open();
            command.Connection = baglanti;
            command.CommandText = "SELECT * FROM tbl_Kullanici where KullaniciAdi='" + tbKAdiAnasayfa.Text + "' AND Sifre='" + tbSifreAnasayfa.Text + "'";
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                tbKAdiAnasayfa.Hide();
                tbSifreAnasayfa.Hide();
                label1.Hide();
                label2.Hide();
                btUyeOl.Hide();
                btGiris.Hide();
                btHesap.Visible = true;
                btHesap.Text = tbKAdiAnasayfa.Text;
                MessageBox.Show("Giriş Başarılı!");
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
            }
            baglanti.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void btHesap_Click(object sender, EventArgs e)
        {
            cmHesap.Show(Cursor.Position.X, Cursor.Position.Y);
        }

    }
}
