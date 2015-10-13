
IF OBJECT_ID ('dbo.cliente') IS NOT NULL
	DROP TABLE dbo.cliente
GO

CREATE TABLE dbo.cliente
	(
	idcliente      INT IDENTITY NOT NULL,
	nome           VARCHAR (100) NULL,
	cpf_cnpj       VARCHAR (18) NULL,
	endereco       VARCHAR (200) NULL,
	bairro         VARCHAR (40) NULL,
	cidade         VARCHAR (40) NULL,
	cep            VARCHAR (10) NULL,
	email          VARCHAR (50) NULL,
	telefone       VARCHAR (15) NULL,
	status_cliente VARCHAR (20) NULL,
	data_cadastro  DATE NULL,
	CONSTRAINT PK__cliente__7B86132F3C07D8AB PRIMARY KEY (idcliente)
	)
GO


IF OBJECT_ID ('dbo.pedido_cabecalho') IS NOT NULL
	DROP TABLE dbo.pedido_cabecalho
GO

CREATE TABLE dbo.pedido_cabecalho
	(
	idpedido_cabecalho INT IDENTITY NOT NULL,
	idcliente          INT NOT NULL,
	valor_total_pedido DECIMAL (6,2) NULL,
	qtde_itens         INT NULL,
	status_pedido      VARCHAR (20) NULL,
	data_pedido        DATE NULL,
	CONSTRAINT PK__pedido_c__95B64A8C3FD8698F PRIMARY KEY (idpedido_cabecalho),
	FOREIGN KEY (idcliente) REFERENCES dbo.cliente (idcliente)
	)
GO

CREATE NONCLUSTERED INDEX pedido_cabecalho_FKIndex1
	ON dbo.pedido_cabecalho (idcliente)
GO

CREATE NONCLUSTERED INDEX IFK_Rel_Cliente__Ped_Cab
	ON dbo.pedido_cabecalho (idcliente)
GO


IF OBJECT_ID ('dbo.pedido_itens') IS NOT NULL
	DROP TABLE dbo.pedido_itens
GO

CREATE TABLE dbo.pedido_itens
	(
	idpedido_itens     INT IDENTITY NOT NULL,
	idpedido_cabecalho INT NOT NULL,
	idproduto          INT NOT NULL,
	quantidade         INT NULL,
	valor_unitario     DECIMAL (6,2) NULL,
	sub_total          DECIMAL (6,2) NULL,
	status_item        VARCHAR (20) NULL,
	CONSTRAINT PK__pedido_i__C07BC54D449D1EAC PRIMARY KEY (idpedido_itens),
	FOREIGN KEY (idpedido_cabecalho) REFERENCES dbo.pedido_cabecalho (idpedido_cabecalho),
	FOREIGN KEY (idproduto) REFERENCES dbo.produto (idproduto)
	)
GO

CREATE NONCLUSTERED INDEX pedido_itens_FKIndex1
	ON dbo.pedido_itens (idpedido_cabecalho)
GO

CREATE NONCLUSTERED INDEX pedido_itens_FKIndex2
	ON dbo.pedido_itens (idproduto)
GO

CREATE NONCLUSTERED INDEX IFK_Rel_PedCab__Ped_Itens
	ON dbo.pedido_itens (idpedido_cabecalho)
GO

CREATE NONCLUSTERED INDEX IFK_Rel_Produto__Ped_Itens
	ON dbo.pedido_itens (idproduto)
GO


IF OBJECT_ID ('dbo.produto') IS NOT NULL
	DROP TABLE dbo.produto
GO

CREATE TABLE dbo.produto
	(
	idproduto      INT IDENTITY NOT NULL,
	descricao      VARCHAR (100) NULL,
	preco_compra   DECIMAL (6,2) NULL,
	preco_venda    DECIMAL (6,2) NULL,
	qtde_estoque   INT NULL,
	data_cadastro  DATE NULL,
	status_produto VARCHAR (20) NULL,
	CONSTRAINT PK__produto__8D509EBC383747C7 PRIMARY KEY (idproduto)
	)
GO


INSERT INTO dbo.cliente (nome, cpf_cnpj, endereco, bairro, cidade, cep, email, telefone, status_cliente, data_cadastro)
VALUES ('Pedrão ', '397.046.978.6', 'Rua Bogaert, 103', 'Sacoma', 'São Paulo', '08548-9872', 'pedraolara@gmail.com', '11 6987-5050', 'Ativo', '2015-01-01')
GO

INSERT INTO dbo.cliente (nome, cpf_cnpj, endereco, bairro, cidade, cep, email, telefone, status_cliente, data_cadastro)
VALUES ('Maria da Silva', '397.046.978.6', 'Rua Bogaert, 103', 'Sacoma', 'São Paulo', '08548-9872', 'maria@gmail.com', '11 6987-5050', 'Ativo', '2015-01-01')
GO

INSERT INTO dbo.produto (descricao, preco_compra, preco_venda, qtde_estoque, data_cadastro, status_produto)
VALUES ('Camiseta', 80, 100, 50, '2015-05-01', 'Ativo')
GO

INSERT INTO dbo.produto (descricao, preco_compra, preco_venda, qtde_estoque, data_cadastro, status_produto)
VALUES ('Camiseta Okdok', 55, 75, 40, '2015-05-01', 'Ativo')
GO

INSERT INTO dbo.produto (descricao, preco_compra, preco_venda, qtde_estoque, data_cadastro, status_produto)
VALUES ('Camiseta Polo', 75, 130, 60, '2015-05-01', 'Ativo')
GO

INSERT INTO dbo.produto (descricao, preco_compra, preco_venda, qtde_estoque, data_cadastro, status_produto)
VALUES ('Regata Diversas Marcas', 25, 50, 300, '2015-05-01', 'Ativo')
GO

INSERT INTO dbo.produto (descricao, preco_compra, preco_venda, qtde_estoque, data_cadastro, status_produto)
VALUES ('Bermuda Billabong', 90, 170, 60, '2015-05-01', 'Ativo')
GO

INSERT INTO dbo.pedido_cabecalho (idcliente, valor_total_pedido, qtde_itens, status_pedido, data_pedido)
VALUES (1, 150, 2, 'Entregue', '2015-10-01')
GO

INSERT INTO dbo.pedido_cabecalho (idcliente, valor_total_pedido, qtde_itens, status_pedido, data_pedido)
VALUES (2, 400, 50, 'Entregue', '2015-10-01')
GO

INSERT INTO dbo.pedido_itens (idpedido_cabecalho, idproduto, quantidade, valor_unitario, sub_total, status_item)
VALUES (1, 1, 2, 50, 100, 'Entregue')
GO

INSERT INTO dbo.pedido_itens (idpedido_cabecalho, idproduto, quantidade, valor_unitario, sub_total, status_item)
VALUES (2, 3, 5, 120, 600, 'Entregue')
GO







