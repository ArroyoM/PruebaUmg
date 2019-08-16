
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/15/2019 21:23:50
-- Generated from EDMX file: C:\Users\Bryan Arroyo\source\repos\PruebaUmg\PruebaUmg\Models\DB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TestUmg];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[alumno]', 'U') IS NOT NULL
    DROP TABLE [dbo].[alumno];
GO
IF OBJECT_ID(N'[dbo].[Curso]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Curso];
GO
IF OBJECT_ID(N'[dbo].[docente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[docente];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'alumno'
CREATE TABLE [dbo].[alumno] (
    [id] int  NOT NULL,
    [nombre] nvarchar(50)  NULL,
    [apellido] nvarchar(50)  NULL,
    [edad] datetime  NULL
);
GO

-- Creating table 'Curso'
CREATE TABLE [dbo].[Curso] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(50)  NULL,
    [docente_id] int  NOT NULL
);
GO

-- Creating table 'docente'
CREATE TABLE [dbo].[docente] (
    [id] int  NOT NULL,
    [nombre] nvarchar(50)  NULL,
    [apellido] nvarchar(50)  NULL
);
GO

-- Creating table 'alumno_cursos'
CREATE TABLE [dbo].[alumno_cursos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Curso_id] int  NOT NULL,
    [alumno_id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'alumno'
ALTER TABLE [dbo].[alumno]
ADD CONSTRAINT [PK_alumno]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Curso'
ALTER TABLE [dbo].[Curso]
ADD CONSTRAINT [PK_Curso]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'docente'
ALTER TABLE [dbo].[docente]
ADD CONSTRAINT [PK_docente]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'alumno_cursos'
ALTER TABLE [dbo].[alumno_cursos]
ADD CONSTRAINT [PK_alumno_cursos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Curso_id] in table 'alumno_cursos'
ALTER TABLE [dbo].[alumno_cursos]
ADD CONSTRAINT [FK_Cursoalumno_curso]
    FOREIGN KEY ([Curso_id])
    REFERENCES [dbo].[Curso]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cursoalumno_curso'
CREATE INDEX [IX_FK_Cursoalumno_curso]
ON [dbo].[alumno_cursos]
    ([Curso_id]);
GO

-- Creating foreign key on [alumno_id] in table 'alumno_cursos'
ALTER TABLE [dbo].[alumno_cursos]
ADD CONSTRAINT [FK_alumnoalumno_curso]
    FOREIGN KEY ([alumno_id])
    REFERENCES [dbo].[alumno]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_alumnoalumno_curso'
CREATE INDEX [IX_FK_alumnoalumno_curso]
ON [dbo].[alumno_cursos]
    ([alumno_id]);
GO

-- Creating foreign key on [docente_id] in table 'Curso'
ALTER TABLE [dbo].[Curso]
ADD CONSTRAINT [FK_docenteCurso]
    FOREIGN KEY ([docente_id])
    REFERENCES [dbo].[docente]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_docenteCurso'
CREATE INDEX [IX_FK_docenteCurso]
ON [dbo].[Curso]
    ([docente_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------