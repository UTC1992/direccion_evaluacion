insert into Usuarios (nombre, email, password, estado, perfil) values ('admin', 'admin@gmail.com', '123456', 1,1);
update Usuarios set Perfil_id = 1 where id = 1;
select * from Usuarios;

insert into Perfils(nombre) values ('Administrador');
insert into Perfils(nombre) values ('Coordinador');
insert into Perfils(nombre) values ('Docente');

select * from Perfils;