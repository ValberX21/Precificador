CREATE TABLE [dbo].[InsumoProduto] (
    [Id]          INT             NOT NULL IDENTITY(1, 1),
    [IdProduto]   INT             NOT NULL,
    [IdInsumo]    INT             NOT NULL,
    [Quantidade]  DECIMAL (18, 2) NOT NULL,
    [PrecoInsumo] DECIMAL (18, 2) NOT NULL,
    [TotalInsumo] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_InsumoProduto] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_InsumoProduto_Insumo] FOREIGN KEY ([IdInsumo]) REFERENCES [dbo].[Insumo] ([Id]),
    CONSTRAINT [FK_InsumoProduto_Produto] FOREIGN KEY ([IdProduto]) REFERENCES [dbo].[Produto] ([Id])
);

