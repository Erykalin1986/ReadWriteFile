using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IUser
    {
        public User GetUserById(Guid id);
        public List<User> GetAllUsers();
        public void SaveToJSON(string name, string surname);
        public void RemoveUserById(Guid id);
    }
}
