CREATE TABLE [dbo].[Locations] (
    [Id]                                INT           IDENTITY (1, 1)   NOT NULL,
    [Address1]                          NVARCHAR (250)                  NULL,
    [Address2]                          NVARCHAR (250)                  NULL,
    [City]                              NVARCHAR (250)                  NULL,
    [StateId]                           INT                             NULL,
    [ZipCode]                           NVARCHAR (50)                   NULL,
    [Latitude]                          FLOAT                           NULL,   
    [Longitude]                         FLOAT                           NULL,  
    [CreatedDate]                       DATETIME                        NOT NULL,
    [CreatedBy]                         INT                             NOT NULL,
    [UpdatedDate]                       DATETIME                        NULL,
    [UpdatedBy]                         INT                             NULL,
    CONSTRAINT [PK_Locations] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Location_State] FOREIGN KEY ([StateId]) REFERENCES [dbo].[States] ([Id])
);

