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


/*
Create with AspNetUsers Normalized Email primary key on Person
use [3.SemesterDb]

ALTER TABLE ASPNetUsers ADD UNIQUE (NormalizedEmail);

CREATE Table Person 
(
	FirstName varchar(255) not null,
	LastName varchar(255) not null,
	NickName varchar(255) not null,
	BirthDate date,
	Email nvarchar(256) PRIMARY KEY,
	FOREIGN KEY (Email) REFERENCES AspNetUsers(NormalizedEmail)
);

*/