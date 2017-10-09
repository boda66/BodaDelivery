using System.Linq;
using TelerikAcademy.ForumSystem.Data.Model;

namespace TelerikAcademy.ForumSystem.Services
{
    public interface IOrderService
    {
        IQueryable<Order> GetAll();

        void Add(Order order);

        void Delete(Order order);
    }
}