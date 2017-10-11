using System.Linq;
using TelerikAcademy.ForumSystem.Data.Model;
using TelerikAcademy.ForumSystem.Data.Repositories;
using TelerikAcademy.ForumSystem.Data.SaveContext;

namespace TelerikAcademy.ForumSystem.Services
{
    public class UsersService : IUsersService
    {
        private readonly IEfRepository<User> userRepo;
        private readonly ISaveContext context;

        public UsersService(IEfRepository<User> userRepo, ISaveContext context)
        {
            this.userRepo = userRepo;
            this.context = context;
        }

        public IQueryable<User> GetAll()
        {
            return this.userRepo.All;
        }
        
        public void Update(User user)
        {
            this.userRepo.Update(user);
            this.context.Commit();
        }

        public void Delete(User user)
        {
            this.userRepo.Delete(user);
            this.context.Commit();
        }
    }
}
