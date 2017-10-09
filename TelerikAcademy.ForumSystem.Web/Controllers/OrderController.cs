using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity.Owin;
using System;
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
        
        [Authorize]
        public ActionResult AllOrders()
        {
            var order = this.ordersService
                .GetAll()
                .ProjectTo<OrderViewModel>()
                .ToList();

            var viewModel = new OrdersViewModel()
            {
                Order = order
            };

            return View(viewModel);
        }
        [Authorize]
        public ActionResult TakeOrder(Guid id)
        {
            var order = this.ordersService
                .GetAll()
                .Where(x => x.Id == id)
                .First();

            this.ordersService.Delete(order);

            return this.RedirectToAction("Index", "Home");
        }
        
        [Authorize]
        public ActionResult MyOrders()
        {
            var order = this.ordersService
                .GetAll()
                .Where(x => x.UserName == User.Identity.Name)
                .ProjectTo<OrderViewModel>()
                .ToList();

            var viewModel = new OrdersViewModel()
            {
                Order = order
            };

            return View(viewModel);
        }
    }
}