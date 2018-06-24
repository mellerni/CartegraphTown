CREATE TABLE [dbo].[Issues] (
    [Id]                                INT IDENTITY (1, 1) NOT NULL,
    [IssueType]                         INT                 NOT NULL,
    [LocationId]                        INT                 NOT NULL,
    [CitizenId]                         INT                 NOT NULL,
    [Details]                           NVARCHAR (4000)     NULL,
    [CreatedDate]                       DATETIME            NOT NULL,
    [CreatedBy]                         INT                 NOT NULL,
    [UpdatedDate]                       DATETIME            NULL,
    [UpdatedBy]                         INT                 NULL,
    [CorrectiveAction]                  NVARCHAR (4000)     NULL,
    [CorrectionDate]                    DATETIME            NULL,
    CONSTRAINT [PK_Issues] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Issue_Citizen] FOREIGN KEY ([CitizenId]) REFERENCES [dbo].[Citizens] ([Id]),
    CONSTRAINT [FK_Issue_Location] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Locations] ([Id])
);

