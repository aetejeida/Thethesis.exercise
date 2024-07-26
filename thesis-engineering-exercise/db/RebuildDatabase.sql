USE master
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ThesisExercise')
BEGIN
  CREATE DATABASE ThesisExercise;
END
GO

USE ThesisExercise
GO

IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE id=OBJECT_ID ('tempdb..#tmpErrors'))
	DROP TABLE #tmpErrors;

CREATE TABLE #tmpErrors (Error int)
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
BEGIN TRANSACTION
-------------------------------------------------------
CREATE TABLE [ProcessorBrand] (
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Name] nvarchar(10),
	CreationDate datetime2 NOT NULL Default(GETUTCDATE())
)

CREATE TABLE [Processor] (
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	BrandId int NOT NULL,
	Model nvarchar(50) NOT NULL,
	FOREIGN KEY (BrandId) REFERENCES [ProcessorBrand](Id),
	CreationDate datetime2 NOT NULL Default(GETUTCDATE())
)

CREATE TABLE [SizeType] (
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[TypeCode] nvarchar(2),
	[TypeName] nvarchar(20),
	CreationDate datetime2 NOT NULL Default(GETUTCDATE())
)

CREATE TABLE [UsbPort] (
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Version] nvarchar(10),
	CreationDate datetime2 NOT NULL Default(GETUTCDATE())
)

CREATE TABLE [HardDisk] (
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Type] nvarchar(3) NOT NULL,
	Size nvarchar(50) NOT NULL,
	SizeTypeId int NOT NULL,
	CreationDate datetime2 NOT NULL Default(GETUTCDATE()),
	FOREIGN KEY (SizeTypeId) REFERENCES [SizeType](Id)
)

CREATE TABLE [Memory] (
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Size int NOT NULL,
	SizeTypeId int NOT NULL,
	CreationDate datetime2 NOT NULL Default(GETUTCDATE()),
	FOREIGN KEY (SizeTypeId) REFERENCES [SizeType](Id)
)

CREATE TABLE Computer(
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ProcessorId int NOT NULL,
	MemoryId int NOT NULL,
	HardDiskId int NOT NULL,
	CreationDate datetime2 NOT NULL Default(GETUTCDATE()),
	FOREIGN KEY (ProcessorId) REFERENCES [Processor](Id),
	FOREIGN KEY (MemoryId) REFERENCES [Memory](Id),
	FOREIGN KEY (HardDiskId) REFERENCES [HardDisk](Id)
)

CREATE TABLE ComputerUsbPort (
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ComputerId int NOT NULL,
	UsbPortId int NOT NULL,
	CreationDate datetime2 NOT NULL Default(GETUTCDATE()),
	FOREIGN KEY (ComputerId) REFERENCES Computer(Id) ON DELETE CASCADE,
	FOREIGN KEY (UsbPortId) REFERENCES UsbPort(Id) ON DELETE CASCADE
)

--Insert Disk Values
SET IDENTITY_INSERT [dbo].[UsbPort] ON
INSERT INTO [dbo].[UsbPort] (Id, [Version]) VALUES (1,'USB 3.0');
INSERT INTO [dbo].[UsbPort] (Id, [Version]) VALUES (2,'USB 2.0');
INSERT INTO [dbo].[UsbPort] (Id, [Version]) VALUES (3,'USB C');
SET IDENTITY_INSERT [dbo].[UsbPort] OFF

SET IDENTITY_INSERT [dbo].[SizeType] ON
INSERT INTO	[dbo].[SizeType] (Id, [TypeCode], [TypeName]) VALUES(1,'TB', 'Terabyte');
INSERT INTO	[dbo].[SizeType] (Id, [TypeCode], [TypeName]) VALUES(2,'GB', 'Gigabytes');
INSERT INTO	[dbo].[SizeType] (Id, [TypeCode], [TypeName]) VALUES(3,'MB', 'Megabytes');
SET IDENTITY_INSERT [dbo].[SizeType] OFF

SET IDENTITY_INSERT [dbo].[ProcessorBrand] ON
INSERT INTO [dbo].[ProcessorBrand] (Id, [Name]) VALUES (1,'Intel®');
INSERT INTO [dbo].[ProcessorBrand] (Id, [Name]) VALUES (2,'AMD');
INSERT INTO [dbo].[ProcessorBrand] (Id, [Name]) VALUES (3,'Intel');
SET IDENTITY_INSERT [dbo].[ProcessorBrand] OFF

