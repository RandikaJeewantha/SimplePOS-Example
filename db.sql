USE [master]
GO
/****** Object:  Database [SuperMarketECommerceWebApp]    Script Date: 26/10/2020 23:42:26 ******/
CREATE DATABASE [SuperMarketECommerceWebApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SuperMarketECommerceWebApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SuperMarketECommerceWebApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SuperMarketECommerceWebApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SuperMarketECommerceWebApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SuperMarketECommerceWebApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET  MULTI_USER 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET QUERY_STORE = OFF
GO
USE [SuperMarketECommerceWebApp]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26/10/2020 23:42:26 ******/
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
/****** Object:  Table [dbo].[Orders]    Script Date: 26/10/2020 23:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[Employee] [nvarchar](250) NOT NULL,
	[CustomerName] [nvarchar](250) NOT NULL,
	[PhoneNumber] [nvarchar](1250) NOT NULL,
	[Gender] [nvarchar](250) NOT NULL,
	[Items] [nvarchar](550) NOT NULL,
	[OrderCost] [nvarchar](550) NOT NULL,
	[Date] [nvarchar](1250) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCatagories]    Script Date: 26/10/2020 23:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCatagories](
	[CatagoryId] [int] IDENTITY(1,1) NOT NULL,
	[CatagoryName] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_ProductCatagories] PRIMARY KEY CLUSTERED 
(
	[CatagoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 26/10/2020 23:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](250) NOT NULL,
	[Price] [real] NOT NULL,
	[Catagory] [nvarchar](250) NOT NULL,
	[Info] [nvarchar](1250) NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 26/10/2020 23:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](250) NOT NULL,
	[SecondName] [nvarchar](250) NOT NULL,
	[Gender] [nvarchar](250) NOT NULL,
	[Position] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](1250) NOT NULL,
	[Password] [nvarchar](1250) NOT NULL,
	[PhoneNumber] [nvarchar](1250) NOT NULL,
	[ContactAddress] [nvarchar](1250) NOT NULL,
	[DateOfBirth] [nvarchar](1250) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201025070631_initial-create', N'3.1.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201025070819_initial-create', N'3.1.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201025070911_initial-create', N'3.1.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201025070954_initial-create', N'3.1.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201025103914_initial-create', N'3.1.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201025192620_initial-create', N'3.1.9')
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [Employee], [CustomerName], [PhoneNumber], [Gender], [Items], [OrderCost], [Date]) VALUES (15, N'Admin', N'Demo customer', N'0123456789', N'Male', N'[{"productName":"Apple","price":50,"quantity":"1","sub_total":50},{"productName":"Orange","price":35,"quantity":"3","sub_total":105}]', N'155', N'10/26/2020, 11:02:50 PM')
INSERT [dbo].[Orders] ([OrderId], [Employee], [CustomerName], [PhoneNumber], [Gender], [Items], [OrderCost], [Date]) VALUES (18, N'Admin', N'Demo customer 5', N'0123456789', N'Male', N'[{"productName":"Orange","price":35,"quantity":"2","sub_total":70},{"productName":"Tomato","price":65,"quantity":"2","sub_total":130}]', N'200', N'10/26/2020, 11:17:40 PM')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCatagories] ON 

INSERT [dbo].[ProductCatagories] ([CatagoryId], [CatagoryName]) VALUES (1, N'Fruits')
INSERT [dbo].[ProductCatagories] ([CatagoryId], [CatagoryName]) VALUES (2, N'Vegetables')
SET IDENTITY_INSERT [dbo].[ProductCatagories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ProductName], [Price], [Catagory], [Info], [Quantity]) VALUES (1, N'Apple', 50, N'Fruits', N'American Green Apples', 0)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Price], [Catagory], [Info], [Quantity]) VALUES (2, N'Orange', 35, N'Fruits', N'Sri Lanka Big Oranges', 0)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Price], [Catagory], [Info], [Quantity]) VALUES (3, N'Tomato', 65, N'Vegetables', N'Indian Tomato Unit - 1KG ', 0)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([AccountId], [FirstName], [SecondName], [Gender], [Position], [Email], [Password], [PhoneNumber], [ContactAddress], [DateOfBirth]) VALUES (1, N'Admin', N'System', N'Male', N'Admin', N'admin@system.world', N'admin', N'0123456789', N'World', N'00/00/0000')
INSERT [dbo].[Users] ([AccountId], [FirstName], [SecondName], [Gender], [Position], [Email], [Password], [PhoneNumber], [ContactAddress], [DateOfBirth]) VALUES (2, N'Demo Cashier', N'first_Cashier', N'Female', N'Cashier', N'cashier@system.com', N'1234', N'0123456789', N'Colombo', N'00/00/0000')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
USE [master]
GO
ALTER DATABASE [SuperMarketECommerceWebApp] SET  READ_WRITE 
GO
