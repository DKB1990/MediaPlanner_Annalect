USE [MediaPlannerDB]
GO
/****** Object:  Table [dbo].[Campaign]    Script Date: 17/12/2019 9:05:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Campaign](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](250) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Budget] [decimal](19, 6) NULL,
	[CountryId] [int] NULL,
	[ClientId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CampaignDetail]    Script Date: 17/12/2019 9:05:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CampaignDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CampaignId] [int] NULL,
	[SupplierId] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Budget] [decimal](19, 6) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Channel]    Script Date: 17/12/2019 9:05:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Channel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 17/12/2019 9:05:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 17/12/2019 9:05:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NULL,
	[Code] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 17/12/2019 9:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NULL,
	[ChannelId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Campaign] ON 

INSERT [dbo].[Campaign] ([Id], [Title], [StartDate], [EndDate], [Budget], [CountryId], [ClientId]) VALUES (1, N'Campaign_Dubai_DutyFree', NULL, NULL, CAST(3000.000000 AS Decimal(19, 6)), 1, 1)
SET IDENTITY_INSERT [dbo].[Campaign] OFF
SET IDENTITY_INSERT [dbo].[CampaignDetail] ON 

INSERT [dbo].[CampaignDetail] ([Id], [CampaignId], [SupplierId], [StartDate], [EndDate], [Budget]) VALUES (1, 1, 1, NULL, NULL, CAST(2320.000000 AS Decimal(19, 6)))
SET IDENTITY_INSERT [dbo].[CampaignDetail] OFF
SET IDENTITY_INSERT [dbo].[Channel] ON 

INSERT [dbo].[Channel] ([Id], [Name]) VALUES (1, N'Out-Of-Home')
INSERT [dbo].[Channel] ([Id], [Name]) VALUES (2, N'Digital')
INSERT [dbo].[Channel] ([Id], [Name]) VALUES (3, N'TV')
SET IDENTITY_INSERT [dbo].[Channel] OFF
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Id], [Name]) VALUES (1, N'OmniMediaGroup')
INSERT [dbo].[Client] ([Id], [Name]) VALUES (2, N'Emirates')
INSERT [dbo].[Client] ([Id], [Name]) VALUES (3, N'Noon.com')
INSERT [dbo].[Client] ([Id], [Name]) VALUES (4, N'FirstScreen')
INSERT [dbo].[Client] ([Id], [Name]) VALUES (5, N'Myntra')
INSERT [dbo].[Client] ([Id], [Name]) VALUES (6, N'Souq.com')
SET IDENTITY_INSERT [dbo].[Client] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([Id], [Name], [Code]) VALUES (1, N'United Arab Emirates', N'UAE')
INSERT [dbo].[Country] ([Id], [Name], [Code]) VALUES (2, N'United States', N'US')
INSERT [dbo].[Country] ([Id], [Name], [Code]) VALUES (3, N'Canada', N'CAD')
INSERT [dbo].[Country] ([Id], [Name], [Code]) VALUES (4, N'India', N'IN')
INSERT [dbo].[Country] ([Id], [Name], [Code]) VALUES (5, N'Singapore', N'SG')
INSERT [dbo].[Country] ([Id], [Name], [Code]) VALUES (6, N'Australia', N'AUS')
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([Id], [Name], [ChannelId]) VALUES (1, N'Facebook', 2)
INSERT [dbo].[Supplier] ([Id], [Name], [ChannelId]) VALUES (2, N'Instagram', 2)
INSERT [dbo].[Supplier] ([Id], [Name], [ChannelId]) VALUES (3, N'Twitter', 2)
INSERT [dbo].[Supplier] ([Id], [Name], [ChannelId]) VALUES (4, N'Gulf News', 2)
INSERT [dbo].[Supplier] ([Id], [Name], [ChannelId]) VALUES (5, N'MCB 1', 3)
INSERT [dbo].[Supplier] ([Id], [Name], [ChannelId]) VALUES (6, N'MCB 2', 3)
INSERT [dbo].[Supplier] ([Id], [Name], [ChannelId]) VALUES (7, N'MCB 3', 3)
INSERT [dbo].[Supplier] ([Id], [Name], [ChannelId]) VALUES (8, N'Billboard', 1)
SET IDENTITY_INSERT [dbo].[Supplier] OFF
ALTER TABLE [dbo].[Campaign]  WITH CHECK ADD FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Campaign]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[CampaignDetail]  WITH CHECK ADD FOREIGN KEY([CampaignId])
REFERENCES [dbo].[Campaign] ([Id])
GO
ALTER TABLE [dbo].[CampaignDetail]  WITH CHECK ADD FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([Id])
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD FOREIGN KEY([ChannelId])
REFERENCES [dbo].[Channel] ([Id])
GO
