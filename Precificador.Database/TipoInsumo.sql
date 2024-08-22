CREATE TABLE [dbo].[TipoInsumo] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Nome] VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_TipoInsumo] PRIMARY KEY CLUSTERED ([Id] ASC)
);

