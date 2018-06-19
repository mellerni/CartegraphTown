CREATE TABLE [dbo].[Users] (
    [Id]                                INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]                         VARCHAR (250) NOT NULL,
    [LastName]                          VARCHAR (250) NOT NULL,
    [Email]                             VARCHAR (50)  NULL,   
    [CreatedDate]                       DATETIME      NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

