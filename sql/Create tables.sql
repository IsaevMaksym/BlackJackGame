CREATE TABLE PLAYERS
(
	[PlayerID] INT NOT NULL PRIMARY KEY IDENTITY,
	[NickName] NVARCHAR(20) NOT NULL UNIQUE,
	[Password] nvarchar(50) NOT NULL,
	[GamesCount] INT,
	[WinCount] INT,	
	[Coins] int 
)
CREATE TABLE Games
(
	[GameID] INT NOT NULL PRIMARY KEY IDENTITY,
	[Player_1_ID] INT REFERENCES PLAYERS(PlayerID),
	[GameLog] varChar(100) not null,
	[WINNER] INT,
	[Date] datetime
)

create TABLE Cards
(
	[CardID] INT NOT NULL PRIMARY KEY IDENTITY,
	[CardName] char(20),
	[CardSuit] char(20)
)