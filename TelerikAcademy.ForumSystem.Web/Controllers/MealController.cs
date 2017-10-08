using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Web.Mvc;
using TelerikAcademy.ForumSystem.Data.Model;
using TelerikAcademy.ForumSystem.Services;
using TelerikAcademy.ForumSystem.Web.Models.Home;

namespace TelerikAcademy.ForumSystem.Web.Controllers
{
    public class MealController : Controller
    {
        private readonly IMealService mealsService;
        private readonly IMapper mapper;
        private readonly IOrderService ordersService;
        public MealController(IMealService mealsService, IMapper mapper, IOrderService ordersService)
        {
            this.mealsService = mealsService;
            this.mapper = mapper;
            this.ordersService = ordersService;
        }
        [Authorize]
        [HttpGet]
        public ActionResult Meals()
        {
            var meal = this.mealsService
                .GetAll()
                .ProjectTo<MealViewModel>()
                .ToList();

            var viewModel = new MealsViewModel()
            {
                Meal = meal
            };

            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Meals(MealViewModel model)
        {
            //this.postsService.Update()

            return this.RedirectToAction("Meals");
        }
        [Authorize]
        public ActionResult Order(string userName, string meal)
        {
            //this.postsService.Update()
            Order order = new Order() { Title = meal, UserName = userName };
            this.ordersService.Add(order);
            return this.RedirectToAction("Meals");
            //return this.RedirectToAction("Meals");
        }
    }
}