
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/29/2018 08:37:59
-- Generated from EDMX file: E:\Client Documents\Harre Singh\28 march 2018 Harre Assignment 2 – Enterprise Computing\Assignment2\Assignment2\Assignment2\Models\TheaterModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Movies];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Screens__Theater__286302EC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Screens] DROP CONSTRAINT [FK__Screens__Theater__286302EC];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Screens]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Screens];
GO
IF OBJECT_ID(N'[dbo].[Theaters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Theaters];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Screens'
CREATE TABLE [dbo].[Screens] (
    [Theater_id] varchar(6)  NULL,
    [Screen_id] varchar(6)  NOT NULL,
    [No_of_Seats] decimal(3,0)  NULL,
    [Current_Movie] varchar(100)  NULL,
    [ThreeD] varchar(5)  NULL
);
GO

-- Creating table 'Theaters'
CREATE TABLE [dbo].[Theaters] (
    [Theater_id] varchar(6)  NOT NULL,
    [TheaterName] varchar(30)  NULL,
    [Address] varchar(50)  NULL,
    [PhoneNumber] varchar(20)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Screen_id] in table 'Screens'
ALTER TABLE [dbo].[Screens]
ADD CONSTRAINT [PK_Screens]
    PRIMARY KEY CLUSTERED ([Screen_id] ASC);
GO

-- Creating primary key on [Theater_id] in table 'Theaters'
ALTER TABLE [dbo].[Theaters]
ADD CONSTRAINT [PK_Theaters]
    PRIMARY KEY CLUSTERED ([Theater_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Theater_id] in table 'Screens'
ALTER TABLE [dbo].[Screens]
ADD CONSTRAINT [FK__Screens__Theater__286302EC]
    FOREIGN KEY ([Theater_id])
    REFERENCES [dbo].[Theaters]
        ([Theater_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Screens__Theater__286302EC'
CREATE INDEX [IX_FK__Screens__Theater__286302EC]
ON [dbo].[Screens]
    ([Theater_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------