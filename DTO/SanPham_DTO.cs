using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class SanPham_DTO
    {
        private String MaSP;
        private String TenSP;
        private int DonGia;
        private String LoaiSP;
        private String NhaSX;
        private int SoLuong;


        public int soluong
        {
            get { return SoLuong; }
            set { SoLuong = value; }
        }
        public String masp
        {
            get { return MaSP; }
            set { MaSP = value; }
        }
        public String tensp
        {
            get { return TenSP; }
            set { TenSP = value; }
        }
        public int dongia
        {
            get { return DonGia; }
            set { DonGia = value; }
        }
        public String loaisp
        {
            get { return LoaiSP; }
            set { LoaiSP = value; }
        }
        public String nhasx
        {
            get { return NhaSX; }
            set { NhaSX = value; }
        }
       
        public SanPham_DTO(String msp, String tsp,  String lsp,int dg, String nsx ,int sl)
        {
            masp = msp;
            tensp = tsp;
            dongia = dg;
            loaisp = lsp;
            nhasx = nsx;
            soluong = sl;
         
        }
    }
}
