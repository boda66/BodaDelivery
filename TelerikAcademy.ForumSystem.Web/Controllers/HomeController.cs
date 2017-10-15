using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using System;
using System.Linq;
using System.Web.Mvc;
using TelerikAcademy.ForumSystem.Services;
using TelerikAcademy.ForumSystem.Web.Models.Home;

namespace TelerikAcademy.ForumSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMealService mealsService;
        private readonly IMapper mapper;

        public HomeController(IMealService mealsService, IMapper mapper)
        {
            Guard.WhenArgument(mealsService, nameof(mealsService)).IsNull().Throw();
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();

            this.mealsService = mealsService;
            this.mapper = mapper;
        }
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
       

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}