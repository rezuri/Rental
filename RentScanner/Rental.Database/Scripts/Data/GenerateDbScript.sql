USE [Rental]
GO
/****** Object:  Table [dbo].[Property]    Script Date: 25/08/2015 9:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Property](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [char](10) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Suburb] [varchar](20) NOT NULL,
	[PostCode] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PropertyExpenditure]    Script Date: 25/08/2015 9:37:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PropertyExpenditure](
	[Id] [int] NOT NULL,
	[PropertyId] [int] NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[Cost] [decimal](8, 2) NOT NULL,
	[Notes] [varchar](max) NULL,
 CONSTRAINT [PK_PropertyExpenditure] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PropertyRent]    Script Date: 25/08/2015 9:37:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyRent](
	[Id] [int] NOT NULL,
	[PropertyId] [int] NOT NULL,
	[RentalPrice] [decimal](5, 2) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_PropertyRent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyTenant]    Script Date: 25/08/2015 9:37:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyTenant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NOT NULL,
	[TenantId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_PropertyTenant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tenant]    Script Date: 25/08/2015 9:37:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tenant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Tenant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TransactionCriteria]    Script Date: 25/08/2015 9:37:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[TransactionCriteria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NOT NULL,
	[Keyword] [varchar](50) NOT NULL,
	[IsExpenditure] [bit] NOT NULL,
	[IsRental] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TransactionCriteria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Property] ON 

INSERT [dbo].[Property] ([Id], [Number], [Address], [Suburb], [PostCode], [IsActive]) VALUES (1, N'114       ', N'Renou Street', N'East Cannington', 6107, 1)
INSERT [dbo].[Property] ([Id], [Number], [Address], [Suburb], [PostCode], [IsActive]) VALUES (2, N'67        ', N'Spring Road', N'Thornlie', 6108, 1)
SET IDENTITY_INSERT [dbo].[Property] OFF
SET IDENTITY_INSERT [dbo].[PropertyTenant] ON 

INSERT [dbo].[PropertyTenant] ([Id], [PropertyId], [TenantId], [IsActive]) VALUES (1, 1, 1, 1)
INSERT [dbo].[PropertyTenant] ([Id], [PropertyId], [TenantId], [IsActive]) VALUES (2, 1, 2, 1)
INSERT [dbo].[PropertyTenant] ([Id], [PropertyId], [TenantId], [IsActive]) VALUES (3, 2, 3, 1)
SET IDENTITY_INSERT [dbo].[PropertyTenant] OFF
SET IDENTITY_INSERT [dbo].[Tenant] ON 

INSERT [dbo].[Tenant] ([Id], [FirstName], [Surname], [IsActive]) VALUES (1, N'Ravinder', N'Kaur', 1)
INSERT [dbo].[Tenant] ([Id], [FirstName], [Surname], [IsActive]) VALUES (2, N'Budh', N'Singh', 1)
INSERT [dbo].[Tenant] ([Id], [FirstName], [Surname], [IsActive]) VALUES (3, N'Pania', N'Kiwara', 1)
SET IDENTITY_INSERT [dbo].[Tenant] OFF
SET IDENTITY_INSERT [dbo].[TransactionCriteria] ON 

INSERT [dbo].[TransactionCriteria] ([Id], [PropertyId], [Keyword], [IsExpenditure], [IsRental], [IsActive]) VALUES (1, 1, N'RAVINDER KAUR', 0, 1, 1)
INSERT [dbo].[TransactionCriteria] ([Id], [PropertyId], [Keyword], [IsExpenditure], [IsRental], [IsActive]) VALUES (2, 1, N'PAYMENT TO R.A.C.I.', 1, 0, 1)
SET IDENTITY_INSERT [dbo].[TransactionCriteria] OFF
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_Property] FOREIGN KEY([Id])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_Property]
GO
ALTER TABLE [dbo].[PropertyExpenditure]  WITH CHECK ADD  CONSTRAINT [FK_PropertyExpenditure_Property] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertyExpenditure] CHECK CONSTRAINT [FK_PropertyExpenditure_Property]
GO
ALTER TABLE [dbo].[PropertyRent]  WITH CHECK ADD  CONSTRAINT [FK_PropertyRent_Property] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertyRent] CHECK CONSTRAINT [FK_PropertyRent_Property]
GO
ALTER TABLE [dbo].[PropertyTenant]  WITH CHECK ADD  CONSTRAINT [FK_PropertyTenant_Property] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertyTenant] CHECK CONSTRAINT [FK_PropertyTenant_Property]
GO
ALTER TABLE [dbo].[PropertyTenant]  WITH CHECK ADD  CONSTRAINT [FK_PropertyTenant_Tenant] FOREIGN KEY([TenantId])
REFERENCES [dbo].[Tenant] ([Id])
GO
ALTER TABLE [dbo].[PropertyTenant] CHECK CONSTRAINT [FK_PropertyTenant_Tenant]
GO
ALTER TABLE [dbo].[TransactionCriteria]  WITH CHECK ADD  CONSTRAINT [FK_TransactionCriteria_Property] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[TransactionCriteria] CHECK CONSTRAINT [FK_TransactionCriteria_Property]
GO
