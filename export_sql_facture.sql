CREATE TABLE [dbo].[Categorie] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Nom]      NVARCHAR (50) NOT NULL,
    [estactif] BIT           DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Nom] ASC)
);


CREATE TABLE [dbo].[Article] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Nom]         NVARCHAR (255)  NOT NULL,
    [Designation] NVARCHAR (255)  NULL,
    [Prix]        DECIMAL (18, 2) NOT NULL,
    [CategorieId] INT             NULL,
    CONSTRAINT [PK_ARTICLE] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Article_Categorie] FOREIGN KEY ([CategorieId]) REFERENCES [dbo].[Categorie] ([Id])
);

CREATE TABLE [dbo].[Client] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Nom]      NVARCHAR (50) NOT NULL,
    [Prenom]   NVARCHAR (50) NOT NULL,
    [Adresse]  NVARCHAR (50) NOT NULL,
    [npa]      NVARCHAR (50) NOT NULL,
    [localite] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_CLIENT] PRIMARY KEY CLUSTERED ([Id] ASC)
);



CREATE TABLE [dbo].[Facture] (
    [Id]          INT      IDENTITY (1, 1) NOT NULL,
    [DateFacture] DATETIME NOT NULL,
    [ClientId]    INT      NOT NULL,
    CONSTRAINT [PK_FACTURE] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Facture_fk0] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id]) ON UPDATE CASCADE
);


CREATE TABLE [dbo].[LigneFacture] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [FactureId]    INT             NOT NULL,
    [ArticleId]    INT             NOT NULL,
    [Quantite]     INT             NOT NULL,
    [PrixUnitaire] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_LigneFacture] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [LigneFacture_fk0] FOREIGN KEY ([FactureId]) REFERENCES [dbo].[Facture] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [LigneFacture_fk1] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Article] ([Id]) ON UPDATE CASCADE
);

CREATE TABLE [dbo].[Utilisateur] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Nom]        NVARCHAR (50)  NOT NULL,
    [Login]      NVARCHAR (50)  NOT NULL,
    [MotDePasse] NVARCHAR (255) NOT NULL,
    [Role]       NVARCHAR (50)  NOT NULL,
    [EstActif]   BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


SET IDENTITY_INSERT [dbo].[Categorie] ON
INSERT INTO [dbo].[Categorie] ([Id], [Nom], [estactif]) VALUES (1, N'Développementx', 1)
INSERT INTO [dbo].[Categorie] ([Id], [Nom], [estactif]) VALUES (27, N'santé', 1)
INSERT INTO [dbo].[Categorie] ([Id], [Nom], [estactif]) VALUES (28, N'sport', 1)
INSERT INTO [dbo].[Categorie] ([Id], [Nom], [estactif]) VALUES (29, N'voyage', 1)
INSERT INTO [dbo].[Categorie] ([Id], [Nom], [estactif]) VALUES (38, N'asdf', 1)
INSERT INTO [dbo].[Categorie] ([Id], [Nom], [estactif]) VALUES (39, N'jeux vidéo', 1)
INSERT INTO [dbo].[Categorie] ([Id], [Nom], [estactif]) VALUES (40, N'wer', 1)
INSERT INTO [dbo].[Categorie] ([Id], [Nom], [estactif]) VALUES (42, N'ysadf', 1)
INSERT INTO [dbo].[Categorie] ([Id], [Nom], [estactif]) VALUES (43, N'asdfdd', 0)
INSERT INTO [dbo].[Categorie] ([Id], [Nom], [estactif]) VALUES (44, N'asdfsadfsdfsdf', 0)
INSERT INTO [dbo].[Categorie] ([Id], [Nom], [estactif]) VALUES (45, N'asdfsadfasdfsdfsadfsadf', 1)
INSERT INTO [dbo].[Categorie] ([Id], [Nom], [estactif]) VALUES (46, N'ssdfsdf', 1)
INSERT INTO [dbo].[Categorie] ([Id], [Nom], [estactif]) VALUES (47, N'asfgggsadfsdfsdfsadf', 0)
INSERT INTO [dbo].[Categorie] ([Id], [Nom], [estactif]) VALUES (48, N'sadfqwergqweqwer', 0)
INSERT INTO [dbo].[Categorie] ([Id], [Nom], [estactif]) VALUES (49, N'aDFSafsdasdf', 0)
INSERT INTO [dbo].[Categorie] ([Id], [Nom], [estactif]) VALUES (50, N'qfqwefwqefwef', 0)
INSERT INTO [dbo].[Categorie] ([Id], [Nom], [estactif]) VALUES (51, N'asdfsadfasdf', 0)
INSERT INTO [dbo].[Categorie] ([Id], [Nom], [estactif]) VALUES (52, N'asdfsdfsdfsadf', 0)
INSERT INTO [dbo].[Categorie] ([Id], [Nom], [estactif]) VALUES (53, N'asdfasdfsadf', 0)
INSERT INTO [dbo].[Categorie] ([Id], [Nom], [estactif]) VALUES (54, N'mardi soir', 1)
SET IDENTITY_INSERT [dbo].[Categorie] OFF



