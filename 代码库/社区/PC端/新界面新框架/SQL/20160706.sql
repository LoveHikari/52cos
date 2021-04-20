USE [Basics]
GO
/****** Object:  Table [dbo].[sns_slide]    Script Date: 07/06/2016 14:55:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sns_slide](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImgText] [varchar](50) NOT NULL,
	[ImgUrl] [varchar](500) NOT NULL,
	[ImgHref] [varchar](500) NULL,
	[weight] [int] NOT NULL,
	[AddTime] [datetime] NOT NULL,
	[Sign] [int] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_sns_slide] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_slide', @level2type=N'COLUMN',@level2name=N'ImgText'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_slide', @level2type=N'COLUMN',@level2name=N'ImgUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'链接地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_slide', @level2type=N'COLUMN',@level2name=N'ImgHref'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权重' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_slide', @level2type=N'COLUMN',@level2name=N'weight'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_slide', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sns_slide', @level2type=N'COLUMN',@level2name=N'Sign'
GO
/****** Object:  Default [DF_sns_slide_Status]    Script Date: 07/06/2016 14:55:42 ******/
ALTER TABLE [dbo].[sns_slide] ADD  CONSTRAINT [DF_sns_slide_Status]  DEFAULT ((1)) FOR [Status]
GO
