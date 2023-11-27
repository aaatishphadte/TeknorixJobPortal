USE [TeknorixDB]
GO

INSERT INTO [dbo].[Jobs]
           ([Code]
           ,[Title]
           ,[Description]
           ,[LocationID]
           ,[DepartmentID]
           ,[PostedDate]
           ,[ClosedDate])
     VALUES
           (<Code, uniqueidentifier,>
           ,<Title, nvarchar(100),>
           ,<Description, nvarchar(1000),>
           ,<LocationID, int,>
           ,<DepartmentID, int,>
           ,<PostedDate, datetime2(7),>
           ,<ClosedDate, datetime2(7),>)
GO

