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
insert into tekst values('test tekst er bedst tekst', '', 2);
insert into tekst values('test tekst er bedst tekst', '', 3);
insert into tekst values('test tekst er bedst tekst', '', 4);
insert into tekst values('test tekst er bedst tekst', '', 5);
insert into tekst values('test tekst er bedst tekst', '', 6);
update tekst set text_dk = 'test tekst er bedst tekst' where id=2;

insert into users values('tara', 'pinkiepie', 1)

select * from tekst;

insert into skabelon values('Forside.aspx');
insert into skabelon values('Tekstside.aspx');
insert into skabelon values('Formularside.aspx');
insert into skabelon values('Resultatside.aspx');

insert into menu values('s�g', 'search', 3, 0, 1, null);
insert into menu values('info', 'info', 2, 0, 2, null);
insert into menu values('kontakt', 'contact', 2, 0, 3, null);
insert into menu values('betingelser', 'requirements', 2, 1, 1, 2);
insert into menu values('FAQ', 'FAQ', 2, 1, 2, 2);
insert into menu values('Dispensation', 'Dispensation', 2, 1, 3, 2);