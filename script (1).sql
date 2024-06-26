USE [master]
GO
/****** Object:  Database [QUANLYNHANVIENKHACHSAN]    Script Date: 13-Jun-24 7:25:10 PM ******/
CREATE DATABASE [QUANLYNHANVIENKHACHSAN]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QUANLYNHANVIENKHACHSAN', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MYSQL\MSSQL\DATA\QUANLYNHANVIENKHACHSAN.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QUANLYNHANVIENKHACHSAN_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MYSQL\MSSQL\DATA\QUANLYNHANVIENKHACHSAN_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QUANLYNHANVIENKHACHSAN].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET ARITHABORT OFF 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET RECOVERY FULL 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET  MULTI_USER 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QUANLYNHANVIENKHACHSAN', N'ON'
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET QUERY_STORE = ON
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QUANLYNHANVIENKHACHSAN]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 13-Jun-24 7:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[igrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[igrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chucvu]    Script Date: 13-Jun-24 7:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chucvu](
	[Ma ChucVu] [nvarchar](10) NOT NULL,
	[Chuc Vu] [nvarchar](50) NULL,
 CONSTRAINT [PK_Luong] PRIMARY KEY CLUSTERED 
(
	[Ma ChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Congviec]    Script Date: 13-Jun-24 7:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Congviec](
	[Ma CongViec] [int] IDENTITY(1,1) NOT NULL,
	[Chi Tiet Cong Viec] [nchar](50) NULL,
	[Ca Lam] [nvarchar](50) NULL,
 CONSTRAINT [PK_Congviec_1] PRIMARY KEY CLUSTERED 
(
	[Ma CongViec] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CongviecNV]    Script Date: 13-Jun-24 7:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongviecNV](
	[Ma CongViecNV] [int] IDENTITY(1,1) NOT NULL,
	[Ma CongViec] [int] NOT NULL,
	[Ma NV] [nvarchar](10) NULL,
	[Ngay Lam] [datetime] NULL,
 CONSTRAINT [PK_CongviecNV_1] PRIMARY KEY CLUSTERED 
(
	[Ma CongViecNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Luong]    Script Date: 13-Jun-24 7:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Luong](
	[Ma Luong] [int] IDENTITY(1,1) NOT NULL,
	[Ten Ma Luong] [nvarchar](50) NULL,
	[Luong Co Ban] [decimal](12, 0) NULL,
	[Phu Cap] [decimal](12, 0) NULL,
 CONSTRAINT [PK_Luong_1] PRIMARY KEY CLUSTERED 
(
	[Ma Luong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LuongNV]    Script Date: 13-Jun-24 7:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LuongNV](
	[Ma LuongNV] [int] IDENTITY(1,1) NOT NULL,
	[Ma Luong] [int] NULL,
	[Ma NV] [nvarchar](10) NULL,
	[Thang] [datetime] NULL,
	[Ngay cong] [int] NULL,
	[Thuong] [decimal](10, 0) NULL,
	[Phat] [decimal](10, 0) NULL,
	[Luong Tong] [decimal](12, 0) NULL,
 CONSTRAINT [PK_LuongNV] PRIMARY KEY CLUSTERED 
(
	[Ma LuongNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nhanvien]    Script Date: 13-Jun-24 7:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhanvien](
	[Ma NV] [nvarchar](10) NOT NULL,
	[Ten Nhan Vien] [nvarchar](50) NULL,
	[Ngay Sinh] [datetime] NULL,
	[Gioi Tinh] [nvarchar](50) NULL,
	[Dia chi] [nvarchar](50) NULL,
	[So Dien Thoai] [nchar](10) NULL,
	[Email] [nvarchar](50) NULL,
	[CCCD] [nchar](12) NULL,
	[Ma BaoHiem] [nchar](12) NULL,
	[Tai Khoan Ngan Hang] [nchar](10) NULL,
	[Ten Ngan Hang] [nvarchar](50) NULL,
	[Ma PhongBan] [nvarchar](10) NULL,
	[Password] [nvarchar](50) NULL,
	[Ma PhanQuyen] [nvarchar](10) NULL,
	[Ma ChucVu] [nvarchar](10) NULL,
	[Trinh do] [nvarchar](max) NULL,
	[Kinh nghiem] [nvarchar](max) NULL,
	[Trang Thai] [bit] NULL,
 CONSTRAINT [PK_Nhanvien] PRIMARY KEY CLUSTERED 
(
	[Ma NV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phanquyen]    Script Date: 13-Jun-24 7:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phanquyen](
	[Ma PhanQuyen] [nvarchar](10) NOT NULL,
	[Phan Quyen] [nvarchar](50) NULL,
 CONSTRAINT [PK_Phanquyen] PRIMARY KEY CLUSTERED 
(
	[Ma PhanQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phongban]    Script Date: 13-Jun-24 7:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phongban](
	[Ma PhongBan] [nvarchar](10) NOT NULL,
	[Ten PhongBan] [nvarchar](50) NULL,
	[Ma TruongPhong] [nvarchar](50) NULL,
 CONSTRAINT [PK_Phongban] PRIMARY KEY CLUSTERED 
(
	[Ma PhongBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Chucvu] ([Ma ChucVu], [Chuc Vu]) VALUES (N'NV1', N'Nhân viên lễ tân')
INSERT [dbo].[Chucvu] ([Ma ChucVu], [Chuc Vu]) VALUES (N'NV2', N'Nhân viên hành lý')
INSERT [dbo].[Chucvu] ([Ma ChucVu], [Chuc Vu]) VALUES (N'NV3', N'Nhân viên buồng phòng')
INSERT [dbo].[Chucvu] ([Ma ChucVu], [Chuc Vu]) VALUES (N'NV4', N'Nhân viên bảo trì')
INSERT [dbo].[Chucvu] ([Ma ChucVu], [Chuc Vu]) VALUES (N'NV5', N'Bếp trưởng')
INSERT [dbo].[Chucvu] ([Ma ChucVu], [Chuc Vu]) VALUES (N'NV6', N'Nhân viên phục vụ')
INSERT [dbo].[Chucvu] ([Ma ChucVu], [Chuc Vu]) VALUES (N'QL1', N'Quản lý tiền sảnh')
INSERT [dbo].[Chucvu] ([Ma ChucVu], [Chuc Vu]) VALUES (N'QL2', N'Quản lý buồng phòng')
INSERT [dbo].[Chucvu] ([Ma ChucVu], [Chuc Vu]) VALUES (N'QL3', N'Quản lý kỹ thuật')
INSERT [dbo].[Chucvu] ([Ma ChucVu], [Chuc Vu]) VALUES (N'QL4', N'Quản lý nhà hàng')
GO
SET IDENTITY_INSERT [dbo].[Congviec] ON 

INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (30, N'Dọn dẹp buồng phòng                               ', N'8h-16h')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (31, N'Dọn dẹp buồng phòng                               ', N'16h30-23h30')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (32, N'Kiểm tra vệ sinh buồng phòng                      ', N'9h-22h')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (33, N'Thay đồ dùng các buồng phòng                      ', N'9h-22h')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (34, N'Quản lý quầy bar                                  ', N'17h-23h30')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (35, N'Giám sát chất lượng món ăn                        ', N'8h-23h')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (36, N'Lên thực đơn và nấu nướng                         ', N'7h-22h')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (37, N'Check in - Check out                              ', N'8h-16h')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (38, N'Check in - Check out                              ', N'16h30-23h30')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (39, N'Tư vấn - giải quyết khiếu nại                     ', N'9h-22h')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (40, N'Vận chuyển hành lý                                ', N'8h-16h')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (41, N'Vận chuyển hành lý                                ', N'16h30-23h30')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (42, N'Ghi nhận đặt món và phục vụ thức ăn               ', N'8h-22h')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (43, N'Giám sát công việc bảo trì                        ', N'9h-22h')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (44, N'Bảo trì sửa chữa thiết bị                         ', N'8h-16h')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (45, N'Bảo trì sửa chữa thiết bị                         ', N'16h30-23h30')
SET IDENTITY_INSERT [dbo].[Congviec] OFF
GO
SET IDENTITY_INSERT [dbo].[CongviecNV] ON 

INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (10, 42, N'NV101', CAST(N'2024-06-01T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (11, 42, N'NV104', CAST(N'2024-06-01T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (13, 31, N'NV102', CAST(N'2024-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (15, 30, N'NV106', CAST(N'2024-06-14T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (16, 37, N'NV101', CAST(N'2024-06-12T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (17, 38, N'NV105', CAST(N'2024-06-14T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (18, 37, N'NV101', CAST(N'2024-06-14T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (19, 40, N'NV102', CAST(N'2024-06-13T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (20, 40, N'NV110', CAST(N'2024-06-13T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (21, 42, N'NV108', CAST(N'2024-06-13T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (22, 37, N'NV101', CAST(N'2024-06-15T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (23, 37, N'NV109', CAST(N'2024-06-15T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (24, 38, N'NV101', CAST(N'2024-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (25, 38, N'NV105', CAST(N'2024-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (26, 38, N'NV109', CAST(N'2024-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (27, 39, N'NV101', CAST(N'2024-06-17T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (28, 39, N'NV105', CAST(N'2024-06-17T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (29, 33, N'NV104', CAST(N'2024-06-18T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (30, 39, N'NV101', CAST(N'2024-06-19T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (31, 37, N'NV101', CAST(N'2024-06-18T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (32, 38, N'NV101', CAST(N'2024-06-20T00:00:00.000' AS DateTime))
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam]) VALUES (33, 38, N'NV101', CAST(N'2024-06-21T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[CongviecNV] OFF
GO
SET IDENTITY_INSERT [dbo].[Luong] ON 

INSERT [dbo].[Luong] ([Ma Luong], [Ten Ma Luong], [Luong Co Ban], [Phu Cap]) VALUES (13, N'Nhân viên tiền sảnh', CAST(120000 AS Decimal(12, 0)), CAST(200000 AS Decimal(12, 0)))
INSERT [dbo].[Luong] ([Ma Luong], [Ten Ma Luong], [Luong Co Ban], [Phu Cap]) VALUES (14, N'Quản lý tiền sảnh', CAST(200000 AS Decimal(12, 0)), CAST(250000 AS Decimal(12, 0)))
INSERT [dbo].[Luong] ([Ma Luong], [Ten Ma Luong], [Luong Co Ban], [Phu Cap]) VALUES (15, N'Phục vụ', CAST(100000 AS Decimal(12, 0)), CAST(150000 AS Decimal(12, 0)))
INSERT [dbo].[Luong] ([Ma Luong], [Ten Ma Luong], [Luong Co Ban], [Phu Cap]) VALUES (16, N'Nhân viên buồng phòng', CAST(130000 AS Decimal(12, 0)), CAST(150000 AS Decimal(12, 0)))
INSERT [dbo].[Luong] ([Ma Luong], [Ten Ma Luong], [Luong Co Ban], [Phu Cap]) VALUES (17, N'Quản lý buồng phòng', CAST(210000 AS Decimal(12, 0)), CAST(200000 AS Decimal(12, 0)))
INSERT [dbo].[Luong] ([Ma Luong], [Ten Ma Luong], [Luong Co Ban], [Phu Cap]) VALUES (18, N'Nhà hàng', CAST(230000 AS Decimal(12, 0)), CAST(100000 AS Decimal(12, 0)))
INSERT [dbo].[Luong] ([Ma Luong], [Ten Ma Luong], [Luong Co Ban], [Phu Cap]) VALUES (19, N'Bảo trì', CAST(250000 AS Decimal(12, 0)), CAST(200000 AS Decimal(12, 0)))
INSERT [dbo].[Luong] ([Ma Luong], [Ten Ma Luong], [Luong Co Ban], [Phu Cap]) VALUES (20, N'Giám sát bảo trì', CAST(280000 AS Decimal(12, 0)), CAST(150000 AS Decimal(12, 0)))
SET IDENTITY_INSERT [dbo].[Luong] OFF
GO
SET IDENTITY_INSERT [dbo].[LuongNV] ON 

INSERT [dbo].[LuongNV] ([Ma LuongNV], [Ma Luong], [Ma NV], [Thang], [Ngay cong], [Thuong], [Phat], [Luong Tong]) VALUES (34, 14, N'NV101', CAST(N'2024-06-01T00:00:00.000' AS DateTime), 28, CAST(0 AS Decimal(10, 0)), CAST(0 AS Decimal(10, 0)), CAST(5850000 AS Decimal(12, 0)))
INSERT [dbo].[LuongNV] ([Ma LuongNV], [Ma Luong], [Ma NV], [Thang], [Ngay cong], [Thuong], [Phat], [Luong Tong]) VALUES (35, 15, N'NV102', CAST(N'2024-06-01T00:00:00.000' AS DateTime), 30, CAST(0 AS Decimal(10, 0)), CAST(0 AS Decimal(10, 0)), CAST(3150000 AS Decimal(12, 0)))
INSERT [dbo].[LuongNV] ([Ma LuongNV], [Ma Luong], [Ma NV], [Thang], [Ngay cong], [Thuong], [Phat], [Luong Tong]) VALUES (36, 15, N'NV103', CAST(N'2024-06-01T00:00:00.000' AS DateTime), 30, CAST(0 AS Decimal(10, 0)), CAST(0 AS Decimal(10, 0)), CAST(3150000 AS Decimal(12, 0)))
INSERT [dbo].[LuongNV] ([Ma LuongNV], [Ma Luong], [Ma NV], [Thang], [Ngay cong], [Thuong], [Phat], [Luong Tong]) VALUES (37, 13, N'NV101', CAST(N'2024-05-01T00:00:00.000' AS DateTime), 28, CAST(0 AS Decimal(10, 0)), CAST(0 AS Decimal(10, 0)), CAST(3560000 AS Decimal(12, 0)))
INSERT [dbo].[LuongNV] ([Ma LuongNV], [Ma Luong], [Ma NV], [Thang], [Ngay cong], [Thuong], [Phat], [Luong Tong]) VALUES (38, 13, N'NV102', CAST(N'2024-05-01T00:00:00.000' AS DateTime), 29, CAST(0 AS Decimal(10, 0)), CAST(0 AS Decimal(10, 0)), CAST(3680000 AS Decimal(12, 0)))
INSERT [dbo].[LuongNV] ([Ma LuongNV], [Ma Luong], [Ma NV], [Thang], [Ngay cong], [Thuong], [Phat], [Luong Tong]) VALUES (39, 19, N'NV103', CAST(N'2024-05-01T00:00:00.000' AS DateTime), 30, CAST(0 AS Decimal(10, 0)), CAST(0 AS Decimal(10, 0)), CAST(7700000 AS Decimal(12, 0)))
INSERT [dbo].[LuongNV] ([Ma LuongNV], [Ma Luong], [Ma NV], [Thang], [Ngay cong], [Thuong], [Phat], [Luong Tong]) VALUES (40, 16, N'NV104', CAST(N'2024-05-01T00:00:00.000' AS DateTime), 30, CAST(0 AS Decimal(10, 0)), CAST(0 AS Decimal(10, 0)), CAST(4050000 AS Decimal(12, 0)))
INSERT [dbo].[LuongNV] ([Ma LuongNV], [Ma Luong], [Ma NV], [Thang], [Ngay cong], [Thuong], [Phat], [Luong Tong]) VALUES (41, 14, N'NV105', CAST(N'2024-05-01T00:00:00.000' AS DateTime), 28, CAST(0 AS Decimal(10, 0)), CAST(0 AS Decimal(10, 0)), CAST(5850000 AS Decimal(12, 0)))
INSERT [dbo].[LuongNV] ([Ma LuongNV], [Ma Luong], [Ma NV], [Thang], [Ngay cong], [Thuong], [Phat], [Luong Tong]) VALUES (42, 16, N'NV104', CAST(N'2024-06-01T00:00:00.000' AS DateTime), 29, CAST(100000 AS Decimal(10, 0)), CAST(0 AS Decimal(10, 0)), CAST(4020000 AS Decimal(12, 0)))
INSERT [dbo].[LuongNV] ([Ma LuongNV], [Ma Luong], [Ma NV], [Thang], [Ngay cong], [Thuong], [Phat], [Luong Tong]) VALUES (43, 14, N'NV105', CAST(N'2024-06-01T00:00:00.000' AS DateTime), 30, CAST(100000 AS Decimal(10, 0)), CAST(0 AS Decimal(10, 0)), CAST(6350000 AS Decimal(12, 0)))
SET IDENTITY_INSERT [dbo].[LuongNV] OFF
GO
INSERT [dbo].[Nhanvien] ([Ma NV], [Ten Nhan Vien], [Ngay Sinh], [Gioi Tinh], [Dia chi], [So Dien Thoai], [Email], [CCCD], [Ma BaoHiem], [Tai Khoan Ngan Hang], [Ten Ngan Hang], [Ma PhongBan], [Password], [Ma PhanQuyen], [Ma ChucVu], [Trinh do], [Kinh nghiem], [Trang Thai]) VALUES (N'KT101', N'Viet', CAST(N'2004-09-26T00:00:00.000' AS DateTime), N'Nam', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'ketoan', N'102', NULL, NULL, NULL, 1)
INSERT [dbo].[Nhanvien] ([Ma NV], [Ten Nhan Vien], [Ngay Sinh], [Gioi Tinh], [Dia chi], [So Dien Thoai], [Email], [CCCD], [Ma BaoHiem], [Tai Khoan Ngan Hang], [Ten Ngan Hang], [Ma PhongBan], [Password], [Ma PhanQuyen], [Ma ChucVu], [Trinh do], [Kinh nghiem], [Trang Thai]) VALUES (N'NV101', N'Phan Thanh Việt', CAST(N'2004-09-26T00:00:00.000' AS DateTime), N'Nam', N'Tam Dân-Phú Ninh-Quảng Nam', N'0329963894', N'thanhvietphan269@gmail.com	', N'049204006435', N'AB1234567890', N'1234567890', N'Ngân hàng MB', N'PB1', N'101', N'103', N'NV1', N'Cao đẳng', N'Từng thực tập tại khách sạn Mường Thanh', 1)
INSERT [dbo].[Nhanvien] ([Ma NV], [Ten Nhan Vien], [Ngay Sinh], [Gioi Tinh], [Dia chi], [So Dien Thoai], [Email], [CCCD], [Ma BaoHiem], [Tai Khoan Ngan Hang], [Ten Ngan Hang], [Ma PhongBan], [Password], [Ma PhanQuyen], [Ma ChucVu], [Trinh do], [Kinh nghiem], [Trang Thai]) VALUES (N'NV102', N'Huỳnh Thị Thanh Nhàn', CAST(N'2004-12-06T00:00:00.000' AS DateTime), N'Nữ', N'Quế Sơn-Quảng Nam', N'0342857663', N'thanhnhanqmqs@gmail.com', N'049304006436', N'AB1234567891', N'1234567891', N'Ngân hàng VIB', N'PB1', N'102', N'103', N'NV2', NULL, NULL, 1)
INSERT [dbo].[Nhanvien] ([Ma NV], [Ten Nhan Vien], [Ngay Sinh], [Gioi Tinh], [Dia chi], [So Dien Thoai], [Email], [CCCD], [Ma BaoHiem], [Tai Khoan Ngan Hang], [Ten Ngan Hang], [Ma PhongBan], [Password], [Ma PhanQuyen], [Ma ChucVu], [Trinh do], [Kinh nghiem], [Trang Thai]) VALUES (N'NV103', N'Nguyễn Đức Bình', CAST(N'2004-09-14T00:00:00.000' AS DateTime), N'Nam', N'Hà Tĩnh', N'0369458309', N'dbinh1012@gmail.com', N'049204006437', N'AB1234567892', N'1234567892', N'Ngân hàng MB', N'PB2', N'103', N'103', N'NV4', NULL, NULL, 1)
INSERT [dbo].[Nhanvien] ([Ma NV], [Ten Nhan Vien], [Ngay Sinh], [Gioi Tinh], [Dia chi], [So Dien Thoai], [Email], [CCCD], [Ma BaoHiem], [Tai Khoan Ngan Hang], [Ten Ngan Hang], [Ma PhongBan], [Password], [Ma PhanQuyen], [Ma ChucVu], [Trinh do], [Kinh nghiem], [Trang Thai]) VALUES (N'NV104', N'Huỳnh Thị Mỹ Dung', CAST(N'2004-01-09T00:00:00.000' AS DateTime), N'Nữ', N'Quảng Nam', N'0935563776', N'huynhmydung.17082004@gmail.com', N'049304006436', N'AB1234567893', N'1234567893', N'Ngân hàng BIDV', N'PB2', N'104', N'103', N'NV3', NULL, NULL, 1)
INSERT [dbo].[Nhanvien] ([Ma NV], [Ten Nhan Vien], [Ngay Sinh], [Gioi Tinh], [Dia chi], [So Dien Thoai], [Email], [CCCD], [Ma BaoHiem], [Tai Khoan Ngan Hang], [Ten Ngan Hang], [Ma PhongBan], [Password], [Ma PhanQuyen], [Ma ChucVu], [Trinh do], [Kinh nghiem], [Trang Thai]) VALUES (N'NV105', N'Nguyễn Thị Mỹ Lệ', CAST(N'2004-04-08T00:00:00.000' AS DateTime), N'Nữ', N'Đà Nẵng', N'0704407803', N'myle15082004@gmail.com', N'049304006437', N'AB1234567894', N'1234567894', N'Ngân hàng MB', N'PB1', N'105', N'103', N'QL1', NULL, NULL, 1)
INSERT [dbo].[Nhanvien] ([Ma NV], [Ten Nhan Vien], [Ngay Sinh], [Gioi Tinh], [Dia chi], [So Dien Thoai], [Email], [CCCD], [Ma BaoHiem], [Tai Khoan Ngan Hang], [Ten Ngan Hang], [Ma PhongBan], [Password], [Ma PhanQuyen], [Ma ChucVu], [Trinh do], [Kinh nghiem], [Trang Thai]) VALUES (N'NV106', N'Nguyễn Thị Thúy Hằng', CAST(N'2003-10-09T00:00:00.000' AS DateTime), N'Nữ', N'Quảng Bình', N'0898401470', N'hanggnguyenn470@gmail.com', N'049304006438', N'AB1234567895', N'1234567895', N'Ngân hàng MB', N'PB2', N'106', N'103', N'QL2', NULL, NULL, 1)
INSERT [dbo].[Nhanvien] ([Ma NV], [Ten Nhan Vien], [Ngay Sinh], [Gioi Tinh], [Dia chi], [So Dien Thoai], [Email], [CCCD], [Ma BaoHiem], [Tai Khoan Ngan Hang], [Ten Ngan Hang], [Ma PhongBan], [Password], [Ma PhanQuyen], [Ma ChucVu], [Trinh do], [Kinh nghiem], [Trang Thai]) VALUES (N'NV107', N'	Nguyễn Thành Trung', CAST(N'2002-05-05T00:00:00.000' AS DateTime), N'Nam', N'Đà Nẵng', N'0765126302', N'trung9204@gmail.com	', N'049204006439', N'AB1234567896', N'1234567896', N'Ngân hàng Vietcombank', N'PB3', N'107', N'103', N'QL3', NULL, NULL, 1)
INSERT [dbo].[Nhanvien] ([Ma NV], [Ten Nhan Vien], [Ngay Sinh], [Gioi Tinh], [Dia chi], [So Dien Thoai], [Email], [CCCD], [Ma BaoHiem], [Tai Khoan Ngan Hang], [Ten Ngan Hang], [Ma PhongBan], [Password], [Ma PhanQuyen], [Ma ChucVu], [Trinh do], [Kinh nghiem], [Trang Thai]) VALUES (N'NV108', N'Võ Văn Tuấn', CAST(N'2004-10-10T00:00:00.000' AS DateTime), N'Nam', N'Đà Nẵng', N'0899465343', N'nauts010203@gmail.com', N'049204006449', N'AB1234567897', N'1234567897', N'Ngân hàng VIB', N'PB4', N'108', N'103', N'QL4', NULL, NULL, 1)
INSERT [dbo].[Nhanvien] ([Ma NV], [Ten Nhan Vien], [Ngay Sinh], [Gioi Tinh], [Dia chi], [So Dien Thoai], [Email], [CCCD], [Ma BaoHiem], [Tai Khoan Ngan Hang], [Ten Ngan Hang], [Ma PhongBan], [Password], [Ma PhanQuyen], [Ma ChucVu], [Trinh do], [Kinh nghiem], [Trang Thai]) VALUES (N'NV109', N'Lý Hoàng Quyên', CAST(N'2001-09-03T00:00:00.000' AS DateTime), N'Nữ', N'Hà Tĩnh', N'0867517503', N'lyquyen520@gmail.com', N'049204006441', N'AB1234567898', N'1234567898', N'Ngân hàng Vietcombank', N'PB1', N'109', N'103', N'NV1', NULL, NULL, 1)
INSERT [dbo].[Nhanvien] ([Ma NV], [Ten Nhan Vien], [Ngay Sinh], [Gioi Tinh], [Dia chi], [So Dien Thoai], [Email], [CCCD], [Ma BaoHiem], [Tai Khoan Ngan Hang], [Ten Ngan Hang], [Ma PhongBan], [Password], [Ma PhanQuyen], [Ma ChucVu], [Trinh do], [Kinh nghiem], [Trang Thai]) VALUES (N'NV110', N'Nguyễn Hữu Khoa', CAST(N'1999-10-03T00:00:00.000' AS DateTime), N'Nam', N'Đà Nẵng', N'0338104272', N'huukhoa04@gmail.com', N'049204006441', N'AB123456799 ', N'1234567899', N'Ngân hàng BIDV', N'PB2', N'110', N'103', N'NV2', NULL, NULL, 1)
INSERT [dbo].[Nhanvien] ([Ma NV], [Ten Nhan Vien], [Ngay Sinh], [Gioi Tinh], [Dia chi], [So Dien Thoai], [Email], [CCCD], [Ma BaoHiem], [Tai Khoan Ngan Hang], [Ten Ngan Hang], [Ma PhongBan], [Password], [Ma PhanQuyen], [Ma ChucVu], [Trinh do], [Kinh nghiem], [Trang Thai]) VALUES (N'NV111', N'Nguyễn Sĩ Mirinda	', CAST(N'2003-04-30T00:00:00.000' AS DateTime), N'Nam', N'Quảng Nam', N'0905025684', N'nguyensimirinda123@gmail.com', N'049304006456', N'AB1234567800', N'1234567800', N'Ngân hàng BIDV', NULL, N'111', N'103', N'NV4', NULL, NULL, 0)
INSERT [dbo].[Nhanvien] ([Ma NV], [Ten Nhan Vien], [Ngay Sinh], [Gioi Tinh], [Dia chi], [So Dien Thoai], [Email], [CCCD], [Ma BaoHiem], [Tai Khoan Ngan Hang], [Ten Ngan Hang], [Ma PhongBan], [Password], [Ma PhanQuyen], [Ma ChucVu], [Trinh do], [Kinh nghiem], [Trang Thai]) VALUES (N'QL101', N'Nhan', CAST(N'2004-09-26T00:00:00.000' AS DateTime), N'Nam', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'quanly', N'101', NULL, NULL, NULL, 1)
GO
INSERT [dbo].[Phanquyen] ([Ma PhanQuyen], [Phan Quyen]) VALUES (N'101', N'Quản lý')
INSERT [dbo].[Phanquyen] ([Ma PhanQuyen], [Phan Quyen]) VALUES (N'102', N'Kế toán')
INSERT [dbo].[Phanquyen] ([Ma PhanQuyen], [Phan Quyen]) VALUES (N'103', N'Nhân viên')
GO
INSERT [dbo].[Phongban] ([Ma PhongBan], [Ten PhongBan], [Ma TruongPhong]) VALUES (N'PB1', N'Phòng Tiền Sảnh', NULL)
INSERT [dbo].[Phongban] ([Ma PhongBan], [Ten PhongBan], [Ma TruongPhong]) VALUES (N'PB2', N'Phòng Buồng Phòng', NULL)
INSERT [dbo].[Phongban] ([Ma PhongBan], [Ten PhongBan], [Ma TruongPhong]) VALUES (N'PB3', N'Phòng Ẩm Thực', NULL)
INSERT [dbo].[Phongban] ([Ma PhongBan], [Ten PhongBan], [Ma TruongPhong]) VALUES (N'PB4', N'Phòng Kỹ Thuật', NULL)
GO
ALTER TABLE [dbo].[CongviecNV]  WITH CHECK ADD  CONSTRAINT [FK_CongviecNV_Congviec] FOREIGN KEY([Ma CongViec])
REFERENCES [dbo].[Congviec] ([Ma CongViec])
GO
ALTER TABLE [dbo].[CongviecNV] CHECK CONSTRAINT [FK_CongviecNV_Congviec]
GO
ALTER TABLE [dbo].[CongviecNV]  WITH CHECK ADD  CONSTRAINT [FK_CongviecNV_Nhanvien] FOREIGN KEY([Ma NV])
REFERENCES [dbo].[Nhanvien] ([Ma NV])
GO
ALTER TABLE [dbo].[CongviecNV] CHECK CONSTRAINT [FK_CongviecNV_Nhanvien]
GO
ALTER TABLE [dbo].[LuongNV]  WITH CHECK ADD  CONSTRAINT [FK_LuongNV_Luong] FOREIGN KEY([Ma Luong])
REFERENCES [dbo].[Luong] ([Ma Luong])
GO
ALTER TABLE [dbo].[LuongNV] CHECK CONSTRAINT [FK_LuongNV_Luong]
GO
ALTER TABLE [dbo].[LuongNV]  WITH CHECK ADD  CONSTRAINT [FK_LuongNV_Nhanvien] FOREIGN KEY([Ma NV])
REFERENCES [dbo].[Nhanvien] ([Ma NV])
GO
ALTER TABLE [dbo].[LuongNV] CHECK CONSTRAINT [FK_LuongNV_Nhanvien]
GO
ALTER TABLE [dbo].[Nhanvien]  WITH CHECK ADD  CONSTRAINT [FK_Nhanvien_Chucvu] FOREIGN KEY([Ma ChucVu])
REFERENCES [dbo].[Chucvu] ([Ma ChucVu])
GO
ALTER TABLE [dbo].[Nhanvien] CHECK CONSTRAINT [FK_Nhanvien_Chucvu]
GO
ALTER TABLE [dbo].[Nhanvien]  WITH CHECK ADD  CONSTRAINT [FK_Nhanvien_Phanquyen] FOREIGN KEY([Ma PhanQuyen])
REFERENCES [dbo].[Phanquyen] ([Ma PhanQuyen])
GO
ALTER TABLE [dbo].[Nhanvien] CHECK CONSTRAINT [FK_Nhanvien_Phanquyen]
GO
ALTER TABLE [dbo].[Nhanvien]  WITH CHECK ADD  CONSTRAINT [FK_Nhanvien_Phongban] FOREIGN KEY([Ma PhongBan])
REFERENCES [dbo].[Phongban] ([Ma PhongBan])
GO
ALTER TABLE [dbo].[Nhanvien] CHECK CONSTRAINT [FK_Nhanvien_Phongban]
GO
USE [master]
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET  READ_WRITE 
GO
