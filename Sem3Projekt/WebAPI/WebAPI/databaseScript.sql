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

--Create with AspNetUsers Normalized Email primary key on Person
--use [3.SemesterDb]

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

CREATE table Tournament(
	TournamentId int identity not null primary key,
	MinParticipants int,
	MaxParticipants int not null,
	TimeOfEvent datetime not null,
	RegistrationDeadline datetime not null,
	TournamentName varchar(255) not null,
	EnrolledParticipants int not null
);

CREATE table PersonInTournament(
	PersonEmail nvarchar(256) foreign key references Person(Email),
	TournamentId int foreign key references Tournament(TournamentId),
	primary key(PersonEmail, TournamentId)
);
