
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/07/2023 15:34:36
-- Generated from EDMX file: C:\Users\dprado\source\repos\EjercicioMVC3\Models\EjercicioMVC3Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EjercicioMVC3BD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Actores'
CREATE TABLE [dbo].[Actores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreActor] nvarchar(max)  NOT NULL,
    [Nacion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Directores'
CREATE TABLE [dbo].[Directores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreDirector] nvarchar(max)  NOT NULL,
    [FechaNacimiento] nvarchar(max)  NOT NULL,
    [Nacion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Peliculas'
CREATE TABLE [dbo].[Peliculas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titulo] nvarchar(max)  NOT NULL,
    [Estreno] nvarchar(max)  NOT NULL,
    [Nacion] nvarchar(max)  NOT NULL,
    [Idioma] nvarchar(max)  NOT NULL,
    [Color] nvarchar(max)  NOT NULL,
    [Resumen] nvarchar(max)  NOT NULL,
    [Observacion] nvarchar(max)  NOT NULL,
    [DirectorId] int  NOT NULL
);
GO

-- Creating table 'Repartos'
CREATE TABLE [dbo].[Repartos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Personaje] nvarchar(max)  NOT NULL,
    [PeliculaId] int  NOT NULL,
    [ActorId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Actores'
ALTER TABLE [dbo].[Actores]
ADD CONSTRAINT [PK_Actores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Directores'
ALTER TABLE [dbo].[Directores]
ADD CONSTRAINT [PK_Directores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Peliculas'
ALTER TABLE [dbo].[Peliculas]
ADD CONSTRAINT [PK_Peliculas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Repartos'
ALTER TABLE [dbo].[Repartos]
ADD CONSTRAINT [PK_Repartos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DirectorId] in table 'Peliculas'
ALTER TABLE [dbo].[Peliculas]
ADD CONSTRAINT [FK_DirectorPelicula]
    FOREIGN KEY ([DirectorId])
    REFERENCES [dbo].[Directores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DirectorPelicula'
CREATE INDEX [IX_FK_DirectorPelicula]
ON [dbo].[Peliculas]
    ([DirectorId]);
GO

-- Creating foreign key on [PeliculaId] in table 'Repartos'
ALTER TABLE [dbo].[Repartos]
ADD CONSTRAINT [FK_PeliculaReparto]
    FOREIGN KEY ([PeliculaId])
    REFERENCES [dbo].[Peliculas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PeliculaReparto'
CREATE INDEX [IX_FK_PeliculaReparto]
ON [dbo].[Repartos]
    ([PeliculaId]);
GO

-- Creating foreign key on [ActorId] in table 'Repartos'
ALTER TABLE [dbo].[Repartos]
ADD CONSTRAINT [FK_ActorReparto]
    FOREIGN KEY ([ActorId])
    REFERENCES [dbo].[Actores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActorReparto'
CREATE INDEX [IX_FK_ActorReparto]
ON [dbo].[Repartos]
    ([ActorId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------