drop table menu;
drop table skabelon;
go;
create table skabelon
(
id int identity primary key not null,
filename varchar(50) not null
);

create table menu
(
id int identity primary key not null,
text_dk text,
text_en text,
page_type int foreign key references skabelon(id),
level int,
sort int,
parent int foreign key references menu(id)
);

create table users
(
id int identity primary key,
username varchar(128) not null,
password varchar(128) not null,
userlevel int not null
);

create table tekst
(
id int identity primary key,
text_dk text,
text_en text,
side_id int foreign key references menu(id)
);

create table nyhed
(
id int identity primary key,
headline_dk varchar(255),
text_dk text,
headline_en varchar(255),
text_en text,
created date,
shown bit
);

insert into tekst values('test tekst er bedst tekst', '', 4);
insert into tekst values('Se mor, jeg kom på forsiden', '', 1);
insert into tekst values('Endnu en nyhed er ny','', 1);
insert into tekst values('Gammel nyhed er gammel','', 1);

insert into users values('tara', 'pinkiepie', 1)

update tekst set text_dk = 'test tekst er bedst tekst' where side_id = 4;

select * from tekst;

insert into skabelon values('Forside.aspx');
insert into skabelon values('Tekstside.aspx');
insert into skabelon values('Formularside.aspx');
insert into skabelon values('Resultatside.aspx');

insert into menu values('søg', 'search', 3, 0, 1, null);
insert into menu values('info', 'info', 2, 0, 2, null);
insert into menu values('kontakt', 'contact', 2, 0, 3, null);
insert into menu values('betingelser', 'requirements', 2, 1, 1, 2);
insert into menu values('FAQ', 'FAQ', 2, 1, 2, 2);
insert into menu values('Dispensation', 'Dispensation', 2, 1, 3, 2);