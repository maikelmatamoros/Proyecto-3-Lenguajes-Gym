--CREATE DATABASE IF4101Proyecto3AM

use IF4101Proyecto3AM

CREATE TABLE tb_centro_entrenamiento(
	centro_id int identity primary key,
	centro_accessName varchar(50) unique,
	centro_accessPassword varchar(30) not null,
	centro_nombre varchar(100) not null, 
	centro_descripcion varchar(300) not null,
	centro_ubicacion varchar(200) not null, 
	centro_telefono varchar(20) not null, 
	centro_correo_electronico varchar(40) not null,
	centro_capacidad_maxima int not null, 
	centro_porcentaje_permitido int not null,
	centro_hora_apertura datetime not null,
	centro_hora_cierre datetime not null,
	centro_logo_ruta varchar(200) not null
)



create table centro_usuario(
	centro_id int primary key,
	centro_usuario varchar(30),
	foreign key(centro_id) references tb_centro_entrenamiento(centro_id),
	foreign key(centro_usuario) references tb_usuario(	usuario_userName )
)

insert into centro_usuario values(1,'DGCR')


select * from tb_usuario


exec sp_loginToCentro 1,'DGCR','123'

drop procedure sp_loginToCentro

CREATE PROCEDURE sp_loginToCentro(@id int, @usuario varchar(30),@pass varchar(30))
as
Select 'S' as Estado from centro_usuario CU join tb_usuario U on CU.centro_usuario=U.usuario_userName where CU.centro_id=@id and CU.centro_usuario=@usuario and U.usuario_password=@pass


exec sp_obtenerGymVistas

create procedure sp_obtenerGymVistas
as
Select centro_id,centro_logo_ruta,centro_nombre,centro_ubicacion from tb_centro_entrenamiento;


CREATE TABLE tb_centro_fotografias(
	centro_id int not null,
	centro_fotografia_ruta varchar(200) not null,
	foreign key(centro_id) references tb_centro_entrenamiento(centro_id)
)


CREATE TABLE tb_clase_virtual(
	clase_id int identity primary key not null,
	clase_hora_inicio datetime not null,
	clase_hora_fin datetime not null,
	clase_fecha date not null,
	clase_nombre varchar(100) not null,
	clase_descripcion varchar(300) not null,
	clase_centroId int not null,
	foreign key(clase_centroId) references tb_centro_entrenamiento(centro_id)
)




CREATE TABLE tb_control(
	control_hora_id int identity primary key not null,
	control_centro_id int not null,
	control_capacidad int not null,
	control_hora_bloque_inicio datetime not null,
	control_hora_bloque_final datetime not null,
	control_hora_dia date not null,
	foreign key (control_centro_id) references tb_centro_entrenamiento(centro_id)
)




create table tb_usuario(
	usuario_userName varchar(30) primary key not null,
	usuario_password varchar(30) not null,
	usuario_nombre varchar(30) not null,
	usuario_apellidos varchar(60) not null,
	usuario_cedula varchar(15) unique not null
)

insert into tb_usuario values('ArCR','123','Arturo','Campos','2-222-222')

create procedure sp_getUsers
as
select * from tb_usuario;



declare @aux int=0;
declare @

while @aux<



select DATEPART(week,GETDATE())

select "start_of_week" = dateadd(week, datediff(week, 0, getdate()), 0);

