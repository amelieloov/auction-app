USE [master]
GO
/****** Object:  Database [AuctionDB]    Script Date: 2025-03-22 16:34:27 ******/
CREATE DATABASE [AuctionDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AuktionDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\AuktionDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AuktionDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\AuktionDB_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [AuctionDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AuctionDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AuctionDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AuctionDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AuctionDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AuctionDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AuctionDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AuctionDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AuctionDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AuctionDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AuctionDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AuctionDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AuctionDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AuctionDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AuctionDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AuctionDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AuctionDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AuctionDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AuctionDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AuctionDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AuctionDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AuctionDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AuctionDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AuctionDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AuctionDB] SET RECOVERY FULL 
GO
ALTER DATABASE [AuctionDB] SET  MULTI_USER 
GO
ALTER DATABASE [AuctionDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AuctionDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AuctionDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AuctionDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AuctionDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AuctionDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'AuctionDB', N'ON'
GO
ALTER DATABASE [AuctionDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [AuctionDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [AuctionDB]
GO
/****** Object:  Table [dbo].[Auction]    Script Date: 2025-03-22 16:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auction](
	[AuctionID] [int] IDENTITY(1,1) NOT NULL,
	[AuctionTitle] [nvarchar](100) NOT NULL,
	[AuctionDescription] [nvarchar](max) NULL,
	[AuctionPrice] [decimal](18, 2) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[UserID] [int] NOT NULL,
	[Image] [nvarchar](255) NULL,
 CONSTRAINT [PK_Action] PRIMARY KEY CLUSTERED 
(
	[AuctionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bid]    Script Date: 2025-03-22 16:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bid](
	[BidID] [int] IDENTITY(1,1) NOT NULL,
	[BidPrice] [decimal](18, 2) NOT NULL,
	[UserID] [int] NOT NULL,
	[AuctionID] [int] NOT NULL,
 CONSTRAINT [PK_Bid] PRIMARY KEY CLUSTERED 
(
	[BidID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2025-03-22 16:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Auction] ON 

INSERT [dbo].[Auction] ([AuctionID], [AuctionTitle], [AuctionDescription], [AuctionPrice], [StartTime], [EndTime], [UserID], [Image]) VALUES (41, N'Vintage Vinyl Record Collection', N'A rare collection of vinyl records from the 70s and 80s, including classic rock, disco, and jazz albums. Well-preserved with original covers. Perfect for collectors or music enthusiasts.', CAST(150.00 AS Decimal(18, 2)), CAST(N'2025-03-22T15:29:03.373' AS DateTime), CAST(N'2025-04-05T15:22:00.000' AS DateTime), 7, N'cdab0c87-e8f3-4c44-82db-328316ee1a23.jpg')
INSERT [dbo].[Auction] ([AuctionID], [AuctionTitle], [AuctionDescription], [AuctionPrice], [StartTime], [EndTime], [UserID], [Image]) VALUES (42, N'Gaming Laptop - High Performance', N'A powerful gaming laptop with an Intel i7 processor, 16GB of RAM, and a dedicated NVIDIA RTX 3070 graphics card. Ideal for gaming and heavy-duty work. Comes with a 1TB SSD and full warranty.', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2025-03-22T15:53:28.627' AS DateTime), CAST(N'2025-04-05T15:29:00.000' AS DateTime), 7, N'31c79689-f883-436b-9746-8642c11fc8d8.jpg')
INSERT [dbo].[Auction] ([AuctionID], [AuctionTitle], [AuctionDescription], [AuctionPrice], [StartTime], [EndTime], [UserID], [Image]) VALUES (43, N'Modern Abstract Art Painting', N'A stunning piece of abstract artwork featuring vibrant colors and geometric shapes. Created by a local artist, it would add a bold statement to any room. Framed and ready to hang.', CAST(250.00 AS Decimal(18, 2)), CAST(N'2025-03-22T15:34:16.797' AS DateTime), CAST(N'2025-03-23T15:33:00.000' AS DateTime), 7, N'89d4a672-092e-42f4-9caa-0a8311bb5892.jpg')
INSERT [dbo].[Auction] ([AuctionID], [AuctionTitle], [AuctionDescription], [AuctionPrice], [StartTime], [EndTime], [UserID], [Image]) VALUES (44, N'Luxury Leather Handbag', N'A high-end designer leather handbag, in excellent condition. Classic black with gold-tone hardware. Spacious interior, perfect for both everyday use and special occasions.', CAST(460.00 AS Decimal(18, 2)), CAST(N'2025-03-22T15:40:42.190' AS DateTime), CAST(N'2025-04-03T15:40:00.000' AS DateTime), 13, N'c68ab4b7-059f-48ca-aba0-bbc4f65996ea.jpg')
INSERT [dbo].[Auction] ([AuctionID], [AuctionTitle], [AuctionDescription], [AuctionPrice], [StartTime], [EndTime], [UserID], [Image]) VALUES (45, N'Electric Guitar – Beginner’s Pack', N'A complete beginner’s electric guitar set, including a guitar, amp, and accessories. Ideal for those just starting out with music. Comes with a soft case and instructional book.', CAST(120.00 AS Decimal(18, 2)), CAST(N'2025-03-22T15:41:36.657' AS DateTime), CAST(N'2025-05-22T15:41:00.000' AS DateTime), 13, N'1cc60c1f-ac5f-4b16-b932-9c35ca5ab299.jpg')
INSERT [dbo].[Auction] ([AuctionID], [AuctionTitle], [AuctionDescription], [AuctionPrice], [StartTime], [EndTime], [UserID], [Image]) VALUES (46, N'High-End Espresso Machine', N'A professional-grade espresso machine with a built-in grinder and milk frother. Brew café-quality espresso at home. Includes various accessories for making perfect coffee drinks.', CAST(400.00 AS Decimal(18, 2)), CAST(N'2025-03-22T15:42:27.747' AS DateTime), CAST(N'2025-05-08T15:42:00.000' AS DateTime), 13, N'db0c9494-becf-4d24-be0d-cf6c5f8ae783.jpg')
SET IDENTITY_INSERT [dbo].[Auction] OFF
GO
SET IDENTITY_INSERT [dbo].[Bid] ON 

INSERT [dbo].[Bid] ([BidID], [BidPrice], [UserID], [AuctionID]) VALUES (33, CAST(460.00 AS Decimal(18, 2)), 7, 44)
SET IDENTITY_INSERT [dbo].[Bid] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (2, N'lisa', N'2E/n4HvtsifP//EACRUdlvyUT2ob03z/YOjkYmoescM=')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (3, N'kalle2', N'2Bbqxc+vYPryZEW4zRYqCRSPikNSUn7h506scMpjskQ=')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (4, N'fredrik', N'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (5, N'string', N'RzKH+CmNunFjqJeQiVj3wOrnM+JdLgJ5kuou3JvtL6g=')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (6, N'PippiLångstrump', N'gUbOU3Tu9QXFOK9rlVdUJBwahj28osg7H9Pd0SEZ2rI=')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (7, N'simon9', N'savbueJLEDsgVo5DPFn4j9UKG1pIVh3u1r/hhcVhWak=')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (8, N'simon2', N'NP5V10MG/xql41pQOS+lmKoS13QRmVU/Ec+6Jem3oOg=')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (10, N'carl', N'ab/h5uRIId9/igknvX5h7yCP2yXeqkNTRQvD+5BKvVI=')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (11, N'martin', N'tvjUNKhH+w8MGo2bk2uMqVLiJPIFpV9LqbLCD4j9yec=')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (12, N'jakob', N'UgXGJJOIgUnLaVPQpUIBn+nG7/MVq10lQVC3xSDps/E=')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (13, N'simon8', N'V3QUFk26nvIH/fogJNoii1stCv9I/JKRJwrvJYtpC4M=')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (14, N'bella', N'oD6gkHLXia3/Ka/2o3WOkpTJbOgDkVwUVjhOqm4tLfk=')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (15, N'alice2', N'9S+BUlQJ6p3MyLP5vDsUcJ8Acg7K2Oq41rk0mqiRTyo=')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (16, N'simon8', N'V3QUFk26nvIH/fogJNoii1stCv9I/JKRJwrvJYtpC4M=')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (17, N'test', N'n4bQgYhMfWWaL+qgxVrQFaO/TxsrC4Is0V1sFbDwCgg=')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (18, N'henrik2', N'pB6HFfoXpnKjVGltAzuBbSFxFJMjYfh8dZ6xkvJV4lw=')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Auction]  WITH CHECK ADD  CONSTRAINT [FK_Auction_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Auction] CHECK CONSTRAINT [FK_Auction_Users]
GO
ALTER TABLE [dbo].[Bid]  WITH CHECK ADD  CONSTRAINT [FK_Bid_Auction] FOREIGN KEY([AuctionID])
REFERENCES [dbo].[Auction] ([AuctionID])
GO
ALTER TABLE [dbo].[Bid] CHECK CONSTRAINT [FK_Bid_Auction]
GO
ALTER TABLE [dbo].[Bid]  WITH CHECK ADD  CONSTRAINT [FK_Bid_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Bid] CHECK CONSTRAINT [FK_Bid_Users]
GO
/****** Object:  StoredProcedure [dbo].[AddBid]    Script Date: 2025-03-22 16:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddBid]  
    @BidPrice DECIMAL(18, 2),
	@AuctionID int,
	@UserID int
AS
BEGIN
    
    INSERT INTO Bid (BidPrice, AuctionID, UserID)
    VALUES (@BidPrice, @AuctionID, @UserID)

END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 2025-03-22 16:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser]
    @UserName NVARCHAR(50),   
    @Password NVARCHAR(50)    

AS
BEGIN
    -- Inför en ny användare i User-tabellen
    INSERT INTO Users (UserName, Password)
    VALUES (@UserName, @Password)
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteBid]    Script Date: 2025-03-22 16:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteBid]
    @BidID INT 
AS
BEGIN
    
    DELETE FROM Bid
    WHERE BidID = @BidID;
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteItem]    Script Date: 2025-03-22 16:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeleteItem]
@AuctionID int

as
begin

DELETE FROM Auction
WHERE AuctionID = @AuctionID

end 
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 2025-03-22 16:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUser]
    @UserID INT 
AS
BEGIN
   
    DELETE FROM Users
    WHERE UserID = @UserID;
END

GO
/****** Object:  StoredProcedure [dbo].[GetAuctionById]    Script Date: 2025-03-22 16:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [dbo].[GetAuctionById]
@AuctionIDSearch int

as
begin
 -- Hämta alla auktioner som matchar söksträngen i titel
    SELECT AuctionID, AuctionTitle, AuctionDescription, AuctionPrice, StartTime, EndTime, Image, u.UserID, UserName
    FROM Auction a
	inner join Users u on u.UserID = a.UserID
    WHERE AuctionID = @AuctionIDSearch;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAuctionsByUserID]    Script Date: 2025-03-22 16:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAuctionsByUserID](@UserID int)
as
begin
	select AuctionID, AuctionTitle, AuctionDescription, AuctionPrice, StartTime, EndTime, Image
	from Auction
	where UserID = @UserID
end
GO
/****** Object:  StoredProcedure [dbo].[GetBidByID]    Script Date: 2025-03-22 16:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetBidByID]
(@BidID int)

as 
begin

select BidID, AuctionID
from Bid
where BidID = @BidID

end
GO
/****** Object:  StoredProcedure [dbo].[GetBidsByAuctionID]    Script Date: 2025-03-22 16:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetBidsByAuctionID]
@BidAuctionID int
as
begin
 SELECT BidID, BidPrice, u.UserID, u.UserName
    FROM Bid b
	inner join Auction a on a.AuctionID = b.AuctionID
	inner join Users u on u.UserID = b.UserID
    WHERE a. AuctionID = @BidAuctionID
END
GO
/****** Object:  StoredProcedure [dbo].[GetBidsByUserID]    Script Date: 2025-03-22 16:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetBidsByUserID](@UserID int)
as
begin
	select BidID, BidPrice, a.AuctionID, a.AuctionTitle, u.UserID
	from Bid b
	inner join Auction a on a.AuctionID = b.AuctionID
	inner join Users u on u.UserID = b.UserID
	where b.UserID = @UserID
end
GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 2025-03-22 16:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUser]
    @UserID INT  
AS
BEGIN
    
    SELECT  UserName, Password
    FROM Users
    WHERE UserID = @UserID;
END

GO
/****** Object:  StoredProcedure [dbo].[InsertItem]    Script Date: 2025-03-22 16:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertItem] (
@AuctionTitle nvarchar(100),
@AuctionDescription nvarchar(MAX),
@AuctionPrice decimal (18,2),
@StartTime datetime,
@EndTime datetime,
@Userid int,
@Image nvarchar(255)
)
as 
begin

insert into Auction (AuctionTitle, AuctionDescription, AuctionPrice, StartTime, EndTime, UserID, Image)
values (@AuctionTitle,@AuctionDescription, @AuctionPrice, @StartTime,@EndTime, @Userid, @Image)

end;
GO
/****** Object:  StoredProcedure [dbo].[SearchAuction]    Script Date: 2025-03-22 16:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SearchAuction](@Title nvarchar(100))
AS
BEGIN
    -- Hämta alla auktioner som matchar söksträngen i titel
    SELECT AuctionID, AuctionTitle, AuctionDescription, AuctionPrice, StartTime, EndTime, Image, u.UserID, UserName
    FROM Auction a
	INNER JOIN Users u ON u.UserID = a.UserID
    WHERE a.AuctionTitle like '%' + @Title + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateItem]    Script Date: 2025-03-22 16:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateItem]
(@AuctionID int,
@AuctionTitle nvarchar(100),
@AuctionDescription nvarchar(MAX),
@AuctionPrice decimal (18,2),
@StartTime datetime,
@EndTime datetime,
@Image nvarchar(255)
)
as 
begin

UPDATE Auction 
Set 
AuctionTitle = @AuctionTitle,
AuctionDescription = @AuctionDescription,
AuctionPrice = @AuctionPrice,
StartTime = @StartTime,
EndTime = @EndTime,
Image = @Image

WHERE AuctionID = @AuctionID


end
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 2025-03-22 16:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUser]
    @UserID INT,            
    @UserName NVARCHAR(50), 
    @Password NVARCHAR(50)
AS
BEGIN
    
    UPDATE Users
    SET UserName = @UserName, Password = @Password
    WHERE UserID = @UserID;
END

GO
USE [master]
GO
ALTER DATABASE [AuctionDB] SET  READ_WRITE 
GO
