using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAO;
using DTO;

namespace BUS
{
    public class SanPham_BUS
    {
        public static DataTable hienthi()
        {
            return SanPham_DAO.hienthi();
        }
        public static void ThemSP(SanPham_DTO sp)
        {
            SanPham_DAO.ThemSP(sp);
        }
        public static void SuaSP(SanPham_DTO sp, string macu)
        {
            SanPham_DAO.SuaSP(sp,macu);
        }
        public static void XoaSP(string MaSP)
        {
            SanPham_DAO.XoaSP(MaSP);
        }
        public static DataTable timkiem(string ma)
        {
            return SanPham_DAO.timkiem(ma);
        }
        public static DataTable timkiemNC(string ma, string ten, string loai, string from,string to, string sx, string soluong)
        {
            return SanPham_DAO.timkiemNC(ma, ten, loai,from ,to, sx, soluong);
        }
    }
}