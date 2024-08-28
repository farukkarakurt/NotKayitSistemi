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

namespace Not_Kayit_Sistemi
{
    public partial class FrmOgrDetay : Form
    {
        public FrmOgrDetay()
        {
            InitializeComponent();
        }

        public string numara;

        SqlConnection conn = new SqlConnection("Data Source=FARUK\\SQLEXPRESS;Initial Catalog=DbNotKayıt;Integrated Security=True");
        private void FrmOgrDetay_Load(object sender, EventArgs e)
        {
            lbl_numara.Text = numara;

            conn.Open();

            SqlCommand cmd = new SqlCommand("Select * from TBLDERS where OGRNUMARA=@p1",conn);
            cmd.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                lbl_AdSoyad.Text = dr[2].ToString()+" " + dr[3].ToString();
                lbl_Sınav1.Text = dr[4].ToString();
                lbl_Sınav2.Text = dr[5].ToString();
                lbl_Sınav3.Text = dr[6].ToString();
                lbl_Ortalama.Text = dr[7].ToString();
                lbl_durum.Text = dr[8].ToString();  
            }

            conn.Close();
        }
    }
}
