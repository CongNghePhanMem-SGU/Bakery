using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void btnPro_Click(object sender, EventArgs e)
        {
            SP _sp = new SP ();
            _sp.Show();
            //this.Dispose();
        }

        private void btnHD_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.Show();
        }

        private void btnLoai_Click(object sender, EventArgs e)
        {
            loaisp l = new loaisp();
            l.Show();
        }

        private void btnNsx_Click(object sender, EventArgs e)
        {
            NhaSX nsx = new NhaSX();
            nsx.Show();
        }

        private void btnCTHD_Click(object sender, EventArgs e)
        {
            CTHD cthd = new CTHD();
            cthd.Show();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            kho k = new kho();
            k.Show();
        }
       
    }
}
