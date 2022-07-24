# SQL_Task_2
### Консольная приложенька для простой работы с бд

---
#### Для работы доступны СУБД: **MySQL (рекомендовано)**, **SQLite**, **MS SQL** 


> Для смены СУБД достаточно заменить `MySqlConnection`
  ```C#
private static readonly IRepository StorageRepository = new SqlRepository<MySqlConnection>("TravelLine");
  ```

---
Доступные команды
------ 
- **help** - Показать список всех доступных команд
  > Все команды подгружаются автоматически. Достаточно лишь экстенднуть класс `AbstractCommand`

  ![alt-текст](https://alexpshkov.ru/screens/help-command.gif)

---
- **get-all** `<city | flat | citizen | house> [condition]` - Показать список всех объектов
  > Будут выведены все объекты из одной таблицы. С помощью условия можно выбрать какие объекты вам нужны

  ![alt-текст](https://alexpshkov.ru/screens/get-all.gif)
---
- **update** `<city | flat | citizen | house> <ID>` - Обновить все поля у сущности
  > В случае неверно введенного значения вас уведомят. Не беспокойтесь)

  ![alt-текст](https://alexpshkov.ru/screens/update.gif)
---
- **remove** `<city | flat | citizen | house> <ID>` - Удалить объект из таблицы
  > Просто удаление. Ничего сложного

  ![alt-текст](https://alexpshkov.ru/screens/remove.gif)

---
- **get-citizen-skyscrapers** - Вывести жителей, живущих в многоэтажках
  > Многоэтажкой считается дом с кол-вом этажей >= 10

  ![alt-текст](https://alexpshkov.ru/screens/get-citizen-skyscrapers.gif)
---
- **fill-data** - Заполнить БД данными
  > Данная команда выполнит скрипт `SqlScripts/INSERT_SOME_DATA.sql`

  ![alt-текст](https://alexpshkov.ru/screens/fill-data.gif)
---
- **exit** - Завершить выполнение программы
  ![alt-текст](https://alexpshkov.ru/screens/exit.gif)
