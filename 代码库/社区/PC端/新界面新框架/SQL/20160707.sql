USE [ESSoft]
GO
/****** Object:  Table [dbo].[sns_exchange]    Script Date: 07/06/2016 20:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sns_exchange](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](50) NOT NULL,
	[Title] [varchar](50) NULL,
	[Cont] [text] NULL,
	[Cover] [varchar](50) NULL,
	[Imgs] [varchar](50) NULL,
	[Valuation1] [varchar](50) NOT NULL,
	[Valuation2] [varchar](50) NOT NULL,
	[Valuation3] [varchar](50) NOT NULL,
	[Vote1] [int] NOT NULL,
	[Vote2] [int] NOT NULL,
	[Vote3] [int] NOT NULL,
	[ReleaseTime] [datetime] NOT NULL,
	[Examine] [varchar](50) NULL,
	[Status] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布会员id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_exchange', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_exchange', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_exchange', @level2type=N'COLUMN',@level2name=N'Cont'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'封面' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_exchange', @level2type=N'COLUMN',@level2name=N'Cover'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片列表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_exchange', @level2type=N'COLUMN',@level2name=N'Imgs'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自我估价1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_exchange', @level2type=N'COLUMN',@level2name=N'Valuation1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自我估价2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_exchange', @level2type=N'COLUMN',@level2name=N'Valuation2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自我估价3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_exchange', @level2type=N'COLUMN',@level2name=N'Valuation3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'估价1票数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_exchange', @level2type=N'COLUMN',@level2name=N'Vote1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'估价2票数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_exchange', @level2type=N'COLUMN',@level2name=N'Vote2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'估价3票数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_exchange', @level2type=N'COLUMN',@level2name=N'Vote3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_exchange', @level2type=N'COLUMN',@level2name=N'ReleaseTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'过期标志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_exchange', @level2type=N'COLUMN',@level2name=N'Examine'
GO
/****** Object:  Default [DF_sns_exchange_Status]    Script Date: 07/06/2016 20:33:28 ******/
ALTER TABLE [dbo].[sns_exchange] ADD  CONSTRAINT [DF_sns_exchange_Status]  DEFAULT ((1)) FOR [Status]
GO
