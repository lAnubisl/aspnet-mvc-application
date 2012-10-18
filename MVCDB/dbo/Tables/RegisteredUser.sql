CREATE TABLE [dbo].[RegisteredUser] (
    [RegisteredUserId] BIGINT         NOT NULL,
    [Password]         NVARCHAR (255) NOT NULL,
    CONSTRAINT [FK_RegisteredUser_User] FOREIGN KEY ([RegisteredUserId]) REFERENCES [dbo].[User] ([UserId])
);

