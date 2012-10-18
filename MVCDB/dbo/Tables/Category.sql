CREATE TABLE [dbo].[Category] (
    [CategoryId]       BIGINT         IDENTITY (1, 1) NOT NULL,
    [ParentCategoryId] BIGINT         NULL,
    [Name]             NVARCHAR (50)  NOT NULL,
    [Description]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([CategoryId] ASC),
    CONSTRAINT [FK_Category_Category] FOREIGN KEY ([ParentCategoryId]) REFERENCES [dbo].[Category] ([CategoryId])
);

