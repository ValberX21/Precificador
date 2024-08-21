CREATE TABLE [dbo].[Insumo] (
    [Id]               INT             NOT NULL,
    [Nome]             VARCHAR (200)   NOT NULL,
    [Unidade]          VARCHAR (10)    NOT NULL,
    [PrecoPacote]      DECIMAL (18, 2) NOT NULL,
    [QuantidadePacote] DECIMAL (18, 2) NOT NULL,
    [PrecoUnidade]     DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_Insumo] PRIMARY KEY CLUSTERED ([Id] ASC)
);

