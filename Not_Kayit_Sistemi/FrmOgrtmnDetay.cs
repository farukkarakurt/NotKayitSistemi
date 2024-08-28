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
            SqlCommand cmd = new SqlCommand("insert into TBLDERS (OGRNUMARA,OGRAD,OGRSOYAD) values (@P1,@P2,@P3)",conn);

            cmd.Parameters.AddWithValue("@P1", masked_numara.Text);
            cmd.Parameters.AddWithValue("@P2",txt_isim.Text);
            cmd.Parameters.AddWithValue("@P3",txt_soyad.Text);

            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Öğrenci Sisteme Eklendi");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);

        }
    }
}
