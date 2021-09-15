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


if OBJECT_ID ('Products') is not null
	drop table Products;
GO

create table Products
(
	ProductId int primary key identity,
	[Name] varchar(max),
	Quantity int,
	Price decimal(6,2)
);
GO

select * from Products;