SET IDENTITY_INSERT [dbo].[Article] ON
INSERT INTO [dbo].[Article] ([Id], [Nom], [Designation], [Prix], [CategorieId]) VALUES (1, N'DDR3 8GB', N'', CAST(56.95 AS Decimal(18, 2)), 1)
INSERT INTO [dbo].[Article] ([Id], [Nom], [Designation], [Prix], [CategorieId]) VALUES (2, N'a', NULL, CAST(2.00 AS Decimal(18, 2)), 27)
INSERT INTO [dbo].[Article] ([Id], [Nom], [Designation], [Prix], [CategorieId]) VALUES (3, N'Bonne soirée', N'un super cpu', CAST(2.00 AS Decimal(18, 2)), 28)
INSERT INTO [dbo].[Article] ([Id], [Nom], [Designation], [Prix], [CategorieId]) VALUES (4, N'un nouvel article', N'cela est mon nouvel article', CAST(12.50 AS Decimal(18, 2)), 28)
INSERT INTO [dbo].[Article] ([Id], [Nom], [Designation], [Prix], [CategorieId]) VALUES (5, N'un autre article', N'', CAST(212.50 AS Decimal(18, 2)), NULL)
SET IDENTITY_INSERT [dbo].[Article] OFF


SET IDENTITY_INSERT [dbo].[Client] ON
INSERT INTO [dbo].[Client] ([Id], [Nom], [Prenom], [Adresse], [npa], [localite]) VALUES (1, N'Collet', N'yves', N'rue de', N'1020', N'lajsdf')
INSERT INTO [dbo].[Client] ([Id], [Nom], [Prenom], [Adresse], [npa], [localite]) VALUES (2, N'bolomey', N'vincent', N'rue de la tour', N'1005', N'lausanne')
SET IDENTITY_INSERT [dbo].[Client] OFF


SET IDENTITY_INSERT [dbo].[Facture] ON
INSERT INTO [dbo].[Facture] ([Id], [DateFacture], [ClientId]) VALUES (1, N'2023-03-13 18:52:52', 1)
INSERT INTO [dbo].[Facture] ([Id], [DateFacture], [ClientId]) VALUES (2, N'2023-03-13 18:54:25', 1)
INSERT INTO [dbo].[Facture] ([Id], [DateFacture], [ClientId]) VALUES (3, N'2023-04-11 20:37:07', 1)
INSERT INTO [dbo].[Facture] ([Id], [DateFacture], [ClientId]) VALUES (4, N'2023-04-11 20:38:33', 1)
INSERT INTO [dbo].[Facture] ([Id], [DateFacture], [ClientId]) VALUES (5, N'2023-04-24 18:45:06', 1)
INSERT INTO [dbo].[Facture] ([Id], [DateFacture], [ClientId]) VALUES (7, N'2023-06-11 00:00:00', 1)
INSERT INTO [dbo].[Facture] ([Id], [DateFacture], [ClientId]) VALUES (8, N'2023-06-01 00:00:00', 2)
INSERT INTO [dbo].[Facture] ([Id], [DateFacture], [ClientId]) VALUES (11, N'2023-06-12 00:00:00', 1)
INSERT INTO [dbo].[Facture] ([Id], [DateFacture], [ClientId]) VALUES (12, N'2023-06-12 00:00:00', 1)
INSERT INTO [dbo].[Facture] ([Id], [DateFacture], [ClientId]) VALUES (13, N'2023-06-01 00:00:00', 2)
SET IDENTITY_INSERT [dbo].[Facture] OFF


