
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/26/2017 09:36:08
-- Generated from EDMX file: C:\Users\Administrator\Desktop\MoeMoeD\MoeMoe.Model\Entity\MoeMoeD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MoeMoeD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FloderFlie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Flie] DROP CONSTRAINT [FK_FloderFlie];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFlie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Flie] DROP CONSTRAINT [FK_UserFlie];
GO
IF OBJECT_ID(N'[dbo].[FK_FolderFolder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Folder] DROP CONSTRAINT [FK_FolderFolder];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFloder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Folder] DROP CONSTRAINT [FK_UserFloder];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Flie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Flie];
GO
IF OBJECT_ID(N'[dbo].[Folder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Folder];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Flie'
CREATE TABLE [dbo].[Flie] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [UserId] int  NOT NULL,
    [FolderId] int  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [UpdateTime] nvarchar(max)  NOT NULL,
    [Size] nvarchar(max)  NOT NULL,
    [MD5] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Folder'
CREATE TABLE [dbo].[Folder] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [UserId] int  NOT NULL,
    [FolderId] int  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Flie'
ALTER TABLE [dbo].[Flie]
ADD CONSTRAINT [PK_Flie]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Folder'
ALTER TABLE [dbo].[Folder]
ADD CONSTRAINT [PK_Folder]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FolderId] in table 'Flie'
ALTER TABLE [dbo].[Flie]
ADD CONSTRAINT [FK_FloderFlie]
    FOREIGN KEY ([FolderId])
    REFERENCES [dbo].[Folder]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FloderFlie'
CREATE INDEX [IX_FK_FloderFlie]
ON [dbo].[Flie]
    ([FolderId]);
GO

-- Creating foreign key on [UserId] in table 'Flie'
ALTER TABLE [dbo].[Flie]
ADD CONSTRAINT [FK_UserFlie]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserFlie'
CREATE INDEX [IX_FK_UserFlie]
ON [dbo].[Flie]
    ([UserId]);
GO

-- Creating foreign key on [FolderId] in table 'Folder'
ALTER TABLE [dbo].[Folder]
ADD CONSTRAINT [FK_FolderFolder]
    FOREIGN KEY ([FolderId])
    REFERENCES [dbo].[Folder]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FolderFolder'
CREATE INDEX [IX_FK_FolderFolder]
ON [dbo].[Folder]
    ([FolderId]);
GO

-- Creating foreign key on [UserId] in table 'Folder'
ALTER TABLE [dbo].[Folder]
ADD CONSTRAINT [FK_UserFloder]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserFloder'
CREATE INDEX [IX_FK_UserFloder]
ON [dbo].[Folder]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------