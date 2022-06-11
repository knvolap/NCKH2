USE master
GO
IF EXISTS(SELECT name FROM sysdatabases WHERE name ='QuanLyDKHocBong')
DROP DATABASE QuanLyDKHocBong
go
------------------------------------------------------------------------------------------
----Bắt đầu ----

CREATE DATABASE QuanLyDKHocBong
GO
USE QuanLyDKHocBong
GO

--TẠO CÁC BẢNG--	

-- BẢNG 1--
CREATE TABLE Khoa(
	idKhoa VARCHAR(20) PRIMARY KEY,
	tenKhoa NVARCHAR(300) NOT NULL
)
GO
-- BẢNG 2--
CREATE TABLE Nganh(
	idNganh VARCHAR(20) PRIMARY KEY,
	idKhoa VARCHAR(20),
	tenNganh NVARCHAR(300) NOT NULL
)
GO
-- BẢNG 3--
CREATE TABLE Lop(
	idLop VARCHAR(20) PRIMARY KEY,
	idNganh VARCHAR(20),
	tenLop NVARCHAR(50) NOT NULL,
	nienKhoa VARCHAR(50) not null
)
GO
-- BẢNG 4--
CREATE TABLE HocKy(
	idHocKy VARCHAR(20) PRIMARY KEY,
	tenHocKy NVARCHAR(50) NOT NULL,
	NamHoc DATETIME not null,
	tgBatDau date not null,
	tgKetThuc date not null
)
GO
-- BẢNG 5--
CREATE TABLE SinhVien(
	idSinhVien VARCHAR(20) PRIMARY KEY,
	idLop		VARCHAR(20),
	tenSinhVien NVARCHAR(100) NOT NULL,
	passwordSV VARCHAR(20) not null,
	ngaySinh	DATETIME,
	email	VARCHAR(50) UNIQUE NOT NULL,
	soDienThoai CHAR(10)  NULL,
	gioiTinh CHAR(1) DEFAULT 'M',
	diaChi	NVARCHAR(100) NULL,
)
Alter table SinhVien
add PhotoPath varchar(500)

GO


-- BẢNG 6--
CREATE TABLE Diem(
	idHocKy VARCHAR(20),
	idSinhVien VARCHAR(20),
	soTinChi int not null,
	diemThang4 float,
	diemThang10 float,
	xepLoai NVARCHAR(20)not null,
	diemRenLuyen TINYINT not null,
	CONSTRAINT PK_IDSINHVIEN_IDHOCKY PRIMARY KEY (idHocKy,idSinhVien)
)

DROP TABLE Diem
GO
-- BẢNG 7--
CREATE TABLE CapDoHoatDong(
	idCapDo VARCHAR(20) PRIMARY KEY,
	tenCapDo NVARCHAR(50) NOT NULL,
	heSo TINYINT not null
)
GO
-- BẢNG 8--
CREATE TABLE LoaiGiai(
	idLoaiGiai VARCHAR(20) PRIMARY KEY,
	tenGiai NVARCHAR(50) NOT NULL,
	diemThanhTich TINYINT not null
)
GO

-- BẢNG 9--
CREATE TABLE HoatDong(
	idHoatDong VARCHAR(20) PRIMARY KEY,
	tenHoatDong NVARCHAR(100) NOT NULL,
	ngayBatDau DATETIME not null,
	ngayKetThuc DATETIME not null,
	ghiChu NVARCHAR(300) NULL
)
GO
-- BẢNG 10--
CREATE TABLE LoaiHocBong(
	idLHB VARCHAR(20) PRIMARY KEY,
	tenLHB NVARCHAR(50) NOT NULL,
)
GO


-- BẢNG 11--
CREATE TABLE HocBong(
	idHocBong VARCHAR(20) PRIMARY KEY,
	idLHB VARCHAR(20),
	tenHB NVARCHAR(200) NOT NULL,
	noiDungHB NVARCHAR(MAX) NOT NULL,
	doiTuongApDung NVARCHAR(300) NOT NULL,
	nhaTaiTro NVARCHAR(100) NOT NULL,
	ngayBatDau DATETIME not null,
	ngayKetThuc DATETIME not null,
	kinhPhi DECIMAL,
	soLuong SMALLINT not null,
	soLuongDaDK SMALLINT not null,
	ngayDuKienPhatHB DATETIME
)
GO

-- BẢNG 12--
CREATE TABLE DangKyHocBong(
	idDangKy VARCHAR(20) PRIMARY KEY ,
	idSinhVien VARCHAR(20),
	idHocBong VARCHAR(20),
	tgDangKy DATETIME not null,
	tinhTrang NVARCHAR(15) not null
)
GO

