using System.Linq;
using TelerikAcademy.ForumSystem.Data.Model;
using TelerikAcademy.ForumSystem.Data.Repositories;
using TelerikAcademy.ForumSystem.Data.SaveContext;

namespace TelerikAcademy.ForumSystem.Services
{
    public class MealService : IMealService
    {
        private readonly IEfRepository<Meal> mealRepo;
        private readonly ISaveContext context;

        public MealService(IEfRepository<Meal> mealRepo, ISaveContext context)
        {
            this.mealRepo = mealRepo;
            this.context = context;
        }

        public IQueryable<Meal> GetAll()
        {
            return this.mealRepo.All;
        }

        public void Update(Meal meal)
        {
            this.mealRepo.Update(meal);
            this.context.Commit();
        }
    }
}
