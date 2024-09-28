USE [PosDb4]
GO
SET IDENTITY_INSERT [dbo].[TipoMovimiento] ON 

INSERT [dbo].[TipoMovimiento] ([Id], [Nombre], [FechaCreacion], [Borrado]) VALUES (1, N'Entrada', CAST(N'2018-09-07 02:13:35.777' AS DateTime), 0)
INSERT [dbo].[TipoMovimiento] ([Id], [Nombre], [FechaCreacion], [Borrado]) VALUES (2, N'Salida', CAST(N'2018-09-07 02:13:35.777' AS DateTime), 0)
INSERT [dbo].[TipoMovimiento] ([Id], [Nombre], [FechaCreacion], [Borrado]) VALUES (3, N'Devolucion', CAST(N'2018-09-07 02:13:35.777' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[TipoMovimiento] OFF
SET IDENTITY_INSERT [dbo].[TipoPago] ON 

INSERT [dbo].[TipoPago] ([Id], [Name], [FechaCreacion], [Borrado]) VALUES (1, N'Credito', CAST(N'2018-09-07 01:31:04.187' AS DateTime), 0)
INSERT [dbo].[TipoPago] ([Id], [Name], [FechaCreacion], [Borrado]) VALUES (2, N'Debito', CAST(N'2018-09-07 01:31:17.897' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[TipoPago] OFF
SET IDENTITY_INSERT [dbo].[TipoTransaccion] ON 

INSERT [dbo].[TipoTransaccion] ([Id], [Nombre], [FechaCreacion], [Borrado]) VALUES (1, N'Efectivo', CAST(N'2018-09-07 01:37:03.327' AS DateTime), 0)
INSERT [dbo].[TipoTransaccion] ([Id], [Nombre], [FechaCreacion], [Borrado]) VALUES (2, N'Cheques', CAST(N'2018-09-07 01:37:03.327' AS DateTime), 0)
INSERT [dbo].[TipoTransaccion] ([Id], [Nombre], [FechaCreacion], [Borrado]) VALUES (3, N'Tarjeta', CAST(N'2018-09-07 01:37:03.327' AS DateTime), 0)
INSERT [dbo].[TipoTransaccion] ([Id], [Nombre], [FechaCreacion], [Borrado]) VALUES (4, N'Cupones', CAST(N'2018-09-07 01:37:03.327' AS DateTime), 0)
INSERT [dbo].[TipoTransaccion] ([Id], [Nombre], [FechaCreacion], [Borrado]) VALUES (5, N'TarjetayEfectivo', CAST(N'2018-09-07 01:37:03.327' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[TipoTransaccion] OFF