SET IDENTITY_INSERT [dbo].[Memory] ON
INSERT INTO [dbo].[Memory] (Id, Size, SizeTypeId) VALUES (1,8,2);
INSERT INTO [dbo].[Memory] (Id, Size, SizeTypeId) VALUES (2,16,2);
INSERT INTO [dbo].[Memory] (Id, Size, SizeTypeId) VALUES (3,32,2);
INSERT INTO [dbo].[Memory] (Id, Size, SizeTypeId) VALUES (4,512,3);
INSERT INTO [dbo].[Memory] (Id, Size, SizeTypeId) VALUES (5,2,2);
SET IDENTITY_INSERT [dbo].[Memory] OFF


SET IDENTITY_INSERT [dbo].[HardDisk] ON
INSERT INTO [dbo].[HardDisk] (Id, [Type], Size, SizeTypeId) VALUES (1,'SDD', 1, 1);
INSERT INTO [dbo].[HardDisk] (Id, [Type], Size, SizeTypeId) VALUES (2,'HDD', 2, 1);
INSERT INTO [dbo].[HardDisk] (Id, [Type], Size, SizeTypeId) VALUES (3,'HDD', 3, 1);
INSERT INTO [dbo].[HardDisk] (Id, [Type], Size, SizeTypeId) VALUES (4,'HDD', 4, 1);
INSERT INTO [dbo].[HardDisk] (Id, [Type], Size, SizeTypeId) VALUES (5,'SSD', 750, 2);
INSERT INTO [dbo].[HardDisk] (Id, [Type], Size, SizeTypeId) VALUES (6,'SSD', 2, 1);
INSERT INTO [dbo].[HardDisk] (Id, [Type], Size, SizeTypeId) VALUES (7,'SSD', 500, 2);
INSERT INTO [dbo].[HardDisk] (Id, [Type], Size, SizeTypeId) VALUES (8,'SSD', 80, 2);
SET IDENTITY_INSERT [dbo].[HardDisk] OFF


SET IDENTITY_INSERT [dbo].[Processor] ON
INSERT INTO [dbo].[Processor] (Id, [BrandId] ,[Model]) VALUES (1, 1, 'Celeron™ N3050 Processor');
INSERT INTO [dbo].[Processor] (Id, [BrandId] ,[Model]) VALUES (2, 2, 'FX 4300 Processor');
INSERT INTO [dbo].[Processor] (Id, [BrandId] ,[Model]) VALUES (3, 2, 'Athlon Quad-Core APU Athlon 5150');
INSERT INTO [dbo].[Processor] (Id, [BrandId] ,[Model]) VALUES (4, 2, 'FX 8-Core Black Edition FX-8350');
INSERT INTO [dbo].[Processor] (Id, [BrandId] ,[Model]) VALUES (5, 2, 'FX 8-Core Black Edition FX-8370');
INSERT INTO [dbo].[Processor] (Id, [BrandId] ,[Model]) VALUES (6, 3, 'Core i7-6700K 4GHz Processor');
INSERT INTO [dbo].[Processor] (Id, [BrandId] ,[Model]) VALUES (7, 1, 'Core™ i5-6400 Processor');
INSERT INTO [dbo].[Processor] (Id, [BrandId] ,[Model]) VALUES (8, 3, 'Core i7 Extreme Edition 3 GHz Processor');
SET IDENTITY_INSERT [dbo].[Processor] OFF

-------------------------------------------------------
IF @@ERROR<>0 AND @@TRANCOUNT>0 BEGIN PRINT CONVERT(NVARCHAR, SYSDATETIME(), 121) + N' ROLLBACK TRANSACTION' ROLLBACK TRANSACTION END;
IF @@TRANCOUNT=0 BEGIN PRINT CONVERT(NVARCHAR, SYSDATETIME(), 121) + N' NO TRANSACTION' INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END;
-------------------------------------------------------
IF EXISTS (SELECT * FROM #tmpErrors) BEGIN
	ROLLBACK TRANSACTION;
	PRINT CONVERT(NVARCHAR, SYSDATETIME(), 121) + N' ROLLBACK APPLIED';
END
-------------------------------------------------------
IF @@TRANCOUNT>0 BEGIN
	COMMIT TRANSACTION;
	PRINT CONVERT(NVARCHAR, SYSDATETIME(), 121) + N' THE DATABASE UPDATE SUCCEEDED';
END
ELSE BEGIN
	PRINT CONVERT(varchar, SYSDATETIME(), 121) + N' THE DATABASE UPDATE FAILED';
END

DROP TABLE #tmpErrors;