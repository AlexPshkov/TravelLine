﻿CREATE DATABASE IF NOT EXISTS TravelLine;

CREATE TABLE IF NOT EXISTS City
(
    `UUID`    INTEGER PRIMARY KEY AUTO_INCREMENT,
    `CityName`    VARCHAR(255) NOT NULL,
    `Region`  VARCHAR(255) NOT NULL,
    `Country` VARCHAR(50)  NOT NULL
) DEFAULT CHAR SET utf8mb4;

CREATE TABLE IF NOT EXISTS House
(
    `UUID`    INTEGER PRIMARY KEY AUTO_INCREMENT,
    `HouseNumber`  VARCHAR(25)  NOT NULL,
    `FloorsNumber` INT          NOT NULL,
    `StreetName`   VARCHAR(255) NOT NULL,
    `CityId`       INTEGER,

    FOREIGN KEY (`CityId`)
        REFERENCES City (`UUID`)
        ON UPDATE CASCADE
        ON DELETE SET NULL
) DEFAULT CHAR SET utf8mb4;

CREATE TABLE IF NOT EXISTS Flat
(
    `UUID`    INTEGER PRIMARY KEY AUTO_INCREMENT,
    `FlatNumber` INTEGER NOT NULL,
    `HouseId`    INTEGER,
    
    FOREIGN KEY (`HouseId`)
        REFERENCES House (`UUID`)
        ON UPDATE CASCADE
        ON DELETE SET NULL
) DEFAULT CHAR SET utf8mb4;

CREATE TABLE IF NOT EXISTS Citizen
(
    `UUID`    INTEGER PRIMARY KEY AUTO_INCREMENT,
    `LastName`  VARCHAR(255) NOT NULL,
    `FirstName` VARCHAR(255) NOT NULL,
    `FlatId`    INTEGER,

    FOREIGN KEY (`FlatId`)
        REFERENCES Flat (`UUID`)
        ON UPDATE CASCADE 
        ON DELETE SET NULL
) DEFAULT CHAR SET utf8mb4;
