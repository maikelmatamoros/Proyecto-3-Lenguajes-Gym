--CREATE DATABASE IF4101Proyecto3AM

use IF4101Proyecto3AM

CREATE TABLE tb_centro_entrenamiento(
	centro_id int identity primary key,
	centro_accessPassword varchar(30) not null,
	centro_nombre varchar(100) unique not null, 
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


alter table tb_centro_entrenamiento alter column centro_hora_cierre time






select CEILING(88*0.1)


CREATE TABLE tb_control(
	control_id int identity primary key,
	control_centro_id int not null,
	control_capacidad int not null,
	control_hora_bloque_inicio time not null,
	control_hora_bloque_final time not null,
	control_hora_dia date not null,
	foreign key (control_centro_id) references tb_centro_entrenamiento(centro_id)
)

select 4*0.01


drop procedure sp_getHorarios




create procedure sp_generar(@id int,@fecha date)
as

declare @totalH float,@aux int,@capacidad int;

set @totalH=(Select ((DATEDIFF(second, centro_hora_apertura, centro_hora_cierre) / 3600.0)/2) from tb_centro_entrenamiento where centro_id=@id);

set @aux=1;

select @capacidad=CEILING(centro_capacidad_maxima*(centro_porcentaje_permitido*0.01)) from tb_centro_entrenamiento where centro_id=@id;

declare @HI time,@HF time,@horaA time;

Select @horaA=centro_hora_apertura  from tb_centro_entrenamiento where centro_id=@id;

while @totalH>0

begin

	if (@totalH<1)
	begin

		set @HI=(select DATEADD(hour,(@aux-1)*2 ,@horaA))
		set @HF=(select 	centro_hora_cierre  from tb_centro_entrenamiento where centro_id=@id);
		insert into tb_control values(@id,@capacidad,@HI,@HF,@fecha);  
	end
	else
	begin
		set @HI=(select DATEADD(hour,(@aux-1)*2 ,@horaA))
		set @HF=(select DATEADD(hour,@aux*2 ,@horaA))
		insert into tb_control values(@id,@capacidad,@HI,@HF,@fecha);  
	end

	set @totalH=@totalH-1;
	set @aux=@aux+1;
end

drop procedure sp_getHorarios

select CONVERT(varchar, control_hora_dia, 23), from tb_control


drop procedure sp_getHorarios

create procedure sp_getHorarios(@id int,@fecha date)
as

if not exists(select top 1 control_centro_id from tb_control where control_centro_id=@id and control_hora_dia=@fecha order by control_hora_dia asc)
	exec sp_generar @id,@fecha;

select control_id,control_capacidad,convert(varchar(5), control_hora_bloque_inicio, 108)+'-'+convert(varchar(5), control_hora_bloque_final, 108) control_hora_bloque
 from tb_control where control_centro_id=@id and control_hora_dia=@fecha and control_capacidad>0;
	

	
select * from tb_control


drop table tb_control


exec sp_getHorarios 1,'2020-7-6';


select * from tb_centro_entrenamiento
select * from tb_control




create table centro_usuario(
	centro_id int primary key,
	centro_usuario varchar(30),
	foreign key(centro_id) references tb_centro_entrenamiento(centro_id),
	foreign key(centro_usuario) references tb_usuario(	usuario_userName )
)




insert into centro_usuario values(1,'DGCR')

select * from centro_usuario


select * from tb_usuario


exec sp_loginToCentro 1,'DGCR','123'

drop procedure sp_loginToCentro

CREATE PROCEDURE sp_loginToCentro(@id int, @usuario varchar(30),@pass varchar(30),@result char OUTPUT)
as
if exists (Select 'S' as Estado from centro_usuario CU join tb_usuario U on CU.centro_usuario=U.usuario_userName where CU.centro_id=@id and CU.centro_usuario=@usuario and U.usuario_password=@pass)
	set @result='S';
else
	set @result='E';

declare @r char;

exec sp_loginToCentro 1,'DGCR','123',@r output;

print @r;

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



CREATE TABLE tb_reservacion(
	id int identity primary key,
	usuario varchar(30) foreign key references tb_usuario(usuario_userName),
	idHorario int foreign key references tb_control(control_id)
)

CREATE PROCEDURE sp_reservar(@usuario varchar(30), @idH int)
as
insert into tb_reservacion values(@usuario,@idH);
update tb_control set control_capacidad=control_capacidad-1 where control_id=@idH;

exec sp_reservar 'DGCR',1

select * from tb_control

