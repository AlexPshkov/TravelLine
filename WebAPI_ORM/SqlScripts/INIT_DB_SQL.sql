IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'TravelLine')
CREATE DATABASE TravelLine;
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name='City')
CREATE TABLE City
(
    UUID     INTEGER PRIMARY KEY IDENTITY (1, 1),
    CityName VARCHAR(255) NOT NULL,
    Region   VARCHAR(255) NOT NULL,
    Country  VARCHAR(50)  NOT NULL
);
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name='House')
CREATE TABLE House
(
    UUID         INTEGER PRIMARY KEY IDENTITY (1, 1),
    HouseNumber  VARCHAR(25)  NOT NULL,
    FloorsNumber INT          NOT NULL,
    StreetName   VARCHAR(255) NOT NULL,
    CityId       INTEGER,

    FOREIGN KEY (CityId)
        REFERENCES City (UUID)
        ON UPDATE CASCADE
        ON DELETE SET NULL
);
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name='Flat')
CREATE TABLE Flat
(
    UUID       INTEGER PRIMARY KEY IDENTITY (1, 1),
    FlatNumber INTEGER NOT NULL,
    HouseId    INTEGER,

    FOREIGN KEY (HouseId)
        REFERENCES House (UUID)
        ON UPDATE CASCADE
        ON DELETE SET NULL
);
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name='Citizen')
CREATE TABLE Citizen
(
    UUID      INTEGER PRIMARY KEY IDENTITY (1, 1),
    LastName  VARCHAR(255) NOT NULL,
    FirstName VARCHAR(255) NOT NULL,
    FlatId    INTEGER,

    FOREIGN KEY (FlatId)
        REFERENCES Flat (UUID)
        ON UPDATE CASCADE
        ON DELETE SET NULL
);
GO