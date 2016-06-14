
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/26/2016 18:04:50
-- Generated from EDMX file: c:\users\max\documents\visual studio 2012\Projects\Forum\Forum\ForumDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [c:\users\max\documents\visual studio 2012\Projects\Forum\Forum\App_Data\DatabaseForum.mdf];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TopicsDiscus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiscusНабор] DROP CONSTRAINT [FK_TopicsDiscus];
GO
IF OBJECT_ID(N'[dbo].[FK_DiscusAnswer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AnswerНабор] DROP CONSTRAINT [FK_DiscusAnswer];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TopicsНабор]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TopicsНабор];
GO
IF OBJECT_ID(N'[dbo].[DiscusНабор]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DiscusНабор];
GO
IF OBJECT_ID(N'[dbo].[AnswerНабор]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AnswerНабор];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TopicsНабор'
CREATE TABLE [dbo].[TopicsНабор] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TopicName] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Author] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DiscusНабор'
CREATE TABLE [dbo].[DiscusНабор] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TopicsID] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [Author] nvarchar(max)  NOT NULL,
    [Text] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AnswerНабор'
CREATE TABLE [dbo].[AnswerНабор] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DiscusID] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [Author] nvarchar(max)  NOT NULL,
    [Text] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'TopicsНабор'
ALTER TABLE [dbo].[TopicsНабор]
ADD CONSTRAINT [PK_TopicsНабор]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DiscusНабор'
ALTER TABLE [dbo].[DiscusНабор]
ADD CONSTRAINT [PK_DiscusНабор]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AnswerНабор'
ALTER TABLE [dbo].[AnswerНабор]
ADD CONSTRAINT [PK_AnswerНабор]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TopicsID] in table 'DiscusНабор'
ALTER TABLE [dbo].[DiscusНабор]
ADD CONSTRAINT [FK_TopicsDiscus]
    FOREIGN KEY ([TopicsID])
    REFERENCES [dbo].[TopicsНабор]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TopicsDiscus'
CREATE INDEX [IX_FK_TopicsDiscus]
ON [dbo].[DiscusНабор]
    ([TopicsID]);
GO

-- Creating foreign key on [DiscusID] in table 'AnswerНабор'
ALTER TABLE [dbo].[AnswerНабор]
ADD CONSTRAINT [FK_DiscusAnswer]
    FOREIGN KEY ([DiscusID])
    REFERENCES [dbo].[DiscusНабор]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DiscusAnswer'
CREATE INDEX [IX_FK_DiscusAnswer]
ON [dbo].[AnswerНабор]
    ([DiscusID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------