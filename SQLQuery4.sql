﻿--Xóa thông tin theo mẹ, ví dụ khi xóa nhân viên ở bảng nhân viên thì nhân viên đó ở các bảng con liên kết cũng mất
ALTER TABLE TKTHUCHI
ADD CONSTRAINT XOA_TKTC
FOREIGN KEY (MANV)
REFERENCES NHANVIEN(MANV)
ON DELETE CASCADE;

-- Bảng thống kê nhập xuất
ALTER TABLE TKNHAPXUAT
ADD CONSTRAINT XOA_TKNX1
FOREIGN KEY (MANV)
REFERENCES NHANVIEN(MANV)
ON DELETE CASCADE;

-- tính tiền lương nhân viên ok
CREATE PROC THUCLINH
AS
    UPDATE NHANVIEN 
	SET THUCLINH = LUONG1NGAY * SONGAYCONG
GO
---
EXEC THUCLINH

SELECT *
FROM NHANVIEN ; 

--HÓA ĐƠN thanhtien= soluong *giaban ok
CREATE PROC THANHTIEN 
AS
    UPDATE HOADON 
	SET THANHTIEN = SOLUONG * DONGIA
GO

-- HÓA ĐƠN , cập nhật tên nhân viên tự động vào hóa đơn ok
CREATE PROC CapNhatTenNVVaoHoaDon
AS
    UPDATE HOADON
	SET HOADON.TENNV = NHANVIEN.TENNV
	FROM HOADON
	INNER JOIN NHANVIEN
	ON (HOADON.MANV = NHANVIEN.MANV)
GO

-- HÓA ĐƠN cập nhật tên sản phẩm tự động vào hóa đơn ok
CREATE PROC CapNhatTenSPVaoHoaDon1
AS
    UPDATE HOADON
	SET HOADON.TENSP = SANPHAM.TENSP
	FROM HOADON
	INNER JOIN SANPHAM
	ON (HOADON.MASP = SANPHAM.MASP)
GO

-- NHÂP XUẤT cập nhật tên nv vào thống kê nhập xuất ok
CREATE PROC CapNhatTenNVVaoTKNXUAT1
AS
    UPDATE TKNHAPXUAT
	SET TKNHAPXUAT.TENNV = NHANVIEN.TENNV
	FROM TKNHAPXUAT
	INNER JOIN NHANVIEN
	ON (TKNHAPXUAT.MANV = NHANVIEN. MANV)
GO

--NHẬP XUÂT -  giá nhập ok
CREATE PROC CapNhatGIANNHAP
AS
    UPDATE TKNHAPXUAT
	SET TKNHAPXUAT.GIANHAP = SANPHAM.GIANHAP
	FROM TKNHAPXUAT
	INNER JOIN SANPHAM
	ON (TKNHAPXUAT.MASP = SANPHAM.MASP)
GO

***-- NHẬP XUẤT - giá xuất - bán 
CREATE PROC CapNhatGIABAN
AS
    UPDATE TKNHAPXUAT
	SET TKNHAPXUAT.GIABAN = SANPHAM.GIABAN
	FROM TKNHAPXUAT
	INNER JOIN SANPHAM
	ON (TKNHAPXUAT.MASP = SANPHAM.MASP)
GO



-- NHÂP XUẤT cập nhật tên SP vào thống kê nhập xuất ok

CREATE PROC CapNhatTenSPVaoTKNXUAT
AS
    UPDATE TKNHAPXUAT
	SET TKNHAPXUAT.TENSP = SANPHAM.TENSP
	FROM TKNHAPXUAT
	INNER JOIN SANPHAM
	ON (TKNHAPXUAT.MASP = SANPHAM.MASP)
GO

----THUCHI cập nhật tên nv vào thống kê thu chi ok
CREATE PROC CapNhatTenNVVaoTKTHUCHI
AS
    UPDATE TKTHUCHI
	SET TKTHUCHI.TENNV = NHANVIEN.TENNV
	FROM TKTHUCHI
	INNER JOIN NHANVIEN
	ON (TKTHUCHI.MANV = NHANVIEN.MANV)
GO

-- SANPHAM số tồn kho 
CREATE PROC Cap_Nhat_Hang_Ton_Kho
AS
    UPDATE SANPHAM 
	SET SOTONKHO = (SELECT SOTONKHO - SUM(SOLUONG)
		            FROM HOADON
					WHERE HOADON.MASP = SANPHAM.MASP)
	WHERE MASP = MASP;
GO


-- HÓA ĐƠN lấy đơn giá từ giá bán của SAN PHAM sang 
CREATE PROC CapnhatDONGIA
AS
    UPDATE HOADON 
	SET HOADON.DONGIA = SANPHAM.GIABAN
	FROM HOADON
	INNER JOIN SANPHAM
	ON (HOADON.MASP = SANPHAM.MASP)
GO
