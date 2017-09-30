use PanstwaMiasta

create table Players(
	Id uniqueidentifier primary key not null,
	Nickname varchar(40) not null,
	Password varchar(200) not null, 
	Salt varchar(200) not null,
	CreatedAt datetime not null)