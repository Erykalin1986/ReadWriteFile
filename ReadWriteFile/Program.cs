using Models;

bool isWork = true;
string allCommands = "0 - Вывести всех пользователей;\n1 - Вывести одного пользователя;\n2 - Сохранить пользователя;\n3 - Удалить пользователя;\n4 - Завершить работу программы.";
DBFile dBFile = new DBFile();
if (!File.Exists(dBFile.FilePath + dBFile.FileName))
{
    FileStream file = File.Create(dBFile.FilePath + dBFile.FileName);
    file.Close();
}
User user = new User();

while (isWork)
{
    Console.WriteLine(allCommands);

    string inputCommandStr = Console.ReadLine();
    int inputCommand = 0;

    try
    {
        inputCommand = int.Parse(inputCommandStr);
    }
    catch (FormatException)
    {
        Console.WriteLine("Нет такой команды!");
    }

    switch (inputCommand)
    {
        case 0:
            List<User> users = user.GetAllUsers();
            users.ForEach(user => Console.WriteLine(user));
            break;
        case 1:
            Console.WriteLine("Введите идентификатор пользователя");
            string idStr = Console.ReadLine();
            User userById = null;
            try
            {
                Guid id = Guid.Parse(idStr);
                if (id != null)
                {
                    user = user.GetUserById(id);
                    Console.WriteLine(user);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Не верный формат идентификатора!");
            }
            break;
        case 2:
            Console.WriteLine("Введите фамилию пользователя");
            string surname = Console.ReadLine();

            Console.WriteLine("Введите имя пользователя");
            string name = Console.ReadLine();
            user.SaveToJSON(name, surname);
            Console.WriteLine("Пользователь успешно сохранён.");
            break;
        case 3:
            Console.WriteLine("Введите идентификатор пользователя");
            string idRemoveStr = Console.ReadLine();
            User userRemoveById = null;
            try
            {
                Guid id = Guid.Parse(idRemoveStr);
                if (id != null)
                {
                    user.RemoveUserById(id);
                    Console.WriteLine("Пользователь успешно удалён.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Не верный формат идентификатора!");
            }
            break;
            break;
        case 4:
            isWork = false;
            Console.WriteLine("До свидания!");
            break;
        default:
            Console.WriteLine("Нет такой команды!");
            break;
    }
}