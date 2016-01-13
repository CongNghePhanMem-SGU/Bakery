create database [Bakery]
go
use [Bakery]
go



create table SANPHAM (
  MaSP varchar(10) primary key,
  TenSP varchar(50) ,
  LoaiSP varchar(10) ,
  Dongia int ,
  NhaSX varchar(10),
  Soluong int
)
go
create table LOAI (
	MaLoai varchar(10) primary key,
	TenLoai varchar(30)
)
go
--alter table LOAI
--alter column MaLoai nvarchar(10)
alter table LOAI
alter column TenLoai nvarchar(30)
go

create table NHASX (
	MaSX varchar(10) primary key,
	TenNSX varchar(100) ,
	DiaChi varchar (100) ,
	SDT varchar(15) 
)
go

create table KHO(
	MaSP varchar(10) primary key,
	SoLuong int  ,
	NgayNhap datetime
)
go

create table HOADON(
	MaHD varchar(10) primary key,
	NgayHD datetime,
	TongTien int
)
go

create table CTHD(
	MaHD varchar(10) ,
	MaSP varchar (10) ,
	SoLuong int ,
	ThanhTien int,
	constraint PK_CTHD primary key (MaHD, MaSP)
)
go
insert into LOAI values('L02','Tiramisu')
 
insert into LOAI values ('L01','CupCake')
insert into NHASX values ('SX01','ABC','Q6',0835097802)
insert into SANPHAM values ('CK01', 'CupCake Strawberry','CupCake',15000,'SX01',null)

create proc SuaSP 

alter proc ThemSP @ma varchar(10), @ten varchar(50), @loai varchar(10),@dongia int, @nhasx varchar(10)
as
begin
	insert into SANPHAM values(@ma,@ten,@loai,@dongia,@nhasx)
end
go

create proc XoaSP @ma varchar (10)
as
begin
	delete SANPHAM where MaSP=@ma
end
go

create proc HienThi
as
begin
	select * from SANPHAM
end
go

create proc ThemLoai @maloai varchar(10), @tenloai varchar(30)
as
begin
	insert into LOAI values(@maloai,@tenloai)
end
go
select * from LOAI