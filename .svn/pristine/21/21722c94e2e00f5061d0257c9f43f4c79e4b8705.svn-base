using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using BUS;


namespace WindowsFormsApplication1
{
    public partial class TimKiemSP : Form
    {
        public TimKiemSP()
        {
            InitializeComponent();
        }

        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string from= txtGia.Text;
            if (IsNumber(from) == false)
            { MessageBox.Show("Giá phải là số nguyên","Thông báo");
                return;
            }
            string soluong = txtsl.Text;
            if (IsNumber(soluong) == false)
            {
                MessageBox.Show("Số lượng phải là số nguyên", "Thông báo");
                return;
            }
            string to = txtto.Text;
            if (IsNumber(to) == false)
            {
                MessageBox.Show("Giá phải là số nguyên", "Thông báo");
                return;
            }
            string loai;
            string nhasx;
            SqlConnection cnn = sqlConnectionData.Ketnoi();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select * from LOAI where MaLoai='"+cbLoai.SelectedValue.ToString()+"'", cnn);
            SqlDataReader r = cmd.ExecuteReader();
           
            
                r.Read();
                loai = r.GetString(0).ToString();
                r.Close();
            SqlCommand cmd1 = new SqlCommand("select * from NHASX where MaSX='" + cbSX.SelectedValue.ToString() + "'", cnn);
            SqlDataReader r1 = cmd1.ExecuteReader();
           
                r1.Read();
               nhasx = r1.GetString(0).ToString();
               r1.Close();

            string masp = txtMa.Text;
            string tensp = txtTenSP.Text;
            SanPham_BUS.timkiemNC(masp, tensp, loai, from,to, nhasx, soluong);
            dataGridView1.DataSource = SanPham_BUS.timkiemNC(masp, tensp, loai, from,to, nhasx, soluong);


        }
        public class sqlConnectionData
        {
            public static SqlConnection Ketnoi()
            {
                SqlConnection cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bakery;Integrated Security=True");
                return cnn;
            }
        }

        private void TimKiemSP_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bakeryDataSet1.NHASX' table. You can move, or remove it, as needed.
            this.nHASXTableAdapter.Fill(this.bakeryDataSet1.NHASX);
            // TODO: This line of code loads data into the 'bakeryDataSet.LOAI' table. You can move, or remove it, as needed.
            this.lOAITableAdapter.Fill(this.bakeryDataSet.LOAI);
        }
        

        
    }
}
