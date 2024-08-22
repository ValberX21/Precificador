CREATE TABLE [dbo].[Produto] (
    [Id]               INT             NOT NULL IDENTITY(1, 1),
    [Nome]             VARCHAR (200)   NOT NULL,
    [Custo]            DECIMAL (18, 2) NOT NULL,
    [Margem]           DECIMAL (18, 2) NOT NULL,
    [PrecoVenda]       DECIMAL (18, 2) NOT NULL,
    [PrecoPromocional] DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED ([Id] ASC)
);

