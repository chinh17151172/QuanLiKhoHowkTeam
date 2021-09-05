USE [QuanLiKho]
GO
SET IDENTITY_INSERT [dbo].[Unit] ON 

INSERT [dbo].[Unit] ([Id], [DisplayName]) VALUES (1, N'Kg')
INSERT [dbo].[Unit] ([Id], [DisplayName]) VALUES (2, N'Thùng')
INSERT [dbo].[Unit] ([Id], [DisplayName]) VALUES (3, N'Bao')
SET IDENTITY_INSERT [dbo].[Unit] OFF
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (1, N'Suppiler 1 ', N'Address 1', N'0122033022', N'supplier1@gmail.com', NULL, CAST(N'2021-03-09T00:00:00.000' AS DateTime))
INSERT [dbo].[Supplier] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (2, N'Suppiler 2', N'Address 2', N'0909990023', N'supplier2@gmail.com', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO
INSERT [dbo].[Objects] ([Id], [DisplayName], [IdUnit], [IdSuplier], [QRCode], [BarCode]) VALUES (N'1', N'Xi măng', 3, 1, NULL, NULL)
INSERT [dbo].[Objects] ([Id], [DisplayName], [IdUnit], [IdSuplier], [QRCode], [BarCode]) VALUES (N'2', N'Gạch', 2, 2, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (1, N'Customer 1', N'Address 1', N'023232032', N'customer1@gmail.com', NULL, NULL)
INSERT [dbo].[Customer] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (2, N'Customer 2', N'Address 2', N'098923233', N'customer2@gmail.com', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
INSERT [dbo].[Output] ([Id], [DateOutput]) VALUES (N'1', CAST(N'2021-08-30T00:00:00.000' AS DateTime))
INSERT [dbo].[Output] ([Id], [DateOutput]) VALUES (N'2', CAST(N'2021-09-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Output] ([Id], [DateOutput]) VALUES (N'3', CAST(N'2021-09-02T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OutputInfo] ([Id], [IdObject], [IdOutputInfo], [IdCustomer], [Count], [Status]) VALUES (N'1', N'1', N'1', 1, 10, NULL)
INSERT [dbo].[OutputInfo] ([Id], [IdObject], [IdOutputInfo], [IdCustomer], [Count], [Status]) VALUES (N'2', N'2', N'1', 1, 200, NULL)
GO
INSERT [dbo].[Input] ([Id], [DateInput]) VALUES (N'1', CAST(N'2021-08-30T00:00:00.000' AS DateTime))
INSERT [dbo].[Input] ([Id], [DateInput]) VALUES (N'2', CAST(N'2021-09-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Input] ([Id], [DateInput]) VALUES (N'3', CAST(N'2021-09-02T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[InputInfo] ([Id], [IdObject], [IdInput], [Count], [InputPrice], [OutputPrice], [Status]) VALUES (N'1', N'1', N'1', 100, 200000, 500000, NULL)
INSERT [dbo].[InputInfo] ([Id], [IdObject], [IdInput], [Count], [InputPrice], [OutputPrice], [Status]) VALUES (N'2', N'2', N'1', 1000, 200, 500, NULL)
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [DisplayName]) VALUES (1, N'Admin')
INSERT [dbo].[UserRole] ([Id], [DisplayName]) VALUES (2, N'Staff')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [IdRole]) VALUES (1, N'Chinh Nguyen', N'Admin', N'db69fc039dcbd2962cb4d28f5891aae1', 1)
INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [IdRole]) VALUES (2, N'Nhân viên', N'Staff', N'978aae9bb6bee8fb75de3e4830a1be46', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
