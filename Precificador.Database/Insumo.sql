CREATE TABLE [dbo].[Insumo] (
    [Id]               INT             NOT NULL IDENTITY(1, 1),
    [Nome]             VARCHAR (200)   NOT NULL,
    [PrecoPacote]      DECIMAL (18, 2) NOT NULL,
    [QuantidadePacote] DECIMAL (18, 2) NOT NULL,
    [PrecoUnidade]     DECIMAL (18, 2) NOT NULL,
    [IdTipoInsumo]     INT             NOT NULL,
    [IdUnidadeMedida]  INT             NOT NULL,
    CONSTRAINT [PK_Insumo] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Insumo_TipoInsumo] FOREIGN KEY ([IdTipoInsumo]) REFERENCES [dbo].[TipoInsumo] ([Id]),
    CONSTRAINT [FK_Insumo_UnidadeMedida] FOREIGN KEY ([IdUnidadeMedida]) REFERENCES [dbo].[UnidadeMedida] ([Id])
);

