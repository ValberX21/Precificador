CREATE TABLE [dbo].[ProdutoColecao] (
    [Id]        INT NOT NULL IDENTITY(1, 1),
    [IdColecao] INT NOT NULL,
    [IdProduto] INT NOT NULL,
    CONSTRAINT [PK_ProdutoColecao] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProdutoColecao_Colecao] FOREIGN KEY ([IdColecao]) REFERENCES [dbo].[Colecao] ([Id]),
    CONSTRAINT [FK_ProdutoColecao_Produto] FOREIGN KEY ([IdProduto]) REFERENCES [dbo].[Produto] ([Id])
);

