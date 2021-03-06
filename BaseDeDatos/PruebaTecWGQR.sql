USE [PruebaTecWGQR]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 04/20/2013 23:23:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Usuarios](
	[Usuario] [nvarchar](50) NOT NULL,
	[Contrasenna] [nvarchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](50) NOT NULL,
	[Token] [nvarchar](50) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_BorrarToken]    Script Date: 04/20/2013 23:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_BorrarToken]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_BorrarToken]
	(
	@Token NVARCHAR(50)
	)

AS
	UPDATE Usuarios
	SET Token = NULL
	WHERE Token = @Token

' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarToken]    Script Date: 04/20/2013 23:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_ActualizarToken]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_ActualizarToken]
	(
	@Usuario NVARCHAR(50),
	@Token NVARCHAR(50)
	)

AS
	UPDATE Usuarios
	SET Token = @Token
	WHERE Usuario = @Usuario
	

' 
END
GO
/****** Object:  Default [DF_Usuarios_Perfil]    Script Date: 04/20/2013 23:23:42 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Usuarios_Perfil]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuarios]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Usuarios_Perfil]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_Perfil]  DEFAULT ((0)) FOR [Token]
END

/* INSERT de usuarios */
INSERT INTO [PruebaTecWGQR].[dbo].[Usuarios]([Usuario],[Contrasenna],[Nombre],[Apellidos],[Email],[Direccion],[Telefono])
VALUES('amunoz','amunoz','Alejandro','Munoz','amnoz@gmail.com','Cartago','8532-91-96')

INSERT INTO [PruebaTecWGQR].[dbo].[Usuarios]([Usuario],[Contrasenna],[Nombre],[Apellidos],[Email],[Direccion],[Telefono])
VALUES('wquiros','wquiros','Wendy','Quiros','wquiros@gmail.com','Cartago','8532-91-96')

End
GO
