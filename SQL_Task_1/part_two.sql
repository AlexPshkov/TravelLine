## ====== [Task 1. (CRUD)] ======

# Insert Cities
INSERT INTO CityMap.City 
VALUES (0, 'Москва', 'Московская область', 'Россия'),
       (0, 'Люберцы', 'Московская область', 'Россия'),
       (0, 'Киров', 'Кировская область', 'Россия'),
       (0, 'Йошкар-Ола', 'Республика Марий Эл', 'Россия'),
       (0, 'Мытищи', 'Московская область', 'Россия');

# Insert Houses
INSERT INTO CityMap.House
VALUES (0, '423A', 5, 'Пятницкая', 1),
       (0, '56', 25, 'Казанская', 1),
       (0, '179', 3, 'Щипок', 1),
       (0, '150B', 3, 'Добровольская', 1),
       (0, '1254A', 10, 'Люсиновская', 1);

INSERT INTO CityMap.House
VALUES (0, '1A', 9, 'Яничкина', 2),
       (0, '356', 8, 'Железнодорожная', 2),
       (0, '79', 5, 'Перковая', 2),
       (0, '640B', 25, 'Садовая', 2),
       (0, '525', 135, 'Кирова', 2);

INSERT INTO CityMap.House
VALUES (0, '16', 11, 'Щорса', 3),
       (0, '56', 12, 'Водопроводная', 3),
       (0, '196', 16, 'Октябрьская', 3),
       (0, '14', 17, 'Блюхера', 3),
       (0, '15', 1, 'Воровского', 3);

INSERT INTO CityMap.House
VALUES (0, '126A', 9, 'Строителей', 4),
       (0, '356', 9, 'Крылова', 4),
       (0, '1796', 15, 'Мира', 4),
       (0, '14', 20, 'Красноармейская', 4),
       (0, '123A', 2, 'Дружбы', 4);

INSERT INTO CityMap.House
VALUES (0, '1253', 2, 'Белобородова', 5),
       (0, '356', 5, 'Рождественская', 5),
       (0, '179', 5, 'Колонцова', 5),
       (0, '14', 5, 'Титова', 5),
       (0, '125', 5, 'Бояринова', 5);


# Insert Flats
INSERT INTO CityMap.Flat
VALUES (0, 5, 1),
       (0, 1, 1),
       (0, 2, 1),
       (0, 3, 1),
       (0, 4, 1);

INSERT INTO CityMap.Flat
VALUES (0, 5, 2),
       (0, 1, 2),
       (0, 2, 2),
       (0, 3, 2),
       (0, 4, 2);

INSERT INTO CityMap.Flat
VALUES (0, 5, 3),
       (0, 1, 3),
       (0, 2, 3),
       (0, 3, 3),
       (0, 4, 3);

INSERT INTO CityMap.Flat
VALUES (0, 5, 4),
       (0, 1, 4),
       (0, 2, 4),
       (0, 3, 4),
       (0, 4, 4);

INSERT INTO CityMap.Flat
VALUES (0, 5, 5),
       (0, 1, 5),
       (0, 2, 5),
       (0, 3, 5),
       (0, 4, 5);

INSERT INTO CityMap.Flat
VALUES (0, 5, 6),
       (0, 1, 6),
       (0, 2, 6),
       (0, 3, 6),
       (0, 4, 6);

INSERT INTO CityMap.Flat
VALUES (0, 5, 7),
       (0, 1, 7),
       (0, 2, 7),
       (0, 3, 7),
       (0, 4, 7);

INSERT INTO CityMap.Flat
VALUES (0, 5, 8),
       (0, 1, 8),
       (0, 2, 8),
       (0, 3, 8),
       (0, 4, 8);

INSERT INTO CityMap.Flat
VALUES (0, 5, 9),
       (0, 1, 9),
       (0, 2, 9),
       (0, 3, 9),
       (0, 4, 9);

INSERT INTO CityMap.Flat
VALUES (0, 5, 10),
       (0, 1, 10),
       (0, 2, 10),
       (0, 3, 10),
       (0, 4, 10);


# Insert Citizens
INSERT INTO CityMap.Citizen
VALUES (0, 'Лебедев', 'Матвей', 1),
       (0, 'Корнилова', 'Елизавета', 1),
       (0, 'Борисова', 'Анастасия', 2),
       (0, 'Павловская', 'Алина', 3),
       (0, 'Антонов', 'Лев', 4);

INSERT INTO CityMap.Citizen
VALUES (0, 'Чернышев', 'Илья', 5),
       (0, 'Горелов', 'Леонид', 5),
       (0, 'Федоров', 'Егор', 6),
       (0, 'Никитина', 'София', 7),
       (0, 'Дубинин', 'Владимир', 8);

