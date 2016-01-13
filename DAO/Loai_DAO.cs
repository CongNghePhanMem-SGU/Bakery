﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DTO;
using System.Data;

namespace DAO
{
    public class Loai_DAO
    {
        KetNoi ketnoi;
        public Loai_DAO()
        {
            ketnoi = new KetNoi();
        }

        public DataTable HienThi()
        {
            DataTable table = new DataTable();
            string laydl = "select * from Loai";
            ketnoi.Cmd = new SqlCommand(laydl, ketnoi.Cnn);
            ketnoi.MoKetNoi();
            SqlDataAdapter adap = new SqlDataAdapter(ketnoi.Cmd);
            adap.Fill(table);
            ketnoi.DongKetNoi();
            return table;
        }

        public bool ThemLoai(Loai_DTO loai)
        {
            bool kq = false;
            string them = "insert into Loai values(@maloai, @tenloai)";
            ketnoi.Cmd = new SqlCommand(them, ketnoi.Cnn);
            ketnoi.Cmd.Parameters.Add("@maloai", SqlDbType.NVarChar, 10);
            ketnoi.Cmd.Parameters.Add("@tenloai", SqlDbType.NVarChar, 30);

            ketnoi.Cmd.Parameters["@maloai"].Value = loai.MaLoai;
            ketnoi.Cmd.Parameters["@tenloai"].Value = loai.TenLoai;
            ketnoi.MoKetNoi();
            if (ketnoi.Cmd.ExecuteNonQuery() > 0)
            {
                kq = true;
            }
            ketnoi.DongKetNoi();
            return kq;
        }

        public bool SuaLoai(Loai_DTO loai)
        {
            bool kq = false;
            string sua = "update Loai set TenLoai=@tenloai where MaLoai=@maloai";
            ketnoi.Cmd = new SqlCommand(sua, ketnoi.Cnn);
            ketnoi.Cmd.Parameters.Add("@maloai", SqlDbType.NVarChar, 10);
            ketnoi.Cmd.Parameters.Add("@tenloai", SqlDbType.NVarChar, 30);

            ketnoi.Cmd.Parameters["@maloai"].Value = loai.MaLoai;
            ketnoi.Cmd.Parameters["@tenloai"].Value = loai.TenLoai;
            ketnoi.MoKetNoi();
            if (ketnoi.Cmd.ExecuteNonQuery() > 0)
            {
                kq = true;
            }
            ketnoi.DongKetNoi();
            return kq;
        }

        public bool XoaLoai(string maloai)
        {
            bool kq = false;
            string xoa = "delete from Loai where MaLoai=@maloai";
            ketnoi.Cmd = new SqlCommand(xoa, ketnoi.Cnn);
            ketnoi.Cmd.Parameters.Add("@maloai", SqlDbType.NVarChar, 10);
            ketnoi.Cmd.Parameters["@maloai"].Value = maloai;
            ketnoi.MoKetNoi();
            if (ketnoi.Cmd.ExecuteNonQuery() > 0)
            {
                kq = true;
            }
            ketnoi.DongKetNoi();
            return kq;
        }

        public bool KiemTra(string maloai)
        {
            bool kq = false;
            DataTable table = new DataTable();
            string laydl = "select * from Loai where MaLoai=@maloai";
            ketnoi.Cmd = new SqlCommand(laydl, ketnoi.Cnn);
            ketnoi.Cmd.Parameters.Add("@maloai", SqlDbType.NVarChar, 10);
            ketnoi.Cmd.Parameters["@maloai"].Value = maloai;
            ketnoi.MoKetNoi();
            SqlDataAdapter adap = new SqlDataAdapter(ketnoi.Cmd);
            adap.Fill(table);
            ketnoi.DongKetNoi();
            if (table.Rows.Count > 0)
            {
                kq = true;
            }
            return kq;
        }

        public DataTable TimKiem(string chuoi)
        {
            DataTable table = new DataTable();
            string tim = "select * from Loai where MaLoai like @maloai or TenLoai like @tenloai";
            ketnoi.Cmd = new SqlCommand(tim, ketnoi.Cnn);
            ketnoi.Cmd.Parameters.Add("@maloai", SqlDbType.NVarChar, 10);
            ketnoi.Cmd.Parameters.Add("@tenloai", SqlDbType.NVarChar, 30);

            ketnoi.Cmd.Parameters["@maloai"].Value = "%"+chuoi+"%";
            ketnoi.Cmd.Parameters["@tenloai"].Value = "%" + chuoi + "%";
            ketnoi.MoKetNoi();
            SqlDataAdapter adap = new SqlDataAdapter(ketnoi.Cmd);
            adap.Fill(table);
            ketnoi.DongKetNoi();
            return table;
        }
    }
}
