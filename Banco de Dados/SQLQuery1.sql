create table PP2_Usuario
(
	id int identity(1,1) primary key not null,
	nomeUsuario varchar(30) not null,
	email varchar(50) not null,
	senha varchar(10) not null,
	pontuacao int,
	imgPerfil varchar(max)
)

create table PP2_Acesso
(
	id int identity(1,1) primary key not null,
	data datetime not null,
	codUsuario int not null 
	constraint fkPP2_Usuario foreign key (codUsuario) references PP2_Usuario(id) 
)

create table PP2_Quiz
(
	codQuiz int primary key not null,
	pergunta nText not null,
	resposta nText not null,
	opcaoA nText,
	opcaoB nText,
	opcaoC nText,
	opcaoD nText,
	opcaoE nText
)

create table PP2_Forum
(
	codPergunta int identity primary key not null,
	titulo nText not null,
	descricao nText not null,
	codUsuario int not null
	constraint fkPP2_Usuario_2 foreign key (codUsuario) references PP2_Usuario(codUsuario)
)

create table PP2_Respostas
(
	codResposta int identity primary  key not null,
	codPergunta int not null
	constraint fkPP2_Forum foreign key (codPergunta) references PP2_Forum(codPergunta),
	codUsuario int not null
	constraint fkPP2_Usuario_3 foreign key (codUsuario) references PP2_Usuario(codUsuario),
	reposta nText not null
)

create table PP2_Grafico
(
   codGrafico int primary key not null,
   titulo nText not null,
   descricao nText not null,
   img varchar(max) not null
)

create table PP2_EducacaoSexual
(
   codTema int primary key not null,
   nomTema nText not null,
   descricao nText not null,
   imgTema varchar(max) not null
)

create table PP2_Doenca
(
   id int primary key not null,
   titulo varchar(30),
   texto nText not null,
   codImagem int not null
   constraint fkPP2_Imagem foreign key (codImagem) references PP2_Imagem(id)
)

create table PP2_MetodoPrevencao
(
   id int primary key not null,
   titulo varchar(30),
   texto nText not null,
   codImagem int not null
   constraint fkPP2_Imagem4 foreign key (codImagem) references PP2_Imagem(id)
)

create table PP2_HIV
(
   id int primary key not null,
   titulo varchar(30),
   texto nText not null,
   codImagem int not null
   constraint fkPP2_Imagem5 foreign key (codImagem) references PP2_Imagem(id)
)

create table PP2_Corpo
(
   id int primary key not null,
   titulo varchar(30),
   texto nText not null,
   codImagem int not null
   constraint fkPP2_Imagem2 foreign key (codImagem) references PP2_Imagem(id)
)


create table PP2_Gravidez
(
   id int primary key not null,
   titulo varchar(30),
   texto nText not null,
   codImagem int not null
   constraint fkPP2_Imagem3 foreign key (codImagem) references PP2_Imagem(id)
)


create table PP2_Mito
(
   codMito int primary key not null,
   titulo nText not null,
   verdade nText not null,
   mentira nText not null
)

create table PP2_Imagem
(
	id int primary key not null,
	link varchar(max) not null
)
drop table PP2_Imagem

select * from PP2_Imagem

insert into PP2_Imagem values (1, '../img/imgHIV.png')
insert into PP2_Imagem values (2, '../img/imgIST.png')
insert into PP2_Imagem values (3, '../img/imgPrev.png')
insert into PP2_Imagem values (4, '../img/imgGravidez.png')
insert into PP2_Imagem values (5, '../img/imgCorpo.png')
