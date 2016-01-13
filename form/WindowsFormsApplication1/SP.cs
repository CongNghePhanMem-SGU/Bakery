using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
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
        public class sqlConnectionData
        {
            public static SqlConnection Ketnoi()
            {
                SqlConnection cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bakery;Integrated Security=True");
                return cnn;
            }
        }
        private void SP_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bakeryDataSet1.NHASX' table. You can move, or remove it, as needed.
            this.nHASXTableAdapter.Fill(this.bakeryDataSet1.NHASX);
            // TODO: This line of code loads data into the 'bakeryDataSet.LOAI' table. You can move, or remove it, as needed.
            this.lOAITableAdapter.Fill(this.bakeryDataSet.LOAI);
            dataGridView1.DataSource = SanPham_BUS.hienthi();
            
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (kiemtratrungdl() == true)
            {
                MessageBox.Show("Mã bánh không được trùng", "Thông Báo");
                return;
            }
            if (txtMaSP.Text == "" || txtGia.Text == "" || txtsl.Text == "" || txtTenSP.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông Báo");
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

            string masp = txtMaSP.Text;
            string tensp = txtTenSP.Text;
            int gia = int.Parse(txtGia.Text);
            int soluong=int.Parse(txtsl.Text);
           
            SanPham_DTO sp = new SanPham_DTO(masp, tensp,loai,gia,nhasx,soluong);
            SanPham_BUS.ThemSP(sp);
            dataGridView1.DataSource = SanPham_BUS.hienthi();
            cnn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string masp = dataGridView1.CurrentCell.Value.ToString();
            if (MessageBox.Show("Chắc chắn xóa chứ ?", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SanPham_BUS.XoaSP(masp);
            }
            dataGridView1.DataSource = SanPham_BUS.hienthi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimKiemSP tk = new TimKiemSP();
            tk.Show();
        }


        private void dataGridView1_RowSelected(object sender, EventArgs e)
        {
           
            if (dataGridView1.CurrentRow != null)
            {
                txtMaSP.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
                txtGia.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
                txtsl.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString().Trim();
                txtTenSP.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
                cbLoai.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                cbSX.SelectedValue = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            }
        }
        private bool kiemtratrungdl()
        {
            bool tam = false;
            string ma=txtMaSP.Text;
            SqlConnection cnn = sqlConnectionData.Ketnoi();
            cnn.Open();
            string sql = "SELECT * from SANPHAM ";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (ma == dr.GetString(0))
                {
                    tam = true;
                    break;
                }
            }
            cnn.Close();
            return tam;
        }
        
        
        private void button4_Click(object sender, EventArgs e)
        {
            
            string old = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            string masp = txtMaSP.Text;
            if (old != masp)
            {
                MessageBox.Show("Không được sửa mã bánh!", "Thông Báo");
                return;
            }
            string loai;
            string nhasx;
            SqlConnection cnn = sqlConnectionData.Ketnoi();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select * from LOAI where MaLoai='" + cbLoai.SelectedValue.ToString() + "'", cnn);
            SqlDataReader r = cmd.ExecuteReader();


            r.Read();
            loai = r.GetString(0).ToString();
            r.Close();
            SqlCommand cmd1 = new SqlCommand("select * from NHASX where MaSX='" + cbSX.SelectedValue.ToString() + "'", cnn);
            SqlDataReader r1 = cmd1.ExecuteReader();

            r1.Read();
            nhasx = r1.GetString(0).ToString();
            r1.Close();

            string tensp = txtTenSP.Text;
            int gia = int.Parse(txtGia.Text);
            int soluong = int.Parse(txtsl.Text);
            SanPham_DTO sp = new SanPham_DTO(masp, tensp, loai, gia, nhasx, soluong);
           
            SanPham_BUS.SuaSP(sp,txtMaSP.Text);
            dataGridView1.DataSource = SanPham_BUS.hienthi();
            cnn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.txtMaSP.Clear();
            this.txtTenSP.Clear();
            this.txtGia.Clear();
            this.txtsl.Clear();
            this.txtTim.Clear();
            dataGridView1.DataSource = SanPham_BUS.hienthi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string masp = txtTim.Text;
            SanPham_BUS.timkiem(masp);
            dataGridView1.DataSource = SanPham_BUS.timkiem(masp);
        }     
    }
}