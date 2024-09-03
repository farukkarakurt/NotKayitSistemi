using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace Not_Kayit_Sistemi
{
    public partial class FrmOgrtmnDetay : Form
    {
        public FrmOgrtmnDetay()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=FARUK\\SQLEXPRESS;Initial Catalog=DbNotKayıt;Integrated Security=True");

        private void FrmOgrtmnDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNotKayıtDataSet.TBLDERS' table. You can move, or remove it, as needed.
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLDERS (OGRNUMARA,OGRAD,OGRSOYAD) values (@P1,@P2,@P3)", conn);

            cmd.Parameters.AddWithValue("@P1", masked_numara.Text);
            cmd.Parameters.AddWithValue("@P2", txt_isim.Text);
            cmd.Parameters.AddWithValue("@P3", txt_soyad.Text);

            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Öğrenci Sisteme Eklendi");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            masked_numara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txt_isim.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txt_soyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txt_Sınav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txt_Sınav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txt_Sınav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();


        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            double ortalama, s1, s2, s3;
            string durum;
            

            s1 = Convert.ToDouble(txt_Sınav1.Text);
            s2 = Convert.ToDouble(txt_Sınav2.Text);
            s3 = Convert.ToDouble(txt_Sınav3.Text);

            ortalama = (s1 + s2 + s3) / 3;

            lbl_ortalama.Text = ortalama.ToString();


            if (ortalama >= 50)
            {
                durum = "True";


            }
            else
            {
                durum = "False";

            }

            conn.Open();
            SqlCommand cmd = new SqlCommand("update TBLDERS set OGRS1=@P1,OGRS2=@P2,OGRS3=@P3,ORTALAMA=@P4,DURUM=@P5 WHERE OGRNUMARA=@P6", conn);
            cmd.Parameters.AddWithValue("@P1", txt_Sınav1.Text);
            cmd.Parameters.AddWithValue("@P2", txt_Sınav2.Text);
            cmd.Parameters.AddWithValue("@P3", txt_Sınav3.Text);
            cmd.Parameters.AddWithValue("@P4", decimal.Parse(lbl_ortalama.Text));
            cmd.Parameters.AddWithValue("@P5", durum);
            cmd.Parameters.AddWithValue("@P6", masked_numara.Text);


            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Öğrenci Sınav Bilgileri Güncellendi");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);

            KalanGecenSayısı();
        }


        private void KalanGecenSayısı()
        {
            conn.Open();

            // Ortalaması 50'den büyük olan kişi sayısı
            SqlCommand cmdGecen = new SqlCommand("SELECT COUNT(*) FROM TBLDERS WHERE ORTALAMA >= 50", conn);
            int gecenSayisi = (int)cmdGecen.ExecuteScalar();
            lbl_gecenSay.Text = gecenSayisi.ToString();

            // Ortalaması 50'den küçük olan kişi sayısı
            SqlCommand cmdKalan = new SqlCommand("SELECT COUNT(*) FROM TBLDERS WHERE ORTALAMA < 50", conn);
            int kalanSayisi = (int)cmdKalan.ExecuteScalar();
            lbl_kalanSay.Text = kalanSayisi.ToString();

            conn.Close();
        }

    }
}
