use TournamentSystem
GO

CREATE Table Person 
(
	FirstName varchar(255) not null,
	LastName varchar(255) not null,
	NickName varchar(255) not null,
	BirthDate date,
	Email nvarchar(256) primary key not null
);