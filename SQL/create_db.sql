USE [master]
GO

IF db_id('FITC') IS NULL
  CREATE DATABASE [FITC]
GO

USE [FITC]
GO

DROP TABLE IF EXISTS [Gardener];
DROP TABLE IF EXISTS [Plot];
GO


CREATE TABLE [Plot] (
  [Id] integer PRIMARY KEY IDENTITY (1,1),
  [Bed] varchar(25) NOT NULL
)
GO

CREATE TABLE [Gardener] (
  [Id] integer PRIMARY KEY IDENTITY (1,1),
  [FirstName] varchar (255) NOT NULL,
  [LastName] varchar (255) NOT NULL,
  [Phone] varchar (255) NOT NULL,
  [Email] varchar (255) NOT NULL,
  [PlotId] varchar NOT NULL
  CONSTRAINT [FK_Gardener_Plot] FOREIGN KEY ([PlotId]) REFERENCES [Plot] ([Id])
)
GO

ALTER TABLE [Gardener] ADD FOREIGN KEY ([PlotId]) REFERENCES [Plot] ([Id])
GO