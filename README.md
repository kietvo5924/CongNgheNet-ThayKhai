# Car Rental Management System
# Car Rental Management System

Ứng dụng quản lý cho thuê xe viết bằng `C# WinForms` theo mô hình nhiều lớp:

- `CarRental` (UI WinForms)
- `CarRental_Business` (Business Logic)
- `CarRental_DataAccess` (ADO.NET / SQL Server)

## Tính năng chính

- Quản lý xe, khách hàng, người dùng.
- Tạo lịch đặt xe, theo dõi giao dịch, trả xe.
- Theo dõi bảo trì xe.
- Dashboard thống kê nhanh.
- Tối ưu tải dữ liệu với bất đồng bộ và cache cho danh sách chính.

## Cấu trúc thư mục

- `CarRental/` - ứng dụng WinForms chính.
- `CarRental_Business/` - lớp nghiệp vụ.
- `CarRental_DataAccess/` - truy cập dữ liệu SQL Server.
- `Database/` - script database.

## Yêu cầu môi trường

- Visual Studio 2022 (khuyến nghị).
- .NET Framework `4.8`.
- SQL Server (local hoặc cloud).

## Hướng dẫn chạy dự án

1. Khởi tạo database bằng script trong thư mục `Database/`.
2. Cấu hình chuỗi kết nối SQL Server tại:
   - `CarRental_DataAccess/clsDataAccessSettings.cs`
3. Mở solution:
   - `CarRental/CarRental.sln`
4. Restore NuGet packages (nếu Visual Studio yêu cầu).
5. Build solution với cấu hình `Debug` hoặc `Release`.
6. Chạy project `CarRental`.

## Ghi chú kỹ thuật

- Dự án dùng `ADO.NET` (không dùng EF).
- Luồng dữ liệu theo hướng: `UI -> Business -> DataAccess`.
- Một số màn hình tải dữ liệu lớn đã được xử lý bất đồng bộ để tránh đơ UI.

## Đóng góp

Bạn có thể mở `Issue` hoặc tạo `Pull Request` để đóng góp cải tiến.
