USE [Rehersal]
GO
/****** Object:  Table [dbo].[City]    Script Date: 06.10.2020 20:20:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](50) NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 06.10.2020 20:20:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[RehersalSpaceID] [int] NULL,
	[UserID] [int] NULL,
	[OrderNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 06.10.2020 20:20:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[RehersalRoomID] [int] NULL,
	[DateStart] [datetime] NULL,
	[DateEnd] [datetime] NULL,
	[Price] [money] NULL,
	[Comment] [nvarchar](500) NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RehersalSpase]    Script Date: 06.10.2020 20:20:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RehersalSpase](
	[RehersalSpaseID] [int] IDENTITY(1,1) NOT NULL,
	[RehersalSpaseName] [nvarchar](50) NULL,
	[CityID] [int] NULL,
	[Adress] [nvarchar](50) NULL,
 CONSTRAINT [PK_RehersalSpase] PRIMARY KEY CLUSTERED 
(
	[RehersalSpaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 06.10.2020 20:20:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RehersalRoomID] [int] IDENTITY(1,1) NOT NULL,
	[RehersalRoomName] [nchar](10) NULL,
	[RehersalRoomSize] [int] NULL,
	[RehersalSpaseID] [int] NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[RehersalRoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 06.10.2020 20:20:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserType] [smallint] NULL,
	[UserName] [nvarchar](50) NULL,
	[UserMail] [nvarchar](50) NULL,
	[UserPhone] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_RehersalSpase] FOREIGN KEY([RehersalSpaceID])
REFERENCES [dbo].[RehersalSpase] ([RehersalSpaseID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_RehersalSpase]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Room] FOREIGN KEY([RehersalRoomID])
REFERENCES [dbo].[Room] ([RehersalRoomID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Room]
GO
ALTER TABLE [dbo].[RehersalSpase]  WITH CHECK ADD  CONSTRAINT [FK_RehersalSpase_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[City] ([CityID])
GO
ALTER TABLE [dbo].[RehersalSpase] CHECK CONSTRAINT [FK_RehersalSpase_City]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RehersalSpase] FOREIGN KEY([RehersalSpaseID])
REFERENCES [dbo].[RehersalSpase] ([RehersalSpaseID])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_RehersalSpase]
GO
