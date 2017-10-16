using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
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
        private readonly IUsersService usersService;
        public OrderController(IMapper mapper, IOrderService ordersService, IUsersService usersService)
        {
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();
            Guard.WhenArgument(ordersService, nameof(ordersService)).IsNull().Throw();
            Guard.WhenArgument(usersService, nameof(usersService)).IsNull().Throw();

            this.mapper = mapper;
            this.ordersService = ordersService;
            this.usersService = usersService;
        }
        
        [Authorize]
        public ActionResult Order(string userName, string meal)
        {
            //this.postsService.Update()
            var users = this.usersService
                 .GetAll()
                 .Where(x => x.UserName == userName)
                 .First();

            Order order = new Order() { Title = meal, Address = users.Address, UserName = userName };
            this.ordersService.Add(order);
            
            return this.RedirectToAction("Meals", "Meal");
        }
        
        [Authorize]
        public ActionResult AllOrders()
        {
            var order = this.ordersService
                .GetAll()
                .OrderBy(x=>x.UserName)
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