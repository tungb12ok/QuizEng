USE [QuizEng]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 2/26/2024 11:37:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[QuizId] [int] NULL,
	[Content] [nvarchar](max) NOT NULL,
	[CorrectAnswer] [nvarchar](255) NOT NULL,
	[MaxScore] [int] NOT NULL,
 CONSTRAINT [PK__Question__0DC06FAC54CCD369] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quizzes]    Script Date: 2/26/2024 11:37:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quizzes](
	[QuizId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK__Quizzes__8B42AE8EC1396688] PRIMARY KEY CLUSTERED 
(
	[QuizId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Questions] ON 

INSERT [dbo].[Questions] ([QuestionId], [QuizId], [Content], [CorrectAnswer], [MaxScore]) VALUES (1, 1, N'What is the capital of France?', N'a', 1)
INSERT [dbo].[Questions] ([QuestionId], [QuizId], [Content], [CorrectAnswer], [MaxScore]) VALUES (2, 1, N'Who wrote "Romeo and Juliet"?', N'a', 1)
INSERT [dbo].[Questions] ([QuestionId], [QuizId], [Content], [CorrectAnswer], [MaxScore]) VALUES (3, 2, N'What is the largest ocean on Earth?', N'Pacific Ocean', 1)
INSERT [dbo].[Questions] ([QuestionId], [QuizId], [Content], [CorrectAnswer], [MaxScore]) VALUES (4, 4, N'eoiqwoeqwj
a,
b,
c,', N'ab', 1)
INSERT [dbo].[Questions] ([QuestionId], [QuizId], [Content], [CorrectAnswer], [MaxScore]) VALUES (5, 5, N'eoiqwoeqwj
a,
b,
c,', N'ab', 1)
INSERT [dbo].[Questions] ([QuestionId], [QuizId], [Content], [CorrectAnswer], [MaxScore]) VALUES (6, 6, N'eoiqwoeqwj
a,
b,
c,', N'ab', 1)
INSERT [dbo].[Questions] ([QuestionId], [QuizId], [Content], [CorrectAnswer], [MaxScore]) VALUES (7, 7, N'eoiqwoeqwja,b,c,', N'abc', 1)
INSERT [dbo].[Questions] ([QuestionId], [QuizId], [Content], [CorrectAnswer], [MaxScore]) VALUES (8, 7, N'qưe', N'b', 1)
SET IDENTITY_INSERT [dbo].[Questions] OFF
GO
SET IDENTITY_INSERT [dbo].[Quizzes] ON 

INSERT [dbo].[Quizzes] ([QuizId], [Title]) VALUES (1, N'English Quiz 1')
INSERT [dbo].[Quizzes] ([QuizId], [Title]) VALUES (2, N'English Quiz 2')
INSERT [dbo].[Quizzes] ([QuizId], [Title]) VALUES (3, N'ewqe')
INSERT [dbo].[Quizzes] ([QuizId], [Title]) VALUES (4, N'Vocab')
INSERT [dbo].[Quizzes] ([QuizId], [Title]) VALUES (5, N'Vocab')
INSERT [dbo].[Quizzes] ([QuizId], [Title]) VALUES (6, N'Vocab')
INSERT [dbo].[Quizzes] ([QuizId], [Title]) VALUES (7, N'Vocab')
SET IDENTITY_INSERT [dbo].[Quizzes] OFF
GO
ALTER TABLE [dbo].[Questions] ADD  CONSTRAINT [DF__Questions__MaxSc__571DF1D5]  DEFAULT ((1)) FOR [MaxScore]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK__Questions__QuizI__5812160E] FOREIGN KEY([QuizId])
REFERENCES [dbo].[Quizzes] ([QuizId])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK__Questions__QuizI__5812160E]
GO
