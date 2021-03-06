USE [master]
GO
/****** Object:  Database [Net5McSvcTemplate]    Script Date: 3/9/2021 10:29:23 PM ******/
CREATE DATABASE [Net5McSvcTemplate]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Net5McSvcTemplate', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Net5McSvcTemplate.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Net5McSvcTemplate_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Net5McSvcTemplate_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Net5McSvcTemplate] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Net5McSvcTemplate].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Net5McSvcTemplate] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Net5McSvcTemplate] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Net5McSvcTemplate] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Net5McSvcTemplate] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Net5McSvcTemplate] SET ARITHABORT OFF 
GO
ALTER DATABASE [Net5McSvcTemplate] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Net5McSvcTemplate] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Net5McSvcTemplate] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Net5McSvcTemplate] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Net5McSvcTemplate] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Net5McSvcTemplate] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Net5McSvcTemplate] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Net5McSvcTemplate] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Net5McSvcTemplate] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Net5McSvcTemplate] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Net5McSvcTemplate] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Net5McSvcTemplate] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Net5McSvcTemplate] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Net5McSvcTemplate] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Net5McSvcTemplate] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Net5McSvcTemplate] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Net5McSvcTemplate] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Net5McSvcTemplate] SET RECOVERY FULL 
GO
ALTER DATABASE [Net5McSvcTemplate] SET  MULTI_USER 
GO
ALTER DATABASE [Net5McSvcTemplate] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Net5McSvcTemplate] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Net5McSvcTemplate] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Net5McSvcTemplate] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Net5McSvcTemplate] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Net5McSvcTemplate', N'ON'
GO
ALTER DATABASE [Net5McSvcTemplate] SET QUERY_STORE = OFF
GO
USE [Net5McSvcTemplate]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 3/9/2021 10:29:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[ProductId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 3/9/2021 10:29:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[UpdatedTime] [datetime] NOT NULL,
	[UserName] [varchar](50) NULL,
	[Reason] [varchar](max) NULL,
	[CencelledBy] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 3/9/2021 10:29:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[ProductName] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/9/2021 10:29:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](1000) NOT NULL,
	[Type] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/9/2021 10:29:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Warehouse]    Script Date: 3/9/2021 10:29:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[InventoryId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[CREATE_ORDER]    Script Date: 3/9/2021 10:29:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CREATE_ORDER]
	-- Add the parameters for the stored procedure here
	@userId int, 
	@userName varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Order] VALUES (@userId, GETDATE(), @userName)

	SELECT @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[CREATE_ORDER_DETAILS]    Script Date: 3/9/2021 10:29:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CREATE_ORDER_DETAILS]
	-- Add the parameters for the stored procedure here
	@orderId int, 
	@productId int,
	@quantity int,
	@productName varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[OrderDetail]
	([OrderId],[ProductId],[Quantity],[ProductName]) VALUES (@orderId, @productId, @quantity, @productName)

END

GO
/****** Object:  StoredProcedure [dbo].[UPDATE_INVENTORY]    Script Date: 3/9/2021 10:29:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UPDATE_INVENTORY]
	-- Add the parameters for the stored procedure here
	@productId int, 
	@quantity int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [dbo].[Inventory] SET [Quantity] = @quantity WHERE [ProductId] = @productId

END

GO
USE [master]
GO
ALTER DATABASE [Net5McSvcTemplate] SET  READ_WRITE 
GO
