INSERT INTO [dbo].[TipoInsumo] ([Nome]) VALUES ('Desgaste'), ('Embalagem'), ('Fios'), ('OffSet 75g'), ('Papel Kraft');

INSERT INTO [dbo].[UnidadeMedida] ([Nome]) VALUES ('Unidade'), ('Metro'), ('Folha A5');

INSERT INTO [dbo].[Insumo]	([IdTipoInsumo],	[Nome],							[PrecoPacote],	[QuantidadePacote], [IdUnidadeMedida],	[PrecoUnidade])
     VALUES					(1,					'Desgaste Bloquinho/Outros',	0.5,			1,					1,					0.5),
							(2,					'Embalagem Padrão',				1.5,			1,					1,					1.5),
							(3,					'Cordão Encerado Settanyl',		15.9,			100,				2,					0.16),
							(4,					'Sulfite 75g A5',				30.9,			1000,				3,					0.03),
							(5,					'Papel Kraft A5',				16.1,			60,					3,					0.27),
							(3,					'Linha Circulo Maxi Mouline',	1.4,			8,					2,					0.18);

INSERT INTO [dbo].[Produto] ([Nome], [Custo], [Margem], [PrecoVenda]) VALUES ('Caderno Kraft A6 bordado', 3.48, 0.55, 15);

INSERT INTO [dbo].[InsumoProduto]	([IdProduto],	[IdInsumo],	[Quantidade],	[PrecoInsumo],	[TotalInsumo])
     VALUES							(1,				5,			1,				0.27,			0.27),
									(1,				4,			25,				0.03,			0.75),
									(1,				3,			0.6,			0.16,			0.10),
									(1,				6,			2,				0.18,			0.36),
									(1,				1,			1,				0.5,			0.5),
									(1,				2,			1,				1.5,			1.5);

INSERT INTO [dbo].[Colecao] ([Nome], [DataLancamento]) VALUES ('Kraft', '2023-04-01');

INSERT INTO [dbo].[ProdutoColecao] ([IdColecao], [IdProduto]) VALUES (1, 1);