using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Web;
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
            Guard.WhenArgument(mealsService, nameof(mealsService)).IsNull().Throw();
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();
            Guard.WhenArgument(ordersService, nameof(ordersService)).IsNull().Throw();

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
        public ActionResult AddMeal()
        {
            return View();
        }
        [Authorize]
        public ActionResult Add(MealViewModel mealModel)
        {
            this.mealsService.Add(new Meal() { Title = mealModel.Title, Image = mealModel.Image, Price = mealModel.Price, Content = mealModel.Content });
            return this.RedirectToAction("Index", "Home");
        }
    }
}