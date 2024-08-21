CREATE TABLE [dbo].[InsumoProduto] (
    [Id]         INT             NOT NULL,
    [IdProduto]  INT             NOT NULL,
    [IdInsumo]   INT             NOT NULL,
    [Quantidade] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_InsumoProduto] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_InsumoProduto_Insumo] FOREIGN KEY ([IdInsumo]) REFERENCES [dbo].[Insumo] ([Id]),
    CONSTRAINT [FK_InsumoProduto_Produto] FOREIGN KEY ([IdProduto]) REFERENCES [dbo].[Produto] ([Id])
);

