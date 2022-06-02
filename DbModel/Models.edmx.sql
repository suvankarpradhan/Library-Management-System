
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/18/2022 00:33:12
-- Generated from EDMX file: D:\Education\c# project\Library Management System\DbModel\Models.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Library_Management_System];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[bookRecod]', 'U') IS NOT NULL
    DROP TABLE [dbo].[bookRecod];
GO
IF OBJECT_ID(N'[dbo].[employeeRecord]', 'U') IS NOT NULL
    DROP TABLE [dbo].[employeeRecord];
GO
IF OBJECT_ID(N'[dbo].[memberRecord]', 'U') IS NOT NULL
    DROP TABLE [dbo].[memberRecord];
GO
IF OBJECT_ID(N'[dbo].[transactionRecord]', 'U') IS NOT NULL
    DROP TABLE [dbo].[transactionRecord];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'bookRecod'
CREATE TABLE [dbo].[bookRecod] (
    [book_id] int IDENTITY(1,1) NOT NULL,
    [book_name] varchar(50)  NOT NULL,
    [author_name] varchar(50)  NOT NULL,
    [category] varchar(50)  NOT NULL,
    [copies] int  NOT NULL
);
GO

-- Creating table 'employeeRecord'
CREATE TABLE [dbo].[employeeRecord] (
    [emp_id] int IDENTITY(1,1) NOT NULL,
    [emp_name] varchar(50)  NOT NULL,
    [emp_email] varchar(50)  NOT NULL,
    [emp_phone] varchar(50)  NOT NULL,
    [emp_pass] varchar(50)  NOT NULL,
    [emp_add] varchar(100)  NULL,
    [role] varchar(50)  NULL,
    [username] varchar(50)  NOT NULL
);
GO

-- Creating table 'memberRecord'
CREATE TABLE [dbo].[memberRecord] (
    [mem_id] int IDENTITY(1,1) NOT NULL,
    [mem_name] varchar(50)  NOT NULL,
    [mem_email] varchar(50)  NULL,
    [mem_phone] varchar(50)  NOT NULL,
    [mem_add] varchar(100)  NULL
);
GO

-- Creating table 'transactionRecord'
CREATE TABLE [dbo].[transactionRecord] (
    [trans_id] int IDENTITY(1,1) NOT NULL,
    [emp_id] int  NOT NULL,
    [book_id] int  NOT NULL,
    [mem_id] int  NOT NULL,
    [issue_date] datetime  NOT NULL,
    [return_date] datetime  NOT NULL,
    [last_date] datetime  NOT NULL,
    [penalty] varchar(50)  NULL,
    [book_name] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [book_id] in table 'bookRecod'
ALTER TABLE [dbo].[bookRecod]
ADD CONSTRAINT [PK_bookRecod]
    PRIMARY KEY CLUSTERED ([book_id] ASC);
GO

-- Creating primary key on [emp_id] in table 'employeeRecord'
ALTER TABLE [dbo].[employeeRecord]
ADD CONSTRAINT [PK_employeeRecord]
    PRIMARY KEY CLUSTERED ([emp_id] ASC);
GO

-- Creating primary key on [mem_id] in table 'memberRecord'
ALTER TABLE [dbo].[memberRecord]
ADD CONSTRAINT [PK_memberRecord]
    PRIMARY KEY CLUSTERED ([mem_id] ASC);
GO

-- Creating primary key on [trans_id] in table 'transactionRecord'
ALTER TABLE [dbo].[transactionRecord]
ADD CONSTRAINT [PK_transactionRecord]
    PRIMARY KEY CLUSTERED ([trans_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------