CREATE TABLE [dbo].[Citizens] (
    [Id]                                INT IDENTITY (1, 1) NOT NULL,
    [FirstName]                         NVARCHAR (250)      NOT NULL,
    [LastName]                          NVARCHAR (250)      NOT NULL,
    [Email]                             NVARCHAR (250)      NULL,   
    [Phone]                             NVARCHAR (50)       NULL,   
    [LocationId]                        INT                 NULL,  
    [CreatedDate]                       DATETIME            NOT NULL,
    [CreatedBy]                         INT                 NOT NULL,
    [UpdatedDate]                       DATETIME            NULL,
    [UpdatedBy]                         INT                 NULL,
    CONSTRAINT [PK_Citizens] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Citizen_Location] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Locations] ([Id])
);

