USE [BoothManages]
GO
/****** Object:  Table [dbo].[BooAucalnfo]    Script Date: 2020/6/20 10:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BooAucalnfo](
	[Id] [uniqueidentifier] NOT NULL,
	[BooId] [uniqueidentifier] NULL,
	[CreateTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[CashMoney] [money] NULL,
	[StartMoney] [money] NULL,
	[MarkUpMoney] [money] NULL,
	[ResMoney] [money] NULL,
	[DefTime] [datetime] NULL,
	[WinnerUser] [varchar](50) NULL,
	[FinishPrice] [money] NULL,
	[OrderState] [varchar](3) NULL,
	[CashMoneyState] [varchar](2) NULL,
	[BooAucaState] [varchar](2) NULL,
 CONSTRAINT [PK_BOOAUCALNFO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BooInfo]    Script Date: 2020/6/20 10:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BooInfo](
	[Id] [uniqueidentifier] NOT NULL,
	[Boo_Title] [varchar](50) NULL,
	[Boo_No] [varchar](4) NULL,
	[Mark_Id] [uniqueidentifier] NULL,
	[Boo_Area] [int] NULL,
	[Boo_Len] [int] NULL,
	[Boo_Wid] [int] NULL,
	[Boo_Label] [varbinary](50) NULL,
	[Boo_Rent] [money] NULL,
	[Boo_Dead] [int] NULL,
	[Less_Id] [uniqueidentifier] NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[IsEnable] [varchar](3) NULL,
 CONSTRAINT [PK_BOOINFO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[City]    Script Date: 2020/6/20 10:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] NOT NULL,
	[PId] [int] NULL,
	[CityName] [varchar](255) NULL,
	[CType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ConTastInfo]    Script Date: 2020/6/20 10:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ConTastInfo](
	[Id] [uniqueidentifier] NOT NULL,
	[ConNo] [varchar](50) NULL,
	[OId] [uniqueidentifier] NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_CONTASTINFO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MarketInfo]    Script Date: 2020/6/20 10:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MarketInfo](
	[Id] [uniqueidentifier] NOT NULL,
	[Mark_Name] [varchar](50) NULL,
	[Mark_Phone] [varchar](11) NULL,
	[Mark_AccName] [varchar](50) NULL,
	[Mark_Address] [varchar](max) NULL,
	[Mark_SortId] [int] NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[IsEnable] [varchar](2) NULL,
 CONSTRAINT [PK_MARKETINFO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MemberInfoo]    Script Date: 2020/6/20 10:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MemberInfoo](
	[Id] [uniqueidentifier] NOT NULL,
	[Mem_Name] [varchar](50) NULL,
	[Mem_WX] [varchar](50) NULL,
	[Mem_Address] [varchar](100) NULL,
	[Mem_State] [varchar](2) NULL,
	[IsAllow] [varchar](2) NULL,
 CONSTRAINT [PK_MEMBERINFOO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderInfo]    Script Date: 2020/6/20 10:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderInfo](
	[Id] [uniqueidentifier] NOT NULL,
	[OrderNo] [varchar](50) NULL,
	[Mark_Id] [uniqueidentifier] NULL,
	[BooAucaId] [uniqueidentifier] NULL,
	[UserId] [uniqueidentifier] NULL,
	[RenPrice] [money] NULL,
	[CashMoney] [money] NULL,
	[Teancy] [varchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[PayState] [varchar](2) NULL,
	[OrderState] [varchar](2) NULL,
 CONSTRAINT [PK_ORDERINFO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rbac_Admin]    Script Date: 2020/6/20 10:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rbac_Admin](
	[Id] [uniqueidentifier] NOT NULL,
	[Acc_Name] [varchar](50) NULL,
	[Acc_Num] [varchar](50) NULL,
	[Acc_Pass] [varchar](50) NULL,
	[Acc_Phone] [varchar](11) NULL,
	[Acc_Img] [varchar](200) NULL,
	[DeptId] [uniqueidentifier] NULL,
	[RoleId] [uniqueidentifier] NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[IsEnable] [varchar](2) NULL,
 CONSTRAINT [PK_RBAC_ADMIN] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rbac_DeptPart]    Script Date: 2020/6/20 10:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rbac_DeptPart](
	[Id] [uniqueidentifier] NOT NULL,
	[Dept_Name] [varchar](50) NULL,
	[Dept_Desc] [varchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[IsEnable] [varchar](2) NULL,
 CONSTRAINT [PK_RBAC_DEPTPART] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rbac_Power]    Script Date: 2020/6/20 10:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rbac_Power](
	[Id] [uniqueidentifier] NOT NULL,
	[Power_Name] [varchar](50) NULL,
 CONSTRAINT [PK_RBAC_POWER] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rbac_PowerAndRole]    Script Date: 2020/6/20 10:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rbac_PowerAndRole](
	[Id] [uniqueidentifier] NOT NULL,
	[PowerId] [varchar](50) NULL,
	[RoleId] [varchar](50) NULL,
 CONSTRAINT [PK_RBAC_POWERANDROLE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rbac_RoleInfo]    Script Date: 2020/6/20 10:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rbac_RoleInfo](
	[Id] [uniqueidentifier] NOT NULL,
	[Role_Name] [varchar](50) NULL,
	[Role_Desc] [varchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[IsEnable] [varchar](2) NULL,
 CONSTRAINT [PK_RBAC_ROLEINFO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RecordInfo]    Script Date: 2020/6/20 10:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RecordInfo](
	[Id] [uniqueidentifier] NOT NULL,
	[AccId] [uniqueidentifier] NULL,
	[Ip_Address] [varchar](20) NULL,
	[UpdateTime] [datetime] NULL,
	[Record] [varchar](50) NULL,
 CONSTRAINT [PK_RECORDINFO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 2020/6/20 10:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserInfo](
	[Id] [uniqueidentifier] NOT NULL,
	[User_Name] [varchar](50) NULL,
	[User_Pass] [varchar](50) NULL,
	[User_Phone] [varchar](11) NULL,
	[MemerId] [uniqueidentifier] NULL,
	[User_Address] [varchar](100) NULL,
	[User_State] [varchar](2) NULL,
	[User_Img] [varchar](50) NULL,
 CONSTRAINT [PK_USERINFO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[BooAucalnfo] ([Id], [BooId], [CreateTime], [EndTime], [CashMoney], [StartMoney], [MarkUpMoney], [ResMoney], [DefTime], [WinnerUser], [FinishPrice], [OrderState], [CashMoneyState], [BooAucaState]) VALUES (N'd72c6b2e-d0eb-4b8a-a388-846eeeb09c75', N'62e84a5f-8754-47f7-9fa9-249c5149ae81', CAST(0x0000ABE000A89A80 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[BooInfo] ([Id], [Boo_Title], [Boo_No], [Mark_Id], [Boo_Area], [Boo_Len], [Boo_Wid], [Boo_Label], [Boo_Rent], [Boo_Dead], [Less_Id], [CreateTime], [UpdateTime], [IsEnable]) VALUES (N'62e84a5f-8754-47f7-9fa9-249c5149ae81', NULL, NULL, N'd86cd85e-8fad-47e0-b1e7-294864403f99', NULL, NULL, NULL, NULL, NULL, NULL, N'35427841-0c05-4a26-904d-f79cc3392e4b', NULL, NULL, NULL)
INSERT [dbo].[MarketInfo] ([Id], [Mark_Name], [Mark_Phone], [Mark_AccName], [Mark_Address], [Mark_SortId], [CreateTime], [UpdateTime], [IsEnable]) VALUES (N'd86cd85e-8fad-47e0-b1e7-294864403f99', N'1', N'1', N'1', N'1', 1, CAST(0x0000ABE000A7E3B0 AS DateTime), CAST(0x0000ABE000A7E734 AS DateTime), N'1')
INSERT [dbo].[OrderInfo] ([Id], [OrderNo], [Mark_Id], [BooAucaId], [UserId], [RenPrice], [CashMoney], [Teancy], [CreateTime], [EndTime], [PayState], [OrderState]) VALUES (N'd022f48c-4804-4a9e-8d82-46a6a6cfb7e6', N'2354678654', N'd86cd85e-8fad-47e0-b1e7-294864403f99', N'd72c6b2e-d0eb-4b8a-a388-846eeeb09c75', N'35427841-0c05-4a26-904d-f79cc3392e4b', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserInfo] ([Id], [User_Name], [User_Pass], [User_Phone], [MemerId], [User_Address], [User_State], [User_Img]) VALUES (N'35427841-0c05-4a26-904d-f79cc3392e4b', N'1', N'1', NULL, NULL, NULL, NULL, NULL)
ALTER TABLE [dbo].[BooAucalnfo] ADD  CONSTRAINT [DF_BooAucalnfo_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[BooInfo] ADD  CONSTRAINT [DF_BooInfo_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[City] ADD  DEFAULT ('0') FOR [Id]
GO
ALTER TABLE [dbo].[City] ADD  DEFAULT (NULL) FOR [PId]
GO
ALTER TABLE [dbo].[City] ADD  DEFAULT (NULL) FOR [CType]
GO
ALTER TABLE [dbo].[ConTastInfo] ADD  CONSTRAINT [DF_ConTastInfo_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[MarketInfo] ADD  CONSTRAINT [DF_MarketInfo_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[MemberInfoo] ADD  CONSTRAINT [DF_MemberInfoo_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[OrderInfo] ADD  CONSTRAINT [DF_OrderInfo_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Rbac_Admin] ADD  CONSTRAINT [DF_Rbac_Admin_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Rbac_DeptPart] ADD  CONSTRAINT [DF_Rbac_DeptPart_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Rbac_Power] ADD  CONSTRAINT [DF_Rbac_Power_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Rbac_PowerAndRole] ADD  CONSTRAINT [DF_Rbac_PowerAndRole_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Rbac_RoleInfo] ADD  CONSTRAINT [DF_Rbac_RoleInfo_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[RecordInfo] ADD  CONSTRAINT [DF_RecordInfo_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_Id]  DEFAULT (newid()) FOR [Id]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'摊位竞拍Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BooAucalnfo', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'摊位Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BooAucalnfo', @level2type=N'COLUMN',@level2name=N'BooId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BooAucalnfo', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BooAucalnfo', @level2type=N'COLUMN',@level2name=N'EndTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保证金' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BooAucalnfo', @level2type=N'COLUMN',@level2name=N'CashMoney'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'起拍价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BooAucalnfo', @level2type=N'COLUMN',@level2name=N'StartMoney'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'加价幅度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BooAucalnfo', @level2type=N'COLUMN',@level2name=N'MarkUpMoney'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保留价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BooAucalnfo', @level2type=N'COLUMN',@level2name=N'ResMoney'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'延迟周期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BooAucalnfo', @level2type=N'COLUMN',@level2name=N'DefTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'中标用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BooAucalnfo', @level2type=N'COLUMN',@level2name=N'WinnerUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成交价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BooAucalnfo', @level2type=N'COLUMN',@level2name=N'FinishPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BooAucalnfo', @level2type=N'COLUMN',@level2name=N'OrderState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保证金' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BooAucalnfo', @level2type=N'COLUMN',@level2name=N'CashMoneyState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BooAucalnfo', @level2type=N'COLUMN',@level2name=N'BooAucaState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'合同Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ConTastInfo', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'合同编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ConTastInfo', @level2type=N'COLUMN',@level2name=N'ConNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单列表Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ConTastInfo', @level2type=N'COLUMN',@level2name=N'OId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上传时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ConTastInfo', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ConTastInfo', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MemberInfoo', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MemberInfoo', @level2type=N'COLUMN',@level2name=N'Mem_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MemberInfoo', @level2type=N'COLUMN',@level2name=N'Mem_WX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MemberInfoo', @level2type=N'COLUMN',@level2name=N'Mem_Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MemberInfoo', @level2type=N'COLUMN',@level2name=N'Mem_State'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否允许访问' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MemberInfoo', @level2type=N'COLUMN',@level2name=N'IsAllow'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'OrderNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'摊位竞拍Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'BooAucaId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租赁金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'RenPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保证金' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'CashMoney'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'Teancy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'EndTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'PayState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'User_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'User_Pass'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'User_Phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联会员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'MemerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'User_Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'User_State'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'头像' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'User_Img'
GO
