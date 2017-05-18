
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/13/2013 11:38:06
-- Generated from EDMX file: C:\Users\maimunas\Videos\IC2013WebApp\Ubuoy\Ubuoy.UserAuthentication\Model\UbuoyDbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ubuoy];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Application_Task]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Applications] DROP CONSTRAINT [FK_Application_Task];
GO
IF OBJECT_ID(N'[dbo].[FK_Application_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Applications] DROP CONSTRAINT [FK_Application_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Availibility_Skill]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Availibilities] DROP CONSTRAINT [FK_Availibility_Skill];
GO
IF OBJECT_ID(N'[dbo].[FK_Availibility_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Availibilities] DROP CONSTRAINT [FK_Availibility_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Skill_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Skills] DROP CONSTRAINT [FK_Skill_Category];
GO
IF OBJECT_ID(N'[dbo].[FK_Task_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [FK_Task_Category];
GO
IF OBJECT_ID(N'[dbo].[FK_Following_Orginization]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Followings] DROP CONSTRAINT [FK_Following_Orginization];
GO
IF OBJECT_ID(N'[dbo].[FK_Following_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Followings] DROP CONSTRAINT [FK_Following_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_Following_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Followings] DROP CONSTRAINT [FK_Following_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_NewsFeed_Following]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NewsFeeds] DROP CONSTRAINT [FK_NewsFeed_Following];
GO
IF OBJECT_ID(N'[dbo].[FK_User_With_honor_Honors]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_With_honor] DROP CONSTRAINT [FK_User_With_honor_Honors];
GO
IF OBJECT_ID(N'[dbo].[FK_Project_ImagePackage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [FK_Project_ImagePackage];
GO
IF OBJECT_ID(N'[dbo].[FK_UserModules_Module]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserModules] DROP CONSTRAINT [FK_UserModules_Module];
GO
IF OBJECT_ID(N'[dbo].[FK_NewsFeed_Orginization]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NewsFeeds] DROP CONSTRAINT [FK_NewsFeed_Orginization];
GO
IF OBJECT_ID(N'[dbo].[FK_NewsFeed_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NewsFeeds] DROP CONSTRAINT [FK_NewsFeed_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_Project_Orginization]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [FK_Project_Orginization];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProjects_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserProjects] DROP CONSTRAINT [FK_UserProjects_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_Role_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [FK_Role_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Task_Skill]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [FK_Task_Skill];
GO
IF OBJECT_ID(N'[dbo].[FK_User_With_honor_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_With_honor] DROP CONSTRAINT [FK_User_With_honor_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UserModules_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserModules] DROP CONSTRAINT [FK_UserModules_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProjects_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserProjects] DROP CONSTRAINT [FK_UserProjects_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO
IF OBJECT_ID(N'[dbo].[Applications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Applications];
GO
IF OBJECT_ID(N'[dbo].[Availibilities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Availibilities];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[Followings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Followings];
GO
IF OBJECT_ID(N'[dbo].[Honors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Honors];
GO
IF OBJECT_ID(N'[dbo].[ImagePackages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImagePackages];
GO
IF OBJECT_ID(N'[dbo].[Modules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Modules];
GO
IF OBJECT_ID(N'[dbo].[NewsFeeds]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NewsFeeds];
GO
IF OBJECT_ID(N'[dbo].[Orginizations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orginizations];
GO
IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Skills]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Skills];
GO
IF OBJECT_ID(N'[dbo].[Tasks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tasks];
GO
IF OBJECT_ID(N'[dbo].[User_With_honor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_With_honor];
GO
IF OBJECT_ID(N'[dbo].[UserModules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserModules];
GO
IF OBJECT_ID(N'[dbo].[UserProjects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserProjects];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[UsersTasks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersTasks];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [addressId] uniqueidentifier  NOT NULL,
    [country] nvarchar(50)  NOT NULL,
    [city] nvarchar(50)  NOT NULL,
    [postalCode] int  NOT NULL,
    [streetAddress] nvarchar(max)  NOT NULL,
    [phone] nvarchar(50)  NOT NULL,
    [email] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Applications'
CREATE TABLE [dbo].[Applications] (
    [applicationId] uniqueidentifier  NOT NULL,
    [userId] uniqueidentifier  NOT NULL,
    [taskId] uniqueidentifier  NOT NULL,
    [euro_Hr] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'Availibilities'
CREATE TABLE [dbo].[Availibilities] (
    [availibilityId] uniqueidentifier  NOT NULL,
    [userId] uniqueidentifier  NOT NULL,
    [skillId] uniqueidentifier  NOT NULL,
    [from] datetime  NOT NULL,
    [to] datetime  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [categoryId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [image] varchar(max)  NULL,
    [parent] nvarchar(50)  NULL
);
GO

-- Creating table 'Followings'
CREATE TABLE [dbo].[Followings] (
    [followingId] uniqueidentifier  NOT NULL,
    [organizationId] uniqueidentifier  NULL,
    [projectId] uniqueidentifier  NULL,
    [userId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Honors'
CREATE TABLE [dbo].[Honors] (
    [honorId] uniqueidentifier  NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [image] nvarchar(max)  NULL
);
GO

-- Creating table 'ImagePackages'
CREATE TABLE [dbo].[ImagePackages] (
    [imageId] uniqueidentifier  NOT NULL,
    [imageDefault] varchar(max)  NULL,
    [image1] nvarchar(max)  NULL,
    [image2] nvarchar(max)  NULL,
    [image3] nvarchar(max)  NULL,
    [image4] nvarchar(max)  NULL,
    [image5] nvarchar(max)  NULL,
    [image6] nvarchar(max)  NULL,
    [image7] nvarchar(max)  NULL,
    [image8] nvarchar(max)  NULL,
    [image9] nvarchar(max)  NULL,
    [image10] nvarchar(max)  NULL
);
GO

-- Creating table 'Modules'
CREATE TABLE [dbo].[Modules] (
    [moduleId] uniqueidentifier  NOT NULL,
    [name] varchar(max)  NULL,
    [icon] varchar(max)  NULL,
    [description] varchar(max)  NULL
);
GO

-- Creating table 'NewsFeeds'
CREATE TABLE [dbo].[NewsFeeds] (
    [newsFeedId] uniqueidentifier  NOT NULL,
    [organizationId] uniqueidentifier  NOT NULL,
    [projectId] uniqueidentifier  NOT NULL,
    [date] datetime  NOT NULL,
    [feed] nvarchar(max)  NOT NULL,
    [followingId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Orginizations'
CREATE TABLE [dbo].[Orginizations] (
    [orginizationId] uniqueidentifier  NOT NULL,
    [name] varchar(50)  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [link] nvarchar(max)  NULL,
    [imagePackageId] uniqueidentifier  NULL,
    [orgLogo] varchar(max)  NULL,
    [orgFgColor] nvarchar(50)  NULL,
    [orgBgColor] nvarchar(50)  NULL,
    [country] nvarchar(max)  NULL,
    [city] nvarchar(max)  NULL,
    [postalCode] int  NULL,
    [streetAdress] nvarchar(max)  NULL,
    [email] nvarchar(max)  NULL,
    [phone] nvarchar(max)  NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [projectId] uniqueidentifier  NOT NULL,
    [organizationId] uniqueidentifier  NULL,
    [description] nvarchar(max)  NULL,
    [startedOn] datetime  NULL,
    [endOn] datetime  NULL,
    [budget] decimal(38,0)  NULL,
    [recived] decimal(38,0)  NULL,
    [userId] uniqueidentifier  NULL,
    [imagePackageId] uniqueidentifier  NULL,
    [currency] nchar(10)  NULL,
    [updateDate] datetime  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [roleId] uniqueidentifier  NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [userId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Skills'
CREATE TABLE [dbo].[Skills] (
    [skillId] uniqueidentifier  NOT NULL,
    [skillName] nvarchar(50)  NULL,
    [description] nvarchar(max)  NULL,
    [categoryId] uniqueidentifier  NULL,
    [userId] uniqueidentifier  NULL,
    [image] nvarchar(max)  NULL,
    [updateDate] datetime  NULL
);
GO

-- Creating table 'Tasks'
CREATE TABLE [dbo].[Tasks] (
    [taskId] uniqueidentifier  NOT NULL,
    [owner] nvarchar(50)  NULL,
    [doer] nvarchar(50)  NULL,
    [startedOn] datetime  NULL,
    [endline] nvarchar(max)  NULL,
    [deadline] datetime  NULL,
    [description] nvarchar(max)  NULL,
    [categoryId] uniqueidentifier  NULL,
    [status] nvarchar(max)  NULL,
    [skillId] uniqueidentifier  NULL,
    [updateDate] datetime  NULL
);
GO

-- Creating table 'User_With_honor'
CREATE TABLE [dbo].[User_With_honor] (
    [userWithHonorId] uniqueidentifier  NOT NULL,
    [userId] uniqueidentifier  NOT NULL,
    [honorId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'UserModules'
CREATE TABLE [dbo].[UserModules] (
    [userModuleId] uniqueidentifier  NOT NULL,
    [userId] uniqueidentifier  NULL,
    [prority] bit  NULL,
    [moduleFgColor] nvarchar(50)  NULL,
    [moduleBgColor] nvarchar(50)  NULL
);
GO

-- Creating table 'UserProjects'
CREATE TABLE [dbo].[UserProjects] (
    [projectId] uniqueidentifier  NULL,
    [userId] uniqueidentifier  NULL,
    [priority] bit  NULL,
    [userProjectId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [userId] uniqueidentifier  NOT NULL,
    [firstName] nvarchar(50)  NOT NULL,
    [lastName] nvarchar(50)  NOT NULL,
    [email] nvarchar(50)  NOT NULL,
    [gender] nvarchar(50)  NULL,
    [DOB] datetime  NULL,
    [password] nvarchar(max)  NULL,
    [phoneNumber] nvarchar(max)  NULL,
    [image] nvarchar(max)  NULL,
    [country] nvarchar(max)  NULL,
    [city] nvarchar(max)  NULL,
    [postalCode] int  NULL,
    [streetAddress] nvarchar(max)  NULL
);
GO

-- Creating table 'UsersTasks'
CREATE TABLE [dbo].[UsersTasks] (
    [userTaskId] uniqueidentifier  NOT NULL,
    [userId] uniqueidentifier  NULL,
    [taskId] uniqueidentifier  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [addressId] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([addressId] ASC);
GO

-- Creating primary key on [applicationId] in table 'Applications'
ALTER TABLE [dbo].[Applications]
ADD CONSTRAINT [PK_Applications]
    PRIMARY KEY CLUSTERED ([applicationId] ASC);
GO

-- Creating primary key on [availibilityId] in table 'Availibilities'
ALTER TABLE [dbo].[Availibilities]
ADD CONSTRAINT [PK_Availibilities]
    PRIMARY KEY CLUSTERED ([availibilityId] ASC);
GO

-- Creating primary key on [categoryId] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([categoryId] ASC);
GO

-- Creating primary key on [followingId] in table 'Followings'
ALTER TABLE [dbo].[Followings]
ADD CONSTRAINT [PK_Followings]
    PRIMARY KEY CLUSTERED ([followingId] ASC);
GO

-- Creating primary key on [honorId] in table 'Honors'
ALTER TABLE [dbo].[Honors]
ADD CONSTRAINT [PK_Honors]
    PRIMARY KEY CLUSTERED ([honorId] ASC);
GO

-- Creating primary key on [imageId] in table 'ImagePackages'
ALTER TABLE [dbo].[ImagePackages]
ADD CONSTRAINT [PK_ImagePackages]
    PRIMARY KEY CLUSTERED ([imageId] ASC);
GO

-- Creating primary key on [moduleId] in table 'Modules'
ALTER TABLE [dbo].[Modules]
ADD CONSTRAINT [PK_Modules]
    PRIMARY KEY CLUSTERED ([moduleId] ASC);
GO

-- Creating primary key on [newsFeedId] in table 'NewsFeeds'
ALTER TABLE [dbo].[NewsFeeds]
ADD CONSTRAINT [PK_NewsFeeds]
    PRIMARY KEY CLUSTERED ([newsFeedId] ASC);
GO

-- Creating primary key on [orginizationId] in table 'Orginizations'
ALTER TABLE [dbo].[Orginizations]
ADD CONSTRAINT [PK_Orginizations]
    PRIMARY KEY CLUSTERED ([orginizationId] ASC);
GO

-- Creating primary key on [projectId] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([projectId] ASC);
GO

-- Creating primary key on [roleId] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([roleId] ASC);
GO

-- Creating primary key on [skillId] in table 'Skills'
ALTER TABLE [dbo].[Skills]
ADD CONSTRAINT [PK_Skills]
    PRIMARY KEY CLUSTERED ([skillId] ASC);
GO

-- Creating primary key on [taskId] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [PK_Tasks]
    PRIMARY KEY CLUSTERED ([taskId] ASC);
GO

-- Creating primary key on [userWithHonorId] in table 'User_With_honor'
ALTER TABLE [dbo].[User_With_honor]
ADD CONSTRAINT [PK_User_With_honor]
    PRIMARY KEY CLUSTERED ([userWithHonorId] ASC);
GO

-- Creating primary key on [userModuleId] in table 'UserModules'
ALTER TABLE [dbo].[UserModules]
ADD CONSTRAINT [PK_UserModules]
    PRIMARY KEY CLUSTERED ([userModuleId] ASC);
GO

-- Creating primary key on [userProjectId] in table 'UserProjects'
ALTER TABLE [dbo].[UserProjects]
ADD CONSTRAINT [PK_UserProjects]
    PRIMARY KEY CLUSTERED ([userProjectId] ASC);
GO

-- Creating primary key on [userId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([userId] ASC);
GO

-- Creating primary key on [userTaskId] in table 'UsersTasks'
ALTER TABLE [dbo].[UsersTasks]
ADD CONSTRAINT [PK_UsersTasks]
    PRIMARY KEY CLUSTERED ([userTaskId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [taskId] in table 'Applications'
ALTER TABLE [dbo].[Applications]
ADD CONSTRAINT [FK_Application_Task]
    FOREIGN KEY ([taskId])
    REFERENCES [dbo].[Tasks]
        ([taskId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Application_Task'
CREATE INDEX [IX_FK_Application_Task]
ON [dbo].[Applications]
    ([taskId]);
GO

-- Creating foreign key on [userId] in table 'Applications'
ALTER TABLE [dbo].[Applications]
ADD CONSTRAINT [FK_Application_Users]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[Users]
        ([userId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Application_Users'
CREATE INDEX [IX_FK_Application_Users]
ON [dbo].[Applications]
    ([userId]);
GO

-- Creating foreign key on [skillId] in table 'Availibilities'
ALTER TABLE [dbo].[Availibilities]
ADD CONSTRAINT [FK_Availibility_Skill]
    FOREIGN KEY ([skillId])
    REFERENCES [dbo].[Skills]
        ([skillId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Availibility_Skill'
CREATE INDEX [IX_FK_Availibility_Skill]
ON [dbo].[Availibilities]
    ([skillId]);
GO

-- Creating foreign key on [userId] in table 'Availibilities'
ALTER TABLE [dbo].[Availibilities]
ADD CONSTRAINT [FK_Availibility_Users]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[Users]
        ([userId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Availibility_Users'
CREATE INDEX [IX_FK_Availibility_Users]
ON [dbo].[Availibilities]
    ([userId]);
GO

-- Creating foreign key on [categoryId] in table 'Skills'
ALTER TABLE [dbo].[Skills]
ADD CONSTRAINT [FK_Skill_Category]
    FOREIGN KEY ([categoryId])
    REFERENCES [dbo].[Categories]
        ([categoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Skill_Category'
CREATE INDEX [IX_FK_Skill_Category]
ON [dbo].[Skills]
    ([categoryId]);
GO

-- Creating foreign key on [categoryId] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [FK_Task_Category]
    FOREIGN KEY ([categoryId])
    REFERENCES [dbo].[Categories]
        ([categoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Task_Category'
CREATE INDEX [IX_FK_Task_Category]
ON [dbo].[Tasks]
    ([categoryId]);
GO

-- Creating foreign key on [organizationId] in table 'Followings'
ALTER TABLE [dbo].[Followings]
ADD CONSTRAINT [FK_Following_Orginization]
    FOREIGN KEY ([organizationId])
    REFERENCES [dbo].[Orginizations]
        ([orginizationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Following_Orginization'
CREATE INDEX [IX_FK_Following_Orginization]
ON [dbo].[Followings]
    ([organizationId]);
GO

-- Creating foreign key on [projectId] in table 'Followings'
ALTER TABLE [dbo].[Followings]
ADD CONSTRAINT [FK_Following_Project]
    FOREIGN KEY ([projectId])
    REFERENCES [dbo].[Projects]
        ([projectId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Following_Project'
CREATE INDEX [IX_FK_Following_Project]
ON [dbo].[Followings]
    ([projectId]);
GO

-- Creating foreign key on [userId] in table 'Followings'
ALTER TABLE [dbo].[Followings]
ADD CONSTRAINT [FK_Following_Users]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[Users]
        ([userId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Following_Users'
CREATE INDEX [IX_FK_Following_Users]
ON [dbo].[Followings]
    ([userId]);
GO

-- Creating foreign key on [followingId] in table 'NewsFeeds'
ALTER TABLE [dbo].[NewsFeeds]
ADD CONSTRAINT [FK_NewsFeed_Following]
    FOREIGN KEY ([followingId])
    REFERENCES [dbo].[Followings]
        ([followingId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_NewsFeed_Following'
CREATE INDEX [IX_FK_NewsFeed_Following]
ON [dbo].[NewsFeeds]
    ([followingId]);
GO

-- Creating foreign key on [honorId] in table 'User_With_honor'
ALTER TABLE [dbo].[User_With_honor]
ADD CONSTRAINT [FK_User_With_honor_Honors]
    FOREIGN KEY ([honorId])
    REFERENCES [dbo].[Honors]
        ([honorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_User_With_honor_Honors'
CREATE INDEX [IX_FK_User_With_honor_Honors]
ON [dbo].[User_With_honor]
    ([honorId]);
GO

-- Creating foreign key on [imagePackageId] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_Project_ImagePackage]
    FOREIGN KEY ([imagePackageId])
    REFERENCES [dbo].[ImagePackages]
        ([imageId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Project_ImagePackage'
CREATE INDEX [IX_FK_Project_ImagePackage]
ON [dbo].[Projects]
    ([imagePackageId]);
GO

-- Creating foreign key on [userModuleId] in table 'UserModules'
ALTER TABLE [dbo].[UserModules]
ADD CONSTRAINT [FK_UserModules_Module]
    FOREIGN KEY ([userModuleId])
    REFERENCES [dbo].[Modules]
        ([moduleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [organizationId] in table 'NewsFeeds'
ALTER TABLE [dbo].[NewsFeeds]
ADD CONSTRAINT [FK_NewsFeed_Orginization]
    FOREIGN KEY ([organizationId])
    REFERENCES [dbo].[Orginizations]
        ([orginizationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_NewsFeed_Orginization'
CREATE INDEX [IX_FK_NewsFeed_Orginization]
ON [dbo].[NewsFeeds]
    ([organizationId]);
GO

-- Creating foreign key on [projectId] in table 'NewsFeeds'
ALTER TABLE [dbo].[NewsFeeds]
ADD CONSTRAINT [FK_NewsFeed_Project]
    FOREIGN KEY ([projectId])
    REFERENCES [dbo].[Projects]
        ([projectId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_NewsFeed_Project'
CREATE INDEX [IX_FK_NewsFeed_Project]
ON [dbo].[NewsFeeds]
    ([projectId]);
GO

-- Creating foreign key on [organizationId] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_Project_Orginization]
    FOREIGN KEY ([organizationId])
    REFERENCES [dbo].[Orginizations]
        ([orginizationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Project_Orginization'
CREATE INDEX [IX_FK_Project_Orginization]
ON [dbo].[Projects]
    ([organizationId]);
GO

-- Creating foreign key on [projectId] in table 'UserProjects'
ALTER TABLE [dbo].[UserProjects]
ADD CONSTRAINT [FK_UserProjects_Project]
    FOREIGN KEY ([projectId])
    REFERENCES [dbo].[Projects]
        ([projectId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProjects_Project'
CREATE INDEX [IX_FK_UserProjects_Project]
ON [dbo].[UserProjects]
    ([projectId]);
GO

-- Creating foreign key on [userId] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [FK_Role_Users]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[Users]
        ([userId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Role_Users'
CREATE INDEX [IX_FK_Role_Users]
ON [dbo].[Roles]
    ([userId]);
GO

-- Creating foreign key on [skillId] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [FK_Task_Skill]
    FOREIGN KEY ([skillId])
    REFERENCES [dbo].[Skills]
        ([skillId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Task_Skill'
CREATE INDEX [IX_FK_Task_Skill]
ON [dbo].[Tasks]
    ([skillId]);
GO

-- Creating foreign key on [userId] in table 'User_With_honor'
ALTER TABLE [dbo].[User_With_honor]
ADD CONSTRAINT [FK_User_With_honor_Users]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[Users]
        ([userId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_User_With_honor_Users'
CREATE INDEX [IX_FK_User_With_honor_Users]
ON [dbo].[User_With_honor]
    ([userId]);
GO

-- Creating foreign key on [userId] in table 'UserModules'
ALTER TABLE [dbo].[UserModules]
ADD CONSTRAINT [FK_UserModules_User]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[Users]
        ([userId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserModules_User'
CREATE INDEX [IX_FK_UserModules_User]
ON [dbo].[UserModules]
    ([userId]);
GO

-- Creating foreign key on [userId] in table 'UserProjects'
ALTER TABLE [dbo].[UserProjects]
ADD CONSTRAINT [FK_UserProjects_User]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[Users]
        ([userId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProjects_User'
CREATE INDEX [IX_FK_UserProjects_User]
ON [dbo].[UserProjects]
    ([userId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------