USE [master]
GO
/****** Object:  Database [QUANLYNHANVIENKHACHSAN]    Script Date: 5/23/2024 8:17:18 PM ******/
CREATE DATABASE [QUANLYNHANVIENKHACHSAN]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QUANLYNHANVIENKHACHSAN', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QUANLYNHANVIENKHACHSAN.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QUANLYNHANVIENKHACHSAN_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QUANLYNHANVIENKHACHSAN_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET QUERY_STORE = ON
GO
ALTER DATABASE [QUANLYNHANVIENKHACHSAN] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QUANLYNHANVIENKHACHSAN]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/23/2024 8:17:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chucvu]    Script Date: 5/23/2024 8:17:19 PM ******/
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
/****** Object:  Table [dbo].[Congviec]    Script Date: 5/23/2024 8:17:19 PM ******/
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
/****** Object:  Table [dbo].[CongviecNV]    Script Date: 5/23/2024 8:17:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongviecNV](
	[Ma CongViecNV] [int] IDENTITY(1,1) NOT NULL,
	[Ma CongViec] [int] NOT NULL,
	[Ma NV] [nvarchar](10) NULL,
	[Ngay Lam] [datetime] NULL,
	[Cham Cong] [bit] NULL,
	[Nghi Phep] [int] NULL,
 CONSTRAINT [PK_CongviecNV_1] PRIMARY KEY CLUSTERED 
(
	[Ma CongViecNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Luong]    Script Date: 5/23/2024 8:17:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Luong](
	[Ma Luong] [nvarchar](10) NOT NULL,
	[Ten Ma Luong] [nvarchar](50) NULL,
	[Luong Co Ban] [decimal](12, 3) NULL,
	[Phu Cap] [decimal](12, 3) NULL,
 CONSTRAINT [PK_Luong_1] PRIMARY KEY CLUSTERED 
(
	[Ma Luong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LuongNV]    Script Date: 5/23/2024 8:17:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LuongNV](
	[Ma Luong] [nvarchar](10) NULL,
	[Ma NV] [nvarchar](10) NULL,
	[Thang] [int] NULL,
	[Ngay cong] [int] NULL,
	[Thuong] [decimal](10, 3) NULL,
	[Phat] [decimal](10, 3) NULL,
	[Luong Tong] [decimal](12, 0) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nhanvien]    Script Date: 5/23/2024 8:17:19 PM ******/
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
	[Hinh anh] [image] NULL,
	[Email] [nvarchar](50) NULL,
	[CCCD] [nchar](12) NULL,
	[Ma BaoHiem] [nchar](10) NULL,
	[Tai Khoan Ngan Hang] [nchar](10) NULL,
	[Ten Ngan Hang] [nvarchar](50) NULL,
	[Ma PhongBan] [nvarchar](10) NULL,
	[Password] [nvarchar](50) NULL,
	[Ma PhanQuyen] [nvarchar](10) NULL,
	[Ma ChucVu] [nvarchar](10) NULL,
	[Trinh do] [nvarchar](max) NULL,
	[Kinh nghiem] [nvarchar](max) NULL,
 CONSTRAINT [PK_Nhanvien] PRIMARY KEY CLUSTERED 
