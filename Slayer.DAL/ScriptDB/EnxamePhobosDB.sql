CREATE DATABASE EnxamePhobosDB;
USE EnxamePhobosDB;

CREATE TABLE TipoUsuario(
IdTipoUsuario INT PRIMARY KEY IDENTITY (1,1),
DescricaoTipoUsuario VARCHAR(150) NOT NULL
);

INSERT INTO TipoUsuario (DescricaoTipoUsuario)
VALUES ('Administrador'),('Outros');

SELECT * FROM TipoUsuario;
UPDATE TipoUsuario SET DescricaoTipoUsuario = 'Administrador'
WHERE IdTipoUsuario = 1;

CREATE TABLE Usuario(
IdUsuario INT PRIMARY KEY IDENTITY (1,1),
NomeUsuario VARCHAR(150) NOT NULL,
EmailUsuario VARCHAR(150) NOT NULL,
SenhaUsuario CHAR(6) NOT NULL,
DtNascUsuario DATE NOT NULL,
UsuarioTp INT NOT NULL,

FOREIGN KEY (UsuarioTp) REFERENCES TipoUsuario (IdTipoUsuario)

);

/*CRUD Usuario*/
/*CREATE*/
INSERT INTO Usuario (NomeUsuario,EmailUsuario,SenhaUsuario,DtNascUsuario,UsuarioTp) 
VALUES ('Juia','juia@email.com','jui123','2006-10-03',1),
('Momo','momo@email.com','mom123','2001-09-11',1),
('Geovana','geovana@email.com','geo123','2006-10-15',2),
('Atlas','atlas@email.com','atl123','2001-07-28',2),
('Minzon','minzon@email.com','min123','2006-08-10',2);

/*READ*/
SELECT IdUsuario,NomeUsuario, EmailUsuario,SenhaUsuario,DtNascUsuario,DescricaoTipoUsuario
FROM Usuario INNER JOIN TipoUsuario ON UsuarioTp = IdTipoUsuario;


/*UPDATE*/
UPDATE Usuario SET NomeUsuario = '@NomeUsuario',EmailUsuario = '@EmailUsuario',SenhaUsuario = '@SenhaUsuario',
DtNascUsuario = '@DtNascUsuario',UsuarioTp = '@UsuarioTp' WHERE IdUsuario = '@IdUsuario';

/*DELETE*/
DELETE FROM Usuario WHERE IdUsuario = '@IdUsuario';

/*AUTENTICACAO*/
SELECT * FROM Usuario WHERE NomeUsuario = 'juia' AND SenhaUsuario='jui231';

/*SEARCHBYID*/
SELECT * FROM Usuario WHERE IdUsuario =  '@IdUsuario';




SELECT * FROM Usuario;



CREATE TABLE Genero(
IdGenero INT PRIMARY KEY IDENTITY (1,1),
DescricaoGenero VARCHAR(150) NOT NULL
);

INSERT INTO Genero (DescricaoGenero)
VALUES ('Terror'),('Porno'),('Suspense'),('Romance'),('Gore');

SELECT * FROM Genero;


CREATE TABLE Classificacao(
IdClassificacao INT PRIMARY KEY IDENTITY (1,1),
DescricaoClassificacao VARCHAR(150) NOT NULL
);

INSERT INTO Classificacao (DescricaoClassificacao)
VALUES ('+18'),('kids'),('livre');

SELECT * FROM Classificacao;


CREATE TABLE Filme(
IdFilme INT PRIMARY KEY IDENTITY (1,1),
TituloFilme VARCHAR(150) NOT NULL,
ProdutoraFilme VARCHAR(150) NOT NULL,
UrlFilme VARCHAR (MAX) NOT NULL,

GeneroId INT NOT NULL,
ClassificacaoId INT NOT NULL,

FOREIGN KEY (GeneroId) REFERENCES Genero (IdGenero),
FOREIGN KEY (ClassificacaoId) REFERENCES Classificacao (IdClassificacao)

);

INSERT INTO Filme (TituloFilme,ProdutoraFilme,UrlFilme,GeneroId,ClassificacaoId) 
VALUES ('Depravados do mal','mondo bizarro','~/img/depravados.jpg',1,1),
('Demonios do fim do mundo','twisted','~/img/demonios.jpg',1,1),
('As primas do interior','imperio','~/img/primas.jpg',2,1),
('Estranhos desejos','angel','~/img/estranhos.jpg',2,1),
('Mais que amigo','cherolayne','~/img/mais.jpg',4,3),
('A lagoa vermelha','mistura','~/img/lagoa.jpg',4,3),
('Dominados','mondo bizarro','~/img/dominados.jpg',3,1),
('O grande lixo','mondo bizarro','~/img/mondo.jpg',3,2),
('Restos de nada','impact blood','~/img/restos.jpg',5,1),
('Pombal de vermes','twisted','~/img/pombal.jpg',5,1)

SELECT * FROM Filme;


/*CRUD Filme*/

/*READ*/
SELECT TituloFilme,ProdutoraFilme,UrlFilme,DescricaoGenero, DescricaoClassificacao
FROM Filme INNER JOIN Genero ON GeneroId = IdGenero INNER JOIN Classificacao ON 
ClassificacaoId = IdClassificacao;

/*FILTER*/
SELECT * FROM Filme WHERE GeneroId = 1;

SELECT TituloFilme,ProdutoraFilme,UrlFilme,DescricaoGenero, DescricaoClassificacao
FROM Filme INNER JOIN Genero ON GeneroId = IdGenero INNER JOIN Classificacao ON 
ClassificacaoId = IdClassificacao WHERE GeneroId = 1;
