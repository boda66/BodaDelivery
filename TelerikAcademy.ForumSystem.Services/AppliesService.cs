using System.Linq;
using TelerikAcademy.ForumSystem.Data.Model;
using TelerikAcademy.ForumSystem.Data.Repositories;
using TelerikAcademy.ForumSystem.Data.SaveContext;

namespace TelerikAcademy.ForumSystem.Services
{
    public class AppliesService : IAppliesService
    {
        private readonly IEfRepository<Applies> applyRepo;
        private readonly ISaveContext context;

        public AppliesService(IEfRepository<Applies> applyRepo, ISaveContext context)
        {
            this.applyRepo = applyRepo;
            this.context = context;
        }

        public IQueryable<Applies> GetAll()
        {
            return this.applyRepo.All;
        }

        public void Add(Applies apply)
        {
            this.applyRepo.Add(apply);
            this.context.Commit();
        }

        public void Update(Applies apply)
        {
            this.applyRepo.Update(apply);
            this.context.Commit();
        }

        public void Delete(Applies apply)
        {
            this.applyRepo.Delete(apply);
            this.context.Commit();
        }
    }
}
