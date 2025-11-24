USE [NZWalksDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 24-11-2025 4.16.40 PM ******/
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
/****** Object:  Table [dbo].[difficulties]    Script Date: 24-11-2025 4.16.40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[difficulties](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_difficulties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[regions]    Script Date: 24-11-2025 4.16.40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[regions](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[RegionImageUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_regions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[walks]    Script Date: 24-11-2025 4.16.40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[walks](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[LengthInKm] [float] NOT NULL,
	[WalkImageUrl] [nvarchar](max) NULL,
	[RegionId] [uniqueidentifier] NOT NULL,
	[DifficultyId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_walks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20251120093251_InitialMigration', N'9.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20251123090833_Sedding Data Difficulty and regions', N'9.0.0')
GO
INSERT [dbo].[difficulties] ([Id], [Name]) VALUES (N'f808ddcd-b5e5-4d80-b732-1ca523e48434', N'Hard')
GO
INSERT [dbo].[difficulties] ([Id], [Name]) VALUES (N'54466f17-02af-48e7-8ed3-5a4a8bfacf6f', N'Easy')
GO
INSERT [dbo].[difficulties] ([Id], [Name]) VALUES (N'ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c', N'Medium')
GO
INSERT [dbo].[regions] ([Id], [Code], [Name], [RegionImageUrl]) VALUES (N'906cb139-415a-4bbb-a174-1a1faf9fb1f6', N'NSN', N'Nelson', N'https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1')
GO
INSERT [dbo].[regions] ([Id], [Code], [Name], [RegionImageUrl]) VALUES (N'f7248fc3-2585-4efb-8d1d-1c555f4087f6', N'AKL', N'Auckland', N'https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1')
GO
INSERT [dbo].[regions] ([Id], [Code], [Name], [RegionImageUrl]) VALUES (N'14ceba71-4b51-4777-9b17-46602cf66153', N'BOP', N'Bay Of Plenty', NULL)
GO
INSERT [dbo].[regions] ([Id], [Code], [Name], [RegionImageUrl]) VALUES (N'6884f7d7-ad1f-4101-8df3-7a6fa7387d81', N'NTL', N'Northland', NULL)
GO
INSERT [dbo].[regions] ([Id], [Code], [Name], [RegionImageUrl]) VALUES (N'f077a22e-4248-4bf6-b564-c7cf4e250263', N'STL', N'Southland', NULL)
GO
INSERT [dbo].[regions] ([Id], [Code], [Name], [RegionImageUrl]) VALUES (N'cfa06ed2-bf65-4b65-93ed-c9d286ddb0de', N'WGN', N'Wellington', N'https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1')
GO
INSERT [dbo].[walks] ([Id], [Name], [Description], [LengthInKm], [WalkImageUrl], [RegionId], [DifficultyId]) VALUES (N'1cc5f2bc-ff4b-47c0-a475-1add56c6497b', N'Makara Beach Walkway', N'This walk takes you along the coastline of Makara Beach...', 8.2, N'https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg', N'cfa06ed2-bf65-4b65-93ed-c9d286ddb0de', N'ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c')
GO
INSERT [dbo].[walks] ([Id], [Name], [Description], [LengthInKm], [WalkImageUrl], [RegionId], [DifficultyId]) VALUES (N'f2b56c63-eb99-475a-881c-278f3da03e3d', N'Kepler Track', N'Famous Fiordland alpine walk...', 32, N'https://images.pexels.com/photos/2226900/pexels-photo-2226900.jpeg', N'f077a22e-4248-4bf6-b564-c7cf4e250263', N'f808ddcd-b5e5-4d80-b732-1ca523e48434')
GO
INSERT [dbo].[walks] ([Id], [Name], [Description], [LengthInKm], [WalkImageUrl], [RegionId], [DifficultyId]) VALUES (N'43132402-3d5e-467a-8cde-351c5c7c5dde', N'Centre of NZ Walkway', N'Walk to the centre of New Zealand...', 1, N'https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg', N'906cb139-415a-4bbb-a174-1a1faf9fb1f6', N'ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c')
GO
INSERT [dbo].[walks] ([Id], [Name], [Description], [LengthInKm], [WalkImageUrl], [RegionId], [DifficultyId]) VALUES (N'f7578324-f025-4c86-83a9-37a7f3d8fe81', N'Cornwall Park Walk', N'Explore Cornwall Park...', 3, N'https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg', N'f7248fc3-2585-4efb-8d1d-1c555f4087f6', N'54466f17-02af-48e7-8ed3-5a4a8bfacf6f')
GO
INSERT [dbo].[walks] ([Id], [Name], [Description], [LengthInKm], [WalkImageUrl], [RegionId], [DifficultyId]) VALUES (N'30d654c7-89ac-4704-8333-5065b740150b', N'Mount Eden Summit Walk', N'Takes you to the summit of Mount Eden...', 2, N'https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg', N'f7248fc3-2585-4efb-8d1d-1c555f4087f6', N'54466f17-02af-48e7-8ed3-5a4a8bfacf6f')
GO
INSERT [dbo].[walks] ([Id], [Name], [Description], [LengthInKm], [WalkImageUrl], [RegionId], [DifficultyId]) VALUES (N'2d9d6604-bef9-4b0a-805d-630240a29595', N'Papamoa Hills Walk', N'Panoramic views of Tauranga...', 5, N'https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg', N'14ceba71-4b51-4777-9b17-46602cf66153', N'ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c')
GO
INSERT [dbo].[walks] ([Id], [Name], [Description], [LengthInKm], [WalkImageUrl], [RegionId], [DifficultyId]) VALUES (N'a7796ab6-5426-46af-b755-65d9b9e12978', N'Hump Ridge Track', N'Fiordland coastline multi-day walk...', 60, N'https://images.pexels.com/photos/2226900/pexels-photo-2226900.jpeg', N'f077a22e-4248-4bf6-b564-c7cf4e250263', N'f808ddcd-b5e5-4d80-b732-1ca523e48434')
GO
INSERT [dbo].[walks] ([Id], [Name], [Description], [LengthInKm], [WalkImageUrl], [RegionId], [DifficultyId]) VALUES (N'1ea0b064-2d44-4324-91ee-6dd86c91b713', N'Maitai Valley Walk', N'Explore Maitai Valley...', 5, N'https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg', N'906cb139-415a-4bbb-a174-1a1faf9fb1f6', N'ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c')
GO
INSERT [dbo].[walks] ([Id], [Name], [Description], [LengthInKm], [WalkImageUrl], [RegionId], [DifficultyId]) VALUES (N'327aa9f7-26f7-4ddb-8047-97464374bb63', N'Mount Victoria Loop', N'This scenic walk takes you around Mount Victoria...', 3.5, N'https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg', N'cfa06ed2-bf65-4b65-93ed-c9d286ddb0de', N'54466f17-02af-48e7-8ed3-5a4a8bfacf6f')
GO
INSERT [dbo].[walks] ([Id], [Name], [Description], [LengthInKm], [WalkImageUrl], [RegionId], [DifficultyId]) VALUES (N'04ab77f0-e145-4fbf-b641-989df24e5573', N'Boulder Bank Walkway', N'Coastal walk along Boulder Bank...', 8, N'https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg', N'906cb139-415a-4bbb-a174-1a1faf9fb1f6', N'f808ddcd-b5e5-4d80-b732-1ca523e48434')
GO
INSERT [dbo].[walks] ([Id], [Name], [Description], [LengthInKm], [WalkImageUrl], [RegionId], [DifficultyId]) VALUES (N'b5aa2791-3616-4db6-ab33-c54d03d17f62', N'Mount Maunganui Summit Walk', N'Summit walk with ocean views...', 3, N'https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg', N'14ceba71-4b51-4777-9b17-46602cf66153', N'ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c')
GO
INSERT [dbo].[walks] ([Id], [Name], [Description], [LengthInKm], [WalkImageUrl], [RegionId], [DifficultyId]) VALUES (N'24ef9346-17e2-467e-bfc0-d062a9042bf1', N'Bluff Hill Walkway', N'Walk to the top of Bluff Hill...', 6, N'https://images.pexels.com/photos/2226900/pexels-photo-2226900.jpeg', N'f077a22e-4248-4bf6-b564-c7cf4e250263', N'ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c')
GO
INSERT [dbo].[walks] ([Id], [Name], [Description], [LengthInKm], [WalkImageUrl], [RegionId], [DifficultyId]) VALUES (N'135a6e58-969f-47e1-8278-d7fbf2b3bd69', N'White Pine Bush Track', N'White Pine Bush easy nature walk...', 2, N'https://images.pexels.com/photos/808466/pexels-photo-808466.jpeg', N'14ceba71-4b51-4777-9b17-46602cf66153', N'ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c')
GO
INSERT [dbo].[walks] ([Id], [Name], [Description], [LengthInKm], [WalkImageUrl], [RegionId], [DifficultyId]) VALUES (N'09601132-f92d-457c-b47e-da90e117b33c', N'Botanic Garden Walk', N'Explore the beautiful Botanic Garden...', 2, N'https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg', N'cfa06ed2-bf65-4b65-93ed-c9d286ddb0de', N'54466f17-02af-48e7-8ed3-5a4a8bfacf6f')
GO
INSERT [dbo].[walks] ([Id], [Name], [Description], [LengthInKm], [WalkImageUrl], [RegionId], [DifficultyId]) VALUES (N'bdf28703-6d0e-4822-ad8b-e2923f4e95a2', N'Takapuna to Milford Coastal Walk', N'Coastal walk along Takapuna and Milford...', 5, N'https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg', N'f7248fc3-2585-4efb-8d1d-1c555f4087f6', N'ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c')
GO
ALTER TABLE [dbo].[walks]  WITH CHECK ADD  CONSTRAINT [FK_walks_difficulties_DifficultyId] FOREIGN KEY([DifficultyId])
REFERENCES [dbo].[difficulties] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[walks] CHECK CONSTRAINT [FK_walks_difficulties_DifficultyId]
GO
ALTER TABLE [dbo].[walks]  WITH CHECK ADD  CONSTRAINT [FK_walks_regions_RegionId] FOREIGN KEY([RegionId])
REFERENCES [dbo].[regions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[walks] CHECK CONSTRAINT [FK_walks_regions_RegionId]
GO
