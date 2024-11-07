using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ado.NETProject
{
    public partial class FrmMap : Form
    {
        public FrmMap()
        {
            InitializeComponent();
        }

        private void btnOpenCityForm_Click(object sender, EventArgs e)
        {
            FrmCity frmCity = new FrmCity();
            frmCity.Show();
        }

        private void btnOpenCustomerForm_Click(object sender, EventArgs e)
        {
            FrmCustomer frmCustomer = new FrmCustomer();
            frmCustomer.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Kullanıcıya çıkış yapmak isteyip istemediğini soralım
            DialogResult result = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Eğer kullanıcı "Evet" derse uygulamayı kapatalım
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