(
	[Ma NV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phanquyen]    Script Date: 5/23/2024 8:17:19 PM ******/
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
/****** Object:  Table [dbo].[Phongban]    Script Date: 5/23/2024 8:17:19 PM ******/
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
INSERT [dbo].[Chucvu] ([Ma ChucVu], [Chuc Vu]) VALUES (N'CV1', N'Quản lý')
INSERT [dbo].[Chucvu] ([Ma ChucVu], [Chuc Vu]) VALUES (N'CV2', N'Kế toán')
INSERT [dbo].[Chucvu] ([Ma ChucVu], [Chuc Vu]) VALUES (N'CV3', N'Nhân viên')
GO
SET IDENTITY_INSERT [dbo].[Congviec] ON 

INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (1, N'Buồng phòng                                       ', N'5h-13h')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (2, N'Lễ tân                                            ', N'6h-12h30')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (3, N'Lễ tân                                            ', N'13h-20h30')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (15, N'Lễ tân                                            ', N'5h-13h')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (16, N'Lễ tân                                            ', N'5h-13h')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (17, N'Giám sát                                          ', N'5h-13h')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (18, N'Giám sát                                          ', N'5h-13h')
INSERT [dbo].[Congviec] ([Ma CongViec], [Chi Tiet Cong Viec], [Ca Lam]) VALUES (19, N'Buồng phòng                                       ', N'7h-12')
SET IDENTITY_INSERT [dbo].[Congviec] OFF
GO
SET IDENTITY_INSERT [dbo].[CongviecNV] ON 

INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam], [Cham Cong], [Nghi Phep]) VALUES (1, 1, N'NV103', CAST(N'2024-11-03T00:00:00.000' AS DateTime), 1, 3)
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam], [Cham Cong], [Nghi Phep]) VALUES (2, 2, N'NV102', CAST(N'2022-04-04T00:00:00.000' AS DateTime), 1, 2)
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam], [Cham Cong], [Nghi Phep]) VALUES (3, 3, N'NV103', CAST(N'2024-07-07T00:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam], [Cham Cong], [Nghi Phep]) VALUES (4, 15, N'NV105', CAST(N'2034-05-05T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam], [Cham Cong], [Nghi Phep]) VALUES (5, 16, N'NV103', CAST(N'2024-11-03T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam], [Cham Cong], [Nghi Phep]) VALUES (6, 19, N'NV103', CAST(N'2024-05-09T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam], [Cham Cong], [Nghi Phep]) VALUES (7, 19, N'NV106', CAST(N'2024-05-12T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam], [Cham Cong], [Nghi Phep]) VALUES (8, 17, N'NV105', CAST(N'2024-05-18T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam], [Cham Cong], [Nghi Phep]) VALUES (9, 19, N'NV106', CAST(N'2024-05-26T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam], [Cham Cong], [Nghi Phep]) VALUES (10, 19, N'NV106', CAST(N'2024-05-26T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam], [Cham Cong], [Nghi Phep]) VALUES (11, 17, N'NV106', CAST(N'2024-05-19T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam], [Cham Cong], [Nghi Phep]) VALUES (12, 16, N'NV105', CAST(N'2024-05-17T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam], [Cham Cong], [Nghi Phep]) VALUES (13, 16, N'NV106', CAST(N'2024-05-17T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam], [Cham Cong], [Nghi Phep]) VALUES (14, 15, N'NV106', CAST(N'2024-05-17T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[CongviecNV] ([Ma CongViecNV], [Ma CongViec], [Ma NV], [Ngay Lam], [Cham Cong], [Nghi Phep]) VALUES (15, 16, N'NV101', CAST(N'2024-05-17T00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[CongviecNV] OFF
GO
INSERT [dbo].[Luong] ([Ma Luong], [Ten Ma Luong], [Luong Co Ban], [Phu Cap]) VALUES (N'L1', N'Kế toán', CAST(5000000.000 AS Decimal(12, 3)), CAST(5000000.000 AS Decimal(12, 3)))
INSERT [dbo].[Luong] ([Ma Luong], [Ten Ma Luong], [Luong Co Ban], [Phu Cap]) VALUES (N'L2', N'Quản lý', CAST(10000000.000 AS Decimal(12, 3)), CAST(1000000.000 AS Decimal(12, 3)))
INSERT [dbo].[Luong] ([Ma Luong], [Ten Ma Luong], [Luong Co Ban], [Phu Cap]) VALUES (N'L3', N'Lễ tân', CAST(7000000.000 AS Decimal(12, 3)), CAST(5000000.000 AS Decimal(12, 3)))
INSERT [dbo].[Luong] ([Ma Luong], [Ten Ma Luong], [Luong Co Ban], [Phu Cap]) VALUES (N'L4', N'Trưởng lễ tân', CAST(9000000.000 AS Decimal(12, 3)), CAST(7000000.000 AS Decimal(12, 3)))
GO
INSERT [dbo].[LuongNV] ([Ma Luong], [Ma NV], [Thang], [Ngay cong], [Thuong], [Phat], [Luong Tong]) VALUES (N'L1', N'NV103', 4, 23, CAST(500000.000 AS Decimal(10, 3)), CAST(200000.000 AS Decimal(10, 3)), NULL)
INSERT [dbo].[LuongNV] ([Ma Luong], [Ma NV], [Thang], [Ngay cong], [Thuong], [Phat], [Luong Tong]) VALUES (N'L2', N'NV102', 4, 27, CAST(500000.000 AS Decimal(10, 3)), CAST(100000.000 AS Decimal(10, 3)), NULL)
GO
INSERT [dbo].[Nhanvien] ([Ma NV], [Ten Nhan Vien], [Ngay Sinh], [Gioi Tinh], [Dia chi], [So Dien Thoai], [Hinh anh], [Email], [CCCD], [Ma BaoHiem], [Tai Khoan Ngan Hang], [Ten Ngan Hang], [Ma PhongBan], [Password], [Ma PhanQuyen], [Ma ChucVu], [Trinh do], [Kinh nghiem]) VALUES (N'NV101', N'Nguyễn Văn Tuấn', CAST(N'2000-03-11T00:00:00.000' AS DateTime), N'false', N'Quảng Nam', N'03848484w ', NULL, N'tuan@gmail.com', N'049373773222', N'8337736363', N'4743838383', N'MB', NULL, N'1', N'101', N'CV1', N'Đại học', N'')
INSERT [dbo].[Nhanvien] ([Ma NV], [Ten Nhan Vien], [Ngay Sinh], [Gioi Tinh], [Dia chi], [So Dien Thoai], [Hinh anh], [Email], [CCCD], [Ma BaoHiem], [Tai Khoan Ngan Hang], [Ten Ngan Hang], [Ma PhongBan], [Password], [Ma PhanQuyen], [Ma ChucVu], [Trinh do], [Kinh nghiem]) VALUES (N'NV102', N'Nguyễn Đức Bình ', CAST(N'2004-01-23T00:00:00.000' AS DateTime), N'true', N'Hà Tĩnh', N'0893737222', NULL, N'ducbinh2004@gmail.com', N'043738838333', N'5333333333', N'654227874 ', N'Aribank', N'PB1', N'2', N'102', N'CV2', N'Đại hpcj', NULL)
INSERT [dbo].[Nhanvien] ([Ma NV], [Ten Nhan Vien], [Ngay Sinh], [Gioi Tinh], [Dia chi], [So Dien Thoai], [Hinh anh], [Email], [CCCD], [Ma BaoHiem], [Tai Khoan Ngan Hang], [Ten Ngan Hang], [Ma PhongBan], [Password], [Ma PhanQuyen], [Ma ChucVu], [Trinh do], [Kinh nghiem]) VALUES (N'NV103', N'Phan Thanh VIệt', CAST(N'2004-05-05T00:00:00.000' AS DateTime), N'Nam', N'Quảng Nam', N'0473883333', NULL, N'Viet@gmail.com', N'037373833   ', N'4484848484', N'484848484 ', N'MB', N'PB2', N'3', N'103', N'CV3', NULL, NULL)
INSERT [dbo].[Nhanvien] ([Ma NV], [Ten Nhan Vien], [Ngay Sinh], [Gioi Tinh], [Dia chi], [So Dien Thoai], [Hinh anh], [Email], [CCCD], [Ma BaoHiem], [Tai Khoan Ngan Hang], [Ten Ngan Hang], [Ma PhongBan], [Password], [Ma PhanQuyen], [Ma ChucVu], [Trinh do], [Kinh nghiem]) VALUES (N'NV105', N'Nguyễn Phan Thành Dương', CAST(N'2024-05-16T00:00:00.000' AS DateTime), N'Nam', N'Đà Nẵng', N'03627282  ', NULL, N'thanhduong@gmail.com', N'0349227272  ', N'344455    ', N'32828288  ', N'MB bank', N'PB1', N'5', N'103', N'CV3', NULL, NULL)
INSERT [dbo].[Nhanvien] ([Ma NV], [Ten Nhan Vien], [Ngay Sinh], [Gioi Tinh], [Dia chi], [So Dien Thoai], [Hinh anh], [Email], [CCCD], [Ma BaoHiem], [Tai Khoan Ngan Hang], [Ten Ngan Hang], [Ma PhongBan], [Password], [Ma PhanQuyen], [Ma ChucVu], [Trinh do], [Kinh nghiem]) VALUES (N'NV106', N'Trần Nguyễn Thanh An', CAST(N'2024-05-15T00:00:00.000' AS DateTime), N'Nữ', N'Quảng Nam', N'08483774  ', NULL, N'an@gmail.com', N'03737383    ', N'22222     ', N'48484848  ', N'MB bank', N'PB3', N'6', N'103', N'CV3', NULL, NULL)
GO
INSERT [dbo].[Phanquyen] ([Ma PhanQuyen], [Phan Quyen]) VALUES (N'101', N'Quản lý')
INSERT [dbo].[Phanquyen] ([Ma PhanQuyen], [Phan Quyen]) VALUES (N'102', N'Kế toán')
INSERT [dbo].[Phanquyen] ([Ma PhanQuyen], [Phan Quyen]) VALUES (N'103', N'Nhân viên')
GO
INSERT [dbo].[Phongban] ([Ma PhongBan], [Ten PhongBan], [Ma TruongPhong]) VALUES (N'PB1', N'Nhân sự', N'NV103')
INSERT [dbo].[Phongban] ([Ma PhongBan], [Ten PhongBan], [Ma TruongPhong]) VALUES (N'PB2', N'Kế toán', N'NV102')
INSERT [dbo].[Phongban] ([Ma PhongBan], [Ten PhongBan], [Ma TruongPhong]) VALUES (N'PB3', N'Lễ tân', N'NV105')
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
