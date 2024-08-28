using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Not_Kayit_Sistemi
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmOgrDetay frmOgrDetay = new FrmOgrDetay();
            frmOgrDetay.numara = mask_ogreNumara.Text;
            frmOgrDetay.Show();

        }

        private void mask_ogreNumara_TextChanged(object sender, EventArgs e)
        {
            if (mask_ogreNumara.Text== "1111")
            {
                FrmOgrtmnDetay frm=new FrmOgrtmnDetay();
                frm.Show();

                // Emir Karakurt
            }
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
