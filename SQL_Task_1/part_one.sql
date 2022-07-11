# ====== [Init database] ======
DROP DATABASE IF EXISTS `CityMap`;
CREATE DATABASE `CityMap`;

# Create table with cities
CREATE TABLE IF NOT EXISTS CityMap.City
(
    `UUID`    INT AUTO_INCREMENT,
    `CityName`    VARCHAR(255) NOT NULL,
    `Region`  VARCHAR(255) NOT NULL,
    `Country` VARCHAR(50)  NOT NULL,
    PRIMARY KEY (`UUID`)
) DEFAULT CHAR SET utf8mb4;

# Create table with houses
CREATE TABLE IF NOT EXISTS CityMap.House
(
    `UUID`         INT AUTO_INCREMENT,
    `HouseNumber`  VARCHAR(25)  NOT NULL,
    `FloorsNumber` INT          NOT NULL,
    `StreetName`   VARCHAR(255) NOT NULL,
    `CityId`       INT,
    PRIMARY KEY (`UUID`),

    INDEX (`CityId`),
    FOREIGN KEY (`CityId`)
        REFERENCES CityMap.City (`UUID`)
        ON UPDATE CASCADE ON DELETE RESTRICT
) DEFAULT CHAR SET utf8mb4;

# Create table with flats
CREATE TABLE IF NOT EXISTS CityMap.Flat
(
    `UUID`       INT AUTO_INCREMENT,
    `FlatNumber` INT NOT NULL,
    `HouseId`    INT,
    PRIMARY KEY (`UUID`),

    INDEX (`HouseId`),
    FOREIGN KEY (`HouseId`)
        REFERENCES CityMap.House (`UUID`)
        ON UPDATE CASCADE ON DELETE RESTRICT
) DEFAULT CHAR SET utf8mb4;

# Create table with citizens
CREATE TABLE IF NOT EXISTS CityMap.Citizen
(
    `UUID`      INT AUTO_INCREMENT,
    `LastName`  VARCHAR(255) NOT NULL,
    `FirstName` VARCHAR(255) NOT NULL,
    `FlatId`    INT,
    PRIMARY KEY (`UUID`),

    INDEX (`FlatId`),
    FOREIGN KEY (`FlatId`)
        REFERENCES CityMap.Flat (`UUID`)
        ON UPDATE CASCADE ON DELETE RESTRICT
) DEFAULT CHAR SET utf8mb4;