-- BẢNG 13--
CREATE TABLE DanhSachThamGiaHoatDong(
	idDangKy VARCHAR(20),
	idHoatDong VARCHAR(20),
	idCapDo	VARCHAR(20),
	idLoaiGiai VARCHAR(20) ,
	minhChung IMAGE not null,
	diemHoatDong TINYINT not null
)




--RÀNG BUỘC CÁC BẢNG--
--BẢNG 2---
GO
ALTER TABLE Nganh
	ADD CONSTRAINT FK_IDKHOA_NGANH FOREIGN KEY (idKhoa) REFERENCES Khoa(idKhoa);
GO
--BẢNG 3---
ALTER TABLE Lop
	ADD CONSTRAINT FK_IDNGANH_LOP FOREIGN KEY (idNganh) REFERENCES Nganh(idNganh)
GO

-- BẢNG 5--
ALTER TABLE SinhVien
	ADD CONSTRAINT FK_IDLOP_SINHVIEN FOREIGN KEY (idLop) REFERENCES Lop(idLop),
		CONSTRAINT CHECK_NGAYSINH CHECK (dateDiff(year, NgaySinh, getdate())>=17),
		CONSTRAINT CHECK_EMAIL CHECK ( email LIKE '[A-Za-z0-9]%@gmail.com' OR email LIKE '[A-Za-z0-9]%@ute.udn.vn'),
		CONSTRAINT CHECK_SODIENTHOAI CHECK ( soDienThoai LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' ),
		CONSTRAINT CHECK_GIOITINH CHECK ( gioiTinh IN ( 'M', 'F' ) ) --male: nam; female: nữ
GO
--BẢNG 6---
ALTER TABLE Diem
	ADD CONSTRAINT FK_IDHOCKY_DIEM FOREIGN KEY (idHocKy) REFERENCES HocKy(idHocKy),
		CONSTRAINT FK_IDSINHVIEN_DIEM FOREIGN KEY (idSinhVien) REFERENCES SinhVien(idSinhVien),
		CONSTRAINT CHECK_DIEMTHANG4 CHECK (diemThang4 >=0 and DiemThang4 <=4),
		CONSTRAINT CHECK_DIEMTHANG10 CHECK (DiemThang10 >=0 and DiemThang10 <=10),
		CONSTRAINT CHECK_SoTinChi CHECK (soTinChi >=14 )
GO
Alter table Diem drop constraint FK_IDHOCKY_DIEM

GO
Alter table Diem drop constraint FK_IDSINHVIEN_DIEM

GO
--BẢNG 6---
ALTER TABLE Diem
	ADD CONSTRAINT FK_IDHOCKY_DIEM FOREIGN KEY (idHocKy) REFERENCES HocKy(idHocKy)ON DELETE CASCADE ON UPDATE CASCADE,
		CONSTRAINT FK_IDSINHVIEN_DIEM FOREIGN KEY (idSinhVien) REFERENCES SinhVien(idSinhVien) ON DELETE CASCADE ON UPDATE CASCADE

GO
--BẢNG 11---
ALTER TABLE HocBong
	ADD CONSTRAINT FK_IDLHB_HOCBONG FOREIGN KEY (idLHB) REFERENCES LoaiHocBong(idLHB),
		CONSTRAINT CHECK_KINHPHI  CHECK(kinhPhi > 0)
GO
--BẢNG 12---
ALTER TABLE DangKyHocBong
	ADD CONSTRAINT FK_IDSINHVIEN_DKHB FOREIGN KEY (idSinhVien) REFERENCES SinhVien(idSinhVien),
		CONSTRAINT FK_IDHOCBONG_DKHB  FOREIGN KEY (idHocBong) REFERENCES HocBong(idHocBong)
		

GO
--BẢNG 13---
ALTER TABLE DanhSachThamGiaHoatDong
	ADD CONSTRAINT FK_IDHOATDONG_DSTGHD FOREIGN KEY (idHoatDong) REFERENCES HoatDong(idHoatDong),
		CONSTRAINT FK_IDDANGKY_DSTGHD FOREIGN KEY (idDangKy) REFERENCES DangKyHocBong(idDangKy),
		CONSTRAINT FK_IDCAPDO_DSTGHD FOREIGN KEY (idCapDo) REFERENCES CapDoHoatDong(idCapDo),
		CONSTRAINT FK_IDLOAIGIAI_DSTGHD FOREIGN KEY (idLoaiGiai) REFERENCES LoaiGiai(idLoaiGiai)
GO

GO
ALTER TABLE DanhSachThamGiaHoatDong
DROP CONSTRAINT FK_IDDANGKY_DSTGHD;

GO
ALTER TABLE DanhSachThamGiaHoatDong
ADD CONSTRAINT FK_IDDANGKY_DSTGHD FOREIGN KEY (idDangKy) REFERENCES DangKyHocBong(idDangKy) 
			ON DELETE CASCADE
			ON UPDATE CASCADE;



--CHÈN DỮ LIỆU VÀO--
-- BẢNG 1--
SET DATEFORMAT dmy
INSERT INTO dbo.Khoa
        ( idKhoa, tenKhoa )
VALUES  ( '505', N'Điện - Điện Tử'),
		( '504', N'Cơ Khí'),
		( '507', N'Công Nghệ Hoá Học - Môi Trường'),
		( '506', N'Kỹ Thuật Xây Dựng'),
		( '514', N'Sư phạm công nghiệp')
GO
-- BẢNG 2--
INSERT INTO dbo.Nganh
        ( idNganh, idKhoa,TenNganh)
VALUES  ( '310', '505', N'Công Nghệ Thông Tin'),
		( '120', '505', N'CNKT Điện tử - Viễn thông'),
		( '210', '507', N'Công Nghệ Kỹ Thuật Môi Trường'),
		( '121','506', N'Công Nghệ Kỹ Thuật Xây Dựng'),
		( '410', '506', N'Công nghệ kỹ thuật cơ điện tử'),
		( '110', '504', N'Công nghệ kỹ thuật ô tô'),
		( '111', '514', N'Sư phạm')
GO
-- BẢNG 3--
INSERT INTO dbo.Lop
        ( idLop, idNganh, tenLop, nienKhoa)
VALUES  ( '18T1','310', '18T1','2018-2022'),
		( '18T2','310', '18T2','2018-2022'),
		( '18T3','310', '18T3','2018-2022'),
		( '18T4','310', '18T4','2018-2022'),
		( '18D1','120', '18D1','2018-2022'),
		( '19T1','310', '19T1','2019-2024'),
		( '19T2','310', '19T2','2019-2024'),
		( '18HTP1','210', '18HTP1','2018-2022'),
		( '19HTP1','210', '19HTP1','2019-2024'),
		( '18CDT1','410', '18CDT1','2018-2022'),
		( '18CDT2','410', '18CDT2','2018-2022'),
		( '18DL1','110', '18DL1','2018-2022'),
		( '18DL2','110', '18DL2','2018-2022'),
		( '18DL3','110', '18DL3','2018-2022'),
		( '19CDT1', '410','19CDT1','2019-2024'),
		( '19DL1', '110', '19DL1','2019-2024'),
		( '18Sk1', '111', '18Sk1','2018-2022')


GO
-- BẢNG 3--
INSERT INTO dbo.Lop
        ( idLop, idNganh, tenLop, nienKhoa)
VALUES  ( '--Chon--','310', '18T1','2018-2022')

	delete from Lop
	where idLop = '--Chọn--'
	

GO
-- BẢNG 4--
INSERT INTO dbo.HocKy
        ( idHocKy, tenHocKy, NamHoc, tgBatDau, tgKetThuc)
VALUES  ( 'HK118', N'Học kì 118', '01/01/2018', '20/08/2018','30/12/2018'),
		( 'HK218', N'Học kì 218', '01/01/2019', '01/01/2019', '30/05/2019'),
		( 'HK119', N'Học kì 119', '01/01/2019', '15/08/2019', '25/12/2019'),
		( 'HK219', N'Học kì 219', '01/01/2020','01/01/2020', '30/05/2020'),
		( 'HK120', N'Học kì 120', '01/01/2020','15/08/2020', '25/12/2020'),
		( 'HK220', N'Học kì 220','01/01/2021', '01/01/2021', '01/06/2021')



GO
-- BẢNG 5--

INSERT INTO dbo.SinhVien
        (idSinhVien, idLop, tenSinhVien, passwordSV, NgaySinh, email, soDienThoai,gioiTinh,DiaChi)
VALUES  
('1811505310101','18T1',N'Nguyễn Ngọc Anh'	,'123456','14-03-2000','1811505310101@ute.udn.vn','0344976832',DEFAULT,N'30 Hải sơn - Phú Bổn- Gia Lai'),
('1811505310104','18T1',N'Nguyễn Đình Cường','123456','21-07-2000','1811505310104@ute.udn.vn','0889189917',DEFAULT,N'Điện Bàn - Quảng Nam'),
('1811505310116','18T1',N'Nguyễn Ngọc Huy'	,'123456','17-06-2000','1811505310116@ute.udn.vn','0402763335',DEFAULT,N'27 Hoàng Diệu- Hải Châu - Đà Nẵng'),
('1811505310121','18T1',N'Bạch Trung Kiên'	,'123456','11-05-2000','1811505310121@ute.udn.vn','0402763387',DEFAULT,N'02 Thanh Long - Hải Châu - Đà Nẵng'),
('1811505310123','18T1',N'Trần Võ Lập'		,'123456','30-04-2000','1811505310123@ute.udn.vn','0334447177',DEFAULT,N'Cát Hưng - Phù Cát - Bình Định'),
('1811505310135','18T1',N'Võ Quang Nhả'		,'123456','21-07-1998','1811505310135@ute.udn.vn','0325871777',DEFAULT,N'48 Hải Hồ - Hải Châu - Đà Nẵng'),
('1811505310139','18T1',N'Trần Văn Nhật'	,'123456','01-01-2000','1811505310139@ute.udn.vn','0344979998',DEFAULT,N'77 Nguyễn Tất Thành - Hải Châu - Đà Nẵng'),
('1811505310243','18T2',N'Võ Thị Hoàng Thư'	,'123456','21-07-2000','1811505310243@ute.udn.vn','0354262219','F',N'Điện Bàn - Quảng Nam'),
('1811505310253','18T2',N'Dương Quốc Vương'	,'123456','11-06-2000','1811505310253@ute.udn.vn','0949443245',DEFAULT,N'100 Nguyễn Tất Thành - Hải Châu - Đà Nẵng'),
('1811505310221','18T2',N'Trần Minh Khoa'	,'123456','14-06-2000','1811505310221@ute.udn.vn','0949443223',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811505310351','18T3',N'Hoàng Thị Cẩm Vân','123456','11-11-2000','1811505310351@ute.udn.vn','0949443245','F',N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811505310345','18T3',N' Nguyễn Văn Trí'	,'123456','21-04-2000','1811505310345@ute.udn.vn','0949111245',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811505310455','18T4',N'Phan Diệu Mây'	,'123456','21-04-2000','1811505310455@ute.udn.vn','0344976235','F',N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
------------CNTT
('1911505310111','19T1',N'Ngô Nhật Dương'	,'123456','21-04-2001','1911505310111@ute.udn.vn','0935198553',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1911505310115','19T1',N'Phan Quốc Đạt'	,'123456','21-02-2001','1911505310115@ute.udn.vn','0901910946',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1911505310118','19T1',N'Thúy Hằng'		,'123456','21-06-2001','1911505310118@ute.udn.vn','0765700336','F',N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1911505310121','19T1',N'Minh Hiếu'		,'123456','21-08-2001','1911505310121@ute.udn.vn','0583574399',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
---------- Công nghệ kỹ thuật ô tô
('1811504210107','18DL1',N'Nguyễn Văn Cường','123456','21-05-2000','1811504210107@ute.udn.vn','0905230271',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811504210108','18DL1',N'Hoàng Danh'		,'123456','12-03-2000','1811504210108@ute.udn.vn','0905222371',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811504210112','18DL1',N'Lê Văn Hiếu'		,'123456','22-02-2000','1811504210112@ute.udn.vn','0942533471',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811504210116','18DL1',N'Phan Văn Lâm'	,'123456','21-05-2000','1811504210116@ute.udn.vn','0947221114',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811504210233','18DL2',N'Nguyễn Vũ Phúc'	,'123456','01-04-2000','1811504210233@ute.udn.vn','0947134744',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811504210204','18DL2',N'Đoàn Bá Cầu '	,'123456','21-01-2000','1811504210204@ute.udn.vn','0947131144',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811504210218','18DL2',N'Phạm Đình Hoàng'	,'123456','27-01-2000','1811504210218@ute.udn.vn','0969991945',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811504210222','18DL2',N'Trần Duy Khánh'	,'123456','26-03-2000','1811504210222@ute.udn.vn','0905551312',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1911504210132','19DL1',N'Vũ Duy Nhất'		,'123456','22-05-2001','1911504210132@ute.udn.vn','0916015701',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1911504210134','19DL1',N'Lương Văn Phú'	,'123456','13-06-2001','1911504210134@ute.udn.vn','0374244796',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1911504210135','19DL1',N'Đoàn Trí Thuần'	,'123456','12-07-2001','1911504210135@ute.udn.vn','0982253160',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1911504210137','19DL1',N'Trần Duy Nhạn'	,'123456','15-08-2001','1911504210137@ute.udn.vn','0376115303',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
-----------------Công nghệ kỹ thuật cơ điện tử 
('1811504410144','18CDT1',N'Nguyễn Hòa Phước','123456','18-01-2000','1811504410144@ute.udn.vn','0889367729',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811504410145','18CDT1',N'Đặng  Anh Quân'	,'123456','22-02-2000','1811504410145@ute.udn.vn','0703344720',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811504410146','18CDT1',N'Ngọc Quang'		,'123456','17-03-2000','1811504410146@ute.udn.vn','0399143396',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811504410227','18CDT2',N'Nguyễn Văn Khánh','123456','14-04-2000','1811504410227@ute.udn.vn','0911559312',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811504410228','18CDT2',N'Bùi Xuân Lộc '	,'123456','22-05-2000','1811504410228@ute.udn.vn','0917951027',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811504410229','18CDT2',N'Nguyễn Đắc Lộc'	,'123456','11-03-2000','1811504410229@ute.udn.vn','0889266347',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811504410230','18CDT2',N'Phạm Nhất Long ','123456','12-05-2000','1811504410230@ute.udn.vn','0902504236',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811504410232','18CDT2',N'Nguyễn Hữu Lực'	,'123456','21-07-2000','1811504410232@ute.udn.vn','0965839513',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1911504410103','19CDT1',N'Nguyễn Duy Cường','123456','11-02-2001','1911504410103@ute.udn.vn','0354810913',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1911504410104','19CDT1',N'Võ Nguyên Chinh' ,'123456','22-04-2001','1911504410104@ute.udn.vn','0911390315',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1911504410105','19CDT1',N'Trương Quang Đại','123456','25-05-2001','1911504410105@ute.udn.vn','0364014614',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1911504410106','19CDT1',N'Nguyễn Hữu Huy'	 ,'123456','12-07-2001','1911504410106@ute.udn.vn','0366990248',DEFAULT,N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
-------------------Hóa thực phẩm
('1811507310103','18HTP1',N'Đinh Đan'		,'123456','21-06-2000','1811507310103@ute.udn.vn','0961066765','F',N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811507310104','18HTP1',N'Lê Mỹ Hạnh'		,'123456','12-08-2000','1811507310104@ute.udn.vn','0378690592','F',N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811507310115','18HTP1',N'Phạm Kim Liên'  ,'123456','13-07-2000','1811507310115@ute.udn.vn','0397272807','F',N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811507310116','18HTP1',N'Đỗ Mỹ Linh'		,'123456','15-05-2000','1811507310116@ute.udn.vn','0949114145','F',N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1811507310117','18HTP1',N'Hồ Ái Linh'		,'123456','17-04-2000','1811507310117@ute.udn.vn','0388228530','F',N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1911507310122','19HTP1',N'Nguyễn Khánh Ly','123456','01-09-2001','1911507310122@ute.udn.vn','0381353934','F',N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1911507310123','19HTP1',N'Đỗ Kiều Oanh'	,'123456','03-08-2001','1911507310123@ute.udn.vn','0345192432','F',N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1911507310125','19HTP1',N'Duy Uyển Nhi'	,'123456','13-07-2001','1911507310125@ute.udn.vn','0853971817','F',N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng'),
('1911507310128','19HTP1',N'Mai Thu Ngân'	,'123456','14-06-2001','1911507310128@ute.udn.vn','0833700209','F',N'ktx 02 Thanh Sơn - Hải Châu - Đà Nẵng')
-- BẢNG 6--
GO
INSERT INTO dbo.Diem
        ( idHocKy, idSinhVien,soTinChi,diemThang4, diemThang10,xepLoai,diemRenLuyen)
VALUES 
		( 'HK219', '1811505310101','18','3.1','7.2',N'Khá','81'),
		( 'HK120', '1811505310101','21','3.2','8.2',N'Giỏi','81'),
		( 'HK219', '1811505310104','22','2.19','6.29',N'Khá','85'),
		( 'HK120', '1811505310104','14','3.29','7.94',N'Giỏi','85'),
		( 'HK120', '1811505310121','17','3.06','7.81',N'Khá','83'),
		( 'HK219', '1811505310121','18','2.89','7.36',N'Khá','81')
GO
INSERT INTO dbo.Diem
        ( idHocKy, idSinhVien,soTinChi,diemThang4, diemThang10,xepLoai,diemRenLuyen)
VALUES
		( 'HK219', '1811505310123','25','3.48','8.48',N'Giỏi','88'),
		( 'HK120', '1811505310123','17','3.53','8.52',N'Giỏi','88'),
		( 'HK219', '1811505310135','25','3.48','8.28',N'Giỏi','95'),
		( 'HK120', '1811505310135','17','3.5','7.96',N'Giỏi','95'),
		( 'HK219', '1811505310139','21','2.95','7.66',N'Khá','81'),
		( 'HK120', '1811505310139','18','3.21','7.67',N'Giỏi','83'),
		( 'HK219', '1811505310243','20','2.95','7.56',N'Khá','90'),
		( 'HK120', '1811505310243','18','3.5','8.27',N'Giỏi','90')
GO
INSERT INTO dbo.Diem
        ( idHocKy, idSinhVien,soTinChi,diemThang4, diemThang10,xepLoai,diemRenLuyen)
VALUES
		( 'HK219', '1811505310253','21','3.1','8.0',N'Khá','82'),
		( 'HK120', '1811505310253','15','3.4','8.46',N'Giỏi','83'),
		( 'HK219', '1811505310221','23','3.39','8.17',N'Giỏi','87'),
		( 'HK120', '1811505310221','15','3.33','7.55',N'Giỏi','87'),
		( 'HK219', '1811505310351','25','3.44','8.24',N'Giỏi','85'),
		( 'HK120', '1811505310351','14','3.21','7.99',N'Giỏi','85'),
		( 'HK219', '1811505310345','19','3.37','8.26',N'Giỏi','85'),
		( 'HK120', '1811505310345','18','3.67','8.54',N'Xuất Sắc','85'),
		( 'HK219', '1811505310455','18','3.2','7.5',N'Giỏi','100'),
		( 'HK120', '1811505310455','18','3.3','7.9',N'Giỏi','100')

GO
INSERT INTO dbo.Diem
        ( idHocKy, idSinhVien,soTinChi,diemThang4, diemThang10,xepLoai,diemRenLuyen)
VALUES
		( 'HK219', '1911505310111','25','3.48','8.28',N'Giỏi','95'),
		( 'HK120', '1911505310111','17','3.5','7.91',N'Giỏi','95'),
		( 'HK219', '1911505310115','21','2.95','7.66',N'Khá','81'),
		( 'HK120', '1911505310115','18','3.11','7.27',N'Khá','83'),
		( 'HK219', '1911505310118','20','2.95','7.36',N'Khá','90'),
		( 'HK120', '1911505310118','17','3.3','7.86',N'Giỏi','95'),
		( 'HK219', '1911505310121','21','3.1','7.2',N'Khá','82')

GO
INSERT INTO dbo.Diem
        ( idHocKy, idSinhVien,soTinChi,diemThang4, diemThang10,xepLoai,diemRenLuyen)
VALUES
		( 'HK219', '1811504210107','18','3.1','7.21',N'Khá','81'),
		( 'HK120', '1811504210107','22','3.2','8.22',N'Giỏi','81'),
		( 'HK219', '1811504210108','21','2.19','6.29',N'Khá','85'),
		( 'HK120', '1811504210108','15','3.29','7.94',N'Giỏi','85'),
		( 'HK219', '1811504210112','23','3.2','7.95',N'Giỏi','87'),
		( 'HK120', '1811504210112','16','3.06','7.81',N'Khá','83'),
		( 'HK219', '1811504210116','18','2.89','7.36',N'Khá','81'),
		( 'HK120', '1811504210116','23','3.29','6.72',N'Khá','84'),
		( 'HK219', '1811504210233','18','2.89','7.36',N'Khá','85'),
		( 'HK120', '1811504210233','21','3.29','6.71',N'Khá','85')

GO
INSERT INTO dbo.Diem
        ( idHocKy, idSinhVien,soTinChi,diemThang4, diemThang10,xepLoai,diemRenLuyen)
VALUES
		( 'HK219', '1811504210204','21','3.48','8.41',N'Giỏi','88'),
		( 'HK120', '1811504210204','15','3.53','8.52',N'Giỏi','88'),
		( 'HK219', '1811504210218','27','3.48','8.58',N'Giỏi','95'),
		( 'HK120', '1811504210218','17','3.5','7.96',N'Giỏi','95'),
		( 'HK219', '1811504210222','21','2.95','7.62',N'Khá','81'),
		( 'HK120', '1811504210222','18','3.21','7.67',N'Giỏi','83'),
		( 'HK219', '1911504210132','20','2.95','7.55',N'Khá','90'),
		( 'HK120', '1911504210132','18','3.5','8.67',N'Giỏi','90'),
		( 'HK219', '1911504210134','21','3.1','8.25',N'Khá','82'),
		( 'HK120', '1911504210134','15','3.4','8.49',N'Giỏi','83'),
		( 'HK219', '1911504210135','23','3.39','8.17',N'Giỏi','87'),
		( 'HK120', '1911504210135','15','3.33','7.51',N'Giỏi','87'),
		( 'HK219', '1911504210137','25','3.44','8.28',N'Giỏi','85'),
		( 'HK120', '1911504210137','14','3.21','7.99',N'Giỏi','85')

GO
INSERT INTO dbo.Diem
        ( idHocKy, idSinhVien,soTinChi,diemThang4, diemThang10,xepLoai,diemRenLuyen)
VALUES
		( 'HK219', '1811504410144','17','3.21','7.21',N'Giỏi','81'),
		( 'HK120', '1811504410144','26','3.32','8.32',N'Giỏi','81'),
		( 'HK219', '1811504410145','23','2.29','6.29',N'Khá','85'),
		( 'HK120', '1811504410145','16','3.39','7.94',N'Giỏi','85'),
		( 'HK219', '1811504410146','27','3.23','7.95',N'Giỏi','87'),
		( 'HK120', '1811504410146','17','3.16','7.81',N'Khá','83'),
		( 'HK219', '1811504410227','18','2.81','7.36',N'Khá','93'),
		( 'HK120', '1811504410227','23','3.43','8.72',N'Giỏi','79'),
		( 'HK219', '1811504410228','14','2.89','7.36',N'Khá','77'),
		( 'HK120', '1811504410228','21','3.12','7.71',N'Khá','81'),
		( 'HK219', '1811504410229','25','3.48','8.41',N'Giỏi','88'),
		( 'HK120', '1811504410229','17','3.0','6.62',N'Khá','87'),
		( 'HK219', '1811504410230','22','3.48','8.48',N'Giỏi','95'),
		( 'HK120', '1811504410230','15','3.5','7.96',N'Giỏi','94')

GO
INSERT INTO dbo.Diem
        ( idHocKy, idSinhVien,soTinChi,diemThang4, diemThang10,xepLoai,diemRenLuyen)
VALUES
		( 'HK219', '1811504410232','22','2.95','7.62',N'Khá','81'),
		( 'HK120', '1811504410232','18','3.21','7.67',N'Giỏi','85'),
		( 'HK219', '1911504410103','26','2.95','7.55',N'Khá','91'),
		( 'HK120', '1911504410103','18','3.5','8.47',N'Giỏi','87'),
		( 'HK219', '1911504410104','27','3.31','8.45',N'Khá','82'),
		( 'HK120', '1911504410104','15','3.13','7.49',N'Khá','85'),
		( 'HK219', '1911504410105','21','3.39','8.57',N'Giỏi','87'),
		( 'HK120', '1911504410105','19','3.13','7.21',N'Khá','82'),
		( 'HK219', '1911504410106','25','3.44','8.28',N'Giỏi','85'),
		( 'HK120', '1911504410106','14','3.21','7.99',N'Giỏi','81'),

		( 'HK219', '1811507310103','20','3.21','7.71',N'Giỏi','89'),
		( 'HK120', '1811507310103','21','3.32','8.32',N'Giỏi','87'),
		( 'HK219', '1811507310104','23','2.29','6.29',N'Khá','85'),
		( 'HK120', '1811507310115','16','3.19','7.94',N'Giỏi','83'),
		( 'HK219', '1811507310115','27','3.23','7.95',N'Giỏi','82')

GO
INSERT INTO dbo.Diem
        ( idHocKy, idSinhVien,soTinChi,diemThang4, diemThang10,xepLoai,diemRenLuyen)
VALUES
		
		( 'HK219', '1811507310116','18','2.81','7.36',N'Khá','96'),
		( 'HK120', '1811507310116','23','3.43','8.72',N'Giỏi','78'),
		( 'HK219', '1811507310117','14','2.89','7.36',N'Khá','71'),
		( 'HK120', '1811507310117','21','3.19','7.71',N'Khá','83'),
		( 'HK219', '1911507310122','25','3.48','8.41',N'Giỏi','85'),
		( 'HK120', '1911507310122','17','3.53','8.62',N'Giỏi','87'),
		( 'HK219', '1911507310123','22','3.18','8.48',N'Khá','95'),
		( 'HK120', '1911507310123','15','3.5','7.96',N'Giỏi','94'),
		( 'HK219', '1911507310125','22','2.95','7.62',N'Khá','84'),
		( 'HK120', '1911507310125','18','3.21','7.67',N'Giỏi','82'),
		( 'HK219', '1911507310128','26','2.95','7.55',N'Khá','96'),
		( 'HK120', '1911507310128','18','2.7','6.47',N'Khá','88')

-- BẢNG 7--
INSERT INTO dbo.CapDoHoatDong
        ( idCapDo, tenCapDo,heSo )
VALUES  ( 'CD01', N'Cấp Khoa',1),
		( 'CD02', N'Cấp Trường',5),
		( 'CD03', N'Cấp Đại học Đà Nẵng',9),
		( 'CD04', N'Cấp Tỉnh - Thành Phố',13),
		( 'CD05', N'Cấp Quốc gia',17),
		( 'CD06', N'Cấp Quốc tế',21)
GO
-- BẢNG 8--
INSERT INTO dbo.LoaiGiai
        ( idLoaiGiai,tenGiai,diemThanhTich )
VALUES  ( 'TT01',N'Giải Nhất',4),
		( 'TT02',N'Giải Nhì',3),
		( 'TT03',N'Giải Ba',2),
		( 'TT04',N'Giải Khuyến khích',1)
GO

-- BẢNG 9--
INSERT INTO dbo.HoatDong
        ( idHoatDong,tenHoatDong,ngayBatDau,ngayKetThuc,ghiChu)
VALUES  ( 'HD01',N'Nghiên cứu khoa học Trường ĐH Sư Phạm Kỹ Thuật', '01-04-2019','14-04-2019',N''),
		( 'HD02',N'Đại hội thể thao ĐHĐN', '01-04-2019','14-04-2019',N'')
GO

-- BẢNG 10--
INSERT INTO dbo.LoaiHocBong
        ( idLHB, tenLHB )
VALUES  ( 'LHB01', N'Học bổng khuyến khích học tập'),
		( 'LHB02', N'Học bổng thử thách UTE'),
		( 'LHB03', N'Học bổng doanh nghiệp')	
GO
-- BẢNG 11--


INSERT INTO dbo.HocBong
        ( idHocBong, idLHB, tenHB,noiDungHB, doiTuongApDung,nhaTaiTro,ngayBatDau,ngayKetThuc,kinhPhi,soLuong,soLuongDaDK,ngayDuKienPhatHB)
VALUES 
		( '22002001', 'LHB02', N'Học bổng thử thách UTE', N'Khen thưởng những sinh viên có thành tích học tập tốt',N'Sinh viên có thành tích tham gia NCKH','Trường SPKT','10-02-2021', '25-02-2021','100000000',20,1, '25-03-2021'),
		( '22003001', 'LHB03', N'Học bổng tiếp sức đến trường', N'Học bổng tiếp sức đến trường học kỳ 220 năm học 2020 - 2021',N' Sinh viên theo học tại trường','Công Ty Miền Trung','10-02-2021', '25-02-2021','50000000',20,1, '25-03-2021'),
		( '22003002', 'LHB03', N'Học bổng hỗ trợ dịch covid',  N'Học bổng hỗ trợ dịch covid học kỳ 119 năm học 2019 - 2020',N' Sinh viên theo học tại trường','Công Ty Miền Trung','1-12-2021', '12-12-2021','100000000',20,1, '25-1-2021'),
		( '22003003', 'LHB03',N'Học bổng xuân sẻ chia', N'Học bổng xuân sẻ chia học kỳ 219 năm học 2019 - 2020',N' Sinh viên theo học tại trường','Công Ty Miền Trung', '20-12-2020','01-01-2021','100000000',20,1, '20-01-2021')	
GO

--22002001 : 220: học kỳ, 02: loại học bổng, 001: số thứ tự học bổng 

-- BẢNG 12--
INSERT INTO dbo.DangKyHocBong
        ( idDangKy, idSinhVien, idHocBong, tgDangKy, tinhTrang)
VALUES 
		( '000001', '1811505310101','22002001', GETDATE(), N'Đã duyệt'),
		( '000002', '1811505310121','22003001', GETDATE(), N'Đã duyệt'),
		( '000003', '1811505310253','22003002', GETDATE(), N'Đã duyệt'),
		( '000004', '1811505310123','22003003', GETDATE(), N'Đã duyệt')
GO
DELETE from DangKyHocBong
GO
--BẢNG 13---
INSERT INTO dbo.DanhSachThamGiaHoatDong
        ( idDangKy,idHoatDong, idCapDo,idLoaiGiai,minhChung,diemHoatDong )
VALUES  ( 'DKHB01', 'HD01 ','CD01 ','TT01','https://images.app.goo.gl/C8uuYjnrWkNDF1sJA','9'),
		( 'DKHB01', 'HD02 ','CD03 ','TT01','https://images.app.goo.gl/C8uuYjnrWkNDF1sJA','13'),
		( 'DKHB02', 'HD01 ','CD01 ','TT02','https://images.app.goo.gl/C8uuYjnrWkNDF1sJA','8'),
		( 'DKHB02', 'HD02 ','CD03 ','TT02','https://images.app.goo.gl/C8uuYjnrWkNDF1sJA','12')


