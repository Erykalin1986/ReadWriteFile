using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;

namespace Models
{
    public class User : IUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public override string ToString()
        {
            return $"Идентификатор: {Id}, Фамилия: {Surname}, Имя: {Name}.";
        }

        /// <summary>
        /// Получает всех пользователей из файла.
        /// </summary>
        /// <returns>Список пользователей.</returns>
        public List<User> GetAllUsers()
        {
            string userJSON = DBFile.ReadFile();
            List<User> users = JsonConvert.DeserializeObject<List<User>>(userJSON);
            return users ?? new List<User>();
        }

        /// <summary>
        /// Получает пользователя из файла по его идентификационному номеру.
        /// </summary>
        /// <param name="id">Идентификационный номер.</param>
        /// <returns>Полученного пользователя.</returns>
        public User GetUserById(Guid id)
        {
            string userJSON = DBFile.ReadFile();
            return JsonConvert.DeserializeObject<List<User>>(userJSON).FirstOrDefault(f => f.Id == id);
        }

        /// <summary>
        /// Удаляет пользователя из файла по его идентификационному номеру.
        /// </summary>
        /// <param name="id">Идентификационный номер.</param>
        public void RemoveUserById(Guid id)
        {
            List<User> users = GetAllUsers();
            List<User> overUsers = users.Where(u => u.Id != id).ToList();
            string serilizedUsers = JsonConvert.SerializeObject(overUsers, Formatting.Indented);
            DBFile.WriteFile(serilizedUsers);
        }

        /// <summary>
        /// Сохраняет пользователя в файл.
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        /// <param name="surname">Фамилия пользователя.</param>
        public void SaveToJSON(string name, string surname)
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Surname = surname
            };
            List<User> currentAllUsers = this.GetAllUsers();
            currentAllUsers.Add(user);
            string serilizedUsers = JsonConvert.SerializeObject(currentAllUsers, Formatting.Indented);
            DBFile.WriteFile(serilizedUsers);
        }
    }
}
