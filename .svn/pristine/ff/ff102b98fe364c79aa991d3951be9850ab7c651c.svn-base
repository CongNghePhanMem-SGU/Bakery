using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DAO
{
    class KetNoi
    {
        string cnnString = @"Data Source=.\sqlexpress;Initial Catalog=Bakery;Integrated Security=True";
        SqlConnection cnn;
        SqlCommand cmd;
        public SqlConnection Cnn 
        {
            get { return cnn; }
            set { cnn = value; }
        }
        //public SqlCommand Cmd { get; set; } khai báo thuộc tính
        public SqlCommand Cmd
        {
            get { return cmd; }
            set { cmd = value; }
        }
        public KetNoi()
        {
            cnn = new SqlConnection(cnnString);
        }

        public void MoKetNoi()
        {
            cnn.Open();
        }

        public void DongKetNoi()
        {
            cnn.Close();
        }
    }
}
