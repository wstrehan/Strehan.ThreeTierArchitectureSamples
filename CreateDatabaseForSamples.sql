CREATE DATABASE [Inventory]

GO

use [Inventory]

GO

CREATE LOGIN inventory_user
    WITH PASSWORD = 'abcdeft';

GO


CREATE USER inventory_user FOR login inventory_user;
GO 

CREATE SCHEMA [Stock]
GO

Grant Execute on Schema::Stock to inventory_user;

Go

/****** Object:  Table [Stock].[Color]    Script Date: 6/28/2018 6:53:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Stock].[Color](
	[ColorId] [smallint] IDENTITY(1,1) NOT NULL,
	[ColorName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED 
(
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Stock].[Gadget]    Script Date: 6/28/2018 6:53:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Stock].[Gadget](
	[GadgetId] [int] IDENTITY(1,1) NOT NULL,
	[GadgetName] [nvarchar](50) NOT NULL,
	[ColorId] [smallint] NOT NULL,
	[SizeId] [smallint] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[UpdatedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Stock.Gadgets] PRIMARY KEY CLUSTERED 
(
	[GadgetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Stock].[Size]    Script Date: 6/28/2018 6:53:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Stock].[Size](
	[SizeId] [smallint] IDENTITY(1,1) NOT NULL,
	[SizeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sizes] PRIMARY KEY CLUSTERED 
(
	[SizeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [Stock].[Gadget] ADD  CONSTRAINT [DF_Gadgets_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [Stock].[Gadget]  WITH CHECK ADD  CONSTRAINT [FK_Gadgets_Colors] FOREIGN KEY([ColorId])
REFERENCES [Stock].[Color] ([ColorId])
GO
ALTER TABLE [Stock].[Gadget] CHECK CONSTRAINT [FK_Gadgets_Colors]
GO
ALTER TABLE [Stock].[Gadget]  WITH CHECK ADD  CONSTRAINT [FK_Gadgets_Sizes] FOREIGN KEY([SizeId])
REFERENCES [Stock].[Size] ([SizeId])
GO
ALTER TABLE [Stock].[Gadget] CHECK CONSTRAINT [FK_Gadgets_Sizes]
GO
/****** Object:  StoredProcedure [Stock].[DeleteGadget]    Script Date: 6/28/2018 6:53:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Stock].[DeleteGadget]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE Gadget
	Set Deleted = 'true'
	Where GadgetId = @Id
END
GO
/****** Object:  StoredProcedure [Stock].[GetAllGadgets]    Script Date: 6/28/2018 6:53:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Stock].[GetAllGadgets]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT g.*, c.ColorName, s.SizeName FROM Stock.Gadget as g
	JOIN Stock.Color as c on g.ColorId = c.ColorId
	JOIN Stock.Size as s on G.SizeId = s.SizeId
	WHERE Deleted = 'false'
	ORDER BY UpdatedDateTime DESC
END
GO
/****** Object:  StoredProcedure [Stock].[GetColors]    Script Date: 6/28/2018 6:53:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Stock].[GetColors]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM Stock.Color
	ORDER BY ColorName 
END
GO
/****** Object:  StoredProcedure [Stock].[GetGadgetById]    Script Date: 6/28/2018 6:53:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Stock].[GetGadgetById]
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT g.*, c.ColorName, s.SizeName FROM Stock.Gadget as g
	JOIN Stock.Color as c on g.ColorId = c.ColorId
	JOIN Stock.Size as s on G.SizeId = s.SizeId
	WHERE GadgetId = @Id
END
GO
/****** Object:  StoredProcedure [Stock].[GetSizes]    Script Date: 6/28/2018 6:53:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Stock].[GetSizes]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM Stock.Size
END
GO
/****** Object:  StoredProcedure [Stock].[InsertGadget]    Script Date: 6/28/2018 6:53:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Stock].[InsertGadget]
	@GadgetName nvarchar(50),
	@ColorId smallint,
	@SizeId smallInt,
	@Id int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO Stock.Gadget
	(
		GadgetName,
		ColorId,
		SizeId,
		Deleted,
		CreatedDateTime,
		UpdatedDateTime
	)
	values
	(
		@GadgetName,
		@ColorId,
		@SizeId,
		DEFAULT,
		GetDate(),
		GetDate()
	)

	set @Id = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [Stock].[UnDeleteAllGadgets]    Script Date: 6/28/2018 6:53:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Stock].[UnDeleteAllGadgets]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE Gadget
	set Deleted = 'false'
END
GO
/****** Object:  StoredProcedure [Stock].[UpdateGadget]    Script Date: 6/28/2018 6:53:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Stock].[UpdateGadget]
	@Id int,
	@GadgetName nvarchar(50),
	@ColorId smallint,
	@SizeId smallInt
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE Stock.Gadget
	SET GadgetName = @GadgetName,
	ColorId = @ColorId,
	SizeId = @SizeId,
	UpdatedDateTime = GETDATE()
	Where GadgetId = @Id
END
GO


SET IDENTITY_INSERT [Stock].[Color] ON 
GO
INSERT [Stock].[Color] ([ColorId], [ColorName]) VALUES (1, N'Red')
GO
INSERT [Stock].[Color] ([ColorId], [ColorName]) VALUES (2, N'Green')
GO
INSERT [Stock].[Color] ([ColorId], [ColorName]) VALUES (3, N'Blue')
GO
INSERT [Stock].[Color] ([ColorId], [ColorName]) VALUES (4, N'Orange')
GO
INSERT [Stock].[Color] ([ColorId], [ColorName]) VALUES (5, N'Yellow')
GO
SET IDENTITY_INSERT [Stock].[Color] OFF
GO
SET IDENTITY_INSERT [Stock].[Size] ON 
GO
INSERT [Stock].[Size] ([SizeId], [SizeName]) VALUES (1, N'Small')
GO
INSERT [Stock].[Size] ([SizeId], [SizeName]) VALUES (2, N'Medium')
GO
INSERT [Stock].[Size] ([SizeId], [SizeName]) VALUES (3, N'Large')
GO
SET IDENTITY_INSERT [Stock].[Size] OFF
GO
