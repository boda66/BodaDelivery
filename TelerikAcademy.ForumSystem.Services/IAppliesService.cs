using System.Linq;
using TelerikAcademy.ForumSystem.Data.Model;

namespace TelerikAcademy.ForumSystem.Services
{
    public interface IAppliesService
    {
        IQueryable<Applies> GetAll();

        void Add(Applies order);

        void Delete(Applies order);
    }
}