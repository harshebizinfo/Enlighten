
/****** Object:  Table [dbo].[AcademicYear]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AcademicYear](
	[Id] [int] NOT NULL,
	[Year] [varchar](max) NULL,
	[CreatedBy] [varchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdmissionBaseMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdmissionBaseMaster](
	[Id] [int] NOT NULL,
	[AdmissionBaseName] [varchar](max) NOT NULL,
	[CreatedBy] [varchar](max) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AreaMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AreaMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AreaName] [varchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [varchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AreaVehicleMapping]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AreaVehicleMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AreaMasterId] [int] NULL,
	[VehicleMasterId] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [varchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Assignment]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Assignment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[LessonId] [int] NOT NULL,
	[Title] [varchar](max) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[SubmissionDate] [datetime] NOT NULL,
	[AssignmentFilePath] [varchar](max) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AssignNotice]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignNotice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NoticeId] [int] NULL,
	[StandardId] [int] NULL,
	[IsForStudent] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BankDetails]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BankDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BankName] [varchar](50) NOT NULL,
	[AccountNumber] [varchar](50) NOT NULL,
	[IFSCCode] [varchar](25) NOT NULL,
	[ApplicationUsedId] [int] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
	[AccountHolderName] [varchar](50) NULL,
	[NickName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CategoryMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CategoryMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](max) NOT NULL,
	[CategoryDescription] [varchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [varchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CityMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CityMaster](
	[Id] [int] NOT NULL,
	[CityName] [varchar](max) NOT NULL,
	[CreatedBy] [varchar](max) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClassDivisionAllotment]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassDivisionAllotment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentStandardId] [int] NOT NULL,
	[DivisionId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClassMappingMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClassMappingMaster](
	[Id] [int] NOT NULL,
	[StreamId] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
	[SectionId] [int] NOT NULL,
	[CreatedBy] [varchar](max) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClientPaymentConfiguration]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClientPaymentConfiguration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentGateWay] [varchar](max) NOT NULL,
	[ClientId] [varchar](max) NOT NULL,
	[PaymentPassword] [varchar](250) NOT NULL,
	[MerchantId] [varchar](250) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[RequestHashKey] [nvarchar](max) NOT NULL,
	[ResponseHashKey] [nvarchar](max) NOT NULL,
	[RequestAESKey] [nvarchar](max) NOT NULL,
	[ResponseAESKey] [nvarchar](max) NOT NULL,
	[TransactionType] [nvarchar](max) NOT NULL,
	[ProductId] [nvarchar](max) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ComplaintMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ComplaintMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StreamId] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
	[SectionId] [int] NOT NULL,
	[AdmissionNumber] [varchar](max) NULL,
	[Complaint] [varchar](max) NULL,
	[StepTaken] [varchar](max) NULL,
	[OfflineId] [int] NULL,
	[CreatedBy] [varchar](max) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ConveyanceMonthForStudent]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConveyanceMonthForStudent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationUserId] [int] NOT NULL,
	[StandardId] [int] NOT NULL,
	[DivisionId] [int] NOT NULL,
	[MonthId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CourseSubject]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CourseSubject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentStandardID] [int] NOT NULL,
	[CourseSubjectName] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
	[SubjectId] [int] NULL,
	[DivisionId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DepartmentStandard]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DepartmentStandard](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentStandardName] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [varchar](max) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Division]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Division](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Section] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [varchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DocumentGoogleDrive]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DocumentGoogleDrive](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[CourseID] [int] NOT NULL,
	[LessonID] [int] NOT NULL,
	[DocumentID] [varchar](max) NOT NULL,
	[SharedLink] [varchar](max) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DocumentMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DocumentMaster](
	[Id] [int] NOT NULL,
	[DocumentName] [varchar](max) NOT NULL,
	[CreatedBy] [varchar](max) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DocumentsFileRequired]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DocumentsFileRequired](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileTypeId] [int] NOT NULL,
	[ApplicationUserId] [int] NOT NULL,
	[MultipleFilePath] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EducationMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EducationMaster](
	[Id] [int] NOT NULL,
	[EducationName] [varchar](max) NOT NULL,
	[CreatedBy] [varchar](max) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EventSession]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EventSession](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [varchar](max) NOT NULL,
	[DepartmentStandardId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Exam]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Exam](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExamName] [varchar](50) NOT NULL,
	[DepartmentStandardId] [int] NULL,
	[CourseSubjectId] [int] NULL,
	[TotalMarks] [int] NULL,
	[ExamStartDateTime] [datetime] NULL,
	[ExamEndDateTime] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
	[NumberOfQuestion] [int] NULL DEFAULT (NULL),
	[DurationInMinutes] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ExamAnswer]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ExamAnswer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationUserId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
	[DepartmentStandardId] [int] NOT NULL,
	[CourseSubjectId] [int] NOT NULL,
	[ExamId] [int] NOT NULL,
	[Answer] [varchar](max) NULL,
	[Marks] [int] NULL,
	[SequenceNumber] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
	[NumberOfAttempts] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ExamAnswerLog]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ExamAnswerLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationUserId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
	[DepartmentStandardId] [int] NOT NULL,
	[CourseSubjectId] [int] NOT NULL,
	[ExamId] [int] NOT NULL,
	[Answer] [varchar](max) NULL,
	[Marks] [int] NULL,
	[SequenceNumber] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
	[NumberOfAttempts] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ExamCoveredTime]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamCoveredTime](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationUserId] [int] NOT NULL,
	[DepartmentStandardId] [int] NOT NULL,
	[CourseSubjectId] [int] NOT NULL,
	[ExamId] [int] NOT NULL,
	[NumberOfAttempts] [int] NOT NULL,
	[TimeCoveredInMinutes] [int] NOT NULL,
	[TimeCoveredInSecond] [int] NOT NULL,
	[ExamStartDateTime] [datetime] NULL,
	[ExamEndDateTime] [datetime] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FeeGroup]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FeeGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FeeGroupName] [varchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [varchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FeeMonthMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FeeMonthMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FeeMonth] [varchar](max) NOT NULL,
	[FeeMonthType] [varchar](max) NOT NULL,
	[NumberOfMonth] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [varchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FeeNameMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FeeNameMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FeeName] [varchar](max) NOT NULL,
	[RefundableFee] [bit] NOT NULL,
	[OptionalFee] [bit] NOT NULL,
	[DiscountOn] [bit] NOT NULL,
	[Conveyance] [bit] NOT NULL,
	[FeeDisplay] [bit] NOT NULL,
	[TransferHead] [bit] NOT NULL,
	[FeeGroupId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [varchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FeeReceipt]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeeReceipt](
	[ReceiptNumber] [int] IDENTITY(1,1) NOT NULL,
	[ReceiptDate] [datetime] NOT NULL,
	[ApplicationUserId] [int] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[ReceiptNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FeeReceiptMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FeeReceiptMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OfflineReceiptNumber] [varchar](max) NOT NULL,
	[OnlineReceiptNumber] [varchar](max) NULL,
	[AdmissionNumber] [varchar](max) NOT NULL,
	[AcademicYearId] [int] NULL,
	[CreatedBy] [varchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FeeStructure]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FeeStructure](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentStandardId] [int] NOT NULL,
	[FeeNameMasterId] [int] NOT NULL,
	[FeeNameAmount] [int] NULL,
	[FeeTypeMasterId] [int] NULL,
	[CategoryMasterId] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [varchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FeeTransaction]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FeeTransaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FeeReceiptId] [int] NOT NULL,
	[ApplicationUserId] [int] NOT NULL,
	[TotalFeeAmount] [int] NOT NULL,
	[FineAmount] [int] NOT NULL,
	[TotalDiscountAmount] [int] NOT NULL,
	[TotalReceivedAmount] [int] NOT NULL,
	[ServiceTax] [int] NOT NULL,
	[TransactionId] [varchar](max) NULL,
	[TransactionDate] [varchar](max) NULL,
	[ReferenceNumber] [varchar](max) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[DepartmentId] [int] NULL,
	[AmountInWords] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FeeTransactionDetail]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FeeTransactionDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FeeReceiptId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[FeeMonth] [varchar](max) NULL,
	[FeeName] [varchar](max) NULL,
	[FeeStructureId] [int] NOT NULL,
	[FeeAmount] [decimal](18, 2) NULL,
	[PaidFee] [decimal](18, 2) NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FeeTransactionDetailMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FeeTransactionDetailMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReceiptNumber] [varchar](max) NULL,
	[FeeMonthId] [int] NULL,
	[FeeHeadId] [int] NULL,
	[PreviousBalanceAmount] [decimal](10, 2) NULL,
	[FeeAmount] [decimal](10, 2) NULL,
	[DiscountAmount] [decimal](10, 2) NULL,
	[PaidFeeAmount] [decimal](10, 2) NULL,
	[IsBalanced] [bit] NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FeeTransactionMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FeeTransactionMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReceiptNumber] [varchar](max) NOT NULL,
	[AdmissionNumber] [varchar](max) NULL,
	[BillBookNo] [varchar](max) NULL,
	[TotalFeeAmount] [decimal](10, 2) NULL,
	[FineAmount] [decimal](10, 2) NULL,
	[TotalDiscountAmount] [decimal](10, 2) NULL,
	[TotalReceivedAmount] [decimal](10, 2) NULL,
	[CashReceivedAmount] [decimal](10, 2) NULL,
	[ChequeAmount] [decimal](10, 2) NULL,
	[ChequeNumber] [varchar](max) NULL,
	[ChequeDate] [datetime] NULL,
	[OnlineAmount] [decimal](10, 2) NULL,
	[OnlineReferenceNumber] [varchar](max) NULL,
	[OnlineTransactionNumber] [varchar](max) NULL,
	[OnlineTransactionDate] [varchar](max) NULL,
	[AmountInWords] [varchar](max) NULL,
	[AcademicYearId] [int] NULL,
	[CreatedBy] [varchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[CancelDateTime] [datetime] NULL,
	[CancelBy] [varchar](max) NULL,
	[IsOnline] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsCancelled] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FeeTypeMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FeeTypeMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentStandardId] [int] NOT NULL,
	[DueDate] [datetime] NOT NULL,
	[FeeNameMasterId] [int] NOT NULL,
	[LateFee] [int] NOT NULL,
	[FeeMonthId] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [varchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FileType]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FileType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileTypeName] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lesson](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentStandardId] [int] NOT NULL,
	[CourseSubjectId] [int] NOT NULL,
	[LessonTitle] [varchar](50) NOT NULL,
	[LessonDescription] [varchar](max) NOT NULL,
	[OrderSequence] [varchar](25) NULL,
	[Duration] [varchar](10) NULL,
	[ThumbNailImage] [varchar](max) NULL,
	[FileType] [varchar](50) NULL,
	[UploadFileMetaData] [varchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MediumMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MediumMaster](
	[Id] [int] NOT NULL,
	[MediumName] [varchar](max) NOT NULL,
	[CreatedBy] [varchar](max) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Notice]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Notice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](max) NULL,
	[NoticeDescription] [varchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NumberOfExamAttempts]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NumberOfExamAttempts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationUserId] [int] NOT NULL,
	[DepartmentStandardId] [int] NOT NULL,
	[CourseSubjectId] [int] NOT NULL,
	[ExamId] [int] NOT NULL,
	[NumberOfAttempts] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsChecked] [bit] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OccupationMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OccupationMaster](
	[Id] [int] NOT NULL,
	[OccupationName] [varchar](max) NOT NULL,
	[CreatedBy] [varchar](max) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PaymentDetail]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PaymentDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentStandardId] [int] NOT NULL,
	[SubjectCourseId] [int] NOT NULL,
	[ExamId] [int] NOT NULL,
	[PaymentNumberOfTimes] [int] NOT NULL,
	[ReferenceNumber] [varchar](max) NOT NULL,
	[ApplicationUserId] [int] NOT NULL,
	[ClientId] [varchar](50) NOT NULL,
	[TransactionDate] [datetime] NULL,
	[Varified] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PlayList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PlayList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[LessonId] [int] NOT NULL,
	[PlayListId] [varchar](max) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PlayListItem]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PlayListItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[LessonId] [int] NOT NULL,
	[PlayListId] [varchar](max) NOT NULL,
	[PlayListItemId] [varchar](max) NOT NULL,
	[VideoId] [varchar](max) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PreviousBalanceFee]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreviousBalanceFee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationUserId] [int] NOT NULL,
	[DepartmentStandardId] [int] NOT NULL,
	[DivisionId] [int] NOT NULL,
	[PreviousBalanceAmount] [decimal](10, 2) NULL,
	[IsPaid] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDelete] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Questionaire]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Questionaire](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentStandardId] [int] NOT NULL,
	[CourseSubjectId] [int] NOT NULL,
	[ExamId] [int] NOT NULL,
	[Question] [varchar](max) NOT NULL,
	[QuestionOptionMetadata] [varchar](max) NULL,
	[CorrectOption] [varchar](max) NULL,
	[QuestionAnswerTypeId] [varchar](max) NOT NULL,
	[Marks] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuestionaireValue]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuestionaireValue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId] [int] NOT NULL,
	[AnswerValue] [varchar](max) NOT NULL,
	[MarksObtained] [int] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuestionAnswerType]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuestionAnswerType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AnswerTypeName] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RefferedMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RefferedMaster](
	[Id] [int] NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[Email] [varchar](max) NOT NULL,
	[Contact] [varchar](max) NOT NULL,
	[CreatedBy] [varchar](max) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RequestedConveyance]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RequestedConveyance](
	[Id] [int] NOT NULL,
	[AdmissionNumber] [varchar](max) NOT NULL,
	[LocationId] [int] NOT NULL,
	[ModeId] [int] NULL,
	[Amount] [decimal](10, 2) NULL,
	[Month] [varchar](max) NULL,
	[IsOneSide] [bit] NULL,
	[IsBoth] [bit] NULL,
	[PickBusNumber] [varchar](max) NULL,
	[PickTripNumber] [varchar](max) NULL,
	[PickStopageOrder] [varchar](max) NULL,
	[DropBusNumber] [varchar](max) NULL,
	[DropTripNumber] [varchar](max) NULL,
	[DropStopageOrder] [varchar](max) NULL,
	[CreatedBy] [varchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [varchar](max) NULL,
	[IsDeleted] [bit] NULL,
	[AcademicYearId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sibilings]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sibilings](
	[Id] [int] NOT NULL,
	[AdmissionNumber] [varchar](max) NOT NULL,
	[Name] [varchar](max) NULL,
	[SibilingAdmissionNumber] [varchar](max) NULL,
	[Relation] [varchar](max) NULL,
	[CreatedBy] [varchar](max) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StreamMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StreamMaster](
	[Id] [int] NOT NULL,
	[StreamName] [varchar](max) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[CreatedBy] [varchar](max) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentAttendance]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentAttendance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StandardId] [int] NOT NULL,
	[DivisionId] [int] NOT NULL,
	[AttendanceDate] [datetime] NOT NULL,
	[ApplicationUserId] [int] NOT NULL,
	[StudentName] [varchar](max) NULL,
	[Attandence] [varchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentFeeWriteOff]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentFeeWriteOff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdmissionNumber] [varchar](max) NULL,
	[FeeMonthId] [int] NULL,
	[AcademicYearId] [int] NULL,
	[CreatedBy] [varchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentInDepartmentStandard]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentInDepartmentStandard](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentStandardId] [int] NOT NULL,
	[ApplicationUserId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
	[DivisionId] [int] NULL,
	[CategoryId] [int] NULL,
	[AreaId] [int] NULL,
	[HasConveyance] [bit] NULL,
	[ModeId] [int] NULL,
	[PickUpVehicleNumber] [varchar](max) NULL,
	[DropVehicleNumber] [varchar](max) NULL,
	[PickUpVehicleId] [int] NULL,
	[DropVehicleId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsOneWayTrip] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentInformation]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentInformation](
	[AdmissionNumber] [varchar](max) NOT NULL,
	[RegistrationNumber] [varchar](max) NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[ReceiptNumber] [varchar](max) NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[BloodGroup] [varchar](max) NULL,
	[FeeCategoryId] [int] NULL,
	[Language] [varchar](max) NULL,
	[Nationality] [varchar](max) NULL,
	[TehseelId] [int] NULL,
	[CityId] [int] NULL,
	[PrevSchoolName] [varchar](max) NULL,
	[PrevMediumId] [int] NULL,
	[PrevStreamId] [int] NULL,
	[PrevMarks] [decimal](10, 2) NULL,
	[PrevClassId] [int] NULL,
	[PrevTotalMarks] [decimal](10, 2) NULL,
	[PrevAddress] [varchar](max) NULL,
	[StudentImage] [varchar](max) NULL,
	[FatherName] [varchar](max) NULL,
	[FatherPhone] [varchar](max) NULL,
	[FatherEducationId] [int] NULL,
	[FatherOccupationId] [int] NULL,
	[FatherAddress] [varchar](max) NULL,
	[FatherImage] [varchar](max) NULL,
	[MotherName] [varchar](max) NULL,
	[MotherPhone] [varchar](max) NULL,
	[MotherEducationId] [int] NULL,
	[MotherOccupationId] [int] NULL,
	[MotherAddress] [varchar](max) NULL,
	[MotherImage] [varchar](max) NULL,
	[GuardianName] [varchar](max) NULL,
	[GuardianPhone] [varchar](max) NULL,
	[GuardianRelationShip] [varchar](max) NULL,
	[GuardianAddress] [varchar](max) NULL,
	[GuardianImage] [varchar](max) NULL,
	[StreamId] [int] NOT NULL,
	[MediumId] [int] NOT NULL,
	[AdmissionBaseId] [int] NULL,
	[ClassId] [int] NOT NULL,
	[BillBookNumber] [varchar](max) NULL,
	[RefferedBy] [int] NULL,
	[DocumentsId] [int] NULL,
	[SectionId] [int] NULL,
	[Board] [varchar](max) NULL,
	[ConveyBook] [varchar](max) NULL,
	[Remarks] [varchar](max) NULL,
	[IsScholarship] [bit] NULL,
	[IsDiscount] [bit] NULL,
	[IsConveyanceIncluded] [bit] NULL,
	[OptionalFee] [varchar](max) NULL,
	[AcademicYearId] [int] NULL,
	[IsPreviousSchoolIncluded] [bit] NULL,
	[IsSibilingsIncluded] [bit] NULL,
	[IsReleved] [int] NULL DEFAULT ((0)),
	[StudentDocuments] [varchar](max) NULL,
	[IsDeleted] [bit] NULL DEFAULT ((0))
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentOptionalFeeMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentOptionalFeeMaster](
	[Id] [int] NOT NULL,
	[AdmissionNumber] [varchar](max) NOT NULL,
	[StreamId] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
	[SectionId] [int] NOT NULL,
	[IsIncluded] [bit] NOT NULL,
	[FeeHeadId] [int] NOT NULL,
	[AcademicYearId] [int] NULL,
	[CreatedBy] [varchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentResult]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentResult](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationUserId] [int] NOT NULL,
	[DepartmentStandardId] [int] NOT NULL,
	[CourseSubjectId] [int] NOT NULL,
	[ExamId] [int] NOT NULL,
	[TotalObtainedMarks] [int] NOT NULL,
	[NumberOfAttempts] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentTransportHistory]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentTransportHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AreaId] [int] NULL,
	[ModeId] [int] NULL,
	[PickupvehichleNumber] [varchar](max) NULL,
	[PickupvehichleNumberId] [int] NULL,
	[DropVehicleNumber] [varchar](max) NULL,
	[DropVehicleNumberId] [int] NULL,
	[FromDate] [datetime] NULL,
	[ApplicationUserId] [int] NULL,
	[IsCurrentActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[IsOneWayTrip] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SubjectMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SubjectMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [varchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SubmitAssignment]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SubmitAssignment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[LessonId] [int] NOT NULL,
	[AnswerFilePath] [varchar](max) NOT NULL,
	[SubmittedBy] [int] NOT NULL,
	[SubmittedOn] [datetime] NOT NULL,
	[IsLateSubmitted] [bit] NOT NULL DEFAULT ((0)),
	[AssignmentId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_test_temp]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_test_temp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationUserID] [int] NULL,
	[value1] [varchar](max) NULL,
	[value2] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TehseelMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TehseelMaster](
	[Id] [int] NOT NULL,
	[TehseelName] [varchar](max) NOT NULL,
	[CityId] [int] NOT NULL,
	[CreatedBy] [varchar](max) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TempPaymentDetail]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TempPaymentDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationUserId] [int] NOT NULL,
	[StandardId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[TotalFee] [decimal](18, 2) NULL,
	[LateFee] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[ReferenceNumber] [varchar](max) NULL,
	[Verified] [bit] NULL,
	[TransactionDate] [datetime] NULL,
	[IsPreviousYearBalanceInclided] [bit] NULL,
	[F1] [varchar](max) NULL,
	[F2] [varchar](max) NULL,
	[F3] [varchar](max) NULL,
	[F4] [varchar](max) NULL,
	[F5] [varchar](max) NULL,
	[F6] [varchar](max) NULL,
	[F7] [varchar](max) NULL,
	[F8] [varchar](max) NULL,
	[F9] [varchar](max) NULL,
	[F10] [varchar](max) NULL,
	[F11] [varchar](max) NULL,
	[F12] [varchar](max) NULL,
	[F13] [varchar](max) NULL,
	[F14] [varchar](max) NULL,
	[F15] [varchar](max) NULL,
	[F16] [varchar](max) NULL,
	[F17] [varchar](max) NULL,
	[F18] [varchar](max) NULL,
	[F19] [varchar](max) NULL,
	[F20] [varchar](max) NULL,
	[F21] [varchar](max) NULL,
	[F22] [varchar](max) NULL,
	[F23] [varchar](max) NULL,
	[F24] [varchar](max) NULL,
	[F25] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TraineeAttendance]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TraineeAttendance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AttendanceDate] [datetime] NOT NULL,
	[ApplicationUserId] [int] NOT NULL,
	[TraineeName] [varchar](max) NULL,
	[TraineeEmail] [varchar](max) NULL,
	[Attandence] [varchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TraineeInDeoartmentandCourse]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TraineeInDeoartmentandCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationUserId] [int] NOT NULL,
	[DepartmentStandardId] [int] NULL,
	[CourseSubjectId] [int] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TransportPrice]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TransportPrice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AreaMasterId] [int] NOT NULL,
	[VehicleModeId] [int] NOT NULL,
	[TransportAmount] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [varchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ValidationAnswerType]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ValidationAnswerType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AnswerTypeName] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ValidationTable]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ValidationTable](
	[ValidationId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId] [int] NOT NULL,
	[IsRequired] [bit] NOT NULL,
	[ValidationAnswerTypeId] [int] NULL,
	[ValidationAnswerId] [int] NULL,
	[ValueToCompare] [varchar](50) NULL,
	[MaxValue] [int] NULL,
	[MinValue] [int] NULL,
	[ErrorMessage] [varchar](max) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ValidationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ValidationType]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ValidationType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ValidationAnswerTypeId] [int] NOT NULL,
	[ValidationTypeName] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleModeId] [int] NOT NULL,
	[VehicleNumber] [varchar](max) NULL,
	[VehicleDescription] [varchar](max) NULL,
	[PickUpDriverName] [varchar](max) NULL,
	[PickUpDriverAddress] [varchar](max) NULL,
	[PickUpDriverContactNumber] [varchar](max) NULL,
	[PickUpDriverAdhaarNumber] [varchar](max) NULL,
	[DropDriverName] [varchar](max) NULL,
	[DropDriverAddress] [varchar](max) NULL,
	[DropDriverContactNumber] [varchar](max) NULL,
	[DropDriverAdhaarNumber] [varchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [varchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleMode]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleMode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleType] [varchar](max) NULL,
	[VehicleName] [varchar](max) NULL,
	[IsActive] [bit] NOT NULL DEFAULT ((0)),
	[CreatedBy] [varchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedBy] [varchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[YoutubeVideoList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[YoutubeVideoList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[LessonId] [int] NOT NULL,
	[VideoId] [varchar](max) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[ClassWiseStatus]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create View [dbo].[ClassWiseStatus] as
select sa.AdmissionNumber,au.FirstName +' '+  au.LastName as 'StudentName',sm.StreamName,cm.DepartmentStandardName,secm.Section,
                        fcm.CategoryName,sum(ftsm.FeeNameAmount) FeeAmount,sa.AcademicYearId,
                        (select CASE when (sum(ftdm.DiscountAmount)+sum(ftdm.PaidFeeAmount)) is null then 0 else
                        (sum(ftdm.DiscountAmount)+sum(ftdm.PaidFeeAmount)) end from  FeeTransactionMaster ftm
                          inner join FeeTransactionDetailMaster ftdm on ftdm.ReceiptNumber=ftm.ReceiptNumber
                          where ftm.AdmissionNumber=sa.AdmissionNumber and  ftm.IsDeleted=0 and  ftm.IsCancelled=0 AND
                         ftdm.IsDeleted=0 and ftm.AdmissionNumber=sa.AdmissionNumber) paidAmount,

                         sum(ftsm.FeeNameAmount)-(select CASE when (sum(ftdm.DiscountAmount)+sum(ftdm.PaidFeeAmount)) is null then 0 else
                        (sum(ftdm.DiscountAmount)+sum(ftdm.PaidFeeAmount)) end from  FeeTransactionMaster ftm
                          inner join FeeTransactionDetailMaster ftdm on ftdm.ReceiptNumber=ftm.ReceiptNumber
                          where ftm.AdmissionNumber=sa.AdmissionNumber and  ftm.IsDeleted=0 and  ftm.IsCancelled=0 AND
                         ftdm.IsDeleted=0 and ftm.AdmissionNumber=sa.AdmissionNumber) PendingAmount,

 case when (sum(ftsm.FeeNameAmount)-(select CASE when (sum(ftdm.DiscountAmount)+sum(ftdm.PaidFeeAmount)) is null then 0 else
                        (sum(ftdm.DiscountAmount)+sum(ftdm.PaidFeeAmount)) end from  FeeTransactionMaster ftm
                          inner join FeeTransactionDetailMaster ftdm on ftdm.ReceiptNumber=ftm.ReceiptNumber
                          where ftm.AdmissionNumber=sa.AdmissionNumber and  ftm.IsDeleted=0 and  ftm.IsCancelled=0 AND
                         ftdm.IsDeleted=0 and ftm.AdmissionNumber=sa.AdmissionNumber)) = 0 then 'Paid'


when (sum(ftsm.FeeNameAmount)-(select CASE when (sum(ftdm.DiscountAmount)+sum(ftdm.PaidFeeAmount)) is null then 0 else
                        (sum(ftdm.DiscountAmount)+sum(ftdm.PaidFeeAmount)) end from  FeeTransactionMaster ftm
                          inner join FeeTransactionDetailMaster ftdm on ftdm.ReceiptNumber=ftm.ReceiptNumber
                          where ftm.AdmissionNumber=sa.AdmissionNumber and  ftm.IsDeleted=0 and  ftm.IsCancelled=0 AND
                         ftdm.IsDeleted=0 and ftm.AdmissionNumber=sa.AdmissionNumber)) < sum(FeeNameAmount) then 'Pending'

when (sum(ftsm.FeeNameAmount)-(select CASE when (sum(ftdm.DiscountAmount)+sum(ftdm.PaidFeeAmount)) is null then 0 else
                        (sum(ftdm.DiscountAmount)+sum(ftdm.PaidFeeAmount)) end from  FeeTransactionMaster ftm
                          inner join FeeTransactionDetailMaster ftdm on ftdm.ReceiptNumber=ftm.ReceiptNumber
                          where ftm.AdmissionNumber=sa.AdmissionNumber and  ftm.IsDeleted=0 and  ftm.IsCancelled=0 AND
                         ftdm.IsDeleted=0 and ftm.AdmissionNumber=sa.AdmissionNumber)) = sum(FeeNameAmount) then 'UnPaid'
end Status



                        from StudentInformation sa inner join Enlighten.dbo.ApplicationUser au on au.StudentInformationId=sa.AdmissionNumber inner join FeeStructure ftsm on ftsm.CategoryMasterId=sa.FeeCategoryId
                         inner join StreamMaster sm on sm.Id=sa.StreamId
                         inner join DepartmentStandard cm on cm.Id=sa.ClassId
                         inner join Division secm on secm.Id=sa.Sectionid
                         inner join CategoryMaster fcm on fcm.id=sa.FeeCategoryId
                        where sa.IsDeleted=0 and sa.IsReleved=0 and ftsm.IsDeleted=0 and ftsm.DepartmentStandardId=sa.ClassId
                        and sm.IsDeleted=0 and cm.IsDeleted=0 and secm.IsDeleted=0 and fcm.IsDeleted=0
                        and sa.StreamId =sa.streamId group by sa.AdmissionNumber,au.FirstName,au.LastName,sm.StreamName,cm.DepartmentStandardName,secm.Section,
                        fcm.CategoryName,sa.AcademicYearId



GO

SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[FileType] ON 

INSERT [dbo].[FileType] ([Id], [FileTypeName]) VALUES (1, N'Education')
INSERT [dbo].[FileType] ([Id], [FileTypeName]) VALUES (2, N'Experience')
INSERT [dbo].[FileType] ([Id], [FileTypeName]) VALUES (3, N'Documents')
SET IDENTITY_INSERT [dbo].[FileType] OFF

SET IDENTITY_INSERT [dbo].[QuestionAnswerType] ON 

INSERT [dbo].[QuestionAnswerType] ([Id], [AnswerTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (1, N'Short Answer', 1, 0, CAST(N'2021-11-27 18:31:47.460' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[QuestionAnswerType] ([Id], [AnswerTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (2, N'Paragraph', 1, 0, CAST(N'2021-11-27 18:31:47.463' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[QuestionAnswerType] ([Id], [AnswerTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (3, N'Upload Files', 1, 0, CAST(N'2021-11-27 18:31:47.463' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[QuestionAnswerType] ([Id], [AnswerTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (4, N'Multiple Choice', 1, 0, CAST(N'2021-11-27 18:31:47.463' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[QuestionAnswerType] ([Id], [AnswerTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (5, N'Checkboxes', 1, 0, CAST(N'2021-11-27 18:31:47.463' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[QuestionAnswerType] ([Id], [AnswerTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (6, N'Dropdown', 1, 0, CAST(N'2021-11-27 18:31:47.463' AS DateTime), NULL, NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[QuestionAnswerType] OFF
SET IDENTITY_INSERT [dbo].[ValidationAnswerType] ON 

INSERT [dbo].[ValidationAnswerType] ([Id], [AnswerTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (1, N'Number', 1, 0, CAST(N'2021-11-29 11:52:38.850' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[ValidationAnswerType] ([Id], [AnswerTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (2, N'Text', 1, 0, CAST(N'2021-11-29 11:52:38.873' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[ValidationAnswerType] ([Id], [AnswerTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (3, N'Length', 1, 0, CAST(N'2021-11-29 11:52:38.873' AS DateTime), NULL, NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[ValidationAnswerType] OFF
SET IDENTITY_INSERT [dbo].[ValidationType] ON 

INSERT [dbo].[ValidationType] ([Id], [ValidationAnswerTypeId], [ValidationTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (1, 1, N'Greater than', 1, 0, CAST(N'2021-11-27 18:45:22.400' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[ValidationType] ([Id], [ValidationAnswerTypeId], [ValidationTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (2, 1, N'Greater than or equal to', 1, 0, CAST(N'2021-11-27 18:45:22.400' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[ValidationType] ([Id], [ValidationAnswerTypeId], [ValidationTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (3, 1, N'Less than', 1, 0, CAST(N'2021-11-27 18:45:22.400' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[ValidationType] ([Id], [ValidationAnswerTypeId], [ValidationTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (4, 1, N'Less than or equal to', 1, 0, CAST(N'2021-11-27 18:45:22.400' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[ValidationType] ([Id], [ValidationAnswerTypeId], [ValidationTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (5, 1, N'Equal to', 1, 0, CAST(N'2021-11-27 18:45:22.400' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[ValidationType] ([Id], [ValidationAnswerTypeId], [ValidationTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (6, 1, N'Not equal to', 1, 0, CAST(N'2021-11-27 18:45:22.400' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[ValidationType] ([Id], [ValidationAnswerTypeId], [ValidationTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (7, 1, N'Between', 1, 0, CAST(N'2021-11-27 18:45:22.400' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[ValidationType] ([Id], [ValidationAnswerTypeId], [ValidationTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (8, 1, N'Not between', 1, 0, CAST(N'2021-11-27 18:45:22.400' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[ValidationType] ([Id], [ValidationAnswerTypeId], [ValidationTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (9, 1, N'Is number', 1, 0, CAST(N'2021-11-27 18:45:22.400' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[ValidationType] ([Id], [ValidationAnswerTypeId], [ValidationTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (10, 1, N'Whole number', 1, 0, CAST(N'2021-11-27 18:45:22.400' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[ValidationType] ([Id], [ValidationAnswerTypeId], [ValidationTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (11, 2, N'Contains', 1, 0, CAST(N'2021-11-27 18:48:20.510' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[ValidationType] ([Id], [ValidationAnswerTypeId], [ValidationTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (12, 2, N'Doesnt contains', 1, 0, CAST(N'2021-11-27 18:48:20.510' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[ValidationType] ([Id], [ValidationAnswerTypeId], [ValidationTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (13, 3, N'Maximum character count', 1, 0, CAST(N'2021-11-27 18:48:20.510' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[ValidationType] ([Id], [ValidationAnswerTypeId], [ValidationTypeName], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [DeletedBy], [DeletedOn], [IsDeleted]) VALUES (14, 3, N'Minimum character count', 1, 0, CAST(N'2021-11-27 18:48:20.510' AS DateTime), NULL, NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[ValidationType] OFF

ALTER TABLE [dbo].[PaymentDetail] ADD  DEFAULT ((0)) FOR [Varified]
GO
ALTER TABLE [dbo].[PaymentDetail] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[PreviousBalanceFee] ADD  DEFAULT ((0)) FOR [IsPaid]
GO
ALTER TABLE [dbo].[PreviousBalanceFee] ADD  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[YoutubeVideoList] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  StoredProcedure [dbo].[AddAndCalculateBalanceFee]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddAndCalculateBalanceFee](@applicationUserId int,@categoryId int,@createdBy int)
as
begin

Declare @totalPendingFee decimal
Declare @feeAmount decimal
Declare @conveyanceFee decimal(10,2)
set @conveyanceFee=0

Declare @currentdepartmentId int
set @currentdepartmentId=(select DepartmentStandardId from StudentInDepartmentStandard where ApplicationUserId=@applicationUserId and IsActive=1 and IsDeleted=0)

Declare @currentCategoryId int
set @currentCategoryId=(select CategoryId from StudentInDepartmentStandard where ApplicationUserId=@applicationUserId and IsActive=1 and IsDeleted=0)

set @feeAmount=(Select Sum(FeeNameAmount) from FeeStructure fs inner join FeeTypeMaster ftm on fs.FeeTypeMasterId=ftm.Id where fs.IsActive=1 and fs.IsDeleted=0 and ftm.IsDeleted=0 and ftm.IsActive=1 
and fs.DepartmentStandardId=@currentdepartmentId and fs.CategoryMasterId=@currentCategoryId)

Declare @IsConveyance int
Declare @IsOneWayTrip int
Declare @areaId int
Declare @vehicleModeId int
set @IsConveyance=(select HasConveyance from StudentInDepartmentStandard where ApplicationUserId=@applicationUserId and IsActive=1 and IsDeleted=0)
set @IsOneWayTrip=(select IsOneWayTrip from StudentInDepartmentStandard where ApplicationUserId=@applicationUserId and IsActive=1 and IsDeleted=0)
set @areaId=(select AreaId from StudentInDepartmentStandard where ApplicationUserId=@applicationUserId and IsActive=1 and IsDeleted=0)
set @vehicleModeId=(select ModeId from StudentInDepartmentStandard where ApplicationUserId=@applicationUserId and IsActive=1 and IsDeleted=0)

if(@IsConveyance=1)
Begin
	
		select * into #ConveyanceFeeMonth from  ConveyanceMonthForStudent where ApplicationUserId=@applicationUserId and IsDeleted=0 and IsActive=1
		declare @numberofrows int,@i int
		set @i=0
		set @numberofrows=(select count(*) from #ConveyanceFeeMonth)
		while (@i<@numberofrows)
 		Begin
			Declare @transportFeeAmount int
			Declare @transportValue decimal(10,2)
			set @transportFeeAmount=(select TransportAmount from TransportPrice where AreaMasterId=@areaId and VehicleModeId=@vehicleModeId and IsDeleted=0 and IsActive=1)
			if(@IsOneWayTrip=0)
			Begin
					set @transportValue=@transportFeeAmount
					set @conveyanceFee=@conveyanceFee+@transportValue

			End
			else
			Begin 
					set @transportValue=(@transportFeeAmount/2)
					set @conveyanceFee=@conveyanceFee+@transportValue
			End
			set @i=@i+1
		End
End

set @totalPendingFee=@feeAmount+@conveyanceFee;

Declare @paidFee decimal(10,2)
set @paidFee=0
Declare @isFeeCount int
set @isFeeCount=(select Count(*) from FeeTransaction where ApplicationUserId=@applicationUserId and DepartmentId=@currentdepartmentId and IsDeleted=0)
if(@isFeeCount>0)
begin
set @paidFee=(select sum(TotalFeeAmount) from FeeTransaction where ApplicationUserId=@applicationUserId and DepartmentId=@currentdepartmentId and IsDeleted=0)
end


Declare @currentYearBalanceFee decimal(10,2)
set @currentYearBalanceFee=@totalPendingFee-@paidFee

Declare @previousYearBalanceFee decimal(10,2)
set @previousYearBalanceFee=0
Declare @ispreviousBalanceFeeCount int
set @ispreviousBalanceFeeCount=(Select Count(*) from PreviousBalanceFee where IsDelete=0 and IsPaid=0 and ApplicationUserId=@applicationUserId)

if(@ispreviousBalanceFeeCount>0)
Begin
set @previousYearBalanceFee=(Select Sum(PreviousBalanceAmount) from PreviousBalanceFee where IsDelete=0 and IsPaid=0 and ApplicationUserId=@applicationUserId)
end

Declare @FinalTotalBalanceFee decimal(10,2)
set @FinalTotalBalanceFee =@previousYearBalanceFee+@currentYearBalanceFee

update PreviousBalanceFee set isPaid=1,IsDelete=1,DeletedBy=@createdBy,DeletedOn=GETDATE() where ApplicationUserId=@applicationUserId

Declare @divisionId int
set @divisionId=(select DivisionId from StudentInDepartmentStandard where ApplicationUserId=@applicationUserId and IsActive=1 and IsDeleted=0)

insert into PreviousBalanceFee(ApplicationUserId,DepartmentStandardId,DivisionId,PreviousBalanceAmount,IsPaid,CreatedBy,CreatedOn,IsDelete)
 values(@applicationUserId,@currentdepartmentId,@divisionId,@FinalTotalBalanceFee,0,@createdBy,GETDATE(),0)

end


GO
/****** Object:  StoredProcedure [dbo].[AddAreaMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddAreaMaster](@areaName varchar(max),@ispublished bit,@createdBy varchar(max))
as
begin
Insert into AreaMaster(AreaName,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@areaName,@ispublished,@createdBy,GETDATE(),0)
end
GO
/****** Object:  StoredProcedure [dbo].[AddAreaVehicleMapping]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddAreaVehicleMapping](@areaNameId int,@vehicleMasterId int,@ispublished bit,@createdBy varchar(max))
as
begin
Insert into AreaVehicleMapping(AreaMasterId,VehicleMasterId,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@areaNameId,@vehicleMasterId,@ispublished,@createdBy,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AddAssignment]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[AddAssignment](@departmentStandardId int,@courseSubjectId int,@lessonId int,@submissionDateTime DateTime,@title varchar(max),@description varchar(max),@filePath varchar(max)
,@applicationUserId int)
as
begin
Insert into Assignment(DepartmentId,CourseId,LessonId,Title,Description,SubmissionDate,AssignmentFilePath,CreatedBy,CreatedOn,IsDeleted) values(@departmentStandardId,@courseSubjectId,@lessonId,@title,@description,
@submissionDateTime,@filePath,@applicationUserId,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AddAssignNotice]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[AddAssignNotice](@noticeId int,@standardId int,@isforStudent bit,@createdBy int)
as
begin

Insert into AssignNotice(NoticeId,StandardId,IsForStudent,CreatedBy,CreatedOn)
 values(@noticeId,@standardId,@isforStudent,@createdBy,GETDATE())

end

GO
/****** Object:  StoredProcedure [dbo].[AddBankDetails]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddBankDetails](@applicationUserId int,@bankname varchar(50),@accountNumber varchar(50),@ifscCode varchar(25),@createdBy int,@accountHolderName varchar(25),@nickName varchar(25))
as
begin
insert into BankDetails(BankName,AccountNumber,IFSCCode,ApplicationUsedId,CreatedBy,CreatedOn,IsDeleted,AccountHolderName,NickName)
values(@bankname,@accountNumber,@ifscCode,@applicationUserId,@createdBy,GETDATE(),0,@accountHolderName,@nickName)
end

GO
/****** Object:  StoredProcedure [dbo].[AddConveyanceMonthForStudent]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddConveyanceMonthForStudent](@applicationUserId int,@standardId int,@divisionUserId int,@monthId int,@ispublished bit,@createdBy int)
as
Begin
Insert into ConveyanceMonthForStudent(ApplicationUserId,StandardId,DivisionId,MonthId,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@applicationUserId,@standardId,@divisionUserId,@monthId,@ispublished,@createdBy,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AddDocumentGoogleDrive]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[AddDocumentGoogleDrive](@deptId int,@courseId int,@lessonId int,@documentId varchar(max),@sharedLink varchar(max),@applicationUserId int)
as
begin
	insert into DocumentGoogleDrive(DepartmentID,CourseID,LessonID,DocumentID,SharedLink,CreatedBy,CreatedOn,IsDeleted) values(@deptId,@courseId,@lessonId,@documentId,@sharedLink,@applicationUserId,getdate(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AddExamSetting]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddExamSetting](@isNew bit,@isActive bit,@ExamName varchar(max),@departmentStandardId int,@courseSubjectId int,@totalMarks int,@examStartDateTime DateTime,@examEndDateTime DateTime,@updatedBy int,@examId int,@numberOfQuestion int,@durationInMinutes int)
as
begin

if(@isNew=1)
begin
Insert into Exam(ExamName,DepartmentStandardId,CourseSubjectId,TotalMarks,ExamStartDateTime,ExamEndDateTime,NumberOfQuestion,CreatedBy,CreatedOn,DurationInMinutes,IsActive,IsDeleted) 
values(@ExamName,@departmentStandardId,@courseSubjectId,@totalMarks,@examStartDateTime,@examEndDateTime,@numberOfQuestion,@updatedBy,GETDATE(),@durationInMinutes,@isActive,0)
end
else
Begin
Update Exam set TotalMarks=@totalMarks,ExamStartDateTime=@examStartDateTime,
ExamEndDateTime=@examEndDateTime,NumberOfQuestion=@numberOfQuestion,UpdatedBy=@updatedBy,UpdatedOn=GETDATE(),DurationInMinutes=@durationInMinutes where Id=@examId
End
end
GO
/****** Object:  StoredProcedure [dbo].[AddFeeGroup]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddFeeGroup](@feeGroupName varchar(max),@ispublished bit,@createdBy varchar(max))
as
begin
Insert into FeeGroup(FeeGroupName,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@feeGroupName,@ispublished,@createdBy,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AddFeeNameMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddFeeNameMaster](@feeName varchar(max),@refundableFee bit,@optionalFee bit,@discountOn bit,@conveyance bit,@feeDisplay bit,@transferHead bit,@feeGroupId int,@ispublished bit,@createdBy varchar(max))
as
begin
Insert into FeeNameMaster(FeeName,RefundableFee,OptionalFee,DiscountOn,Conveyance,FeeDisplay,TransferHead,FeeGroupId,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@feeName,@refundableFee,@optionalFee,@discountOn,@conveyance,@feeDisplay,@transferHead,@feeGroupId,@ispublished,@createdBy,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AddFeeStructure]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[AddFeeStructure](@departmentStandardId int,@feeNameMasterId int,@feeNameAmount int,@categoryMasterId int,@feeMonthId int,@ispublished bit,@createdBy int)
as
begin
Declare @FeeTypeId int;
set @FeeTypeId=(select distinct Id from FeeTypeMaster where DepartmentStandardId=@departmentStandardId and FeeNameMasterId=@feeNameMasterId and FeeMonthId=@feeMonthId and IsDeleted=0 and IsActive=1)

Insert into FeeStructure(DepartmentStandardId,FeeNameMasterId,FeeNameAmount,FeeTypeMasterId,CategoryMasterId,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@departmentStandardId,@feeNameMasterId,@feeNameAmount,@FeeTypeId,@categoryMasterId,@ispublished,@createdBy,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AddFeeTypeMasterAndFeeStructure]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddFeeTypeMasterAndFeeStructure](@departmentStandardId int,@dueDate datetime,@feeNameMasterId int,@feeNameAmount int,@categoryMasterId int,@lateFee int,@feeMonthId int,@ispublished bit,@createdBy int)
as
begin

Insert into FeeTypeMaster(DepartmentStandardId,DueDate,FeeNameMasterId,LateFee,FeeMonthId,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@departmentStandardId,@dueDate,@feeNameMasterId,@lateFee,@feeMonthId,@ispublished,@createdBy,GETDATE(),0)

 Declare @FeeTypeId int;
set @FeeTypeId=(select distinct Id from FeeTypeMaster where DepartmentStandardId=@departmentStandardId and FeeNameMasterId=@feeNameMasterId and FeeMonthId=@feeMonthId and IsDeleted=0)

Insert into FeeStructure(DepartmentStandardId,FeeNameMasterId,FeeNameAmount,FeeTypeMasterId,CategoryMasterId,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@departmentStandardId,@feeNameMasterId,@feeNameAmount,@FeeTypeId,@categoryMasterId,@ispublished,@createdBy,GETDATE(),0)

end

GO
/****** Object:  StoredProcedure [dbo].[AddFeeTypeMasterMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create procedure [dbo].[AddFeeTypeMasterMaster](@departmentStandardId int,@dueDate datetime,@feeNameMasterId int,@lateFee int,@feeMonthId int,@ispublished bit,@createdBy int)
as
begin
Insert into FeeTypeMaster(DepartmentStandardId,DueDate,FeeNameMasterId,LateFee,FeeMonthId,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@departmentStandardId,@dueDate,@feeNameMasterId,@lateFee,@feeMonthId,@ispublished,@createdBy,GETDATE(),0)
end


GO
/****** Object:  StoredProcedure [dbo].[AddMappingApplicationUserIdAndDepartmentStandard]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddMappingApplicationUserIdAndDepartmentStandard](@applicationUserId int,@departmentStandardId int,@divisionId int,@categoryId int,@areaId int,@hasConveyance bit,@modeId int,
@pickupVehicleNumber varchar(max),@dropVehicleNumber varchar(max),@pickUpVehicleNumberId int,@dropVehicleNumberId int,@isPublished bit,@createdBy int,@isOneTrip bit)
as
begin
insert into StudentInDepartmentStandard(DepartmentStandardId,ApplicationUserId,CreatedBy,CreatedOn,IsDeleted,DivisionId,CategoryId,AreaId,HasConveyance,ModeId,PickUpVehicleNumber,DropVehicleNumber,PickUpVehicleId
,DropVehicleId,IsActive,IsOneWayTrip)
values(@departmentStandardId,@applicationUserId,@createdBy,GETDATE(),0,@divisionId,@categoryId,@areaId,@hasConveyance,@modeId,
@pickupVehicleNumber,@dropVehicleNumber,@pickUpVehicleNumberId,@dropVehicleNumberId,@isPublished,@isOneTrip)
end


GO
/****** Object:  StoredProcedure [dbo].[AddNewAllotedQuestionExamAnswer]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddNewAllotedQuestionExamAnswer](@questionId int,@applicationUserId int,@examId int,@departmentStandardId int,@courseSubjectId int,@sequenceNumber int,@answer varchar(max),@marks int,@createdBy int,@numberOfAttempts int)
as
begin
	Insert into ExamAnswer(QuestionId,ApplicationUserId,DepartmentStandardId,CourseSubjectId,ExamId,Answer,Marks,SequenceNumber,CreatedBy,CreatedOn,IsDeleted,NumberOfAttempts)
	values(@questionId,@applicationUserId,@departmentStandardId,@courseSubjectId,@examId,@answer,@marks,@sequenceNumber,@createdBy,GETDATE(),0,@numberOfAttempts)
end




select * from ExamAnswer
select * from ExamAnswerLog
Select * from NumberOfExamAttempts


GO
/****** Object:  StoredProcedure [dbo].[AddNewAllotedQuestionExamAnswerLog]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddNewAllotedQuestionExamAnswerLog](@applicationUserId int,@questionId int,@examId int,@departmentStandardId int,@courseSubjectId int,@sequenceNumber int,@createdBy int,@numberOfAttempts int)
as
begin
	Insert into ExamAnswerLog(QuestionId,ApplicationUserId,DepartmentStandardId,CourseSubjectId,ExamId,SequenceNumber,CreatedBy,CreatedOn,IsDeleted,NumberOfAttempts)
	values(@questionId,@applicationUserId,@departmentStandardId,@courseSubjectId,@examId,@sequenceNumber,@createdBy,GETDATE(),0,@numberOfAttempts)
end


GO
/****** Object:  StoredProcedure [dbo].[AddNewCategoryMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddNewCategoryMaster](@categoryName varchar(max),@categoryDescription varchar(max),@ispublished bit,@createdBy varchar(max))
as
begin
Insert into CategoryMaster(CategoryName,CategoryDescription,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@categoryName,@categoryDescription,@ispublished,@createdBy,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AddNewComplaint]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[AddNewComplaint](@StreamId int,@ClassId int,@SectionId int,@AdmissionNumber varchar(max),@Complaint varchar(max),@createdBy varchar(max))
as
begin
Insert into ComplaintMaster(StreamId,ClassId,SectionId,AdmissionNumber,Complaint,CreatedBy,CreatedOn,IsDeleted)
 values(@StreamId,@ClassId,@SectionId,@AdmissionNumber,@Complaint,@createdBy,GETDATE(),0)
end
GO
/****** Object:  StoredProcedure [dbo].[AddNewCourseSubject]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddNewCourseSubject](@subjectId int,@courseSubjectName varchar(max),@departmentStandardID int,@ispublished bit,@createdBy int)
as
begin
Insert into CourseSubject(SubjectId,CourseSubjectName,DepartmentStandardID,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@subjectId,@courseSubjectName,@departmentStandardID,@ispublished,@createdBy,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AddNewDepartmentStandard]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddNewDepartmentStandard](@departmentName varchar(max),@ispublished bit,@createdBy varchar(max))
as
begin
Insert into DepartmentStandard(DepartmentStandardName,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@departmentName,@ispublished,@createdBy,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AddNewDivision]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddNewDivision](@divisionName varchar(max),@ispublished bit,@createdBy varchar(max))
as
begin
Insert into Division(Section,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@divisionName,@ispublished,@createdBy,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AddNewExam]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[AddNewExam](@examName varchar(max),@isActive bit,@createdBy int)
as
begin
Insert into Exam(ExamName,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@examName,@isActive,@createdBy,GETDATE(),0)
end


GO
/****** Object:  StoredProcedure [dbo].[AddNewExamCoveredTime]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddNewExamCoveredTime](@applicationUserId int,@departmentStandardId int,@courseSubjectId int,@examId int,@timeCoveredInMinutes int,@timeCoveredInSecond int,@numberOfAttempts int,@createdBy int
,@examStartDateTime dateTime,@examEndDateTime dateTime)
as
begin
Insert into ExamCoveredTime(DepartmentStandardId,CourseSubjectId,ExamId,TimeCoveredInMinutes,TimeCoveredInSecond,NumberOfAttempts,ApplicationUserId,CreatedBy,CreatedOn,IsDeleted,ExamStartDateTime,ExamEndDateTime) values(@departmentStandardId,
@courseSubjectId,@examId,@timeCoveredInMinutes,@timeCoveredInSecond,@numberOfAttempts,@applicationUserId,@createdBy,GETDATE(),0,@examStartDateTime,@examEndDateTime)
end

GO
/****** Object:  StoredProcedure [dbo].[AddNewFeeMonthMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddNewFeeMonthMaster](@feeMonth varchar(max),@feeMonthType varchar(max),@numberOfMonth int,@ispublished bit,@createdBy varchar(max))
as
begin
Insert into FeeMonthMaster(FeeMonth,FeeMonthType,NumberOfMonth,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@feeMonth,@feeMonthType,@numberOfMonth,@ispublished,@createdBy,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AddNewLesson]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[AddNewLesson](@departmentStandardId int,@courseSubjectId int,@lessonTitle varchar(50),@lessonDescription varchar(max),@isActive bit,@createdBy int)
as
begin
Insert into Lesson(DepartmentStandardId,CourseSubjectId,LessonTitle,LessonDescription,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@departmentStandardId,@courseSubjectId,@lessonTitle,@lessonDescription,@isActive,@createdBy,GETDATE(),0)
end


GO
/****** Object:  StoredProcedure [dbo].[AddNewQuestion]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddNewQuestion](@departmentStandardId int,@courseSubjectId int,@examId int,@question varchar(max)=NULL,@questionOptionMetadata varchar(max)=NULL,@correctOption varchar(max)=NULL,@questionAnswerTypeId int,
@marks int,@isRequired bit,@validationAnswerTypeId int,@validationAnswerId int,@valueToCompare varchar(50)=null,@minValue int,@maxValue int,@errorMessage varchar(max)=NULL,@createdBy int,@LASTID int)
as
begin
		Insert into Questionaire(DepartmentStandardId,CourseSubjectId,ExamId,Question,QuestionOptionMetadata,CorrectOption,QuestionAnswerTypeId,Marks,CreatedBy,CreatedOn,IsDeleted) 
		values(@departmentStandardId,@courseSubjectId,@examId,@question,@questionOptionMetadata,@correctOption,@questionAnswerTypeId,@marks,@createdBy,GETDATE(),0)

		SET @LASTID =IDENT_CURRENT('dbo.Questionaire');

		Insert into ValidationTable(QuestionId,IsRequired,ValidationAnswerTypeId,ValidationAnswerId,ValueToCompare,MaxValue,MinValue,ErrorMessage,CreatedBy,CreatedOn,IsDeleted)
		values(@LASTID,@isRequired,@validationAnswerTypeId,@validationAnswerId,@valueToCompare,@maxValue,@minValue,@errorMessage,@createdBy,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AddNewStudentResult]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddNewStudentResult](@applicationUserId int,@departmentStandardId int,@courseSubjectId int,@examId int,@totalObtainedMarks int,@numberOfAttempts int,@createdBy int)
as
begin
Insert into StudentResult(ApplicationUserId,DepartmentStandardId,CourseSubjectId,ExamId,TotalObtainedMarks,NumberOfAttempts,CreatedBy,CreatedOn,IsDeleted) values(@applicationUserId,@departmentStandardId,
@courseSubjectId,@examId,@totalObtainedMarks,@numberOfAttempts,@createdBy,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AddNewVehicleMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddNewVehicleMaster](@vehicleModeId int,@vehicleNumber varchar(max),@vehicleDescription varchar(max),@PickUpDriverName varchar(max),@pickUpDriverAddress varchar(max),@pickUpDriverContactNumber varchar(max)
,@pickUpDriverAdhaarNumber varchar(max),@dropDriverName varchar(max),@dropDriverAddress varchar(max),@dropDriverContactNumber varchar(max),@dropDriverAdhaarNumber varchar(max),@ispublished bit,@createdBy varchar(max))
as
begin
Insert into VehicleMaster(VehicleModeId,VehicleNumber,VehicleDescription,PickUpDriverName,PickUpDriverAddress,PickUpDriverContactNumber,PickUpDriverAdhaarNumber,DropDriverName,DropDriverAddress,DropDriverContactNumber,
DropDriverAdhaarNumber,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@vehicleModeId,@vehicleNumber,@vehicleDescription,@PickUpDriverName,@pickUpDriverAddress,@pickUpDriverContactNumber,@pickUpDriverAdhaarNumber,@dropDriverName,@dropDriverAddress,@dropDriverContactNumber,@dropDriverAdhaarNumber
 ,@ispublished,@createdBy,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AddNewVehicleMode]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddNewVehicleMode](@vehicleType varchar(max),@vehicleName varchar(max),@ispublished bit,@createdBy varchar(max))
as
begin
Insert into VehicleMode(VehicleType,VehicleName,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@vehicleType,@vehicleName,@ispublished,@createdBy,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AddNotice]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create procedure [dbo].[AddNotice](@noticeTitle varchar(max),@noticeDescription varchar(max),@ispublished bit,@createdBy int)
as
begin
Insert into Notice(Title,NoticeDescription,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@noticeTitle,@noticeDescription,@ispublished,@createdBy,GETDATE(),0)
end


GO
/****** Object:  StoredProcedure [dbo].[AddNumberOfExamAttemptsList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddNumberOfExamAttemptsList](@departmentStandardId int,@courseSubjectId int,@examId int,@applicationUserId int,@numberofAttempts int,@createdBy int)
as
begin
	Insert into NumberOfExamAttempts(ApplicationUserId,DepartmentStandardId,CourseSubjectId,ExamId,NumberOfAttempts,CreatedBy,CreatedOn,IsDeleted,IsChecked) 
	values(@applicationUserId,@departmentStandardId,@courseSubjectId,@examId,@numberofAttempts,@createdBy,GETDATE(),0,0)
end


GO
/****** Object:  StoredProcedure [dbo].[AddPlayList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddPlayList](@deptId int,@courseId int,@lessonId int,@playListId varchar(max),@applicationUserId int)
as
begin
	Insert into PlayList(DepartmentId,CourseId,LessonId,PlayListId,CreatedBy,CreatedOn,IsDeleted)
	 values(@deptId,@courseId,@lessonId,@playListId,@applicationUserId,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AddPlayListItem]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddPlayListItem](@deptId int,@courseId int,@lessonId int,@playListId varchar(max),@playListItemId varchar(max),@videoId varchar(max),@applicationUserId int)
as
begin
	Insert into PlayListItem(DepartmentId,CourseId,LessonId,PlayListId,PlayListItemId,VideoId,CreatedBy,CreatedOn,IsDeleted)
	 values(@deptId,@courseId,@lessonId,@playListId,@playListItemId,@videoId,@applicationUserId,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AddSessionEvent]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddSessionEvent](@applicationUserId int,@eventId varchar(max),@departmentId int)
as
begin
Insert into EventSession(EventId,DepartmentStandardId,CreatedBy,CreatedOn,IsDeleted) values(@eventId,@departmentId,@applicationUserId,GETDATE(),0)
End

GO
/****** Object:  StoredProcedure [dbo].[AddStudentAttendance]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddStudentAttendance](@standardId int=0,@divisionId int=0,@attendanceDate datetime,@applicationUserId int,@studentName varchar(max),@attendance varchar(max),@createdBy int)
as
begin
	Declare @count int;
	set @count=0;
	set @count=(select count(*) from StudentAttendance where StandardId=@standardId and DivisionId=@divisionId and AttendanceDate=@attendanceDate and ApplicationUserId=@applicationUserId)
	if(@count=0)
	Begin
		Insert into StudentAttendance(StandardId,DivisionId,AttendanceDate,ApplicationUserId,StudentName,Attandence,CreatedBy,CreatedOn,IsDeleted) 
		values(@standardId,@divisionId,@attendanceDate,@applicationUserId,@studentName,@attendance,@createdBy,getdate(),0)
	End
end


GO
/****** Object:  StoredProcedure [dbo].[AddStudentTransportHistory]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[AddStudentTransportHistory](@areaId int,@modeId int,@pickupvehichleNumber varchar(max),@pickupvehichleNumberId int,@dropVehicleNumber varchar(max),@dropVehicleNumberId int,
@fromDate datetime,@applicationUserId int,@isCurrentActive bit,@createdBy int,@isOneWayTrip bit)
as
Begin

Update StudentTransportHistory set IsCurrentActive=0 where ApplicationUserId=@applicationUserId


Insert into StudentTransportHistory(AreaId,ModeId,PickupvehichleNumber,PickupvehichleNumberId,DropVehicleNumber,DropVehicleNumberId,FromDate,ApplicationUserId,IsCurrentActive,
CreatedBy,CreatedOn,IsOneWayTrip)
 values(@areaId,@modeId,@pickupvehichleNumber,@pickupvehichleNumberId,@dropVehicleNumber,@dropVehicleNumberId,@fromDate,@applicationUserId,@isCurrentActive,@createdBy,GETDATE(),@isOneWayTrip)
end


GO
/****** Object:  StoredProcedure [dbo].[AddSubjectMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[AddSubjectMaster](@subjectName varchar(max),@ispublished bit,@createdBy int)
as
begin
Insert into SubjectMaster(SubjectName,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@subjectName,@ispublished,@createdBy,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AddTraineeAttendance]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[AddTraineeAttendance](@attendanceDate datetime,@applicationUserId int,@traineeName varchar(max),@traineeEmail varchar(max),@attendance varchar(max),@createdBy int)
as
begin
	Declare @count int;
	set @count=0;
	set @count=(select count(*) from TraineeAttendance where AttendanceDate=@attendanceDate and ApplicationUserId=@applicationUserId)
	if(@count=0)
	Begin
		Insert into TraineeAttendance(AttendanceDate,ApplicationUserId,TraineeName,TraineeEmail,Attandence,CreatedBy,CreatedOn,IsDeleted) 
		values(@attendanceDate,@applicationUserId,@traineeName,@traineeEmail,@attendance,@createdBy,getdate(),0)
	End
end

GO
/****** Object:  StoredProcedure [dbo].[AddTransportPrice]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[AddTransportPrice](@areaNameId int,@vehicleModeId int,@transportAmount int,@ispublished bit,@createdBy varchar(max))
as
begin
Insert into TransportPrice(AreaMasterId,VehicleModeId,TransportAmount,IsActive,CreatedBy,CreatedOn,IsDeleted)
 values(@areaNameId,@vehicleModeId,@transportAmount,@ispublished,@createdBy,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AddUpdateConveyanceMonthForStudent]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[AddUpdateConveyanceMonthForStudent](@applicationUserId int,@updatedBy int)
as
Begin
update ConveyanceMonthForStudent set IsActive=0,IsDeleted=1,DeletedBy=@updatedBy,DeletedOn=GETDATE() where  ApplicationUserId=@applicationUserId

end

GO
/****** Object:  StoredProcedure [dbo].[AddYoutubeVideo]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddYoutubeVideo](@deptId int,@courseId int,@lessonId int,@videoId varchar(max),@applicationUserId int)
as
begin
	Insert into YoutubeVideoList(DepartmentId,CourseId,LessonId,VideoId,CreatedBy,CreatedOn,IsDeleted)
	 values(@deptId,@courseId,@lessonId,@videoId,@applicationUserId,GETDATE(),0)
end


GO
/****** Object:  StoredProcedure [dbo].[AssignClassDivisionAllotment]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[AssignClassDivisionAllotment](@departmentStandardId int,@divisionId int,@createdBy int)
as
begin
Insert into ClassDivisionAllotment(DepartmentStandardId,DivisionId,CreatedBy,CreatedOn,IsDeleted)
 values(@departmentStandardId,@divisionId,@createdBy,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[AssignmentList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AssignmentList](@departmentStandardId int,@courseSubjectId int,@lessonId int)
as
begin
select a.Id,ds.DepartmentStandardName as 'DepartmentName',cs.CourseSubjectName as 'CourseName',l.LessonTitle as 'LessonName',a.Title,a.Description,a.SubmissionDate,a.AssignmentFilePath
 from Assignment a inner join DepartmentStandard ds on a.DepartmentId=ds.Id inner join CourseSubject cs on a.CourseId=cs.Id inner join Lesson l on a.lessonId=l.id where a.DepartmentId=@departmentStandardId and 
a.CourseId=@courseSubjectId and a.LessonId=@lessonId and a.IsDeleted=0 and ds.IsDeleted=0 and cs.IsDeleted=0 and l.IsDeleted=0
end

GO
/****** Object:  StoredProcedure [dbo].[AssignmentListUnderDepartment]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AssignmentListUnderDepartment](@departmentStandardId int)
as
begin
select a.Id,ds.DepartmentStandardName as 'DepartmentName',cs.CourseSubjectName as 'CourseName',l.LessonTitle as 'LessonName',a.Title,a.Description,a.SubmissionDate,a.AssignmentFilePath
 from Assignment a inner join DepartmentStandard ds on a.DepartmentId=ds.Id inner join CourseSubject cs on a.CourseId=cs.Id inner join Lesson l on a.lessonId=l.id where a.DepartmentId=@departmentStandardId and 
 a.IsDeleted=0 and ds.IsDeleted=0 and cs.IsDeleted=0 and l.IsDeleted=0 order by SubmissionDate asc
end

GO
/****** Object:  StoredProcedure [dbo].[AssignTenantGroupDepartmentAndCourseToTrainee]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AssignTenantGroupDepartmentAndCourseToTrainee](@departmentStandardId int,@applicationUserId int,@courseSubjectId int,@createdBy int)
as
begin
insert into TraineeInDeoartmentandCourse(ApplicationUserId,DepartmentStandardId,CourseSubjectId,CreatedBy,CreatedOn,IsDeleted) values(@applicationUserId,@departmentStandardId,@courseSubjectId,@createdBy,getdate(),0)
end


GO
/****** Object:  StoredProcedure [dbo].[CheckIsUserAlreadyExists]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[CheckIsUserAlreadyExists](@applicationUserId int)
as
Begin
Declare @isExists bit
if exists (select * from StudentInDepartmentStandard where ApplicationUserId=@applicationUserId and IsDeleted=0 and IsActive=1 ) 
select 'True' as IsExists 
else 
select 'False' as IsExists
return
end

GO
/****** Object:  StoredProcedure [dbo].[CheckPreviousBalanceExists]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create  procedure [dbo].[CheckPreviousBalanceExists]
 @applicationUserId int
  as
    begin
select * from PreviousBalanceFee where IsPaid=0 and IsDelete=0 and ApplicationUserId=@applicationUserId
 end

GO
/****** Object:  StoredProcedure [dbo].[DeleteAreaMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DeleteAreaMaster](@id int,@deletedBy varchar(max))
as
begin
Update AreaMaster set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteAreaVehicleMapping]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DeleteAreaVehicleMapping](@id int,@deletedBy varchar(max))
as
begin
Update AreaVehicleMapping set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteAssignment]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DeleteAssignment](@id int,@applicationUserId int)
as
begin
Update Assignment set UpdatedBy=@applicationUserId,UpdatedOn=getdate(),DeletedBy=@applicationUserId,DeletedOn=GETDATE(),IsDeleted=1  where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteAssignNotice]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[DeleteAssignNotice](@noticeId int)
as
begin

delete from AssignNotice where NoticeId =@noticeId

end

GO
/****** Object:  StoredProcedure [dbo].[DeleteCategoryMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DeleteCategoryMaster](@id int,@deletedBy varchar(max))
as
begin
Update CategoryMaster set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteClassDivisionAllotment]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[DeleteClassDivisionAllotment](@id int,@deletedBy int)
as
begin
Update ClassDivisionAllotment set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteComplaint]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[DeleteComplaint](@id int,@deletedBy varchar(max))
as
begin
Update ComplaintMaster set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteCourseSubject]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeleteCourseSubject](@id int,@deletedBy int)
as
begin
Update CourseSubject set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where Id=@id
end



GO
/****** Object:  StoredProcedure [dbo].[DeleteDepartmentStandard]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DeleteDepartmentStandard](@id int,@deletedBy varchar(max))
as
begin
Update DepartmentStandard set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where Id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteDivision]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DeleteDivision](@id int,@deletedBy varchar(max))
as
begin
Update Division set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteDocumentGoogleDrive]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DeleteDocumentGoogleDrive](@fileId varchar(max),@applicationUserId int)
as
begin
	update DocumentGoogleDrive set IsDeleted=1,DeletedBy=@applicationUserId,DeletedOn=GETDATE() where DocumentID=@fileId 
end


GO
/****** Object:  StoredProcedure [dbo].[DeleteExam]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeleteExam](@examid int,@deletedBy int)
as
begin
update Exam set IsDeleted=1,DeletedBy=@deletedBy,DeletedOn=GETDATE() where Id=@examid
end


GO
/****** Object:  StoredProcedure [dbo].[DeleteFeeGroup]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DeleteFeeGroup](@id int,@deletedBy varchar(max))
as
begin
Update FeeGroup set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteFeeMonthMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DeleteFeeMonthMaster](@id int,@deletedBy varchar(max))
as
begin
Update FeeMonthMaster set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteFeeNameMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[DeleteFeeNameMaster](@id int,@deletedBy varchar(max))
as
begin
Update FeeNameMaster set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteFeeStructure]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[DeleteFeeStructure](@id int,@deletedBy int)
as
begin
Update FeeStructure set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where Id=@id
end


GO
/****** Object:  StoredProcedure [dbo].[DeleteFeeTypeMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[DeleteFeeTypeMaster](@id int,@deletedBy int)
as
begin
Update FeeTypeMaster set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where Id=@id
end


GO
/****** Object:  StoredProcedure [dbo].[DeleteLearnerExamAnswerLog]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DeleteLearnerExamAnswerLog](@departmentStandardId int,@courseSubjectId int,@examId int,@applicationUserId int,@attemptNumber int)
as
begin
delete from ExamAnswerLog where DepartmentStandardId=@departmentStandardId and CourseSubjectId=@courseSubjectId and ExamId=@examId and ApplicationUserId=@applicationUserId and NumberOfAttempts=@attemptNumber
delete from ExamCoveredTime where DepartmentStandardId=@departmentStandardId and CourseSubjectId=@courseSubjectId and ExamId=@examId and ApplicationUserId=@applicationUserId and NumberOfAttempts=@attemptNumber
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteLesson]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[DeleteLesson](@id int,@deletedBy int)
as
begin
Update Lesson set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteMappingApplicationUserIdAndDepartmentStandard]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[DeleteMappingApplicationUserIdAndDepartmentStandard](@id int,@updatedBy int)
as
begin
update StudentInDepartmentStandard set IsDeleted=1,UpdatedBy=@updatedBy,UpdatedOn=GETDATE(),DeletedBy=@updatedBy,DeletedOn=GETDATE() where id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteNotice]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[DeleteNotice](@id int,@deletedBy int)
as
begin
Update Notice set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where Id=@id
end


GO
/****** Object:  StoredProcedure [dbo].[DeletePlayList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DeletePlayList](@playListId varchar(max),@applicationUserId int)
as
begin
	Update PlayList set IsDeleted=1,DeletedBy=@applicationUserId,DeletedOn=GETDATE() where PlayListId=@playListId
end

GO
/****** Object:  StoredProcedure [dbo].[DeletePlayListItem]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DeletePlayListItem](@playListId varchar(max),@applicationUserId int,@listItemId varchar(max))
as
begin
	Update PlayListItem set IsDeleted=1,DeletedBy=@applicationUserId,DeletedOn=GETDATE() where PlayListId=@playListId and PlayListItemId=@listItemId
end

GO
/****** Object:  StoredProcedure [dbo].[deletePreviousExamAnswerLog]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[deletePreviousExamAnswerLog](@id int)
as
begin
	delete from ExamAnswerLog where Id =@id
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteQuestionAndValidationTable]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeleteQuestionAndValidationTable](@id int,@deletedBy int)
as
begin
Update Questionaire set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where Id=@id

update ValidationTable set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where QuestionId=@id
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteSessionEvent]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DeleteSessionEvent](@applicationUserId int,@eventId varchar(max))
as
begin
Update EventSession set DeletedBy=@applicationUserId,DeletedOn=getdate(),IsDeleted=1 where EventId=@eventId
End

GO
/****** Object:  StoredProcedure [dbo].[DeleteSubjectMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DeleteSubjectMaster](@id int,@deletedBy int)
as
begin
Update SubjectMaster set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteTransportPrice]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DeleteTransportPrice](@id int,@deletedBy varchar(max))
as
begin
Update TransportPrice set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where Id=@id
end


GO
/****** Object:  StoredProcedure [dbo].[DeleteVehicleMaster]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DeleteVehicleMaster](@id int,@deletedBy varchar(max))
as
begin
Update VehicleMaster set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteVehicleMode]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DeleteVehicleMode](@id int,@deletedBy varchar(max))
as
begin
Update VehicleMode set DeletedBy=@deletedBy,DeletedOn=getdate(),IsDeleted=1 where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[EditMappingApplicationUserIdAndDepartmentStandard]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[EditMappingApplicationUserIdAndDepartmentStandard](@id int,@applicationUserId int,@departmentStandardId int,@divisionId int,@categoryId int,@areaId int,@hasConveyance bit,@modeId int,
@pickupVehicleNumber varchar(max),@dropVehicleNumber varchar(max),@pickUpVehicleNumberId int,@dropVehicleNumberId int,@isPublished bit,@updatedBy int,@isOneTrip bit)
as
begin
update StudentInDepartmentStandard set DepartmentStandardId=@departmentStandardId,ApplicationUserId=@applicationUserId,UpdatedBy=@updatedBy,UpdatedOn=GETDATE(),IsDeleted=0,DivisionId=@divisionId
,CategoryId=@categoryId,AreaId=@areaId,HasConveyance=@hasConveyance,ModeId=@modeId,PickUpVehicleNumber=@pickupVehicleNumber,DropVehicleNumber=@dropVehicleNumber,PickUpVehicleId=@pickUpVehicleNumberId
,DropVehicleId=@dropVehicleNumberId,IsActive=@isPublished,IsOneWayTrip=@isOneTrip where id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[GenerateReceiptNumber]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

									 
Create procedure [dbo].[GenerateReceiptNumber]
                                    (
                                    @ReceiptDt date,@applicationUserId int,@id int output)
                                    as
                                    begin
                                    
                                    insert into FeeReceipt(ReceiptDate,ApplicationUserId,CreatedBy,CreatedOn,IsDeleted) values(@ReceiptDt,@applicationUserId,@applicationUserId,GETDATE(),0)
                                    SET @id = SCOPE_IDENTITY();
                                    return @id
                                    end          

GO
/****** Object:  StoredProcedure [dbo].[GetAllDepartmentUnderStudentList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetAllDepartmentUnderStudentList]
@studentId int=0
as
  begin
	select sids.*,ds.DepartmentStandardName,d.Section,cm.CategoryName,am.AreaName,(select VehicleName from VehicleMode where id=sids.ModeId) as 'VehicleName'
	,sids.PickUpVehicleNumber,sids.DropVehicleNumber,sids.IsActive from Enlighten.dbo.ApplicationUser au 
	inner join StudentInDepartmentStandard sids on au.ApplicationUserId=sids.ApplicationUserId  
	inner join DepartmentStandard ds on ds.Id=sids.DepartmentStandardId
	inner join CategoryMaster cm on cm.id=sids.CategoryId 
	inner join Division d on d.id=sids.DivisionId
	inner join AreaMaster am on am.Id=sids.AreaId 
	where sids.ApplicationUserId=@studentId and  au.IsDeleted=0 and
	sids.IsDeleted=0 and
	ds.IsActive=1 and ds.IsDeleted=0 and
	cm.IsActive=1 and cm.IsDeleted=0 and
	d.IsActive=1 and d.IsDeleted=0 and
	am.IsActive=1 and am.IsDeleted=0
 end

GO
/****** Object:  StoredProcedure [dbo].[GetAllotedExamAnswerLog]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAllotedExamAnswerLog](@applicationUserId int,@examId int,@departmentStandardId int,@courseSubjectId int,@numberOfAttempts int=null)
as
begin
	select * from ExamAnswerLog where ApplicationUserId=@applicationUserId and DepartmentStandardId=@departmentStandardId and CourseSubjectId=@courseSubjectId and ExamId=@examId and IsDeleted=0 and NumberOfAttempts= @numberOfAttempts
end


GO
/****** Object:  StoredProcedure [dbo].[GetAllStudentAttendanceByMonth]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAllStudentAttendanceByMonth](
@departmentId int,
@divisionId int,
@month AS INT,
@Year AS INT
)
as
begin


Declare @CreateTableQuery varchar(max)='';

;WITH N(N)AS 
(SELECT 1 FROM(VALUES(1),(1),(1),(1),(1),(1))M(N)),
tally(N)AS(SELECT ROW_NUMBER()OVER(ORDER BY N.N)FROM N,N a)
SELECT N day,datefromparts(@year,@month,N) date INTO #tmpmonthandYear FROM tally
WHERE N <= day(EOMONTH(datefromparts(@year,@month,1)))

Create Table #MonthlyAttendance(ApplicationUserId int,StudentName varchar(max))

set @CreateTableQuery='Alter Table #MonthlyAttendance add '
declare @numberofrowsinmonthdays int,@i int
set @i=0
set @numberofrowsinmonthdays=(select count(*) from #tmpmonthandYear)
while(@i<@numberofrowsinmonthdays)
Begin
set @CreateTableQuery=@CreateTableQuery+ ' Day'+ Cast((@i+1) as varchar(max)) +' varchar(max) '
if((@i+1)!=@numberofrowsinmonthdays)
Begin
set @CreateTableQuery=@CreateTableQuery+ ' , '
End

set @i=@i+1
End
set @CreateTableQuery=@CreateTableQuery+''

EXEC(@CreateTableQuery)

select au.ApplicationUserId,au.FirstName +' '+ au.LastName as 'StudentName' INTO #tempstudentDetail from Enlighten.dbo.ApplicationUser au inner join StudentInDepartmentStandard sids on au.ApplicationUserId=sids.ApplicationUserId where sids.IsActive=1 and sids.IsDeleted=0 and au.IsDeleted=0 and 
sids.DepartmentStandardId=@departmentId and sids.DivisionId=@divisionId



declare @numberofrowsintempstudentDetail int,@j int
set @j=0
set @numberofrowsintempstudentDetail=(select count(*) from #tempstudentDetail)
While(@j<@numberofrowsintempstudentDetail)
Begin
declare @studentName varchar(max);
declare @applicationStudentId int;
 			set @studentName=(SELECT StudentName FROM (SELECT *,ROW_NUMBER() OVER (ORDER BY (Select 0)) R FROM  #tempstudentDetail ) Temp WHERE R=(@j+1))
			set @applicationStudentId=(SELECT ApplicationUserId FROM (SELECT *,ROW_NUMBER() OVER (ORDER BY (Select 0)) R FROM  #tempstudentDetail ) Temp WHERE R=(@j+1))
			
			Declare @insertMonthlyAttendance varchar(max);
			Declare @k int
			set @k=0
			set @insertMonthlyAttendance='Insert into #MonthlyAttendance(ApplicationUserId ,StudentName,'
				while(@k<@numberofrowsinmonthdays)
				Begin
				set @insertMonthlyAttendance=@insertMonthlyAttendance+ ' Day'+  Cast((@k+1) as varchar(max)) +'  '
				if((@k+1)!=@numberofrowsinmonthdays)
				Begin
				set @insertMonthlyAttendance=@insertMonthlyAttendance + ' , '
				End
				set @k=@k+1
				End
			 set @insertMonthlyAttendance=@insertMonthlyAttendance+')'
			  set @insertMonthlyAttendance=@insertMonthlyAttendance+' values('+Cast(@applicationStudentId as varchar(26))+','''+@studentName+''','
				Declare @l int
				set @l=0
				while(@l<@numberofrowsinmonthdays)
				Begin
				declare @attendanceDate varchar(max);
				declare @attendance varchar(max);
 					set @attendanceDate=(SELECT date FROM (SELECT *,ROW_NUMBER() OVER (ORDER BY (Select 0)) R FROM  #tmpmonthandYear ) Temp WHERE R=(@l+1))
					set @attendance=(SELECT Attandence FROM StudentAttendance WHERE
					 StandardId = @departmentId and DivisionId = @divisionId AND ApplicationUserId=@applicationStudentId and IsDeleted=0 and AttendanceDate=@attendanceDate)
				if(@attendance is NULL)
				Begin
					set @attendance=' '
				End
				set @insertMonthlyAttendance=@insertMonthlyAttendance+ ''''+ @attendance +''''
				
				if((@l+1)!=@numberofrowsinmonthdays)
				Begin
				set @insertMonthlyAttendance=@insertMonthlyAttendance + ' , '
				End
					
				set @l=@l+1
				End
			set @insertMonthlyAttendance=@insertMonthlyAttendance+')'
			--select @insertMonthlyAttendance
			EXEC(@insertMonthlyAttendance)
		
			set @insertMonthlyAttendance='';
			--set @applicationStudentId=0;
			--set @studentName='';
set @j=@j+1
End

select * from #MonthlyAttendance
End


GO
/****** Object:  StoredProcedure [dbo].[GetAllStudentAttendanceByStandardId]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GetAllStudentAttendanceByStandardId](@standardId int=0)
as
begin
	Select * from StudentAttendance where StandardId=@standardId
end

GO
/****** Object:  StoredProcedure [dbo].[GetAllTempPaymentDetail]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROCEDURE [dbo].[GetAllTempPaymentDetail]
                                AS
                                BEGIN
                                select tpd.Id,tpd.ApplicationUserId,tpd.ReferenceNumber,tpd.StandardId,ds.DepartmentStandardName,tpd.GrandTotal,au.FirstName+ ' ' + au.LastName as FullName ,tpd.TransactionDate,'' as status from TempPaymentDetail tpd inner join Enlighten.dbo.ApplicationUser au 
								on tpd.ApplicationUserId=au.ApplicationUserId inner join DepartmentStandard ds on ds.id=tpd.StandardId where verified=0
                                END


GO
/****** Object:  StoredProcedure [dbo].[GetAllTraineeAttendanceByMonth]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GetAllTraineeAttendanceByMonth](
@clientId varchar(max),
@month AS INT,
@Year AS INT
)
as
begin


Declare @CreateTableQuery varchar(max)='';

;WITH N(N)AS 
(SELECT 1 FROM(VALUES(1),(1),(1),(1),(1),(1))M(N)),
tally(N)AS(SELECT ROW_NUMBER()OVER(ORDER BY N.N)FROM N,N a)
SELECT N day,datefromparts(@year,@month,N) date INTO #tmpmonthandYear FROM tally
WHERE N <= day(EOMONTH(datefromparts(@year,@month,1)))

Create Table #MonthlyAttendance(ApplicationUserId int,TraineeName varchar(max),EmailId varchar(max))

set @CreateTableQuery='Alter Table #MonthlyAttendance add '
declare @numberofrowsinmonthdays int,@i int
set @i=0
set @numberofrowsinmonthdays=(select count(*) from #tmpmonthandYear)
while(@i<@numberofrowsinmonthdays)
Begin
set @CreateTableQuery=@CreateTableQuery+ ' Day'+ Cast((@i+1) as varchar(max)) +' varchar(max) '
if((@i+1)!=@numberofrowsinmonthdays)
Begin
set @CreateTableQuery=@CreateTableQuery+ ' , '
End

set @i=@i+1
End
set @CreateTableQuery=@CreateTableQuery+''

EXEC(@CreateTableQuery)

select
au.ApplicationUserId,au.FirstName + ' '+ au.LastName as 'TraineeName',au.EmailId INTO #tempTraineeDetail
FROM Enlighten.dbo.ApplicationUser au  inner join Enlighten.dbo.ClientUser cu on
 cu.ApplicationUserId=au.ApplicationUserId inner join Enlighten.dbo.TenantUserGroup tug on au.ApplicationUserId=tug.ApplicationUserId left join TraineeInDeoartmentandCourse tidac on au.ApplicationUserId=tidac.ApplicationUserId left join CourseSubject cs on tidac.CourseSubjectId=cs.Id 
	 left join DepartmentStandard ds on tidac.DepartmentStandardId=ds.Id where tug.TenantGroupId=(select tgid.TenantGroupId from
    Enlighten.dbo.TenantGroup tgid  where tgid.ClientId=@clientID and tgid.GroupName='Teacher') and cu.ClientId=@clientID and au.IsDeleted=0 and tug.IsDeleted=0



declare @numberofrowsintempstudentDetail int,@j int
set @j=0
set @numberofrowsintempstudentDetail=(select count(*) from #tempTraineeDetail)
While(@j<@numberofrowsintempstudentDetail)
Begin
declare @traineeName varchar(max);
declare @emailId varchar(max);
declare @applicationStudentId int;
 			set @traineeName=(SELECT TraineeName FROM (SELECT *,ROW_NUMBER() OVER (ORDER BY (Select 0)) R FROM  #tempTraineeDetail ) Temp WHERE R=(@j+1))
			set @applicationStudentId=(SELECT ApplicationUserId FROM (SELECT *,ROW_NUMBER() OVER (ORDER BY (Select 0)) R FROM  #tempTraineeDetail ) Temp WHERE R=(@j+1))
			set @emailId=(SELECT EmailId FROM (SELECT *,ROW_NUMBER() OVER (ORDER BY (Select 0)) R FROM  #tempTraineeDetail ) Temp WHERE R=(@j+1))
			
			Declare @insertMonthlyAttendance varchar(max);
			Declare @k int
			set @k=0
			set @insertMonthlyAttendance='Insert into #MonthlyAttendance(ApplicationUserId ,TraineeName,EmailId,'
				while(@k<@numberofrowsinmonthdays)
				Begin
				set @insertMonthlyAttendance=@insertMonthlyAttendance+ ' Day'+  Cast((@k+1) as varchar(max)) +'  '
				if((@k+1)!=@numberofrowsinmonthdays)
				Begin
				set @insertMonthlyAttendance=@insertMonthlyAttendance + ' , '
				End
				set @k=@k+1
				End
			 set @insertMonthlyAttendance=@insertMonthlyAttendance+')'
			  set @insertMonthlyAttendance=@insertMonthlyAttendance+' values('+Cast(@applicationStudentId as varchar(26))+','''+@traineeName+''','''+@emailId+''','
				Declare @l int
				set @l=0
				while(@l<@numberofrowsinmonthdays)
				Begin
				declare @attendanceDate varchar(max);
				declare @attendance varchar(max);
 					set @attendanceDate=(SELECT date FROM (SELECT *,ROW_NUMBER() OVER (ORDER BY (Select 0)) R FROM  #tmpmonthandYear ) Temp WHERE R=(@l+1))
					set @attendance=(SELECT Attandence FROM TraineeAttendance WHERE
					  ApplicationUserId=@applicationStudentId and IsDeleted=0 and AttendanceDate=@attendanceDate)
				if(@attendance is NULL)
				Begin
					set @attendance=' '
				End
				set @insertMonthlyAttendance=@insertMonthlyAttendance+ ''''+ @attendance +''''
				
				if((@l+1)!=@numberofrowsinmonthdays)
				Begin
				set @insertMonthlyAttendance=@insertMonthlyAttendance + ' , '
				End
					
				set @l=@l+1
				End
			set @insertMonthlyAttendance=@insertMonthlyAttendance+')'
			--select @insertMonthlyAttendance
			EXEC(@insertMonthlyAttendance)
		
			set @insertMonthlyAttendance='';
			--set @applicationStudentId=0;
			--set @studentName='';
set @j=@j+1
End

select * from #MonthlyAttendance
End

GO
/****** Object:  StoredProcedure [dbo].[GetApplicationUserList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetApplicationUserList](@clientID varchar(50))
as
begin
select
au.*,(select DepartmentStandardName from DepartmentStandard where id=sds.DepartmentStandardId) as 'DepartmentName',(select Section from Division where id=sds.DivisionId) as 'Section'
FROM Enlighten.dbo.ApplicationUser au
Left JOIN StudentInDepartmentStandard sds ON au.ApplicationUserId = sds.ApplicationUserId inner join Enlighten.dbo.ClientUser cu on
 cu.ApplicationUserId=au.ApplicationUserId inner join Enlighten.dbo.TenantUserGroup tug on au.ApplicationUserId=tug.ApplicationUserId where tug.TenantGroupId=(select tgid.TenantGroupId from   Enlighten.dbo.TenantGroup tgid where tgid.ClientId=@clientId and tgid.GroupName='Learner') and cu.ClientId=@clientID and au.IsDeleted=0
end


GO
/****** Object:  StoredProcedure [dbo].[GetAreaMasterList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetAreaMasterList](@type varchar(50))
as
begin
if(@type='Active')
Begin
Select* from AreaMaster  where IsActive=1 and IsDeleted=0
end
if(@type='Full')
Begin
Select * from AreaMaster where IsDeleted=0
end
end


GO
/****** Object:  StoredProcedure [dbo].[GetAreaVehicleMappingList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GetAreaVehicleMappingList](@type varchar(50))
as
begin
if(@type='Active')
Begin
Select avm.*,am.AreaName,vm.VehicleNumber from AreaVehicleMapping avm inner join AreaMaster am on am.id=avm.AreaMasterId inner join VehicleMaster vm on vm.Id=avm.VehicleMasterId where avm.IsActive=1 and avm.IsDeleted=0
 and am.IsActive=1 and am.IsDeleted=0 and vm.IsActive=1 and vm.IsDeleted=0
end
if(@type='Full')
Begin
Select avm.*,am.AreaName,vm.VehicleNumber from AreaVehicleMapping avm inner join AreaMaster am on am.id=avm.AreaMasterId inner join VehicleMaster vm on vm.Id=avm.VehicleMasterId where avm.IsDeleted=0
end
end

GO
/****** Object:  StoredProcedure [dbo].[GetAssignmentList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetAssignmentList](@id int)
as
begin
select * from Assignment where Id=@id and IsDeleted=0
end

GO
/****** Object:  StoredProcedure [dbo].[GetAssignNotice]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetAssignNotice](@noticeId int)
as
begin

select * from AssignNotice where NoticeId =@noticeId

end

GO
/****** Object:  StoredProcedure [dbo].[GetAssignNoticeForStudentAndTrainee]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create procedure [dbo].[GetAssignNoticeForStudentAndTrainee](@type varchar(max),@standardId int=0)
as
begin

if(@type='Trainee')
	Begin
		Select * from Notice where IsActive=1 and IsDeleted=0 order by CreatedOn desc
	end
if(@type='Student')
	Begin
		select * from Notice n inner join AssignNotice an on n.id=an.NoticeId where n.IsActive=1 and n.IsDeleted=0 and an.StandardId=@standardId and an.IsForStudent=1
	End

end


GO
/****** Object:  StoredProcedure [dbo].[GetBankDetailsByApplicationUserId]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GetBankDetailsByApplicationUserId](@applicationUserId int)
as
begin
Select * from BankDetails where ApplicationUsedId=@applicationUserId and IsDeleted=0
end

GO
/****** Object:  StoredProcedure [dbo].[GetCategoryMasterList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetCategoryMasterList](@type varchar(50))
as
begin
if(@type='Active')
Begin
Select * from CategoryMaster where IsActive=1 and IsDeleted=0
end
if(@type='Full')
Begin
Select * from CategoryMaster where IsDeleted=0
end
end

GO
/****** Object:  StoredProcedure [dbo].[GetCityMasterList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetCityMasterList]
as
begin
Select * from CityMaster where IsDeleted=0
end
GO
/****** Object:  StoredProcedure [dbo].[GetClassDivisionAllotment]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetClassDivisionAllotment]
as
begin
select cda.Id,ds.id as deptId,ds.DepartmentStandardName,d.id as sectId,d.Section from ClassDivisionAllotment cda inner join DepartmentStandard ds on cda.DepartmentStandardId=ds.Id inner join Division d on d.id=cda.DivisionId where cda.IsDeleted=0 and ds.IsDeleted=0 and d.IsDeleted=0
end

GO
/****** Object:  StoredProcedure [dbo].[GetComplaintList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetComplaintList]
as
begin
Select * from ComplaintMaster where IsDeleted=0

end
GO
/****** Object:  StoredProcedure [dbo].[GetComplaintListByAdmissionNumber]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetComplaintListByAdmissionNumber](@admissionNumber varchar(50))
as
begin
Select * from ComplaintMaster where IsDeleted=0 and AdmissionNumber=@admissionNumber

end
GO
/****** Object:  StoredProcedure [dbo].[GetComplaintListById]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetComplaintListById](@id int)
as
begin
Select * from ComplaintMaster where IsDeleted=0 and Id=@id

end

GO
/****** Object:  StoredProcedure [dbo].[GetConveyanceMonthForStudent]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetConveyanceMonthForStudent](@applicationUserId int,@standardId int,@divisionUserId int)
as
begin
select * from ConveyanceMonthForStudent where ApplicationUserId=@applicationUserId and StandardId=@standardId and DivisionId=@divisionUserId and IsDeleted=0
end

GO
/****** Object:  StoredProcedure [dbo].[GetCourseSubjectList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetCourseSubjectList](@type varchar(50),@applicationUserId int =null)
as
begin
if(@type='Active')
Begin
Select a.*,b.DepartmentStandardName,di.Section,sm.SubjectName from CourseSubject a inner join DepartmentStandard b on 
b.Id=a.DepartmentStandardID inner join Division di on di.Id=a.DivisionId inner join SubjectMaster sm on sm.id=a.SubjectId
 where a.IsActive=1 and a.IsDeleted=0 and di.IsDeleted=0 and b.IsDeleted=0 and di.IsDeleted=0 and sm.IsDeleted=0
end
if(@type='Full')
Begin
Select a.*,b.DepartmentStandardName,di.Section,sm.SubjectName from CourseSubject a inner join DepartmentStandard b on b.Id=a.DepartmentStandardID 
inner join Division di on di.Id=a.DivisionId inner join SubjectMaster sm on sm.id=a.SubjectId  where a.IsDeleted=0 and b.IsDeleted=0 and di.IsDeleted=0 and sm.IsDeleted=0
end
if(@type='Trainee')
Begin
Select a.*,b.DepartmentStandardName,di.Section,sm.SubjectName from CourseSubject a inner join DepartmentStandard b on b.Id=a.DepartmentStandardID inner join TraineeInDeoartmentandCourse tidac 
on tidac.DepartmentStandardId=b.Id inner join Division di on di.Id=a.DivisionId inner join SubjectMaster sm on sm.id=a.SubjectId
  where a.IsDeleted=0 and tidac.ApplicationUserId=@applicationUserId and b.IsDeleted=0 and di.IsDeleted=0 and sm.IsDeleted=0
end
if(@type='Learner')
Begin
select a.*,di.Section,sm.SubjectName from CourseSubject a inner join StudentInDepartmentStandard b on b.DepartmentStandardId=a.DepartmentStandardID 
inner join Division di on di.Id=a.DivisionId  inner join SubjectMaster sm on sm.id=a.SubjectId  where b.ApplicationUserId=@applicationUserId and b.IsDeleted=0 and di.IsDeleted=0 and sm.IsDeleted=0
end
end


GO
/****** Object:  StoredProcedure [dbo].[GetCourseUnderDepartment]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetCourseUnderDepartment](@departmentStandardId int)
as
begin
Select c.*,sm.SubjectName from CourseSubject c inner join SubjectMaster sm on sm.id=c.SubjectId where c.IsActive=1 and c.IsDeleted=0 and c.DepartmentStandardID=@departmentStandardId
end

GO
/****** Object:  StoredProcedure [dbo].[GetDashBoardDeatilForAdmin]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GetDashBoardDeatilForAdmin](@clientId varchar(max))
as
begin
Declare @traineeCount int
Declare @learnerCount int
Declare @DepartmentCount int
Declare @CourseCount int


SET @traineeCount=(select COUNT(*)  from Enlighten.dbo.ApplicationUser au inner join Enlighten.dbo.TenantUserGroup tug on au.ApplicationUserId=tug.ApplicationUserId inner join Enlighten.dbo.TenantGroup tg on tg.TenantGroupId=tug.TenantGroupId 
where au.IsDeleted=0 and tug.IsDeleted=0 and tg.IsDeleted=0 and tg.ClientId=@clientId and tg.GroupName like '%Teacher%')

SET @learnerCount=(select COUNT(*)  from Enlighten.dbo.ApplicationUser au inner join Enlighten.dbo.TenantUserGroup tug on au.ApplicationUserId=tug.ApplicationUserId inner join Enlighten.dbo.TenantGroup tg on tg.TenantGroupId=tug.TenantGroupId 
where au.IsDeleted=0 and tug.IsDeleted=0 and tg.IsDeleted=0 and tg.ClientId=@clientId and tg.GroupName like '%Learner%')

SET @DepartmentCount=(select Count(*) from DepartmentStandard where IsDeleted=0)

SET @CourseCount=(select Count(*) from CourseSubject where IsDeleted=0)

Select @traineeCount as 'TraineeCount',@learnerCount as 'LearnerCount',@DepartmentCount as 'DepartmentCount',@CourseCount as 'CourseCount'

end


GO
/****** Object:  StoredProcedure [dbo].[GetDepartmentStandardList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetDepartmentStandardList](@type varchar(50),@applicationUserId int=null)
as
begin
if(@type='Active')
Begin
Select * from DepartmentStandard where IsDeleted=0
end
if(@type='Full')
Begin
Select * from DepartmentStandard where IsDeleted=0
end
if(@type='Teacher')
Begin
Select * from DepartmentStandard a right join TraineeInDeoartmentandCourse b on a.Id=b.DepartmentStandardId  where a.IsDeleted=0 and b.ApplicationUserId=@applicationUserId
end
if(@type='Learner')
Begin
Select * from DepartmentStandard a inner join StudentInDepartmentStandard b on a.Id=b.DepartmentStandardId  where a.IsDeleted=0 and b.ApplicationUserId=@applicationUserId
end
end

GO
/****** Object:  StoredProcedure [dbo].[GetDivisionList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetDivisionList](@type varchar(50))
as
begin
if(@type='Active')
Begin
Select * from Division where IsActive=1 and IsDeleted=0
end
if(@type='Full')
Begin
Select * from Division where IsDeleted=0
end
end

GO
/****** Object:  StoredProcedure [dbo].[GetDivisionUnderDepartmentId]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetDivisionUnderDepartmentId](@departmentStandardId int)
as
begin
Select d.Id,d.Section from ClassDivisionAllotment cda inner join DepartmentStandard ds on ds.Id=cda.DepartmentStandardId inner join Division d on cda.DivisionId=d.Id where 
cda.IsDeleted=0 and ds.IsDeleted=0 and ds.IsActive=1 and d.IsDeleted=0 and d.IsActive=1 and cda.DepartmentStandardId=@departmentStandardId 
end

GO
/****** Object:  StoredProcedure [dbo].[GetDocumentInDriveByDeptId]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetDocumentInDriveByDeptId](@deptId int)
as
begin
	select DocumentID from  DocumentGoogleDrive where DepartmentID=@deptId and IsDeleted=0
end


GO
/****** Object:  StoredProcedure [dbo].[GetDocumentMasterList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetDocumentMasterList]
as
begin
Select * from DocumentMaster where IsDeleted=0
end
GO
/****** Object:  StoredProcedure [dbo].[GetDocumentsFileRequired]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetDocumentsFileRequired](@applicationUserId int,@fileTypeId int)
as
begin
	select * from DocumentsFileRequired where ApplicationUserId=@applicationUserId and FileTypeId=@fileTypeId
end


GO
/****** Object:  StoredProcedure [dbo].[GetEducationMasterList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetEducationMasterList]
as
begin
Select * from EducationMaster where IsDeleted=0
end

GO
/****** Object:  StoredProcedure [dbo].[GetEventDetailUnderByTraineeId]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetEventDetailUnderByTraineeId](@applicationUserId int)
as
begin
DECLARE @cnt INT = 0;
Declare @eventCnt int=0;
Declare @NumberOfDepartment int;
Declare @NumberOfEventUnderDepartment int;
Declare @eventId varchar(max);

CREATE TABLE #newEventList (EventId varchar(max))

SET @NumberOfDepartment=(select count(*) from TraineeInDeoartmentandCourse where ApplicationUserId=@applicationUserId and IsDeleted=0)
SELECT IDENTITY(INT, 1, 1) AS [NewID], Id + 0 AS [OldUserID],DepartmentStandardId INTO #NewTraineeInDeoartmentandCourse FROM TraineeInDeoartmentandCourse where IsDeleted=0 and ApplicationUserId=@applicationUserId

While(@cnt<@NumberOfDepartment)
BEGIN
set @cnt=@cnt+1;
Declare @DepartmentId int;
set @DepartmentId=(select DepartmentStandardId from #NewTraineeInDeoartmentandCourse where NewId=@cnt);
set @NumberOfEventUnderDepartment=(select count(*) from EventSession where DepartmentStandardId=@DepartmentId and IsDeleted=0)
SELECT IDENTITY(INT, 1, 1) AS [NewID], Id + 0 AS [OldUserID],EventId INTO #NewEventSession FROM EventSession where IsDeleted=0 and DepartmentStandardId=@DepartmentId

while(@eventCnt<@NumberOfEventUnderDepartment)
Begin
set @eventCnt=@eventCnt+1;
set @eventId=(select EventId from #NewEventSession where NewID=@eventCnt)
insert into #newEventList(EventId) values(@eventId)
End
drop table #NewEventSession
End
select EventId from #newEventList
end

GO
/****** Object:  StoredProcedure [dbo].[GetEventSessionChartDetail]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GetEventSessionChartDetail]
as
begin
	select top 10 Cast(CreatedOn as date) 'EventDate',ROW_NUMBER() OVER(ORDER by (Cast(CreatedOn as date)) desc) AS 'RowNumber',COUNT(CreatedOn) 'NumberOfEvent' from EventSession where IsDeleted=0
 group by Cast(CreatedOn as date) order by Cast(CreatedOn as date) desc
end

GO
/****** Object:  StoredProcedure [dbo].[GetExamCoveredTime]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetExamCoveredTime](@applicationUserId int,@departmentStandardId int,@courseSubjectId int,@examId int,@numberOfAttempts int)
as
begin
select * from ExamCoveredTime where  DepartmentStandardId=@departmentStandardId and CourseSubjectId=@courseSubjectId and ExamId=@examId and ApplicationUserId=@applicationUserId and NumberOfAttempts=@numberOfAttempts
end


GO
/****** Object:  StoredProcedure [dbo].[GetExamDetailByID]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetExamDetailByID](@examId int)
as
begin
	select * from Exam where id=@examId
end

GO
/****** Object:  StoredProcedure [dbo].[GetExamList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetExamList](@type varchar(50),@departmentId int=0,@courseId int=0)
as
begin
	if(@type='Active')
		Begin
			select a.DepartmentStandardName,b.*,c.CourseSubjectName,sm.SubjectName from Exam b left join DepartmentStandard a on 
			a.Id=b.DepartmentStandardId left join CourseSubject c on b.CourseSubjectId=c.Id inner join SubjectMaster sm on
			 sm.id=c.SubjectId where b.IsActive=1 and b.IsDeleted=0 and sm.IsDeleted=0 
		end
	if(@type='Full')
		Begin
			select a.DepartmentStandardName,b.*,c.CourseSubjectName,sm.SubjectName from Exam b left join DepartmentStandard a on
			 a.Id=b.DepartmentStandardId left join CourseSubject c on b.CourseSubjectId=c.Id inner join SubjectMaster sm on
			 sm.id=c.SubjectId where b.IsDeleted=0 and sm.IsDeleted=0 
		end
	if(@type='ByDepartmentId')
		Begin
			select a.DepartmentStandardName,b.*,c.CourseSubjectName,sm.SubjectName from Exam b left join DepartmentStandard a on
			 a.Id=b.DepartmentStandardId left join CourseSubject c on b.CourseSubjectId=c.Id inner join SubjectMaster sm on
			 sm.id=c.SubjectId where b.IsDeleted=0 and
			 a.Id=@departmentId and a.IsDeleted=0 and a.IsActive=1 and sm.IsDeleted=0 
		end
	if(@type='ByCourseId')
		Begin
			select a.DepartmentStandardName,b.*,c.CourseSubjectName,sm.SubjectName from Exam b left join DepartmentStandard a on 
			a.Id=b.DepartmentStandardId left join CourseSubject c on b.CourseSubjectId=c.Id inner join SubjectMaster sm on
			 sm.id=c.SubjectId where b.IsDeleted=0 and
			 c.Id=@courseId and c.IsDeleted=0 and c.IsActive=1 and b.IsActive=1 and a.IsDeleted=0 and a.IsActive=1 and sm.IsDeleted=0
		end
end
GO
/****** Object:  StoredProcedure [dbo].[GetFeeDetails]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetFeeDetails]
                                        (										
                                        @applicationUserId int,
										@standardId int,
                                        @t1 varchar(50),
                                        @t2 varchar(50),
                                        @t3 varchar(50),
                                        @t4 varchar(50),
                                        @t5 varchar(50),
                                        @t6 varchar(50),
                                        @t7 varchar(50),
                                        @t8 varchar(50),
                                        @t9 varchar(50),
                                        @t10 varchar(50),
                                        @t11 varchar(50),
                                        @t12 varchar(50),
                                        @t13 varchar(50),
                                        @t14 varchar(50),
                                        @t15 varchar(50),
                                        @t16 varchar(50),
                                        @t17 varchar(50),
                                        @t18 varchar(50),
                                        @t19 varchar(50),
                                        @t20 varchar(50),
										@t21 varchar(50),
                                        @t22 varchar(50),
                                        @t23 varchar(50),
                                        @t24 varchar(50),
                                        @t25 varchar(50),
										@isPreviousBalanceFee bit,
										@admissionNumber varchar(max),
										@academicYearId int
                                        )
                                        as										
                                        begin 
										if object_id('tempdb..#TestTable','U') is not null
										begin
										 drop table #TestTable
										 end

										 Declare @categoryId int
										 set @categoryId=(select CategoryId from StudentInDepartmentStandard where ApplicationUserId=@applicationUserId and IsActive=1 and IsDeleted=0)

										  create table #TestTable(FeeStructureId int,FeeMonth varchar(max),FeeName varchar(max),FeeNameAmount decimal(18,2),FeeType varchar(max),feemonthId int,feenameId int)

										    insert into #TestTable
										 Select fs.Id,fmm.FeeMonth,fnm.FeeName,fs.FeeNameAmount,fmm.FeeMonthType,fnm.Id feemonthId,fmm.Id feenameId from FeeStructure fs inner join FeeMonthMaster fmm on fmm.id=fs.FeeTypeMasterId 
										  inner join FeeNameMaster fnm on fnm.id=fs.FeeNameMasterId where fs.IsActive=1 and fnm.IsActive=1 and fnm.IsDeleted=0 and 
										  fs.IsDeleted=0 and fmm.IsDeleted=0 and fs.DepartmentStandardId=@standardId and fs.CategoryMasterId=@categoryId and 
										  fmm.FeeMonth in(@t1,@t2,@t3,@t4,@t5,@t6,@t7,@t8,@t9,@t10,@t11,@t12,@t13,@t14,@t15,@t16,@t17,@t18,@t19,@t20,@t21,@t22,@t23,@t24,@t25)

										  Declare @IsConveyance int
										  Declare @IsOneWayTrip int
										  Declare @areaId int
										  Declare @vehicleModeId int
										  Declare @ConveyanceFeeNameId int
										 set @IsConveyance=(select IsConveyanceIncluded from StudentInformation where IsDeleted=0 and IsReleved=0 and AdmissionNumber=@admissionNumber)
										 set @IsOneWayTrip=(select IsOneSide from RequestedConveyance where IsDeleted=0 and AdmissionNumber=@admissionNumber and AcademicYearId=@academicYearId)
										 set @areaId=(select LocationId from RequestedConveyance where IsDeleted=0 and AdmissionNumber=@admissionNumber and AcademicYearId=@academicYearId)
										 set @vehicleModeId=(select ModeId from RequestedConveyance where IsDeleted=0 and AdmissionNumber=@admissionNumber and AcademicYearId=@academicYearId)
										 set @ConveyanceFeeNameId=(select Id from FeeNameMaster where IsDeleted=0 and IsActive=1 and Conveyance=1)
										 if(@IsConveyance=1)
										  Begin
										  	
										  		select cmfs.* into #ConveyanceFeeMonth from  RequestedConveyance cmfs inner join FeeMonthMaster fmm on fmm.id=cmfs.Month
												where fmm.IsActive=1 and fmm.IsDeleted=0 and fmm.FeeMonth  in(@t1,@t2,@t3,@t4,@t5,@t6,@t7,@t8,@t9,@t10,@t11,@t12,@t13,@t14,@t15,@t16,@t17,@t18,@t19,@t20,@t21,@t22,@t23,@t24,@t25) 
													and  cmfs.AdmissionNumber=@admissionNumber and cmfs.IsDeleted=0 and AcademicYearId=@academicYearId
										  		declare @numberofrows int,@i int
										  		set @i=0
										  		set @numberofrows=(select count(*) from #ConveyanceFeeMonth)
										  		while (@i<@numberofrows)
										   		Begin

													declare @MonthName varchar(25)
                                        				set @MonthName=(SELECT fmm.FeeMonth FROM (SELECT *,ROW_NUMBER() OVER (ORDER BY (Select 0)) R FROM  #ConveyanceFeeMonth ) Temp inner join FeeMonthMaster fmm on fmm.id=Temp.Month WHERE R=(@i+1)
														 and fmm.FeeMonth in(@t1,@t2,@t3,@t4,@t5,@t6,@t7,@t8,@t9,@t10,@t11,@t12,@t13,@t14,@t15,@t16,@t17,@t18,@t19,@t20,@t21,@t22,@t23,@t24,@t25)) 
																							
													declare @conMonthNameId int
                                        				set @conMonthNameId=(SELECT fmm.Id FROM (SELECT *,ROW_NUMBER() OVER (ORDER BY (Select 0)) R FROM  #ConveyanceFeeMonth ) Temp inner join FeeMonthMaster fmm on fmm.id=Temp.Month WHERE R=(@i+1)
														 and fmm.FeeMonth in(@t1,@t2,@t3,@t4,@t5,@t6,@t7,@t8,@t9,@t10,@t11,@t12,@t13,@t14,@t15,@t16,@t17,@t18,@t19,@t20,@t21,@t22,@t23,@t24,@t25)) 
														

										  			Declare @transportFeeAmount int
										  			Declare @transportValue decimal(10,2)
										  			set @transportFeeAmount=(select TransportAmount from TransportPrice where AreaMasterId=@areaId and VehicleModeId=@vehicleModeId and IsDeleted=0 and IsActive=1)
										  			if(@IsOneWayTrip=0)
										  			Begin
														set @transportValue=@transportFeeAmount
										  				insert into #TestTable(FeeStructureId,FeeMonth,FeeName,FeeNameAmount,FeeType,feemonthId,feenameId) values(10001,@MonthName,'Conveyance Fee',@transportValue,'Transport Fee',@conMonthNameId,@ConveyanceFeeNameId)	
										  			End
										  			else
										  			Begin 
										  					set @transportValue=(@transportFeeAmount/2)
										  					insert into #TestTable(FeeStructureId,FeeMonth,FeeName,FeeNameAmount,FeeType,feemonthId,feenameId) values(10001,@MonthName,'Conveyance Fee',@transportValue,'Transport Fee',@conMonthNameId,@ConveyanceFeeNameId)	
										  			End
										  			set @i=@i+1
										  		End



										  End

										  if(@isPreviousBalanceFee=1)
										  Begin
												Declare @previousBalanceAmount decimal(10,2)
												Declare @isPreviousBalanceCount int
												set @isPreviousBalanceCount=(select Count(*) from ClassWiseStatus where AdmissionNumber=@admissionNumber)
												if(@isPreviousBalanceCount>0)
												Begin
													set @previousBalanceAmount=(select case when PendingAmount= null then 0 else PendingAmount end 'PendingAmount' from ClassWiseStatus where AdmissionNumber=@admissionNumber and AcademicYearId=@academicYearId)
													insert into #TestTable(FeeStructureId,FeeMonth,FeeName,FeeNameAmount,FeeType,feemonthId,feenameId) values(10101,'Previous Balance','Previous Year Balance Fee',@transportValue,'Balance Fee',0,0)
												End
										  End

										   --paidFeeAmount
										select ftdm.FeeMonthId,ftdm.FeeHeadId into #paidFeeAmountTable from FeeTransactionDetailMaster ftdm inner join FeeTransactionMaster ftm on ftdm.ReceiptNumber=ftm.ReceiptNumber inner join FeeMonthMaster fmm on ftdm.FeeMonthId=fmm.Id  where 
										ftm.IsDeleted=0 and ftm.IsCancelled=0 and ftm.AcademicYearId=@academicYearId and ftm.AdmissionNumber=@admissionNumber and ftdm.IsDeleted=0 and fmm.IsActive=1 and fmm.IsDeleted=0 and 
										fmm.FeeMonth in(@t1,@t2,@t3,@t4,@t5,@t6,@t7,@t8,@t9,@t10,@t11,@t12,@t13,@t14,@t15,@t16,@t17,@t18,@t19,@t20,@t21,@t22,@t23,@t24,@t25) and ftdm.FeeAmount=(ftdm.DiscountAmount+ftdm.PaidFeeAmount)
											declare @paidnumberofrows int,@paidi int
										  		set @paidi=0
										  		set @paidnumberofrows=(select count(*) from #paidFeeAmountTable)
												while (@paidi<@paidnumberofrows)
										   		Begin
													declare @paidMonthId int
													declare @paidFeeHeadId int;
                                        				set @paidMonthId=(SELECT FeeMonthId FROM (SELECT *,ROW_NUMBER() OVER (ORDER BY (Select 0)) R FROM  #paidFeeAmountTable ) Temp WHERE R=(@paidi+1))
                                        				set @paidFeeHeadId=(SELECT FeeMonthId FROM (SELECT *,ROW_NUMBER() OVER (ORDER BY (Select 0)) R FROM  #paidFeeAmountTable ) Temp WHERE R=(@paidi+1))

														delete from #TestTable where feemonthId=@paidMonthId and feenameId=@paidFeeHeadId

													set @paidi=@paidi+1
												end


											 --pendingdFeeAmount
										select ftdm.FeeMonthId,ftdm.FeeHeadId,ftdm.FeeAmount-(ftdm.DiscountAmount+ftdm.PaidFeeAmount) pendingAmount into #pendingFeeAmountTable from FeeTransactionDetailMaster ftdm inner join FeeTransactionMaster ftm on ftdm.ReceiptNumber=ftm.ReceiptNumber inner join FeeMonthMaster fmm on ftdm.FeeMonthId=fmm.Id  where 
										ftm.IsDeleted=0 and ftm.IsCancelled=0 and ftm.AcademicYearId=@academicYearId and ftm.AdmissionNumber=@admissionNumber and ftdm.IsDeleted=0 and fmm.IsActive=1 and fmm.IsDeleted=0 and 
										fmm.FeeMonth in(@t1,@t2,@t3,@t4,@t5,@t6,@t7,@t8,@t9,@t10,@t11,@t12,@t13,@t14,@t15,@t16,@t17,@t18,@t19,@t20,@t21,@t22,@t23,@t24,@t25) and ftdm.FeeAmount!=(ftdm.DiscountAmount+ftdm.PaidFeeAmount)
											declare @pendingnumberofrows int,@pendingi int
										  		set @pendingi=0
										  		set @pendingnumberofrows=(select count(*) from #paidFeeAmountTable)
												while (@pendingi<@pendingnumberofrows)
										   		Begin
													declare @pendingMonthId int
													declare @pendingFeeHeadId int;
													declare @pendingAmount int;
                                        				set @pendingMonthId=(SELECT FeeMonthId FROM (SELECT *,ROW_NUMBER() OVER (ORDER BY (Select 0)) R FROM  #pendingFeeAmountTable ) Temp WHERE R=(@pendingi+1))
                                        				set @pendingFeeHeadId=(SELECT FeeMonthId FROM (SELECT *,ROW_NUMBER() OVER (ORDER BY (Select 0)) R FROM  #pendingFeeAmountTable ) Temp WHERE R=(@pendingi+1))
														set @pendingAmount=(SELECT pendingAmount FROM (SELECT *,ROW_NUMBER() OVER (ORDER BY (Select 0)) R FROM  #pendingFeeAmountTable ) Temp WHERE R=(@pendingi+1))
														update #TestTable set FeeNameAmount=@pendingAmount  where feemonthId=@paidMonthId and feenameId=@paidFeeHeadId

													set @pendingi=@pendingi+1
												end

										  select * from #TestTable
                                        end
GO
/****** Object:  StoredProcedure [dbo].[GetFeeGroupList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GetFeeGroupList](@type varchar(50))
as
begin
if(@type='Active')
Begin
Select * from FeeGroup where IsActive=1 and IsDeleted=0
end
if(@type='Full')
Begin
Select * from FeeGroup where IsDeleted=0
end
end

GO
/****** Object:  StoredProcedure [dbo].[GetFeeMonthMasterList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetFeeMonthMasterList](@type varchar(50))
as
begin
if(@type='Active')
Begin
Select * from FeeMonthMaster where IsActive=1 and IsDeleted=0
end
if(@type='Full')
Begin
Select * from FeeMonthMaster where IsDeleted=0
end
end

GO
/****** Object:  StoredProcedure [dbo].[GetFeeMonthMasterListById]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GetFeeMonthMasterListById](@id int)
as
begin
Select * from FeeMonthMaster where IsActive=1 and IsDeleted=0 and Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[GetFeeNameMasterList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetFeeNameMasterList](@type varchar(50))
as
begin
if(@type='Active')
Begin
Select fnm.*,fg.FeeGroupName from FeeNameMaster fnm inner join FeeGroup fg on fnm.FeeGroupId=fg.Id where fnm.IsActive=1 and fnm.IsDeleted=0 and fg.IsDeleted=0
end
if(@type='Full')
Begin
Select fnm.*,fg.FeeGroupName from FeeNameMaster  fnm inner join FeeGroup fg on fnm.FeeGroupId=fg.Id where fnm.IsDeleted=0 and fg.IsDeleted=0
end
end

GO
/****** Object:  StoredProcedure [dbo].[GetFeeNameMasterListById]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GetFeeNameMasterListById](@id int)
as
begin
Select * from FeeNameMaster where IsDeleted=0 and Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[GetFeeStructureById]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetFeeStructureById](@id int)
as
begin
select fs.*,ds.DepartmentStandardName,fnm.FeeName,cm.CategoryName,(Select FeeMonth from FeeMonthMaster where id=ftm.FeeMonthId) as 'FeeMonth' from FeeStructure fs inner join DepartmentStandard ds on fs.DepartmentStandardId=ds.Id inner join FeeNameMaster fnm  on fs.FeeNameMasterId=fnm.Id inner join 
 CategoryMaster cm on cm.id=fs.CategoryMasterId  inner join FeeTypeMaster ftm on fs.FeeTypeMasterId=ftm.Id
 where fs.Id=@id and cm.IsDeleted=0 and cm.IsActive=1
end

GO
/****** Object:  StoredProcedure [dbo].[GetFeeStructureList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetFeeStructureList](@type varchar(50))
as
begin
if(@type='Active')
Begin
select fs.*,ds.DepartmentStandardName,fnm.FeeName,cm.CategoryName,(Select FeeMonth from FeeMonthMaster where id=ftm.FeeMonthId) as 'FeeMonth' from FeeStructure fs inner join DepartmentStandard ds on fs.DepartmentStandardId=ds.Id inner join FeeNameMaster fnm  on fs.FeeNameMasterId=fnm.Id inner join 
 CategoryMaster cm on cm.id=fs.CategoryMasterId inner join FeeTypeMaster ftm on fs.FeeTypeMasterId=ftm.Id
where fs.IsDeleted=0 and fs.IsActive=1 and ds.IsDeleted=0 and ds.IsActive=1 and fnm.IsActive=1 and fnm.IsDeleted=0 and cm.IsDeleted=0 and cm.IsActive=1 and ftm.IsDeleted=0 and ftm.IsActive=1
end
if(@type='Full')
Begin
select fs.*,ds.DepartmentStandardName,fnm.FeeName,cm.CategoryName,(Select FeeMonth from FeeMonthMaster where id=ftm.FeeMonthId) as 'FeeMonth' from FeeStructure fs inner join DepartmentStandard ds on fs.DepartmentStandardId=ds.Id inner join FeeNameMaster fnm  on fs.FeeNameMasterId=fnm.Id inner join 
 CategoryMaster cm on cm.id=fs.CategoryMasterId inner join FeeTypeMaster ftm on fs.FeeTypeMasterId=ftm.Id
where fs.IsDeleted=0 and ds.IsDeleted=0 and fnm.IsDeleted=0 and cm.IsDeleted=0 and ftm.IsDeleted=0
end
end


GO
/****** Object:  StoredProcedure [dbo].[GetFeeTransactionByReceiptNumber]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[GetFeeTransactionByReceiptNumber]
(
@receiptNumber int
)
AS
BEGIN
Select * from FeeTransaction where FeeReceiptId=@receiptNumber
END


GO
/****** Object:  StoredProcedure [dbo].[GetFeeTransactionDetailByReceiptNumber]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[GetFeeTransactionDetailByReceiptNumber]
(
@receiptNumber int
)
AS
BEGIN
Select * from FeeTransactionDetail where FeeReceiptId=@receiptNumber
END

GO
/****** Object:  StoredProcedure [dbo].[GetFeeTypeMasterById]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetFeeTypeMasterById](@id int)
as
begin
select ftm.*,ds.DepartmentStandardName,fnm.FeeName,fmm.FeeMonth from FeeTypeMaster ftm inner join DepartmentStandard ds on ftm.DepartmentStandardId=ds.Id inner join FeeNameMaster fnm  on ftm.FeeNameMasterId=fnm.Id inner join FeeMonthMaster fmm on fmm.id=ftm.FeeMonthId 
 where ftm.Id=@id and ftm.IsDeleted=0
end

GO
/****** Object:  StoredProcedure [dbo].[GetFeeTypeMasterList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetFeeTypeMasterList](@type varchar(50))
as
begin
if(@type='Active')
Begin
select ftm.*,ds.DepartmentStandardName,fnm.FeeName,fmm.FeeMonth from FeeTypeMaster ftm inner join DepartmentStandard ds on ftm.DepartmentStandardId=ds.Id inner join FeeNameMaster fnm  on ftm.FeeNameMasterId=fnm.Id inner join FeeMonthMaster fmm on fmm.id=ftm.FeeMonthId 
where ftm.IsDeleted=0 and ftm.IsActive=1 and ds.IsDeleted=0 and ds.IsActive=1 and fnm.IsActive=1 and fnm.IsDeleted=0 and fmm.IsDeleted=0 and fmm.IsActive=1
end
if(@type='Full')
Begin
select ftm.*,ds.DepartmentStandardName,fnm.FeeName,fmm.FeeMonth from FeeTypeMaster ftm inner join DepartmentStandard ds on ftm.DepartmentStandardId=ds.Id inner join FeeNameMaster fnm  on ftm.FeeNameMasterId=fnm.Id inner join FeeMonthMaster fmm on fmm.id=ftm.FeeMonthId 
where ftm.IsDeleted=0 and ds.IsDeleted=0 and fnm.IsDeleted=0 and fmm.IsDeleted=0
end
end


GO
/****** Object:  StoredProcedure [dbo].[GETLearnerAnswer]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GETLearnerAnswer](@departmentStandardId int,@courseSubjectId int,@examId int,@applicationUserId int,@numberOfAttempts int)
as
begin
	select ea.id,q.*,ea.Answer,q.Marks as 'QuestionMarks',ea.Marks as 'ObtainedMarks',ea.NumberOfAttempts,vt.ValueToCompare,vt.MaxValue,vt.MinValue,vt.ErrorMessage from ExamAnswer ea 
	inner join Questionaire q on q.Id=ea.QuestionId inner join ValidationTable vt on q.Id=vt.QuestionId
	inner join NumberOfExamAttempts nea on ea.NumberOfAttempts=nea.NumberOfAttempts
	where  ea.NumberOfAttempts=@numberOfAttempts and ea.DepartmentStandardId=@departmentStandardId and ea.CourseSubjectId=@courseSubjectId and ea.ExamId=@examId and ea.ApplicationUserId=@applicationUserId
	 and nea.DepartmentStandardId=@departmentStandardId and nea.CourseSubjectId=@courseSubjectId and nea.ExamId=@examId
end

GO
/****** Object:  StoredProcedure [dbo].[GetLearnerDepartmentId]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetLearnerDepartmentId](@applicationUserId int =null)
as
begin
select DepartmentStandardId from StudentInDepartmentStandard where ApplicationUserId=@applicationUserId and IsDeleted=0
end

GO
/****** Object:  StoredProcedure [dbo].[GetLearnerDetailUnderTrainee]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetLearnerDetailUnderTrainee](@type varchar(50),@applicationUserId int=null,@clientId varchar(50)=null,@departmentId int=null)
as
begin
if(@type='AllDepartment')
Begin
select au.*,(select DepartmentStandardName from DepartmentStandard where Id=sids.DepartmentStandardId) as 'DepartmentStandardName',(select Section from Division where id=sids.DivisionId) as 'Section' from Enlighten.dbo.ApplicationUser au inner join StudentInDepartmentStandard sids on
 au.ApplicationUserId=sids.ApplicationUserId inner join TraineeInDeoartmentandCourse tdc on tdc.DepartmentStandardId=sids.DepartmentStandardId where sids.DepartmentStandardId=@departmentId and tdc.ApplicationUserId=@applicationUserId
end
if(@type='DepartmentById')
Begin
select au.* from Enlighten.dbo.ApplicationUser au inner join StudentInDepartmentStandard sids on au.ApplicationUserId=sids.ApplicationUserId where sids.DepartmentStandardId=@departmentId
end
end

GO
/****** Object:  StoredProcedure [dbo].[GETLearnerExamAnswerLog]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GETLearnerExamAnswerLog](@departmentStandardId int,@courseSubjectId int,@examId int,@applicationUserId int)
as
begin
	select ea.id,q.*,ea.Answer,q.Marks as 'QuestionMarks',ea.Marks as 'ObtainedMarks',ea.NumberOfAttempts,vt.ValueToCompare,vt.MaxValue,vt.MinValue,vt.ErrorMessage from ExamAnswerLog ea 
	inner join Questionaire q on q.Id=ea.QuestionId inner join ValidationTable vt on q.Id=vt.QuestionId
	where   ea.DepartmentStandardId=@departmentStandardId and ea.CourseSubjectId=@courseSubjectId and ea.ExamId=@examId and ea.ApplicationUserId=@applicationUserId
end

GO
/****** Object:  StoredProcedure [dbo].[GetLessonList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetLessonList](@type varchar(50),@applicationUserId int =null)
as
begin
	if(@type='Active')
		Begin
			select a.DepartmentStandardName,b.*,c.CourseSubjectName,sm.SubjectName from  Lesson b left join DepartmentStandard a on 
			a.Id=b.DepartmentStandardId left join CourseSubject c on b.CourseSubjectId=c.Id  inner join SubjectMaster sm on sm.id=c.SubjectId where b.IsActive=1 and b.IsDeleted=0
		end
	if(@type='Full')
		Begin
			select a.DepartmentStandardName,b.*,c.CourseSubjectName,sm.SubjectName from  Lesson b left join DepartmentStandard a on 
			a.Id=b.DepartmentStandardId left join CourseSubject c on b.CourseSubjectId=c.Id inner join SubjectMaster sm on sm.id=c.SubjectId where b.IsDeleted=0
		end
	if(@type='Trainee')
		Begin
			select a.DepartmentStandardName,b.*,c.CourseSubjectName,sm.SubjectName from  Lesson b left join DepartmentStandard a on
			 a.Id=b.DepartmentStandardId left join CourseSubject c on b.CourseSubjectId=c.Id inner join SubjectMaster sm on sm.id=c.SubjectId
			 right join TraineeInDeoartmentandCourse tidac 
			on tidac.DepartmentStandardId=a.Id where b.IsActive=1 and b.IsDeleted=0 and tidac.ApplicationUserId=@applicationUserId
		end
end

GO
/****** Object:  StoredProcedure [dbo].[GetLessonListUnderDeptCourse]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetLessonListUnderDeptCourse](@deptId int,@courseId int)
as
begin
	Select Id,LessonTitle from Lesson where DepartmentStandardId=@deptId and CourseSubjectId=@courseId and IsDeleted=0
end


GO
/****** Object:  StoredProcedure [dbo].[GetListOfDepartmentByUserId]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetListOfDepartmentByUserId](@applicationUserId int)
as
begin
select b.DepartmentStandardName,c.CourseSubjectName from TraineeInDeoartmentandCourse a inner join DepartmentStandard b 
on b.Id=a.DepartmentStandardId inner join CourseSubject c on a.CourseSubjectId=c.Id inner join SubjectMaster sm on
sm.id=c.SubjectId where a.ApplicationUserId=@applicationUserId and a.IsDeleted=0 and b.IsDeleted=0 and c.IsDeleted=0 and sm.IsDeleted=0
end
GO
/****** Object:  StoredProcedure [dbo].[GETMappingApplicationUserIdAndDepartmentStandardByID]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GETMappingApplicationUserIdAndDepartmentStandardByID](@id int)
as
begin
select sids.*,au.EmailId,ds.DepartmentStandardName,d.Section,cm.CategoryName,am.AreaName,(select VehicleName from VehicleMode where id=sids.ModeId) as 'VehicleName' from Enlighten.dbo.ApplicationUser au 
	inner join StudentInDepartmentStandard sids on au.ApplicationUserId=sids.ApplicationUserId  
	inner join DepartmentStandard ds on ds.Id=sids.DepartmentStandardId
	inner join CategoryMaster cm on cm.id=sids.CategoryId 
	inner join Division d on d.id=sids.DivisionId
	inner join AreaMaster am on am.Id=sids.AreaId 
	where sids.Id=@id and  au.IsDeleted=0 and sids.IsDeleted=0 and	ds.IsDeleted=0 and	cm.IsDeleted=0 and d.IsDeleted=0 and am.IsDeleted=0
end

GO
/****** Object:  StoredProcedure [dbo].[GetMediumMasterList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetMediumMasterList]
as
begin
Select * from MediumMaster where IsDeleted=0
end
GO
/****** Object:  StoredProcedure [dbo].[GetNewQuestionList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetNewQuestionList](@examId int,@departmentStandardId int,@courseSubjectId int)
as
begin
select q.*,ds.DepartmentStandardName,cs.CourseSubjectName,e.ExamName,qat.AnswerTypeName,vt.IsRequired,e.DurationInMinutes from Questionaire q inner join DepartmentStandard ds on q.DepartmentStandardId=ds.Id 
			inner join CourseSubject cs on q.CourseSubjectId=cs.Id  inner join Exam e on q.ExamId=e.Id
			inner join QuestionAnswerType qat on q.QuestionAnswerTypeId=qat.Id left join ValidationTable vt on q.Id=vt.QuestionId left join ValidationAnswerType vat on vat.id=vt.ValidationAnswerTypeId
			 left join ValidationType vtyp on vtyp.id=vt.ValidationAnswerId where q.ExamId= @examId and q.DepartmentStandardId= @departmentStandardId
			 and q.CourseSubjectId=@courseSubjectId and q.IsDeleted=0  ORDER BY NEWID()
end

GO
/****** Object:  StoredProcedure [dbo].[GetNoticeList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetNoticeList](@type varchar(50))
as
begin
if(@type='Active')
Begin
Select * from Notice where IsActive=1 and IsDeleted=0 order by createdOn desc
end
if(@type='Full')
Begin
Select * from Notice where IsDeleted=0 order by createdOn desc
end
end

GO
/****** Object:  StoredProcedure [dbo].[GetNumberOfExamAttemptsIsChecked]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetNumberOfExamAttemptsIsChecked](@departmentStandardId int,@courseSubjectId int,@examId int,@applicationUserId int)
as
begin
	select IsChecked from NumberOfExamAttempts where DepartmentStandardId=@departmentStandardId and CourseSubjectId=@courseSubjectId and ExamId=@examId and ApplicationUserId=@applicationUserId
end


GO
/****** Object:  StoredProcedure [dbo].[GetNumberOfExamAttemptsList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetNumberOfExamAttemptsList](@departmentStandardId int,@courseSubjectId int,@examId int,@applicationUserId int)
as
begin
	select Max(NumberOfAttempts) as 'NumberOfAttempts' from NumberOfExamAttempts where DepartmentStandardId=@departmentStandardId and CourseSubjectId=@courseSubjectId and ExamId=@examId and ApplicationUserId=@applicationUserId
end


GO
/****** Object:  StoredProcedure [dbo].[GetNumberOfExamAttemptsListByApplicationUserId]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetNumberOfExamAttemptsListByApplicationUserId](@departmentStandardId int,@courseSubjectId int,@examId int,@applicationUserId int)
as
begin
	select * from NumberOfExamAttempts where DepartmentStandardId=@departmentStandardId and CourseSubjectId=@courseSubjectId and ExamId=@examId and ApplicationUserId=@applicationUserId
end


GO
/****** Object:  StoredProcedure [dbo].[GetOccupationMasterList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetOccupationMasterList]
as
begin
Select * from OccupationMaster where IsDeleted=0
end
GO
/****** Object:  StoredProcedure [dbo].[GetPaymentData]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  procedure [dbo].[GetPaymentData]
 @admissionNumber varchar(max),
 @academicYear int,
 @ClassName int
  as
    begin
Create Table #tempTable(id int,FeeType varchar(25),status varchar(25))
declare @numberofrows int,@i int
set @i=0

SELECT distinct(fmm.FeeMonth) FeeMonth,ftm.FeeMonthId as feemonthId INTO #tmpfeeStructure FROM FeeStructure fs inner join FeeTypeMaster ftm on ftm.id=fs.FeeTypeMasterId inner join FeeMonthMaster fmm on fmm.id=ftm.FeeMonthId
 where  fmm.IsDeleted=0 and fs.IsDeleted=0 and ftm.IsDeleted=0 and fs.DepartmentStandardId=@ClassName

	set @numberofrows=(select count(*) from #tmpfeeStructure)
 		while (@i<@numberofrows)
 		Begin
 			declare @MonthName varchar(25);
			declare @MonthId int;
			set @MonthId=(SELECT feemonthId FROM (SELECT *,ROW_NUMBER() OVER (ORDER BY (Select 0)) R FROM  #tmpfeeStructure ) Temp WHERE R=(@i+1));
 			set @MonthName=(SELECT FeeMonth FROM (SELECT *,ROW_NUMBER() OVER (ORDER BY (Select 0)) R FROM  #tmpfeeStructure ) Temp WHERE R=(@i+1));
			
 			
			Declare @FeeAmount decimal(10,2);
			set @FeeAmount=(select case when sum(FeeNameAmount) is null then 0 else sum(FeeNameAmount) end from FeeStructure where DepartmentStandardId=@ClassName and FeeTypeMasterId=@MonthId)

			Declare @conveyanceFeeAmount decimal(10,2)
			set @conveyanceFeeAmount=0;
			Declare @IsConveyance int
			set @IsConveyance=(select IsConveyanceIncluded from StudentInformation where IsDeleted=0 and IsReleved=0 and AdmissionNumber=@admissionNumber)
			if(@IsConveyance=1)
										  Begin
			set @conveyanceFeeAmount=(select case when Sum(lmm.TransportAmount) is null then 0 else sum(lmm.TransportAmount) end from RequestedConveyance rc inner join FeeMonthMaster fm on fm.Id=rc.Month inner join TransportPrice lmm on lmm.AreaMasterId=rc.LocationId
				where lmm.VehicleModeId=rc.ModeId and rc.IsDeleted=0 and fm.IsDeleted=0 and lmm.IsDeleted=0 and rc.AcademicYearId=@academicYear and rc.AdmissionNumber=@admissionNumber and rc.month=@MonthId)
				end

			Declare @paidAmount decimal(10,2)
			set @paidAmount=(select case when sum(ftdm.DiscountAmount+ftdm.PaidFeeAmount) is null then 0 else sum(ftdm.DiscountAmount+ftdm.PaidFeeAmount) end from FeeTransactionDetailMaster ftdm inner join FeeTransactionMaster ftm on ftm.ReceiptNumber=ftdm.ReceiptNumber 
								where ftm.IsCancelled=0 and ftm.IsDeleted=0 AND ftdm.FeeMonthId=@MonthId and ftm.AdmissionNumber=@admissionNumber and ftm.AcademicYearId=@academicYear)

			Declare @totalFeeAmount decimal(10,2)
			set @totalFeeAmount=@FeeAmount+@conveyanceFeeAmount;

			Declare @remainingAmount decimal(10,2)
			set @remainingAmount=@totalFeeAmount-@paidAmount;

			Declare @isWriteOff varchar(max);
			set @isWriteOff=(select case when count(*)>0 then 'true' else 'false' end from StudentFeeWriteOff where FeeMonthId=@MonthId and AcademicYearId=@academicYear and AdmissionNumber=@admissionNumber)

			declare @statusValue varchar(25)
 					set @statusValue=(select case when @isWriteOff='true' then 'wf' else case when (@remainingAmount=0) then 'Deposited'  else  
					Case when (@remainingAmount=@totalFeeAmount) then 'Not Deposited' else 'Pending' end end end as status)
			insert into #tempTable(id,FeeType,status) values(@i+1,@monthName,@statusValue)
	
 			set @i=@i+1
 		End
 	select * from #tempTable
 end

GO
/****** Object:  StoredProcedure [dbo].[GetPaymentDetail]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetPaymentDetail](@departmentStandardId int,@courseSubjectId int,@examId int,@applicationUserId int)
as
begin
	Select * from PaymentDetail where DepartmentStandardId=@departmentStandardId and SubjectCourseId=@courseSubjectId and ExamId=@examId and ApplicationUserId=@applicationUserId
end

GO
/****** Object:  StoredProcedure [dbo].[GetPlayList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetPlayList](@playListId varchar(max))
as
begin
	select * from PlayList where IsDeleted=0 and PlayListId=@playListId
end


GO
/****** Object:  StoredProcedure [dbo].[GetPlayListByDeptId]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetPlayListByDeptId](@deptId int)
as
begin
	select PlayListId from PlayList where DepartmentID=@deptId and IsDeleted=0
end

GO
/****** Object:  StoredProcedure [dbo].[GetPlayListUnderLesson]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetPlayListUnderLesson](@deptId int,@courseId int,@lessonId int)
as
begin
	select PlayListId from PlayList where DepartmentID=@deptId and CourseId=@courseId and LessonId=@lessonId	 and IsDeleted=0
end

GO
/****** Object:  StoredProcedure [dbo].[GetQuestionaireById]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GetQuestionaireById](@questionId int)
as
begin
	select q.*,ds.DepartmentStandardName,cs.CourseSubjectName,e.ExamName,qat.AnswerTypeName,vt.IsRequired from Questionaire q inner join DepartmentStandard ds on q.DepartmentStandardId=ds.Id 
			inner join CourseSubject cs on q.CourseSubjectId=cs.Id  inner join Exam e on q.ExamId=e.Id
			inner join QuestionAnswerType qat on q.QuestionAnswerTypeId=qat.Id left join ValidationTable vt on q.Id=vt.QuestionId left join ValidationAnswerType vat on vat.id=vt.ValidationAnswerTypeId
			 left join ValidationType vtyp on vtyp.id=vt.ValidationAnswerId where q.Id=@questionId and q.IsDeleted=0
end



GO
/****** Object:  StoredProcedure [dbo].[GetQuestionAnswerTypeList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetQuestionAnswerTypeList](@type varchar(50))
as
begin
	if(@type='Active')
		Begin
			select * from QuestionAnswerType where IsActive=1 and IsDeleted=0
		end
	if(@type='Full')
		Begin
			select * from QuestionAnswerType where IsDeleted=0
		end
end



GO
/****** Object:  StoredProcedure [dbo].[GetQuestionList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetQuestionList](@examId int,@departmentStandardId int,@courseSubjectId int,@isExamList bit)
as
begin
	if(@isExamList=1)
		begin
			select TOP (select NumberofQuestion from exam where id=@examId) q.*,ds.DepartmentStandardName,cs.CourseSubjectName,e.ExamName,qat.AnswerTypeName,vt.IsRequired,e.DurationInMinutes from Questionaire q inner join DepartmentStandard ds on q.DepartmentStandardId=ds.Id 
			inner join CourseSubject cs on q.CourseSubjectId=cs.Id  inner join Exam e on q.ExamId=e.Id
			inner join QuestionAnswerType qat on q.QuestionAnswerTypeId=qat.Id left join ValidationTable vt on q.Id=vt.QuestionId left join ValidationAnswerType vat on vat.id=vt.ValidationAnswerTypeId
			 left join ValidationType vtyp on vtyp.id=vt.ValidationAnswerId where q.ExamId=@examId and q.DepartmentStandardId=@departmentStandardId and q.CourseSubjectId=@courseSubjectId and q.IsDeleted=0 ORDER BY NEWID()
		end
	if(@isExamList=0)
		begin
			select q.*,ds.DepartmentStandardName,cs.CourseSubjectName,e.ExamName,qat.AnswerTypeName,vt.IsRequired,e.DurationInMinutes from Questionaire q inner join DepartmentStandard ds on q.DepartmentStandardId=ds.Id 
			inner join CourseSubject cs on q.CourseSubjectId=cs.Id  inner join Exam e on q.ExamId=e.Id
			inner join QuestionAnswerType qat on q.QuestionAnswerTypeId=qat.Id left join ValidationTable vt on q.Id=vt.QuestionId left join ValidationAnswerType vat on vat.id=vt.ValidationAnswerTypeId
			 left join ValidationType vtyp on vtyp.id=vt.ValidationAnswerId where q.ExamId=@examId and q.DepartmentStandardId=@departmentStandardId and q.CourseSubjectId=@courseSubjectId and q.IsDeleted=0
		end
end

GO
/****** Object:  StoredProcedure [dbo].[GetSessionEventByDepartmentId]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetSessionEventByDepartmentId](@departmentStandardId int)
as
begin
Select * from EventSession where DepartmentStandardId=@departmentStandardId and IsDeleted=0
End

GO
/****** Object:  StoredProcedure [dbo].[GetStreamMasterList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetStreamMasterList]
as
begin
Select * from StreamMaster where IsDeleted=0
end
GO
/****** Object:  StoredProcedure [dbo].[GetStudentAttendance]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetStudentAttendance](@standardId int=0,@divisionId int=0,@attendanceDate dateTime)
as
begin
	Select * from StudentAttendance where StandardId=@standardId and DivisionId=@divisionId and AttendanceDate=@attendanceDate
end

GO
/****** Object:  StoredProcedure [dbo].[GetStudentDetailUnderDepartmentAndDivision]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetStudentDetailUnderDepartmentAndDivision](@departmentId int=0,@divisionId int=0)
as
begin
	select au.ApplicationUserId,au.FirstName +' '+ au.LastName as 'StudentName' from Enlighten.dbo.ApplicationUser au inner join StudentInDepartmentStandard sids on au.ApplicationUserId=sids.ApplicationUserId where sids.IsActive=1 and sids.IsDeleted=0 and au.IsDeleted=0 and 
sids.DepartmentStandardId=@departmentId and sids.DivisionId=@divisionId
end

GO
/****** Object:  StoredProcedure [dbo].[GetStudentInformationDetailsByApplicationUserId]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetStudentInformationDetailsByApplicationUserId](@applicationUserId int)
as
begin
Select *,ds.DepartmentStandardName,di.Section,cm.CategoryName from StudentInformation si inner join Enlighten.dbo.ApplicationUser au on au.StudentInformationId=si.AdmissionNumber
inner join DepartmentStandard ds on ds.id=si.ClassId 
inner join Division di on di.Id=si.SectionId 
inner join CategoryMaster cm on cm.id=si.FeeCategoryId
 where au.IsDeleted=0 and si.IsDeleted=0 and au.ApplicationUserId=@applicationUserId and ds.IsDeleted=0 and di.IsDeleted=0 and cm.IsDeleted=0
end
GO
/****** Object:  StoredProcedure [dbo].[GetStudentInformationList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetStudentInformationList]
as
begin
Select * from StudentInformation where IsDeleted=0
end
GO
/****** Object:  StoredProcedure [dbo].[GetStudentInformationListByApplicationUserId]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetStudentInformationListByApplicationUserId](@applicationUserId int)
as
begin
Select *,au.FatherName fathersName from StudentInformation si inner join Enlighten.dbo.ApplicationUser au on au.StudentInformationId=si.AdmissionNumber where au.IsDeleted=0 and si.IsDeleted=0 and au.ApplicationUserId=@applicationUserId
end
GO
/****** Object:  StoredProcedure [dbo].[GetStudentResult]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetStudentResult](@departmentStandardId int,@courseSubjectId int,@examId int)
as
begin
Select sr.*,au.EmailId,e.TotalMarks from StudentResult sr inner join Enlighten.dbo.ApplicationUser au on sr.ApplicationUserId=au.ApplicationUserId inner join Exam e on sr.ExamId=e.Id
where sr.DepartmentStandardId=@departmentStandardId and sr.CourseSubjectId=@courseSubjectId and sr.ExamId=@examId
end


GO
/****** Object:  StoredProcedure [dbo].[GetStudentUnderDepartmentList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetStudentUnderDepartmentList]
@standardId int=0
as
  begin
	select au.ApplicationUserId,au.EmailId from Enlighten.dbo.ApplicationUser au inner join StudentInDepartmentStandard sids on au.ApplicationUserId=sids.ApplicationUserId
	where sids.DepartmentStandardId=@standardId and sids.IsActive=1 and au.IsDeleted=0 and sids.IsDeleted=0
 end

GO
/****** Object:  StoredProcedure [dbo].[GetSubjectMasterList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetSubjectMasterList](@type varchar(50),@applicationUserId int=null)
as
begin
if(@type='Active')
Begin
Select * from SubjectMaster where IsActive=1 and IsDeleted=0
end
if(@type='Full')
Begin
Select * from SubjectMaster where IsDeleted=0
end
end

GO
/****** Object:  StoredProcedure [dbo].[GetSubmitAssignmentById]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetSubmitAssignmentById](@id int)
as
begin
select * from SubmitAssignment where Id=@id and IsDeleted=0
end

GO
/****** Object:  StoredProcedure [dbo].[GetSubmittedAssignmentByAssignmentId]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetSubmittedAssignmentByAssignmentId](@applicationUserId int =null,@assignmentId int)
as
begin

select sa.Id,ds.DepartmentStandardName as 'DepartmentName',cs.CourseSubjectName as 'CourseName',l.LessonTitle as 'LessonName',sa.IsLateSubmitted from SubmitAssignment sa inner join DepartmentStandard ds
  on sa.DepartmentId=ds.Id inner join CourseSubject cs on sa.CourseId=cs.Id inner join Lesson l on l.Id=sa.LessonId where sa.IsDeleted=0 and ds.IsDeleted=0
 and cs.IsDeleted=0 and l.IsDeleted=0 and sa.AssignmentId=@assignmentId and sa.SubmittedBy=@applicationUserId
end

GO
/****** Object:  StoredProcedure [dbo].[GetSubmittedAssignmentOfUserByAssignmentId]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetSubmittedAssignmentOfUserByAssignmentId](@assignmentId int)
as
begin
select sa.Id,au.ApplicationUserId,au.FirstName,au.LastName,au.ContactNumber,sa.IsLateSubmitted from SubmitAssignment sa inner join Enlighten.dbo.ApplicationUser au
  on sa.SubmittedBy=au.ApplicationUserId where au.IsDeleted=0 and sa.AssignmentId=@assignmentId
end

GO
/****** Object:  StoredProcedure [dbo].[GetTehseelMasterList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetTehseelMasterList]
as
begin
Select * from TehseelMaster where IsDeleted=0
end

GO
/****** Object:  StoredProcedure [dbo].[GetTempPaymentDetailById]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetTempPaymentDetailById](@id int)
as
begin
	Select * from TempPaymentDetail where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[GetTraineeApplicationUserList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetTraineeApplicationUserList](@clientID varchar(50))
as
begin
select
au.*,ds.DepartmentStandardName,cs.CourseSubjectName
FROM Enlighten.dbo.ApplicationUser au  inner join Enlighten.dbo.ClientUser cu on
 cu.ApplicationUserId=au.ApplicationUserId inner join Enlighten.dbo.TenantUserGroup tug on au.ApplicationUserId=tug.ApplicationUserId left join TraineeInDeoartmentandCourse tidac on au.ApplicationUserId=tidac.ApplicationUserId left join CourseSubject cs on tidac.CourseSubjectId=cs.Id 
	 left join DepartmentStandard ds on tidac.DepartmentStandardId=ds.Id where tug.TenantGroupId=(select tgid.TenantGroupId from
    Enlighten.dbo.TenantGroup tgid  where tgid.ClientId=@clientID and tgid.GroupName='Teacher') and cu.ClientId=@clientID and au.IsDeleted=0 and tug.IsDeleted=0
end

GO
/****** Object:  StoredProcedure [dbo].[GetTraineeAttendance]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetTraineeAttendance](@attendanceDate dateTime)
as
begin
	Select * from TraineeAttendance where AttendanceDate=@attendanceDate
end


GO
/****** Object:  StoredProcedure [dbo].[GetTransportPriceList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetTransportPriceList](@type varchar(50))
as
begin
if(@type='Active')
Begin
Select tp.*,am.AreaName,vm.VehicleName from TransportPrice tp inner join AreaMaster am on am.id=tp.AreaMasterId inner join VehicleMode vm on vm.Id=tp.VehicleModeId where tp.IsActive=1 and tp.IsDeleted=0 and am.IsActive=1 and am.IsDeleted=0 
and vm.IsActive=1 and vm.IsDeleted=0
end
if(@type='Full')
Begin
Select tp.*,am.AreaName,vm.VehicleName from TransportPrice tp inner join AreaMaster am on am.id=tp.AreaMasterId inner join VehicleMode vm on vm.Id=tp.VehicleModeId where tp.IsDeleted=0
end
end

GO
/****** Object:  StoredProcedure [dbo].[GetUploadedAssignmentUnderDepartmentUsingApplicationUserId]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetUploadedAssignmentUnderDepartmentUsingApplicationUserId](@applicationUserId int)
as
begin

DECLARE @cnt INT = 0;
Declare @assignmentId int
Declare @NumberOfAssignmentCreated int;
Declare @deptId int;
Declare @departmentName varchar(max);
Declare @courseId int;
Declare @courseName varchar(max);
Declare @assignmentTitle varchar(max);
Declare @submissionDate DateTime;

Set @deptId=(select DepartmentStandardId from StudentInDepartmentStandard where ApplicationUserId=@applicationUserId and IsDeleted=0)
Set @NumberOfAssignmentCreated=(Select count(*) from Assignment where IsDeleted=0 and DepartmentId=@deptId)

CREATE TABLE #AssignmentList (id INT,AssignmentTitle varchar(max),SubmissionDate datetime,DepartmentStandardName varchar(max),CourseName varchar(max))  
SELECT IDENTITY(INT, 1, 1) AS [NewID], Id + 0 AS [OldUserID],DepartmentId,CourseId,LessonId,Title,SubmissionDate INTO #NewAssignment FROM Assignment where IsDeleted=0  and DepartmentId=@deptId

while(@cnt<@NumberOfAssignmentCreated)
Begin
set @cnt=@cnt+1;
set @assignmentId=(Select OldUserId from #NewAssignment where NewID=@cnt);
set @assignmentTitle=(Select Title from #NewAssignment where NewID=@cnt);
set @submissionDate=(Select SubmissionDate from #NewAssignment where NewID=@cnt);
set @deptId=(select DepartmentId from #NewAssignment where NewId=@cnt);
set @departmentName=(Select DepartmentStandardName from DepartmentStandard where Id=@deptId and IsDeleted=0);
set @courseId=(select CourseId from #NewAssignment where NewId=@cnt);
set @courseName=(Select CourseSubjectName from CourseSubject where Id=@courseId and DepartmentStandardID=@deptId and IsDeleted=0);

Insert into #AssignmentList(id,AssignmentTitle,SubmissionDate,DepartmentStandardName,CourseName) 
values(@assignmentId,@assignmentTitle,@submissionDate,@departmentName,@courseName)

End;
Select Top 6 * from #AssignmentList order by SubmissionDate asc
end

GO
/****** Object:  StoredProcedure [dbo].[GetUploadedAssignmentUnderTrainee]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--1) Number of student submittedAssignment
--2) Total number of student in standards
--3)Assignment Title
--4) student pending to submit assignment
--5) Submission Date
--6) standard/Department


CREATE procedure [dbo].[GetUploadedAssignmentUnderTrainee](@applicationUserId int,@type varchar(max))
as
begin

DECLARE @cnt INT = 0;
Declare @NumberOfAssignmentCreated int;
Declare @assignmentId int
Declare @deptId int;
Declare @departmentName varchar(max);
Declare @courseId int;
Declare @courseName varchar(max);
Declare @numberOfStudent int;
Declare @AssignmentSubmittedCount int;
Declare @AssignmentPendingCount int;
Declare @assignmentTitle varchar(max);
Declare @submissionDate DateTime;

Set @NumberOfAssignmentCreated=(Select count(*) from Assignment where IsDeleted=0 and CreatedBy=@applicationUserId)

CREATE TABLE #AssignmentList (id INT, AssignmentSubmitted int,TotalLearner int,AssignmentTitle varchar(max),AssignmentPending int,SubmissionDate datetime,DepartmentStandardName varchar(max),CourseName varchar(max))  
SELECT IDENTITY(INT, 1, 1) AS [NewID], Id + 0 AS [OldUserID],DepartmentId,CourseId,LessonId,Title,SubmissionDate INTO #NewAssignment FROM Assignment where IsDeleted=0 and CreatedBy=@applicationUserId

while(@cnt<@NumberOfAssignmentCreated)
Begin
set @cnt=@cnt+1;
set @assignmentId=(Select OldUserId from #NewAssignment where NewID=@cnt);
set @assignmentTitle=(Select Title from #NewAssignment where NewID=@cnt);
set @submissionDate=(Select SubmissionDate from #NewAssignment where NewID=@cnt);
set @deptId=(select DepartmentId from #NewAssignment where NewId=@cnt);
set @departmentName=(Select DepartmentStandardName from DepartmentStandard where Id=@deptId and IsDeleted=0);
set @courseId=(select CourseId from #NewAssignment where NewId=@cnt);
set @courseName=(Select CourseSubjectName from CourseSubject where Id=@courseId and DepartmentStandardID=@deptId and IsDeleted=0);
set @numberOfStudent=(Select count(*) from StudentInDepartmentStandard where DepartmentStandardId=@deptId and IsDeleted=0);
set @AssignmentSubmittedCount=(Select count(*) from SubmitAssignment where AssignmentId=@assignmentId and IsDeleted=0);
set @AssignmentPendingCount=@numberOfStudent-@AssignmentSubmittedCount;

Insert into #AssignmentList(id, AssignmentSubmitted,TotalLearner,AssignmentTitle,AssignmentPending,SubmissionDate,DepartmentStandardName,CourseName) 
values(@assignmentId,@AssignmentSubmittedCount,@numberOfStudent,@assignmentTitle,@AssignmentPendingCount,@submissionDate,@departmentName,@courseName)

End;
if (@type='Dashboard')
Begin
Select Top 6 * from #AssignmentList order by SubmissionDate asc
End
if (@type='Complete')
Begin
Select * from #AssignmentList order by SubmissionDate asc
End

end

GO
/****** Object:  StoredProcedure [dbo].[GetValidationAnswerTypeList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetValidationAnswerTypeList](@type varchar(50))
as
begin
	if(@type='Active')
		Begin
			select * from ValidationAnswerType where IsActive=1 and IsDeleted=0
		end
	if(@type='Full')
		Begin
			select * from ValidationAnswerType where IsDeleted=0
		end
end


GO
/****** Object:  StoredProcedure [dbo].[GetValidationByQuestionId]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetValidationByQuestionId](@questionId int)
as
begin
	select vt.*,vat.AnswerTypeName,vtyp.ValidationTypeName from  ValidationTable vt  left join ValidationAnswerType vat on vat.id=vt.ValidationAnswerTypeId
	left join ValidationType vtyp on vtyp.id=vt.ValidationAnswerId where vt.QuestionId=@questionId and vt.IsDeleted=0
end


GO
/****** Object:  StoredProcedure [dbo].[GetValidationTypeList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetValidationTypeList](@type varchar(50),@validationAnswerTypeId int)
as
begin
	if(@type='Active')
		Begin
			select * from ValidationType where IsActive=1 and IsDeleted=0 and ValidationAnswerTypeId=@validationAnswerTypeId
		end
	if(@type='Full')
		Begin
			select * from ValidationType where IsDeleted=0 and ValidationAnswerTypeId=@validationAnswerTypeId
		end
end


GO
/****** Object:  StoredProcedure [dbo].[GetVehicleMasterById]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetVehicleMasterById](@id int)
as
begin
Select * from VehicleMaster where IsActive=1 and IsDeleted=0 and Id=@id
end


GO
/****** Object:  StoredProcedure [dbo].[GetVehicleMasterList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetVehicleMasterList](@type varchar(50))
as
begin
if(@type='Active')
Begin
Select vm.*,v.VehicleName from VehicleMaster vm inner join VehicleMode v on vm.VehicleModeId=v.Id  where vm.IsActive=1 and vm.IsDeleted=0 and v.IsActive=1 and v.IsDeleted=0
end
if(@type='Full')
Begin
Select vm.*,v.VehicleName from VehicleMaster vm inner join VehicleMode v on vm.VehicleModeId=v.Id  where  vm.IsDeleted=0 and v.IsDeleted=0
end
end

GO
/****** Object:  StoredProcedure [dbo].[GetVehicleModeList]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetVehicleModeList](@type varchar(50))
as
begin
if(@type='Active')
Begin
Select * from VehicleMode where IsActive=1 and IsDeleted=0
end
if(@type='Full')
Begin
Select * from VehicleMode where IsDeleted=0
end
end


GO
/****** Object:  StoredProcedure [dbo].[GetVehicleUnderModeOrArea]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create procedure [dbo].[GetVehicleUnderModeOrArea]
@modeId int=0,
@areaId int=0
as
  begin
	if(@modeId=0)
	     begin
			select vm.Id,vm.VehicleNumber from VehicleMaster vm inner join AreaVehicleMapping avm on avm.VehicleMasterId=vm.Id where avm.AreaMasterId=@areaId and avm.IsDeleted=0 and vm.IsDeleted=0 
			and avm.IsActive=1  and vm.IsActive=1
	     end
	else if(@areaId=0)
	     begin
			select vm.Id,vm.VehicleNumber from VehicleMaster vm inner join AreaVehicleMapping avm on avm.VehicleMasterId=vm.Id where vm.VehicleModeId=@modeId and avm.IsDeleted=0 and vm.IsDeleted=0 
			and avm.IsActive=1  and vm.IsActive=1
	     end
	else
		 Begin
			select vm.Id,vm.VehicleNumber from VehicleMaster vm inner join AreaVehicleMapping avm on avm.VehicleMasterId=vm.Id where vm.VehicleModeId=@modeId and avm.AreaMasterId=@areaId and avm.IsDeleted=0 
			and vm.IsDeleted=0 and avm.IsActive=1  and vm.IsActive=1
		 end
 end

GO
/****** Object:  StoredProcedure [dbo].[InsertFeeTransactionDetail]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  
Create procedure [dbo].[InsertFeeTransactionDetail]
                                        (@receiptNumber int
                                        ,@standardId int
                                        ,@feeMonth varchar(max)
                                        ,@feeName varchar(max)
                                        ,@feeStructureId int
                                        ,@feeAmount float
                                        ,@createdBy int)
                                        as
                                        begin
                                        insert into FeeTransactionDetail(FeeReceiptId,DepartmentId,FeeMonth,FeeName,FeeStructureId,FeeAmount,PaidFee,CreatedBy,CreatedOn,IsDeleted)
                                        values( @receiptNumber,@standardId,@feeMonth,@feeName,@feeStructureId,@feeAmount,@feeAmount,@createdBy,GETDATE(),0)
                                        end


GO
/****** Object:  StoredProcedure [dbo].[InsertFeeTransactionOnline]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create procedure [dbo].[InsertFeeTransactionOnline]
                                        (@receiptNumber int
                                        ,@applicationUserId int
                                        ,@totalFeeAmount float
                                        ,@fineAmount float
                                        ,@totalDiscountAmount float
                                        ,@totalReceivedAmount float
                                        ,@serviceTax float
                                        ,@transactionId varchar(max)
                                        ,@transactionDate varchar(max)
                                        ,@referenceNumber varchar(max)
                                        ,@amountInWord varchar(max)
                                        ,@createdBy int
                                        ,@standardId int)
                                        as
                                        begin
                                        insert into FeeTransaction(FeeReceiptId,ApplicationUserId,TotalFeeAmount,FineAmount,TotalDiscountAmount,TotalReceivedAmount,ServiceTax,TransactionId
										,TransactionDate,ReferenceNumber,DepartmentId,AmountInWords,CreatedBy,CreatedOn,IsDeleted)
                                        values( @receiptNumber,@applicationUserId,@totalFeeAmount,@fineAmount,@totalDiscountAmount,@totalReceivedAmount,@serviceTax,@transactionId,@transactionDate,@referenceNumber
										,@standardId,@amountInWord,@createdBy,GETDATE(),0)
                                        end


GO
/****** Object:  StoredProcedure [dbo].[InsertPreviousBalanceFee]    Script Date: 9/30/2023 9:41:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create  procedure [dbo].[InsertPreviousBalanceFee]
 (@applicationUserId int,
 @ClassName int,
 @divisionId int,
 @previousBalanceAmount decimal(10,2),
 @IsPaid bit,
 @createdBy int)
  as
 begin
	Insert into PreviousBalanceFee(ApplicationUserId,DepartmentStandardId,DivisionId,PreviousBalanceAmount,IsPaid,CreatedBy,CreatedOn,IsDelete) values(@applicationUserId,@ClassName,@divisionId,@previousBalanceAmount
	,@IsPaid,@createdBy,GETDATE(),0)
 end

GO
/****** Object:  StoredProcedure [dbo].[InsertTempPaymentDetail]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertTempPaymentDetail]
           (
           @applicationUserId	int,
           @standardId	int,
           @totalFee	decimal(18,2),
           @lateFee	decimal(18,2),
           @grandTotal	decimal(18,2),
			@isPreviousYearBalanceIncluded bit,
           @f1	varchar(max),
           @f2	varchar(max),
           @f3	varchar(max),
           @f4	varchar(max),
           @f5	varchar(max),
           @f6	varchar(max),
           @f7	varchar(max),
           @f8	varchar(max),
           @f9	varchar(max),
           @f10	varchar(max),
           @f11	varchar(max),
           @f12	varchar(max),
			@f13	varchar(max),
			@f14	varchar(max),
			@f15	varchar(max),
			@f16	varchar(max),
			@f17	varchar(max),
			@f18	varchar(max),
			@f19	varchar(max),
			@f20	varchar(max),
			@f21	varchar(max),
			@f22	varchar(max),
			@f23	varchar(max),
			@f24	varchar(max),
			@f25	varchar(max),
			@refernceNumber varchar(max),
			@verified bit,
			@transactionDate dateTime,
           @id int output)
           as
           begin
           
		   Declare @categoryId	int
		   set @categoryId=(select CategoryId from StudentInDepartmentStandard where ApplicationUserId=@applicationUserId and IsActive=1 and IsDeleted=0)

           insert into TempPaymentDetail(
			ApplicationUserId,StandardId,CategoryId,TotalFee,LateFee,GrandTotal,ReferenceNumber,Verified,TransactionDate,IsPreviousYearBalanceInclided,
			F1,F2,F3,F4,F5,F6,F7,F8,F9,F10,F11,F12,F13,F14,F15,F16,F17,F18,F19,F20,F21,F22,F23,F24,F25)
			values
           (
           @applicationUserId,@standardId,@categoryId,@totalFee,@lateFee,@grandTotal,@refernceNumber,@verified,@transactionDate,@isPreviousYearBalanceIncluded
           ,@f1,@f2,@f3,@f4,@f5,@f6,@f7,@f8,@f9,@f10,@f11,@f12,@f13,@f14,@f15,@f16,@f17,@f18,@f19,@f20,@f21,@f22,@f23,@f24,@f25
           )
           SET @id = SCOPE_IDENTITY();
           return @id
           end		


GO
/****** Object:  StoredProcedure [dbo].[NewAddNewLearner]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[NewAddNewLearner](@firstName varchar(50),
@lastName varchar(50),@contactNumber varchar(20),@emailId varchar(50),@userName varchar(50),@fatherName	varchar(MAX),@fatherContactNumber varchar(20),@presentAddess varchar(MAX)
,@presentCity varchar(50),@presentState varchar(50),@permanentAddress varchar(MAX),@permanentCity varchar(50),@permanentState varchar(50),@gender varchar(15),@adhaarCardNumber	varchar(50)=null
,@pANCardNumber	 varchar(50)=null,@passwordHashKey varchar(MAX)=null,@passwordSaltKey varchar(MAX)=null,@numberOfAttempts	int,@createdBy	int,@ClientId varchar(20),@LASTID int,@admissionNumber varchar(max))
as
begin
insert into Enlighten.dbo.ApplicationUser(FirstName,LastName,ContactNumber,EmailId,UserName,FatherName,FatherContactNumber,PresentAddess,PresentCity,PresentState,PermanentAddress,PermanentCity,PermanentState,Gender,AdhaarCardNumber
,PANCardNumber,PasswordHashKey,PasswordSaltKey,NumberOfAttempts,CreatedBy,CreatedOn,IsDeleted,StudentInformationId) values(@firstName,@lastName,@contactNumber,@emailId,@userName,@fatherName,@fatherContactNumber,@presentAddess
,@presentCity,@presentState,@permanentAddress,@permanentCity,@permanentState,@gender,@adhaarCardNumber,@pANCardNumber,@passwordHashKey,@passwordSaltKey,@numberOfAttempts,@createdBy,GETDATE(),0,@admissionNumber)

SET @LASTID =IDENT_CURRENT('Enlighten.dbo.ApplicationUser');

insert into Enlighten.dbo.ClientUser(ApplicationUserId,ClientId,CreatedBy,CreatedOn,IsDeleted) values(@LASTID,@ClientId,@createdBy,GETDATE(),0)

insert into Enlighten.dbo.TenantUserGroup(ApplicationUserId,TenantGroupId,CreatedBy,CreatedOn,IsDeleted,IsDefault) values(@LASTID,(select TenantGroupId from  Enlighten.dbo.TenantGroup where ClientId=@ClientId and GroupName='Learner'),@createdBy,GETDATE(),0,1)

end
GO
/****** Object:  StoredProcedure [dbo].[PublishAreaMaster]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[PublishAreaMaster](@id int,@isActive bit,@updatedBy varchar(max))
as
begin
update AreaMaster set IsActive=@isActive,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[PublishAreaVehicleMapping]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[PublishAreaVehicleMapping](@id int,@isActive bit,@updatedBy varchar(max))
as
begin
update AreaVehicleMapping set IsActive=@isActive,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[PublishCategoryMaster]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[PublishCategoryMaster](@id int,@isActive bit,@updatedBy varchar(max))
as
begin
update CategoryMaster set IsActive=@isActive,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[PublishCourseSubject]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[PublishCourseSubject](@id int,@isActive bit,@updatedBy int)
as
begin
update CourseSubject set IsActive=@isActive,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[PublishDepartment]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[PublishDepartment](@id int,@isActive bit,@updatedBy int)
as
begin
update DepartmentStandard set IsActive=@isActive,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[PublishDivision]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[PublishDivision](@id int,@isActive bit,@updatedBy varchar(max))
as
begin
update Division set IsActive=@isActive,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[PublishExam]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[PublishExam](@id int,@isActive bit,@updatedBy int)
as
begin
update Exam set IsActive=@isActive,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[PublishFeeGroup]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[PublishFeeGroup](@id int,@isActive bit,@updatedBy varchar(max))
as
begin
update FeeGroup set IsActive=@isActive,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[PublishFeeMonthMaster]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[PublishFeeMonthMaster](@id int,@isActive bit,@updatedBy varchar(max))
as
begin
update FeeMonthMaster set IsActive=@isActive,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where Id=@id
end


GO
/****** Object:  StoredProcedure [dbo].[PublishFeeNameMaster]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[PublishFeeNameMaster](@id int,@isActive bit,@updatedBy varchar(max))
as
begin
update FeeNameMaster set IsActive=@isActive,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[PublishFeeStructure]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[PublishFeeStructure](@id int,@isActive bit,@updatedBy int)
as
begin
update FeeStructure set IsActive=@isActive,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[PublishFeeTypeMaster]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create procedure [dbo].[PublishFeeTypeMaster](@id int,@isActive bit,@updatedBy int)
as
begin
update FeeTypeMaster set IsActive=@isActive,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[PublishLesson]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[PublishLesson](@id int,@isActive bit,@updatedBy int)
as
begin
update Lesson set IsActive=@isActive,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[PublishMappingApplicationUserIdAndDepartmentStandard]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[PublishMappingApplicationUserIdAndDepartmentStandard](@id int,@isPublished bit,@updatedBy int)
as
begin
update StudentInDepartmentStandard set UpdatedBy=@updatedBy,UpdatedOn=GETDATE(),IsActive=@isPublished where id=@id
end


GO
/****** Object:  StoredProcedure [dbo].[PublishNotice]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[PublishNotice](@id int,@isActive bit,@updatedBy int)
as
begin
update Notice set IsActive=@isActive,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[PublishSubjectMaster]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[PublishSubjectMaster](@id int,@isActive bit,@updatedBy int)
as
begin
update SubjectMaster set IsActive=@isActive,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[PublishTransportPrice]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[PublishTransportPrice](@id int,@isActive bit,@updatedBy varchar(max))
as
begin
update TransportPrice set IsActive=@isActive,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[PublishVehicleMaster]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[PublishVehicleMaster](@id int,@isActive bit,@updatedBy varchar(max))
as
begin
update VehicleMaster set IsActive=@isActive,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[PublishVehicleMode]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[PublishVehicleMode](@id int,@isActive bit,@updatedBy varchar(max))
as
begin
update VehicleMode set IsActive=@isActive,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[SetNumberOfAttempts]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SetNumberOfAttempts](@emailID varchar(max),@numberOfAttempts int)
as
begin
Update ApplicationUser set NumberOfAttempts= @numberOfAttempts,UpdatedBy=(select ApplicationUserId from ApplicationUser where EmailId=@emailID),UpdatedOn=GETDATE() where EmailId=@emailID
end


GO
/****** Object:  StoredProcedure [dbo].[sp_updateTempPaymentstatus_verified]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  Create PROCEDURE [dbo].[sp_updateTempPaymentstatus_verified]
                                    (
                                    @referenceno varchar(MAX)
                                    )
                                    AS
                                    BEGIN
                                    update TempPaymentDetail
                                    set verified=1
                                    where referencenumber=@referenceno
                                    END
GO
/****** Object:  StoredProcedure [dbo].[SubmitNewAssignmentByLearner]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubmitNewAssignmentByLearner](@applicationUserId int =null,@answerFilePath varchar(max),@assignmentId int)
as
begin

Declare @isLateSubmitted bit;
Declare @departmentId int;
Declare @courseId int;
Declare @lessonId int;

SET @departmentId =(Select DepartmentId from Assignment where Id=@assignmentId and IsDeleted=0)
SET @courseId =(Select CourseId from Assignment where Id=@assignmentId and IsDeleted=0)
SET @lessonId =(Select LessonId from Assignment where Id=@assignmentId and IsDeleted=0)
SET @isLateSubmitted=(select (CASE WHEN (SubmissionDate<GETDATE()) then 1 ELSE 0 END) from Assignment where Id=@assignmentId and IsDeleted=0)

Insert into SubmitAssignment(DepartmentId,CourseId,LessonId,AnswerFilePath,SubmittedBy,SubmittedOn,IsLateSubmitted,AssignmentId,CreatedBy,CreatedOn,IsDeleted) 
values(@departmentId,@courseId,@lessonId,@answerFilePath,@applicationUserId,GETDATE(),@isLateSubmitted,@assignmentId,@applicationUserId,GETDATE(),0)
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateAllotedQuestionExamAnswerLog]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[UpdateAllotedQuestionExamAnswerLog](@answer varchar(max),@marks int,@updatedBy int,@examAnswerLogId int,@numberOfAttempts int=null)
as
begin
	Update ExamAnswerLog set Answer=@answer,Marks=@marks,UpdatedBy=@updatedBy,UpdatedOn=GETDATE(),NumberOfAttempts= @numberOfAttempts where Id=@examAnswerLogId
end


GO
/****** Object:  StoredProcedure [dbo].[UpdateAllotedQuestionExamAnswerLogNumberOfAttempts]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateAllotedQuestionExamAnswerLogNumberOfAttempts](@applicationUserId int,@examId int,@departmentStandardId int,@courseSubjectId int,@numberOfAttempts int=null,@updatedBy int)
as
begin
	Update ExamAnswerLog set NumberOfAttempts=@numberOfAttempts,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where  ApplicationUserId=@applicationUserId and DepartmentStandardId=@departmentStandardId 
	and CourseSubjectId=@courseSubjectId and ExamId=@examId and IsDeleted=0 and NumberOfAttempts=0
end


GO
/****** Object:  StoredProcedure [dbo].[UpdateAreaMaster]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[UpdateAreaMaster](@id int,@areaName varchar(max),@ispublished bit,@updatedBy varchar(max))
as
begin
Update AreaMaster set AreaName=@areaName,IsActive=@ispublished,UpdatedBy=@updatedBy,UpdatedOn=getdate() where Id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateCategoryMaster]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[UpdateCategoryMaster](@id int,@categoryName varchar(max),@categoryDescription varchar(max),@ispublished bit,@updatedBy varchar(max))
as
begin
Update CategoryMaster set CategoryName=@categoryName,CategoryDescription=@categoryDescription,IsActive=@ispublished,UpdatedBy=@updatedBy,UpdatedOn=getdate() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateComplaint]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[UpdateComplaint](@id int,@Complaint varchar(max),@updatedBy varchar(max))
as
begin
Update ComplaintMaster set Complaint=@Complaint,UpdatedBy=@updatedBy,UpdatedOn=getdate() where Id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateConveyanceMonthForStudent]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create procedure [dbo].[UpdateConveyanceMonthForStudent](@applicationUserId int,@standardId int,@divisionUserId int,@updatedBy int)
as
Begin
update ConveyanceMonthForStudent set IsActive=0,IsDeleted=1,DeletedBy=@updatedBy,DeletedOn=GETDATE() where StandardId=@standardId and DivisionId=@divisionUserId and ApplicationUserId=@applicationUserId

end

GO
/****** Object:  StoredProcedure [dbo].[UpdateCourseSubject]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[UpdateCourseSubject](@id int,@subjectId int,@courseSubjectName varchar(max),@departmentStandardID int,@ispublished bit,@updatedBy int)
as
begin
Update CourseSubject set SubjectId=@subjectId,CourseSubjectName=@courseSubjectName,DepartmentStandardID=@departmentStandardID,IsActive=@ispublished,UpdatedBy=@updatedBy,UpdatedOn=getdate() where Id=@id
end


GO
/****** Object:  StoredProcedure [dbo].[UpdatedApplicationUserById]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UpdatedApplicationUserById](@applicationUserId int,@updatedBy int,@firstName varchar(max),@lastName varchar(max),@contactNumber varchar(max),@email varchar(max),@fatherName varchar(max),@fatherContactNumber varchar(max),
@presentAddress varchar(max),@presentCity varchar(max),@presentState varchar(max),@permanentAddress varchar(max),@permanentCity varchar(max),@permanentState varchar(max))
as
begin
Declare @isOnlyOne int;
set @isOnlyOne=(select count(*) from Enlighten.dbo.ApplicationUser where ApplicationUserId=@applicationUserId or EmailId=@email)

if(@isOnlyOne=1)
Begin
Update Enlighten.dbo.ApplicationUser set FirstName=@firstName,LastName=@lastName,EmailId=@email,UserName=@email,FatherName=@fatherName,FatherContactNumber=@fatherContactNumber,PresentAddess=@presentAddress,PresentCity=@presentCity,
 PresentState=@presentState,PermanentAddress=@permanentAddress,PermanentCity=@permanentCity,PermanentState=@permanentState,ContactNumber=@contactNumber,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where ApplicationUserId=@applicationUserId
end
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateDepartmentStandard]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[UpdateDepartmentStandard](@id int,@departmentName varchar(max),@ispublished bit,@updatedBy varchar(max))
as
begin
Update DepartmentStandard set DepartmentStandardName=@departmentName,IsActive=@ispublished,UpdatedBy=@updatedBy,UpdatedOn=getdate() where Id=@id
end


GO
/****** Object:  StoredProcedure [dbo].[UpdateDivision]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[UpdateDivision](@id int,@divisionName varchar(max),@ispublished bit,@updatedBy varchar(max))
as
begin
Update Division set Section=@divisionName,IsActive=@ispublished,UpdatedBy=@updatedBy,UpdatedOn=getdate() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateExam]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UpdateExam](@examid int,@examName varchar(max),@isActive bit,@updatedBy int)
as
begin
update Exam set ExamName=@examName,IsActive=@isActive,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where Id=@examid
end


GO
/****** Object:  StoredProcedure [dbo].[UpdateExamCoveredTime]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateExamCoveredTime](@applicationUserId int,@departmentStandardId int,@courseSubjectId int,@examId int,@timeCoveredInMinutes int,@timeCoveredInSecond int,@numberOfAttempts int,@updatedBy int)
as
begin
update ExamCoveredTime set TimeCoveredInMinutes=@timeCoveredInMinutes,UpdatedBy=@updatedBy,UpdatedOn=GETDATE(),TimeCoveredInSecond=@timeCoveredInSecond where DepartmentStandardId=@departmentStandardId and CourseSubjectId=@courseSubjectId and ExamId=@examId and ApplicationUserId=@applicationUserId
and NumberOfAttempts=@numberOfAttempts
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateFeeGroup]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[UpdateFeeGroup](@id int,@feeGroupName varchar(max),@ispublished bit,@updatedBy varchar(max))
as
begin
Update FeeGroup set FeeGroupName=@feeGroupName,IsActive=@ispublished,UpdatedBy=@updatedBy,UpdatedOn=getdate() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateFeeMonthMaster]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[UpdateFeeMonthMaster](@id int,@feeMonth varchar(max),@feeMonthType varchar(max),@numberOfMonth int,@ispublished bit,@updatedBy varchar(max))
as
begin
Update FeeMonthMaster set FeeMonth=@feeMonth,FeeMonthType=@feeMonthType,NumberOfMonth=@numberOfMonth,IsActive=@ispublished,UpdatedBy=@updatedBy,UpdatedOn=getdate() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateFeeNameMaster]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[UpdateFeeNameMaster](@id int,@feeName varchar(max),@refundableFee bit,@optionalFee bit,@discountOn bit,@conveyance bit,@feeDisplay bit,@transferHead bit,@feeGroupId int,@ispublished bit,@updatedBy varchar(max))
as
begin
Update FeeNameMaster set FeeName=@feeName,RefundableFee=@refundableFee,OptionalFee=@optionalFee,DiscountOn=@discountOn,Conveyance=@conveyance,FeeDisplay=@feeDisplay
,TransferHead=@transferHead,FeeGroupId=@feeGroupId,IsActive=@ispublished,UpdatedBy=@updatedBy,UpdatedOn=getdate() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateFeeStructure]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[UpdateFeeStructure](@id int,@feeNameAmount int,@ispublished bit,@updatedBy int)
as
begin
Update FeeStructure set FeeNameAmount=@feeNameAmount,IsActive=@ispublished,UpdatedBy=@updatedBy,UpdatedOn=getdate() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateFeeTypeMaster]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[UpdateFeeTypeMaster](@id int,@departmentStandardId int,@dueDate datetime,@feeNameMasterId int,@lateFee int,@feeMonthId int,@ispublished bit,@updatedBy int)
as
begin
Update FeeTypeMaster set DepartmentStandardId=@departmentStandardId,DueDate=@dueDate,FeeNameMasterId=@feeNameMasterId,LateFee=@lateFee,FeeMonthId=@feeMonthId,IsActive=@ispublished,UpdatedBy=@updatedBy,UpdatedOn=getdate() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateLearnerMarks]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateLearnerMarks](@examAnswerId int,@marks int,@updatedBy int)
as
begin
	update ExamAnswer set Marks=@marks,UpdatedBy=@updatedBy,UpdatedOn=getdate() where id=@examAnswerId
end


GO
/****** Object:  StoredProcedure [dbo].[UpdateNotice]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[UpdateNotice](@id int,@noticeTitle varchar(max),@noticeDescription varchar(max),@ispublished bit,@updatedBy int)
as
begin
Update Notice set Title=@noticeTitle,NoticeDescription=@noticeDescription,IsActive=@ispublished,UpdatedBy=@updatedBy,UpdatedOn=getdate() where Id=@id
end



GO
/****** Object:  StoredProcedure [dbo].[UpdateNumberOfExamAttemptsIsChecked]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateNumberOfExamAttemptsIsChecked](@departmentStandardId int,@courseSubjectId int,@examId int,@applicationUserId int,@numberofAttempts int,@updatedBy int)
as
begin
	Update NumberOfExamAttempts set IsChecked=1,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where DepartmentStandardId=@departmentStandardId and CourseSubjectId=@courseSubjectId
	 and ExamId=@examId and NumberOfAttempts=@numberofAttempts and IsDeleted=0 and ApplicationUserId=@applicationUserId
end


GO
/****** Object:  StoredProcedure [dbo].[UpdateStudentAttendance]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UpdateStudentAttendance](@id int,@standardId int=0,@divisionId int=0,@attendanceDate datetime,@applicationUserId int,@studentName varchar(max),@attendance varchar(max),@updatedBy int)
as
begin
	update StudentAttendance set StandardId=@standardId,DivisionId=@divisionId,AttendanceDate=@attendanceDate,ApplicationUserId=@applicationUserId,StudentName=@studentName,Attandence=@attendance,
	UpdatedBy=@updatedBy,UpdatedOn =GETDATE() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateStudentDetailByAddmissionNo]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UpdateStudentDetailByAddmissionNo](@Language varchar(max),@Nationality  varchar(max),@TehseelId int,@CityId int,@PrevSchoolName varchar(max),@PrevStreamId int,@PrevClassId int,@PrevMediumId int,@PrevMarks decimal(10,2)
,@PrevTotalMarks decimal(10,2),@PrevAddress varchar(max),@FatherPhone varchar(max),@FatherEducationId int,@FatherOccupationId int,@FatherAddress varchar(max),@MotherName varchar(max),@MotherPhone varchar(max)
,@MotherEducationId int,@MotherOccupationId int,@MotherAddress varchar(max),@GuardianName varchar(max),@GuardianPhone varchar(max),@GuardianRelationShip varchar(max),@GuardianAddress varchar(max),@DocumentsId int
,@IsPreviousSchoolIncluded bit,@IsSibilingsIncluded bit,@AdmissionNumber varchar(max))
as
begin
Update StudentInformation set Language=@Language ,Nationality=@Nationality ,TehseelId=@TehseelId,CityId=@CityId,PrevSchoolName=@PrevSchoolName,PrevStreamId=@PrevStreamId,PrevClassId=@PrevClassId,PrevMediumId=@PrevMediumId,PrevMarks=@PrevMarks
,PrevTotalMarks=@PrevTotalMarks,PrevAddress=@PrevAddress,FatherPhone=@FatherPhone,FatherEducationId=@FatherEducationId,FatherOccupationId=@FatherOccupationId,FatherAddress=@FatherAddress,MotherName=@MotherName
,MotherPhone=@MotherPhone,MotherEducationId=@MotherEducationId,MotherOccupationId=@MotherOccupationId,MotherAddress=@MotherAddress,GuardianName=@GuardianName,GuardianPhone=@GuardianPhone,GuardianRelationShip=@GuardianRelationShip
,GuardianAddress=@GuardianAddress,DocumentsId=@DocumentsId,IsPreviousSchoolIncluded=@IsPreviousSchoolIncluded,IsSibilingsIncluded=@IsSibilingsIncluded where AdmissionNumber=@AdmissionNumber

end
GO
/****** Object:  StoredProcedure [dbo].[UpdateStudentResultTotalMarks]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[UpdateStudentResultTotalMarks](@departmentStandardId int,@courseSubjectId int,@examId int,@applicationUserId int,@numberOfAttempts int,@updatedBy int,@totalObtainedMarks int)
as
begin
Update StudentResult set TotalObtainedMarks=@totalObtainedMarks,UpdatedBy=@updatedBy,UpdatedOn=GETDATE() where DepartmentStandardId=@departmentStandardId
 and CourseSubjectId=CourseSubjectId and ExamId=@examId and NumberOfAttempts=@numberOfAttempts
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateSubjectMaster]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[UpdateSubjectMaster](@id int,@subjectName varchar(max),@ispublished bit,@updatedBy int)
as
begin
Update SubjectMaster set SubjectName=@subjectName,IsActive=@ispublished,UpdatedBy=@updatedBy,UpdatedOn=getdate() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateTraineeAttendance]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UpdateTraineeAttendance](@id int,@attendanceDate datetime,@applicationUserId int,@attendance varchar(max),@updatedBy int)
as
begin
	update TraineeAttendance set AttendanceDate=@attendanceDate,ApplicationUserId=@applicationUserId,Attandence=@attendance,
	UpdatedBy=@updatedBy,UpdatedOn =GETDATE() where Id=@id
end


GO
/****** Object:  StoredProcedure [dbo].[UpdateTransportPrice]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[UpdateTransportPrice](@id int,@transportAmount int,@ispublished bit,@updatedBy varchar(max))
as
begin
Update TransportPrice set TransportAmount=@transportAmount,IsActive=@ispublished,UpdatedBy=@updatedBy,UpdatedOn=getdate() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateVehicleMaster]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[UpdateVehicleMaster](@id int,@vehicleNumber varchar(max),@vehicleDescription varchar(max),@PickUpDriverName varchar(max),@pickUpDriverAddress varchar(max),@pickUpDriverContactNumber varchar(max)
,@pickUpDriverAdhaarNumber varchar(max),@dropDriverName varchar(max),@dropDriverAddress varchar(max),@dropDriverContactNumber varchar(max),@dropDriverAdhaarNumber varchar(max),@ispublished bit,@updatedBy varchar(max))
as
begin
Update VehicleMaster set VehicleNumber=@vehicleNumber,VehicleDescription=@vehicleDescription,PickUpDriverName=@PickUpDriverName,PickUpDriverAddress=@pickUpDriverAddress,PickUpDriverContactNumber=@pickUpDriverContactNumber,
PickUpDriverAdhaarNumber=@pickUpDriverAdhaarNumber,DropDriverName=@dropDriverName,DropDriverAddress=@dropDriverAddress,DropDriverContactNumber=@dropDriverContactNumber,DropDriverAdhaarNumber=@dropDriverAdhaarNumber
,IsActive=@ispublished,UpdatedBy=@updatedBy,UpdatedOn=getdate() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateVehicleMode]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[UpdateVehicleMode](@id int,@vehicleType varchar(max),@vehicleName varchar(max),@ispublished bit,@updatedBy int)
as
begin
Update VehicleMode set VehicleType=@vehicleType,VehicleName=@vehicleName,IsActive=@ispublished,UpdatedBy=@updatedBy,UpdatedOn=getdate() where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[UploadFileOnDocumentFileRequired]    Script Date: 9/30/2023 9:41:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UploadFileOnDocumentFileRequired]
(
@applicationUserId int,
@fileTypeId int,
@DifferentFilePath varchar(MAX)=null
)
AS
BEGIN
insert into DocumentsFileRequired(FileTypeId,ApplicationUserId,MultipleFilePath) values(@fileTypeId,@applicationUserId,@DifferentFilePath)
END

GO
