
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/09/2017 21:04:28
-- Generated from EDMX file: C:\Users\匀强的磁场\Desktop\Moe\MoeMoeD\MoeMoe.Model\MoeMoeD.edmx
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

IF OBJECT_ID(N'[dbo].[FK_UserFlie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Flie] DROP CONSTRAINT [FK_UserFlie];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFloder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Floder] DROP CONSTRAINT [FK_UserFloder];
GO
IF OBJECT_ID(N'[dbo].[FK_FloderFlie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Flie] DROP CONSTRAINT [FK_FloderFlie];
GO
IF OBJECT_ID(N'[dbo].[FK_FloderFloder_Floder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FloderFloder] DROP CONSTRAINT [FK_FloderFloder_Floder];
GO
IF OBJECT_ID(N'[dbo].[FK_FloderFloder_Floder1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FloderFloder] DROP CONSTRAINT [FK_FloderFloder_Floder1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Flie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Flie];
GO
IF OBJECT_ID(N'[dbo].[Floder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Floder];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[FloderFloder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FloderFloder];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Flie'
CREATE TABLE [dbo].[Flie] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [UserId] int  NOT NULL,
    [FloderId] int  NOT NULL
);
GO

-- Creating table 'Floder'
CREATE TABLE [dbo].[Floder] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [UserId] int  NOT NULL
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

-- Creating table 'FloderFloder'
CREATE TABLE [dbo].[FloderFloder] (
    [ParentFloder_Id] int  NOT NULL,
    [ChildFloder_Id] int  NOT NULL
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

-- Creating primary key on [Id] in table 'Floder'
ALTER TABLE [dbo].[Floder]
ADD CONSTRAINT [PK_Floder]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ParentFloder_Id], [ChildFloder_Id] in table 'FloderFloder'
ALTER TABLE [dbo].[FloderFloder]
ADD CONSTRAINT [PK_FloderFloder]
    PRIMARY KEY CLUSTERED ([ParentFloder_Id], [ChildFloder_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'Flie'
ALTER TABLE [dbo].[Flie]
ADD CONSTRAINT [FK_UserFlie]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserFlie'
CREATE INDEX [IX_FK_UserFlie]
ON [dbo].[Flie]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Floder'
ALTER TABLE [dbo].[Floder]
ADD CONSTRAINT [FK_UserFloder]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserFloder'
CREATE INDEX [IX_FK_UserFloder]
ON [dbo].[Floder]
    ([UserId]);
GO

-- Creating foreign key on [FloderId] in table 'Flie'
ALTER TABLE [dbo].[Flie]
ADD CONSTRAINT [FK_FloderFlie]
    FOREIGN KEY ([FloderId])
    REFERENCES [dbo].[Floder]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FloderFlie'
CREATE INDEX [IX_FK_FloderFlie]
ON [dbo].[Flie]
    ([FloderId]);
GO

-- Creating foreign key on [ParentFloder_Id] in table 'FloderFloder'
ALTER TABLE [dbo].[FloderFloder]
ADD CONSTRAINT [FK_FloderFloder_Floder]
    FOREIGN KEY ([ParentFloder_Id])
    REFERENCES [dbo].[Floder]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ChildFloder_Id] in table 'FloderFloder'
ALTER TABLE [dbo].[FloderFloder]
ADD CONSTRAINT [FK_FloderFloder_Floder1]
    FOREIGN KEY ([ChildFloder_Id])
    REFERENCES [dbo].[Floder]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FloderFloder_Floder1'
CREATE INDEX [IX_FK_FloderFloder_Floder1]
ON [dbo].[FloderFloder]
    ([ChildFloder_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------