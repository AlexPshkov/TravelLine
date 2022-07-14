# SQL_Task_2
 ### ```Консольное приложение для работы с репозиториями```

---
> В качестве СУБД используется MySQL, а это значит, что для
> тестирования этого приложения она будет так же необходима

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
- **exit** - Завершить выполнение программы
  > ![alt-текст](https://alexpshkov.ru/screens/exit.gif)