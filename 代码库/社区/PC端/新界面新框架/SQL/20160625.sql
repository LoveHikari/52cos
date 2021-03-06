USE [master]
GO
/****** Object:  Database [Basics]    Script Date: 06/25/2016 16:36:41 ******/
CREATE DATABASE [Basics] ON  PRIMARY 
( NAME = N'Basics', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Basics.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Basics_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Basics_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Basics] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Basics].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Basics] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Basics] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Basics] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Basics] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Basics] SET ARITHABORT OFF
GO
ALTER DATABASE [Basics] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Basics] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Basics] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Basics] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Basics] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Basics] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Basics] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Basics] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Basics] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Basics] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Basics] SET  DISABLE_BROKER
GO
ALTER DATABASE [Basics] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Basics] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Basics] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Basics] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Basics] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Basics] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Basics] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Basics] SET  READ_WRITE
GO
ALTER DATABASE [Basics] SET RECOVERY FULL
GO
ALTER DATABASE [Basics] SET  MULTI_USER
GO
ALTER DATABASE [Basics] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Basics] SET DB_CHAINING OFF
GO
USE [Basics]
GO
/****** Object:  Table [dbo].[sns_works]    Script Date: 06/25/2016 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sns_works](
	[WorksId] [int] IDENTITY(1,1) NOT NULL,
	[User_id] [varchar](50) NOT NULL,
	[WorksTitle] [text] NOT NULL,
	[WorksType] [varchar](50) NULL,
	[Type2] [varchar](50) NULL,
	[OriginaWorks] [varchar](50) NULL,
	[OriginaRole] [varchar](50) NULL,
	[coser] [varchar](50) NULL,
	[Photography] [varchar](50) NULL,
	[Makeup] [varchar](50) NULL,
	[Late] [varchar](50) NULL,
	[Third] [varchar](50) NULL,
	[Painter] [varchar](50) NULL,
	[LabelDesc] [varchar](50) NULL,
	[WorksContent] [text] NULL,
	[Root] [varchar](1) NOT NULL,
	[Keep] [varchar](1) NOT NULL,
	[Watermark] [varchar](1) NOT NULL,
	[ReleaseTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[GoodNo] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[reward] [int] NOT NULL,
	[cover] [varchar](50) NULL,
	[worksExcerpt] [text] NULL,
	[source] [varchar](50) NOT NULL,
	[sourceUrl] [varchar](50) NULL,
 CONSTRAINT [PK_sns_ordinaryNote] PRIMARY KEY CLUSTERED 
(
	[WorksId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发帖人id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'User_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'WorksTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'WorksType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品二级类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'Type2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原作品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'OriginaWorks'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原角色' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'OriginaRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'coser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'coser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'摄影' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'Photography'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'化妆' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'Makeup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'后期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'Late'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'协力' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'Third'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'画师' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'Painter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标签描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'LabelDesc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'WorksContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限设置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'Root'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'允许保存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'Keep'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加水印' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'Watermark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'ReleaseTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'被赞数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'GoodNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'启用状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'打赏' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'reward'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'封面' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'cover'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品摘要' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'worksExcerpt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'来源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'source'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'来源网址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_works', @level2type=N'COLUMN',@level2name=N'sourceUrl'
GO
/****** Object:  Table [dbo].[sns_workImg]    Script Date: 06/25/2016 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sns_workImg](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[workId] [varchar](50) NOT NULL,
	[ImgId] [varchar](50) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_sns_noteImg] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sns_userGood]    Script Date: 06/25/2016 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sns_userGood](
	[GoodId] [uniqueidentifier] NOT NULL,
	[User_id] [nvarchar](50) NOT NULL,
	[NoteId] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_sns_userGood] PRIMARY KEY CLUSTERED 
(
	[GoodId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sns_transactions]    Script Date: 06/25/2016 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sns_transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](50) NOT NULL,
	[NotifyTime] [datetime] NOT NULL,
	[NotifyType] [varchar](50) NOT NULL,
	[NotifyId] [varchar](50) NOT NULL,
	[SignType] [varchar](50) NOT NULL,
	[Sign] [varchar](50) NOT NULL,
	[OutTradeNo] [varchar](64) NULL,
	[Subject] [varchar](256) NULL,
	[PaymentType] [varchar](4) NULL,
	[TradeNo] [varchar](64) NULL,
	[TradeStatus] [varchar](50) NULL,
	[GmtCreate] [datetime] NULL,
	[GmtPayment] [datetime] NULL,
	[GmtClose] [datetime] NULL,
	[SellerEmail] [varchar](100) NULL,
	[SellerId] [varchar](30) NULL,
	[BuyerEmail] [varchar](100) NULL,
	[BuyerId] [varchar](30) NULL,
	[TotalFee] [varchar](50) NULL,
	[Body] [varchar](1000) NULL,
	[Discount] [varchar](50) NULL,
	[BusinessScene] [varchar](50) NULL,
	[ExtraCommonParam] [text] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_sns_transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通知时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'NotifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通知类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'NotifyType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通知校验ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'NotifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'签名方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'SignType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'签名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'Sign'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户网站唯一订单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'OutTradeNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'Subject'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'PaymentType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付宝交易号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'TradeNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'TradeStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'GmtCreate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易付款时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'GmtPayment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易关闭时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'GmtClose'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家支付宝账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'SellerEmail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家支付宝账户号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'SellerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'买家支付宝账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'BuyerEmail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'买家支付宝账户号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'BuyerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'TotalFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'Body'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'折扣' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'Discount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否扫码支付' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'BusinessScene'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公用回传参数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_transactions', @level2type=N'COLUMN',@level2name=N'ExtraCommonParam'
GO
/****** Object:  Table [dbo].[sns_smallImg]    Script Date: 06/25/2016 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sns_smallImg](
	[ImgId] [int] IDENTITY(1,1) NOT NULL,
	[ImgUrl] [varchar](50) NOT NULL,
	[addtime] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_sns_smallImg] PRIMARY KEY CLUSTERED 
(
	[ImgId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_smallImg', @level2type=N'COLUMN',@level2name=N'ImgUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_smallImg', @level2type=N'COLUMN',@level2name=N'addtime'
GO
/****** Object:  Table [dbo].[sns_reward]    Script Date: 06/25/2016 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sns_reward](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[User_id] [varchar](50) NULL,
	[worksId] [varchar](50) NULL,
	[rewardMoney] [int] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_sns_reward] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sns_reply]    Script Date: 06/25/2016 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sns_reply](
	[ReplyId] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](50) NULL,
	[workId] [varchar](50) NULL,
	[User_id] [varchar](50) NULL,
	[ReplyContent] [text] NULL,
	[ReleaseTime] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_sns_reply] PRIMARY KEY CLUSTERED 
(
	[ReplyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_reply', @level2type=N'COLUMN',@level2name=N'type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_reply', @level2type=N'COLUMN',@level2name=N'workId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_reply', @level2type=N'COLUMN',@level2name=N'User_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回复内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_reply', @level2type=N'COLUMN',@level2name=N'ReplyContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回复时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_reply', @level2type=N'COLUMN',@level2name=N'ReleaseTime'
GO
/****** Object:  Table [dbo].[sns_rechargeRecord]    Script Date: 06/25/2016 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sns_rechargeRecord](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](50) NOT NULL,
	[source] [varchar](50) NOT NULL,
	[RMB] [varchar](50) NOT NULL,
	[Cnbi] [varchar](50) NOT NULL,
	[addTime] [datetime] NULL,
	[OrderNo] [varchar](50) NOT NULL,
	[OrderName] [varchar](50) NOT NULL,
	[wareDesc] [varchar](50) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_sns_rechargeRecord] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_rechargeRecord', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变更来源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_rechargeRecord', @level2type=N'COLUMN',@level2name=N'source'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人民币' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_rechargeRecord', @level2type=N'COLUMN',@level2name=N'RMB'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'折算的CN币' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_rechargeRecord', @level2type=N'COLUMN',@level2name=N'Cnbi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_rechargeRecord', @level2type=N'COLUMN',@level2name=N'addTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_rechargeRecord', @level2type=N'COLUMN',@level2name=N'OrderNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_rechargeRecord', @level2type=N'COLUMN',@level2name=N'OrderName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品描述
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_rechargeRecord', @level2type=N'COLUMN',@level2name=N'wareDesc'
GO
/****** Object:  Table [dbo].[sns_personMedal]    Script Date: 06/25/2016 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sns_personMedal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[medalId] [varchar](50) NOT NULL,
	[userId] [varchar](50) NOT NULL,
	[getTime] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_sns_personMedal] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应的勋章id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_personMedal', @level2type=N'COLUMN',@level2name=N'medalId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_personMedal', @level2type=N'COLUMN',@level2name=N'userId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'获得时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_personMedal', @level2type=N'COLUMN',@level2name=N'getTime'
GO
/****** Object:  Table [dbo].[sns_medal]    Script Date: 06/25/2016 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sns_medal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RefText] [varchar](50) NULL,
	[RefDesc] [varchar](50) NULL,
	[imgUrl] [varchar](500) NULL,
	[access] [text] NULL,
	[addtime] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_sns_medal] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'值文本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_medal', @level2type=N'COLUMN',@level2name=N'RefText'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'值描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_medal', @level2type=N'COLUMN',@level2name=N'RefDesc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片位置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_medal', @level2type=N'COLUMN',@level2name=N'imgUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'获取条件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_medal', @level2type=N'COLUMN',@level2name=N'access'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'增加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_medal', @level2type=N'COLUMN',@level2name=N'addtime'
GO
/****** Object:  Table [dbo].[sns_IntegralChange]    Script Date: 06/25/2016 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sns_IntegralChange](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](50) NULL,
	[source] [varchar](50) NULL,
	[Cnbi] [varchar](50) NULL,
	[integral] [int] NULL,
	[Growth] [int] NULL,
	[Status] [int] NOT NULL,
	[ardent] [int] NULL,
	[AddTime] [datetime] NULL,
 CONSTRAINT [PK_sns_IntegralChange] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变更来源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_IntegralChange', @level2type=N'COLUMN',@level2name=N'source'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'cn币' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_IntegralChange', @level2type=N'COLUMN',@level2name=N'Cnbi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'节操' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_IntegralChange', @level2type=N'COLUMN',@level2name=N'integral'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成长值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_IntegralChange', @level2type=N'COLUMN',@level2name=N'Growth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'热心' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_IntegralChange', @level2type=N'COLUMN',@level2name=N'ardent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_IntegralChange', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
/****** Object:  Table [dbo].[sns_Img]    Script Date: 06/25/2016 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sns_Img](
	[ImgId] [int] IDENTITY(1,1) NOT NULL,
	[ImgUrl] [varchar](50) NOT NULL,
	[addtime] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_sns_Img] PRIMARY KEY CLUSTERED 
(
	[ImgId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_Img', @level2type=N'COLUMN',@level2name=N'ImgUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_Img', @level2type=N'COLUMN',@level2name=N'addtime'
GO
/****** Object:  Table [dbo].[sns_cooSignPerson]    Script Date: 06/25/2016 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sns_cooSignPerson](
	[spId] [int] IDENTITY(1,1) NOT NULL,
	[cooId] [varchar](50) NULL,
	[uid] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[QQ] [varchar](50) NULL,
	[Status] [int] NOT NULL,
	[type] [varchar](50) NULL,
	[uname] [varchar](50) NULL,
 CONSTRAINT [PK_sns_cooSignPerson] PRIMARY KEY CLUSTERED 
(
	[spId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sns_cooperation]    Script Date: 06/25/2016 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sns_cooperation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[User_id] [varchar](50) NULL,
	[title] [varchar](50) NULL,
	[type] [varchar](50) NULL,
	[send] [varchar](50) NULL,
	[enrollEnd] [datetime] NULL,
	[timeBudget] [varchar](50) NULL,
	[intention] [varchar](50) NULL,
	[acceptSum] [varchar](50) NULL,
	[cooContent] [text] NULL,
	[RMBBudget] [varchar](50) NULL,
	[GenderAsk] [varchar](50) NULL,
	[signPerson] [varchar](50) NULL,
	[personSum] [varchar](50) NULL,
	[ReleaseTime] [datetime] NULL,
	[Status] [int] NOT NULL,
	[contacts] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[qq] [varchar](50) NULL,
	[cover] [varchar](500) NULL,
	[limitPerson] [int] NOT NULL,
	[will] [varchar](50) NULL,
	[prov] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[dist] [varchar](50) NULL,
	[excerpt] [text] NULL,
 CONSTRAINT [PK_sns_cooperation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布会员id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'User_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'接单种类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否寄拍' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'send'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报名截止' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'enrollEnd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间预算' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'timeBudget'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'意向类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'intention'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'接单数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'acceptSum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'介绍' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'cooContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预算' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'RMBBudget'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别要求' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'GenderAsk'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报名人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'signPerson'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'查看人次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'personSum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'ReleaseTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'contacts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'封面' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'cover'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'限制报名人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'limitPerson'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'意向' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'will'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'省' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'prov'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'city'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'区/县' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'dist'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'摘要' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_cooperation', @level2type=N'COLUMN',@level2name=N'excerpt'
GO
/****** Object:  Table [dbo].[sns_cooImg]    Script Date: 06/25/2016 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sns_cooImg](
	[ImgId] [int] IDENTITY(1,1) NOT NULL,
	[cooId] [varchar](50) NOT NULL,
	[ImgUrl] [varchar](50) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_sns_cooImg] PRIMARY KEY CLUSTERED 
(
	[ImgId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sns_activitySignPerson]    Script Date: 06/25/2016 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sns_activitySignPerson](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[acId] [varchar](50) NOT NULL,
	[uid] [varchar](50) NOT NULL,
	[uname] [varchar](50) NOT NULL,
	[phone] [varchar](50) NULL,
	[QQ] [varchar](50) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_sns_activitySignPerson] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activitySignPerson', @level2type=N'COLUMN',@level2name=N'acId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activitySignPerson', @level2type=N'COLUMN',@level2name=N'uid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activitySignPerson', @level2type=N'COLUMN',@level2name=N'uname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activitySignPerson', @level2type=N'COLUMN',@level2name=N'phone'
GO
/****** Object:  Table [dbo].[sns_activity]    Script Date: 06/25/2016 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sns_activity](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[User_id] [varchar](50) NULL,
	[title] [varchar](50) NULL,
	[starttime] [datetime] NULL,
	[endtime] [datetime] NULL,
	[enrollEnd] [datetime] NULL,
	[contacts] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[qq] [varchar](50) NULL,
	[cover] [varchar](500) NULL,
	[cont] [text] NULL,
	[RMBBudget] [varchar](50) NULL,
	[limitPerson] [varchar](50) NULL,
	[prov] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[dist] [varchar](50) NULL,
	[ReleaseTime] [datetime] NULL,
	[Status] [int] NOT NULL,
	[excerpt] [text] NULL,
 CONSTRAINT [PK_sns_activity] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布会员id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activity', @level2type=N'COLUMN',@level2name=N'User_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activity', @level2type=N'COLUMN',@level2name=N'title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activity', @level2type=N'COLUMN',@level2name=N'starttime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activity', @level2type=N'COLUMN',@level2name=N'endtime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报名截止' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activity', @level2type=N'COLUMN',@level2name=N'enrollEnd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activity', @level2type=N'COLUMN',@level2name=N'contacts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activity', @level2type=N'COLUMN',@level2name=N'phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activity', @level2type=N'COLUMN',@level2name=N'qq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'封面' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activity', @level2type=N'COLUMN',@level2name=N'cover'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'介绍' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activity', @level2type=N'COLUMN',@level2name=N'cont'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activity', @level2type=N'COLUMN',@level2name=N'RMBBudget'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'限制报名人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activity', @level2type=N'COLUMN',@level2name=N'limitPerson'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'省' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activity', @level2type=N'COLUMN',@level2name=N'prov'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activity', @level2type=N'COLUMN',@level2name=N'city'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'区/县' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activity', @level2type=N'COLUMN',@level2name=N'dist'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activity', @level2type=N'COLUMN',@level2name=N'ReleaseTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'摘要' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_activity', @level2type=N'COLUMN',@level2name=N'excerpt'
GO
/****** Object:  Table [dbo].[cos_sysPara]    Script Date: 06/25/2016 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cos_sysPara](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RefType] [varchar](50) NOT NULL,
	[RefTypeDesc] [varchar](50) NULL,
	[RefValue] [varchar](50) NULL,
	[RefText] [varchar](50) NULL,
	[RefDesc] [varchar](50) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_cos_sysPara] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[cos_sysPara] ON
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (1, N'ordersClass', N'接单类别', N'cp', N'cp', N'', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (2, N'ordersClass', N'接单类别', N'coser', N'coser', N'', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (3, N'ordersClass', N'接单类别', N'tailor', N'裁缝', N'裁缝', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (4, N'ordersClass', N'接单类别', N'Photography', N'摄影', N'摄影', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (5, N'ordersClass', N'接单类别', N'ps', N'后期', N'后期', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (6, N'ordersClass', N'接单类别', N'logistical', N'后勤', N'后勤', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (7, N'ordersClass', N'接单类别', N'makeup', N'妆娘', N'妆娘', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (8, N'ordersClass', N'接单类别', N'other', N'其他', N'其他', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (9, N'sex', N'性别', N'1', N'男', N'', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (10, N'sex', N'性别', N'0', N'女', N'', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (11, N'integralSource', N'积分来源', N'dailyLogin', N'每日登录', N'每日登录', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (12, N'integralSource', N'积分来源', N'publishedWorks', N'发布作品', N'发布作品', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (13, N'integralSource', N'积分来源', N'publishedCoo', N'发布合作', N'发布合作', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (14, N'integralSource', N'积分来源', N'reward', N'打赏', N'打赏', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (15, N'integralSource', N'积分来源', N'clickLike', N'点赞', N'点赞', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (16, N'integralSource', N'积分来源', N'comment', N'评论', N'评论', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (17, N'integralSource', N'积分来源', N'deleteWorks', N'删除作品', N'删除作品', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (18, N'integralSource', N'积分来源', N'onlineTime', N'在线时间', N'在线时间', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (19, N'integralSource', N'积分来源', N'modifiedNickname', N'修改昵称', N'修改昵称', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (20, N'noteType', N'作品类型', N'cos', N'cos', N'', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (21, N'noteType', N'作品类型', N'daily', N'日常', N'日常', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (22, N'noteType', N'作品类型', N'painting', N'绘画', N'绘画', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (23, N'noteType', N'作品类型', N'photography', N'轻小说', N'轻小说', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (24, N'noteType2', N'作品类型2级分类', N'herald', N'预告', N'cos', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (25, N'noteType2', N'作品类型2级分类', N'official', N'正片', N'cos', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (26, N'noteType2', N'作品类型2级分类', N'fan', N'同人', N'painting', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (27, N'noteType2', N'作品类型2级分类', N'original', N'原创', N'painting', 1)
INSERT [dbo].[cos_sysPara] ([id], [RefType], [RefTypeDesc], [RefValue], [RefText], [RefDesc], [Status]) VALUES (28, N'integralSource', N'积分来源', N'recharge', N'CN币充值', N'CN币充值', 1)
SET IDENTITY_INSERT [dbo].[cos_sysPara] OFF
/****** Object:  Table [dbo].[cos_member]    Script Date: 06/25/2016 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cos_member](
	[User_id] [int] IDENTITY(1,1) NOT NULL,
	[User_name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NOT NULL,
	[Real_name] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[Birthday] [varchar](50) NULL,
	[Phone_tel] [varchar](50) NULL,
	[Phone_mob] [varchar](50) NULL,
	[Im_qq] [varchar](50) NULL,
	[Im_msn] [varchar](50) NULL,
	[In_skype] [varchar](50) NULL,
	[Im_yahoo] [varchar](50) NULL,
	[Im_aliww] [varchar](50) NULL,
	[Reg_time] [datetime] NULL,
	[Last_login] [datetime] NULL,
	[Last_ip] [varchar](50) NULL,
	[Logins] [int] NOT NULL,
	[Ugrade] [int] NOT NULL,
	[Portrait] [varchar](500) NULL,
	[Outer_id] [varchar](50) NULL,
	[Activation] [varchar](50) NULL,
	[Feed_config] [varchar](50) NULL,
	[Status] [int] NOT NULL,
	[reward] [int] NULL,
	[CNbi] [int] NULL,
	[integral] [int] NOT NULL,
	[nickname] [varchar](50) NULL,
	[ardent] [int] NULL,
	[Growth] [int] NULL,
	[code] [varchar](500) NULL,
	[Describe] [text] NULL,
 CONSTRAINT [PK_cos_member] PRIMARY KEY CLUSTERED 
(
	[User_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'User_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'真实姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Real_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Birthday'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Phone_tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Phone_mob'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Im_qq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MSN' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Im_msn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SKYPE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'In_skype'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'雅虎' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Im_yahoo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'阿里旺旺' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Im_aliww'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Reg_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Last_login'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后登录IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Last_ip'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Logins'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员级别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Ugrade'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'头像地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Portrait'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登出ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Outer_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'激活' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Activation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订阅配置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Feed_config'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'启用状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总打赏数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'reward'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CN币' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'CNbi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'节操' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'integral'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'nickname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'热心' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'ardent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员成长值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Growth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱验证code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'个人描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_member', @level2type=N'COLUMN',@level2name=N'Describe'
GO
/****** Object:  Table [dbo].[cos_loginIP]    Script Date: 06/25/2016 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cos_loginIP](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[User_id] [varchar](50) NULL,
	[Last_ip] [varchar](50) NULL,
	[Lastddress] [varchar](50) NULL,
	[Status] [int] NOT NULL,
	[LastTime] [datetime] NULL,
 CONSTRAINT [PK_cos_loginIP] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_loginIP', @level2type=N'COLUMN',@level2name=N'User_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_loginIP', @level2type=N'COLUMN',@level2name=N'Last_ip'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_loginIP', @level2type=N'COLUMN',@level2name=N'Lastddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cos_loginIP', @level2type=N'COLUMN',@level2name=N'LastTime'
GO
/****** Object:  Default [DF_sns_ordinaryNote_Root]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_works] ADD  CONSTRAINT [DF_sns_ordinaryNote_Root]  DEFAULT ((0)) FOR [Root]
GO
/****** Object:  Default [DF_sns_ordinaryNote_Keep]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_works] ADD  CONSTRAINT [DF_sns_ordinaryNote_Keep]  DEFAULT ((1)) FOR [Keep]
GO
/****** Object:  Default [DF_sns_ordinaryNote_Watermark]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_works] ADD  CONSTRAINT [DF_sns_ordinaryNote_Watermark]  DEFAULT ((1)) FOR [Watermark]
GO
/****** Object:  Default [DF_sns_ordinaryNote_GoodNo]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_works] ADD  CONSTRAINT [DF_sns_ordinaryNote_GoodNo]  DEFAULT ((0)) FOR [GoodNo]
GO
/****** Object:  Default [DF_sns_ordinaryNote_Status]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_works] ADD  CONSTRAINT [DF_sns_ordinaryNote_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_sns_ordinaryNote_reward]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_works] ADD  CONSTRAINT [DF_sns_ordinaryNote_reward]  DEFAULT ((0)) FOR [reward]
GO
/****** Object:  Default [DF_sns_noteImg_Status]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_workImg] ADD  CONSTRAINT [DF_sns_noteImg_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_sns_userGood_Status]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_userGood] ADD  CONSTRAINT [DF_sns_userGood_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_sns_transactions_Status]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_transactions] ADD  CONSTRAINT [DF_sns_transactions_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_sns_smallImg_Status]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_smallImg] ADD  CONSTRAINT [DF_sns_smallImg_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF__sns_rewar__Statu__2A4B4B5E]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_reward] ADD  CONSTRAINT [DF__sns_rewar__Statu__2A4B4B5E]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_sns_reply_Status]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_reply] ADD  CONSTRAINT [DF_sns_reply_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_sns_rechargeRecord_Status]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_rechargeRecord] ADD  CONSTRAINT [DF_sns_rechargeRecord_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_sns_personMedal_Status]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_personMedal] ADD  CONSTRAINT [DF_sns_personMedal_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_sns_medal_Status]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_medal] ADD  CONSTRAINT [DF_sns_medal_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_sns_IntegralChange_Status]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_IntegralChange] ADD  CONSTRAINT [DF_sns_IntegralChange_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_sns_Img_Status]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_Img] ADD  CONSTRAINT [DF_sns_Img_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_sns_cooSignPerson_Status]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_cooSignPerson] ADD  CONSTRAINT [DF_sns_cooSignPerson_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_sns_cooperation_Status]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_cooperation] ADD  CONSTRAINT [DF_sns_cooperation_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF__sns_coope__limit__35BCFE0A]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_cooperation] ADD  DEFAULT ((0)) FOR [limitPerson]
GO
/****** Object:  Default [DF_sns_cooImg_Status]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_cooImg] ADD  CONSTRAINT [DF_sns_cooImg_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_sns_activitySignPerson_Status]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_activitySignPerson] ADD  CONSTRAINT [DF_sns_activitySignPerson_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_sns_activity_Status]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[sns_activity] ADD  CONSTRAINT [DF_sns_activity_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_cos_sysPara_Status]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[cos_sysPara] ADD  CONSTRAINT [DF_cos_sysPara_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_cos_member_Logins]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[cos_member] ADD  CONSTRAINT [DF_cos_member_Logins]  DEFAULT ((0)) FOR [Logins]
GO
/****** Object:  Default [DF_cos_member_Ugrade]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[cos_member] ADD  CONSTRAINT [DF_cos_member_Ugrade]  DEFAULT ((1)) FOR [Ugrade]
GO
/****** Object:  Default [DF_cos_member_Status]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[cos_member] ADD  CONSTRAINT [DF_cos_member_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_cos_member_reward]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[cos_member] ADD  CONSTRAINT [DF_cos_member_reward]  DEFAULT ((0)) FOR [reward]
GO
/****** Object:  Default [DF_cos_member_CNbi]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[cos_member] ADD  CONSTRAINT [DF_cos_member_CNbi]  DEFAULT ((0)) FOR [CNbi]
GO
/****** Object:  Default [DF_cos_member_integral]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[cos_member] ADD  CONSTRAINT [DF_cos_member_integral]  DEFAULT ((0)) FOR [integral]
GO
/****** Object:  Default [DF_cos_loginIP_Status]    Script Date: 06/25/2016 16:36:43 ******/
ALTER TABLE [dbo].[cos_loginIP] ADD  CONSTRAINT [DF_cos_loginIP_Status]  DEFAULT ((1)) FOR [Status]
GO
