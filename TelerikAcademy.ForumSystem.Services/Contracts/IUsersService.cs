using System.Linq;
using TelerikAcademy.ForumSystem.Data.Model;

namespace TelerikAcademy.ForumSystem.Services
{
    public interface IUsersService
    {
        IQueryable<User> GetAll();
        
        void Delete(User order);
    }
}