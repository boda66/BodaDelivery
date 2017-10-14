using System.Linq;
using TelerikAcademy.ForumSystem.Data.Model;

namespace TelerikAcademy.ForumSystem.Services
{
    public interface IMealService
    {
        IQueryable<Meal> GetAll();

        void Add(Meal meal);
    }
}