using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;
using DTO;

namespace WindowsFormsApplication1
{
    public partial class SP : Form
    {
        public SP()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SanPham_BUS.hienthi();
        }

        private void SP_Load(object sender, EventArgs e)
        {

        }
    }
}