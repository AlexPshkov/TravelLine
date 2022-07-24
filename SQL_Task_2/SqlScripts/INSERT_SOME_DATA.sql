-- TRUNCATE TABLE City;
-- TRUNCATE TABLE House;
-- TRUNCATE TABLE Flat;
-- TRUNCATE TABLE Citizen;

INSERT INTO City (CityName, Region, Country) 
VALUES ('Москва', 'Московская область', 'Россия'),
       ('Люберцы', 'Московская область', 'Россия'),
       ('Киров', 'Кировская область', 'Россия'),
       ('Йошкар-Ола', 'Республика Марий Эл', 'Россия'),
       ('Мытищи', 'Московская область', 'Россия');

INSERT INTO House (HouseNumber, FloorsNumber, StreetName , CityId)
VALUES ('423A', 5, 'Пятницкая', 1),
       ('56', 25, 'Казанская', 1),
       ('179', 3, 'Щипок', 1),
       ('150B', 3, 'Добровольская', 1),
       ('1254A', 10, 'Люсиновская', 1);

INSERT INTO House (HouseNumber, FloorsNumber, StreetName , CityId)
VALUES ('1A', 9, 'Яничкина', 2),
       ('356', 8, 'Железнодорожная', 2),
       ('79', 5, 'Перковая', 2),
       ('640B', 25, 'Садовая', 2),
       ('525', 135, 'Кирова', 2);

INSERT INTO House (HouseNumber, FloorsNumber, StreetName , CityId)
VALUES ('16', 11, 'Щорса', 3),
       ('56', 12, 'Водопроводная', 3),
       ('196', 16, 'Октябрьская', 3),
       ('14', 17, 'Блюхера', 3),
       ('15', 1, 'Воровского', 3);

INSERT INTO House (HouseNumber, FloorsNumber, StreetName , CityId)
VALUES ('126A', 9, 'Строителей', 4),
       ('356', 9, 'Крылова', 4),
       ('1796', 15, 'Мира', 4),
       ('14', 20, 'Красноармейская', 4),
       ('123A', 2, 'Дружбы', 4);

INSERT INTO House (HouseNumber, FloorsNumber, StreetName , CityId)
VALUES ('1253', 2, 'Белобородова', 5),
       ('356', 5, 'Рождественская', 5),
       ('179', 5, 'Колонцова', 5),
       ('14', 5, 'Титова', 5),
       ('125', 5, 'Бояринова', 5);


INSERT INTO Flat (FlatNumber, HouseId)
VALUES (5, 1),
       (1, 1),
       (2, 1),
       (3, 1),
       (4, 1);

INSERT INTO Flat (FlatNumber, HouseId)
VALUES (5, 2),
       (1, 2),
       (2, 2),
       (3, 2),
       (4, 2);

INSERT INTO Flat (FlatNumber, HouseId)
VALUES (5, 3),
       (1, 3),
       (2, 3),
       (3, 3),
       (4, 3);

INSERT INTO Flat (FlatNumber, HouseId)
VALUES (5, 4),
       (1, 4),
       (2, 4),
       (3, 4),
       (4, 4);

INSERT INTO Flat (FlatNumber, HouseId)
VALUES (5, 5),
       (1, 5),
       (2, 5),
       (3, 5),
       (4, 5);

INSERT INTO Flat (FlatNumber, HouseId)
VALUES (5, 6),
       (1, 6),
       (2, 6),
       (3, 6),
       (4, 6);

INSERT INTO Flat (FlatNumber, HouseId)
VALUES (5, 7),
       (1, 7),
       (2, 7),
       (3, 7),
       (4, 7);

INSERT INTO Flat (FlatNumber, HouseId)
VALUES (5, 8),
       (1, 8),
       (2, 8),
       (3, 8),
       (4, 8);

INSERT INTO Flat (FlatNumber, HouseId)
VALUES (5, 9),
       (1, 9),
       (2, 9),
       (3, 9),
       (4, 9);

INSERT INTO Flat (FlatNumber, HouseId)
VALUES (5, 10),
       (1, 10),
       (2, 10),
       (3, 10),
       (4, 10);


INSERT INTO Citizen (LastName, FirstName, FlatId)
VALUES ('Лебедев', 'Матвей', 1),
       ('Корнилова', 'Елизавета', 1),
       ('Борисова', 'Анастасия', 2),
       ('Павловская', 'Алина', 3),
       ('Антонов', 'Лев', 4);

INSERT INTO Citizen (LastName, FirstName, FlatId)
VALUES ('Чернышев', 'Илья', 5),
       ('Горелов', 'Леонид', 5),
       ('Федоров', 'Егор', 6),
       ('Никитина', 'София', 7),
       ('Дубинин', 'Владимир', 8);

INSERT INTO Citizen (LastName, FirstName, FlatId)
VALUES ('Чернов', 'Андрей', 9),
       ('Майоров', 'Павел', 9),
       ('Лебедев', 'Тимофей', 10),
       ('Лебедева', 'Виктория', 11),
       ('Киселев', 'Даниил', 12);

INSERT INTO Citizen (LastName, FirstName, FlatId)
VALUES ('Авдеев', 'Виктор', 13),
       ('Ершов', 'Максим', 13),
       ('Никонов', 'Даниил', 14),
       ('Зверева', 'Ева', 15),
       ('Куликов', 'Михаил', 16);

INSERT INTO Citizen (LastName, FirstName, FlatId)
VALUES ('Смирнов', 'Егор', 17),
       ('Макарова', 'София', 17),
       ('Софронова', 'Кристина', 18),
       ('Пирогов', 'Максим', 19),
       ('Иванова', 'Маргарита', 20);

INSERT INTO Citizen (LastName, FirstName, FlatId)
VALUES ('Давыдова', 'Анна', 21),
       ('Николаев', 'Роман', 22),
       ('Бондарев', 'Матвей', 23),
       ('Евдокимова', 'Арина', 24),
       ('Гусева', 'Таисия', 25);

INSERT INTO Citizen (LastName, FirstName, FlatId)
VALUES ('Чернышев', 'Илья', 26),
       ('Горелов', 'Леонид', 27),
       ('Федоров', 'Егор', 28),
       ('Никитина', 'София', 29),
       ('Дубинин', 'Владимир', 30);

INSERT INTO Citizen (LastName, FirstName, FlatId)
VALUES ('Чернов', 'Андрей', 31),
       ('Майоров', 'Павел', 32),
       ('Лебедев', 'Тимофей', 33),
       ('Лебедева', 'Виктория', 34),
       ('Киселев', 'Даниил', 35);

INSERT INTO Citizen (LastName, FirstName, FlatId)
VALUES ('Авдеев', 'Виктор', 36),
       ('Ершов', 'Максим', 37),
       ('Никонов', 'Даниил', 38),
       ('Зверева', 'Ева', 39),
       ('Куликов', 'Михаил', 40);

INSERT INTO Citizen (LastName, FirstName, FlatId)
VALUES ('Смирнов', 'Егор', 41),
       ('Макарова', 'София', 42),
       ('Софронова', 'Кристина', 43),
       ('Пирогов', 'Максим', 44),
       ('Иванова', 'Маргарита', 45);

INSERT INTO Citizen (LastName, FirstName, FlatId)
VALUES ('Давыдова', 'Анна', 46),
       ('Николаев', 'Роман', 47),
       ('Бондарев', 'Матвей', 48),
       ('Евдокимова', 'Арина', 49),
       ('Гусева', 'Таисия', 50);