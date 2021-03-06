﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class sqlConnectionData
    {
        public static SqlConnection Ketnoi()
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bakery;Integrated Security=True");
            return cnn;
        }
    }
    public class SanPham_DAO
    {
        //hiển thị DS
        public static DataTable hienthi()
        {
            SqlConnection cnn= sqlConnectionData.Ketnoi();
            cnn.Open();
            string sql = "select * from SANPHAM";
            SqlCommand cmd= new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            cnn.Close();
            return dtb;
        }
        public static DataTable timkiem(string Ma)
        {
            SqlConnection cnn = sqlConnectionData.Ketnoi();
            string sql = "select * from SANPHAM where MaSP= @Ma ";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Ma", SqlDbType.NVarChar, 10);
            cmd.Parameters["@Ma"].Value=Ma;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        public static DataTable timkiemNC(string Ma,string ten,string loai, string from, string to, string sx,string soluong)
        {
            SqlConnection cnn = sqlConnectionData.Ketnoi();
            string sql = "select * from SANPHAM where MaSP like '%" + Ma + "%' and TenSP like'%" + ten + "%' and LoaiSP like'%" + loai + "%'  and NhaSX like'%" + sx + "%' and Soluong like'%" + soluong + "%' and (Dongia between '" + from + "'and'"+to+"')";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        
        public static void ThemSP(SanPham_DTO sp)
        { 
            SqlConnection cnn= sqlConnectionData.Ketnoi();
            string sql = "insert into SANPHAM values(@ma,@ten,@loai,@dongia,@nhasx,@soluong)";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ma",SqlDbType.NVarChar,10);
            cmd.Parameters.Add("@ten",SqlDbType.NVarChar,50);
            cmd.Parameters.Add("@loai",SqlDbType.NVarChar,10);
            cmd.Parameters.Add("@dongia",SqlDbType.Int);
            cmd.Parameters.Add("@nhasx",SqlDbType.NVarChar,10);
            cmd.Parameters.Add("@soluong",SqlDbType.Int);

            cmd.Parameters["@ma"].Value = sp.masp;
            cmd.Parameters["@ten"].Value = sp.tensp;
            cmd.Parameters["@loai"].Value = sp.loaisp;
            cmd.Parameters["@dongia"].Value = sp.dongia;
            cmd.Parameters["@nhasx"].Value = sp.nhasx;
            cmd.Parameters["@soluong"].Value =sp.soluong;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static void SuaSP(SanPham_DTO sp,string macu)
        {
            SqlConnection cnn = sqlConnectionData.Ketnoi();
            string sql = "update SANPHAM set MaSP=@ma,TenSP=@ten,LoaiSP=@loai,Dongia=@dongia,NhaSX=nhasx,SoLuong=@soluong where MaSP='"+macu+"'";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar, 10);
            cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@loai", SqlDbType.NVarChar, 10);
            cmd.Parameters.Add("@dongia", SqlDbType.Int);
            cmd.Parameters.Add("@nhasx", SqlDbType.NVarChar, 10);
            cmd.Parameters.Add("@soluong", SqlDbType.Int);


            cmd.Parameters["@ma"].Value = sp.masp;
            cmd.Parameters["@ten"].Value = sp.tensp;
            cmd.Parameters["@loai"].Value = sp.loaisp;
            cmd.Parameters["@dongia"].Value = sp.dongia;
            cmd.Parameters["@nhasx"].Value = sp.nhasx;
            cmd.Parameters["@soluong"].Value = sp.soluong;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static void XoaSP(string MaSP)
        {
            SqlConnection cnn = sqlConnectionData.Ketnoi();
            string sql = "delete SANPHAM where MaSP=@ma";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar, 10);
            cmd.Parameters["@ma"].Value = MaSP;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
