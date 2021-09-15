create database DapperDb
GO


use DapperDB
GO

IF OBJECT_ID ('People') IS NOT NULL
	DROP TABLE People;
GO

CREATE TABLE People
(
	PersonId int primary key identity,
	[Name] varchar(max),
	Age int --or tiny int
);
GO


select * from People 
GO

