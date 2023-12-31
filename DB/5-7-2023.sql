USE [master]
GO
/****** Object:  Database [ZahraMarket]    Script Date: 7/5/2023 5:00:36 PM ******/
CREATE DATABASE [ZahraMarket]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ZahraMarket', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ZahraMarket.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ZahraMarket_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ZahraMarket_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ZahraMarket] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ZahraMarket].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ZahraMarket] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ZahraMarket] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ZahraMarket] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ZahraMarket] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ZahraMarket] SET ARITHABORT OFF 
GO
ALTER DATABASE [ZahraMarket] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ZahraMarket] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ZahraMarket] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ZahraMarket] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ZahraMarket] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ZahraMarket] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ZahraMarket] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ZahraMarket] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ZahraMarket] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ZahraMarket] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ZahraMarket] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ZahraMarket] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ZahraMarket] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ZahraMarket] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ZahraMarket] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ZahraMarket] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ZahraMarket] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ZahraMarket] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ZahraMarket] SET  MULTI_USER 
GO
ALTER DATABASE [ZahraMarket] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ZahraMarket] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ZahraMarket] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ZahraMarket] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ZahraMarket]
GO
/****** Object:  User [vts]    Script Date: 7/5/2023 5:00:36 PM ******/
CREATE USER [vts] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [MPC]    Script Date: 7/5/2023 5:00:36 PM ******/
CREATE USER [MPC] FOR LOGIN [MPC] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [DESKTOP-7P7OFFS\VTS-fathi]    Script Date: 7/5/2023 5:00:36 PM ******/
CREATE USER [DESKTOP-7P7OFFS\VTS-fathi] FOR LOGIN [DESKTOP-7P7OFFS\VTS-fathi] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [vts]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [vts]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [vts]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [vts]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [vts]
GO
ALTER ROLE [db_datareader] ADD MEMBER [vts]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [vts]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [vts]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [vts]
GO
ALTER ROLE [db_owner] ADD MEMBER [MPC]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [MPC]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [MPC]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [MPC]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [MPC]
GO
ALTER ROLE [db_datareader] ADD MEMBER [MPC]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [MPC]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [MPC]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [MPC]
GO
ALTER ROLE [db_owner] ADD MEMBER [DESKTOP-7P7OFFS\VTS-fathi]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [DESKTOP-7P7OFFS\VTS-fathi]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [DESKTOP-7P7OFFS\VTS-fathi]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [DESKTOP-7P7OFFS\VTS-fathi]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [DESKTOP-7P7OFFS\VTS-fathi]
GO
ALTER ROLE [db_datareader] ADD MEMBER [DESKTOP-7P7OFFS\VTS-fathi]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [DESKTOP-7P7OFFS\VTS-fathi]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [DESKTOP-7P7OFFS\VTS-fathi]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [DESKTOP-7P7OFFS\VTS-fathi]
GO
/****** Object:  Table [dbo].[LoginInfo]    Script Date: 7/5/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginInfo](
	[Id] [uniqueidentifier] NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[LastLogin] [nvarchar](50) NULL,
	[IsActivated] [bit] NULL,
	[IsBloacked] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK_LoginInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MainGroups]    Script Date: 7/5/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MainGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](max) NULL,
	[pi_path] [nvarchar](max) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_MainGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductPictures]    Script Date: 7/5/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPictures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[pi_path] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProductPictures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 7/5/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SupGroup] [int] NULL,
	[ProductName] [nvarchar](50) NULL,
	[Qnt] [int] NULL,
	[Price] [float] NULL,
	[Notes] [nvarchar](50) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubGroupsT]    Script Date: 7/5/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubGroupsT](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupID] [int] NULL,
	[SubGroupName] [nvarchar](50) NULL,
	[IsDeletedd] [bit] NULL,
 CONSTRAINT [PK_SubGroupsT] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Reg_Info]    Script Date: 7/5/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Reg_Info](
	[Id] [uniqueidentifier] NULL,
	[FirstName] [nvarchar](50) NULL,
	[userPhone] [int] NULL,
	[useremail] [nvarchar](50) NULL,
	[username] [nvarchar](50) NULL,
	[userpassword] [nchar](10) NULL,
	[RoleId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/5/2023 5:00:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[RoleId] [int] NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[LoginInfo] ([Id], [Email], [Password], [LastLogin], [IsActivated], [IsBloacked], [IsDeleted], [RoleId]) VALUES (N'f465bc14-7767-47ae-93b2-244d9d228845', N'admin@MINIA.COM', N'123', N'1', 1, 0, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[MainGroups] ON 

INSERT [dbo].[MainGroups] ([Id], [GroupName], [pi_path], [IsDeleted]) VALUES (9, N'ملابس ', N'/Uploads/ServicesAtt/9/bg.jpg', 0)
INSERT [dbo].[MainGroups] ([Id], [GroupName], [pi_path], [IsDeleted]) VALUES (10, N'الكترونيات ', N'/Uploads/ServicesAtt/11/الكترونيات .jpg', 0)
INSERT [dbo].[MainGroups] ([Id], [GroupName], [pi_path], [IsDeleted]) VALUES (11, N'ملابس ', N'/Uploads/ServicesAtt/11/ملابس .jpg', 0)
SET IDENTITY_INSERT [dbo].[MainGroups] OFF
GO
SET IDENTITY_INSERT [dbo].[SubGroupsT] ON 

INSERT [dbo].[SubGroupsT] ([Id], [GroupID], [SubGroupName], [IsDeletedd]) VALUES (4, 9, N'ملابس رجالي ', 0)
SET IDENTITY_INSERT [dbo].[SubGroupsT] OFF
GO
INSERT [dbo].[Users] ([Id], [RoleId], [UserName], [Password], [IsActive]) VALUES (N'79e1c750-fe83-4cc1-88dc-0f37eaa86b21', 2, N'adminda', N'7f103M4D/xMsDHuh2U1J6Q==', 1)
INSERT [dbo].[Users] ([Id], [RoleId], [UserName], [Password], [IsActive]) VALUES (N'199d872d-ece2-4843-9549-1d337d467a44', 2, N'admindad', N'7f103M4D/xMsDHuh2U1J6Q==', 1)
INSERT [dbo].[Users] ([Id], [RoleId], [UserName], [Password], [IsActive]) VALUES (N'b11a66ea-9b77-4151-b39f-522972d8a025', 2, N'fathi', N'7f103M4D/xMsDHuh2U1J6Q==', 1)
INSERT [dbo].[Users] ([Id], [RoleId], [UserName], [Password], [IsActive]) VALUES (N'9245fe4a-d402-451c-b9ed-9c1a04247482', 1, N'Admin', N'7f103M4D/xMsDHuh2U1J6Q==', 1)
INSERT [dbo].[Users] ([Id], [RoleId], [UserName], [Password], [IsActive]) VALUES (N'40c2b760-917f-4013-8c9b-d88db383333e', 2, N'adminda', N'7f103M4D/xMsDHuh2U1J6Q==', 1)
GO
ALTER TABLE [dbo].[LoginInfo] ADD  CONSTRAINT [DF_LoginInfo_IsActivated]  DEFAULT ((0)) FOR [IsActivated]
GO
ALTER TABLE [dbo].[LoginInfo] ADD  CONSTRAINT [DF_LoginInfo_IsBloacked]  DEFAULT ((0)) FOR [IsBloacked]
GO
ALTER TABLE [dbo].[LoginInfo] ADD  CONSTRAINT [DF_LoginInfo_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[MainGroups] ADD  CONSTRAINT [DF_MainGroups_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[User_Reg_Info] ADD  CONSTRAINT [DF_UserInfo_RoleId]  DEFAULT ((2)) FOR [RoleId]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[ProductPictures]  WITH CHECK ADD  CONSTRAINT [FK_ProductPictures_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ID])
GO
ALTER TABLE [dbo].[ProductPictures] CHECK CONSTRAINT [FK_ProductPictures_Products]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_SubGroupsT] FOREIGN KEY([SupGroup])
REFERENCES [dbo].[SubGroupsT] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_SubGroupsT]
GO
ALTER TABLE [dbo].[SubGroupsT]  WITH CHECK ADD  CONSTRAINT [FK_SubGroupsT_MainGroups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[MainGroups] ([Id])
GO
ALTER TABLE [dbo].[SubGroupsT] CHECK CONSTRAINT [FK_SubGroupsT_MainGroups]
GO
USE [master]
GO
ALTER DATABASE [ZahraMarket] SET  READ_WRITE 
GO
