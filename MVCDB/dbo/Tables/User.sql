CREATE TABLE [dbo].[User] (
    [UserId]    BIGINT         IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50)  NULL,
    [LastName]  NVARCHAR (50)  NULL,
    [Email]     NVARCHAR (255) NOT NULL,
    [RoleId]    BIGINT         NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_User_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId])
);

