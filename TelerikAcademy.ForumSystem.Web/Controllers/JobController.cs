using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;
using TelerikAcademy.ForumSystem.Data.Model;
using TelerikAcademy.ForumSystem.Services;
using TelerikAcademy.ForumSystem.Web.Models.Home;

namespace TelerikAcademy.ForumSystem.Web.Controllers
{
    public class JobController : Controller
    {
        private readonly IAppliesService appliesService;
        private readonly IUsersService usersService;
        private readonly IMapper mapper;

        public JobController(IAppliesService appliesService, IMapper mapper, IUsersService usersService)
        {
            this.appliesService = appliesService;
            this.mapper = mapper;
            this.usersService = usersService;
        }

        [Authorize]
        public ActionResult ApplyForJob()
        {
            Applies apply = new Applies() { Id = Guid.NewGuid(), UserName = User.Identity.Name, UserId = User.Identity.GetUserId() };
            this.appliesService.Add(apply);

            return this.RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult AdminApplies()
        {
            var applies = this.appliesService
                .GetAll()
                .ProjectTo<ApplyViewModel>()
                .ToList();

            var viewModel = new AppliesViewModel()
            {
                Apply = applies
            };
            return View(viewModel);
        }
        [Authorize]
        public virtual ActionResult Reject(Guid id)
        {
            var apply = this.appliesService
                .GetAll()
                .Where(x => x.Id == id)
                .First();

            this.appliesService.Delete(apply);

            return this.RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult ManageEmployees()
        {
            var users = this.usersService
                .GetAll()
                .ProjectTo<UserViewModel>()
                .ToList();

            var viewModel = new UsersViewModel()
            {
                Users = new Collection<UserViewModel>()
            };
            foreach (var user in users)
            {
                if (user.Roles.ElementAt(0).RoleId == "fc8b443d-e00a-46fc-84e2-5b3584fb1539")
                {
                    viewModel.Users.Add(user);
                }
            }

            return View(viewModel);
        }

    }
}