SET IDENTITY_INSERT [dbo].[LigneFacture] ON
INSERT INTO [dbo].[LigneFacture] ([Id], [FactureId], [ArticleId], [Quantite], [PrixUnitaire]) VALUES (1, 1, 1, 2, CAST(12.50 AS Decimal(18, 2)))
INSERT INTO [dbo].[LigneFacture] ([Id], [FactureId], [ArticleId], [Quantite], [PrixUnitaire]) VALUES (2, 1, 3, 4, CAST(54.95 AS Decimal(18, 2)))
INSERT INTO [dbo].[LigneFacture] ([Id], [FactureId], [ArticleId], [Quantite], [PrixUnitaire]) VALUES (3, 1, 5, 2, CAST(58.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[LigneFacture] ([Id], [FactureId], [ArticleId], [Quantite], [PrixUnitaire]) VALUES (4, 7, 4, 2, CAST(0.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[LigneFacture] ([Id], [FactureId], [ArticleId], [Quantite], [PrixUnitaire]) VALUES (5, 7, 2, 3, CAST(0.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[LigneFacture] ([Id], [FactureId], [ArticleId], [Quantite], [PrixUnitaire]) VALUES (6, 8, 2, 5, CAST(2.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[LigneFacture] ([Id], [FactureId], [ArticleId], [Quantite], [PrixUnitaire]) VALUES (7, 8, 4, 6, CAST(12.50 AS Decimal(18, 2)))
INSERT INTO [dbo].[LigneFacture] ([Id], [FactureId], [ArticleId], [Quantite], [PrixUnitaire]) VALUES (8, 11, 3, 2, CAST(2.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[LigneFacture] ([Id], [FactureId], [ArticleId], [Quantite], [PrixUnitaire]) VALUES (9, 11, 1, 1, CAST(56.95 AS Decimal(18, 2)))
INSERT INTO [dbo].[LigneFacture] ([Id], [FactureId], [ArticleId], [Quantite], [PrixUnitaire]) VALUES (10, 12, 2, 1, CAST(2.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[LigneFacture] ([Id], [FactureId], [ArticleId], [Quantite], [PrixUnitaire]) VALUES (11, 12, 3, 1, CAST(2.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[LigneFacture] ([Id], [FactureId], [ArticleId], [Quantite], [PrixUnitaire]) VALUES (12, 13, 2, 3, CAST(2.50 AS Decimal(18, 2)))
INSERT INTO [dbo].[LigneFacture] ([Id], [FactureId], [ArticleId], [Quantite], [PrixUnitaire]) VALUES (13, 13, 4, 5, CAST(12.50 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[LigneFacture] OFF


SET IDENTITY_INSERT [dbo].[Utilisateur] ON
INSERT INTO [dbo].[Utilisateur] ([Id], [Nom], [Login], [MotDePasse], [Role], [EstActif]) VALUES (1, N'Yves', N'yves', N'1CF64FD4B7038E114D4CA35DFAB1564CB3B9EA0C9A96717B78C8D4ED3C4D8D3D:9546D7934C4C6E3A13DAF1332E3C6495:50000:SHA256', N'admin', 1)
INSERT INTO [dbo].[Utilisateur] ([Id], [Nom], [Login], [MotDePasse], [Role], [EstActif]) VALUES (2, N'Luis', N'luis', N'1CF64FD4B7038E114D4CA35DFAB1564CB3B9EA0C9A96717B78C8D4ED3C4D8D3D:9546D7934C4C6E3A13DAF1332E3C6495:50000:SHA256', N'user', 1)
SET IDENTITY_INSERT [dbo].[Utilisateur] OFF
