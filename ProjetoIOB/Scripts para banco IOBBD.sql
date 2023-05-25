-- Scripts para criação das tabelas do banco

-- Tabela e Procedures para CONTATO

CREATE TABLE [dbo].[CONTATO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](100) NOT NULL,
	[TELEFONE] [varchar](50) NOT NULL,
	[TELEFONE_AUX] [varchar](50) NOT NULL,
	[EMAIL] [varchar](100) NOT NULL,
	[DATA_NASCIMENTO] [date] NOT NULL,
	[CEP] [int] NOT NULL,
	[RUA] [varchar](50) NOT NULL,
	[NUMERO] [int] NOT NULL,
	[COMPLEMENTO] [varchar](200),
	[BAIRRO] [varchar](50) NOT NULL,
	[CIDADE] [varchar](50) NOT NULL,
	[ESTADO] [varchar](50) NOT NULL
) ON [PRIMARY]
GO

-- Procedure de consulta de lista de contatos

CREATE PROCEDURE sp_viewAllContato
AS
BEGIN
SELECT ID, NOME, TELEFONE, TELEFONE_AUX, EMAIL, DATA_NASCIMENTO, CEP, RUA, NUMERO,
COMPLEMENTO, BAIRRO, CIDADE, ESTADO
FROM CONTATO 
ORDER BY NOME
END

-- Procedure de busca de contatos por ID

CREATE PROCEDURE sp_viewContatoById (@id int)
AS
BEGIN
SELECT * FROM CONTATO WHERE ID = @id
END

-- Procedure para deletar Contato 

CREATE PROCEDURE sp_deleteContato (@id int)
AS
BEGIN
DELETE FROM CONTATO WHERE ID = @id
END

-- Procedure para cadastrar e atualizar contatos

CREATE PROCEDURE sp_insertupdate_contato (
@id int, 
@nome varchar(100),
@telefone varchar(50),
@telefone_aux varchar(50),
@email varchar(100),
@data_nascimento date,
@rua varchar(50),
@numero int,
@complemento varchar(200),
@bairro varchar(50),
@cidade varchar(50),
@estado varchar(50),
@idout int out
)
AS
BEGIN
	IF(@id=0)
	 BEGIN
	 INSERT INTO CONTATO(NOME, TELEFONE, TELEFONE_AUX, EMAIL, DATA_NASCIMENTO, CEP, RUA, NUMERO,
	 COMPLEMENTO, BAIRRO, CIDADE, ESTADO) VALUES (@nome, @telefone, @telefone_aux, @email, @data_nascimento,
	 @cep, @rua, @numero, @complemento, @bairro, @cidade, @estado)
	 SET @idout=@@IDENTITY
	 END
	  ELSE
	  BEGIN
	  UPDATE CONTATO SET NOME=@nome, TELEFONE=@telefone, TELEFONE_AUX=@telefone_aux, 
	  EMAIL=@email, DATA_NASCIMENTO=@data_nascimento, CEP=@cep, RUA=@rua, NUMERO=@numero, 
	  COMPLEMENTO=@complemento, BAIRRO=@bairro, CIDADE=@cidade, ESTADO=@estado
	  WHERE ID=@id
	  SET @id=@idout
	  END
END

-- Tabela e Procedures para EVENTO

CREATE TABLE [dbo].[EVENTO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](50) NOT NULL,
	[DATA] [datetime] NOT NULL,
	[DESCRICAO] [varchar](200) NOT NULL
) ON [PRIMARY]
GO

-- Procedure de consulta de lista de eventos

CREATE PROCEDURE sp_viewAllEvento
AS
BEGIN
SELECT ID, NOME, DATA, DESCRICAO
FROM EVENTO
ORDER BY DATA
END

-- Procedure de busca de eventos por ID

CREATE PROCEDURE sp_viewEventoById (@id int)
AS
BEGIN
SELECT * FROM EVENTO WHERE ID = @id
END

-- Procedure para deletar Evento

CREATE PROCEDURE sp_deleteEvento (@id int)
AS
BEGIN
DELETE FROM EVENTO WHERE ID = @id
END

-- Procedure para cadastrar e atualizar contatos

CREATE PROCEDURE sp_insertupdate_evento (
@id int, 
@nome varchar(100),
@data datetime,
@descricao varchar(200),
@idout int out
)
AS
BEGIN
	IF(@id=0)
	 BEGIN
	 INSERT INTO EVENTO(NOME, DATA, DESCRICAO) VALUES (@nome, @data, @descricao)
	 SET @idout=@@IDENTITY
	 END
	  ELSE
	  BEGIN
	  UPDATE EVENTO SET NOME=@nome, DATA=@data, DESCRICAO=@descricao
	  WHERE ID=@id
	  SET @id=@idout
	  END
END