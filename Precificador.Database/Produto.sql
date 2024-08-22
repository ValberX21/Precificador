CREATE TABLE [dbo].[Produto] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [Nome]             VARCHAR (200)   NOT NULL,
    [Custo]            DECIMAL (18, 2) NOT NULL,
    [Margem]           DECIMAL (18, 2) NOT NULL,
    [PrecoVenda]       DECIMAL (18, 2) NOT NULL,
    [PrecoPromocional] DECIMAL (18, 2) NULL,
    [DataPreco]        DATETIME        CONSTRAINT [DF_Produto_DataPreco] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED ([Id] ASC)
);