INSERT INTO CityMap.Citizen
VALUES (0, 'Чернов', 'Андрей', 9),
       (0, 'Майоров', 'Павел', 9),
       (0, 'Лебедев', 'Тимофей', 10),
       (0, 'Лебедева', 'Виктория', 11),
       (0, 'Киселев', 'Даниил', 12);

INSERT INTO CityMap.Citizen
VALUES (0, 'Авдеев', 'Виктор', 13),
       (0, 'Ершов', 'Максим', 13),
       (0, 'Никонов', 'Даниил', 14),
       (0, 'Зверева', 'Ева', 15),
       (0, 'Куликов', 'Михаил', 16);

INSERT INTO CityMap.Citizen
VALUES (0, 'Смирнов', 'Егор', 17),
       (0, 'Макарова', 'София', 17),
       (0, 'Софронова', 'Кристина', 18),
       (0, 'Пирогов', 'Максим', 19),
       (0, 'Иванова', 'Маргарита', 20);

INSERT INTO CityMap.Citizen
VALUES (0, 'Давыдова', 'Анна', 21),
       (0, 'Николаев', 'Роман', 22),
       (0, 'Бондарев', 'Матвей', 23),
       (0, 'Евдокимова', 'Арина', 24),
       (0, 'Гусева', 'Таисия', 25);

INSERT INTO CityMap.Citizen
VALUES (0, 'Чернышев', 'Илья', 26),
       (0, 'Горелов', 'Леонид', 27),
       (0, 'Федоров', 'Егор', 28),
       (0, 'Никитина', 'София', 29),
       (0, 'Дубинин', 'Владимир', 30);

INSERT INTO CityMap.Citizen
VALUES (0, 'Чернов', 'Андрей', 31),
       (0, 'Майоров', 'Павел', 32),
       (0, 'Лебедев', 'Тимофей', 33),
       (0, 'Лебедева', 'Виктория', 34),
       (0, 'Киселев', 'Даниил', 35);

INSERT INTO CityMap.Citizen
VALUES (0, 'Авдеев', 'Виктор', 36),
       (0, 'Ершов', 'Максим', 37),
       (0, 'Никонов', 'Даниил', 38),
       (0, 'Зверева', 'Ева', 39),
       (0, 'Куликов', 'Михаил', 40);

INSERT INTO CityMap.Citizen
VALUES (0, 'Смирнов', 'Егор', 41),
       (0, 'Макарова', 'София', 42),
       (0, 'Софронова', 'Кристина', 43),
       (0, 'Пирогов', 'Максим', 44),
       (0, 'Иванова', 'Маргарита', 45);

INSERT INTO CityMap.Citizen
VALUES (0, 'Давыдова', 'Анна', 46),
       (0, 'Николаев', 'Роман', 47),
       (0, 'Бондарев', 'Матвей', 48),
       (0, 'Евдокимова', 'Арина', 49),
       (0, 'Гусева', 'Таисия', 50);


#Select Cities
SELECT *
FROM CityMap.City;

#Select Houses
SELECT *
FROM CityMap.House;

#Select Flats
SELECT *
FROM CityMap.Flat;

#Select Citizens
SELECT *
FROM CityMap.Citizen;


#Update citizen 
UPDATE Citymap.Citizen -- Житель с UUID = 1 переехал в другой город 
SET `FlatId` = 5
WHERE `UUID` = 1;


#Delete citizen 
DELETE -- Житель с UUID = 5 исключен из реестра
FROM Citymap.Citizen
WHERE `UUID` = 5;


## ====== [Task 2. (GROUP BY + aggregation func)] ======
SELECT Citymap.City.Region, COUNT(Citymap.City.Region) AS `Amount` -- Получаем кол-во городов в каждом регионе
FROM Citymap.City
GROUP BY Citymap.City.Region;


## ====== [Task 3. (GROUP BY + having)] ======
SELECT * -- Получаем многоэтажки
FROM Citymap.House
GROUP BY Citymap.house.UUID
HAVING MAX(Citymap.House.FloorsNumber) >= 10;



## ====== [Task 4. (JOIN tables)] ======
SELECT Citymap.Citizen.FirstName,
       Citymap.Citizen.LastName,
       Citymap.Flat.FlatNumber,
       Citymap.House.HouseNumber,
       Citymap.House.StreetName,
       Citymap.City.CityName,
       Citymap.City.Country
FROM Citymap.Citizen -- Имя и Фамилия + Номер квартиры + Номер дома + Улица + Город + Страна
         JOIN Citymap.Flat ON Citymap.Citizen.FlatId = Citymap.Flat.UUID
         JOIN Citymap.House ON Citymap.Flat.HouseId = Citymap.House.UUID
         JOIN Citymap.City ON Citymap.House.CityId = Citymap.City.UUID;
        
