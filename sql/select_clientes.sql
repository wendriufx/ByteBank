﻿CREATE TABLE [dbo].[Clientes]
(
	[IDCliente] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
    [Nome] VARCHAR (50) NOT NULL,
	[Telefone] VARCHAR (50) NOT NULL,
	[CPF] VARCHAR (50) NOT NULL,
)
