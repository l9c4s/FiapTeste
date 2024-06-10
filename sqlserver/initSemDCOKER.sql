USE master;


-- Create the FiapTest database
IF DB_ID('FiapTest') IS NULL
BEGIN
    CREATE DATABASE FiapTest;
END


USE FiapTest;


-- Create CURSO table
IF OBJECT_ID('dbo.CURSO', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.CURSO (
        id int IDENTITY(1,1) NOT NULL,
        nome varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
        CONSTRAINT PK__CURSO__3213E83F8CC44028 PRIMARY KEY (id)
    );
END


-- Create ALUNO table
IF OBJECT_ID('dbo.ALUNO', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.ALUNO (
        id int IDENTITY(1,1) NOT NULL,
        nome varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
        usuario varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        senha char(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        Ativo int DEFAULT 1 NULL,
        CONSTRAINT PK__ALUNO__3213E83F10825ACE PRIMARY KEY (id)
    );
END


-- Create TURMA table
IF OBJECT_ID('dbo.TURMA', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.TURMA (
        id int IDENTITY(1,1) NOT NULL,
        curso_id int NULL,
        turma varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        ano char(60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        Ativo int DEFAULT 1 NULL,
        CONSTRAINT PK__TURMA__3213E83FD922C0C3 PRIMARY KEY (id),
        CONSTRAINT FK__TURMA__curso_id__2A164134 FOREIGN KEY (curso_id) REFERENCES dbo.CURSO(id)
    );
END


-- Create ALUNO_TURMA table
IF OBJECT_ID('dbo.ALUNO_TURMA', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.ALUNO_TURMA (
        aluno_id int NULL,
        turma_id int NULL,
        ativo int DEFAULT 1 NOT NULL,
        CONSTRAINT FK__ALUNO_TUR__aluno__2CF2ADDF FOREIGN KEY (aluno_id) REFERENCES dbo.ALUNO(id),
        CONSTRAINT FK__ALUNO_TUR__turma__2DE6D218 FOREIGN KEY (turma_id) REFERENCES dbo.TURMA(id)
    );
END


INSERT INTO FiapTest.dbo.CURSO
(nome)
VALUES('Medicina'),
('Ciencia Da computação'),
('Redes de tecnlogia'),
('Direito');


INSERT INTO FiapTest.dbo.TURMA
(curso_id, turma, ano)
VALUES(1, 'Medicina 1', CONVERT(VARCHAR, GETDATE(), 20)),
	  (1, 'Medicina 2', CONVERT(VARCHAR, GETDATE(), 20)),
	  (1, 'Medicina 3', CONVERT(VARCHAR, GETDATE(), 20));

	 
INSERT INTO FiapTest.dbo.ALUNO
( nome, usuario, senha)
VALUES('Lucas Carvalho', 'LCS.NET', 'TESTE'),
('Romulo', 'RO.PHP', 'TESTE'),
('Mexicano', 'MEXI.SQL', 'TESTE');


INSERT INTO FiapTest.dbo.ALUNO_TURMA
(aluno_id, turma_id)
VALUES(1, 1),
(2, 1),
(3, 1);
G
