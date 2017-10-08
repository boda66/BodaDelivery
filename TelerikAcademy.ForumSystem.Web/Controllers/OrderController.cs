using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikAcademy.ForumSystem.Data.Model;
using TelerikAcademy.ForumSystem.Services;
using TelerikAcademy.ForumSystem.Web.Models.Home;

namespace TelerikAcademy.ForumSystem.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMapper mapper;
        private readonly IOrderService ordersService;
        public OrderController(IMapper mapper, IOrderService ordersService)
        {
            this.mapper = mapper;
            this.ordersService = ordersService;
        }
        
        [Authorize]
        public ActionResult Order(string userName, string meal)
        {
            //this.postsService.Update()
           
            Order order = new Order() { Title = meal, Address = null, UserName = userName };
            this.ordersService.Add(order);
            
            return this.RedirectToAction("Meals", "Meal");
        }
        
    }
}