using System.Linq;
using TelerikAcademy.ForumSystem.Data.Model;
using TelerikAcademy.ForumSystem.Data.Repositories;
using TelerikAcademy.ForumSystem.Data.SaveContext;

namespace TelerikAcademy.ForumSystem.Services
{
    public class OrderService : IOrderService
    {
        private readonly IEfRepository<Order> orderRepo;
        private readonly ISaveContext context;

        public OrderService(IEfRepository<Order> orderRepo, ISaveContext context)
        {
            this.orderRepo = orderRepo;
            this.context = context;
        }

        public IQueryable<Order> GetAll()
        {
            return this.orderRepo.All;
        }

        public void Add(Order order)
        {
            this.orderRepo.Add(order);
            this.context.Commit();
        }

        public void Update(Order order)
        {
            this.orderRepo.Update(order);
            this.context.Commit();
        }

        public void Delete(Order order)
        {
            this.orderRepo.Delete(order);
            this.context.Commit();
        }
    }
}
